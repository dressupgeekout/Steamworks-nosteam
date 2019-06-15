// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamVideo {
		/// Get a URL suitable for streaming the given Video app ID's video
		public static void GetVideoURL(AppId_t unVideoAppID) { }
		/// returns true if user is uploading a live broadcast
		public static bool IsBroadcasting(out int pnNumViewers) {
			pnNumViewers = 0;
			return false;
		}
		/// Get the OPF Details for 360 Video Playback
		public static void GetOPFSettings(AppId_t unVideoAppID) { }
		public static bool GetOPFStringForApp(AppId_t unVideoAppID, out string pchBuffer, ref int pnBufferSize) {
			pchBuffer = "";
			return false;
		}
	}
}
