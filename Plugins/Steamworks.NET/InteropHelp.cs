// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

using System.Text;

namespace Steamworks {
	public class InteropHelp {
		public static void TestIfPlatformSupported() { }
		public static void TestIfAvailableClient() { }
		public static void TestIfAvailableGameServer() { }

		public static string PtrToStringUTF8(IntPtr nativeUtf8) {
			if (nativeUtf8 == IntPtr.Zero) { return null; }
			int len = 0;
			while (Marshal.ReadByte(nativeUtf8, len) != 0) {
				++len;
			}

			if (len == 0) {
				return string.Empty;
			}

			byte[] buffer = new byte[len];
			Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
			return Encoding.UTF8.GetString(buffer);
		}

#if UNITY_EDITOR || UNITY_STANDALONE || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX
		public class UTF8StringHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid {
			public UTF8StringHandle(string str)
				: base(true) {
				if (str == null) {
					SetHandle(IntPtr.Zero);
					return;
				}

				byte[] strbuf = new byte[Encoding.UTF8.GetByteCount(str) + 1];
				Encoding.UTF8.GetBytes(str, 0, str.Length, strbuf, 0);
				IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length);
				Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

				SetHandle(buffer);
			}

			protected override bool ReleaseHandle() {
				if (!IsInvalid) {
					Marshal.FreeHGlobal(handle);
				}
				return true;
			}
		}
#else
		public class UTF8StringHandle : IDisposable {
			public UTF8StringHandle(string str) { }
			public void Dispose() {}
		}
#endif

		public class SteamParamStringArray {
			IntPtr[] m_Strings;
			IntPtr m_ptrStrings;
			IntPtr m_pSteamParamStringArray;

			public SteamParamStringArray(System.Collections.Generic.IList<string> strings) {
				if (strings == null) {
					m_pSteamParamStringArray = IntPtr.Zero;
					return;
				}

				m_Strings = new IntPtr[strings.Count];
				for (int i = 0; i < strings.Count; ++i) {
					byte[] strbuf = new byte[Encoding.UTF8.GetByteCount(strings[i]) + 1];
					Encoding.UTF8.GetBytes(strings[i], 0, strings[i].Length, strbuf, 0);
					m_Strings[i] = Marshal.AllocHGlobal(strbuf.Length);
					Marshal.Copy(strbuf, 0, m_Strings[i], strbuf.Length);
				}

				m_ptrStrings = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * m_Strings.Length);
				SteamParamStringArray_t stringArray = new SteamParamStringArray_t() {
					m_ppStrings = m_ptrStrings,
					m_nNumStrings = m_Strings.Length
				};
				Marshal.Copy(m_Strings, 0, stringArray.m_ppStrings, m_Strings.Length);

				m_pSteamParamStringArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamParamStringArray_t)));
				Marshal.StructureToPtr(stringArray, m_pSteamParamStringArray, false);
			}

			~SteamParamStringArray() {
				foreach (IntPtr ptr in m_Strings) {
					Marshal.FreeHGlobal(ptr);
				}

				if (m_ptrStrings != IntPtr.Zero) {
					Marshal.FreeHGlobal(m_ptrStrings);
				}

				if (m_pSteamParamStringArray != IntPtr.Zero) {
					Marshal.FreeHGlobal(m_pSteamParamStringArray);
				}
			}

			public static implicit operator IntPtr(SteamParamStringArray that) {
				return that.m_pSteamParamStringArray;
			}
		}
	}

	public class MMKVPMarshaller {
		private IntPtr m_pNativeArray;
		private IntPtr m_pArrayEntries;

		public MMKVPMarshaller(MatchMakingKeyValuePair_t[] filters) {
			if (filters == null) {
				return;
			}

			int sizeOfMMKVP = Marshal.SizeOf(typeof(MatchMakingKeyValuePair_t));
			m_pNativeArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * filters.Length);
			m_pArrayEntries = Marshal.AllocHGlobal(sizeOfMMKVP * filters.Length);
			for (int i = 0; i < filters.Length; ++i) {
				Marshal.StructureToPtr(filters[i], new IntPtr(m_pArrayEntries.ToInt64() + (i * sizeOfMMKVP)), false);
			}
			Marshal.WriteIntPtr(m_pNativeArray, m_pArrayEntries);
		}

		~MMKVPMarshaller() {
			if (m_pArrayEntries != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pArrayEntries);
			}
			if (m_pNativeArray != IntPtr.Zero) {
				Marshal.FreeHGlobal(m_pNativeArray);
			}
		}

		public static implicit operator IntPtr(MMKVPMarshaller that) {
			return that.m_pNativeArray;
		}
	}

	public class DllCheck {
#if DISABLED
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		extern static int GetModuleFileName(IntPtr hModule, StringBuilder strFullPath, int nSize);
#endif

		/// This is an optional runtime check to ensure that the dlls are the correct version. Returns false only if the steam_api.dll is found and it's the wrong size or version number.
		public static bool Test() { return true; }
		private static bool CheckSteamAPIDLL() { return false; }
	}
}
