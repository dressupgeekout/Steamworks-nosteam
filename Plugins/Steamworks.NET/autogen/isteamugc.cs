// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamUGC {
		/// <para> Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.</para>
		public static UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage) {
			return (UGCQueryHandle_t) 0;
		}

		/// <para> Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app. unPage should start at 1.</para>
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage) {
			return (UGCQueryHandle_t) 0;
		}

		/// <para> Query for all matching UGC using the new deep paging interface. Creator app id or consumer app id must be valid and be set to the current running app. pchCursor should be set to NULL or "*" to get the first result set.</para>
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, string pchCursor = null) {
			return (UGCQueryHandle_t) 0;
		}

		/// <para> Query for the details of the given published file ids (the RequestUGCDetails call is deprecated and replaced with this)</para>
		public static UGCQueryHandle_t CreateQueryUGCDetailsRequest(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (UGCQueryHandle_t) 0;
		}

		/// <para> Send the query to Steam</para>
		public static SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Retrieve an individual result after receiving the callback for querying UGC</para>
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

		/// <para> Release the request to free up memory, after retrieving results</para>
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle) {
			return false;
		}

		/// <para> Options to set for querying UGC</para>
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

		/// <para> Options only for querying user UGC</para>
		public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string pMatchCloudFileName) {
			return false;
		}

		/// <para> Options only for querying all UGC</para>
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

		/// <para> DEPRECATED - Use CreateQueryUGCDetailsRequest call above instead!</para>
		public static SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds) {
			return (SteamAPICall_t) 0;
		}

		/// <para> Steam Workshop Creator API</para>
		/// <para> create new item for this app with no content attached yet</para>
		public static SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType) {
			return (SteamAPICall_t) 0;
		}

		/// <para> start an UGC item update. Set changed properties before commiting update with CommitItemUpdate()</para>
		public static UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID) {
			return (UGCUpdateHandle_t) 0;
		}

		/// <para> change the title of an UGC item</para>
		public static bool SetItemTitle(UGCUpdateHandle_t handle, string pchTitle) {
			return false;
		}

		/// <para> change the description of an UGC item</para>
		public static bool SetItemDescription(UGCUpdateHandle_t handle, string pchDescription) {
			return false;
		}

		/// <para> specify the language of the title or description that will be set</para>
		public static bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, string pchLanguage) {
			return false;
		}

		/// <para> change the metadata of an UGC item (max = k_cchDeveloperMetadataMax)</para>
		public static bool SetItemMetadata(UGCUpdateHandle_t handle, string pchMetaData) {
			return false;
		}

		/// <para> change the visibility of an UGC item</para>
		public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility) {
			return false;
		}

		/// <para> change the tags of an UGC item</para>
		public static bool SetItemTags(UGCUpdateHandle_t updateHandle, System.Collections.Generic.IList<string> pTags) {
			return false;
		}

		/// <para> update item content from this local folder</para>
		public static bool SetItemContent(UGCUpdateHandle_t handle, string pszContentFolder) {
			return false;
		}

		/// <para>  change preview image file for this item. pszPreviewFile points to local image file, which must be under 1MB in size</para>
		public static bool SetItemPreview(UGCUpdateHandle_t handle, string pszPreviewFile) {
			return false;
		}

		/// <para>  use legacy upload for a single small file. The parameter to SetItemContent() should either be a directory with one file or the full path to the file.  The file must also be less than 10MB in size.</para>
		public static bool SetAllowLegacyUpload(UGCUpdateHandle_t handle, bool bAllowLegacyUpload) {
			return false;
		}

		/// <para> remove any existing key-value tags with the specified key</para>
		public static bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, string pchKey) {
			return false;
		}

		/// <para> add new key-value tags for the item. Note that there can be multiple values for a tag.</para>
		public static bool AddItemKeyValueTag(UGCUpdateHandle_t handle, string pchKey, string pchValue) {
			return false;
		}

		/// <para>  add preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size</para>
		public static bool AddItemPreviewFile(UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type) {
			return false;
		}

		/// <para>  add preview video for this item</para>
		public static bool AddItemPreviewVideo(UGCUpdateHandle_t handle, string pszVideoID) {
			return false;
		}

		/// <para>  updates an existing preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size</para>
		public static bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint index, string pszPreviewFile) {
			return false;
		}

		/// <para>  updates an existing preview video for this item</para>
		public static bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint index, string pszVideoID) {
			return false;
		}

		/// <para> remove a preview by index starting at 0 (previews are sorted)</para>
		public static bool RemoveItemPreview(UGCUpdateHandle_t handle, uint index) {
			return false;
		}

		/// <para> commit update process started with StartItemUpdate()</para>
		public static SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, string pchChangeNote) {
			return (SteamAPICall_t) 0;
		}

		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal) {
			punBytesProcessed = (ulong) 0;
			punBytesTotal = (ulong) 0;
			return (EItemUpdateStatus) 0;
		}

		/// <para> Steam Workshop Consumer API</para>
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

		/// <para> subscribe to this item, will be installed ASAP</para>
		public static SteamAPICall_t SubscribeItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> unsubscribe from this item, will be uninstalled after game quits</para>
		public static SteamAPICall_t UnsubscribeItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> number of subscribed items</para>
		public static uint GetNumSubscribedItems() {
			return (uint) 0;
		}

		/// <para> all subscribed item PublishFileIDs</para>
		public static uint GetSubscribedItems(PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries) {
			return (uint) 0;
		}

		/// <para> get EItemState flags about item on this client</para>
		public static uint GetItemState(PublishedFileId_t nPublishedFileID) {
			return (uint) 0;
		}

		/// <para> get info about currently installed content on disc for items that have k_EItemStateInstalled set</para>
		/// <para> if k_EItemStateLegacyItem is set, pchFolder contains the path to the legacy file itself (not a folder)</para>
		public static bool GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, out uint punTimeStamp) {
			punSizeOnDisk = (ulong) 0;
			pchFolder = "";
			punTimeStamp = (uint) 0;
			return false;
		}

		/// <para> get info about pending update for items that have k_EItemStateNeedsUpdate set. punBytesTotal will be valid after download started once</para>
		public static bool GetItemDownloadInfo(PublishedFileId_t nPublishedFileID, out ulong punBytesDownloaded, out ulong punBytesTotal) {
			punBytesDownloaded = (ulong) 0;
			punBytesTotal = (ulong) 0;
			return false;
		}

		/// <para> download new or update already installed item. If function returns true, wait for DownloadItemResult_t. If the item is already installed,</para>
		/// <para> then files on disk should not be used until callback received. If item is not subscribed to, it will be cached for some time.</para>
		/// <para> If bHighPriority is set, any other item download will be suspended and this item downloaded ASAP.</para>
		public static bool DownloadItem(PublishedFileId_t nPublishedFileID, bool bHighPriority) {
			return false;
		}

		/// <para> game servers can set a specific workshop folder before issuing any UGC commands.</para>
		/// <para> This is helpful if you want to support multiple game servers running out of the same install folder</para>
		public static bool BInitWorkshopForGameServer(DepotId_t unWorkshopDepotID, string pszFolder) {
			return false;
		}

		/// <para> SuspendDownloads( true ) will suspend all workshop downloads until SuspendDownloads( false ) is called or the game ends</para>
		public static void SuspendDownloads(bool bSuspend) {
		}

		/// <para> usage tracking</para>
		public static SteamAPICall_t StartPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t StopPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t StopPlaytimeTrackingForAllItems() {
			return (SteamAPICall_t) 0;
		}

		/// <para> parent-child relationship or dependency management</para>
		public static SteamAPICall_t AddDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t RemoveDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> add/remove app dependence/requirements (usually DLC)</para>
		public static SteamAPICall_t AddAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t RemoveAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> request app dependencies. note that whatever callback you register for GetAppDependenciesResult_t may be called multiple times</para>
		/// <para> until all app dependencies have been returned</para>
		public static SteamAPICall_t GetAppDependencies(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}

		/// <para> delete the item without prompting the user</para>
		public static SteamAPICall_t DeleteItem(PublishedFileId_t nPublishedFileID) {
			return (SteamAPICall_t) 0;
		}
	}
}
