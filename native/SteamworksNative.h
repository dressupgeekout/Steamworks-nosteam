/* SteamworksNative - C# Wrapper for Steamworks Features - stub
 * Copyright (c) 2013-2014 Ethan "flibitijibibo" Lee
 * Copyright (c) 2019      Thomas Frohwein
 */

#ifndef STEAMWORKSNATIVE_H
#define STEAMWORKSNATIVE_H

#include <stdint.h>

#ifdef __cplusplus
extern "C" {
#endif

#ifdef _WIN32
	#define EXPORTFN __declspec(dllexport)
	#define DELEGATECALL __stdcall
#else
	#define EXPORTFN
	#define DELEGATECALL
#endif

/* Steam */

typedef void (DELEGATECALL *OverlayStatusChangeDelegate)(
	bool
);
typedef void (DELEGATECALL *UserStatsReceivedDelegate)(
	uint64_t,
	int32_t,
	uint32_t
);
typedef void (DELEGATECALL *UserStatsStoredDelegate)(
	bool
);
typedef void (DELEGATECALL *TextInputDismissedDelegate)(
	bool,
	char*
);
typedef void (DELEGATECALL *LeaderboardFoundDelegate)();
typedef void (DELEGATECALL *LeaderboardInitializedDelegate)(
	int32_t,
	uint64_t
);
typedef void (DELEGATECALL *LeaderboardFriendScoresDownloadedDelegate)(
	int32_t
);
typedef void (DELEGATECALL *LeaderboardCompletedFriendScoreDownloadDelegate)();
typedef void (DELEGATECALL *SharedFileDelegate)(bool);
typedef void (DELEGATECALL *PublishedFileDelegate)(
	bool,
	int32_t,
	uint64_t
);
typedef void (DELEGATECALL *UpdatedFileDelegate)(
	bool,
	int32_t
);
typedef void (DELEGATECALL *DeletedFileDelegate)(bool);
typedef void (DELEGATECALL *EnumeratedPublishedFilesDelegate)(
	bool,
	uint64_t*,
	int32_t
);
typedef void (DELEGATECALL *EnumeratedSubscribedFilesDelegate)(
	bool,
	uint64_t*,
	int32_t
);
typedef void (DELEGATECALL *ReceivedFileInfoDelegate)(
	uint64_t,
	char*,
	char*,
	char*
);
typedef void (DELEGATECALL *GotUGCDetailsDelegate)(
	uint32_t, /* FIXME: EResult! -flibit */
	uint64_t,
	char*,
	char*,
	char*,
	uint32_t,
	uint64_t,
	char*,
	char*
);
typedef void (DELEGATECALL *GotUserPublishedItemVoteDetailsDelegate)(
	uint64_t,
	int32_t
);

EXPORTFN bool Initialize(
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
);

EXPORTFN uint32_t GetAppID();

EXPORTFN void ActivateFriendsOverlay();

EXPORTFN void ActivateStatsOverlay();

EXPORTFN void ActivateWebPage(const char *URL);

EXPORTFN void OpenFullGameStorePage(const uint32_t appID);

EXPORTFN void FillFriendResults(
	uint64_t *resultArray,
	const int32_t numEntries
);

EXPORTFN bool IsOverlayEnabled();

EXPORTFN bool ShowGamepadTextInput(
	const bool passwordMode,
	const bool multipleLines,
	const char *description,
	const uint32_t charMax
);

EXPORTFN void RunCallbacks();

EXPORTFN uint32_t GetUserAccountID();

EXPORTFN const char *GetFriendNameByID(const uint32_t friendSteamID);

EXPORTFN const char *GetPlayersName();

EXPORTFN uint32_t GetFriendCount();

EXPORTFN uint32_t GetFriendByIndex(const int32_t index);

EXPORTFN uint32_t GetSmallFriendAvatar(const uint32_t friendSteamID);

EXPORTFN uint32_t GetMediumFriendAvatar(const uint32_t friendSteamID);

EXPORTFN uint32_t GetLargeFriendAvatar(const uint32_t friendSteamID);

EXPORTFN bool GetImageSize(
	const int iImage,
	uint32_t *pnWidth,
	uint32_t *pnHeight
);

EXPORTFN bool GetImageRGBA(
	const int iImage,
	unsigned char *pubDest,
	const int nDestBufferSize
);

EXPORTFN const char *GetCurrentGameLanguage();

EXPORTFN void Shutdown();

EXPORTFN int64_t GetNextRequestID();

/* Steam::Filesystem */

EXPORTFN bool IsCloudEnabled();

EXPORTFN int32_t GetFileSize(const char *name);

EXPORTFN void WriteFile(
	const char *name,
	unsigned char *data,
	const int32_t size
);

EXPORTFN int32_t ReadFile(
	const char *name,
	unsigned char *data,
	const int32_t byteCount
);

EXPORTFN void DeleteFile(const char *name);

EXPORTFN void ShareFile(const char *name);

EXPORTFN bool FileExists(const char *name);

EXPORTFN bool GetByteQuota(int32_t *total, int32_t *available);

EXPORTFN char *GetUserDataFolder();

/* Steam::SteamUGC */

typedef enum
{
	EFileVisibility_PUBLIC = 0,
	EFileVisibility_FRIENDSONLY = 1,
	EFileVisibility_PRIVATE = 2
} EFileVisibility;

typedef enum
{
	EFileType_COMMUNITY = 0,
	EFileType_MICROTRANSACTION = 1,
	EFileType_COLLECTION = 2,
	EFileType_ART = 3,
	EFileType_VIDEO = 4,
	EFileType_SCREENSHOT = 5,
	EFileType_GAME = 6,
	EFileType_SOFTWARE = 7,
	EFileType_CONCEPT = 8,
	EFileType_WEBGUIDE = 9,
	EFileType_INTEGRATEDGUIDE = 10,
	EFileType_MAX = 11 /* DO NOT USE! */
} EFileType;

EXPORTFN void PublishFile(
	const uint32_t appid,
	const char *name,
	const char *previewName,
	const char *title,
	const char *description,
	void *tags,
	const EFileVisibility visibility,
	const EFileType type
);

EXPORTFN void UpdatePublishedFile( /* TODO: Tags! -K */
	const uint64_t fileID,
	const char *name,
	const char *previewName,
	const char *title,
	const char *description,
	void *tags,
	const EFileVisibility visibility
);

EXPORTFN void DeletePublishedFile(const uint64_t fileID);

EXPORTFN void EnumeratePublishedFiles();

EXPORTFN void EnumerateSubscribedFiles();

EXPORTFN void GetPublishedFileInfo(const uint64_t fileID, const uint32_t secondsOld);

EXPORTFN void RequestUGCDetails(const uint64_t publishedFileID);

EXPORTFN bool GetRequestUGCDetailsStatus(const uint64_t publishedFileID);

/* Steam::Stats */

EXPORTFN void CommitStats();

EXPORTFN bool RequestCurrentStats();

EXPORTFN bool RequestGlobalStats(int32_t days);

EXPORTFN long long GetGlobalStatLong(const char *statID); // FIXME: long long, ugh -flibit

EXPORTFN int32_t GetProgressStat(const char *statID);

EXPORTFN float GetTimeStat(const char *statID);

EXPORTFN void SetProgressStat(const char *statID, const int32_t newValue);

EXPORTFN void SetTimeStat(const char *statID, const float minutesPlayed);

EXPORTFN void ResetAllStats(bool achievementsToo);

EXPORTFN void SetAchievement(const char *name);

EXPORTFN void ClearAchievement(const char *name);

EXPORTFN bool IndicateAchievementProgress(
	const char *name,
	const uint32_t curProgress,
	const uint32_t maxProgress
);

EXPORTFN bool GetAchievementAndUnlockTime(
	const char *name,
	bool *achieved,
	uint32_t *unlockTime
);

EXPORTFN void RequestUserStats(const uint32_t userAccountId);

EXPORTFN bool GetUserAchievement(
	const uint32_t userAccountId,
	const char *name,
	bool *pbAchieved
);

/* Steam::Leaderboards */

EXPORTFN void UploadLeaderboardScore(
	const uint64_t handle,
	const int score,
	const bool forceUpdate
);

EXPORTFN void GetFriendLeaderboardScores(const uint64_t leaderboardID);

EXPORTFN void FindLeaderboard(
	const char *name,
	const int32_t externID,
	const bool initializingLeaderboard
);

/* Steam::DLC */

EXPORTFN bool IsDLCInstalled(const uint32_t appID);

/* Steam::SteamController */

typedef struct ControllerState_s
{
	uint32_t packetNum;
	uint64_t buttons;
	int16_t leftPadX;
	int16_t leftPadY;
	int16_t rightPadX;
	int16_t rightPadY;
} ControllerState_t;

typedef enum
{
	SteamControllerPad_Left,
	SteamControllerPad_Right
} SteamControllerPad;

EXPORTFN bool ControllerInit(const char *absolutePathToControllerConfigVDF);

EXPORTFN bool ControllerShutdown();

EXPORTFN void ControllerRunFrame();

EXPORTFN bool GetControllerState(
	const uint32_t controllerIndex,
	ControllerState_t *state
);

EXPORTFN void TriggerHapticPulse(
	const uint32_t controllerIndex,
	SteamControllerPad targetPad,
	const uint16_t durationMicroSec
);

EXPORTFN void SetOverrideMode(const char *mode);

EXPORTFN void UGCDownloadToLocation(const uint64_t ugcHandle, const char * destinationPath, uint32_t priority);

EXPORTFN void GetUGCDownloadProgress(const uint64_t ugcHandle, int32_t * bytesDownloaded, int32_t * bytesExpected);

EXPORTFN void UnsubscribePublishedFile(const uint64_t publishedFileId);

EXPORTFN void SetUserPublishedFileAction(const uint64_t publishedFileId, int eAction);

EXPORTFN void UpdateUserPublishedItemVote(const uint64_t publishedFileId, int voteUp);

EXPORTFN void GetUserPublishedItemVoteDetails(const uint64_t publishedFileId);

#undef EXPORTFN
#undef DELEGATECALL

#ifdef __cplusplus
}
#endif

#endif /* STEAMWORKSNATIVE_H */
