#include "steamwrap.h"

/*
vdynamic *CallbackHandler::EncodeLobbyData( int *d ) {
	return nullptr;
}

vdynamic *CallbackHandler::EncodeLobbyChatUpdate( int *d ) {
	return nullptr;
}

vdynamic *CallbackHandler::EncodeLobbyChatMsg( int *d ) {
	return nullptr;
}

vdynamic *CallbackHandler::EncodeLobbyJoinRequest( int *d ) {
	return nullptr;
}
*/

// --------- Lobby Search --------------------------

static void on_lobby_list( vclosure *c, int *result, bool error ) {
	printf("%s\n", __func__);
}

HL_PRIM void* HL_NAME(request_lobby_list)( vclosure *closure ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM vuid HL_NAME(get_lobby_by_index)( int index ) {
	printf("%s\n", __func__);
	return (vuid)0;
}

HL_PRIM void HL_NAME(request_filter_string)( vbyte *key, vbyte *value, int type ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(request_filter_numerical)( vbyte *key, int value, int type ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(request_filter_near_value)( vbyte *key, int value ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(request_filter_slots_available)( int slots ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(request_filter_distance)( int distance ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(request_result_count)( int max ) {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_CRESULT, request_lobby_list, _CALLB(_I32));
DEFINE_PRIM(_UID, get_lobby_by_index, _I32);

DEFINE_PRIM(_VOID, request_filter_string, _BYTES _BYTES _I32);
DEFINE_PRIM(_VOID, request_filter_numerical, _BYTES _I32 _I32);
DEFINE_PRIM(_VOID, request_filter_near_value, _BYTES _I32);
DEFINE_PRIM(_VOID, request_filter_slots_available, _I32);
DEFINE_PRIM(_VOID, request_filter_distance, _I32);
DEFINE_PRIM(_VOID, request_result_count, _I32);

// --------- Lobby Create / Manage --------------------------

static void on_lobby_created( vclosure *c, int *result, bool error ) {
	printf("%s\n", __func__);
}

HL_PRIM void* HL_NAME(create_lobby)( int lobbyType, int maxMembers, vclosure *closure ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM void HL_NAME(leave_lobby)( vuid uid ) {
	printf("%s\n", __func__);
}

static void on_lobby_joined( vclosure *c, int *result, bool error ) {
	printf("%s\n", __func__);
}

HL_PRIM void* HL_NAME(join_lobby)( vuid uid, vclosure *closure ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM int HL_NAME(get_num_lobby_members)( vuid uid ) {
	printf("%s\n", __func__);
	return 0;
}

HL_PRIM vuid HL_NAME(get_lobby_member_by_index)( vuid uid, int index ) {
	printf("%s\n", __func__);
	return (vuid)0;
}

HL_PRIM vuid HL_NAME(get_lobby_owner)( vuid uid ) {
	printf("%s\n", __func__);
	return (vuid)0;
}

HL_PRIM void HL_NAME(lobby_invite_friends)( vuid uid ) {
	printf("%s\n", __func__);
}

HL_PRIM bool HL_NAME(send_lobby_chat_msg)( vuid uid, vbyte *msg, int len ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM vuid HL_NAME(get_lobby_chat_entry)( vuid uid, int cid, vbyte *data, int maxData, int *type, int *outLen ) {
	printf("%s\n", __func__);
	return (vuid)0;
}

HL_PRIM bool HL_NAME(lobby_invite_user)( vuid lid, vuid fid ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM int HL_NAME(get_lobby_member_limit)( vuid uid ) {
	printf("%s\n", __func__);
	return 0;
}

HL_PRIM void HL_NAME(set_lobby_member_limit)( vuid uid, int count ) {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_CRESULT, create_lobby, _I32 _I32 _CALLB(_UID));
DEFINE_PRIM(_VOID, leave_lobby, _UID);
DEFINE_PRIM(_CRESULT, join_lobby, _UID _CALLB(_BOOL));

DEFINE_PRIM(_I32, get_num_lobby_members, _UID);
DEFINE_PRIM(_UID, get_lobby_member_by_index, _UID _I32);
DEFINE_PRIM(_I32, get_lobby_member_limit, _UID);
DEFINE_PRIM(_VOID, set_lobby_member_limit, _UID _I32);

DEFINE_PRIM(_UID, get_lobby_owner, _UID);
DEFINE_PRIM(_VOID, lobby_invite_friends, _UID);
DEFINE_PRIM(_BOOL, lobby_invite_user, _UID _UID);
DEFINE_PRIM(_BOOL, send_lobby_chat_msg, _UID _BYTES _I32);
DEFINE_PRIM(_UID, get_lobby_chat_entry, _UID _I32 _BYTES _I32 _REF(_I32) _REF(_I32));

// --------- Lobby Data --------------------------

HL_PRIM bool HL_NAME(request_lobby_data)( vuid uid ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM const char *HL_NAME(get_lobby_data)( vuid uid, const char *key ) {
	printf("%s\n", __func__);
	return "";
}

HL_PRIM bool HL_NAME(set_lobby_data)( vuid uid, const char *key, const char *value ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(delete_lobby_data)( vuid uid, const char *key ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM int HL_NAME(get_lobby_data_count)( vuid uid ) {
	printf("%s\n", __func__);
	return 0;
}

HL_PRIM bool HL_NAME(get_lobby_data_byindex)( vuid uid, int index, char *key, int ksize, char *value, int vsize ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM vbyte *HL_NAME(get_lobby_member_data)( vuid lid, vuid uid, const char *key ) {
	printf("%s\n", __func__);
	return (vbyte*)0;
}

HL_PRIM void HL_NAME(set_lobby_member_data)( vuid lid, const char *key, const char *value ) {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_BOOL, request_lobby_data, _UID);
DEFINE_PRIM(_BYTES, get_lobby_data, _UID _BYTES);
DEFINE_PRIM(_BOOL, set_lobby_data, _UID _BYTES _BYTES);
DEFINE_PRIM(_BOOL, delete_lobby_data, _UID _BYTES);
DEFINE_PRIM(_I32, get_lobby_data_count, _UID);
DEFINE_PRIM(_BOOL, get_lobby_data_byindex, _UID _I32 _BYTES _I32 _BYTES _I32);
DEFINE_PRIM(_BYTES, get_lobby_member_data, _UID _UID _BYTES);
DEFINE_PRIM(_VOID, set_lobby_member_data, _UID _BYTES _BYTES);

// ---------
