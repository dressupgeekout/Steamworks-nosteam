#include "steamwrap.h"

#define Networking()	(SteamNetworking() ? SteamNetworking() : SteamGameServerNetworking())

/*
vdynamic *CallbackHandler::EncodeP2PSessionRequest( P2PSessionRequest_t *d ) {
	HLValue v;
	v.Set("uid", d->m_steamIDRemote);
	return v.value;
}

vdynamic *CallbackHandler::EncodeP2PSessionConnectionFail( P2PSessionConnectFail_t *d ) {
	HLValue v;
	v.Set("uid", d->m_steamIDRemote);
	v.Set("error", d->m_eP2PSessionError);
	return v.value;
}
*/

HL_PRIM bool HL_NAME(send_p2p_packet)( vuid uid, vbyte *data, int length, int type, int channel ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(accept_p2p_session)( vuid uid ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM bool HL_NAME(is_p2p_packet_available)( int *msgSize, int channel ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM vuid HL_NAME(read_p2p_packet)( vbyte *data, int maxLength, int *length, int channel ) {
	printf("%s\n", __func__);
	return (vuid)0;
}

HL_PRIM vdynamic *HL_NAME(get_p2p_session_data)( vuid uid ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM bool HL_NAME(close_p2p_session)( vuid uid ) {
	printf("%s\n", __func__);
	return false;
}

DEFINE_PRIM(_BOOL, send_p2p_packet, _UID _BYTES _I32 _I32 _I32);
DEFINE_PRIM(_BOOL, accept_p2p_session, _UID);
DEFINE_PRIM(_BOOL, is_p2p_packet_available, _REF(_I32) _I32);
DEFINE_PRIM(_UID, read_p2p_packet, _BYTES _I32 _REF(_I32) _I32);
DEFINE_PRIM(_DYN, get_p2p_session_data, _UID);
DEFINE_PRIM(_BOOL, close_p2p_session, _UID);
