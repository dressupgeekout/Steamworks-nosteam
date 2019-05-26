// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class CallbackDispatcher {
		// We catch exceptions inside callbacks and reroute them here.
		// For some reason throwing an exception causes RunCallbacks() to break otherwise.
		// If you have a custom ExceptionHandler in your engine you can register it here manually until we get something more elegant hooked up.
		public static void ExceptionHandler(Exception e) {
		}
	}

	public sealed class Callback<T> : IDisposable {
		private IntPtr m_pVTable = IntPtr.Zero;
		private GCHandle m_pCCallbackBase;

		public delegate void DispatchDelegate(T param);

		private bool m_bGameServer;
		private readonly int m_size = Marshal.SizeOf(typeof(T));

		private bool m_bDisposed = false;

		/// <summary>
		/// Creates a new Callback. You must be calling SteamAPI.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> Create(DispatchDelegate func) {
			return new Callback<T>(func, bGameServer: false);
		}

		/// <summary>
		/// Creates a new GameServer Callback. You must be calling GameServer.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> CreateGameServer(DispatchDelegate func) {
			return new Callback<T>(func, bGameServer: true);
		}

		public Callback(DispatchDelegate func, bool bGameServer = false) {
			m_bGameServer = bGameServer;
			BuildCCallbackBase();
			Register(func);
		}

		~Callback() {
			Dispose();
		}

		public void Dispose() {
			if (m_bDisposed) {
				return;
			}

			GC.SuppressFinalize(this);

			Unregister();

			if (m_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pVTable);
			}

			if (m_pCCallbackBase.IsAllocated) {
				m_pCCallbackBase.Free();
			}

			m_bDisposed = true;
		}

		// Manual registration of the callback
		public void Register(DispatchDelegate func) {
		}

		public void Unregister() {
		}

		public void SetGameserverFlag() {
		}

		private void OnRunCallback(IntPtr pvParam) {
		}

		// Shouldn't ever get called here, but this is what C++ Steamworks does!
		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall) {
		}

		private int OnGetCallbackSizeBytes() {
			return 0;
		}

		// Steamworks.NET Specific
		private void BuildCCallbackBase() {
		}
	}

	public sealed class CallResult<T> : IDisposable {
		private IntPtr m_pVTable = IntPtr.Zero;

		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
		private event APIDispatchDelegate m_Func;

		private SteamAPICall_t m_hAPICall = SteamAPICall_t.Invalid;
		public SteamAPICall_t Handle { get { return m_hAPICall; } }

		private readonly int m_size = Marshal.SizeOf(typeof(T));

		/// <summary>
		/// Creates a new async CallResult. You must be calling SteamAPI.RunCallbacks() to retrieve the callback.
		/// <para>Returns a handle to the CallResult.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static CallResult<T> Create(APIDispatchDelegate func = null) {
			return new CallResult<T>(func);
		}

		public CallResult(APIDispatchDelegate func = null) {
			m_Func = func;
			BuildCCallbackBase();
		}

		~CallResult() {
			Dispose();
		}

		public void Dispose() {
		}

		public void Set(SteamAPICall_t hAPICall, APIDispatchDelegate func = null) {
		}

		public bool IsActive() {
			return true;
		}

		public void Cancel() {
		}

		public void SetGameserverFlag() {
		}

		// Shouldn't ever get called here, but this is what C++ Steamworks does!
		private void OnRunCallback(IntPtr pvParam) {
		}

		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall_) {
		}

		private int OnGetCallbackSizeBytes() {
			return 0;
		}

		// Steamworks.NET Specific
		private void BuildCCallbackBase() {
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBase {
		public const byte k_ECallbackFlagsRegistered = 0x01;
		public const byte k_ECallbackFlagsGameServer = 0x02;

		public IntPtr m_vfptr;
		public byte m_nCallbackFlags;
		public int m_iCallback;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBaseVTable {
#if STDCALL
		private const CallingConvention cc = CallingConvention.StdCall;

		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCBDel(IntPtr pvParam);
		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCRDel(IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);
		[UnmanagedFunctionPointer(cc)]
		public delegate int GetCallbackSizeBytesDel();
#else
	#if THISCALL
		private const CallingConvention cc = CallingConvention.ThisCall;
	#else
		private const CallingConvention cc = CallingConvention.Cdecl;
	#endif

		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCBDel(IntPtr thisptr, IntPtr pvParam);
		[UnmanagedFunctionPointer(cc)]
		public delegate void RunCRDel(IntPtr thisptr, IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);
		[UnmanagedFunctionPointer(cc)]
		public delegate int GetCallbackSizeBytesDel(IntPtr thisptr);
#endif

		// RunCallback and RunCallResult are swapped in MSVC ABI
#if WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCRDel m_RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCBDel m_RunCallback;
#if !WINDOWS_BUILD
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RunCRDel m_RunCallResult;
#endif
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public GetCallbackSizeBytesDel m_GetCallbackSizeBytes;
	}
}
