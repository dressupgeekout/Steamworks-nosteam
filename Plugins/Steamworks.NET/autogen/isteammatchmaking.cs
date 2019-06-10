// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamMatchmaking {
		/// game server favorites storage
		/// saves basic details about a multiplayer game server locally
		/// returns the number of favorites servers the user has stored
		public static int GetFavoriteGameCount() { return 0; }

		/// returns the details of the game server
		/// iGame is of range [0,GetFavoriteGameCount())
		/// *pnIP, *pnConnPort are filled in the with IP:port of the game server
		/// *punFlags specify whether the game server was stored as an explicit favorite or in the history of connections
		/// *pRTime32LastPlayedOnServer is filled in the with the Unix time the favorite was added
		public static bool GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer) {
			pnAppID = (AppId_t) 0;
			pnIP = (uint) 0;
			pnConnPort = (ushort) 0;
			pnQueryPort = (ushort) 0;
			punFlags = (uint) 0;
			pRTime32LastPlayedOnServer = (uint) 0;
			return false;
		}

		/// adds the game server to the local list; updates the time played of the server if it already exists in the list
		public static int AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer) {
			return 0;
		}

		/// removes the game server from the local storage; returns true if one was removed
		public static bool RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags) {
			return false;
		}

		/// /////
		/// Game lobby functions
		/// Get a list of relevant lobbies
		/// this is an asynchronous request
		/// results will be returned by LobbyMatchList_t callback &amp; call result, with the number of lobbies found
		/// this will never return lobbies that are full
		/// to add more filter, the filter calls below need to be call before each and every RequestLobbyList() call
		/// use the CCallResult&lt;&gt; object in steam_api.h to match the SteamAPICall_t call result to a function in an object, e.g.
		/// 		class CMyLobbyListManager
		/// 		{
		/// 			CCallResult&lt;CMyLobbyListManager, LobbyMatchList_t&gt; m_CallResultLobbyMatchList;
		/// 			void FindLobbies()
		/// 			{
		/// 				// SteamMatchmaking()-&gt;AddRequestLobbyListFilter*() functions would be called here, before RequestLobbyList()
		/// 				SteamAPICall_t hSteamAPICall = SteamMatchmaking()-&gt;RequestLobbyList();
		/// 				m_CallResultLobbyMatchList.Set( hSteamAPICall, this, &amp;CMyLobbyListManager::OnLobbyMatchList );
		/// 			}
		/// 			void OnLobbyMatchList( LobbyMatchList_t *pLobbyMatchList, bool bIOFailure )
		/// 			{
		/// 				// lobby list has be retrieved from Steam back-end, use results
		/// 			}
		/// 		}
		public static SteamAPICall_t RequestLobbyList() { return (SteamAPICall_t) 0; }

		/// filters for lobbies
		/// this needs to be called before RequestLobbyList() to take effect
		/// these are cleared on each call to RequestLobbyList()
		public static void AddRequestLobbyListStringFilter(string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType) { }

		/// numerical comparison
		public static void AddRequestLobbyListNumericalFilter(string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType) { }

		/// returns results closest to the specified value. Multiple near filters can be added, with early filters taking precedence
		public static void AddRequestLobbyListNearValueFilter(string pchKeyToMatch, int nValueToBeCloseTo) { }

		/// returns only lobbies with the specified number of slots available
		public static void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable) { }

		/// sets the distance for which we should search for lobbies (based on users IP address to location map on the Steam backed)
		public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter) { }

		/// sets how many results to return, the lower the count the faster it is to download the lobby results &amp; details to the client
		public static void AddRequestLobbyListResultCountFilter(int cMaxResults) { }

		public static void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby) { }

		/// returns the CSteamID of a lobby, as retrieved by a RequestLobbyList call
		/// should only be called after a LobbyMatchList_t callback is received
		/// iLobby is of the range [0, LobbyMatchList_t::m_nLobbiesMatching)
		/// the returned CSteamID::IsValid() will be false if iLobby is out of range
		public static CSteamID GetLobbyByIndex(int iLobby) {
			return (CSteamID) 0;
		}

		/// Create a lobby on the Steam servers.
		/// If private, then the lobby will not be returned by any RequestLobbyList() call; the CSteamID
		/// of the lobby will need to be communicated via game channels or via InviteUserToLobby()
		/// this is an asynchronous request
		/// results will be returned by LobbyCreated_t callback and call result; lobby is joined &amp; ready to use at this point
		/// a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)
		public static SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers) {
			return (SteamAPICall_t) 0;
		}

		/// Joins an existing lobby
		/// this is an asynchronous request
		/// results will be returned by LobbyEnter_t callback &amp; call result, check m_EChatRoomEnterResponse to see if was successful
		/// lobby metadata is available to use immediately on this call completing
		public static SteamAPICall_t JoinLobby(CSteamID steamIDLobby) {
			return (SteamAPICall_t) 0;
		}

		/// Leave a lobby; this will take effect immediately on the client side
		/// other users in the lobby will be notified by a LobbyChatUpdate_t callback
		public static void LeaveLobby(CSteamID steamIDLobby) { }

		/// Invite another user to the lobby
		/// the target user will receive a LobbyInvite_t callback
		/// will return true if the invite is successfully sent, whether or not the target responds
		/// returns false if the local user is not connected to the Steam servers
		/// if the other user clicks the join link, a GameLobbyJoinRequested_t will be posted if the user is in-game,
		/// or if the game isn't running yet the game will be launched with the parameter +connect_lobby &lt;64-bit lobby id&gt;
		/// </summary>
		public static bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee) {
			return false;
		}

		/// Lobby iteration, for viewing details of users in a lobby
		/// only accessible if the lobby user is a member of the specified lobby
		/// persona information for other lobby members (name, avatar, etc.) will be asynchronously received
		/// and accessible via ISteamFriends interface
		/// returns the number of users in the specified lobby
		public static int GetNumLobbyMembers(CSteamID steamIDLobby) {
			return 0;
		}

		/// returns the CSteamID of a user in the lobby
		/// iMember is of range [0,GetNumLobbyMembers())
		/// note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby
		public static CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember) {
			return (CSteamID) 0;
		}

		/// Get data associated with this lobby
		/// takes a simple key, and returns the string associated with it
		/// "" will be returned if no value is set, or if steamIDLobby is invalid
		public static string GetLobbyData(CSteamID steamIDLobby, string pchKey) {
			return "";
		}

		/// Sets a key/value pair in the lobby metadata
		/// each user in the lobby will be broadcast this new value, and any new users joining will receive any existing data
		/// this can be used to set lobby names, map, etc.
		/// to reset a key, just set it to ""
		/// other users in the lobby will receive notification of the lobby data change via a LobbyDataUpdate_t callback
		public static bool SetLobbyData(CSteamID steamIDLobby, string pchKey, string pchValue) {
			return false;
		}

		/// returns the number of metadata keys set on the specified lobby
		public static int GetLobbyDataCount(CSteamID steamIDLobby) {
			return 0;
		}

		/// returns a lobby metadata key/values pair by index, of range [0, GetLobbyDataCount())
		public static bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize) {
			pchKey = "";
			pchValue = "";
			return false;
		}

		/// removes a metadata key from the lobby
		public static bool DeleteLobbyData(CSteamID steamIDLobby, string pchKey) {
			return false;
		}

		/// Gets per-user metadata for someone in this lobby
		public static string GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, string pchKey) {
			return "";
		}

		/// Sets per-user metadata (for the local user implicitly)
		public static void SetLobbyMemberData(CSteamID steamIDLobby, string pchKey, string pchValue) { }

		/// Broadcasts a chat message to the all the users in the lobby
		/// users in the lobby (including the local user) will receive a LobbyChatMsg_t callback
		/// returns true if the message is successfully sent
		/// pvMsgBody can be binary or text data, up to 4k
		/// if pvMsgBody is text, cubMsgBody should be strlen( text ) + 1, to include the null terminator
		public static bool SendLobbyChatMsg(CSteamID steamIDLobby, byte[] pvMsgBody, int cubMsgBody) {
			return false;
		}

		/// Get a chat message as specified in a LobbyChatMsg_t callback
		/// iChatID is the LobbyChatMsg_t::m_iChatID value in the callback
		/// *pSteamIDUser is filled in with the CSteamID of the member
		/// *pvData is filled in with the message itself
		/// return value is the number of bytes written into the buffer
		public static int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, byte[] pvData, int cubData, out EChatEntryType peChatEntryType) {
			pSteamIDUser = (CSteamID) 0;
			peChatEntryType = (EChatEntryType) 0;
			return 0;
		}

		/// Refreshes metadata for a lobby you're not necessarily in right now
		/// you never do this for lobbies you're a member of, only if your
		/// this will send down all the metadata associated with a lobby
		/// this is an asynchronous call
		/// returns false if the local user is not connected to the Steam servers
		/// results will be returned by a LobbyDataUpdate_t callback
		/// if the specified lobby doesn't exist, LobbyDataUpdate_t::m_bSuccess will be set to false
		public static bool RequestLobbyData(CSteamID steamIDLobby) { return false; }

		/// sets the game server associated with the lobby
		/// usually at this point, the users will join the specified game server
		/// either the IP/Port or the steamID of the game server has to be valid, depending on how you want the clients to be able to connect
		public static void SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer) { }

		/// returns the details of a game server set in a lobby - returns false if there is no game server set, or that lobby doesn't exist
		public static bool GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer) {
			punGameServerIP = (uint) 0;
			punGameServerPort = (ushort) 0;
			psteamIDGameServer = (CSteamID) 0;
			return false;
		}

		/// set the limit on the # of users who can join the lobby
		public static bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers) {
			return false;
		}

		/// returns the current limit on the # of users who can join the lobby; returns 0 if no limit is defined
		public static int GetLobbyMemberLimit(CSteamID steamIDLobby) { return 0; }

		/// updates which type of lobby it is
		/// only lobbies that are k_ELobbyTypePublic or k_ELobbyTypeInvisible, and are set to joinable, will be returned by RequestLobbyList() calls
		public static bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType) {
			return false;
		}

		/// sets whether or not a lobby is joinable - defaults to true for a new lobby
		/// if set to false, no user can join, even if they are a friend or have been invited
		public static bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable) {
			return false;
		}

		/// returns the current lobby owner
		/// you must be a member of the lobby to access this
		/// there always one lobby owner - if the current owner leaves, another user will become the owner
		/// it is possible (bur rare) to join a lobby just as the owner is leaving, thus entering a lobby with self as the owner
		public static CSteamID GetLobbyOwner(CSteamID steamIDLobby) {
			return (CSteamID) 0;
		}

		/// changes who the lobby owner is
		/// you must be the lobby owner for this to succeed, and steamIDNewOwner must be in the lobby
		/// after completion, the local user will no longer be the owner
		public static bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner) {
			return false;
		}

		/// link two lobbies for the purposes of checking player compatibility
		/// you must be the lobby owner of both lobbies
		public static bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent) {
			return false;
		}
#if _PS3
		/// changes who the lobby owner is
		/// you must be the lobby owner for this to succeed, and steamIDNewOwner must be in the lobby
		/// after completion, the local user will no longer be the owner
		public static void CheckForPSNGameBootInvite(uint iGameBootAttributes) { }
#endif
	}
	public static class SteamMatchmakingServers {
		/// Request a new list of servers of a particular type.  These calls each correspond to one of the EMatchMakingType values.
		/// Each call allocates a new asynchronous request object.
		/// Request object must be released by calling ReleaseRequest( hServerListRequest )
		public static HServerListRequest RequestInternetServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		public static HServerListRequest RequestLANServerList(AppId_t iApp, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		public static HServerListRequest RequestFriendsServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		public static HServerListRequest RequestFavoritesServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		public static HServerListRequest RequestHistoryServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		public static HServerListRequest RequestSpectatorServerList(AppId_t iApp, MatchMakingKeyValuePair_t[] ppchFilters, uint nFilters, ISteamMatchmakingServerListResponse pRequestServersResponse) {
			HServerListRequest ret = new HServerListRequest();
			return ret;
		}
		/// Releases the asynchronous request object and cancels any pending query on it if there's a pending query in progress.
		/// RefreshComplete callback is not posted when request is released.
		public static void ReleaseRequest(HServerListRequest hServerListRequest) {
		}
		/// the filter operation codes that go in the key part of MatchMakingKeyValuePair_t should be one of these:
		/// 		"map"
		/// 			- Server passes the filter if the server is playing the specified map.
		/// 		"gamedataand"
		/// 			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) contains all of the
		/// 			specified strings.  The value field is a comma-delimited list of strings to match.
		/// 		"gamedataor"
		/// 			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) contains at least one of the
		/// 			specified strings.  The value field is a comma-delimited list of strings to match.
		/// 		"gamedatanor"
		/// 			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) does not contain any
		/// 			of the specified strings.  The value field is a comma-delimited list of strings to check.
		/// 		"gametagsand"
		/// 			- Server passes the filter if the server's game tags (ISteamGameServer::SetGameTags) contains all
		/// 			of the specified strings.  The value field is a comma-delimited list of strings to check.
		/// 		"gametagsnor"
		/// 			- Server passes the filter if the server's game tags (ISteamGameServer::SetGameTags) does not contain any
		/// 			of the specified strings.  The value field is a comma-delimited list of strings to check.
		/// 		"and" (x1 &amp;&amp; x2 &amp;&amp; ... &amp;&amp; xn)
		/// 		"or" (x1 || x2 || ... || xn)
		/// 		"nand" !(x1 &amp;&amp; x2 &amp;&amp; ... &amp;&amp; xn)
		/// 		"nor" !(x1 || x2 || ... || xn)
		/// 			- Performs Boolean operation on the following filters.  The operand to this filter specifies
		/// 			the "size" of the Boolean inputs to the operation, in Key/value pairs.  (The keyvalue
		/// 			pairs must immediately follow, i.e. this is a prefix logical operator notation.)
		/// 			In the simplest case where Boolean expressions are not nested, this is simply
		/// 			the number of operands.
		/// 			For example, to match servers on a particular map or with a particular tag, would would
		/// 			use these filters.
		/// 				( server.map == "cp_dustbowl" || server.gametags.contains("payload") )
		/// 				"or", "2"
		/// 				"map", "cp_dustbowl"
		/// 				"gametagsand", "payload"
		/// 			If logical inputs are nested, then the operand specifies the size of the entire
		/// 			"length" of its operands, not the number of immediate children.
		/// 				( server.map == "cp_dustbowl" || ( server.gametags.contains("payload") &amp;&amp; !server.gametags.contains("payloadrace") ) )
		/// 				"or", "4"
		/// 				"map", "cp_dustbowl"
		/// 				"and", "2"
		/// 				"gametagsand", "payload"
		/// 				"gametagsnor", "payloadrace"
		/// 			Unary NOT can be achieved using either "nand" or "nor" with a single operand.
		/// 		"addr"
		/// 			- Server passes the filter if the server's query address matches the specified IP or IP:port.
		/// 		"gameaddr"
		/// 			- Server passes the filter if the server's game address matches the specified IP or IP:port.
		/// 		The following filter operations ignore the "value" part of MatchMakingKeyValuePair_t
		/// 		"dedicated"
		/// 			- Server passes the filter if it passed true to SetDedicatedServer.
		/// 		"secure"
		/// 			- Server passes the filter if the server is VAC-enabled.
		/// 		"notfull"
		/// 			- Server passes the filter if the player count is less than the reported max player count.
		/// 		"hasplayers"
		/// 			- Server passes the filter if the player count is greater than zero.
		/// 		"noplayers"
		/// 			- Server passes the filter if it doesn't have any players.
		/// 		"linux"
		/// 			- Server passes the filter if it's a linux server
		/// Get details on a given server in the list, you can get the valid range of index
		/// values by calling GetServerCount().  You will also receive index values in
		/// ISteamMatchmakingServerListResponse::ServerResponded() callbacks
		public static gameserveritem_t GetServerDetails(HServerListRequest hRequest, int iServer) {
			gameserveritem_t ret = new gameserveritem_t();
			return ret;
		}

		/// Cancel an request which is operation on the given list type.  You should call this to cancel
		/// any in-progress requests before destructing a callback object that may have been passed
		/// to one of the above list request calls.  Not doing so may result in a crash when a callback
		/// occurs on the destructed object.
		/// Canceling a query does not release the allocated request handle.
		/// The request handle must be released using ReleaseRequest( hRequest )
		public static void CancelQuery(HServerListRequest hRequest) { }

		/// Ping every server in your list again but don't update the list of servers
		/// Query callback installed when the server list was requested will be used
		/// again to post notifications and RefreshComplete, so the callback must remain
		/// valid until another RefreshComplete is called on it or the request
		/// is released with ReleaseRequest( hRequest )
		public static void RefreshQuery(HServerListRequest hRequest) { }

		/// Returns true if the list is currently refreshing its server list
		public static bool IsRefreshing(HServerListRequest hRequest) { return false; }

		/// How many servers in the given list, GetServerDetails above takes 0... GetServerCount() - 1
		public static int GetServerCount(HServerListRequest hRequest) { return 0; }

		/// Refresh a single server inside of a query (rather than all the servers )
		public static void RefreshServer(HServerListRequest hRequest, int iServer) { }

		/// Queries to individual servers directly via IP/Port

		/// Request updated ping time and other details from a single server
		public static HServerQuery PingServer(uint unIP, ushort usPort, ISteamMatchmakingPingResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// Request the list of players currently playing on a server
		public static HServerQuery PlayerDetails(uint unIP, ushort usPort, ISteamMatchmakingPlayersResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// Request the list of rules that the server is running (See ISteamGameServer::SetKeyValue() to set the rules server side)
		public static HServerQuery ServerRules(uint unIP, ushort usPort, ISteamMatchmakingRulesResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// Cancel an outstanding Ping/Players/Rules query from above.  You should call this to cancel
		/// any in-progress requests before destructing a callback object that may have been passed
		/// to one of the above calls to avoid crashing when callbacks occur.
		public static void CancelServerQuery(HServerQuery hServerQuery) { }
	}
	public static class SteamGameSearch {
		/// Game Player APIs
		/// a keyname and a list of comma separated values: one of which is must be found in order for the match to qualify
		/// fails if a search is currently in progress
		public static EGameSearchErrorCode_t AddGameSearchParams(string pchKeyToFind, string pchValuesToFind) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// all players in lobby enter the queue and await a SearchForGameNotificationCallback_t callback. fails if another search is currently in progress
		/// if not the owner of the lobby or search already in progress this call fails
		/// periodic callbacks will be sent as queue time estimates change
		public static EGameSearchErrorCode_t SearchForGameWithLobby(CSteamID steamIDLobby, int nPlayerMin, int nPlayerMax) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// user enter the queue and await a SearchForGameNotificationCallback_t callback. fails if another search is currently in progress
		/// periodic callbacks will be sent as queue time estimates change
		public static EGameSearchErrorCode_t SearchForGameSolo(int nPlayerMin, int nPlayerMax) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// after receiving SearchForGameResultCallback_t, accept or decline the game
		/// multiple SearchForGameResultCallback_t will follow as players accept game until the host starts or cancels the game
		public static EGameSearchErrorCode_t AcceptGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		public static EGameSearchErrorCode_t DeclineGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// after receiving GameStartedByHostCallback_t get connection details to server
		public static EGameSearchErrorCode_t RetrieveConnectionDetails(CSteamID steamIDHost, out string pchConnectionDetails, int cubConnectionDetails) {
			pchConnectionDetails = "";
			return (EGameSearchErrorCode_t) 0;
		}

		// leaves nueue if still waiting
		public static EGameSearchErrorCode_t EndGameSearch() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// Game Host APIs
		/// a keyname and a list of comma separated values: all the values you allow
		public static EGameSearchErrorCode_t SetGameHostParams(string pchKey, string pchValue) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// set connection details for players once game is found so they can connect to this server
		public static EGameSearchErrorCode_t SetConnectionDetails(string pchConnectionDetails, int cubConnectionDetails) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// mark server as available for more players with nPlayerMin,nPlayerMax desired
		/// accept no lobbies with playercount greater than nMaxTeamSize
		/// the set of lobbies returned must be partitionable into teams of no more than nMaxTeamSize
		/// RequestPlayersForGameNotificationCallback_t callback will be sent when the search has started
		/// multple RequestPlayersForGameResultCallback_t callbacks will follow when players are found
		public static EGameSearchErrorCode_t RequestPlayersForGame(int nPlayerMin, int nPlayerMax, int nMaxTeamSize) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// accept the player list and release connection details to players
		/// players will only be given connection details and host steamid when this is called
		/// ( allows host to accept after all players confirm, some confirm, or none confirm. decision is entirely up to the host )
		public static EGameSearchErrorCode_t HostConfirmGameStart(ulong ullUniqueGameID) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// cancel request and leave the pool of game hosts looking for players
		/// if a set of players has already been sent to host, all players will receive SearchForGameHostFailedToConfirm_t
		public static EGameSearchErrorCode_t CancelRequestPlayersForGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// submit a result for one player. does not end the game. ullUniqueGameID continues to describe this game
		public static EGameSearchErrorCode_t SubmitPlayerResult(ulong ullUniqueGameID, CSteamID steamIDPlayer, EPlayerResult_t EPlayerResult) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// ends the game. no further SubmitPlayerResults for ullUniqueGameID will be accepted
		/// any future requests will provide a new ullUniqueGameID
		public static EGameSearchErrorCode_t EndGame(ulong ullUniqueGameID) {
			return (EGameSearchErrorCode_t) 0;
		}
	}
	public static class SteamParties {
		/// Party Client APIs
		/// Enumerate any active beacons for parties you may wish to join
		public static uint GetNumActiveBeacons() { return (uint) 0; }

		public static PartyBeaconID_t GetBeaconByIndex(uint unIndex) {
			return (PartyBeaconID_t) 0;
		}
		public static bool GetBeaconDetails(PartyBeaconID_t ulBeaconID, out CSteamID pSteamIDBeaconOwner, out SteamPartyBeaconLocation_t pLocation, out string pchMetadata, int cchMetadata) {
			pSteamIDBeaconOwner = (CSteamID) 0;
			pLocation = new SteamPartyBeaconLocation_t();
			pchMetadata = "";
			return false;
		}

		/// Join an open party. Steam will reserve one beacon slot for your SteamID,
		/// and return the necessary JoinGame string for you to use to connect
		public static SteamAPICall_t JoinParty(PartyBeaconID_t ulBeaconID) {
			return (SteamAPICall_t) 0;
		}

		/// Party Host APIs
		/// Get a list of possible beacon locations
		public static bool GetNumAvailableBeaconLocations(out uint puNumLocations) {
			puNumLocations = (uint) 0;
			return false;
		}

		public static bool GetAvailableBeaconLocations(out SteamPartyBeaconLocation_t pLocationList, uint uMaxNumLocations) {
			pLocationList = new SteamPartyBeaconLocation_t();
			return false;
		}

		/// Create a new party beacon and activate it in the selected location.
		/// unOpenSlots is the maximum number of users that Steam will send to you.
		/// When people begin responding to your beacon, Steam will send you
		/// PartyReservationCallback_t callbacks to let you know who is on the way.
		public static SteamAPICall_t CreateBeacon(uint unOpenSlots, out SteamPartyBeaconLocation_t pBeaconLocation, string pchConnectString, string pchMetadata) {
			pBeaconLocation = new SteamPartyBeaconLocation_t();
			return (SteamAPICall_t) 0;
		}

		/// Call this function when a user that had a reservation (see callback below)
		/// has successfully joined your party.
		/// Steam will manage the remaining open slots automatically.
		public static void OnReservationCompleted(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) { }

		/// To cancel a reservation (due to timeout or user input), call this.
		/// Steam will open a new reservation slot.
		/// Note: The user may already be in-flight to your game, so it's possible they will still connect and try to join your party.
		public static void CancelReservation(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) { }

		/// Change the number of open beacon reservation slots.
		/// Call this if, for example, someone without a reservation joins your party (eg a friend, or via your own matchmaking system).
		public static SteamAPICall_t ChangeNumOpenSlots(PartyBeaconID_t ulBeacon, uint unOpenSlots) {
			return (SteamAPICall_t) 0;
		}

		/// Turn off the beacon.
		public static bool DestroyBeacon(PartyBeaconID_t ulBeacon) { return false; }

		/// Utils
		public static bool GetBeaconLocationData(SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, out string pchDataStringOut, int cchDataStringOut) {
			pchDataStringOut = "";
			return false;
		}
	}
}
