// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class Version {
		public const string SteamworksNETVersion = "13.0.0";
		public const string SteamworksSDKVersion = "1.43";
		public const string SteamAPIDLLVersion = "04.95.20.30";
		public const int SteamAPIDLLSize = 257312;
		public const int SteamAPI64DLLSize = 288032;
	}

	public static class SteamAPI {
		//------------------------------------------------------------//
		//	Steam API setup & shutdown
		//
		//	These functions manage loading, initializing and shutdown of the steamclient.dll
		//
		//------------------------------------------------------------//

		// SteamAPI_Init must be called before using any other API functions. If it fails, an
		// error message will be output to the debugger (or stderr) with further information.
		public static bool Init() {
			//InteropHelp.TestIfPlatformSupported();

			//bool ret = NativeMethods.SteamAPI_Init();

			// Steamworks.NET specific: We initialize the SteamAPI Context like this for now, but we need to do it
			// every time that Unity reloads binaries, so we also check if the pointers are available and initialized
			// before each call to any interface functions. That is in InteropHelp.cs
			//if (ret)
			//{
				//ret = CSteamAPIContext.Init();
			//}

			return true; //return ret;
		}

		public static void Shutdown() {
		}

		// SteamAPI_RestartAppIfNecessary ensures that your executable was launched through Steam.
		//
		// Returns true if the current process should terminate. Steam is now re-launching your application.
		//
		// Returns false if no action needs to be taken. This means that your executable was started through
		// the Steam client, or a steam_appid.txt file is present in your game's directory (for development).
		// Your current process should continue if false is returned.
		//
		// NOTE: If you use the Steam DRM wrapper on your primary executable file, this check is unnecessary
		// since the DRM wrapper will ensure that your application was launched properly through Steam.
		public static bool RestartAppIfNecessary(AppId_t unOwnAppID) {
			return false;
		}

		// Many Steam API functions allocate a small amount of thread-local memory for parameter storage.
		// SteamAPI_ReleaseCurrentThreadMemory() will free API memory associated with the calling thread.
		// This function is also called automatically by SteamAPI_RunCallbacks(), so a single-threaded
		// program never needs to explicitly call this function.
		public static void ReleaseCurrentThreadMemory() {
		}


		//----------------------------------------------------------------------------------------------------------------------------------------------------------//
		//	steam callback and call-result helpers
		//
		//	The following macros and classes are used to register your application for
		//	callbacks and call-results, which are delivered in a predictable manner.
		//
		//	STEAM_CALLBACK macros are meant for use inside of a C++ class definition.
		//	They map a Steam notification callback directly to a class member function
		//	which is automatically prototyped as "void func( callback_type *pParam )".
		//
		//	CCallResult is used with specific Steam APIs that return "result handles".
		//	The handle can be passed to a CCallResult object's Set function, along with
		//	an object pointer and member-function pointer. The member function will
		//	be executed once the results of the Steam API call are available.
		//
		//	CCallback and CCallbackManual classes can be used instead of STEAM_CALLBACK
		//	macros if you require finer control over registration and unregistration.
		//
		//	Callbacks and call-results are queued automatically and are only
		//	delivered/executed when your application calls SteamAPI_RunCallbacks().
		//---------------------------------------------------------------------//

		// SteamAPI_RunCallbacks is safe to call from multiple threads simultaneously,
		// but if you choose to do this, callback code could be executed on any thread.
		// One alternative is to call SteamAPI_RunCallbacks from the main thread only,
		// and call SteamAPI_ReleaseCurrentThreadMemory regularly on other threads.
		public static void RunCallbacks() {
		}

		//-----------------------------------------------------------------------//
		//	steamclient.dll private wrapper functions
		//
		//	The following functions are part of abstracting API access to the steamclient.dll, but should only be used in very specific cases
		//----------------------------------------------------------------------//

		// SteamAPI_IsSteamRunning() returns true if Steam is currently running
		public static bool IsSteamRunning() {
			return true;
		}

		// returns the HSteamUser of the last user to dispatch a callback
		public static HSteamUser GetHSteamUserCurrent() {
			return (HSteamUser) 0;
		}

		// returns the pipe we are communicating to Steam with
		public static HSteamPipe GetHSteamPipe() {
			return (HSteamPipe) 0;
		}

		public static HSteamUser GetHSteamUser() {
			return (HSteamUser) 0;
		}
	}

	public static class GameServer {
		// Initialize ISteamGameServer interface object, and set server properties which may not be changed.
		//
		// After calling this function, you should set any additional server parameters, and then
		// call ISteamGameServer::LogOnAnonymous() or ISteamGameServer::LogOn()
		//
		// - usSteamPort is the local port used to communicate with the steam servers.
		// - usGamePort is the port that clients will connect to for gameplay.
		// - usQueryPort is the port that will manage server browser related duties and info
		//		pings from clients.  If you pass MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE for usQueryPort, then it
		//		will use "GameSocketShare" mode, which means that the game is responsible for sending and receiving
		//		UDP packets for the master  server updater. See references to GameSocketShare in isteamgameserver.h.
		// - The version string is usually in the form x.x.x.x, and is used by the master server to detect when the
		//		server is out of date.  (Only servers with the latest version will be listed.)
		public static bool Init(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString) {
			return false;
		}

		public static void Shutdown() {
		}

		public static void RunCallbacks() {
		}

		// Most Steam API functions allocate some amount of thread-local memory for
		// parameter storage. Calling SteamGameServer_ReleaseCurrentThreadMemory()
		// will free all API-related memory associated with the calling thread.
		// This memory is released automatically by SteamGameServer_RunCallbacks(),
		// so single-threaded servers do not need to explicitly call this function.
		public static void ReleaseCurrentThreadMemory() {
		}

		public static bool BSecure() {
			return false;
		}

		public static CSteamID GetSteamID() {
			return (CSteamID) 0;
		}

		public static HSteamPipe GetHSteamPipe() {
			return (HSteamPipe) 0;
		}

		public static HSteamUser GetHSteamUser() {
			return (HSteamUser) 0;
		}
	}

	public static class SteamEncryptedAppTicket {
		public static bool BDecryptTicket(byte[] rgubTicketEncrypted, uint cubTicketEncrypted, byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, byte[] rgubKey, int cubKey) {
			return false;
		}

		public static bool BIsTicketForApp(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID) {
			return false;
		}

		public static uint GetTicketIssueTime(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) {
			return (uint) 0;
		}

		public static void GetTicketSteamID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out CSteamID psteamID) {
			psteamID = (CSteamID) 0;
		}

		public static uint GetTicketAppID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) {
			return (uint) 0;
		}

		public static bool BUserOwnsAppInTicket(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID) {
			return false;
		}

		public static bool BUserIsVacBanned(byte[] rgubTicketDecrypted, uint cubTicketDecrypted) {
			return false;
		}

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

		internal static bool Init() {
			return true;
		}

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

		internal static bool Init() {
			return true;
		}

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
