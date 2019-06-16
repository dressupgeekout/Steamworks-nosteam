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

/* Callbacks */

class SteamCallbackContainer
{
	/*
public:
	GotUGCDetailsDelegate				gotUGCDetailsDelegate;
private:
	OverlayStatusChangeDelegate			overlayDelegate;
	UserStatsReceivedDelegate			userStatsReceivedDelegate;
	UserStatsStoredDelegate				userStatsStoredDelegate;
	TextInputDismissedDelegate			textInputDismissedDelegate;
	LeaderboardFoundDelegate			leaderboardFoundDelegate;
	LeaderboardInitializedDelegate			leaderboardInitializedDelegate;
	LeaderboardFriendScoresDownloadedDelegate	leaderboardFriendScoresDownloadedDelegate;
	LeaderboardCompletedFriendScoreDownloadDelegate	leaderboardCompletedFriendScoreDownloadDelegate;
	SharedFileDelegate				sharedFileDelegate;
	PublishedFileDelegate				publishedFileDelegate;
	UpdatedFileDelegate				updatedFileDelegate;
	DeletedFileDelegate				deletedFileDelegate;
	EnumeratedPublishedFilesDelegate		enumeratedPublishedFilesDelegate;
	EnumeratedSubscribedFilesDelegate		enumeratedSubscribedFilesDelegate;
	ReceivedFileInfoDelegate			receivedFileInfoDelegate;
	GotUserPublishedItemVoteDetailsDelegate		gotUserPublishedItemVoteDetailsDelegate;

	STEAM_CALLBACK(
		SteamCallbackContainer,
		INTERNAL_GameOverlayActivated,
		GameOverlayActivated_t,
		GameOverlayActivated
	) {
		overlayDelegate(pParam->m_bActive);
		printf(
			"Managed overlay call successful, status: %s\n",
			pParam->m_bActive ? "On" : "Off"
		);
	}

	STEAM_CALLBACK(
		SteamCallbackContainer,
		INTERNAL_UserStatsReceived,
		UserStatsReceived_t,
		UserStatsReceived
	) {
		if (pParam->m_eResult == k_EResultOK)
		{
			printf("STAT RECEIVE SUCCESSFUL\n");
		}
		else
		{
			printf("STAT RECEIVE FAILED: %d\n", pParam->m_eResult);
		}
		userStatsReceivedDelegate(
			pParam->m_nGameID,
			pParam->m_eResult,
			pParam->m_steamIDUser.GetAccountID()
		);
	}

	STEAM_CALLBACK(
		SteamCallbackContainer,
		INTERNAL_GlobalStatsReceived,
		GlobalStatsReceived_t,
		GlobalStatsReceived
	) {
		if (pParam->m_eResult == k_EResultOK)
		{
			printf("GLOBAL STAT RECEIVE SUCCESSFUL\n");
		}
		else
		{
			printf("GLOBAL STAT RECEIVE FAILED: %d\n", pParam->m_eResult);
		}
	}

	STEAM_CALLBACK(
		SteamCallbackContainer,
		INTERNAL_UserStatsStored,
		UserStatsStored_t,
		UserStatsStored
	) {
		if (pParam->m_eResult == k_EResultOK)
		{
			userStatsStoredDelegate(true);
			printf("STATS STORED SUCCESSFUL\n");
		}
		else
		{
			userStatsStoredDelegate(false);
			printf("STATS STORED FAILED: %d\n", pParam->m_eResult);
		}
	}

	STEAM_CALLBACK(
		SteamCallbackContainer,
		INTERNAL_TextInputDismissed,
		GamepadTextInputDismissed_t,
		GamepadTextInputDismissed
	) {
		if (!pParam->m_bSubmitted)
		{
			textInputDismissedDelegate(false, NULL);
			return;
		}
		char input[2048];
		SteamUtils()->GetEnteredGamepadTextInput(
			input,
			pParam->m_unSubmittedText + 1
		);
		textInputDismissedDelegate(
			true,
			input
		);
	}
	*/

public:
	/* FoundLeaderboard */
	int32_t externID;
	bool initializingLeaderboard;

	/* GotFriendScores */
	//SteamLeaderboard_t leaderboardHandle;
	//SteamLeaderboardEntries_t resultLeaderboardHandle;

	/* GotUserPublishedItemVoteDetails */
	//std::map<uint64_t, CCallResult<SteamCallbackContainer, SteamUGCRequestUGCDetailsResult_t> > ugcDetailsRequests;

	/* GotUserPublishedItemVoteDetails */
	//std::map<uint64_t, CCallResult<SteamCallbackContainer, RemoteStorageUserVoteDetails_t> > voteDetailsRequests;

	/*
	SteamCallbackContainer(
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
	) :	GameOverlayActivated(this, &SteamCallbackContainer::INTERNAL_GameOverlayActivated),
		UserStatsReceived(this, &SteamCallbackContainer::INTERNAL_UserStatsReceived),
		GlobalStatsReceived(this, &SteamCallbackContainer::INTERNAL_GlobalStatsReceived),
		UserStatsStored(this, &SteamCallbackContainer::INTERNAL_UserStatsStored),
		GamepadTextInputDismissed(this, &SteamCallbackContainer::INTERNAL_TextInputDismissed)
	{
		overlayDelegate = managedOverlayDelegate;
		userStatsReceivedDelegate = managedUserStatsReceivedDelegate;
		userStatsStoredDelegate = managedUserStatsStoredDelegate;
		textInputDismissedDelegate = managedTextInputDismissedDelegate;
		leaderboardFoundDelegate = managedLeaderboardFoundDelegate;
		leaderboardInitializedDelegate = managedLeaderboardInitializedDelegate;
		leaderboardFriendScoresDownloadedDelegate = managedLeaderboardFriendScoresDownloadedDelegate;
		leaderboardCompletedFriendScoreDownloadDelegate = managedLeaderboardCompletedFriendScoresDownloadDelegate;
		sharedFileDelegate = managedSharedFileDelegate;
		publishedFileDelegate = managedPublishedFileDelegate;
		updatedFileDelegate = managedUpdatedFileDelegate;
		deletedFileDelegate = managedDeletedFileDelegate;
		enumeratedPublishedFilesDelegate = managedEnumeratedPublishedFilesDelegate;
		enumeratedSubscribedFilesDelegate = managedEnumeratedSubscribedFilesDelegate;
		receivedFileInfoDelegate = managedReceivedFileInfoDelegate;
		gotUGCDetailsDelegate = managedGotUGCDetailsDelegate;
		gotUserPublishedItemVoteDetailsDelegate = managedGotUserPublishedItemVoteDetailsDelegate;

		externID = -1;
		initializingLeaderboard = false;

		leaderboardHandle = 0;
		resultLeaderboardHandle = 0;
	}
	*/

	void FoundLeaderboard(
		void *result,
		bool bIOFailure
	) {
		/*
		if (!result->m_bLeaderboardFound || bIOFailure)
		{
			printf("SOMETHING WENT WRONG WITH LEADERBOARDS\n");
		}
		else
		{
			leaderboardFoundDelegate();
		}

		if (initializingLeaderboard)
		{
			initializingLeaderboard = false;
			leaderboardInitializedDelegate(
				externID,
				result->m_hSteamLeaderboard
			);
		}
		*/
	}

	void GotUGCDetails(
		void *result,
		bool bIOFailure
	) {
		/*
		if (!result)
		{
			return;
		}
		gotUGCDetailsDelegate(
			result->m_details.m_eResult,
			result->m_details.m_nPublishedFileId,
			result->m_details.m_rgchTitle,
			result->m_details.m_rgchDescription,
			result->m_details.m_rgchTags,
			result->m_details.m_rtimeUpdated,
			result->m_details.m_hFile,
			result->m_details.m_pchFileName,
			result->m_details.m_rgchURL
		);
		*/
	}

	void GotUserPublishedItemVoteDetails(
		void *result,
		bool bIOFailure
	) {
		/*
		if (!result || bIOFailure)
		{
			gotUserPublishedItemVoteDetailsDelegate(0, -1);
		}
		else
		{
			this->voteDetailsRequests.erase(this->voteDetailsRequests.find(result->m_nPublishedFileId));
			gotUserPublishedItemVoteDetailsDelegate(result->m_nPublishedFileId, result->m_eVote);
		}
		*/
	}

	void GotFriendScores(void *result, bool bIOFailure)
	{
		/*
		if (bIOFailure)
		{
			printf("SOMETHING WENT WRONG WITH LEADERBOARDS\n");
			return;
		}
		else
		{
			if (result->m_cEntryCount > 0)
			{
				leaderboardHandle = result->m_hSteamLeaderboard;
				resultLeaderboardHandle = result->m_hSteamLeaderboardEntries;
				printf(
					"DOWNLOAD SUCCESS: (%llu) # of Friend Scores: %i\n",
					result->m_hSteamLeaderboard,
					result->m_cEntryCount
				);
				leaderboardFriendScoresDownloadedDelegate(
					result->m_cEntryCount
				);
				leaderboardCompletedFriendScoreDownloadDelegate();
			}
			else
			{
				printf(
					"DOWNLOAD SKIPPED: (%llu) No Friends with an entry\n",
					result->m_hSteamLeaderboard
				);
				leaderboardCompletedFriendScoreDownloadDelegate();
			}
		}
		*/
	}

	#define CHECK_FAILURE(CallbackName) \
		if (bIOFailure) \
		{ \
			printf( \
				"\nFile %s: INTERNAL STEAM ERROR: %i\n", \
				CallbackName, \
				result->m_eResult \
			); \
		} \
		else \
		{ \
			printf("\nFile %s succeeded!\n", CallbackName); \
		}

	void SharedFile(
		void *result,
		bool bIOFailure
	) {
		/*
		CHECK_FAILURE("Share")
		if (sharedFileDelegate)
		{
			sharedFileDelegate(!bIOFailure);
		}
		*/
	}

	void PublishedFile(
		void *result,
		bool bIOFailure
	) {
		/*
		if (!bIOFailure)
		{
			printf(
				"\nFile Publish succeeded! FileID: %llu\n",
				result->m_nPublishedFileId
			);
		}
		else
		{
			printf("\nFile Publish failed! No FileID returned.\n");
		}
		if (publishedFileDelegate)
		{
			publishedFileDelegate(
				!bIOFailure,
				result->m_eResult,
				result->m_nPublishedFileId
			);
		}
		*/
	}

	void UpdatedFile(
		void *result,
		bool bIOFailure
	) {
		/*
		CHECK_FAILURE("Update")
		if (updatedFileDelegate)
		{
			updatedFileDelegate(!bIOFailure, result->m_eResult);
		}
		*/
	}

	void DeletedFile(
		void *result,
		bool bIOFailure
	) {
		/*
		CHECK_FAILURE("Delete")
		if (deletedFileDelegate)
		{
			deletedFileDelegate(!bIOFailure);
		}
		*/
	}

	void EnumeratedPublishedFiles(
		void *result,
		bool bIOFailure
	) {
		/* FIXME: This 100 is totally arbitrary! */
		/*
		uint64_t retVals[100];
		int32_t i;
		if (!bIOFailure)
		{
			printf(
				"\nListing succeeded! %i files found.\n",
				result->m_nResultsReturned
			);
		}
		else
		{
			printf("\nListing failed! No files found.\n");
		}
		if (enumeratedPublishedFilesDelegate)
		{
			for (i = 0; i < result->m_nResultsReturned; i++)
			{
				retVals[i] = result->m_rgPublishedFileId[i];
			}
			enumeratedPublishedFilesDelegate(
				!bIOFailure,
				retVals,
				result->m_nResultsReturned
			);
		}
		*/
	}

	void EnumeratedSubscribedFiles(
		void *result,
		bool bIOFailure
	) {
		/* FIXME: This 100 is totally arbitrary! */
		/*
		uint64_t retVals[100];
		int32_t i;
		if (!bIOFailure)
		{
			printf(
				"\nListing succeeded! %i files found.\n",
				result->m_nResultsReturned
			);
		}
		else
		{
			printf("\nListing failed! No files found.\n");
		}
		if (enumeratedSubscribedFilesDelegate)
		{
			for (i = 0; i < result->m_nResultsReturned; i++)
			{
				retVals[i] = result->m_rgPublishedFileId[i];
			}
			enumeratedSubscribedFilesDelegate(
				!bIOFailure,
				retVals,
				result->m_nResultsReturned
			);
		}
		*/
	}

	void ReceivedFileInfo(
		void *result,
		bool bIOFailure
	) {
		/*
		if (!bIOFailure)
		{	
			printf(
				"\nWorkshop Info for file ID %llu:\n"
				"\tTitle: %s\n\tDescription: %s\n",
				result->m_nPublishedFileId,
				result->m_rgchTitle,
				result->m_rgchDescription
			);
		}
		else
		{
			printf("\nFile Listing failed! No info found.\n");
		}
		if (receivedFileInfoDelegate)
		{
			receivedFileInfoDelegate(
				result->m_nPublishedFileId,
				result->m_rgchTitle,
				result->m_rgchDescription,
				result->m_rgchTags
			);
		}
		*/
	}

	#undef CHECK_FAILURE
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
) {
	/*
	if (!SteamAPI_Init())
	{
		return false;
	}

	callbackContainer = new SteamCallbackContainer(
		managedOverlayDelegate,
		managedUserStatsReceivedDelegate,
		managedUserStatsStoredDelegate,
		managedTextInputDismissedDelegate,
		managedLeaderboardFoundDelegate,
		managedLeaderboardInitializedDelegate,
		managedLeaderboardFriendScoresDownloadedDelegate,
		managedLeaderboardCompletedFriendScoresDownloadDelegate,
		managedSharedFileDelegate,
		managedPublishedFileDelegate,
		managedUpdatedFileDelegate,
		managedDeletedFileDelegate,
		managedEnumeratedPublishedFilesDelegate,
		managedEnumeratedSubscribedFilesDelegate,
		managedReceivedFileInfoDelegate,
		managedGotUGCDetailsDelegate,
		managedGotUserPublishedItemVoteDetailsDelegate
	);
	*/

	return true;
}

uint32_t GetAppID()
{
	//return SteamUtils()->GetAppID();
	return (uint32_t) 0;
}

int GetAppBuildId() { return 0; }
int GetCurrentStats() { return 0; }
bool IsSubscribedApp(uint32_t appID) { return false; }
char *GetLaunchQueryParam(char *paramName) { return ""; }

void ActivateFriendsOverlay()
{
	//SteamFriends()->ActivateGameOverlay("Settings");
}

void ActivateStatsOverlay()
{
	//SteamFriends()->ActivateGameOverlay("Achievements");
}

void ActivateWebPage(const char *URL)
{
	//SteamFriends()->ActivateGameOverlayToWebPage(URL);
}

void OpenFullGameStorePage(const uint32_t appID)
{
	//SteamFriends()->ActivateGameOverlayToStore(appID, k_EOverlayToStoreFlag_None);
}

void FillFriendResults(
	uint64_t *resultArray,
	const int32_t numEntries
) {
	/*
	int32_t index = 0;
	LeaderboardEntry_t filler;
	*/

	/* Sometimes you get fun numbers like eleventy billion, so here we are. */
	/*
	if (numEntries > 100)
	{
		printf(
			"NO. You do NOT have %i entries Steam. STAHP IT.\n",
			numEntries
		);
		return;
	}

	for (int i = 0; i < numEntries; i++)
	{
		SteamUserStats()->GetDownloadedLeaderboardEntry(
			callbackContainer->resultLeaderboardHandle,
			i,
			&filler,
			NULL,
			0
		);

		resultArray[index++] = callbackContainer->leaderboardHandle;
		resultArray[index++] = filler.m_nScore;
		resultArray[index++] = filler.m_steamIDUser.GetAccountID();

		printf(
			"Handle: %" PRIu64 ", Score: %" PRIu64 ", Account: %" PRIu64 "\n",
			resultArray[index - 3],
			resultArray[index - 2],
			resultArray[index - 1]
		);
	}
	*/
}

bool IsOverlayEnabled()
{
	//return SteamUtils()->IsOverlayEnabled();
	return false;
}

bool ShowGamepadTextInput(
	const bool passwordMode,
	const bool multipleLines,
	const char *description,
	const uint32_t charMax
) {
	/*
	return SteamUtils()->ShowGamepadTextInput(
		passwordMode ?
			k_EGamepadTextInputModePassword :
			k_EGamepadTextInputModeNormal,
		multipleLines ?
			k_EGamepadTextInputLineModeMultipleLines :
			k_EGamepadTextInputLineModeSingleLine,
		description,
		charMax
	);
	*/
	return false;
}

void RunCallbacks()
{
	//SteamAPI_RunCallbacks();
}

uint32_t GetUserAccountID()
{
	//return SteamUser()->GetSteamID().GetAccountID();
	return (uint32_t) 0;
}

const char *GetFriendNameByID(const uint32_t friendSteamID)
{
	/*
	CSteamID newSteamID(
		friendSteamID,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);
	return SteamFriends()->GetFriendPersonaName(newSteamID);
	*/
	return "";
}

const char *GetPlayersName()
{
	//return SteamFriends()->GetPersonaName();
	return "";
}

uint32_t GetFriendCount()
{
	//return SteamFriends()->GetFriendCount(k_EFriendFlagImmediate);
	return (uint32_t) 0;
}

uint32_t GetFriendByIndex(const int32_t index)
{
	/*
	return SteamFriends()->GetFriendByIndex(
		index,
		k_EFriendFlagImmediate
	).GetAccountID();
	*/
	return (uint32_t) 0;
}

uint32_t GetSmallFriendAvatar(const uint32_t friendSteamID)
{
	/*
	CSteamID newSteamID(
		friendSteamID,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);
	return SteamFriends()->GetSmallFriendAvatar(newSteamID);
	*/
	return (uint32_t) 0;
}

uint32_t GetMediumFriendAvatar(const uint32_t friendSteamID)
{
	/*
	CSteamID newSteamID(
		friendSteamID,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);
	return SteamFriends()->GetMediumFriendAvatar(newSteamID);
	*/
	return (uint32_t) 0;
}

uint32_t GetLargeFriendAvatar(const uint32_t friendSteamID)
{
	/*
	CSteamID newSteamID(
		friendSteamID,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);
	return SteamFriends()->GetLargeFriendAvatar(newSteamID);
	*/
	return (uint32_t) 0;
}

bool GetImageSize(const int iImage, uint32_t *pnWidth, uint32_t *pnHeight)
{
	//return SteamUtils()->GetImageSize(iImage, pnWidth, pnHeight);
	return false;
}

bool GetImageRGBA(const int iImage, unsigned char *pubDest, const int nDestBufferSize)
{
	/*
	return SteamUtils()->GetImageRGBA(
		iImage,
		(uint8_t*) pubDest,
		nDestBufferSize
	);
	*/
	return false;
}

const char *GetCurrentGameLanguage()
{
	//return SteamApps()->GetCurrentGameLanguage();
	return "";
}

void Shutdown()
{
	/*
	delete callbackContainer;

	SteamAPI_Shutdown();
	*/
}

static int64_t lastUsedRequestID = 0;
int64_t GetNextRequestID()
{
	return ++lastUsedRequestID;
}

/* Steam::Filesystem */

bool IsCloudEnabled()
{
	/*
	return (	SteamRemoteStorage()->IsCloudEnabledForAccount() &&
			SteamRemoteStorage()->IsCloudEnabledForApp()	);
	*/
	return false;
}

int32_t GetFileSize(const char *name)
{
	//return SteamRemoteStorage()->GetFileSize(name);
	return (int32_t) 0;
}

void WriteFile(const char *name, unsigned char *data, const int32_t size)
{
	//SteamRemoteStorage()->FileWrite(name, data, size);
}

int32_t ReadFile(const char *name, unsigned char *data, const int32_t byteCount)
{
	//return SteamRemoteStorage()->FileRead(name, data, byteCount);
	return (int32_t) 0;
}

void DeleteFile(const char *name)
{
	//SteamRemoteStorage()->FileDelete(name);
}

void ShareFile(const char *name)
{
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageFileShareResult_t> fileSharedResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->FileShare(name);

	if (hSteamAPICall != 0)
	{
		fileSharedResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::SharedFile
		);
	}
	else
	{
		printf("Steam file share did not happen! D:\n");
	}
	*/
}

bool FileExists(const char *name)
{
	//return SteamRemoteStorage()->FileExists(name);
	return false;
}

bool GetByteQuota(int32_t *total, int32_t *available)
{
	//return SteamRemoteStorage()->GetQuota(total, available);
	return false;
}

/* 300 is arbitrary. Just so you know. -flibit */
static char folder[300];
char *GetUserDataFolder()
{
	/*
	SteamUser()->GetUserDataFolder(folder, 300);
	return folder;
	*/
	return "";
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
) {
	/*
	static CCallResult<SteamCallbackContainer, RemoteStoragePublishFileResult_t> filePublishResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->PublishWorkshopFile(
		name,
		previewName,
		appid,
		title,
		description,
		(ERemoteStoragePublishedFileVisibility) visibility,
		(SteamParamStringArray_t *)tags,
		(EWorkshopFileType) type
	);

	if (hSteamAPICall != 0)
	{
		filePublishResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::PublishedFile
		);
	}
	else
	{
		printf("Steam file publish did not happen! D:\n");
	}
	*/
}

void UpdatePublishedFile(
	const uint64_t fileID,
	const char *name,
	const char *previewName,
	const char *title,
	const char *description,
	void *tags,
	const EFileVisibility visibility
) {
	/* TODO: Tags! -K */
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageUpdatePublishedFileResult_t> fileUpdateResult;

	PublishedFileUpdateHandle_t handle = SteamRemoteStorage()->CreatePublishedFileUpdateRequest(fileID);

	SteamRemoteStorage()->UpdatePublishedFileFile(handle, name);
	SteamRemoteStorage()->UpdatePublishedFilePreviewFile(handle, previewName);
	SteamRemoteStorage()->UpdatePublishedFileTitle(handle, title);
	SteamRemoteStorage()->UpdatePublishedFileDescription(handle, description);
	SteamRemoteStorage()->UpdatePublishedFileVisibility(handle, (ERemoteStoragePublishedFileVisibility) visibility);

	if (tags)
	{
		SteamRemoteStorage()->UpdatePublishedFileTags(handle, (SteamParamStringArray_t *) tags);
	}

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->CommitPublishedFileUpdate(handle);

	if (hSteamAPICall != 0)
	{
		fileUpdateResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::UpdatedFile
		);
	}
	else
	{
		printf("Steam file update did not happen! D:\n");
	}
	*/
}

void DeletePublishedFile(const uint64_t fileID)
{
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageDeletePublishedFileResult_t> fileDeleteResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->DeletePublishedFile(fileID);

	if (hSteamAPICall != 0)
	{
		fileDeleteResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::DeletedFile
		);
	}
	else
	{
		printf("Steam file delete did not happen! D:\n");
	}
	*/
}

void EnumeratePublishedFiles()
{
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageEnumerateUserPublishedFilesResult_t> enumerateFilesResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->EnumerateUserPublishedFiles(0);

	if (hSteamAPICall != 0)
	{
		enumerateFilesResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::EnumeratedPublishedFiles
		);
	}
	else
	{
		printf("Steam enumerate published files did not happen! D:\n");
	}
	*/
}

void EnumerateSubscribedFiles()
{
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageEnumerateUserSubscribedFilesResult_t> enumerateFilesResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->EnumerateUserSubscribedFiles(0);

	if (hSteamAPICall != 0)
	{
		enumerateFilesResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::EnumeratedSubscribedFiles
		);
	}
	else
	{
		printf("Steam enumerate subscribed files did not happen! D:\n");
	}
	*/
}

void GetPublishedFileInfo(const uint64_t fileID, const uint32_t secondsOld)
{
	/*
	static CCallResult<SteamCallbackContainer, RemoteStorageGetPublishedFileDetailsResult_t> receivedFileResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->GetPublishedFileDetails(fileID, secondsOld);

	if (hSteamAPICall != 0)
	{
		receivedFileResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::ReceivedFileInfo
		);
	}
	else
	{
		printf("Steam get published file info did not happen! D:\n");
	}
	*/
}

/* Steam::Stats */

void CommitStats()
{
	//SteamUserStats()->StoreStats();
}

bool RequestCurrentStats()
{
	/* An extra check to be sure the user is logged into Steam. */
	/*
	if (!SteamUser()->BLoggedOn())
	{
		printf("User is not logged into Steam. Can't get stats.");
	}

	return SteamUserStats()->RequestCurrentStats();
	*/
	return false;
}

bool RequestGlobalStats(int32_t days)
{
	//return SteamUserStats()->RequestGlobalStats(days);
	return false;
}

long long GetGlobalStatLong(const char *statID)
{
	long long stat;
	stat = 0;
	//SteamUserStats()->GetGlobalStat(statID, &stat);
	return stat;
}

int32_t GetProgressStat(const char *statID)
{
	int32_t stat;
	stat = 0;
	//SteamUserStats()->GetStat(statID, &stat);
	return stat;
}

float GetTimeStat(const char *statID)
{
	float stat;
	stat = 0.0;
	//SteamUserStats()->GetStat(statID, &stat);
	return stat;
}

void SetProgressStat(const char *statID, const int32_t newValue)
{
	/*
	if (SteamUserStats()->SetStat(statID, newValue))
	{
		if (SteamUserStats()->StoreStats())
		{
			printf("STAT SUCCESS: '%s' set: %i\n", statID, newValue);
		}
		else
		{
			printf("STAT FAILED: '%s' was set, but StoreStats() failed.\n", statID);
		}
	}
	else
	{
		printf("STAT FAILED: '%s' was NOT set.\n", statID);
	}
	*/
}

void SetTimeStat(const char *statID, const float minutesPlayed)
{
	/*
	if (SteamUserStats()->SetStat(statID, minutesPlayed))
	{
		if (SteamUserStats()->StoreStats())
		{
			printf("STAT SUCCESS: '%s' set: %f\n", statID, minutesPlayed);
		}
		else
		{
			printf("STAT FAILED: '%s' was set, but StoreStats() failed.\n", statID);
		}
	}
	else
	{
		printf("STAT FAILED: '%s' was NOT set.\n", statID);
	}
	*/
}

void ResetAllStats(bool achievementsToo)
{
	/*
	if (SteamUserStats()->ResetAllStats(achievementsToo))
	{
		printf("STAT RESET SUCCEEDED\n");
	}
	else
	{
		printf("STAT RESET FAILED!\n");
	}
	*/
}

void SetAchievement(const char *name)
{
	//SteamUserStats()->SetAchievement(name);
}

void ClearAchievement(const char *name)
{
	//SteamUserStats()->ClearAchievement(name);
}

bool IndicateAchievementProgress(
	const char *name,
	const uint32_t curProgress,
	const uint32_t maxProgress
) {
	/*
	return SteamUserStats()->IndicateAchievementProgress(
		name,
		curProgress,
		maxProgress
	);
	*/
	return false;
}

bool GetAchievementAndUnlockTime(
	const char *name,
	bool *achieved,
	uint32_t *unlockTime
) {
	/*
	return SteamUserStats()->GetAchievementAndUnlockTime(
		name,
		achieved,
		unlockTime
	);
	*/
	return false;
}

void RequestUserStats(const uint32_t userAccountId)
{
	/*
	CSteamID newSteamID(
		userAccountId,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamUserStats()->RequestUserStats(newSteamID);

	if (hSteamAPICall == 0)
	{
		printf("STEAM DONE GONE AND 'SPLODED, BRACE YOURSELF\n");
	}
	*/
}

/* This is a direct wrapper for the Steam method (which isn't documented well).
 * The return value is _probably_ a success/failure of the request but it isn't
 * stated. The example app ignores the return value.
 * -Sean
 */
bool GetUserAchievement(const uint32_t userAccountId, const char *name, bool *pbAchieved)
{
	/*
	CSteamID newSteamID(
		userAccountId,
		k_EUniversePublic,
		k_EAccountTypeIndividual
	);

	return SteamUserStats()->GetUserAchievement(newSteamID, name, pbAchieved);
	*/
	return false;
}

/* Steam::Leaderboards */

void UploadLeaderboardScore(const uint64_t handle, const int score, const bool forceUpdate)
{
	/*
	SteamUserStats()->UploadLeaderboardScore(
		handle,
		forceUpdate ?
			k_ELeaderboardUploadScoreMethodForceUpdate :
			k_ELeaderboardUploadScoreMethodKeepBest
		,
		score,
		NULL,
		0
	);
	*/
}

void GetFriendLeaderboardScores(const uint64_t leaderboardID)
{
	/*
	static CCallResult<SteamCallbackContainer, LeaderboardScoresDownloaded_t> getScoresResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamUserStats()->DownloadLeaderboardEntries(
		leaderboardID,
		k_ELeaderboardDataRequestFriends,
		0,
		100
	);

	if (hSteamAPICall != 0)
	{
		getScoresResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::GotFriendScores
		);
	}
	else
	{
		printf("STEAM DONE GONE AND 'SPLODED, BRACE YOURSELF\n");
	}
	*/
}

void FindLeaderboard(
	const char *name,
	const int32_t externID,
	const bool initializingLeaderboard
) {
	/*
	static CCallResult<SteamCallbackContainer, LeaderboardFindResult_t> findLeaderboardResult;

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamUserStats()->FindLeaderboard(name);
	if (hSteamAPICall != 0)
	{
		callbackContainer->externID = externID;
		callbackContainer->initializingLeaderboard = initializingLeaderboard;
		findLeaderboardResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::FoundLeaderboard
		);
	}
	else
	{
		printf("STEAM DONE GONE AND 'SPLODED, BRACE YOURSELF\n");
	}
	*/
}

/* Steam::DLC */

bool IsDLCInstalled(const uint32_t appID)
{
	//return SteamApps()->BIsDlcInstalled(appID);
	return false;
}

/* Steam::SteamController */

bool ControllerInit(const char *absolutePathToControllerConfigVDF)
{
	//return SteamController()->Init(absolutePathToControllerConfigVDF);
	return false;
}

bool ControllerShutdown()
{
	//return SteamController()->Shutdown();
	return false;
}

void ControllerRunFrame()
{
	//SteamController()->RunFrame();
}

bool GetControllerState(
	const uint32_t controllerIndex,
	ControllerState_t *state
) {
	/*
	return SteamController()->GetControllerState(
		controllerIndex,
		(SteamControllerState_t*) state
	);
	*/
	return false;
}

void TriggerHapticPulse(
	const uint32_t controllerIndex,
	SteamControllerPad targetPad,
	const uint16_t durationMicroSec
) {
	/*
	SteamController()->TriggerHapticPulse(
		controllerIndex,
		(ESteamControllerPad) targetPad,
		durationMicroSec
	);
	*/
}

void SetOverrideMode(const char *mode)
{
	//SteamController()->SetOverrideMode(mode);
}

void RequestUGCDetails(const uint64_t publishedFileId) 
{
	/*
	callbackContainer->ugcDetailsRequests[publishedFileId] = CCallResult<SteamCallbackContainer, SteamUGCRequestUGCDetailsResult_t>();
	CCallResult<SteamCallbackContainer, SteamUGCRequestUGCDetailsResult_t> & requestDetailsResult = 
		callbackContainer->ugcDetailsRequests[publishedFileId];

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamUGC()->RequestUGCDetails(publishedFileId);
	if (hSteamAPICall != 0)
	{
		requestDetailsResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::GotUGCDetails
		);
	}
	else
	{
		printf("Welp\n");
	}
	*/
}

void UGCDownloadToLocation(const uint64_t ugcHandle, const char * destinationPath, uint32_t priority) 
{
	//SteamRemoteStorage()->UGCDownloadToLocation(ugcHandle, destinationPath, priority);
}

void GetUGCDownloadProgress(const uint64_t ugcHandle, int32_t * bytesDownloaded, int32_t * bytesExpected) 
{
	//SteamRemoteStorage()->GetUGCDownloadProgress(ugcHandle, bytesDownloaded, bytesExpected);
}

void UnsubscribePublishedFile(const uint64_t publishedFileId) 
{
	//SteamRemoteStorage()->UnsubscribePublishedFile(publishedFileId);
}

void SetUserPublishedFileAction(const uint64_t publishedFileId, int eAction)
{
	//SteamRemoteStorage()->SetUserPublishedFileAction(publishedFileId, (EWorkshopFileAction)eAction);
}

void UpdateUserPublishedItemVote(const uint64_t publishedFileId, int voteUp)
{
	//SteamRemoteStorage()->UpdateUserPublishedItemVote(publishedFileId, voteUp != 0);
}

void GetUserPublishedItemVoteDetails(const uint64_t publishedFileId)
{
	/*
	callbackContainer->voteDetailsRequests[publishedFileId] = CCallResult<SteamCallbackContainer, RemoteStorageUserVoteDetails_t>();
	CCallResult<SteamCallbackContainer, RemoteStorageUserVoteDetails_t> & requestDetailsResult = 
		callbackContainer->voteDetailsRequests[publishedFileId];

	SteamAPICall_t hSteamAPICall = 0;
	hSteamAPICall = SteamRemoteStorage()->GetUserPublishedItemVoteDetails(publishedFileId);
	if (hSteamAPICall != 0)
	{
		requestDetailsResult.Set(
			hSteamAPICall,
			callbackContainer,
			&SteamCallbackContainer::GotUserPublishedItemVoteDetails
		);
	}
	else
	{
		callbackContainer->gotUGCDetailsDelegate(
			-1,
			publishedFileId,
			0, 0, 0, 0, 0, 0, 0
		);
	}
	*/
}

bool GetRequestUGCDetailsStatus(const uint64_t publishedFileId)
{
	/*
	CCallResult<SteamCallbackContainer, SteamUGCRequestUGCDetailsResult_t> & requestDetailsResult = 
		callbackContainer->ugcDetailsRequests[publishedFileId];

	return requestDetailsResult.IsActive();
	*/
	return false;
}
