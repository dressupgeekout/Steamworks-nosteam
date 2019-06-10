// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class Version {	// left in from upstream rlabrecque/Steamworks.NET from May/June 2019
		public const string SteamworksNETVersion = "13.0.0";
		public const string SteamworksSDKVersion = "1.43";
		public const string SteamAPIDLLVersion = "04.95.20.30";
		public const int SteamAPIDLLSize = 257312;
		public const int SteamAPI64DLLSize = 288032;
	}

	public static class SteamAPI {
		public static bool Init() { return true; }
		public static bool InitSafe() { return false; }
		public static void Shutdown() { }
		public static bool RestartAppIfNecessary(AppId_t unOwnAppID) { return false; } // false if no action needs to be taken
		public static void ReleaseCurrentThreadMemory() { }
		public static void RunCallbacks() { }
		public static bool IsSteamRunning() { return true; } // returns true if Steam is currently running
		public static HSteamUser GetHSteamUserCurrent() { return (HSteamUser) 0; }
		public static HSteamPipe GetHSteamPipe() { return (HSteamPipe) 0; }
		public static HSteamUser GetHSteamUser() { return (HSteamUser) 0; }
	}

	public static class GameServer {
		public static bool Init(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString) { return false; }
		public static void Shutdown() { }
		public static void RunCallbacks() { }
		public static void ReleaseCurrentThreadMemory() { }
		public static bool BSecure() { return false; }
		public static CSteamID GetSteamID() { return (CSteamID) 0; }
		public static HSteamPipe GetHSteamPipe() { return (HSteamPipe) 0; }
		public static HSteamUser GetHSteamUser() { return (HSteamUser) 0; }
	}

	public static class SteamEncryptedAppTicket {
		public static bool BDecryptTicket(byte[] rgubTicketEncrypted, uint cubTicketEncrypted, byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, byte[] rgubKey, int cubKey) { return false; }
		public static bool BIsTicketForApp(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID) { return false; }
		public static uint GetTicketIssueTime(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) { return (uint) 0; }
		public static void GetTicketSteamID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out CSteamID psteamID) { psteamID = (CSteamID) 0; }
		public static uint GetTicketAppID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) { return (uint) 0; }
		public static bool BUserOwnsAppInTicket(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID) { return false; }
		public static bool BUserIsVacBanned(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) { return false; }
		public static byte[] GetUserVariableData(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out uint pcubUserData) {
			byte[] ret = { 0 };
			pcubUserData = (uint) 0;
			return ret;
		}
	}

	internal static class CSteamAPIContext {
		internal static void Clear() {
			m_pSteamClient = IntPtr.Zero;
			m_pSteamUser = IntPtr.Zero;
			m_pSteamFriends = IntPtr.Zero;
			m_pSteamUtils = IntPtr.Zero;
			m_pSteamMatchmaking = IntPtr.Zero;
			m_pSteamUserStats = IntPtr.Zero;
			m_pSteamApps = IntPtr.Zero;
			m_pSteamMatchmakingServers = IntPtr.Zero;
			m_pSteamNetworking = IntPtr.Zero;
			m_pSteamRemoteStorage = IntPtr.Zero;
			m_pSteamHTTP = IntPtr.Zero;
			m_pSteamScreenshots = IntPtr.Zero;
			m_pSteamGameSearch = IntPtr.Zero;
			m_pSteamMusic = IntPtr.Zero;
			m_pController = IntPtr.Zero;
			m_pSteamUGC = IntPtr.Zero;
			m_pSteamAppList = IntPtr.Zero;
			m_pSteamMusic = IntPtr.Zero;
			m_pSteamMusicRemote = IntPtr.Zero;
			m_pSteamHTMLSurface = IntPtr.Zero;
			m_pSteamInventory = IntPtr.Zero;
			m_pSteamVideo = IntPtr.Zero;
			m_pSteamParentalSettings = IntPtr.Zero;
			m_pSteamInput = IntPtr.Zero;
			m_pSteamParties = IntPtr.Zero;
		}
		internal static bool Init() { return true; }
		internal static IntPtr GetSteamClient() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUser() { return IntPtr.Zero; }
		internal static IntPtr GetSteamFriends() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUtils() { return IntPtr.Zero; }
		internal static IntPtr GetSteamMatchmaking() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUserStats() { return IntPtr.Zero; }
		internal static IntPtr GetSteamApps() { return IntPtr.Zero; }
		internal static IntPtr GetSteamMatchmakingServers() { return IntPtr.Zero; }
		internal static IntPtr GetSteamNetworking() { return IntPtr.Zero; }
		internal static IntPtr GetSteamRemoteStorage() { return IntPtr.Zero; }
		internal static IntPtr GetSteamScreenshots() { return IntPtr.Zero; }
		internal static IntPtr GetSteamGameSearch() { return IntPtr.Zero; }
		internal static IntPtr GetSteamHTTP() { return IntPtr.Zero; }
		internal static IntPtr GetSteamController() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUGC() { return IntPtr.Zero; }
		internal static IntPtr GetSteamAppList() { return IntPtr.Zero; }
		internal static IntPtr GetSteamMusic() { return IntPtr.Zero; }
		internal static IntPtr GetSteamMusicRemote() { return IntPtr.Zero; }
		internal static IntPtr GetSteamHTMLSurface() { return IntPtr.Zero; }
		internal static IntPtr GetSteamInventory() { return IntPtr.Zero; }
		internal static IntPtr GetSteamVideo() { return IntPtr.Zero; }
		internal static IntPtr GetSteamParentalSettings() { return IntPtr.Zero; }
		internal static IntPtr GetSteamInput() { return IntPtr.Zero; }
		internal static IntPtr GetSteamParties() { return IntPtr.Zero; }
		private static IntPtr m_pSteamClient;
		private static IntPtr m_pSteamUser;
		private static IntPtr m_pSteamFriends;
		private static IntPtr m_pSteamUtils;
		private static IntPtr m_pSteamMatchmaking;
		private static IntPtr m_pSteamUserStats;
		private static IntPtr m_pSteamApps;
		private static IntPtr m_pSteamMatchmakingServers;
		private static IntPtr m_pSteamNetworking;
		private static IntPtr m_pSteamRemoteStorage;
		private static IntPtr m_pSteamScreenshots;
		private static IntPtr m_pSteamGameSearch;
		private static IntPtr m_pSteamHTTP;
		private static IntPtr m_pController;
		private static IntPtr m_pSteamUGC;
		private static IntPtr m_pSteamAppList;
		private static IntPtr m_pSteamMusic;
		private static IntPtr m_pSteamMusicRemote;
		private static IntPtr m_pSteamHTMLSurface;
		private static IntPtr m_pSteamInventory;
		private static IntPtr m_pSteamVideo;
		private static IntPtr m_pSteamParentalSettings;
		private static IntPtr m_pSteamInput;
		private static IntPtr m_pSteamParties;
	}

	internal static class CSteamGameServerAPIContext {
		internal static void Clear() {
			m_pSteamClient = IntPtr.Zero;
			m_pSteamGameServer = IntPtr.Zero;
			m_pSteamUtils = IntPtr.Zero;
			m_pSteamNetworking = IntPtr.Zero;
			m_pSteamGameServerStats = IntPtr.Zero;
			m_pSteamHTTP = IntPtr.Zero;
			m_pSteamInventory = IntPtr.Zero;
			m_pSteamUGC = IntPtr.Zero;
			m_pSteamApps = IntPtr.Zero;
		}
		internal static bool Init() { return true; }
		internal static IntPtr GetSteamClient() { return IntPtr.Zero; }
		internal static IntPtr GetSteamGameServer() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUtils() { return IntPtr.Zero; }
		internal static IntPtr GetSteamNetworking() { return IntPtr.Zero; }
		internal static IntPtr GetSteamGameServerStats() { return IntPtr.Zero; }
		internal static IntPtr GetSteamHTTP() { return IntPtr.Zero; }
		internal static IntPtr GetSteamInventory() { return IntPtr.Zero; }
		internal static IntPtr GetSteamUGC() { return IntPtr.Zero; }
		internal static IntPtr GetSteamApps() { return IntPtr.Zero; }
		private static IntPtr m_pSteamClient;
		private static IntPtr m_pSteamGameServer;
		private static IntPtr m_pSteamUtils;
		private static IntPtr m_pSteamNetworking;
		private static IntPtr m_pSteamGameServerStats;
		private static IntPtr m_pSteamHTTP;
		private static IntPtr m_pSteamInventory;
		private static IntPtr m_pSteamUGC;
		private static IntPtr m_pSteamApps;
	}
}
