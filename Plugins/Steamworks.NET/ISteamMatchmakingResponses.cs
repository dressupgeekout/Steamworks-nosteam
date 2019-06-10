// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public class ISteamMatchmakingServerListResponse {
		public delegate void ServerResponded(HServerListRequest hRequest, int iServer);
		public delegate void ServerFailedToRespond(HServerListRequest hRequest, int iServer);
		public delegate void RefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		private VTable m_VTable;
		private IntPtr m_pVTable;
		private GCHandle m_pGCHandle;
		private ServerResponded m_ServerResponded;
		private ServerFailedToRespond m_ServerFailedToRespond;
		private RefreshComplete m_RefreshComplete;

		public ISteamMatchmakingServerListResponse(ServerResponded onServerResponded, ServerFailedToRespond onServerFailedToRespond, RefreshComplete onRefreshComplete) {
			m_ServerResponded = onServerResponded;
			m_ServerFailedToRespond = onServerFailedToRespond;
			m_RefreshComplete = onRefreshComplete;

			m_VTable = new VTable() {
				m_VTServerResponded = InternalOnServerResponded,
				m_VTServerFailedToRespond = InternalOnServerFailedToRespond,
				m_VTRefreshComplete = InternalOnRefreshComplete
			};
			m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
			Marshal.StructureToPtr(m_VTable, m_pVTable, false);

			m_pGCHandle = GCHandle.Alloc(m_pVTable, GCHandleType.Pinned);
		}

		~ISteamMatchmakingServerListResponse() {
			if (m_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pVTable);
			}

			if (m_pGCHandle.IsAllocated) {
				m_pGCHandle.Free();
			}
		}
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond(HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);
		private void InternalOnServerResponded(HServerListRequest hRequest, int iServer) {
		}
		private void InternalOnServerFailedToRespond(HServerListRequest hRequest, int iServer) {
		}
		private void InternalOnRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response) {
		}
#else
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response);
		private void InternalOnServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer) {
		}
		private void InternalOnServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer) {
		}
		private void InternalOnRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response) {
		}
#endif

		[StructLayout(LayoutKind.Sequential)]
		private class VTable {
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerResponded m_VTServerResponded;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerFailedToRespond m_VTServerFailedToRespond;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalRefreshComplete m_VTRefreshComplete;
		}

		public static explicit operator System.IntPtr(ISteamMatchmakingServerListResponse that) {
			return that.m_pGCHandle.AddrOfPinnedObject();
		}
	};

	public class ISteamMatchmakingPingResponse {
		public delegate void ServerResponded(gameserveritem_t server);
		public delegate void ServerFailedToRespond();
		private VTable m_VTable;
		private IntPtr m_pVTable;
		private GCHandle m_pGCHandle;
		private ServerResponded m_ServerResponded;
		private ServerFailedToRespond m_ServerFailedToRespond;

		public ISteamMatchmakingPingResponse(ServerResponded onServerResponded, ServerFailedToRespond onServerFailedToRespond) {
			m_ServerResponded = onServerResponded;
			m_ServerFailedToRespond = onServerFailedToRespond;

			m_VTable = new VTable() {
				m_VTServerResponded = InternalOnServerResponded,
				m_VTServerFailedToRespond = InternalOnServerFailedToRespond,
			};
			m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
			Marshal.StructureToPtr(m_VTable, m_pVTable, false);

			m_pGCHandle = GCHandle.Alloc(m_pVTable, GCHandleType.Pinned);
		}

		~ISteamMatchmakingPingResponse() {
			if (m_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pVTable);
			}

			if (m_pGCHandle.IsAllocated) {
				m_pGCHandle.Free();
			}
		}

#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(gameserveritem_t server);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond();
		private void InternalOnServerResponded(gameserveritem_t server) { }
		private void InternalOnServerFailedToRespond() { }
#else
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerResponded(IntPtr thisptr, gameserveritem_t server);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerFailedToRespond(IntPtr thisptr);
		private void InternalOnServerResponded(IntPtr thisptr, gameserveritem_t server) { }
		private void InternalOnServerFailedToRespond(IntPtr thisptr) { }
#endif

		[StructLayout(LayoutKind.Sequential)]
		private class VTable {
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerResponded m_VTServerResponded;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalServerFailedToRespond m_VTServerFailedToRespond;
		}

		public static explicit operator System.IntPtr(ISteamMatchmakingPingResponse that) {
			return that.m_pGCHandle.AddrOfPinnedObject();
		}
	};

	public class ISteamMatchmakingPlayersResponse {
		public delegate void AddPlayerToList(string pchName, int nScore, float flTimePlayed);
		public delegate void PlayersFailedToRespond();
		public delegate void PlayersRefreshComplete();
		private VTable m_VTable;
		private IntPtr m_pVTable;
		private GCHandle m_pGCHandle;
		private AddPlayerToList m_AddPlayerToList;
		private PlayersFailedToRespond m_PlayersFailedToRespond;
		private PlayersRefreshComplete m_PlayersRefreshComplete;

		public ISteamMatchmakingPlayersResponse(AddPlayerToList onAddPlayerToList, PlayersFailedToRespond onPlayersFailedToRespond, PlayersRefreshComplete onPlayersRefreshComplete) {
			m_AddPlayerToList = onAddPlayerToList;
			m_PlayersFailedToRespond = onPlayersFailedToRespond;
			m_PlayersRefreshComplete = onPlayersRefreshComplete;
			
			m_VTable = new VTable() {
				m_VTAddPlayerToList = InternalOnAddPlayerToList,
				m_VTPlayersFailedToRespond = InternalOnPlayersFailedToRespond,
				m_VTPlayersRefreshComplete = InternalOnPlayersRefreshComplete
			};
			m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
			Marshal.StructureToPtr(m_VTable, m_pVTable, false);

			m_pGCHandle = GCHandle.Alloc(m_pVTable, GCHandleType.Pinned);
		}

		~ISteamMatchmakingPlayersResponse() {
			if (m_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pVTable);
			}

			if (m_pGCHandle.IsAllocated) {
				m_pGCHandle.Free();
			}
		}
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalAddPlayerToList(IntPtr pchName, int nScore, float flTimePlayed);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersFailedToRespond();
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersRefreshComplete();
		private void InternalOnAddPlayerToList(IntPtr pchName, int nScore, float flTimePlayed) { }
		private void InternalOnPlayersFailedToRespond() { }
		private void InternalOnPlayersRefreshComplete() { }
#else
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalAddPlayerToList(IntPtr thisptr, IntPtr pchName, int nScore, float flTimePlayed);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalPlayersFailedToRespond(IntPtr thisptr);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalPlayersRefreshComplete(IntPtr thisptr);
		private void InternalOnAddPlayerToList(IntPtr thisptr, IntPtr pchName, int nScore, float flTimePlayed) { }
		private void InternalOnPlayersFailedToRespond(IntPtr thisptr) { }
		private void InternalOnPlayersRefreshComplete(IntPtr thisptr) { }
#endif

		[StructLayout(LayoutKind.Sequential)]
		private class VTable {
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalAddPlayerToList m_VTAddPlayerToList;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalPlayersFailedToRespond m_VTPlayersFailedToRespond;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalPlayersRefreshComplete m_VTPlayersRefreshComplete;
		}

		public static explicit operator System.IntPtr(ISteamMatchmakingPlayersResponse that) {
			return that.m_pGCHandle.AddrOfPinnedObject();
		}
	};

	public class ISteamMatchmakingRulesResponse {
		public delegate void RulesResponded(string pchRule, string pchValue);
		public delegate void RulesFailedToRespond();
		public delegate void RulesRefreshComplete();
		private VTable m_VTable;
		private IntPtr m_pVTable;
		private GCHandle m_pGCHandle;
		private RulesResponded m_RulesResponded;
		private RulesFailedToRespond m_RulesFailedToRespond;
		private RulesRefreshComplete m_RulesRefreshComplete;

		public ISteamMatchmakingRulesResponse(RulesResponded onRulesResponded, RulesFailedToRespond onRulesFailedToRespond, RulesRefreshComplete onRulesRefreshComplete) {
			m_RulesResponded = onRulesResponded;
			m_RulesFailedToRespond = onRulesFailedToRespond;
			m_RulesRefreshComplete = onRulesRefreshComplete;

			m_VTable = new VTable() {
				m_VTRulesResponded = InternalOnRulesResponded,
				m_VTRulesFailedToRespond = InternalOnRulesFailedToRespond,
				m_VTRulesRefreshComplete = InternalOnRulesRefreshComplete
			};
			m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VTable)));
			Marshal.StructureToPtr(m_VTable, m_pVTable, false);

			m_pGCHandle = GCHandle.Alloc(m_pVTable, GCHandleType.Pinned);
		}

		~ISteamMatchmakingRulesResponse() {
			if (m_pVTable != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pVTable);
			}

			if (m_pGCHandle.IsAllocated) {
				m_pGCHandle.Free();
			}
		}
		
#if NOTHISPTR
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesResponded(IntPtr pchRule, IntPtr pchValue);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesFailedToRespond();
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesRefreshComplete();
		private void InternalOnRulesResponded(IntPtr pchRule, IntPtr pchValue) { }
		private void InternalOnRulesFailedToRespond() { }
		private void InternalOnRulesRefreshComplete() { }
#else
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesFailedToRespond(IntPtr thisptr);
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesRefreshComplete(IntPtr thisptr);
		private void InternalOnRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue) { }
		private void InternalOnRulesFailedToRespond(IntPtr thisptr) { }
		private void InternalOnRulesRefreshComplete(IntPtr thisptr) { }
#endif

		[StructLayout(LayoutKind.Sequential)]
		private class VTable {
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalRulesResponded m_VTRulesResponded;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalRulesFailedToRespond m_VTRulesFailedToRespond;

			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public InternalRulesRefreshComplete m_VTRulesRefreshComplete;
		}

		public static explicit operator System.IntPtr(ISteamMatchmakingRulesResponse that) {
			return that.m_pGCHandle.AddrOfPinnedObject();
		}
	};
}
