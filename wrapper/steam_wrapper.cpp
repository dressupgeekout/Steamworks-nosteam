/*
 * Copyright (c) 2015 CIPRIAN ILIES
 * See LICENSE for details.
 */

#include <string>

#ifdef APPLE
#include <stdlib.h>
#endif

extern "C" int API_Init()
{
	return 0;
}

extern "C" int API_Shutdown()
{
	return 0;
}

extern "C" int C_SteamAPI_Init()
{
	return 0;
}

extern "C" int C_SteamAPI_RunCallbacks()
{
	return 0;
}

extern "C" int C_SteamAPI_Shutdown()
{
	return 0;
}

extern "C" bool c_SteamAPI_Init()
{
	return false;
}

extern "C" void c_SteamAPI_Shutdown()
{
}

extern "C" bool c_SteamAPI_RestartAppIfNecessary(uint32_t unOwnAppID)
{
	return false;
}

/*bool Steamworks_InitCEGLibrary()
{
	//return Steamworks_InitCEGLibrary();
}*/

extern "C" bool c_SteamUser_BLoggedOn()
{
	return false;
}

extern "C" void c_SteamAPI_RunCallbacks()
{
}

extern "C" bool c_SteamGameServer_Init(uint32_t unIP, uint16_t usSteamPort, uint16_t usGamePort, uint16_t usQueryPort, int eServerMode, const char* pchVersionString)
{
	return false;
}

extern "C" void c_SteamGameServer_Shutdown()
{
}

extern "C" void* c_SteamGameServer()
{
	return nullptr;
}

extern "C" void c_SteamGameServer_SetModDir(const char *pszModDir)
{
}

extern "C" void c_SteamGameServer_SetProduct(const char *pszProduct)
{
}

extern "C" void c_SteamGameServer_SetGameDescription(const char *pszGameDescription)
{
}

extern "C" void c_SteamGameServer_LogOnAnonymous()
{
}

extern "C" void c_SteamGameServer_EnableHeartbeats(bool bActive)
{
}

extern "C" void c_SteamGameServer_LogOff()
{
}

extern "C" void c_SteamGameServerNetworking_AcceptP2PSessionWithUser(void* steamIDRemote)
{
}

extern "C" void c_SteamNetworking_AcceptP2PSessionWithUser(void* steamIDRemote)
{
}

extern "C" int c_SteamGameServer_BeginAuthSession(const void *pAuthTicket, int cbAuthTicket, void* steamID)
{
	return 0;
}

extern "C" void c_SteamGameServer_EndAuthSession(void* steamID)
{
}

extern "C" bool c_SteamGameServerNetworking_SendP2PPacket(void* steamIDRemote, const void *pubData, uint32_t cubData, int eP2PSendType, int nChannel)
{
	return false;
}

extern "C" bool c_SteamGameServerNetworking_IsP2PPacketAvailable(uint32_t *pcubMsgSize, int nChannel)
{
	return false;
}

extern "C" bool c_SteamGameServerNetworking_ReadP2PPacket(void *pubDest, uint32_t cubDest, uint32_t *pcubMsgSize, void* psteamIDRemote, int nChannel)
{
	return false;
}

extern "C" uint64_t c_SteamGameServer_GetSteamID_ConvertToUInt64()
{
	return (uint64_t)0;
}

extern "C" bool c_SteamGameServer_BSecure()
{
	return false;
}

extern "C" void c_SteamGameServer_SendUserDisconnect(void* steamIDUser)
{
}

extern "C" void c_SteamGameServer_RunCallbacks()
{
}

extern "C" void c_SteamGameServer_SetMaxPlayerCount(int cPlayersMax)
{
}

extern "C" void c_SteamGameServer_SetPasswordProtected(bool bPasswordProtected)
{
}

extern "C" void c_SteamGameServer_SetServerName(const char *pszServerName)
{
}

extern "C" void c_SteamGameServer_SetBotPlayerCount(int cBotplayers)
{
}

extern "C" void c_SteamGameServer_SetMapName(const char *pszMapName)
{
}

extern "C" bool c_SteamGameServer_BUpdateUserData(void* steamIDUser, const char *pchPlayerName, uint32_t uScore)
{
	return false;
}

extern "C" int64_t c_SteamUtils_GetAppID()
{
	return (int64_t)0;
}

extern "C" bool c_SteamUser()
{
	return false;
}

extern "C" void* c_SteamUser_GetSteamID()
{
	return nullptr;
}

extern "C" void c_Free_CSteamID(void *steamID)
{
}

extern "C" void* c_AllocateNew_CSteamID()
{
	return nullptr;
}

extern "C" bool c_SteamUserStats()
{
	return false;
}

extern "C" bool c_SteamNetworking_SendP2PPacket(void* steamIDRemote, const void *pubData, uint32_t cubData, int eP2PSendType, int nChannel)
{
	return false;
}

extern "C" bool c_SteamNetworking_IsP2PPacketAvailable(uint32_t *pcubMsgSize, int nChannel)
{
	return false;
}

extern "C" bool c_SteamNetworking_ReadP2PPacket(void *pubDest, uint32_t cubDest, uint32_t *pcubMsgSize, void* psteamIDRemote, int nChannel)
{
	return false;
}

extern "C" bool c_SteamUserStats_RequestCurrentStats()
{
	return false;
}

extern "C" bool c_SteamUserStats_SetAchievement(const char *pchName)
{
	return false;
}

extern "C" int c_SteamUserStats_GetAchievementIcon(const char *pchName)
{
	return 0;
}

extern "C" bool c_SteamUserStats_SetStat(const char *pchName, int32_t nData)
{
	return false;
}

extern "C" bool c_SteamUserStats_UpdateAvgRateStat(const char *pchName, float flCountThisSession, double dSessionLength)
{
	return false;
}

extern "C" bool c_SteamUserStats_GetStat_Int(const char *pchName, int32_t *pData)
{
	return false;
}

extern "C" bool c_SteamUserStats_GetStat_Float(const char *pchName, float *pData)
{
	return false;
}

extern "C" bool c_SteamUserStats_StoreStats()
{
	return false;
}

extern "C" const char* c_SteamUserStats_GetAchievementDisplayAttribute(const char *pchName, const char *pchKey)
{
	return "";
}

extern "C" bool c_CSteamID_IsValid(void *CSteamID_instance)
{
	return false;
}

extern "C" int c_SteamMatchmaking_GetNumLobbyMembers(void *steamIDLobby)
{
	return 0;
}

extern "C" void* c_SteamMatchmaking_GetLobbyMemberByIndex(void *steamIDLobby, int iMember)
{
	return nullptr;
}

extern "C" const char* c_SteamFriends_GetPersonaName()
{
	return "";
}

extern "C" const char* c_SteamFriends_GetFriendPersonaName(void *steamIDLobbyMember)
{
	return "";
}

extern "C" const char* c_SteamMatchmaking_GetLobbyMemberData(void *steamIDLobby, void *steamIDUser, const char *pchKey)
{
	return "";
}

extern "C" void* c_SteamMatchmaking_GetLobbyOwner(void *steamIDLobby)
{
	return nullptr;
}

extern "C" bool c_SteamFriends_IsUserInSource(void *steamIDUser, void *steamIDSource)
{
	return false;
}

extern "C" void* c_SteamMatchmaking_GetLobbyByIndex(int iLobby)
{
	return nullptr;
}

extern "C" bool c_SteamMatchmaking_RequestLobbyData(void *steamIDLobby)
{
	return false;
}

//steamIDLobby.GetAccountID()
extern "C" int c_CSteamID_GetAccountID(void *CSteamID_instance)
{
	return 0;
}

extern "C" bool c_SteamUtils_IsAPICallCompleted(unsigned long hSteamAPICall, bool *pbFailed)
{
	return false;
}

extern "C" bool c_SteamUtils_GetAPICallResult(int hSteamAPICall, void* pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed)
{
	return false;
}

extern "C" uint32_t c_LobbyMatchList_t_m_nLobbiesMatching(void *LobbyMatchList_t_instance)
{
	return (uint32_t)0;
}

extern "C" void c_SteamMatchmaking_AddRequestLobbyListStringFilter(const char *pchKeyToMatch, const char *pchValueToMatch, int eComparisonType)
{
}

extern "C" void c_SteamMatchmaking_AddRequestLobbyListNumericalFilter(const char *pchKeyToMatch, int nValueToMatch, int eComparisonType)
{
}

extern "C" void c_SteamMatchmaking_AddRequestLobbyListNearValueFilter(const char *pchKeyToMatch, int nValueToBeCloseTo)
{
}

extern "C" void c_SteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable)
{
}

extern "C" bool c_SteamMatchmaking_SetLobbyData(void *steamIDLobby, const char *pchKey, const char *pchValue)
{
	return false;
}

extern "C" bool c_SteamMatchmaking_SetLobbyType(void *steamIDLobby, int eLobbyType)
{
	return false;
}

extern "C" bool c_SteamMatchmaking_DeleteLobbyData(void *steamIDLobby, const char *pchKey)
{
	return false;
}

extern "C" int c_SteamMatchmaking_GetLobbyDataCount(void *steamIDLobby)
{
	return 0;
}

extern "C" bool c_SteamMatchmaking_GetLobbyDataByIndex(void *steamIDLobby, int iLobbyData, char *pchKey, int cchKeyBufferSize, char *pchValue, int cchValueBufferSize)
{
	return false;
}

extern "C" const char* c_SteamMatchmaking_GetLobbyData(void *steamIDLobby, const char *pchKey)
{
	return "";
}

extern "C" bool c_SteamMatchmaking_SendLobbyChatMsg(void *steamIDLobby, const void *pvMsgBody, int cubMsgBody)
{
	return false;
}

extern "C" int c_SteamMatchmaking_GetLobbyChatEntry(void *steamIDLobby, int iChatID, void *pSteamIDUser, void *pvData, int cubData, int *peChatEntryType)
{
	return 0;
}

extern "C" bool c_SteamFriends_SetRichPresence(const char *pchKey, const char *pchValue)
{
	return false;
}

extern "C" int c_SteamFriends_GetFriendCount(int iFriendFlags)
{
	return 0;
}

extern "C" bool c_SteamMatchmaking_InviteUserToLobby(void *steamIDLobby, void *steamIDInvitee)
{
	return false;
}

extern "C" void c_SteamFriends_ActivateGameOverlay(const char *pchDialog)
{
}

extern "C" void c_SteamMatchmaking_LeaveLobby(void *steamIDLobby)
{
}

extern "C" bool c_SteamFriends_GetFriendGamePlayed(void *steamIDFriend, void *pFriendGameInfo)
{
	return false;
}

extern "C" void* c_FriendGameInfo_t_m_steamIDLobby(void *FriendGameInfo_t_instance)
{
	return nullptr;
}

extern "C" void* c_P2PSessionRequest_t_m_steamIDRemote(void *P2PSessionRequest_t_instance)
{
	return nullptr;
}

extern "C" int c_LobbyCreated_Result(void *pCallback)
{
	return 0;
}

extern "C" void* c_LobbyCreated_Lobby(void *pCallback)
{
	return nullptr;
}

extern "C" void *c_GameJoinRequested_m_steamIDLobby(void *pCallback)
{
	return nullptr;
}

//class SteamServerWrapper
//{
//public:
	//SteamServerWrapper()
	//:
	//m_CallbackSteamServersConnected(this, &SteamServerWrapper::OnSteamServersConnected),
	//m_CallbackSteamServersDisconnected(this, &SteamServerWrapper::OnSteamServersDisconnected),
	//m_CallbackSteamServersConnectFailure( this, &SteamServerWrapper::OnSteamServersConnectFailure ),
	//m_CallbackPolicyResponse(this, &SteamServerWrapper::OnPolicyResponse),
	//m_CallbackGSAuthTicketResponse(this, &SteamServerWrapper::OnValidateAuthTicketResponse),
	//m_CallbackP2PSessionRequest(this, &SteamServerWrapper::OnP2PSessionRequest),
	//m_CallbackP2PSessionConnectFail(this, &SteamServerWrapper::OnP2PSessionConnectFail)
	//{
		//c_SteamServerWrapper_OnSteamServersConnected = nullptr;
		//c_SteamServerWrapper_OnSteamServersDisconnected = nullptr;
		//c_SteamServerWrapper_OnSteamServersConnectFailure = nullptr;
		//c_SteamServerWrapper_OnP2PSessionRequest = nullptr;
		//c_SteamServerWrapper_OnP2PSessionConnectFail = nullptr;
		//c_SteamServerWrapper_OnPolicyResponse = nullptr;
		//c_SteamServerWrapper_OnValidateAuthTicketResponse = nullptr;
	//}

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnSteamServersConnected, SteamServersConnected_t, m_CallbackSteamServersConnected);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnSteamServersDisconnected, SteamServersDisconnected_t, m_CallbackSteamServersDisconnected);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnSteamServersConnectFailure, SteamServerConnectFailure_t, m_CallbackSteamServersConnectFailure);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnPolicyResponse, GSPolicyResponse_t, m_CallbackPolicyResponse);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnValidateAuthTicketResponse, ValidateAuthTicketResponse_t, m_CallbackGSAuthTicketResponse);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnP2PSessionRequest, P2PSessionRequest_t, m_CallbackP2PSessionRequest);

	//STEAM_GAMESERVER_CALLBACK(SteamServerWrapper, OnP2PSessionConnectFail, P2PSessionConnectFail_t, m_CallbackP2PSessionConnectFail);
//} *steam_server_wrapper;

//void SteamServerWrapper::OnSteamServersConnected(int *pLogonSuccess)
//{
	//if (c_SteamServerWrapper_OnSteamServersConnected)
		//(*c_SteamServerWrapper_OnSteamServersConnected)(pLogonSuccess);
//}

//void SteamServerWrapper::OnSteamServersDisconnected(int *pLoggedOff)
//{
	//if (c_SteamServerWrapper_OnSteamServersDisconnected)
		//(*c_SteamServerWrapper_OnSteamServersDisconnected)(pLoggedOff);
//}

//void SteamServerWrapper::OnSteamServersConnectFailure(int *pConnectFailure)
//{
	//if (c_SteamServerWrapper_OnSteamServersConnectFailure)
	//{
		//(*c_SteamServerWrapper_OnSteamServersConnectFailure)(pConnectFailure);
	//}
//}

//void SteamServerWrapper::OnPolicyResponse(int *pPolicyResponse)
//{
	//if (c_SteamServerWrapper_OnPolicyResponse)
		//(*c_SteamServerWrapper_OnPolicyResponse)(pPolicyResponse);
//}

//void SteamServerWrapper::OnValidateAuthTicketResponse(int *pResponse)
//{
	//if (c_SteamServerWrapper_OnValidateAuthTicketResponse)
		//(*c_SteamServerWrapper_OnValidateAuthTicketResponse)(pResponse);
//}

//void SteamServerWrapper::OnP2PSessionRequest(int *pCallback)
//{
	//if (c_SteamServerWrapper_OnP2PSessionRequest)
		//(*c_SteamServerWrapper_OnP2PSessionRequest)(pCallback);
//}

//void SteamServerWrapper::OnP2PSessionConnectFail(int *pCallback)
//{
	//if (c_SteamServerWrapper_OnP2PSessionConnectFail)
		//(*c_SteamServerWrapper_OnP2PSessionConnectFail)(pCallback);
//}

//extern "C" void c_SteamServerWrapper_Instantiate()
//{
	//steam_server_wrapper = new SteamServerWrapper();
//}

//extern "C" void c_SteamServerWrapper_Destroy()
//{
	//delete steam_server_wrapper;
	//steam_server_wrapper = nullptr;
//}

//extern "C" void* c_P2PSessionConnectFail_t_m_steamIDRemote(void *P2PSessionConnectFail_t_instance)
//{
	//CSteamID *id = new CSteamID;
	//*id = static_cast<P2PSessionConnectFail_t*>(P2PSessionConnectFail_t_instance)->m_steamIDRemote;
	//return id;
	//return nullptr;
//}

extern "C" int c_ValidateAuthTicketResponse_t_EAuthSessionResponse(void *ValidateAuthTicketResponse_t_instance)
{
	return 0;
}

extern "C" void* c_ValidateAuthTicketResponse_t_m_SteamID(void *ValidateAuthTicketResponse_t_instance)
{
	return nullptr;
}

//class SteamServerClientWrapper
//{
//public:
	//SteamServerClientWrapper()
	//:
	//m_LobbyGameCreated(this, &SteamServerClientWrapper::OnLobbyGameCreated),
	//m_GameJoinRequested(this, &SteamServerClientWrapper::OnGameJoinRequested),
	//m_AvatarImageLoadedCreated(this, &SteamServerClientWrapper::OnAvatarImageLoaded),
	//m_SteamServersConnected(this, &SteamServerClientWrapper::OnSteamServersConnected),
	//m_SteamServersDisconnected(this, &SteamServerClientWrapper::OnSteamServersDisconnected),
	//m_SteamServerConnectFailure(this, &SteamServerClientWrapper::OnSteamServerConnectFailure),
	//m_CallbackGameOverlayActivated(this, &SteamServerClientWrapper::OnGameOverlayActivated),
	//m_CallbackGameWebCallback( this, &SteamServerClientWrapper::OnGameWebCallback),
	//m_CallbackWorkshopItemInstalled(this, &SteamServerClientWrapper::OnWorkshopItemInstalled),
	//m_CallbackP2PSessionConnectFail(this, &SteamServerClientWrapper::OnP2PSessionConnectFail),
	//m_CallbackP2PSessionRequest(this, &SteamServerClientWrapper::OnP2PSessionRequest),
	//m_CallbackLobbyDataUpdate(this, &SteamServerClientWrapper::OnLobbyDataUpdate),
	//m_IPCFailureCallback(this, &SteamServerClientWrapper::OnIPCFailure),
	//m_SteamShutdownCallback(this, &SteamServerClientWrapper::OnSteamShutdown)
	//{
		//c_SteamServerClientWrapper_OnLobbyGameCreated = nullptr;
		//c_SteamServerClientWrapper_OnGameJoinRequested = nullptr;
		//c_SteamServerClientWrapper_OnAvatarImageLoaded = nullptr;
		//c_SteamServerClientWrapper_OnSteamServersConnected = nullptr;
		//c_SteamServerClientWrapper_OnSteamServersDisconnected = nullptr;
		//c_SteamServerClientWrapper_OnSteamServerConnectFailure = nullptr;
		//c_SteamServerClientWrapper_OnGameOverlayActivated = nullptr;
		//c_SteamServerClientWrapper_OnGameWebCallback = nullptr;
		//c_SteamServerClientWrapper_OnWorkshopItemInstalled = nullptr;
		//c_SteamServerClientWrapper_OnP2PSessionConnectFail = nullptr;
		//c_SteamServerClientWrapper_OnP2PSessionRequest = nullptr;
		//c_SteamServerClientWrapper_OnIPCFailure = nullptr;
		//c_SteamServerClientWrapper_OnSteamShutdown = nullptr;
		//c_SteamServerClientWrapper_OnLobbyDataUpdate = nullptr;
	//}

	//STEAM_CALLBACK(SteamServerClientWrapper, OnLobbyDataUpdate, LobbyDataUpdate_t, m_CallbackLobbyDataUpdate);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnLobbyGameCreated, LobbyGameCreated_t, m_LobbyGameCreated);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnGameJoinRequested, GameLobbyJoinRequested_t, m_GameJoinRequested);

	//STEAM_CALLBACK( CSpaceWarClient, OnAvatarImageLoaded, AvatarImageLoaded_t, m_AvatarImageLoadedCreated );
	//STEAM_CALLBACK(SteamServerClientWrapper, OnAvatarImageLoaded, AvatarImageLoaded_t, m_AvatarImageLoadedCreated); //TODO: Finish.

	//STEAM_CALLBACK(SteamServerClientWrapper, OnSteamServersConnected, SteamServersConnected_t, m_SteamServersConnected);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnSteamServersDisconnected, SteamServersDisconnected_t, m_SteamServersDisconnected);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnSteamServerConnectFailure, SteamServerConnectFailure_t, m_SteamServerConnectFailure);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnGameOverlayActivated, GameOverlayActivated_t, m_CallbackGameOverlayActivated);

	//STEAM_CALLBACK( CSpaceWarClient, OnGameWebCallback, GameWebCallback_t, m_CallbackGameWebCallback );
	//STEAM_CALLBACK(SteamServerClientWrapper, OnGameWebCallback, GameWebCallback_t, m_CallbackGameWebCallback); //TODO: Finish.

	//STEAM_CALLBACK(CSpaceWarClient, OnWorkshopItemInstalled, ItemInstalled_t, m_CallbackWorkshopItemInstalled);
	//STEAM_CALLBACK(SteamServerClientWrapper, OnWorkshopItemInstalled, ItemInstalled_t, m_CallbackWorkshopItemInstalled); //TODO: Finish.

	//STEAM_CALLBACK(SteamServerClientWrapper, OnP2PSessionConnectFail, P2PSessionConnectFail_t, m_CallbackP2PSessionConnectFail);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnIPCFailure, IPCFailure_t, m_IPCFailureCallback);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnSteamShutdown, SteamShutdown_t, m_SteamShutdownCallback);

	//STEAM_CALLBACK(SteamServerClientWrapper, OnP2PSessionRequest, P2PSessionRequest_t, m_CallbackP2PSessionRequest);

	//void OnLobbyCreated(LobbyCreated_t *pCallback, bool bIOFailure);
	//CCallResult<SteamServerClientWrapper, LobbyCreated_t> m_SteamCallResultLobbyCreated;
	//void m_SteamCallResultLobbyCreated_Set(SteamAPICall_t hSteamAPICall);

	//void OnLobbyEntered( LobbyEnter_t *pCallback, bool bIOFailure );
	//CCallResult<SteamServerClientWrapper, LobbyEnter_t> m_SteamCallResultLobbyEntered; //Why isn't this set in the example?
	//void m_SteamCallResultLobbyEntered_Set(SteamAPICall_t hSteamAPICall);
	
	//void OnLobbyMatchListCallback( LobbyMatchList_t *pCallback, bool bIOFailure );
	//CCallResult<SteamServerClientWrapper, LobbyMatchList_t> m_SteamCallResultLobbyMatchList;
	//void m_SteamCallResultLobbyMatchList_Set(SteamAPICall_t hSteamAPICall);

	// Called when SteamUser()->RequestEncryptedAppTicket() returns asynchronously
	//void OnRequestEncryptedAppTicket( EncryptedAppTicketResponse_t *pEncryptedAppTicketResponse, bool bIOFailure );
	//CCallResult<SteamServerClientWrapper, EncryptedAppTicketResponse_t> m_SteamCallResultEncryptedAppTicket;
	//void m_SteamCallResultEncryptedAppTicket_Set(SteamAPICall_t hSteamAPICall);
	//void RetrieveSteamIDFromGameServer( uint32_t m_unServerIP, uint16_t m_usServerPort );

//private:
	// simple class to marshal callbacks from pinging a game server
	//class CGameServerPing : public ISteamMatchmakingPingResponse
	//{
	//public:
		//CGameServerPing()
		//{
			//m_hGameServerQuery = HSERVERQUERY_INVALID;
			//m_pClient = NULL;
		//}

		//void RetrieveSteamIDFromGameServer( SteamServerClientWrapper *pClient, uint32_t unIP, uint16_t unPort )
		//{
			//m_pClient = pClient;
			//m_hGameServerQuery = SteamMatchmakingServers()->PingServer( unIP, unPort, this );
		//}

		//void CancelPing()
		//{
			//m_hGameServerQuery = HSERVERQUERY_INVALID;
		//}

		// Server has responded successfully and has updated data
		//virtual void ServerResponded( gameserveritem_t &server )
		//{
			//if ( m_hGameServerQuery != HSERVERQUERY_INVALID && server.m_steamID.IsValid() )
			//{
				//(*c_SteamServerClientWrapper_GameServerPingOnServerResponded)( static_cast<void *>(&server.m_steamID) );
			//}

			//m_hGameServerQuery = HSERVERQUERY_INVALID;
		//}

		// Server failed to respond to the ping request
		//virtual void ServerFailedToRespond()
		//{
			//m_hGameServerQuery = HSERVERQUERY_INVALID;
		//}

	//private:
		//HServerQuery m_hGameServerQuery;	// we're pinging a game server so we can convert IP:Port to a steamID
		//SteamServerClientWrapper *m_pClient;
	//};
	//CGameServerPing m_GameServerPing;
//} *steam_server_client_wrapper;

//void SteamServerClientWrapper::OnLobbyDataUpdate(int *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnLobbyDataUpdate)
		//(*c_SteamServerClientWrapper_OnLobbyDataUpdate)(pCallback);
//}

//void SteamServerClientWrapper::OnP2PSessionRequest(P2PSessionRequest_t *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnP2PSessionRequest)
		//(*c_SteamServerClientWrapper_OnP2PSessionRequest)(pCallback);
//}

extern "C" int c_SteamMatchmaking_JoinLobby(void *steamIDLobby)
{
	return 0;
}

extern "C" int c_SteamMatchmaking_RequestLobbyList()
{
	return 0;
}

extern "C" int c_SteamMatchmaking_CreateLobby(int eLobbyType, int cMaxMembers)
{
	return 0;
}

extern "C" void c_RetrieveSteamIDFromGameServer( uint32_t m_unServerIP, uint16_t m_usServerPort )
{
}

//void SteamServerClientWrapper::RetrieveSteamIDFromGameServer( uint32_t m_unServerIP, uint16_t m_usServerPort )
//{
	//m_GameServerPing.RetrieveSteamIDFromGameServer( this, m_unServerIP, m_usServerPort );
//}

//void SteamServerClientWrapper::OnLobbyGameCreated(LobbyGameCreated_t *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnLobbyGameCreated)
		//(*c_SteamServerClientWrapper_OnLobbyGameCreated)(pCallback);
//}

//void SteamServerClientWrapper::OnGameJoinRequested(GameLobbyJoinRequested_t *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnGameJoinRequested)
		//(*c_SteamServerClientWrapper_OnGameJoinRequested)(pCallback);
//}

//void SteamServerClientWrapper::OnAvatarImageLoaded(AvatarImageLoaded_t *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnAvatarImageLoaded)
		//(*c_SteamServerClientWrapper_OnAvatarImageLoaded)(pCallback);
//}

//void SteamServerClientWrapper::OnSteamServersConnected(SteamServersConnected_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnSteamServersConnected)
		//(*c_SteamServerClientWrapper_OnSteamServersConnected)(callback);
//}

//void SteamServerClientWrapper::OnSteamServersDisconnected(SteamServersDisconnected_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnSteamServersDisconnected)
		//(*c_SteamServerClientWrapper_OnSteamServersDisconnected)(callback);
//}

//void SteamServerClientWrapper::OnSteamServerConnectFailure(SteamServerConnectFailure_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnSteamServerConnectFailure)
		//(*c_SteamServerClientWrapper_OnSteamServerConnectFailure)(callback);
//}

//void SteamServerClientWrapper::OnGameOverlayActivated(GameOverlayActivated_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnGameOverlayActivated)
		//(*c_SteamServerClientWrapper_OnGameOverlayActivated)(callback);
//}

//void SteamServerClientWrapper::OnGameWebCallback(GameWebCallback_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnGameWebCallback)
		//(*c_SteamServerClientWrapper_OnGameWebCallback)(callback);
//}

//void SteamServerClientWrapper::OnWorkshopItemInstalled(ItemInstalled_t *pParam)
//{
	//if (c_SteamServerClientWrapper_OnWorkshopItemInstalled)
		//(c_SteamServerClientWrapper_OnWorkshopItemInstalled)(pParam);
//}

//void SteamServerClientWrapper::OnP2PSessionConnectFail(P2PSessionConnectFail_t *pCallback)
//{
	//if (c_SteamServerClientWrapper_OnP2PSessionConnectFail)
		//(*c_SteamServerClientWrapper_OnP2PSessionConnectFail)(pCallback);
//}

//void SteamServerClientWrapper::OnIPCFailure(IPCFailure_t *failure)
//{
	//if (c_SteamServerClientWrapper_OnIPCFailure)
		//(*c_SteamServerClientWrapper_OnIPCFailure)(failure);
//}

//void SteamServerClientWrapper::OnSteamShutdown(SteamShutdown_t *callback)
//{
	//if (c_SteamServerClientWrapper_OnSteamShutdown)
		//(*c_SteamServerClientWrapper_OnSteamShutdown)(callback);
//}

//void SteamServerClientWrapper::OnLobbyCreated(LobbyCreated_t *pCallback, bool bIOFailure)
//{
	//if (c_SteamServerClientWrapper_OnLobbyCreated)
		//(*c_SteamServerClientWrapper_OnLobbyCreated)(pCallback, bIOFailure);
//}

//void SteamServerClientWrapper::m_SteamCallResultLobbyCreated_Set(SteamAPICall_t hSteamAPICall)
//{
	//m_SteamCallResultLobbyCreated.Set(hSteamAPICall, this, &SteamServerClientWrapper::OnLobbyCreated);
//}

//void SteamServerClientWrapper::OnLobbyMatchListCallback(LobbyMatchList_t *pCallback, bool bIOFailure)
//{
	//if (c_SteamServerClientWrapper_OnLobbyMatchListCallback)
		//(*c_SteamServerClientWrapper_OnLobbyMatchListCallback)(pCallback, bIOFailure);
//}

//void SteamServerClientWrapper::m_SteamCallResultLobbyMatchList_Set(SteamAPICall_t hSteamAPICall)
//{
	//m_SteamCallResultLobbyMatchList.Set( hSteamAPICall, this, &SteamServerClientWrapper::OnLobbyMatchListCallback );
//}

//void SteamServerClientWrapper::OnLobbyEntered(LobbyEnter_t *pCallback, bool bIOFailure)
//{
	//if (c_SteamServerClientWrapper_OnLobbyEntered)
		//(*c_SteamServerClientWrapper_OnLobbyEntered)(pCallback, bIOFailure);
//}

//void SteamServerClientWrapper::m_SteamCallResultLobbyEntered_Set(SteamAPICall_t hSteamAPICall)
//{
	//m_SteamCallResultLobbyEntered.Set(hSteamAPICall, this, &SteamServerClientWrapper::OnLobbyEntered);
//}

//void SteamServerClientWrapper::OnRequestEncryptedAppTicket(EncryptedAppTicketResponse_t *pEncryptedAppTicketResponse, bool bIOFailure)
//{
	//if (c_SteamServerClientWrapper_OnRequestEncryptedAppTicket)
		//(*c_SteamServerClientWrapper_OnRequestEncryptedAppTicket)(pEncryptedAppTicketResponse, bIOFailure);
//}

//void SteamServerClientWrapper::m_SteamCallResultEncryptedAppTicket_Set(SteamAPICall_t hSteamAPICall)
//{
	//m_SteamCallResultEncryptedAppTicket.Set(hSteamAPICall, this, &SteamServerClientWrapper::OnRequestEncryptedAppTicket);
//}

extern "C" void c_SteamServerClientWrapper_Instantiate()
{
}

extern "C" void c_SteamServerClientWrapper_Destroy()
{
}

extern "C" uint64_t c_LobbyGameCreated_t_m_ulSteamIDGameServer(void *LobbyGameCreated_t_instance)
{
	return (uint64_t)0;
}

extern "C" void c_SteamFriends_ActivateGameOverlayInviteDialog(void *steamIDLobby)
{
}

extern "C" uint8_t c_GameOverlayActivated_t_m_bActive(void *GameOverlayActivated_t_instance)
{
	return (uint8_t)0;
}

extern "C" uint32_t pCallback_m_nLobbiesMatching(void *pCallback)
{
	return (uint32_t)0;
}

extern "C" void c_SteamMatchmaking_JoinLobbyPCH(const char *pchLobbyID, void *onLobbyEnteredFunc)
{
}

extern "C" uint32_t c_pCallback_m_EChatRoomEnterResponse( void *pCallback )
{
	return (uint32_t)0;
}

extern "C" void *c_pCallback_m_ulSteamIDLobby( void *pCallback )
{
	return nullptr;
}

extern "C" uint64_t c_CSteamID_ConvertToUint64( void *steamID )
{
	return (uint64_t)0;
}

extern "C" void *LobbyDataUpdated_pCallback_m_ulSteamIDLobby(void *pCallback)
{
	return nullptr;
}
