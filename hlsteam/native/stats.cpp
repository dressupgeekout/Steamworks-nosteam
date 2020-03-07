#include "steamwrap.h"

/*
void CallbackHandler::OnUserStatsReceived( int *pCallback ){
}

void CallbackHandler::OnUserStatsStored( int *pCallback ){
}

void CallbackHandler::OnAchievementStored( int *pCallback ){
}

void CallbackHandler::FindLeaderboard(const char* name){
}

void CallbackHandler::OnLeaderboardFound(int *pCallback, bool bIOFailure)
{
}

bool CallbackHandler::UploadScore(const std::string& leaderboardId, int score, int detail){
 	return false;
}
*/


static std::string toLeaderboardScore(const char* leaderboardName, int score, int detail, int rank){
	printf("%s\n", __func__);
	return "";
}

/*
void CallbackHandler::OnScoreUploaded(int *pCallback, bool bIOFailure){
}

bool CallbackHandler::DownloadScores(const std::string& leaderboardId, int numBefore, int numAfter){
 	return false;
}

void CallbackHandler::OnScoreDownloaded(int *pCallback, bool bIOFailure){
}

void CallbackHandler::RequestGlobalStats(){
}

void CallbackHandler::OnGlobalStatsReceived(int* pResult, bool bIOFailure){
}
*/

//-----------------------------------------------------------------------------------------------------------

HL_PRIM bool HL_NAME(request_stats)(){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, request_stats, _NO_ARG);

HL_PRIM int HL_NAME(get_stat_int)(vbyte *name){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_stat_int, _BYTES);

HL_PRIM double HL_NAME(get_stat_float)(vbyte *name){
	printf("%s\n", __func__);
	return 0.0;
}
DEFINE_PRIM(_F64, get_stat_float, _BYTES);

HL_PRIM bool HL_NAME(set_stat_int)(vbyte *name, int val){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, set_stat_int, _BYTES _I32);

HL_PRIM bool HL_NAME(set_stat_float)(vbyte *name, double val){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, set_stat_float, _BYTES _F64);

HL_PRIM bool HL_NAME(store_stats)(){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, store_stats, _NO_ARG);

//-----------------------------------------------------------------------------------------------------------

HL_PRIM bool HL_NAME(set_achievement)(vbyte *name){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, set_achievement, _BYTES);

HL_PRIM bool HL_NAME(get_achievement)(vbyte *name) {
	printf("%s\n", __func__);
  return false;
}
DEFINE_PRIM(_BOOL, get_achievement, _BYTES);

HL_PRIM vbyte *HL_NAME(get_achievement_display_attribute)(vbyte *name, vbyte *key){
	printf("%s\n", __func__);
  return (vbyte*)"";
}
DEFINE_PRIM(_BYTES, get_achievement_display_attribute, _BYTES _BYTES);

HL_PRIM int HL_NAME(get_num_achievements)(){
	printf("%s\n", __func__);
  return 0;
}
DEFINE_PRIM(_I32, get_num_achievements, _NO_ARG);

HL_PRIM vbyte *HL_NAME(get_achievement_name)(int index){
	printf("%s\n", __func__);
  return (vbyte*)"";
}
DEFINE_PRIM(_BYTES, get_achievement_name, _I32);

HL_PRIM bool HL_NAME(clear_achievement)(vbyte *name){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, clear_achievement, _BYTES);

HL_PRIM bool HL_NAME(indicate_achievement_progress)(vbyte *name, int numCurProgres, int numMaxProgress){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, indicate_achievement_progress, _BYTES _I32 _I32);

//-----------------------------------------------------------------------------------------------------------

HL_PRIM bool HL_NAME(find_leaderboard)(vbyte *name) {
	printf("%s\n", __func__);
 	return false;
}
DEFINE_PRIM(_BOOL, find_leaderboard, _BYTES);

HL_PRIM bool HL_NAME(upload_score)(vbyte *name, int score, int detail){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, upload_score, _BYTES _I32 _I32);

HL_PRIM bool HL_NAME(download_scores)(vbyte *name, int numBefore, int numAfter) {
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, download_scores, _BYTES _I32 _I32);

HL_PRIM bool HL_NAME(request_global_stats)() {
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, request_global_stats, _NO_ARG);

HL_PRIM int HL_NAME(get_global_stat)(vbyte *name){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_global_stat, _BYTES);
