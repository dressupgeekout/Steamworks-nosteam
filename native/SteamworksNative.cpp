/* SteamworksNative - C# Wrapper for Steamworks Features - stub
 * Copyright (c) 2013-2014	Ethan "flibitijibibo" Lee
 * Copyright (c) 2019		Thomas Frohwein
 */

#include "SteamworksNative.h"

/* Used to get PRIu64 for printf()s -flibit */
#ifdef _WIN32
#define PRIu64 "%llu" /* lol */
#else
#define __STDC_FORMAT_MACROS
#include <inttypes.h>
#endif

#include <map> /* FIXME: C++ :( -flibit */

class SteamCallbackContainer
{
public:
	/* FoundLeaderboard */
	int32_t externID;
	bool initializingLeaderboard;

	void FoundLeaderboard( void *result, bool bIOFailure ) { }
	void GotUGCDetails( void *result, bool bIOFailure ) { }
	void GotUserPublishedItemVoteDetails( void *result, bool bIOFailure ) { }
	void GotFriendScores(void *result, bool bIOFailure) { }
	void SharedFile( void *result, bool bIOFailure ) { }
	void PublishedFile( void *result, bool bIOFailure ) { }
	void UpdatedFile( void *result, bool bIOFailure ) { }
	void DeletedFile( void *result, bool bIOFailure ) { }
	void EnumeratedPublishedFiles( void *result, bool bIOFailure ) { }
	void EnumeratedSubscribedFiles( void *result, bool bIOFailure ) { }
	void ReceivedFileInfo( void *result, bool bIOFailure ) { }
};

static SteamCallbackContainer *callbackContainer;

/* Steam */
bool Initialize(
	OverlayStatusChangeDelegate managedOverlayDelegate,
	UserStatsReceivedDelegate managedUserStatsReceivedDelegate,
	UserStatsStoredDelegate managedUserStatsStoredDelegate,
	TextInputDismissedDelegate managedTextInputDismissedDelegate,
	LeaderboardFoundDelegate managedLeaderboardFoundDelegate,
	LeaderboardInitializedDelegate managedLeaderboardInitializedDelegate,
	LeaderboardFriendScoresDownloadedDelegate managedLeaderboardFriendScoresDownloadedDelegate,
	LeaderboardCompletedFriendScoreDownloadDelegate managedLeaderboardCompletedFriendScoresDownloadDelegate,
	SharedFileDelegate managedSharedFileDelegate,
	PublishedFileDelegate managedPublishedFileDelegate,
	UpdatedFileDelegate managedUpdatedFileDelegate,
	DeletedFileDelegate managedDeletedFileDelegate,
	EnumeratedPublishedFilesDelegate managedEnumeratedPublishedFilesDelegate,
	EnumeratedSubscribedFilesDelegate managedEnumeratedSubscribedFilesDelegate,
	ReceivedFileInfoDelegate managedReceivedFileInfoDelegate,
	GotUGCDetailsDelegate managedGotUGCDetailsDelegate,
	GotUserPublishedItemVoteDetailsDelegate managedGotUserPublishedItemVoteDetailsDelegate
) { return true; }
uint32_t GetAppID() { return (uint32_t) 0; }
int GetAppBuildId() { return 0; }
int GetCurrentStats() { return 0; }
bool IsSubscribedApp(uint32_t appID) { return false; }
char *GetLaunchQueryParam(char *paramName) {
	char *ret = NULL;
	return ret;
}
void ActivateFriendsOverlay() { }
void ActivateStatsOverlay() { }
void ActivateWebPage(const char *URL) { }
void OpenFullGameStorePage(const uint32_t appID) { }
void FillFriendResults( uint64_t *resultArray, const int32_t numEntries) { }
bool IsOverlayEnabled() { return false; }
bool ShowGamepadTextInput(
	const bool passwordMode,
	const bool multipleLines,
	const char *description,
	const uint32_t charMax
) { return false; }
void RunCallbacks() { }
uint32_t GetUserAccountID() { return (uint32_t) 0; }
const char *GetFriendNameByID(const uint32_t friendSteamID) {
	char *ret = NULL;
	return ret;
}
const char *GetPlayersName() {
	char *ret = NULL;
	return ret;
}
uint32_t GetFriendCount() { return (uint32_t) 0; }
uint32_t GetFriendByIndex(const int32_t index) { return (uint32_t) 0; }
uint32_t GetSmallFriendAvatar(const uint32_t friendSteamID) { return (uint32_t) 0; }
uint32_t GetMediumFriendAvatar(const uint32_t friendSteamID)
{ return (uint32_t) 0; }
uint32_t GetLargeFriendAvatar(const uint32_t friendSteamID)
{ return (uint32_t) 0; }
bool GetImageSize(const int iImage, uint32_t *pnWidth, uint32_t *pnHeight)
{ return false; }
bool GetImageRGBA(const int iImage, unsigned char *pubDest, const int nDestBufferSize)
{ return false; }
const char *GetCurrentGameLanguage() { return "en-US"; }
void Shutdown() { }
static int64_t lastUsedRequestID = 0;
int64_t GetNextRequestID() { return ++lastUsedRequestID; }

/* Steam::Filesystem */
bool IsCloudEnabled() { return false; }
int32_t GetFileSize(const char *name) { return (int32_t) 0; }
void WriteFile(const char *name, unsigned char *data, const int32_t size) { }
int32_t ReadFile(const char *name, unsigned char *data, const int32_t byteCount) { return (int32_t) 0; }
void DeleteFile(const char *name) { }
void ShareFile(const char *name) { }
bool FileExists(const char *name) { return false; }
bool GetByteQuota(int32_t *total, int32_t *available) { return false; }
static char folder[300];
char *GetUserDataFolder() {
	char *ret = NULL;
	return ret;
}

/* Steam::SteamUGC */
void PublishFile(
	const uint32_t appid,
	const char *name,
	const char *previewName,
	const char *title,
	const char *description,
	void *tags,
	const EFileVisibility visibility,
	const EFileType type
) { }
void UpdatePublishedFile(
	const uint64_t fileID,
	const char *name,
	const char *previewName,
	const char *title,
	const char *description,
	void *tags,
	const EFileVisibility visibility
) { }
void DeletePublishedFile(const uint64_t fileID) { }
void EnumeratePublishedFiles() { }
void EnumerateSubscribedFiles() { }
void GetPublishedFileInfo(const uint64_t fileID, const uint32_t secondsOld) { }

/* Steam::Stats */
void CommitStats() { }
bool RequestCurrentStats() { return false; }
bool RequestGlobalStats(int32_t days) { return false; }
long long GetGlobalStatLong(const char *statID)
{
	long long stat;
	stat = 0;
	return stat;
}
int32_t GetProgressStat(const char *statID)
{
	int32_t stat;
	stat = 0;
	return stat;
}
float GetTimeStat(const char *statID)
{
	float stat;
	stat = 0.0;
	return stat;
}
void SetProgressStat(const char *statID, const int32_t newValue) { }
void SetTimeStat(const char *statID, const float minutesPlayed) { }
void ResetAllStats(bool achievementsToo) { }
void SetAchievement(const char *name) { }
void ClearAchievement(const char *name) { }
bool IndicateAchievementProgress(
	const char *name,
	const uint32_t curProgress,
	const uint32_t maxProgress
) { return false; }
bool GetAchievementAndUnlockTime(
	const char *name,
	bool *achieved,
	uint32_t *unlockTime
) { return false; }
void RequestUserStats(const uint32_t userAccountId) { }

/* This is a direct wrapper for the Steam method (which isn't documented well).
 * The return value is _probably_ a success/failure of the request but it isn't
 * stated. The example app ignores the return value.
 * -Sean
 */
bool GetUserAchievement(const uint32_t userAccountId, const char *name, bool *pbAchieved)
{ return false; }

/* Steam::Leaderboards */
void UploadLeaderboardScore(const uint64_t handle, const int score, const bool forceUpdate) { }
void GetFriendLeaderboardScores(const uint64_t leaderboardID) { }
void FindLeaderboard(
	const char *name,
	const int32_t externID,
	const bool initializingLeaderboard
) { }

/* Steam::DLC */
bool IsDLCInstalled(const uint32_t appID) { return false; }

/* Steam::SteamController */
bool ControllerInit(const char *absolutePathToControllerConfigVDF) { return false; }
bool ControllerShutdown() { return false; }
void ControllerRunFrame() { }
bool GetControllerState(
	const uint32_t controllerIndex,
	ControllerState_t *state
) { return false; }
void TriggerHapticPulse(
	const uint32_t controllerIndex,
	SteamControllerPad targetPad,
	const uint16_t durationMicroSec
) { }
void SetOverrideMode(const char *mode) { }
void RequestUGCDetails(const uint64_t publishedFileId) { }
void UGCDownloadToLocation(const uint64_t ugcHandle, const char * destinationPath, uint32_t priority) 
{ }
void GetUGCDownloadProgress(const uint64_t ugcHandle, int32_t * bytesDownloaded, int32_t * bytesExpected) 
{ }
void UnsubscribePublishedFile(const uint64_t publishedFileId) { }
void SetUserPublishedFileAction(const uint64_t publishedFileId, int eAction) { }
void UpdateUserPublishedItemVote(const uint64_t publishedFileId, int voteUp) { }
void GetUserPublishedItemVoteDetails(const uint64_t publishedFileId) { }
bool GetRequestUGCDetailsStatus(const uint64_t publishedFileId) { return false; }
