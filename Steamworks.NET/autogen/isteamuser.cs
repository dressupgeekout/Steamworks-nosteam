// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamUser {
		/// returns the HSteamUser this interface represents
		/// this is only used internally by the API, and by a few select interfaces that support multi-user
		public static HSteamUser GetHSteamUser() { return (HSteamUser) 0; }
		/// returns true if the Steam client current has a live connection to the Steam servers.
		/// If false, it means there is no active connection due to either a networking issue on the local machine, or the Steam server is down/busy.
		/// The Steam client will automatically be trying to recreate the connection as often as possible.
		public static bool BLoggedOn() { return false; }
		/// returns the CSteamID of the account currently logged into the Steam client
		/// a CSteamID is a unique identifier for an account, and used to differentiate users in all parts of the Steamworks API
		public static CSteamID GetSteamID() { return (CSteamID) 0; }
		/// Multiplayer Authentication functions
		/// InitiateGameConnection() starts the state machine for authenticating the game client with the game server
		/// It is the client portion of a three-way handshake between the client, the game server, and the steam servers
		/// Parameters:
		/// void *pAuthBlob - a pointer to empty memory that will be filled in with the authentication token.
		/// int cbMaxAuthBlob - the number of bytes of allocated memory in pBlob. Should be at least 2048 bytes.
		/// CSteamID steamIDGameServer - the steamID of the game server, received from the game server by the client
		/// CGameID gameID - the ID of the current game. For games without mods, this is just CGameID( &lt;appID&gt; )
		/// uint32 unIPServer, uint16 usPortServer - the IP address of the game server
		/// bool bSecure - whether or not the client thinks that the game server is reporting itself as secure (i.e. VAC is running)
		/// return value - returns the number of bytes written to pBlob. If the return is 0, then the buffer passed in was too small, and the call has failed
		/// The contents of pBlob should then be sent to the game server, for it to use to complete the authentication process.
		public static int InitiateGameConnection(byte[] pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, bool bSecure) {
			return 0;
		}
		/// notify of disconnect
		/// needs to occur when the game client leaves the specified game server, needs to match with the InitiateGameConnection() call
		public static void TerminateGameConnection(uint unIPServer, ushort usPortServer) { }
		/// Legacy functions
		/// used by only a few games to track usage events
		public static void TrackAppUsageEvent(CGameID gameID, int eAppUsageEvent, string pchExtraInfo = "") { }
		/// get the local storage folder for current Steam account to write application data, e.g. save games, configs etc.
		/// this will usually be something like "C:\Progam Files\Steam\userdata\&lt;SteamID&gt;\&lt;AppID&gt;\local"
		public static bool GetUserDataFolder(out string pchBuffer, int cubBuffer) {
			pchBuffer = "";
			return false;
		}
		/// Starts voice recording. Once started, use GetVoice() to get the data
		public static void StartVoiceRecording() { }
		/// Stops voice recording. Because people often release push-to-talk keys early, the system will keep recording for
		/// a little bit after this function is called. GetVoice() should continue to be called until it returns
		/// k_eVoiceResultNotRecording
		public static void StopVoiceRecording() { }
		/// Determine the size of captured audio data that is available from GetVoice.
		/// Most applications will only use compressed data and should ignore the other
		/// parameters, which exist primarily for backwards compatibility. See comments
		/// below for further explanation of "uncompressed" data.
		public static EVoiceResult GetAvailableVoice(out uint pcbCompressed) {
			pcbCompressed = 0;
			return (EVoiceResult) 0;
		}
		/// NOTE: "uncompressed" audio is a deprecated feature and should not be used
		/// by most applications. It is raw single-channel 16-bit PCM wave data which
		/// may have been run through preprocessing filters and/or had silence removed,
		/// so the uncompressed audio could have a shorter duration than you expect.
		/// There may be no data at all during long periods of silence. Also, fetching
		/// uncompressed audio will cause GetVoice to discard any leftover compressed
		/// audio, so you must fetch both types at once. Finally, GetAvailableVoice is
		/// not precisely accurate when the uncompressed size is requested. So if you
		/// really need to use uncompressed audio, you should call GetVoice frequently
		/// with two very large (20kb+) output buffers instead of trying to allocate
		/// perfectly-sized buffers. But most applications should ignore all of these
		/// details and simply leave the "uncompressed" parameters as NULL/zero.
		/// ---------------------------------------------------------------------------
		/// Read captured audio data from the microphone buffer. This should be called
		/// at least once per frame, and preferably every few milliseconds, to keep the
		/// microphone input delay as low as possible. Most applications will only use
		/// compressed data and should pass NULL/zero for the "uncompressed" parameters.
		/// Compressed data can be transmitted by your application and decoded into raw
		/// using the DecompressVoice function below.
		public static EVoiceResult GetVoice(bool bWantCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten) {
			nBytesWritten = (uint) 0;
			return (EVoiceResult) 0;
		}
		/// Decodes the compressed voice data returned by GetVoice. The output data is
		/// raw single-channel 16-bit PCM audio. The decoder supports any sample rate
		/// from 11025 to 48000; see GetVoiceOptimalSampleRate() below for details.
		/// If the output buffer is not large enough, then *nBytesWritten will be set
		/// to the required buffer size, and k_EVoiceResultBufferTooSmall is returned.
		/// It is suggested to start with a 20kb buffer and reallocate as necessary.
		public static EVoiceResult DecompressVoice(byte[] pCompressed, uint cbCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, uint nDesiredSampleRate) {
			nBytesWritten = (uint) 0;
			return (EVoiceResult) 0;
		}
		/// This returns the native sample rate of the Steam voice decompressor; using
		/// this sample rate for DecompressVoice will perform the least CPU processing.
		/// However, the final audio quality will depend on how well the audio device
		/// (and/or your application's audio output SDK) deals with lower sample rates.
		/// You may find that you get the best audio output quality when you ignore
		/// this function and use the native sample rate of your audio output device,
		/// which is usually 48000 or 44100.
		public static uint GetVoiceOptimalSampleRate() { return (uint) 0; }
		/// Retrieve ticket to be sent to the entity who wishes to authenticate you.
		/// pcbTicket retrieves the length of the actual ticket.
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket) {
			pcbTicket = (uint) 0;
			return (HAuthTicket) 0;
		}
		/// Authenticate ticket from entity steamID to be sure it is valid and isnt reused
		/// Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID) {
			return (EBeginAuthSessionResult) 0;
		}
		/// Stop tracking started by BeginAuthSession - called when no longer playing game with this entity
		public static void EndAuthSession(CSteamID steamID) { }
		/// Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to
		public static void CancelAuthTicket(HAuthTicket hAuthTicket) { }
		/// After receiving a user's authentication data, and passing it to BeginAuthSession, use this function
		/// to determine if the user owns downloadable content specified by the provided AppID.
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID) {
			return (EUserHasLicenseForAppResult) 0;
		}
		/// returns true if this users looks like they are behind a NAT device. Only valid once the user has connected to steam
		/// (i.e a SteamServersConnected_t has been issued) and may not catch all forms of NAT.
		public static bool BIsBehindNAT() {
			return false;
		}
		/// set data to be replicated to friends so that they can join your game
		/// CSteamID steamIDGameServer - the steamID of the game server, received from the game server by the client
		/// uint32 unIPServer, uint16 usPortServer - the IP address of the game server
		public static void AdvertiseGame(CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer) { }
		/// Requests a ticket encrypted with an app specific shared key
		/// pDataToInclude, cbDataToInclude will be encrypted into the ticket
		/// ( This is asynchronous, you must wait for the ticket to be completed by the server )
		public static SteamAPICall_t RequestEncryptedAppTicket(byte[] pDataToInclude, int cbDataToInclude) {
			return (SteamAPICall_t) 0;
		}
		/// retrieve a finished ticket
		public static bool GetEncryptedAppTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket) {
			pcbTicket = (uint) 0;
			return false;
		}
		/// Trading Card badges data access
		/// if you only have one set of cards, the series will be 1
		/// the user has can have two different badges for a series; the regular (max level 5) and the foil (max level 1)
		public static int GetGameBadgeLevel(int nSeries, bool bFoil) { return 0; }
		/// gets the Steam Level of the user, as shown on their profile
		public static int GetPlayerSteamLevel() { return 0; }
		/// Requests a URL which authenticates an in-game browser for store check-out,
		/// and then redirects to the specified URL. As long as the in-game browser
		/// accepts and handles session cookies, Steam microtransaction checkout pages
		/// will automatically recognize the user instead of presenting a login page.
		/// The result of this API call will be a StoreAuthURLResponse_t callback.
		/// NOTE: The URL has a very short lifetime to prevent history-snooping attacks,
		/// so you should only call this API when you are about to launch the browser,
		/// or else immediately navigate to the result URL using a hidden browser window.
		/// NOTE 2: The resulting authorization cookie has an expiration time of one day,
		/// so it would be a good idea to request and visit a new auth URL every 12 hours.
		public static SteamAPICall_t RequestStoreAuthURL(string pchRedirectURL) {
			return (SteamAPICall_t) 0;
		}
		/// gets whether the users phone number is verified
		public static bool BIsPhoneVerified() { return false; }
		/// gets whether the user has two factor enabled on their account
		public static bool BIsTwoFactorEnabled() { return false; }
		/// gets whether the users phone number is identifying
		public static bool BIsPhoneIdentifying() { return false; }
		/// gets whether the users phone number is awaiting (re)verification
		public static bool BIsPhoneRequiringVerification() { return false; }
		public static SteamAPICall_t GetMarketEligibility() {
			return (SteamAPICall_t) 0;
		}
	}
}
