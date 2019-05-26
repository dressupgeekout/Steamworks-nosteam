// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamUser {
		/// <para> returns the HSteamUser this interface represents</para>
		/// <para> this is only used internally by the API, and by a few select interfaces that support multi-user</para>
		public static HSteamUser GetHSteamUser() {
			return (HSteamUser) 0;
		}

		/// <para> returns true if the Steam client current has a live connection to the Steam servers.</para>
		/// <para> If false, it means there is no active connection due to either a networking issue on the local machine, or the Steam server is down/busy.</para>
		/// <para> The Steam client will automatically be trying to recreate the connection as often as possible.</para>
		public static bool BLoggedOn() {
			return false;
		}

		/// <para> returns the CSteamID of the account currently logged into the Steam client</para>
		/// <para> a CSteamID is a unique identifier for an account, and used to differentiate users in all parts of the Steamworks API</para>
		public static CSteamID GetSteamID() {
			return (CSteamID) 0;
		}

		/// <para> Multiplayer Authentication functions</para>
		/// <para> InitiateGameConnection() starts the state machine for authenticating the game client with the game server</para>
		/// <para> It is the client portion of a three-way handshake between the client, the game server, and the steam servers</para>
		/// <para> Parameters:</para>
		/// <para> void *pAuthBlob - a pointer to empty memory that will be filled in with the authentication token.</para>
		/// <para> int cbMaxAuthBlob - the number of bytes of allocated memory in pBlob. Should be at least 2048 bytes.</para>
		/// <para> CSteamID steamIDGameServer - the steamID of the game server, received from the game server by the client</para>
		/// <para> CGameID gameID - the ID of the current game. For games without mods, this is just CGameID( &lt;appID&gt; )</para>
		/// <para> uint32 unIPServer, uint16 usPortServer - the IP address of the game server</para>
		/// <para> bool bSecure - whether or not the client thinks that the game server is reporting itself as secure (i.e. VAC is running)</para>
		/// <para> return value - returns the number of bytes written to pBlob. If the return is 0, then the buffer passed in was too small, and the call has failed</para>
		/// <para> The contents of pBlob should then be sent to the game server, for it to use to complete the authentication process.</para>
		public static int InitiateGameConnection(byte[] pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, bool bSecure) {
			return 0;
		}

		/// <para> notify of disconnect</para>
		/// <para> needs to occur when the game client leaves the specified game server, needs to match with the InitiateGameConnection() call</para>
		public static void TerminateGameConnection(uint unIPServer, ushort usPortServer) {
		}

		/// <para> Legacy functions</para>
		/// <para> used by only a few games to track usage events</para>
		public static void TrackAppUsageEvent(CGameID gameID, int eAppUsageEvent, string pchExtraInfo = "") {
		}

		/// <para> get the local storage folder for current Steam account to write application data, e.g. save games, configs etc.</para>
		/// <para> this will usually be something like "C:\Progam Files\Steam\userdata\&lt;SteamID&gt;\&lt;AppID&gt;\local"</para>
		public static bool GetUserDataFolder(out string pchBuffer, int cubBuffer) {
			pchBuffer = "";
			return false;
		}

		/// <para> Starts voice recording. Once started, use GetVoice() to get the data</para>
		public static void StartVoiceRecording() {
		}

		/// <para> Stops voice recording. Because people often release push-to-talk keys early, the system will keep recording for</para>
		/// <para> a little bit after this function is called. GetVoice() should continue to be called until it returns</para>
		/// <para> k_eVoiceResultNotRecording</para>
		public static void StopVoiceRecording() {
		}

		/// <para> Determine the size of captured audio data that is available from GetVoice.</para>
		/// <para> Most applications will only use compressed data and should ignore the other</para>
		/// <para> parameters, which exist primarily for backwards compatibility. See comments</para>
		/// <para> below for further explanation of "uncompressed" data.</para>
		public static EVoiceResult GetAvailableVoice(out uint pcbCompressed) {
			pcbCompressed = 0;
			return (EVoiceResult) 0;
		}

		/// <para> ---------------------------------------------------------------------------</para>
		/// <para> NOTE: "uncompressed" audio is a deprecated feature and should not be used</para>
		/// <para> by most applications. It is raw single-channel 16-bit PCM wave data which</para>
		/// <para> may have been run through preprocessing filters and/or had silence removed,</para>
		/// <para> so the uncompressed audio could have a shorter duration than you expect.</para>
		/// <para> There may be no data at all during long periods of silence. Also, fetching</para>
		/// <para> uncompressed audio will cause GetVoice to discard any leftover compressed</para>
		/// <para> audio, so you must fetch both types at once. Finally, GetAvailableVoice is</para>
		/// <para> not precisely accurate when the uncompressed size is requested. So if you</para>
		/// <para> really need to use uncompressed audio, you should call GetVoice frequently</para>
		/// <para> with two very large (20kb+) output buffers instead of trying to allocate</para>
		/// <para> perfectly-sized buffers. But most applications should ignore all of these</para>
		/// <para> details and simply leave the "uncompressed" parameters as NULL/zero.</para>
		/// <para> ---------------------------------------------------------------------------</para>
		/// <para> Read captured audio data from the microphone buffer. This should be called</para>
		/// <para> at least once per frame, and preferably every few milliseconds, to keep the</para>
		/// <para> microphone input delay as low as possible. Most applications will only use</para>
		/// <para> compressed data and should pass NULL/zero for the "uncompressed" parameters.</para>
		/// <para> Compressed data can be transmitted by your application and decoded into raw</para>
		/// <para> using the DecompressVoice function below.</para>
		public static EVoiceResult GetVoice(bool bWantCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten) {
			nBytesWritten = (uint) 0;
			return (EVoiceResult) 0;
		}

		/// <para> Decodes the compressed voice data returned by GetVoice. The output data is</para>
		/// <para> raw single-channel 16-bit PCM audio. The decoder supports any sample rate</para>
		/// <para> from 11025 to 48000; see GetVoiceOptimalSampleRate() below for details.</para>
		/// <para> If the output buffer is not large enough, then *nBytesWritten will be set</para>
		/// <para> to the required buffer size, and k_EVoiceResultBufferTooSmall is returned.</para>
		/// <para> It is suggested to start with a 20kb buffer and reallocate as necessary.</para>
		public static EVoiceResult DecompressVoice(byte[] pCompressed, uint cbCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, uint nDesiredSampleRate) {
			nBytesWritten = (uint) 0;
			return (EVoiceResult) 0;
		}

		/// <para> This returns the native sample rate of the Steam voice decompressor; using</para>
		/// <para> this sample rate for DecompressVoice will perform the least CPU processing.</para>
		/// <para> However, the final audio quality will depend on how well the audio device</para>
		/// <para> (and/or your application's audio output SDK) deals with lower sample rates.</para>
		/// <para> You may find that you get the best audio output quality when you ignore</para>
		/// <para> this function and use the native sample rate of your audio output device,</para>
		/// <para> which is usually 48000 or 44100.</para>
		public static uint GetVoiceOptimalSampleRate() {
			return (uint) 0;
		}

		/// <para> Retrieve ticket to be sent to the entity who wishes to authenticate you.</para>
		/// <para> pcbTicket retrieves the length of the actual ticket.</para>
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket) {
			pcbTicket = (uint) 0;
			return (HAuthTicket) 0;
		}

		/// <para> Authenticate ticket from entity steamID to be sure it is valid and isnt reused</para>
		/// <para> Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )</para>
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID) {
			return (EBeginAuthSessionResult) 0;
		}

		/// <para> Stop tracking started by BeginAuthSession - called when no longer playing game with this entity</para>
		public static void EndAuthSession(CSteamID steamID) {
		}

		/// <para> Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to</para>
		public static void CancelAuthTicket(HAuthTicket hAuthTicket) {
		}

		/// <para> After receiving a user's authentication data, and passing it to BeginAuthSession, use this function</para>
		/// <para> to determine if the user owns downloadable content specified by the provided AppID.</para>
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID) {
			return (EUserHasLicenseForAppResult) 0;
		}

		/// <para> returns true if this users looks like they are behind a NAT device. Only valid once the user has connected to steam</para>
		/// <para> (i.e a SteamServersConnected_t has been issued) and may not catch all forms of NAT.</para>
		public static bool BIsBehindNAT() {
			return false;
		}

		/// <para> set data to be replicated to friends so that they can join your game</para>
		/// <para> CSteamID steamIDGameServer - the steamID of the game server, received from the game server by the client</para>
		/// <para> uint32 unIPServer, uint16 usPortServer - the IP address of the game server</para>
		public static void AdvertiseGame(CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer) {
		}

		/// <para> Requests a ticket encrypted with an app specific shared key</para>
		/// <para> pDataToInclude, cbDataToInclude will be encrypted into the ticket</para>
		/// <para> ( This is asynchronous, you must wait for the ticket to be completed by the server )</para>
		public static SteamAPICall_t RequestEncryptedAppTicket(byte[] pDataToInclude, int cbDataToInclude) {
			return (SteamAPICall_t) 0;
		}

		/// <para> retrieve a finished ticket</para>
		public static bool GetEncryptedAppTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket) {
			pcbTicket = (uint) 0;
			return false;
		}

		/// <para> Trading Card badges data access</para>
		/// <para> if you only have one set of cards, the series will be 1</para>
		/// <para> the user has can have two different badges for a series; the regular (max level 5) and the foil (max level 1)</para>
		public static int GetGameBadgeLevel(int nSeries, bool bFoil) {
			return 0;
		}

		/// <para> gets the Steam Level of the user, as shown on their profile</para>
		public static int GetPlayerSteamLevel() {
			return 0;
		}

		/// <para> Requests a URL which authenticates an in-game browser for store check-out,</para>
		/// <para> and then redirects to the specified URL. As long as the in-game browser</para>
		/// <para> accepts and handles session cookies, Steam microtransaction checkout pages</para>
		/// <para> will automatically recognize the user instead of presenting a login page.</para>
		/// <para> The result of this API call will be a StoreAuthURLResponse_t callback.</para>
		/// <para> NOTE: The URL has a very short lifetime to prevent history-snooping attacks,</para>
		/// <para> so you should only call this API when you are about to launch the browser,</para>
		/// <para> or else immediately navigate to the result URL using a hidden browser window.</para>
		/// <para> NOTE 2: The resulting authorization cookie has an expiration time of one day,</para>
		/// <para> so it would be a good idea to request and visit a new auth URL every 12 hours.</para>
		public static SteamAPICall_t RequestStoreAuthURL(string pchRedirectURL) {
			return (SteamAPICall_t) 0;
		}

		/// <para> gets whether the users phone number is verified</para>
		public static bool BIsPhoneVerified() {
			return false;
		}

		/// <para> gets whether the user has two factor enabled on their account</para>
		public static bool BIsTwoFactorEnabled() {
			return false;
		}

		/// <para> gets whether the users phone number is identifying</para>
		public static bool BIsPhoneIdentifying() {
			return false;
		}

		/// <para> gets whether the users phone number is awaiting (re)verification</para>
		public static bool BIsPhoneRequiringVerification() {
			return false;
		}

		public static SteamAPICall_t GetMarketEligibility() {
			return (SteamAPICall_t) 0;
		}
	}
}
