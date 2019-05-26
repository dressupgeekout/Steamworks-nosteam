// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamMatchmaking {
		/// <para> game server favorites storage</para>
		/// <para> saves basic details about a multiplayer game server locally</para>
		/// <para> returns the number of favorites servers the user has stored</para>
		public static int GetFavoriteGameCount() {
			return 0;
		}

		/// <para> returns the details of the game server</para>
		/// <para> iGame is of range [0,GetFavoriteGameCount())</para>
		/// <para> *pnIP, *pnConnPort are filled in the with IP:port of the game server</para>
		/// <para> *punFlags specify whether the game server was stored as an explicit favorite or in the history of connections</para>
		/// <para> *pRTime32LastPlayedOnServer is filled in the with the Unix time the favorite was added</para>
		public static bool GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer) {
			pnAppID = (AppId_t) 0;
			pnIP = (uint) 0;
			pnConnPort = (ushort) 0;
			pnQueryPort = (ushort) 0;
			punFlags = (uint) 0;
			pRTime32LastPlayedOnServer = (uint) 0;
			return false;
		}

		/// <para> adds the game server to the local list; updates the time played of the server if it already exists in the list</para>
		public static int AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer) {
			return 0;
		}

		/// <para> removes the game server from the local storage; returns true if one was removed</para>
		public static bool RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags) {
			return false;
		}

		/// <para>/////</para>
		/// <para> Game lobby functions</para>
		/// <para> Get a list of relevant lobbies</para>
		/// <para> this is an asynchronous request</para>
		/// <para> results will be returned by LobbyMatchList_t callback &amp; call result, with the number of lobbies found</para>
		/// <para> this will never return lobbies that are full</para>
		/// <para> to add more filter, the filter calls below need to be call before each and every RequestLobbyList() call</para>
		/// <para> use the CCallResult&lt;&gt; object in steam_api.h to match the SteamAPICall_t call result to a function in an object, e.g.</para>
		/// <para>		class CMyLobbyListManager</para>
		/// <para>		{</para>
		/// <para>			CCallResult&lt;CMyLobbyListManager, LobbyMatchList_t&gt; m_CallResultLobbyMatchList;</para>
		/// <para>			void FindLobbies()</para>
		/// <para>			{</para>
		/// <para>				// SteamMatchmaking()-&gt;AddRequestLobbyListFilter*() functions would be called here, before RequestLobbyList()</para>
		/// <para>				SteamAPICall_t hSteamAPICall = SteamMatchmaking()-&gt;RequestLobbyList();</para>
		/// <para>				m_CallResultLobbyMatchList.Set( hSteamAPICall, this, &amp;CMyLobbyListManager::OnLobbyMatchList );</para>
		/// <para>			}</para>
		/// <para>			void OnLobbyMatchList( LobbyMatchList_t *pLobbyMatchList, bool bIOFailure )</para>
		/// <para>			{</para>
		/// <para>				// lobby list has be retrieved from Steam back-end, use results</para>
		/// <para>			}</para>
		/// <para>		}</para>
		public static SteamAPICall_t RequestLobbyList() {
			return (SteamAPICall_t) 0;
		}

		/// <para> filters for lobbies</para>
		/// <para> this needs to be called before RequestLobbyList() to take effect</para>
		/// <para> these are cleared on each call to RequestLobbyList()</para>
		public static void AddRequestLobbyListStringFilter(string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType) {
		}

		/// <para> numerical comparison</para>
		public static void AddRequestLobbyListNumericalFilter(string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType) {
		}

		/// <para> returns results closest to the specified value. Multiple near filters can be added, with early filters taking precedence</para>
		public static void AddRequestLobbyListNearValueFilter(string pchKeyToMatch, int nValueToBeCloseTo) {
		}

		/// <para> returns only lobbies with the specified number of slots available</para>
		public static void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable) {
		}

		/// <para> sets the distance for which we should search for lobbies (based on users IP address to location map on the Steam backed)</para>
		public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter) {
		}

		/// <para> sets how many results to return, the lower the count the faster it is to download the lobby results &amp; details to the client</para>
		public static void AddRequestLobbyListResultCountFilter(int cMaxResults) {
		}

		public static void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby) {
		}

		/// <para> returns the CSteamID of a lobby, as retrieved by a RequestLobbyList call</para>
		/// <para> should only be called after a LobbyMatchList_t callback is received</para>
		/// <para> iLobby is of the range [0, LobbyMatchList_t::m_nLobbiesMatching)</para>
		/// <para> the returned CSteamID::IsValid() will be false if iLobby is out of range</para>
		public static CSteamID GetLobbyByIndex(int iLobby) {
			return (CSteamID) 0;
		}

		/// <para> Create a lobby on the Steam servers.</para>
		/// <para> If private, then the lobby will not be returned by any RequestLobbyList() call; the CSteamID</para>
		/// <para> of the lobby will need to be communicated via game channels or via InviteUserToLobby()</para>
		/// <para> this is an asynchronous request</para>
		/// <para> results will be returned by LobbyCreated_t callback and call result; lobby is joined &amp; ready to use at this point</para>
		/// <para> a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)</para>
		public static SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Joins an existing lobby</para>
		/// <para> this is an asynchronous request</para>
		/// <para> results will be returned by LobbyEnter_t callback &amp; call result, check m_EChatRoomEnterResponse to see if was successful</para>
		/// <para> lobby metadata is available to use immediately on this call completing</para>
		public static SteamAPICall_t JoinLobby(CSteamID steamIDLobby) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Leave a lobby; this will take effect immediately on the client side</para>
		/// <para> other users in the lobby will be notified by a LobbyChatUpdate_t callback</para>
		public static void LeaveLobby(CSteamID steamIDLobby) {
		}

		/// <para> Invite another user to the lobby</para>
		/// <para> the target user will receive a LobbyInvite_t callback</para>
		/// <para> will return true if the invite is successfully sent, whether or not the target responds</para>
		/// <para> returns false if the local user is not connected to the Steam servers</para>
		/// <para> if the other user clicks the join link, a GameLobbyJoinRequested_t will be posted if the user is in-game,</para>
		/// <para> or if the game isn't running yet the game will be launched with the parameter +connect_lobby &lt;64-bit lobby id&gt;</para>
		/// </summary>
		public static bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee) {
			return false;
		}

		/// <para> Lobby iteration, for viewing details of users in a lobby</para>
		/// <para> only accessible if the lobby user is a member of the specified lobby</para>
		/// <para> persona information for other lobby members (name, avatar, etc.) will be asynchronously received</para>
		/// <para> and accessible via ISteamFriends interface</para>
		/// <para> returns the number of users in the specified lobby</para>
		public static int GetNumLobbyMembers(CSteamID steamIDLobby) {
			return 0;
		}

		/// <para> returns the CSteamID of a user in the lobby</para>
		/// <para> iMember is of range [0,GetNumLobbyMembers())</para>
		/// <para> note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby</para>
		public static CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember) {
			return (CSteamID) 0;
		}

		/// <para> Get data associated with this lobby</para>
		/// <para> takes a simple key, and returns the string associated with it</para>
		/// <para> "" will be returned if no value is set, or if steamIDLobby is invalid</para>
		public static string GetLobbyData(CSteamID steamIDLobby, string pchKey) {
			return "";
		}

		/// <para> Sets a key/value pair in the lobby metadata</para>
		/// <para> each user in the lobby will be broadcast this new value, and any new users joining will receive any existing data</para>
		/// <para> this can be used to set lobby names, map, etc.</para>
		/// <para> to reset a key, just set it to ""</para>
		/// <para> other users in the lobby will receive notification of the lobby data change via a LobbyDataUpdate_t callback</para>
		public static bool SetLobbyData(CSteamID steamIDLobby, string pchKey, string pchValue) {
			return false;
		}

		/// <para> returns the number of metadata keys set on the specified lobby</para>
		public static int GetLobbyDataCount(CSteamID steamIDLobby) {
			return 0;
		}

		/// <para> returns a lobby metadata key/values pair by index, of range [0, GetLobbyDataCount())</para>
		public static bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize) {
			pchKey = "";
			pchValue = "";
			return false;
		}

		/// <para> removes a metadata key from the lobby</para>
		public static bool DeleteLobbyData(CSteamID steamIDLobby, string pchKey) {
			return false;
		}

		/// <para> Gets per-user metadata for someone in this lobby</para>
		public static string GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, string pchKey) {
			return "";
		}

		/// <para> Sets per-user metadata (for the local user implicitly)</para>
		public static void SetLobbyMemberData(CSteamID steamIDLobby, string pchKey, string pchValue) {
		}

		/// <para> Broadcasts a chat message to the all the users in the lobby</para>
		/// <para> users in the lobby (including the local user) will receive a LobbyChatMsg_t callback</para>
		/// <para> returns true if the message is successfully sent</para>
		/// <para> pvMsgBody can be binary or text data, up to 4k</para>
		/// <para> if pvMsgBody is text, cubMsgBody should be strlen( text ) + 1, to include the null terminator</para>
		public static bool SendLobbyChatMsg(CSteamID steamIDLobby, byte[] pvMsgBody, int cubMsgBody) {
			return false;
		}

		/// <para> Get a chat message as specified in a LobbyChatMsg_t callback</para>
		/// <para> iChatID is the LobbyChatMsg_t::m_iChatID value in the callback</para>
		/// <para> *pSteamIDUser is filled in with the CSteamID of the member</para>
		/// <para> *pvData is filled in with the message itself</para>
		/// <para> return value is the number of bytes written into the buffer</para>
		public static int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, byte[] pvData, int cubData, out EChatEntryType peChatEntryType) {
			pSteamIDUser = (CSteamID) 0;
			peChatEntryType = (EChatEntryType) 0;
			return 0;
		}

		/// <para> Refreshes metadata for a lobby you're not necessarily in right now</para>
		/// <para> you never do this for lobbies you're a member of, only if your</para>
		/// <para> this will send down all the metadata associated with a lobby</para>
		/// <para> this is an asynchronous call</para>
		/// <para> returns false if the local user is not connected to the Steam servers</para>
		/// <para> results will be returned by a LobbyDataUpdate_t callback</para>
		/// <para> if the specified lobby doesn't exist, LobbyDataUpdate_t::m_bSuccess will be set to false</para>
		public static bool RequestLobbyData(CSteamID steamIDLobby) {
			return false;
		}

		/// <para> sets the game server associated with the lobby</para>
		/// <para> usually at this point, the users will join the specified game server</para>
		/// <para> either the IP/Port or the steamID of the game server has to be valid, depending on how you want the clients to be able to connect</para>
		public static void SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer) {
		}

		/// <para> returns the details of a game server set in a lobby - returns false if there is no game server set, or that lobby doesn't exist</para>
		public static bool GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer) {
			punGameServerIP = (uint) 0;
			punGameServerPort = (ushort) 0;
			psteamIDGameServer = (CSteamID) 0;
			return false;
		}

		/// <para> set the limit on the # of users who can join the lobby</para>
		public static bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers) {
			return false;
		}

		/// <para> returns the current limit on the # of users who can join the lobby; returns 0 if no limit is defined</para>
		public static int GetLobbyMemberLimit(CSteamID steamIDLobby) {
			return 0;
		}

		/// <para> updates which type of lobby it is</para>
		/// <para> only lobbies that are k_ELobbyTypePublic or k_ELobbyTypeInvisible, and are set to joinable, will be returned by RequestLobbyList() calls</para>
		public static bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType) {
			return false;
		}

		/// <para> sets whether or not a lobby is joinable - defaults to true for a new lobby</para>
		/// <para> if set to false, no user can join, even if they are a friend or have been invited</para>
		public static bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable) {
			return false;
		}

		/// <para> returns the current lobby owner</para>
		/// <para> you must be a member of the lobby to access this</para>
		/// <para> there always one lobby owner - if the current owner leaves, another user will become the owner</para>
		/// <para> it is possible (bur rare) to join a lobby just as the owner is leaving, thus entering a lobby with self as the owner</para>
		public static CSteamID GetLobbyOwner(CSteamID steamIDLobby) {
			return (CSteamID) 0;
		}

		/// <para> changes who the lobby owner is</para>
		/// <para> you must be the lobby owner for this to succeed, and steamIDNewOwner must be in the lobby</para>
		/// <para> after completion, the local user will no longer be the owner</para>
		public static bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner) {
			return false;
		}

		/// <para> link two lobbies for the purposes of checking player compatibility</para>
		/// <para> you must be the lobby owner of both lobbies</para>
		public static bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent) {
			return false;
		}
#if _PS3
		/// <para> changes who the lobby owner is</para>
		/// <para> you must be the lobby owner for this to succeed, and steamIDNewOwner must be in the lobby</para>
		/// <para> after completion, the local user will no longer be the owner</para>
		public static void CheckForPSNGameBootInvite(uint iGameBootAttributes) {
		}
#endif
	}
	public static class SteamMatchmakingServers {
		/// <para> Request a new list of servers of a particular type.  These calls each correspond to one of the EMatchMakingType values.</para>
		/// <para> Each call allocates a new asynchronous request object.</para>
		/// <para> Request object must be released by calling ReleaseRequest( hServerListRequest )</para>
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

		/// <para> Releases the asynchronous request object and cancels any pending query on it if there's a pending query in progress.</para>
		/// <para> RefreshComplete callback is not posted when request is released.</para>
		public static void ReleaseRequest(HServerListRequest hServerListRequest) {
		}

		/// <para> the filter operation codes that go in the key part of MatchMakingKeyValuePair_t should be one of these:</para>
		/// <para>		"map"</para>
		/// <para>			- Server passes the filter if the server is playing the specified map.</para>
		/// <para>		"gamedataand"</para>
		/// <para>			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) contains all of the</para>
		/// <para>			specified strings.  The value field is a comma-delimited list of strings to match.</para>
		/// <para>		"gamedataor"</para>
		/// <para>			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) contains at least one of the</para>
		/// <para>			specified strings.  The value field is a comma-delimited list of strings to match.</para>
		/// <para>		"gamedatanor"</para>
		/// <para>			- Server passes the filter if the server's game data (ISteamGameServer::SetGameData) does not contain any</para>
		/// <para>			of the specified strings.  The value field is a comma-delimited list of strings to check.</para>
		/// <para>		"gametagsand"</para>
		/// <para>			- Server passes the filter if the server's game tags (ISteamGameServer::SetGameTags) contains all</para>
		/// <para>			of the specified strings.  The value field is a comma-delimited list of strings to check.</para>
		/// <para>		"gametagsnor"</para>
		/// <para>			- Server passes the filter if the server's game tags (ISteamGameServer::SetGameTags) does not contain any</para>
		/// <para>			of the specified strings.  The value field is a comma-delimited list of strings to check.</para>
		/// <para>		"and" (x1 &amp;&amp; x2 &amp;&amp; ... &amp;&amp; xn)</para>
		/// <para>		"or" (x1 || x2 || ... || xn)</para>
		/// <para>		"nand" !(x1 &amp;&amp; x2 &amp;&amp; ... &amp;&amp; xn)</para>
		/// <para>		"nor" !(x1 || x2 || ... || xn)</para>
		/// <para>			- Performs Boolean operation on the following filters.  The operand to this filter specifies</para>
		/// <para>			the "size" of the Boolean inputs to the operation, in Key/value pairs.  (The keyvalue</para>
		/// <para>			pairs must immediately follow, i.e. this is a prefix logical operator notation.)</para>
		/// <para>			In the simplest case where Boolean expressions are not nested, this is simply</para>
		/// <para>			the number of operands.</para>
		/// <para>			For example, to match servers on a particular map or with a particular tag, would would</para>
		/// <para>			use these filters.</para>
		/// <para>				( server.map == "cp_dustbowl" || server.gametags.contains("payload") )</para>
		/// <para>				"or", "2"</para>
		/// <para>				"map", "cp_dustbowl"</para>
		/// <para>				"gametagsand", "payload"</para>
		/// <para>			If logical inputs are nested, then the operand specifies the size of the entire</para>
		/// <para>			"length" of its operands, not the number of immediate children.</para>
		/// <para>				( server.map == "cp_dustbowl" || ( server.gametags.contains("payload") &amp;&amp; !server.gametags.contains("payloadrace") ) )</para>
		/// <para>				"or", "4"</para>
		/// <para>				"map", "cp_dustbowl"</para>
		/// <para>				"and", "2"</para>
		/// <para>				"gametagsand", "payload"</para>
		/// <para>				"gametagsnor", "payloadrace"</para>
		/// <para>			Unary NOT can be achieved using either "nand" or "nor" with a single operand.</para>
		/// <para>		"addr"</para>
		/// <para>			- Server passes the filter if the server's query address matches the specified IP or IP:port.</para>
		/// <para>		"gameaddr"</para>
		/// <para>			- Server passes the filter if the server's game address matches the specified IP or IP:port.</para>
		/// <para>		The following filter operations ignore the "value" part of MatchMakingKeyValuePair_t</para>
		/// <para>		"dedicated"</para>
		/// <para>			- Server passes the filter if it passed true to SetDedicatedServer.</para>
		/// <para>		"secure"</para>
		/// <para>			- Server passes the filter if the server is VAC-enabled.</para>
		/// <para>		"notfull"</para>
		/// <para>			- Server passes the filter if the player count is less than the reported max player count.</para>
		/// <para>		"hasplayers"</para>
		/// <para>			- Server passes the filter if the player count is greater than zero.</para>
		/// <para>		"noplayers"</para>
		/// <para>			- Server passes the filter if it doesn't have any players.</para>
		/// <para>		"linux"</para>
		/// <para>			- Server passes the filter if it's a linux server</para>
		/// <para> Get details on a given server in the list, you can get the valid range of index</para>
		/// <para> values by calling GetServerCount().  You will also receive index values in</para>
		/// <para> ISteamMatchmakingServerListResponse::ServerResponded() callbacks</para>
		public static gameserveritem_t GetServerDetails(HServerListRequest hRequest, int iServer) {
			gameserveritem_t ret = new gameserveritem_t();
			return ret;
		}

		/// <para> Cancel an request which is operation on the given list type.  You should call this to cancel</para>
		/// <para> any in-progress requests before destructing a callback object that may have been passed</para>
		/// <para> to one of the above list request calls.  Not doing so may result in a crash when a callback</para>
		/// <para> occurs on the destructed object.</para>
		/// <para> Canceling a query does not release the allocated request handle.</para>
		/// <para> The request handle must be released using ReleaseRequest( hRequest )</para>
		public static void CancelQuery(HServerListRequest hRequest) {
		}

		/// <para> Ping every server in your list again but don't update the list of servers</para>
		/// <para> Query callback installed when the server list was requested will be used</para>
		/// <para> again to post notifications and RefreshComplete, so the callback must remain</para>
		/// <para> valid until another RefreshComplete is called on it or the request</para>
		/// <para> is released with ReleaseRequest( hRequest )</para>
		public static void RefreshQuery(HServerListRequest hRequest) {
		}

		/// <para> Returns true if the list is currently refreshing its server list</para>
		public static bool IsRefreshing(HServerListRequest hRequest) {
			return false;
		}

		/// <para> How many servers in the given list, GetServerDetails above takes 0... GetServerCount() - 1</para>
		public static int GetServerCount(HServerListRequest hRequest) {
			return 0;
		}

		/// <para> Refresh a single server inside of a query (rather than all the servers )</para>
		public static void RefreshServer(HServerListRequest hRequest, int iServer) {
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Queries to individual servers directly via IP/Port</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Request updated ping time and other details from a single server</para>
		public static HServerQuery PingServer(uint unIP, ushort usPort, ISteamMatchmakingPingResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// <para> Request the list of players currently playing on a server</para>
		public static HServerQuery PlayerDetails(uint unIP, ushort usPort, ISteamMatchmakingPlayersResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// <para> Request the list of rules that the server is running (See ISteamGameServer::SetKeyValue() to set the rules server side)</para>
		public static HServerQuery ServerRules(uint unIP, ushort usPort, ISteamMatchmakingRulesResponse pRequestServersResponse) {
			return (HServerQuery) 0;
		}

		/// <para> Cancel an outstanding Ping/Players/Rules query from above.  You should call this to cancel</para>
		/// <para> any in-progress requests before destructing a callback object that may have been passed</para>
		/// <para> to one of the above calls to avoid crashing when callbacks occur.</para>
		public static void CancelServerQuery(HServerQuery hServerQuery) {
		}
	}
	public static class SteamGameSearch {
		/// <para> =============================================================================================</para>
		/// <para> Game Player APIs</para>
		/// <para> a keyname and a list of comma separated values: one of which is must be found in order for the match to qualify</para>
		/// <para> fails if a search is currently in progress</para>
		public static EGameSearchErrorCode_t AddGameSearchParams(string pchKeyToFind, string pchValuesToFind) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> all players in lobby enter the queue and await a SearchForGameNotificationCallback_t callback. fails if another search is currently in progress</para>
		/// <para> if not the owner of the lobby or search already in progress this call fails</para>
		/// <para> periodic callbacks will be sent as queue time estimates change</para>
		public static EGameSearchErrorCode_t SearchForGameWithLobby(CSteamID steamIDLobby, int nPlayerMin, int nPlayerMax) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> user enter the queue and await a SearchForGameNotificationCallback_t callback. fails if another search is currently in progress</para>
		/// <para> periodic callbacks will be sent as queue time estimates change</para>
		public static EGameSearchErrorCode_t SearchForGameSolo(int nPlayerMin, int nPlayerMax) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> after receiving SearchForGameResultCallback_t, accept or decline the game</para>
		/// <para> multiple SearchForGameResultCallback_t will follow as players accept game until the host starts or cancels the game</para>
		public static EGameSearchErrorCode_t AcceptGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		public static EGameSearchErrorCode_t DeclineGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> after receiving GameStartedByHostCallback_t get connection details to server</para>
		public static EGameSearchErrorCode_t RetrieveConnectionDetails(CSteamID steamIDHost, out string pchConnectionDetails, int cubConnectionDetails) {
			pchConnectionDetails = "";
			return (EGameSearchErrorCode_t) 0;
		}

		// <para> leaves nueue if still waiting</para>
		public static EGameSearchErrorCode_t EndGameSearch() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> =============================================================================================</para>
		/// <para> Game Host APIs</para>
		/// <para> a keyname and a list of comma separated values: all the values you allow</para>
		public static EGameSearchErrorCode_t SetGameHostParams(string pchKey, string pchValue) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> set connection details for players once game is found so they can connect to this server</para>
		public static EGameSearchErrorCode_t SetConnectionDetails(string pchConnectionDetails, int cubConnectionDetails) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> mark server as available for more players with nPlayerMin,nPlayerMax desired</para>
		/// <para> accept no lobbies with playercount greater than nMaxTeamSize</para>
		/// <para> the set of lobbies returned must be partitionable into teams of no more than nMaxTeamSize</para>
		/// <para> RequestPlayersForGameNotificationCallback_t callback will be sent when the search has started</para>
		/// <para> multple RequestPlayersForGameResultCallback_t callbacks will follow when players are found</para>
		public static EGameSearchErrorCode_t RequestPlayersForGame(int nPlayerMin, int nPlayerMax, int nMaxTeamSize) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> accept the player list and release connection details to players</para>
		/// <para> players will only be given connection details and host steamid when this is called</para>
		/// <para> ( allows host to accept after all players confirm, some confirm, or none confirm. decision is entirely up to the host )</para>
		public static EGameSearchErrorCode_t HostConfirmGameStart(ulong ullUniqueGameID) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> cancel request and leave the pool of game hosts looking for players</para>
		/// <para> if a set of players has already been sent to host, all players will receive SearchForGameHostFailedToConfirm_t</para>
		public static EGameSearchErrorCode_t CancelRequestPlayersForGame() {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> submit a result for one player. does not end the game. ullUniqueGameID continues to describe this game</para>
		public static EGameSearchErrorCode_t SubmitPlayerResult(ulong ullUniqueGameID, CSteamID steamIDPlayer, EPlayerResult_t EPlayerResult) {
			return (EGameSearchErrorCode_t) 0;
		}

		/// <para> ends the game. no further SubmitPlayerResults for ullUniqueGameID will be accepted</para>
		/// <para> any future requests will provide a new ullUniqueGameID</para>
		public static EGameSearchErrorCode_t EndGame(ulong ullUniqueGameID) {
			return (EGameSearchErrorCode_t) 0;
		}
	}
	public static class SteamParties {
		/// <para> =============================================================================================</para>
		/// <para> Party Client APIs</para>
		/// <para> Enumerate any active beacons for parties you may wish to join</para>
		public static uint GetNumActiveBeacons() {
			return (uint) 0;
		}

		public static PartyBeaconID_t GetBeaconByIndex(uint unIndex) {
			return (PartyBeaconID_t) 0;
		}

		public static bool GetBeaconDetails(PartyBeaconID_t ulBeaconID, out CSteamID pSteamIDBeaconOwner, out SteamPartyBeaconLocation_t pLocation, out string pchMetadata, int cchMetadata) {
			pSteamIDBeaconOwner = (CSteamID) 0;
			pLocation = new SteamPartyBeaconLocation_t();
			pchMetadata = "";
			return false;
		}

		/// <para> Join an open party. Steam will reserve one beacon slot for your SteamID,</para>
		/// <para> and return the necessary JoinGame string for you to use to connect</para>
		public static SteamAPICall_t JoinParty(PartyBeaconID_t ulBeaconID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> =============================================================================================</para>
		/// <para> Party Host APIs</para>
		/// <para> Get a list of possible beacon locations</para>
		public static bool GetNumAvailableBeaconLocations(out uint puNumLocations) {
			puNumLocations = (uint) 0;
			return false;
		}

		public static bool GetAvailableBeaconLocations(out SteamPartyBeaconLocation_t pLocationList, uint uMaxNumLocations) {
			pLocationList = new SteamPartyBeaconLocation_t();
			return false;
		}

		/// <para> Create a new party beacon and activate it in the selected location.</para>
		/// <para> unOpenSlots is the maximum number of users that Steam will send to you.</para>
		/// <para> When people begin responding to your beacon, Steam will send you</para>
		/// <para> PartyReservationCallback_t callbacks to let you know who is on the way.</para>
		public static SteamAPICall_t CreateBeacon(uint unOpenSlots, out SteamPartyBeaconLocation_t pBeaconLocation, string pchConnectString, string pchMetadata) {
			pBeaconLocation = new SteamPartyBeaconLocation_t();
			return (SteamAPICall_t) 0;
		}

		/// <para> Call this function when a user that had a reservation (see callback below)</para>
		/// <para> has successfully joined your party.</para>
		/// <para> Steam will manage the remaining open slots automatically.</para>
		public static void OnReservationCompleted(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) {
		}

		/// <para> To cancel a reservation (due to timeout or user input), call this.</para>
		/// <para> Steam will open a new reservation slot.</para>
		/// <para> Note: The user may already be in-flight to your game, so it's possible they will still connect and try to join your party.</para>
		public static void CancelReservation(PartyBeaconID_t ulBeacon, CSteamID steamIDUser) {
		}

		/// <para> Change the number of open beacon reservation slots.</para>
		/// <para> Call this if, for example, someone without a reservation joins your party (eg a friend, or via your own matchmaking system).</para>
		public static SteamAPICall_t ChangeNumOpenSlots(PartyBeaconID_t ulBeacon, uint unOpenSlots) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Turn off the beacon.</para>
		public static bool DestroyBeacon(PartyBeaconID_t ulBeacon) {
			return false;
		}

		/// <para> Utils</para>
		public static bool GetBeaconLocationData(SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, out string pchDataStringOut, int cchDataStringOut) {
			pchDataStringOut = "";
			return false;
		}
	}
}
