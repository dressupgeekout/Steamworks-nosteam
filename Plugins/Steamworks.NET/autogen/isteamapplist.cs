// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamAppList {
		public static uint GetNumInstalledApps() {
			return (uint) 0;
		}

		public static uint GetInstalledApps(AppId_t[] pvecAppID, uint unMaxAppIDs) {
			return (uint) 0;
		}

		/// <summary>
		/// <para> returns -1 if no name was found</para>
		/// </summary>
		public static int GetAppName(AppId_t nAppID, out string pchName, int cchNameMax) {
			pchName = "";
			return 0;
		}

		/// <summary>
		/// <para> returns -1 if no dir was found</para>
		/// </summary>
		public static int GetAppInstallDir(AppId_t nAppID, out string pchDirectory, int cchNameMax) {
			pchDirectory = "";
			return 0;
		}

		/// <summary>
		/// <para> return the buildid of this app, may change at any time based on backend updates to the game</para>
		/// </summary>
		public static int GetAppBuildId(AppId_t nAppID) {
			return 0;
		}
	}
}
