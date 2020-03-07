#include "steamwrap.h"

/*
static void GlobalEvent( int id, vdynamic *v );

class GameServerHandler {
	std::map<std::string, void*> m;
public:
	GameServerHandler() :
#	define EVENT_DECL(name,type) m_##name(this,&GameServerHandler::On##name),
#	include "serverevents.h"
		m()
	{}

#	define EVENT_DECL(name,type) vdynamic *Encode##name( type *t );
#	include "serverevents.h"

#	undef EVENT_IMPL
#	define EVENT_IMPL(name,type) vdynamic *GameServerHandler::Encode##name( type *d )
};

#define EVENT_DECL(name,type) void GameServerHandler::On##name( type *t ) { }
#include "serverevents.h"

EVENT_IMPL(ServerConnectFailure, int) {
	printf("%s\n", __func__);
	return nullptr;
}

EVENT_IMPL(ServersConnected, int) {
	printf("%s\n", __func__);
	return NULL;
}

EVENT_IMPL(ServersDisconnected, int) {
	printf("%s\n", __func__);
	return nullptr;
}

EVENT_IMPL(P2PSessionRequest, int) {
	printf("%s\n", __func__);
	return nullptr;
}

EVENT_IMPL(P2PSessionConnectFail, int) {
	printf("%s\n", __func__);
	return nullptr;
}

EVENT_IMPL(PolicyResponse, int) {
	printf("%s\n", __func__);
	return nullptr;
}

EVENT_IMPL(ValidateAuthTicketResponse, int ) {
	printf("%s\n", __func__);
	return nullptr;
}
*/

static vclosure *globalEvent = NULL;

static void GlobalEvent( int id, vdynamic *v ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(gameserver_setup)( vclosure *onGlobalEvent ){
	printf("%s\n", __func__);
}

bool HL_NAME(gameserver_init)( int ip, int port, int gameport, int queryport, int serverMode, char *version ) {
	printf("%s\n", __func__);
	return false;
}

void HL_NAME(gameserver_runcallbacks)() {
	printf("%s\n", __func__);
}

void HL_NAME(gameserver_shutdown)() {
	printf("%s\n", __func__);
}

void HL_NAME(gameserver_logon_anonymous)() {
	printf("%s\n", __func__);
}

void HL_NAME(gameserver_enable_heartbeats)( bool b ) {
	printf("%s\n", __func__);
}

void HL_NAME(gameserver_config)( char *modDir, char *product, char *desc ) {
	printf("%s\n", __func__);
}

void HL_NAME(gameserver_info)( int maxPlayers, bool password, char *serverName, int botCount, char *mapName ) {
	printf("%s\n", __func__);
}

vuid HL_NAME(gameserver_get_steam_id)() {
	printf("%s\n", __func__);
	return (vuid)0;
}

int HL_NAME(gameserver_get_public_ip)() {
	printf("%s\n", __func__);
	return 0;
}

DEFINE_PRIM(_BOOL, gameserver_init, _I32 _I32 _I32 _I32 _I32 _BYTES);
DEFINE_PRIM(_VOID, gameserver_setup, _FUN(_VOID, _I32 _DYN));
DEFINE_PRIM(_VOID, gameserver_runcallbacks, _NO_ARG);
DEFINE_PRIM(_VOID, gameserver_shutdown, _NO_ARG);
DEFINE_PRIM(_VOID, gameserver_logon_anonymous, _NO_ARG);
DEFINE_PRIM(_VOID, gameserver_enable_heartbeats, _BOOL);
DEFINE_PRIM(_VOID, gameserver_config, _BYTES _BYTES _BYTES);
DEFINE_PRIM(_VOID, gameserver_info, _I32 _BOOL _BYTES _I32 _BYTES);
DEFINE_PRIM(_UID, gameserver_get_steam_id, _NO_ARG);
DEFINE_PRIM(_I32, gameserver_get_public_ip, _NO_ARG);

// --------- list --------------------------

/*
class HLServerResponse : public ISteamMatchmakingServerListResponse {
public:

	vclosure *callb;

	HLServerResponse( vclosure *callb ) {
		this->callb = callb;
		hl_add_root(&this->callb);
	}

	~HLServerResponse() {
		hl_remove_root(&this->callb);
	}

	void ServerResponded( HServerListRequest hRequest, int iServer ) {
		saveServer(hRequest,iServer);
	}

	void ServerFailedToRespond( HServerListRequest hRequest, int iServer ) {
		saveServer(hRequest,iServer);
	}

	void saveServer( HServerListRequest hRequest, int iServer ) {
		gameserveritem_t *details = SteamMatchmakingServers()->GetServerDetails(hRequest,iServer);
		HLValue v;
		v.Set("ip", details->m_NetAdr.GetIP());
		v.Set("port", details->m_NetAdr.GetQueryPort());
		v.Set("ping", details->m_bHadSuccessfulResponse ? details->m_nPing : -1);
		v.Set("id", details->m_steamID);
		hl_dyn_call(callb, &v.value, 1);
	}

	void RefreshComplete( HServerListRequest hRequest, EMatchMakingServerResponse response ) {
		vdynamic *arg = NULL;
		hl_dyn_call(callb, &arg, 1);
		delete this;
	}
};
*/

HL_PRIM void HL_NAME(request_internet_server_list)( int appId, varray *filters, vclosure *callb ) {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_VOID, request_internet_server_list, _I32 _ARR _FUN(_VOID, _DYN));

// ---------
