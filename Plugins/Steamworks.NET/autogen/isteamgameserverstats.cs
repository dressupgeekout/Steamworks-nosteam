// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerStats {
		///  downloads stats for the user
		///  returns a GSStatsReceived_t callback when completed
		///  if the user has no stats, GSStatsReceived_t.m_eResult will be set to k_EResultFail
		///  these stats will only be auto-updated for clients playing on the server. For other
		///  users you'll need to call RequestUserStats() again to refresh any data
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser) {
			return (SteamAPICall_t) 0;
		}

		///  requests stat information for a user, usable after a successful call to RequestUserStats()
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData) {
			pData = 0;
			return false;
		}

		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData) {
			pData = (float) 0.0;
			return false;
		}

		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved) {
			pbAchieved = false;
			return false;
		}

		///  Set / update stats and achievements.
		///  Note: These updates will work only on stats game servers are allowed to edit and only for
		///  game servers that have been declared as officially controlled by the game creators.
		///  Set the IP range of your official servers on the Steamworks page
		public static bool SetUserStat(CSteamID steamIDUser, string pchName, int nData) {
			return false;
		}

		public static bool SetUserStat(CSteamID steamIDUser, string pchName, float fData) {
			return false;
		}

		public static bool UpdateUserAvgRateStat(CSteamID steamIDUser, string pchName, float flCountThisSession, double dSessionLength) {
			return false;
		}

		public static bool SetUserAchievement(CSteamID steamIDUser, string pchName) {
			return false;
		}

		public static bool ClearUserAchievement(CSteamID steamIDUser, string pchName) {
			return false;
		}

		///  Store the current data on the server, will get a GSStatsStored_t callback when set.
		///  If the callback has a result of k_EResultInvalidParam, one or more stats
		///  uploaded has been rejected, either because they broke constraints
		///  or were out of date. In this case the server sends back updated values.
		///  The stats should be re-iterated to keep in sync.
		public static SteamAPICall_t StoreUserStats(CSteamID steamIDUser) {
			return (SteamAPICall_t) 0;
		}
	}
}
