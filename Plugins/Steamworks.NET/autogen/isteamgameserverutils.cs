// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerUtils {
		///  return the number of seconds since the user
		public static uint GetSecondsSinceAppActive() { return (uint) 0; }

		public static uint GetSecondsSinceComputerActive() { return (uint) 0; }

		///  the universe this client is connecting to
		public static EUniverse GetConnectedUniverse() { return (EUniverse) 0; }

		///  Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)
		public static uint GetServerRealTime() { return (uint) 0; }

		///  returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)
		///  e.g "US" or "UK".
		public static string GetIPCountry() {
			return ""; //InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetIPCountry(CSteamGameServerAPIContext.GetSteamUtils()));
		}

		///  returns true if the image exists, and valid sizes were filled out
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight) {
			pnWidth = (uint) 0;
			pnHeight = (uint) 0;
			return false;
		}

		///  returns true if the image exists, and the buffer was successfully filled out
		///  results are returned in RGBA format
		///  the destination buffer size should be 4 * height * width * sizeof(char)
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize) {
			return false;
		}

		///  returns the IP of the reporting server for valve - currently only used in Source engine games
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort) {
			unIP = (uint) 0;
			usPort = (ushort) 0;
			return false;
		}

		///  return the amount of battery power left in the current system in % [0..100], 255 for being on AC power
		public static byte GetCurrentBatteryPower() { return (byte) 255; }

		///  returns the appID of the current process
		public static AppId_t GetAppID() { return (AppId_t) 0; }

		///  Sets the position where the overlay instance for the currently calling game should show notifications.
		///  This position is per-game and if this function is called from outside of a game context it will do nothing.
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition) { }

		///  API asynchronous call results
		///  can be used directly, but more commonly used via the callback dispatch API (see steam_api.h)
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

		///  returns the number of IPC calls made since the last time this function was called
		///  Used for perf debugging so you can understand how many IPC calls your game makes per frame
		///  Every IPC call is at minimum a thread context switch if not a process one so you want to rate
		///  control how often you do them.
		public static uint GetIPCCallCount() { return (uint) 0; }

		///  API warning handling
		///  'int' is the severity; 0 for msg, 1 for warning
		///  'const char *' is the text of the message
		///  callbacks will occur directly after the API function is called that generated the warning or message
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) { }

		///  Returns true if the overlay is running &amp; the user can access it. The overlay process could take a few seconds to
		///  start &amp; hook the game process, so this function will initially return false while the overlay is loading.
		public static bool IsOverlayEnabled() { return false; }

		///  Normally this call is unneeded if your game has a constantly running frame loop that calls the
		///  D3D Present API, or OGL SwapBuffers API every frame.
		///  However, if you have a game that only refreshes the screen on an event driven basis then that can break
		///  the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also
		///  need to Present() to the screen any time an even needing a notification happens or when the overlay is
		///  brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present
		///  in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you
		///  refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.
		public static bool BOverlayNeedsPresent() { return false; }

		///  Asynchronous call to check if an executable file has been signed using the public key set on the signing tab
		///  of the partner site, for example to refuse to load modified executable files.
		///  The result is returned in CheckFileSignature_t.
		///    k_ECheckFileSignatureNoSignaturesFoundForThisApp - This app has not been configured on the signing tab of the partner site to enable this function.
		///    k_ECheckFileSignatureNoSignaturesFoundForThisFile - This file is not listed on the signing tab for the partner site.
		///    k_ECheckFileSignatureFileNotFound - The file does not exist on disk.
		///    k_ECheckFileSignatureInvalidSignature - The file exists, and the signing tab has been set for this file, but the file is either not signed or the signature does not match.
		///    k_ECheckFileSignatureValidSignature - The file is signed and the signature is valid.
		public static SteamAPICall_t CheckFileSignature(string szFileName) {
			return (SteamAPICall_t) 0;
		}

		///  Activates the Big Picture text input dialog which only supports gamepad input
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText) {
			return false;
		}

		///  Returns previously entered text &amp; length
		public static uint GetEnteredGamepadTextLength() { return (uint) 0; }

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText) {
			pchText = "";
			return false;
		}

		///  returns the language the steam client is running in, you probably want ISteamApps::GetCurrentGameLanguage instead, this is for very special usage cases
		public static string GetSteamUILanguage() { return "english"; }

		///  returns true if Steam itself is running in VR mode
		public static bool IsSteamRunningInVR() { return false; }

		///  Sets the inset of the overlay notification from the corner specified by SetOverlayNotificationPosition.
		public static void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset) { }

		///  returns true if Steam &amp; the Steam Overlay are running in Big Picture mode
		///  Games much be launched through the Steam client to enable the Big Picture overlay. During development,
		///  a game can be added as a non-steam game to the developers library to test this feature
		public static bool IsSteamInBigPictureMode() { return false; }

		///  ask SteamUI to create and render its OpenVR dashboard
		public static void StartVRDashboard() { }

		///  Returns true if the HMD content will be streamed via Steam In-Home Streaming
		public static bool IsVRHeadsetStreamingEnabled() { return false; }

		///  Set whether the HMD content will be streamed via Steam In-Home Streaming
		///  If this is set to true, then the scene in the HMD headset will be streamed, and remote input will not be allowed.
		///  If this is set to false, then the application window will be streamed instead, and remote input will be allowed.
		///  The default is true unless "VRHeadsetStreaming" "0" is in the extended appinfo for a game.
		///  (this is useful for games that have asymmetric multiplayer gameplay)
		public static void SetVRHeadsetStreamingEnabled(bool bEnabled) { }
	}
}
