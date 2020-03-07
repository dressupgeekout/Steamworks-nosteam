int CommunityExpressNS_CommunityExpress_Initialize() { return 0; }
int SteamUnityAPI_Init() { return 1; }
int SteamUnityAPI_RestartAppIfNecessary() { return 0; }
int SteamUnityAPI_Shutdown() { return 0; }
int SteamUnityAPI_SteamFriends() { return 0; }
int SteamUnityAPI_SteamRemoteStorage() { return 0; }
int SteamUnityAPI_SteamRemoteStorage_EnumeratePublishedWorkshopFiles() { return 0; }
int SteamUnityAPI_SteamMatchmaking() { return 0; }
int SteamUnityAPI_SteamMatchmakingServers() { return 0; }
int SteamUnityAPI_SteamNetworking() { return 0; }
int SteamUnityAPI_SteamNetworking_AllowP2PPacketRelay() { return 0; }
int SteamUnityAPI_SteamNetworking_IsP2PPacketAvailable() { return 0; }
int SteamUnityAPI_RunCallbacks() { return 0; }
int SteamUnityAPI_SteamGameServer_RunCallbacks() { return 0; }
int SteamUnityAPI_SteamUtils_GetAppID() { return 0; }
int SteamUnityAPI_SteamUtils_GetLobbyEnteredResult(void *a, int b, int c)
{
	b = 0;
	c = 0;
	return 0;
}
int SteamUnityAPI_IsSteamRunning() { return 1; }
int SteamUnityAPI_SteamUtils_IsAPICallCompleted(int a, int b)
{
	b = 0;
	return 0;
}
int SteamUnityAPI_SetWarningMessageHook() { return 0; }
int SteamUnityAPI_SteamUser() { return 0; }
int SteamUnityAPI_SteamUser_GetSteamID(void *a) { return 0; }
int SteamUnityAPI_SteamFriends_ActivateGameOverlayToWebPage() { return 0; }
int SteamUnityAPI_GetPersonaNameByID(int a) { return 0; }
int SteamUnityAPI_SteamUserStats() { return 0; }
int SteamUnityAPI_SteamUserStats_RequestCurrentStats() { return 0; }
int SteamUnityAPI_SteamUtils_GetServerRealTime() { return 0; }
int SteamUnityAPI_SteamUserStats_FindOrCreateLeaderboard() { return 0; }
