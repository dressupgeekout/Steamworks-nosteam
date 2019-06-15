// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerUGC {
		///  Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.
		public static UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage) {
			return (UGCQueryHandle_t) 0;
		}

		///  Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage) {
			return (UGCQueryHandle_t) 0;
		}

		///  Query for all matching UGC using the new deep paging interface. Creator app id or consumer app id must be valid and be set to the current running app. pchCursor should be set to NULL or "*" to get the first result set.
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, string pchCursor = null) {
			return (UGCQueryHandle_t) 0;
		}

		///  Query for the details of the given published file ids (the RequestUGCDetails call is deprecated and replaced with this)
		public static UGCQueryHandle_t CreateQueryUGCDetailsRequest(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (UGCQueryHandle_t) 0;
		}

		///  Send the query to Steam
		public static SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle) {
			return (SteamAPICall_t) 0;
		}

		///  Retrieve an individual result after receiving the callback for querying UGC
		public static bool GetQueryUGCResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t pDetails) {
			pDetails = new SteamUGCDetails_t();
			return false;
		}

		public static bool GetQueryUGCPreviewURL(UGCQueryHandle_t handle, uint index, out string pchURL, uint cchURLSize) {
			pchURL = "";
			return false;
		}

		public static bool GetQueryUGCMetadata(UGCQueryHandle_t handle, uint index, out string pchMetadata, uint cchMetadatasize) {
			pchMetadata = "";
			return false;
		}

		public static bool GetQueryUGCChildren(UGCQueryHandle_t handle, uint index, PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries) {
			return false;
		}

		public static bool GetQueryUGCStatistic(UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, out ulong pStatValue) {
			pStatValue = (ulong) 0;
			return false;
		}

		public static uint GetQueryUGCNumAdditionalPreviews(UGCQueryHandle_t handle, uint index) {
			return (uint) 0;
		}

		public static bool GetQueryUGCAdditionalPreview(UGCQueryHandle_t handle, uint index, uint previewIndex, out string pchURLOrVideoID, uint cchURLSize, out string pchOriginalFileName, uint cchOriginalFileNameSize, out EItemPreviewType pPreviewType) {
			pchURLOrVideoID = "";
			pchOriginalFileName = "";
			pPreviewType = (EItemPreviewType) 0;
			return false;
		}

		public static uint GetQueryUGCNumKeyValueTags(UGCQueryHandle_t handle, uint index) {
			return (uint) 0;
		}

		public static bool GetQueryUGCKeyValueTag(UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string pchKey, uint cchKeySize, out string pchValue, uint cchValueSize) {
			pchKey = "";
			pchValue = "";
			return false;
		}

		///  Release the request to free up memory, after retrieving results
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle) {
			return false;
		}

		///  Options to set for querying UGC
		public static bool AddRequiredTag(UGCQueryHandle_t handle, string pTagName) {
			return false;
		}

		public static bool AddExcludedTag(UGCQueryHandle_t handle, string pTagName) {
			return false;
		}
		public static bool SetReturnOnlyIDs(UGCQueryHandle_t handle, bool bReturnOnlyIDs) {
			return false;
		}
		public static bool SetReturnKeyValueTags(UGCQueryHandle_t handle, bool bReturnKeyValueTags) {
			return false;
		}
		public static bool SetReturnLongDescription(UGCQueryHandle_t handle, bool bReturnLongDescription) {
			return false;
		}
		public static bool SetReturnMetadata(UGCQueryHandle_t handle, bool bReturnMetadata) {
			return false;
		}
		public static bool SetReturnChildren(UGCQueryHandle_t handle, bool bReturnChildren) {
			return false;
		}
		public static bool SetReturnAdditionalPreviews(UGCQueryHandle_t handle, bool bReturnAdditionalPreviews) {
			return false;
		}
		public static bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool bReturnTotalOnly) {
			return false;
		}
		public static bool SetReturnPlaytimeStats(UGCQueryHandle_t handle, uint unDays) {
			return false;
		}
		public static bool SetLanguage(UGCQueryHandle_t handle, string pchLanguage) {
			return false;
		}
		public static bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint unMaxAgeSeconds) {
			return false;
		}

		///  Options only for querying user UGC
		public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string pMatchCloudFileName) {
			return false;
		}

		///  Options only for querying all UGC
		public static bool SetMatchAnyTag(UGCQueryHandle_t handle, bool bMatchAnyTag) {
			return false;
		}

		public static bool SetSearchText(UGCQueryHandle_t handle, string pSearchText) {
			return false;
		}
		public static bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint unDays) {
			return false;
		}
		public static bool AddRequiredKeyValueTag(UGCQueryHandle_t handle, string pKey, string pValue) {
			return false;
		}

		///  DEPRECATED - Use CreateQueryUGCDetailsRequest call above instead!
		public static SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds) {
			return (SteamAPICall_t) 0;
		}

		///  Steam Workshop Creator API
		///  create new item for this app with no content attached yet
		public static SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType) {
			return (SteamAPICall_t) 0;
		}

		///  start an UGC item update. Set changed properties before commiting update with CommitItemUpdate()
		public static UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID) {
			return (UGCUpdateHandle_t) 0;
		}

		///  change the title of an UGC item
		public static bool SetItemTitle(UGCUpdateHandle_t handle, string pchTitle) {
			return false;
		}

		///  change the description of an UGC item
		public static bool SetItemDescription(UGCUpdateHandle_t handle, string pchDescription) {
			return false;
		}

		///  specify the language of the title or description that will be set
		public static bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, string pchLanguage) {
			return false;
		}

		///  change the metadata of an UGC item (max = k_cchDeveloperMetadataMax)
		public static bool SetItemMetadata(UGCUpdateHandle_t handle, string pchMetaData) {
			return false;
		}

		///  change the visibility of an UGC item
		public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility) {
			return false;
		}

		///  change the tags of an UGC item
		public static bool SetItemTags(UGCUpdateHandle_t updateHandle, System.Collections.Generic.IList<string> pTags) {
			return false;
		}

		///  update item content from this local folder
		public static bool SetItemContent(UGCUpdateHandle_t handle, string pszContentFolder) {
			return false;
		}

		///   change preview image file for this item. pszPreviewFile points to local image file, which must be under 1MB in size
		public static bool SetItemPreview(UGCUpdateHandle_t handle, string pszPreviewFile) {
			return false;
		}

		///   use legacy upload for a single small file. The parameter to SetItemContent() should either be a directory with one file or the full path to the file.  The file must also be less than 10MB in size.
		public static bool SetAllowLegacyUpload(UGCUpdateHandle_t handle, bool bAllowLegacyUpload) {
			return false;
		}

		///  remove any existing key-value tags with the specified key
		public static bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, string pchKey) {
			return false;
		}

		///  add new key-value tags for the item. Note that there can be multiple values for a tag.
		public static bool AddItemKeyValueTag(UGCUpdateHandle_t handle, string pchKey, string pchValue) {
			return false;
		}

		///   add preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size
		public static bool AddItemPreviewFile(UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type) {
			return false;
		}

		///   add preview video for this item
		public static bool AddItemPreviewVideo(UGCUpdateHandle_t handle, string pszVideoID) {
			return false;
		}

		///   updates an existing preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size
		public static bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint index, string pszPreviewFile) {
			return false;
		}

		///   updates an existing preview video for this item
		public static bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint index, string pszVideoID) {
			return false;
		}

		///  remove a preview by index starting at 0 (previews are sorted)
		public static bool RemoveItemPreview(UGCUpdateHandle_t handle, uint index) {
			return false;
		}

		///  commit update process started with StartItemUpdate()
		public static SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, string pchChangeNote) {
			return (SteamAPICall_t) 0;
		}

		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal) {
			punBytesProcessed = (ulong) 0;
			punBytesTotal = (ulong) 0;
			return (EItemUpdateStatus) 0;
		}

		///  Steam Workshop Consumer API
		public static SteamAPICall_t SetUserItemVote(PublishedFileId_t nPublishedFileID, bool bVoteUp) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t GetUserItemVote(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t AddItemToFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t RemoveItemFromFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		///  subscribe to this item, will be installed ASAP
		public static SteamAPICall_t SubscribeItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		///  unsubscribe from this item, will be uninstalled after game quits
		public static SteamAPICall_t UnsubscribeItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		///  number of subscribed items
		public static uint GetNumSubscribedItems() {
			return (uint) 0;
		}

		///  all subscribed item PublishFileIDs
		public static uint GetSubscribedItems(PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries) {
			return (uint) 0;
		}

		///  get EItemState flags about item on this client
		public static uint GetItemState(PublishedFileId_t nPublishedFileID) {
			return (uint) 0;
		}

		///  get info about currently installed content on disc for items that have k_EItemStateInstalled set
		///  if k_EItemStateLegacyItem is set, pchFolder contains the path to the legacy file itself (not a folder)
		public static bool GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, out uint punTimeStamp) {
			punSizeOnDisk = (ulong) 0;
			pchFolder = "";
			punTimeStamp = (uint) 0;
			return false;
		}

		///  get info about pending update for items that have k_EItemStateNeedsUpdate set. punBytesTotal will be valid after download started once
		public static bool GetItemDownloadInfo(PublishedFileId_t nPublishedFileID, out ulong punBytesDownloaded, out ulong punBytesTotal) {
			punBytesDownloaded = (ulong) 0;
			punBytesTotal = (ulong) 0;
			return false;
		}

		///  download new or update already installed item. If function returns true, wait for DownloadItemResult_t. If the item is already installed,
		///  then files on disk should not be used until callback received. If item is not subscribed to, it will be cached for some time.
		///  If bHighPriority is set, any other item download will be suspended and this item downloaded ASAP.
		public static bool DownloadItem(PublishedFileId_t nPublishedFileID, bool bHighPriority) {
			return false;
		}

		///  game servers can set a specific workshop folder before issuing any UGC commands.
		///  This is helpful if you want to support multiple game servers running out of the same install folder
		public static bool BInitWorkshopForGameServer(DepotId_t unWorkshopDepotID, string pszFolder) {
			return false;
		}

		///  SuspendDownloads( true ) will suspend all workshop downloads until SuspendDownloads( false ) is called or the game ends
		public static void SuspendDownloads(bool bSuspend) {
		}

		///  usage tracking
		public static SteamAPICall_t StartPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t StopPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t StopPlaytimeTrackingForAllItems() {
			return (SteamAPICall_t) 0;
		}

		///  parent-child relationship or dependency management
		public static SteamAPICall_t AddDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t RemoveDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		///  add/remove app dependence/requirements (usually DLC)
		public static SteamAPICall_t AddAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t RemoveAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) {
			return (SteamAPICall_t) 0;
		}

		///  request app dependencies. note that whatever callback you register for GetAppDependenciesResult_t may be called multiple times
		///  until all app dependencies have been returned
		public static SteamAPICall_t GetAppDependencies(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		///  delete the item without prompting the user
		public static SteamAPICall_t DeleteItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}
	}
}
