#include "steamwrap.h"

void hl_set_uid( vdynamic *out, int64 uid ) {
	printf("%s\n", __func__);
}

int hl_to_uid( vuid v ) {
	printf("%s\n", __func__);
	return 0;
}

uint64 hl_to_uint64(vuid v) {
	printf("%s\n", __func__);
	return 0;
}

vuid hl_of_uid( My_CSteamID uid ) {
	printf("%s\n", __func__);
	union {
		vbyte b[8];
		uint64 v;
	} data;
	//data.v = (uint64)uid;
	//return (vuid)0;
	data.v = (uint64)0x2;
	return (vuid)hl_copy_bytes(data.b, 8);
}

vuid hl_of_uint64(uint64 uid) {
	printf("%s\n", __func__);
	union {
		vbyte b[8];
		uint64 v;
	} data;
	//data.v = uid;
	return (vuid)0;
}

void dyn_call_result( vclosure *c, vdynamic *p, bool error ) {
	printf("%s\n", __func__);
}

//just splits a string
void split(const std::string &s, char delim, std::vector<std::string> &elems) {
	printf("%s\n", __func__);
	std::stringstream ss;
	ss.str(s);
	std::string item;
	while (std::getline(ss, item, delim)) {
		elems.push_back(item);
	}
}


//-----------------------------------------------------------------------------------------------------------
// Event
//-----------------------------------------------------------------------------------------------------------

vclosure *g_eventHandler = 0;

void SendEvent(event_type type, bool success, const char *data) {
	printf("%s\n", __func__);
}


CallbackHandler* s_callbackHandler = NULL;
static vclosure *s_globalEvent = NULL;

bool CheckInit(){
	printf("%s\n", __func__);
	return 0;
}

static void GlobalEvent( int id, vdynamic *v ) {
	printf("%s\n", __func__);
}

#define EVENT_DECL(name,type) void CallbackHandler::On##name( type *t ) { GlobalEvent(type::k_iCallback, Encode##name(t)); }
#define GLOBAL_EVENTS
//#include "events.h"
#undef GLOBAL_EVENTS

HL_PRIM bool HL_NAME(init)( vclosure *onEvent, vclosure *onGlobalEvent ){
	printf("%s\n", __func__);
	/* change return value to 1 if wanting to try enable Steam functions like GameNetworkingSockets */
	/* this needs to return 1 to allow running Evoland Legendary Edition */
	return 1;
}

HL_PRIM void HL_NAME(set_notification_position)( int pos ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(shutdown)(){
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(run_callbacks)(){
	//printf("%s\n", __func__); // silenced because it's called too often
}

HL_PRIM bool HL_NAME(open_overlay)(vbyte *url){
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	return true;
}

DEFINE_PRIM(_BOOL, init, _FUN(_VOID, _I32 _BOOL _BYTES) _FUN(_VOID, _I32 _DYN));
DEFINE_PRIM(_VOID, set_notification_position, _I32);
DEFINE_PRIM(_VOID, shutdown, _NO_ARG);
DEFINE_PRIM(_VOID, run_callbacks, _NO_ARG);
DEFINE_PRIM(_BOOL, open_overlay, _BYTES);

//-----------------------------------------------------------------------------------------------------------

HL_PRIM vuid HL_NAME(get_steam_id)(){
	printf("%s\n", __func__);
	My_CSteamID test;
	return hl_of_uid(test);
}

HL_PRIM bool HL_NAME(restart_app_if_necessary)(int appId){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(is_overlay_enabled)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(boverlay_needs_present)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(is_steam_in_big_picture_mode)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(is_steam_running)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(delete_item)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(get_app_dependencies)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(is_subscribed_from_family_sharing)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(remove_app_dependency)(){
	printf("%s\n", __func__);
	return false;
}

HL_PRIM vbyte *HL_NAME(get_current_game_language)(){
	printf("%s\n", __func__);
	if (!CheckInit()) return NULL;
	return (vbyte*)0;
}

HL_PRIM bool HL_NAME(is_dlc_installed)( int appid ) {
	printf("%s\n", __func__);
	return 0;
}

HL_PRIM vbyte *HL_NAME(get_current_beta_name)() {
	printf("%s\n", __func__);
	static char name[1024];
	if (!CheckInit()) return NULL;
	return NULL;
}

/*
vdynamic *CallbackHandler::EncodeAuthSessionTicketResponse(int *d) {
	HLValue ret;
	//ret.Set("authTicket", d->m_hAuthTicket);
	//ret.Set("result", d->m_eResult);
	return ret.value;
}
*/


HL_PRIM vbyte *HL_NAME(get_auth_ticket)( int *size, int *authTicket ) {
	printf("%s\n", __func__);
	vbyte *ticket = hl_alloc_bytes(1024);
	//*authTicket = SteamUser()->GetAuthSessionTicket(ticket,1024,(uint32*)size);
	return (vbyte*)"";
}

HL_PRIM void HL_NAME(cancel_call_result)( int *m_call ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(add_app_dependency)() {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_UID, get_steam_id, _NO_ARG);
DEFINE_PRIM(_BOOL, restart_app_if_necessary, _I32);
DEFINE_PRIM(_BOOL, is_overlay_enabled, _NO_ARG);
DEFINE_PRIM(_BOOL, is_dlc_installed, _I32);
DEFINE_PRIM(_BOOL, boverlay_needs_present, _NO_ARG);
DEFINE_PRIM(_BOOL, is_steam_in_big_picture_mode, _NO_ARG);
DEFINE_PRIM(_BOOL, is_steam_running, _NO_ARG);
DEFINE_PRIM(_BYTES, get_current_game_language, _NO_ARG);
DEFINE_PRIM(_BYTES, get_auth_ticket, _REF(_I32) _REF(_I32));
DEFINE_PRIM(_VOID, cancel_call_result, _CRESULT);
DEFINE_PRIM(_BYTES, get_current_beta_name, _NO_ARG);
DEFINE_PRIM(_BOOL, delete_item, _NO_ARG);
DEFINE_PRIM(_BOOL, get_app_dependencies, _NO_ARG);
DEFINE_PRIM(_BOOL, is_subscribed_from_family_sharing, _NO_ARG);
DEFINE_PRIM(_BOOL, remove_app_dependency, _NO_ARG);
DEFINE_PRIM(_VOID, add_app_dependency, _NO_ARG);
