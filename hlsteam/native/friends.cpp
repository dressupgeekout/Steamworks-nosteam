#include "steamwrap.h"

/*
vdynamic *CallbackHandler::EncodePersonaChange( int *d ) {
	return nullptr;
}
*/

HL_PRIM vbyte *HL_NAME(get_user_name)( vuid uid ) {
	printf("%s\n", __func__);
	return (vbyte*)"Unknown";
}

HL_PRIM bool HL_NAME(request_user_information)( vuid uid, bool nameOnly ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM vbyte *HL_NAME(get_user_avatar)( vuid uid, int size, int *width, int *height ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM varray *HL_NAME(get_friends)( int flags ) {
	printf("%s\n", __func__);
	return nullptr;
}

HL_PRIM bool HL_NAME(has_friend)( vuid uid, int flags ) {
	printf("%s\n", __func__);
	return false;
}

HL_PRIM void HL_NAME(activate_overlay_user)( vbyte *dialog, vuid uid ) {
	printf("%s\n", __func__);
}

HL_PRIM void HL_NAME(activate_overlay_store)( int appid, int flag ) {
	printf("%s\n", __func__);
}

DEFINE_PRIM(_BYTES, get_user_name, _UID);
DEFINE_PRIM(_BYTES, get_user_avatar, _UID _I32 _REF(_I32) _REF(_I32));
DEFINE_PRIM(_BOOL, request_user_information, _UID _BOOL);
DEFINE_PRIM(_ARR, get_friends, _I32);
DEFINE_PRIM(_BOOL, has_friend, _UID _I32);
DEFINE_PRIM(_VOID, activate_overlay_user, _BYTES _UID);
DEFINE_PRIM(_VOID, activate_overlay_store, _I32 _I32);

