// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamHTTP {
		/// Initializes a new HTTP request, returning a handle to use in further operations on it.  Requires
		/// the method (GET or POST) and the absolute URL for the request.  Both http and https are supported,
		/// so this string must start with http:// or https:// and should look like http://store.steampowered.com/app/250/
		/// or such.
		public static HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL) {
			return (HTTPRequestHandle) 0;
		}

		/// Set a context value for the request, which will be returned in the HTTPRequestCompleted_t callback after
		/// sending the request.  This is just so the caller can easily keep track of which callbacks go with which request data.
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue) {
			return false;
		}

		/// Set a timeout in seconds for the HTTP request, must be called prior to sending the request.  Default
		/// timeout is 60 seconds if you don't call this.  Returns false if the handle is invalid, or the request
		/// has already been sent.
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds) {
			return false;
		}

		/// Set a request header value for the request, must be called prior to sending the request.  Will
		/// return false if the handle is invalid or the request is already sent.
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue) {
			return false;
		}

		/// Set a GET or POST parameter value on the request, which is set will depend on the EHTTPMethod specified
		/// when creating the request.  Must be called prior to sending the request.  Will return false if the
		/// handle is invalid or the request is already sent.
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string pchParamName, string pchParamValue) {
			return false;
		}

		/// Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on
		/// asynchronous response via callback.
		/// Note: If the user is in offline mode in Steam, then this will add a only-if-cached cache-control
		/// header and only do a local cache lookup rather than sending any actual remote request.
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle) {
			pCallHandle = (SteamAPICall_t) 0;
			return false;
		}

		/// Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on
		/// asynchronous response via callback for completion, and listen for HTTPRequestHeadersReceived_t and
		/// HTTPRequestDataReceived_t callbacks while streaming.
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle) {
			pCallHandle = (SteamAPICall_t) 0;
			return false;
		}

		/// Defers a request you have sent, the actual HTTP client code may have many requests queued, and this will move
		/// the specified request to the tail of the queue.  Returns false on invalid handle, or if the request is not yet sent.
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest) {
			return false;
		}

		/// Prioritizes a request you have sent, the actual HTTP client code may have many requests queued, and this will move
		/// the specified request to the head of the queue.  Returns false on invalid handle, or if the request is not yet sent.
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest) {
			return false;
		}

		/// Checks if a response header is present in a HTTP response given a handle from HTTPRequestCompleted_t, also
		/// returns the size of the header value if present so the caller and allocate a correctly sized buffer for
		/// GetHTTPResponseHeaderValue.
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string pchHeaderName, out uint unResponseHeaderSize) {
			unResponseHeaderSize = (uint) 0;
			return false;
		}

		/// Gets header values from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the
		/// header is not present or if your buffer is too small to contain it's value.  You should first call
		/// BGetHTTPResponseHeaderSize to check for the presence of the header and to find out the size buffer needed.
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, byte[] pHeaderValueBuffer, uint unBufferSize) {
			return false;
		}

		/// Gets the size of the body data from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the
		/// handle is invalid.
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize) {
			unBodySize = (uint) 0;
			return false;
		}

		/// Gets the body data from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the
		/// handle is invalid or is to a streaming response, or if the provided buffer is not the correct size.  Use BGetHTTPResponseBodySize first to find out
		/// the correct buffer size to use.
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize) {
			return false;
		}

		/// Gets the body data from a streaming HTTP response given a handle from HTTPRequestDataReceived_t. Will return false if the
		/// handle is invalid or is to a non-streaming response (meaning it wasn't sent with SendHTTPRequestAndStreamResponse), or if the buffer size and offset
		/// do not match the size and offset sent in HTTPRequestDataReceived_t.
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize) {
			return false;
		}

		/// Releases an HTTP response handle, should always be called to free resources after receiving a HTTPRequestCompleted_t
		/// callback and finishing using the response.
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest) {
			return false;
		}

		/// Gets progress on downloading the body for the request.  This will be zero unless a response header has already been
		/// received which included a content-length field.  For responses that contain no content-length it will report
		/// zero for the duration of the request as the size is unknown until the connection closes.
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut) {
			pflPercentOut = (float) 0.0;
			return false;
		}

		/// Sets the body for an HTTP Post request.  Will fail and return false on a GET request, and will fail if POST params
		/// have already been set for the request.  Setting this raw body makes it the only contents for the post, the pchContentType
		/// parameter will set the content-type header for the request so the server may know how to interpret the body.
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string pchContentType, byte[] pubBody, uint unBodyLen) {
			return false;
		}

		/// Creates a cookie container handle which you must later free with ReleaseCookieContainer().  If bAllowResponsesToModify=true
		/// than any response to your requests using this cookie container may add new cookies which may be transmitted with
		/// future requests.  If bAllowResponsesToModify=false than only cookies you explicitly set will be sent.  This API is just for
		/// during process lifetime, after steam restarts no cookies are persisted and you have no way to access the cookie container across
		/// repeat executions of your process.
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify) {
			return (HTTPCookieContainerHandle) 0;
		}

		/// Release a cookie container you are finished using, freeing it's memory
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer) {
			return false;
		}

		/// Adds a cookie to the specified cookie container that will be used with future requests.
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie) {
			return false;
		}

		/// Set the cookie container to use for a HTTP request
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer) {
			return false;
		}

		/// Set the extra user agent info for a request, this doesn't clobber the normal user agent, it just adds the extra info on the end
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string pchUserAgentInfo) {
			return false;
		}

		/// Disable or re-enable verification of SSL/TLS certificates.
		/// By default, certificates are checked for all HTTPS requests.
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate) {
			return false;
		}

		/// Set an absolute timeout on the HTTP request, this is just a total time timeout different than the network activity timeout
		/// which can bump everytime we get more data
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds) {
			return false;
		}

		/// Check if the reason the request failed was because we timed it out (rather than some harder failure)
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut) {
			pbWasTimedOut = false;
			return false;
		}
	}
}
