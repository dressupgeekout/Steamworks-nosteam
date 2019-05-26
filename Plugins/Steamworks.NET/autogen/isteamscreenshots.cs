// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamScreenshots {
		/// <para> Writes a screenshot to the user's screenshot library given the raw image data, which must be in RGB format.</para>
		/// <para> The return value is a handle that is valid for the duration of the game process and can be used to apply tags.</para>
		public static ScreenshotHandle WriteScreenshot(byte[] pubRGB, uint cubRGB, int nWidth, int nHeight) {
			return (ScreenshotHandle) 0;
		}

		/// <para> Adds a screenshot to the user's screenshot library from disk.  If a thumbnail is provided, it must be 200 pixels wide and the same aspect ratio</para>
		/// <para> as the screenshot, otherwise a thumbnail will be generated if the user uploads the screenshot.  The screenshots must be in either JPEG or TGA format.</para>
		/// <para> The return value is a handle that is valid for the duration of the game process and can be used to apply tags.</para>
		/// <para> JPEG, TGA, and PNG formats are supported.</para>
		public static ScreenshotHandle AddScreenshotToLibrary(string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight) {
			return (ScreenshotHandle) 0;
		}

		/// <para> Causes the Steam overlay to take a screenshot.  If screenshots are being hooked by the game then a ScreenshotRequested_t callback is sent back to the game instead.</para>
		public static void TriggerScreenshot() {
		}

		/// <para> Toggles whether the overlay handles screenshots when the user presses the screenshot hotkey, or the game handles them.  If the game is hooking screenshots,</para>
		/// <para> then the ScreenshotRequested_t callback will be sent if the user presses the hotkey, and the game is expected to call WriteScreenshot or AddScreenshotToLibrary</para>
		/// <para> in response.</para>
		public static void HookScreenshots(bool bHook) {
		}

		/// <para> Sets metadata about a screenshot's location (for example, the name of the map)</para>
		public static bool SetLocation(ScreenshotHandle hScreenshot, string pchLocation) {
			return false;
		}

		/// <para> Tags a user as being visible in the screenshot</para>
		public static bool TagUser(ScreenshotHandle hScreenshot, CSteamID steamID) {
			return false;
		}

		/// <para> Tags a published file as being visible in the screenshot</para>
		public static bool TagPublishedFile(ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID) {
			return false;
		}

		/// <para> Returns true if the app has hooked the screenshot</para>
		public static bool IsScreenshotsHooked() {
			return false;
		}

		/// <para> Adds a VR screenshot to the user's screenshot library from disk in the supported type.</para>
		/// <para> pchFilename should be the normal 2D image used in the library view</para>
		/// <para> pchVRFilename should contain the image that matches the correct type</para>
		/// <para> The return value is a handle that is valid for the duration of the game process and can be used to apply tags.</para>
		/// <para> JPEG, TGA, and PNG formats are supported.</para>
		public static ScreenshotHandle AddVRScreenshotToLibrary(EVRScreenshotType eType, string pchFilename, string pchVRFilename) {
			return (ScreenshotHandle) 0;
		}
	}
}
