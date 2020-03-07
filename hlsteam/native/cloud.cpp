#include "steamwrap.h"

HL_PRIM int HL_NAME(get_file_count)(){
	printf("%s\n", __func__);
	//if (!CheckInit()) return -1;
	return 0;
}

HL_PRIM int HL_NAME(get_file_size)(vbyte *fileName){
	printf("%s\n", __func__);
	if (!CheckInit()) return -1;
	return 0;
}

HL_PRIM bool HL_NAME(file_exists)(vbyte *fileName){
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	return true;
}

HL_PRIM vbyte *HL_NAME(file_read)(vbyte *fileName, int *len){
	printf("%s\n", __func__);
	if (!CheckInit()) return NULL;
	return NULL;
	int length = 0;
	char *bytesData = (char *)hl_gc_alloc_noptr(length);
	int result = 0;
	*len = length;
	return (vbyte*)bytesData;
}

HL_PRIM bool HL_NAME(file_write)(vbyte *fileName, vbyte *bytes, int length){
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	if (length <= 0) return false;
	return true;
}

HL_PRIM bool HL_NAME(file_delete)(vbyte *fileName){
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	return true;
}

static void on_file_shared(vclosure *c, int *result, bool error) {
	printf("%s\n", __func__);
}

/*
HL_PRIM CClosureCallResult<RemoteStorageFileShareResult_t>* HL_NAME(file_share)(vbyte *fileName, vclosure *closure) {
	if (!CheckInit()) return NULL;
	ASYNC_CALL(SteamRemoteStorage()->FileShare((const char*)fileName), RemoteStorageFileShareResult_t, on_file_shared);
	return m_call;
}
*/

HL_PRIM bool HL_NAME(is_cloud_enabled_for_account)() {
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	return false;
}

HL_PRIM bool HL_NAME(is_cloud_enabled_for_app)(){
	printf("%s\n", __func__);
	if (!CheckInit()) return false;
	return false;
}

HL_PRIM void HL_NAME(set_cloud_enabled_for_app)(bool enabled){
	printf("%s\n", __func__);
	if (!CheckInit()) return;
}

HL_PRIM void HL_NAME(get_quota)( double *total, double *available ){
	printf("%s\n", __func__);
	if (!CheckInit()) return;
}

DEFINE_PRIM(_I32, get_file_count, _NO_ARG);
DEFINE_PRIM(_I32, get_file_size, _BYTES);
DEFINE_PRIM(_BOOL, file_exists, _BYTES);
DEFINE_PRIM(_BYTES, file_read, _BYTES _REF(_I32));
DEFINE_PRIM(_BOOL, file_write, _BYTES _BYTES _I32);
DEFINE_PRIM(_BOOL, file_delete, _BYTES);
//DEFINE_PRIM(_CRESULT, file_share, _BYTES _CALLB(_UID));
DEFINE_PRIM(_BOOL, is_cloud_enabled_for_app, _NO_ARG);
DEFINE_PRIM(_BOOL, is_cloud_enabled_for_account, _NO_ARG);
DEFINE_PRIM(_VOID, set_cloud_enabled_for_app, _BOOL);
DEFINE_PRIM(_VOID, get_quota, _NO_ARG _REF(_F64) _REF(_F64));
