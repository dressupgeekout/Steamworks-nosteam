// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamHTMLSurface {
		/// <para> Must call init and shutdown when starting/ending use of the interface</para>
		public static bool Init() {
			return false;
		}

		public static bool Shutdown() {
			return false;
		}

		/// <para> Create a browser object for display of a html page, when creation is complete the call handle</para>
		/// <para> will return a HTML_BrowserReady_t callback for the HHTMLBrowser of your new browser.</para>
		/// <para>   The user agent string is a substring to be added to the general user agent string so you can</para>
		/// <para> identify your client on web servers.</para>
		/// <para>   The userCSS string lets you apply a CSS style sheet to every displayed page, leave null if</para>
		/// <para> you do not require this functionality.</para>
		/// <para> YOU MUST HAVE IMPLEMENTED HANDLERS FOR HTML_BrowserReady_t, HTML_StartRequest_t,</para>
		/// <para> HTML_JSAlert_t, HTML_JSConfirm_t, and HTML_FileOpenDialog_t! See the CALLBACKS</para>
		/// <para> section of this interface (AllowStartRequest, etc) for more details. If you do</para>
		/// <para> not implement these callback handlers, the browser may appear to hang instead of</para>
		/// <para> navigating to new pages or triggering javascript popups.</para>
		public static SteamAPICall_t CreateBrowser(string pchUserAgent, string pchUserCSS) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Call this when you are done with a html surface, this lets us free the resources being used by it</para>
		public static void RemoveBrowser(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> Navigate to this URL, results in a HTML_StartRequest_t as the request commences</para>
		public static void LoadURL(HHTMLBrowser unBrowserHandle, string pchURL, string pchPostData) {
		}

		/// <para> Tells the surface the size in pixels to display the surface</para>
		public static void SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight) {
		}

		/// <para> Stop the load of the current html page</para>
		public static void StopLoad(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> Reload (most likely from local cache) the current page</para>
		public static void Reload(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> navigate back in the page history</para>
		public static void GoBack(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> navigate forward in the page history</para>
		public static void GoForward(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> add this header to any url requests from this browser</para>
		public static void AddHeader(HHTMLBrowser unBrowserHandle, string pchKey, string pchValue) {
		}

		/// <para> run this javascript script in the currently loaded page</para>
		public static void ExecuteJavascript(HHTMLBrowser unBrowserHandle, string pchScript) {
		}

		/// <para> Mouse click and mouse movement commands</para>
		public static void MouseUp(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) {
		}

		public static void MouseDown(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) {
		}

		public static void MouseDoubleClick(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton) {
		}

		/// <para> x and y are relative to the HTML bounds</para>
		public static void MouseMove(HHTMLBrowser unBrowserHandle, int x, int y) {
		}

		/// <para> nDelta is pixels of scroll</para>
		public static void MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta) {
		}

		/// <para> keyboard interactions, native keycode is the virtual key code value from your OS, system key flags the key to not</para>
		/// <para> be sent as a typed character as well as a key down</para>
		public static void KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers, bool bIsSystemKey = false) {
		}

		public static void KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers) {
		}

		/// <para> cUnicodeChar is the unicode character point for this keypress (and potentially multiple chars per press)</para>
		public static void KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, EHTMLKeyModifiers eHTMLKeyModifiers) {
		}

		/// <para> programmatically scroll this many pixels on the page</para>
		public static void SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll) {
		}

		public static void SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll) {
		}

		/// <para> tell the html control if it has key focus currently, controls showing the I-beam cursor in text controls amongst other things</para>
		public static void SetKeyFocus(HHTMLBrowser unBrowserHandle, bool bHasKeyFocus) {
		}

		/// <para> open the current pages html code in the local editor of choice, used for debugging</para>
		public static void ViewSource(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> copy the currently selected text on the html page to the local clipboard</para>
		public static void CopyToClipboard(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> paste from the local clipboard to the current html page</para>
		public static void PasteFromClipboard(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> find this string in the browser, if bCurrentlyInFind is true then instead cycle to the next matching element</para>
		public static void Find(HHTMLBrowser unBrowserHandle, string pchSearchStr, bool bCurrentlyInFind, bool bReverse) {
		}

		/// <para> cancel a currently running find</para>
		public static void StopFind(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> return details about the link at position x,y on the current page</para>
		public static void GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y) {
		}

		/// <para> set a webcookie for the hostname in question</para>
		public static void SetCookie(string pchHostname, string pchKey, string pchValue, string pchPath = "/", uint nExpires = 0, bool bSecure = false, bool bHTTPOnly = false) {
		}

		/// <para> Zoom the current page by flZoom ( from 0.0 to 2.0, so to zoom to 120% use 1.2 ), zooming around point X,Y in the page (use 0,0 if you don't care)</para>
		public static void SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY) {
		}

		/// <para> Enable/disable low-resource background mode, where javascript and repaint timers are throttled, resources are</para>
		/// <para> more aggressively purged from memory, and audio/video elements are paused. When background mode is enabled,</para>
		/// <para> all HTML5 video and audio objects will execute ".pause()" and gain the property "._steam_background_paused = 1".</para>
		/// <para> When background mode is disabled, any video or audio objects with that property will resume with ".play()".</para>
		public static void SetBackgroundMode(HHTMLBrowser unBrowserHandle, bool bBackgroundMode) {
		}

		/// <para> Scale the output display space by this factor, this is useful when displaying content on high dpi devices.</para>
		/// <para> Specifies the ratio between physical and logical pixels.</para>
		public static void SetDPIScalingFactor(HHTMLBrowser unBrowserHandle, float flDPIScaling) {
		}

		/// <para> Open HTML/JS developer tools</para>
		public static void OpenDeveloperTools(HHTMLBrowser unBrowserHandle) {
		}

		/// <para> CALLBACKS</para>
		/// <para>  These set of functions are used as responses to callback requests</para>
		/// <para> You MUST call this in response to a HTML_StartRequest_t callback</para>
		/// <para>  Set bAllowed to true to allow this navigation, false to cancel it and stay</para>
		/// <para> on the current page. You can use this feature to limit the valid pages</para>
		/// <para> allowed in your HTML surface.</para>
		public static void AllowStartRequest(HHTMLBrowser unBrowserHandle, bool bAllowed) {
		}

		/// <para> You MUST call this in response to a HTML_JSAlert_t or HTML_JSConfirm_t callback</para>
		/// <para>  Set bResult to true for the OK option of a confirm, use false otherwise</para>
		public static void JSDialogResponse(HHTMLBrowser unBrowserHandle, bool bResult) {
		}

		/// <para> You MUST call this in response to a HTML_FileOpenDialog_t callback</para>
		public static void FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles) {
		}
	}
}
