// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerClient {
		/// Creates a communication pipe to the Steam client.
		/// NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling
		public static HSteamPipe CreateSteamPipe() { return (HSteamPipe) 0; }

		/// Releases a previously created communications pipe
		/// NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe) {
			return false;
		}

		/// connects to an existing global user, failing if none exists
		/// used by the game to coordinate with the steamUI
		/// NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe) {
			return (HSteamUser) 0;
		}

		/// used by game servers, create a steam user that won't be shared with anyone else
		/// NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType) {
			phSteamPipe = (HSteamPipe) 0;
			return (HSteamUser) 0;
		}

		/// removes an allocated user
		/// NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser) { }

		/// retrieves the ISteamUser interface associated with the handle
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// retrieves the ISteamGameServer interface associated with the handle
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// set the local IP and Port to bind to
		/// this must be set before CreateLocalUser()
		public static void SetLocalIPBinding(uint unIP, ushort usPort) { }

		/// returns the ISteamFriends interface
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the ISteamUtils interface
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the ISteamMatchmaking interface
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the ISteamMatchmakingServers interface
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the a generic interface
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the ISteamUserStats interface
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the ISteamGameServerStats interface
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns apps interface
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// networking
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// remote storage
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// user screenshots
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// game search
		public static IntPtr GetISteamGameSearch(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns the number of IPC calls made since the last time this function was called
		/// Used for perf debugging so you can understand how many IPC calls your game makes per frame
		/// Every IPC call is at minimum a thread context switch if not a process one so you want to rate
		/// control how often you do them.
		public static uint GetIPCCallCount() { return (uint) 0; }

		/// API warning handling
		/// 'int' is the severity; 0 for msg, 1 for warning
		/// 'const char *' is the text of the message
		/// callbacks will occur directly after the API function is called that generated the warning or message.
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) { }

		/// Trigger global shutdown for the DLL
		public static bool BShutdownIfAllPipesClosed() { return false; }

		/// Expose HTTP interface
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Exposes the ISteamController interface - deprecated in favor of Steam Input
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Exposes the ISteamUGC interface
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// returns app list interface, only available on specially registered apps
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Music Player
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Music Player Remote
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// html page display
		public static IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// inventory
		public static IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Video
		public static IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Parental controls
		public static IntPtr GetISteamParentalSettings(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Exposes the Steam Input interface for controller support
		public static IntPtr GetISteamInput(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// Steam Parties interface
		public static IntPtr GetISteamParties(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}
	}
}
