// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServer {
		/// Basic server data.  These properties, if set, must be set before before calling LogOn.  They</para>
		/// may not be changed after logged in.</para>
		/// This is called by SteamGameServer_Init, and you will usually not need to call it directly</para>
		public static bool InitGameServer(uint unIP, ushort usGamePort, ushort usQueryPort, uint unFlags, AppId_t nGameAppId, string pchVersionString) {
			return false;
		}

		/// Game product identifier.  This is currently used by the master server for version checking purposes.</para>
		/// It's a required field, but will eventually will go away, and the AppID will be used for this purpose.</para>
		public static void SetProduct(string pszProduct) { }

		/// Description of the game.  This is a required field and is displayed in the steam server browser....for now.</para>
		/// This is a required field, but it will go away eventually, as the data should be determined from the AppID.</para>
		public static void SetGameDescription(string pszGameDescription) { }

		/// If your game is a "mod," pass the string that identifies it.  The default is an empty string, meaning</para>
		/// this application is the original game, not a mod.</para>
		/// 
		///<para>/ @see k_cbMaxGameServerGameDir</para>
		public static void SetModDir(string pszModDir) { }

		/// Is this is a dedicated server?  The default value is false.</para>
		public static void SetDedicatedServer(bool bDedicated) { }

		/// Login</para>
		/// Begin process to login to a persistent game server account</para>
		///You need to register for callbacks to determine the result of this operation.</para>
		///@see SteamServersConnected_t</para>
		/// @see SteamServerConnectFailure_t</para>
		/// @see SteamServersDisconnected_t</para>
		public static void LogOn(string pszToken) { }

		/// Login to a generic, anonymous account.</para>
		/// Note: in previous versions of the SDK, this was automatically called within SteamGameServer_Init,</para>
		/// but this is no longer the case.</para>
		public static void LogOnAnonymous() { }

		/// Begin process of logging game server out of steam</para>
		public static void LogOff() { }

		/// status functions</para>
		public static bool BLoggedOn() { return false; }
		public static bool BSecure() { return false; }
		public static CSteamID GetSteamID() { return (CSteamID) 0; }

		/// Returns true if the master server has requested a restart.</para>
		/// Only returns true once per request.</para>
		public static bool WasRestartRequested() { return false; }

		/// Server state.  These properties may be changed at any time.</para>
		/// Max player count that will be reported to server browser and client queries</para>
		public static void SetMaxPlayerCount(int cPlayersMax) { }

		/// Number of bots.  Default value is zero</para>
		public static void SetBotPlayerCount(int cBotplayers) { }

		/// Set the name of server as it will appear in the server browser</para>
		/// @see k_cbMaxGameServerName</para>
		public static void SetServerName(string pszServerName) { }

		/// Set name of map to report in the server browser</para>
		/// @see k_cbMaxGameServerName</para>
		public static void SetMapName(string pszMapName) { }

		/// Let people know if your server will require a password</para>
		public static void SetPasswordProtected(bool bPasswordProtected) { }

		/// Spectator server.  The default value is zero, meaning the service</para>
		/// is not used.</para>
		public static void SetSpectatorPort(ushort unSpectatorPort) { }

		/// Name of the spectator server.  (Only used if spectator port is nonzero.)</para>
		/// @see k_cbMaxGameServerMapName</para>
		public static void SetSpectatorServerName(string pszSpectatorServerName) { }

		/// Call this to clear the whole list of key/values that are sent in rules queries.</para>
		public static void ClearAllKeyValues() { }

		/// Call this to add/update a key/value pair.</para>
		public static void SetKeyValue(string pKey, string pValue) { }

		/// Sets a string defining the "gametags" for this server, this is optional, but if it is set</para>
		/// it allows users to filter in the matchmaking/server-browser interfaces based on the value</para>
		/// @see k_cbMaxGameServerTags</para>
		public static void SetGameTags(string pchGameTags) { }

		/// Sets a string defining the "gamedata" for this server, this is optional, but if it is set</para>
		/// it allows users to filter in the matchmaking/server-browser interfaces based on the value</para>
		/// don't set this unless it actually changes, its only uploaded to the master once (when</para>
		/// acknowledged)</para>
		/// @see k_cbMaxGameServerGameData</para>
		public static void SetGameData(string pchGameData) { }

		/// Region identifier.  This is an optional field, the default value is empty, meaning the "world" region</para>
		public static void SetRegion(string pszRegion) { }

		/// Player list management / authentication</para>
		/// Handles receiving a new connection from a Steam user.  This call will ask the Steam</para>
		/// servers to validate the users identity, app ownership, and VAC status.  If the Steam servers</para>
		/// are off-line, then it will validate the cached ticket itself which will validate app ownership</para>
		/// and identity.  The AuthBlob here should be acquired on the game client using SteamUser()-&gt;InitiateGameConnection()</para>
		/// and must then be sent up to the game server for authentication.</para>
		/// Return Value: returns true if the users ticket passes basic checks. pSteamIDUser will contain the Steam ID of this user. pSteamIDUser must NOT be NULL</para>
		/// If the call succeeds then you should expect a GSClientApprove_t or GSClientDeny_t callback which will tell you whether authentication</para>
		/// for the user has succeeded or failed (the steamid in the callback will match the one returned by this call)</para>
		public static bool SendUserConnectAndAuthenticate(uint unIPClient, byte[] pvAuthBlob, uint cubAuthBlobSize, out CSteamID pSteamIDUser) {
			pSteamIDUser = (CSteamID) 0;
			return false;
		}

		/// Creates a fake user (ie, a bot) which will be listed as playing on the server, but skips validation.</para>
		/// Return Value: Returns a SteamID for the user to be tracked with, you should call HandleUserDisconnect()</para>
		/// when this user leaves the server just like you would for a real user.</para>
		public static CSteamID CreateUnauthenticatedUserConnection() {
			return (CSteamID) 0;
		}

		/// Should be called whenever a user leaves our game server, this lets Steam internally</para>
		/// track which users are currently on which servers for the purposes of preventing a single</para>
		/// account being logged into multiple servers, showing who is currently on a server, etc.</para>
		public static void SendUserDisconnect(CSteamID steamIDUser) { }

		/// Update the data to be displayed in the server browser and matchmaking interfaces for a user</para>
		/// currently connected to the server.  For regular users you must call this after you receive a</para>
		/// GSUserValidationSuccess callback.</para>
		/// Return Value: true if successful, false if failure (ie, steamIDUser wasn't for an active player)</para>
		public static bool BUpdateUserData(CSteamID steamIDUser, string pchPlayerName, uint uScore) {
			return false;
		}

		/// New auth system APIs - do not mix with the old auth system APIs.</para>
		/// Retrieve ticket to be sent to the entity who wishes to authenticate you ( using BeginAuthSession API ).</para>
		/// pcbTicket retrieves the length of the actual ticket.</para>
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket) {
			pcbTicket = (uint) 0;
			return (HAuthTicket) 0;
		}

		/// Authenticate ticket ( from GetAuthSessionTicket ) from entity steamID to be sure it is valid and isnt reused</para>
		/// Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )</para>
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID) {
			return (EBeginAuthSessionResult) 0;
		}

		/// Stop tracking started by BeginAuthSession - called when no longer playing game with this entity</para>
		public static void EndAuthSession(CSteamID steamID) { }

		/// Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to</para>
		public static void CancelAuthTicket(HAuthTicket hAuthTicket) { }

		/// After receiving a user's authentication data, and passing it to SendUserConnectAndAuthenticate, use this function</para>
		/// to determine if the user owns downloadable content specified by the provided AppID.</para>
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID) {
			return (EUserHasLicenseForAppResult) 0;
		}

		/// Ask if a user in in the specified group, results returns async by GSUserGroupStatus_t</para>
		/// returns false if we're not connected to the steam servers and thus cannot ask</para>
		public static bool RequestUserGroupStatus(CSteamID steamIDUser, CSteamID steamIDGroup) {
			return false;
		}

		/// these two functions s are deprecated, and will not return results</para>
		/// they will be removed in a future version of the SDK</para>
		public static void GetGameplayStats() { }

		public static SteamAPICall_t GetServerReputation() {
			return (SteamAPICall_t) 0;
		}

		/// Returns the public IP of the server according to Steam, useful when the server is</para>
		/// behind NAT and you want to advertise its IP in a lobby for other clients to directly</para>
		/// connect to</para>
		public static uint GetPublicIP() { return (uint) 0; }

		/// These are in GameSocketShare mode, where instead of ISteamGameServer creating its own</para>
		/// socket to talk to the master server on, it lets the game use its socket to forward messages</para>
		/// back and forth. This prevents us from requiring server ops to open up yet another port</para>
		/// in their firewalls.</para>
		/// the IP address and port should be in host order, i.e 127.0.0.1 == 0x7f000001</para>
		/// These are used when you've elected to multiplex the game server's UDP socket</para>
		/// rather than having the master server updater use its own sockets.</para>
		/// Source games use this to simplify the job of the server admins, so they</para>
		/// don't have to open up more ports on their firewalls.</para>
		/// Call this when a packet that starts with 0xFFFFFFFF comes in. That means</para>
		/// it's for us.</para>
		public static bool HandleIncomingPacket(byte[] pData, int cbData, uint srcIP, ushort srcPort) {
			return false;
		}

		/// AFTER calling HandleIncomingPacket for any packets that came in that frame, call this.</para>
		/// This gets a packet that the master server updater needs to send out on UDP.</para>
		/// It returns the length of the packet it wants to send, or 0 if there are no more packets to send.</para>
		/// Call this each frame until it returns 0.</para>
		public static int GetNextOutgoingPacket(byte[] pOut, int cbMaxOut, out uint pNetAdr, out ushort pPort) {
			pNetAdr = (uint) 0;
			pPort = (ushort) 0;
			return 0;
		}

		/// Control heartbeats / advertisement with master server</para>
		/// Call this as often as you like to tell the master server updater whether or not</para>
		/// you want it to be active (default: off).</para>
		public static void EnableHeartbeats(bool bActive) { }

		/// You usually don't need to modify this.</para>
		/// Pass -1 to use the default value for iHeartbeatInterval.</para>
		/// Some mods change this.</para>
		public static void SetHeartbeatInterval(int iHeartbeatInterval) { }

		/// Force a heartbeat to steam at the next opportunity</para>
		public static void ForceHeartbeat() { }

		/// associate this game server with this clan for the purposes of computing player compat</para>
		public static SteamAPICall_t AssociateWithClan(CSteamID steamIDClan) {
			return (SteamAPICall_t) 0;
		}

		/// ask if any of the current players dont want to play with this new player - or vice versa</para>
		public static SteamAPICall_t ComputeNewPlayerCompatibility(CSteamID steamIDNewPlayer) {
			return (SteamAPICall_t) 0;
		}
	}
}
