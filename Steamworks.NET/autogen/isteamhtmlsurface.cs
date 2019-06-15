// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamHTMLSurface {
		///  Must call init and shutdown when starting/ending use of the interface
		public static bool Init() { return false; }

		public static bool Shutdown() { return false; }

		///  Create a browser object for display of a html page, when creation is complete the call handle
		///  will return a HTML_BrowserReady_t callback for the HHTMLBrowser of your new browser.
		///    The user agent string is a substring to be added to the general user agent string so you can
		///  identify your client on web servers.
		///    The userCSS string lets you apply a CSS style sheet to every displayed page, leave null if
		///  you do not require this functionality.
		///  YOU MUST HAVE IMPLEMENTED HANDLERS FOR HTML_BrowserReady_t, HTML_StartRequest_t,
		///  HTML_JSAlert_t, HTML_JSConfirm_t, and HTML_FileOpenDialog_t! See the CALLBACKS
		///  section of this interface (AllowStartRequest, etc) for more details. If you do
		///  not implement these callback handlers, the browser may appear to hang instead of
		///  navigating to new pages or triggering javascript popups.
		public static SteamAPICall_t CreateBrowser(string pchUserAgent, string pchUserCSS) {
			return (SteamAPICall_t) 0;
		}

		///  Call this when you are done with a html surface, this lets us free the resources being used by it
		public static void RemoveBrowser(HHTMLBrowser unBrowserHandle) { }

		///  Navigate to this URL, results in a HTML_StartRequest_t as the request commences
		public static void LoadURL(HHTMLBrowser unBrowserHandle, string pchURL, string pchPostData) { }

		///  Tells the surface the size in pixels to display the surface
		public static void SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight) { }

		///  Stop the load of the current html page
		public static void StopLoad(HHTMLBrowser unBrowserHandle) { }

		///  Reload (most likely from local cache) the current page
		public static void Reload(HHTMLBrowser unBrowserHandle) { }

		///  navigate back in the page history
		public static void GoBack(HHTMLBrowser unBrowserHandle) { }

		///  navigate forward in the page history
		public static void GoForward(HHTMLBrowser unBrowserHandle) { }

		///  add this header to any url requests from this browser
		public static void AddHeader(HHTMLBrowser unBrowserHandle, string pchKey, string pchValue) { }

		///  run this javascript script in the currently loaded page
		public static void ExecuteJavascript(HHTMLBrowser unBrowserHandle, string pchScript) { }

		///  Mouse click and mouse movement commands
		public static void MouseUp(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) { }

		public static void MouseDown(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) { }

		public static void MouseDoubleClick(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) { }

		///  x and y are relative to the HTML bounds
		public static void MouseMove(HHTMLBrowser unBrowserHandle, int x, int y) { }

		///  nDelta is pixels of scroll
		public static void MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta) { }

		///  keyboard interactions, native keycode is the virtual key code value from your OS, system key flags the key to not
		///  be sent as a typed character as well as a key down
		public static void KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers, bool bIsSystemKey = false) { }

		public static void KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers) { }

		///  cUnicodeChar is the unicode character point for this keypress (and potentially multiple chars per press)
		public static void KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, EHTMLKeyModifiers eHTMLKeyModifiers) { }

		///  programmatically scroll this many pixels on the page
		public static void SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll) { }

		public static void SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll) { }

		///  tell the html control if it has key focus currently, controls showing the I-beam cursor in text controls amongst other things
		public static void SetKeyFocus(HHTMLBrowser unBrowserHandle, bool bHasKeyFocus) { }

		///  open the current pages html code in the local editor of choice, used for debugging
		public static void ViewSource(HHTMLBrowser unBrowserHandle) { }

		///  copy the currently selected text on the html page to the local clipboard
		public static void CopyToClipboard(HHTMLBrowser unBrowserHandle) { }

		///  paste from the local clipboard to the current html page
		public static void PasteFromClipboard(HHTMLBrowser unBrowserHandle) { }

		///  find this string in the browser, if bCurrentlyInFind is true then instead cycle to the next matching element
		public static void Find(HHTMLBrowser unBrowserHandle, string pchSearchStr, bool bCurrentlyInFind, bool bReverse) { }

		///  cancel a currently running find
		public static void StopFind(HHTMLBrowser unBrowserHandle) { }

		///  return details about the link at position x,y on the current page
		public static void GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y) { }

		///  set a webcookie for the hostname in question
		public static void SetCookie(string pchHostname, string pchKey, string pchValue, string pchPath = "/", uint nExpires = 0, bool bSecure = false, bool bHTTPOnly = false) { }

		///  Zoom the current page by flZoom ( from 0.0 to 2.0, so to zoom to 120% use 1.2 ), zooming around point X,Y in the page (use 0,0 if you don't care)
		public static void SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY) { }

		///  Enable/disable low-resource background mode, where javascript and repaint timers are throttled, resources are
		///  more aggressively purged from memory, and audio/video elements are paused. When background mode is enabled,
		///  all HTML5 video and audio objects will execute ".pause()" and gain the property "._steam_background_paused = 1".
		///  When background mode is disabled, any video or audio objects with that property will resume with ".play()".
		public static void SetBackgroundMode(HHTMLBrowser unBrowserHandle, bool bBackgroundMode) { }

		///  Scale the output display space by this factor, this is useful when displaying content on high dpi devices.
		///  Specifies the ratio between physical and logical pixels.
		public static void SetDPIScalingFactor(HHTMLBrowser unBrowserHandle, float flDPIScaling) { }

		///  Open HTML/JS developer tools
		public static void OpenDeveloperTools(HHTMLBrowser unBrowserHandle) { }

		///  CALLBACKS
		///   These set of functions are used as responses to callback requests
		///  You MUST call this in response to a HTML_StartRequest_t callback
		///   Set bAllowed to true to allow this navigation, false to cancel it and stay
		///  on the current page. You can use this feature to limit the valid pages
		///  allowed in your HTML surface.
		public static void AllowStartRequest(HHTMLBrowser unBrowserHandle, bool bAllowed) { }

		///  You MUST call this in response to a HTML_JSAlert_t or HTML_JSConfirm_t callback
		///   Set bResult to true for the OK option of a confirm, use false otherwise
		public static void JSDialogResponse(HHTMLBrowser unBrowserHandle, bool bResult) { }

		///  You MUST call this in response to a HTML_FileOpenDialog_t callback
		public static void FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles) { }
	}
}
