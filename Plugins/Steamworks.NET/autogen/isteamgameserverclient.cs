// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerClient {
		/// <para> Creates a communication pipe to the Steam client.</para>
		/// <para> NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling</para>
		public static HSteamPipe CreateSteamPipe() {
			return (HSteamPipe) 0;
		}

		/// <para> Releases a previously created communications pipe</para>
		/// <para> NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling</para>
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe) {
			return false;
		}

		/// <para> connects to an existing global user, failing if none exists</para>
		/// <para> used by the game to coordinate with the steamUI</para>
		/// <para> NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling</para>
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe) {
			return (HSteamUser) 0;
		}

		/// <para> used by game servers, create a steam user that won't be shared with anyone else</para>
		/// <para> NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling</para>
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType) {
			phSteamPipe = (HSteamPipe) 0;
			return (HSteamUser) 0;
		}

		/// <para> removes an allocated user</para>
		/// <para> NOT THREADSAFE - ensure that no other threads are accessing Steamworks API when calling</para>
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser) {
		}

		/// <para> retrieves the ISteamUser interface associated with the handle</para>
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> retrieves the ISteamGameServer interface associated with the handle</para>
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> set the local IP and Port to bind to</para>
		/// <para> this must be set before CreateLocalUser()</para>
		public static void SetLocalIPBinding(uint unIP, ushort usPort) {
		}

		/// <para> returns the ISteamFriends interface</para>
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the ISteamUtils interface</para>
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the ISteamMatchmaking interface</para>
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the ISteamMatchmakingServers interface</para>
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the a generic interface</para>
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the ISteamUserStats interface</para>
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the ISteamGameServerStats interface</para>
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns apps interface</para>
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> networking</para>
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> remote storage</para>
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> user screenshots</para>
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> game search</para>
		public static IntPtr GetISteamGameSearch(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns the number of IPC calls made since the last time this function was called</para>
		/// <para> Used for perf debugging so you can understand how many IPC calls your game makes per frame</para>
		/// <para> Every IPC call is at minimum a thread context switch if not a process one so you want to rate</para>
		/// <para> control how often you do them.</para>
		public static uint GetIPCCallCount() {
			return (uint) 0;
		}

		/// <para> API warning handling</para>
		/// <para> 'int' is the severity; 0 for msg, 1 for warning</para>
		/// <para> 'const char *' is the text of the message</para>
		/// <para> callbacks will occur directly after the API function is called that generated the warning or message.</para>
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
		}

		/// <para> Trigger global shutdown for the DLL</para>
		public static bool BShutdownIfAllPipesClosed() {
			return false;
		}

		/// <para> Expose HTTP interface</para>
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Exposes the ISteamController interface - deprecated in favor of Steam Input</para>
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Exposes the ISteamUGC interface</para>
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> returns app list interface, only available on specially registered apps</para>
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Music Player</para>
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Music Player Remote</para>
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> html page display</para>
		public static IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> inventory</para>
		public static IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Video</para>
		public static IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Parental controls</para>
		public static IntPtr GetISteamParentalSettings(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Exposes the Steam Input interface for controller support</para>
		public static IntPtr GetISteamInput(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}

		/// <para> Steam Parties interface</para>
		public static IntPtr GetISteamParties(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion) {
			return IntPtr.Zero;
		}
	}
}
