// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerUtils {
		/// <para> return the number of seconds since the user</para>
		public static uint GetSecondsSinceAppActive() {
			return (uint) 0;
		}

		public static uint GetSecondsSinceComputerActive() {
			return (uint) 0;
		}

		/// <para> the universe this client is connecting to</para>
		public static EUniverse GetConnectedUniverse() {
			return (EUniverse) 0;
		}

		/// <para> Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)</para>
		public static uint GetServerRealTime() {
			return (uint) 0;
		}

		/// <para> returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)</para>
		/// <para> e.g "US" or "UK".</para>
		public static string GetIPCountry() {
			return ""; //InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetIPCountry(CSteamGameServerAPIContext.GetSteamUtils()));
		}

		/// <para> returns true if the image exists, and valid sizes were filled out</para>
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight) {
			pnWidth = (uint) 0;
			pnHeight = (uint) 0;
			return false;
		}

		/// <para> returns true if the image exists, and the buffer was successfully filled out</para>
		/// <para> results are returned in RGBA format</para>
		/// <para> the destination buffer size should be 4 * height * width * sizeof(char)</para>
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize) {
			return false;
		}

		/// <para> returns the IP of the reporting server for valve - currently only used in Source engine games</para>
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort) {
			unIP = (uint) 0;
			usPort = (ushort) 0;
			return false;
		}

		/// <para> return the amount of battery power left in the current system in % [0..100], 255 for being on AC power</para>
		public static byte GetCurrentBatteryPower() {
			return (byte) 255;
		}

		/// <para> returns the appID of the current process</para>
		public static AppId_t GetAppID() {
			return (AppId_t) 0;
		}

		/// <para> Sets the position where the overlay instance for the currently calling game should show notifications.</para>
		/// <para> This position is per-game and if this function is called from outside of a game context it will do nothing.</para>
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition) {
		}

		/// <para> API asynchronous call results</para>
		/// <para> can be used directly, but more commonly used via the callback dispatch API (see steam_api.h)</para>
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed) {
			pbFailed = false;
			return false;
		}

		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) {
			return (ESteamAPICallFailure) 0;
		}

		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed) {
			pbFailed = false;
			return false;
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
		/// <para> callbacks will occur directly after the API function is called that generated the warning or message</para>
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
		}

		/// <para> Returns true if the overlay is running &amp; the user can access it. The overlay process could take a few seconds to</para>
		/// <para> start &amp; hook the game process, so this function will initially return false while the overlay is loading.</para>
		public static bool IsOverlayEnabled() {
			return false;
		}

		/// <para> Normally this call is unneeded if your game has a constantly running frame loop that calls the</para>
		/// <para> D3D Present API, or OGL SwapBuffers API every frame.</para>
		/// <para> However, if you have a game that only refreshes the screen on an event driven basis then that can break</para>
		/// <para> the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also</para>
		/// <para> need to Present() to the screen any time an even needing a notification happens or when the overlay is</para>
		/// <para> brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present</para>
		/// <para> in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you</para>
		/// <para> refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.</para>
		public static bool BOverlayNeedsPresent() {
			return false;
		}

		/// <para> Asynchronous call to check if an executable file has been signed using the public key set on the signing tab</para>
		/// <para> of the partner site, for example to refuse to load modified executable files.</para>
		/// <para> The result is returned in CheckFileSignature_t.</para>
		/// <para>   k_ECheckFileSignatureNoSignaturesFoundForThisApp - This app has not been configured on the signing tab of the partner site to enable this function.</para>
		/// <para>   k_ECheckFileSignatureNoSignaturesFoundForThisFile - This file is not listed on the signing tab for the partner site.</para>
		/// <para>   k_ECheckFileSignatureFileNotFound - The file does not exist on disk.</para>
		/// <para>   k_ECheckFileSignatureInvalidSignature - The file exists, and the signing tab has been set for this file, but the file is either not signed or the signature does not match.</para>
		/// <para>   k_ECheckFileSignatureValidSignature - The file is signed and the signature is valid.</para>
		public static SteamAPICall_t CheckFileSignature(string szFileName) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Activates the Big Picture text input dialog which only supports gamepad input</para>
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText) {
			return false;
		}

		/// <para> Returns previously entered text &amp; length</para>
		public static uint GetEnteredGamepadTextLength() {
			return (uint) 0;
		}

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText) {
			pchText = "";
			return false;
		}

		/// <para> returns the language the steam client is running in, you probably want ISteamApps::GetCurrentGameLanguage instead, this is for very special usage cases</para>
		public static string GetSteamUILanguage() {
			return "english";
		}

		/// <para> returns true if Steam itself is running in VR mode</para>
		public static bool IsSteamRunningInVR() {
			return false;
		}

		/// <para> Sets the inset of the overlay notification from the corner specified by SetOverlayNotificationPosition.</para>
		public static void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset) {
		}

		/// <para> returns true if Steam &amp; the Steam Overlay are running in Big Picture mode</para>
		/// <para> Games much be launched through the Steam client to enable the Big Picture overlay. During development,</para>
		/// <para> a game can be added as a non-steam game to the developers library to test this feature</para>
		public static bool IsSteamInBigPictureMode() {
			return false;
		}

		/// <para> ask SteamUI to create and render its OpenVR dashboard</para>
		public static void StartVRDashboard() {
		}

		/// <para> Returns true if the HMD content will be streamed via Steam In-Home Streaming</para>
		public static bool IsVRHeadsetStreamingEnabled() {
			return false;
		}

		/// <para> Set whether the HMD content will be streamed via Steam In-Home Streaming</para>
		/// <para> If this is set to true, then the scene in the HMD headset will be streamed, and remote input will not be allowed.</para>
		/// <para> If this is set to false, then the application window will be streamed instead, and remote input will be allowed.</para>
		/// <para> The default is true unless "VRHeadsetStreaming" "0" is in the extended appinfo for a game.</para>
		/// <para> (this is useful for games that have asymmetric multiplayer gameplay)</para>
		public static void SetVRHeadsetStreamingEnabled(bool bEnabled) {
		}
	}
}
