// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamRemoteStorage {
		/// Filenames are case-insensitive, and will be converted to lowercase automatically.
		/// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.bar" then
		/// iterate the files, the filename returned will be "foo.bar".
		/// file operations
		public static bool FileWrite(string pchFile, byte[] pvData, int cubData) {
			return false;
		}
		public static int FileRead(string pchFile, byte[] pvData, int cubDataToRead) {
			return 0;
		}
		public static SteamAPICall_t FileWriteAsync(string pchFile, byte[] pvData, uint cubData) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t FileReadAsync(string pchFile, uint nOffset, uint cubToRead) {
			return (SteamAPICall_t) 0;
		}
		public static bool FileReadAsyncComplete(SteamAPICall_t hReadCall, byte[] pvBuffer, uint cubToRead) {
			return false;
		}
		public static bool FileForget(string pchFile) { return false; }
		public static bool FileDelete(string pchFile) { return false; }
		public static SteamAPICall_t FileShare(string pchFile) {
			return (SteamAPICall_t) 0;
		}
		public static bool SetSyncPlatforms(string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform) {
			return false;
		}
		/// file operations that cause network IO
		public static UGCFileWriteStreamHandle_t FileWriteStreamOpen(string pchFile) {
			return (UGCFileWriteStreamHandle_t) 0;
		}
		public static bool FileWriteStreamWriteChunk(UGCFileWriteStreamHandle_t writeHandle, byte[] pvData, int cubData) {
			return false;
		}
		public static bool FileWriteStreamClose(UGCFileWriteStreamHandle_t writeHandle) {
			return false;
		}
		public static bool FileWriteStreamCancel(UGCFileWriteStreamHandle_t writeHandle) {
			return false;
		}
		/// file information
		public static bool FileExists(string pchFile) {
			return false;
		}
		public static bool FilePersisted(string pchFile) { return false; }
		public static int GetFileSize(string pchFile) { return 0; }
		public static long GetFileTimestamp(string pchFile) { return (long) 0; }
		public static ERemoteStoragePlatform GetSyncPlatforms(string pchFile) {
			return (ERemoteStoragePlatform) 0;
		}
		/// iteration
		public static int GetFileCount() { return 0; }
		public static string GetFileNameAndSize(int iFile, out int pnFileSizeInBytes) {
			pnFileSizeInBytes = 0;
			return "";
		}
		/// configuration management
		public static bool GetQuota(out ulong pnTotalBytes, out ulong puAvailableBytes) {
			pnTotalBytes = (ulong) 0;
			puAvailableBytes = (ulong) 0;
			return false;
		}
		public static bool IsCloudEnabledForAccount() { return false; }
		public static bool IsCloudEnabledForApp() { return false; }
		public static void SetCloudEnabledForApp(bool bEnabled) { }

		/// user generated content
		/// Downloads a UGC file.  A priority value of 0 will download the file immediately,
		/// otherwise it will wait to download the file until all downloads with a lower priority
		/// value are completed.  Downloads with equal priority will occur simultaneously.
		public static SteamAPICall_t UGCDownload(UGCHandle_t hContent, uint unPriority) {
			return (SteamAPICall_t) 0;
		}

		/// Gets the amount of data downloaded so far for a piece of content. pnBytesExpected can be 0 if function returns false
		/// or if the transfer hasn't started yet, so be careful to check for that before dividing to get a percentage
		public static bool GetUGCDownloadProgress(UGCHandle_t hContent, out int pnBytesDownloaded, out int pnBytesExpected) {
			pnBytesDownloaded = 0;
			pnBytesExpected = 0;
			return false;
		}

		/// Gets metadata for a file after it has been downloaded. This is the same metadata given in the RemoteStorageDownloadUGCResult_t call result
		public static bool GetUGCDetails(UGCHandle_t hContent, out AppId_t pnAppID, out string ppchName, out int pnFileSizeInBytes, out CSteamID pSteamIDOwner) {
			pnAppID = (AppId_t) 0;
			ppchName = "";
			pnFileSizeInBytes = 0;
			pSteamIDOwner = (CSteamID) 0;
			return false;
		}

		/// After download, gets the content of the file.
		/// Small files can be read all at once by calling this function with an offset of 0 and cubDataToRead equal to the size of the file.
		/// Larger files can be read in chunks to reduce memory usage (since both sides of the IPC client and the game itself must allocate
		/// enough memory for each chunk).  Once the last byte is read, the file is implicitly closed and further calls to UGCRead will fail
		/// unless UGCDownload is called again.
		/// For especially large files (anything over 100MB) it is a requirement that the file is read in chunks.
		public static int UGCRead(UGCHandle_t hContent, byte[] pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction) {
			return 0;
		}

		/// Functions to iterate through UGC that has finished downloading but has not yet been read via UGCRead()
		public static int GetCachedUGCCount() { return 0; }
		public static UGCHandle_t GetCachedUGCHandle(int iCachedContent) {
			return (UGCHandle_t) 0;
		}
#if _PS3 || _SERVER
		/// The following functions are only necessary on the Playstation 3. On PC &amp; Mac, the Steam client will handle these operations for you
		/// On Playstation 3, the game controls which files are stored in the cloud, via FilePersist, FileFetch, and FileForget.
		/// Connect to Steam and get a list of files in the Cloud - results in a RemoteStorageAppSyncStatusCheck_t callback
		public static void GetFileListFromServer() { }

		/// Indicate this file should be downloaded in the next sync
		public static bool FileFetch(string pchFile) { return false; }
		/// Indicate this file should be persisted in the next sync
		public static bool FilePersist(string pchFile) { return false; }
		/// Pull any requested files down from the Cloud - results in a RemoteStorageAppSyncedClient_t callback
		public static bool SynchronizeToClient() { return false; }
		/// Upload any requested files to the Cloud - results in a RemoteStorageAppSyncedServer_t callback
		public static bool SynchronizeToServer() { return false; }
		/// Reset any fetch/persist/etc requests
		public static bool ResetFileRequestState() { return false; }
#endif
		/// publishing UGC
		public static SteamAPICall_t PublishWorkshopFile(string pchFile, string pchPreviewFile, AppId_t nConsumerAppId, string pchTitle, string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, System.Collections.Generic.IList<string> pTags, EWorkshopFileType eWorkshopFileType) {
			return (SteamAPICall_t) 0;
		}
		public static PublishedFileUpdateHandle_t CreatePublishedFileUpdateRequest(PublishedFileId_t unPublishedFileId) {
			return (PublishedFileUpdateHandle_t) 0;
		}
		public static bool UpdatePublishedFileFile(PublishedFileUpdateHandle_t updateHandle, string pchFile) {
			return false;
		}
		public static bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle_t updateHandle, string pchPreviewFile) {
			return false;
		}
		public static bool UpdatePublishedFileTitle(PublishedFileUpdateHandle_t updateHandle, string pchTitle) {
			return false;
		}
		public static bool UpdatePublishedFileDescription(PublishedFileUpdateHandle_t updateHandle, string pchDescription) {
			return false;
		}
		public static bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle_t updateHandle, ERemoteStoragePublishedFileVisibility eVisibility) {
			return false;
		}
		public static bool UpdatePublishedFileTags(PublishedFileUpdateHandle_t updateHandle, System.Collections.Generic.IList<string> pTags) {
			return false;
		}
		public static SteamAPICall_t CommitPublishedFileUpdate(PublishedFileUpdateHandle_t updateHandle) {
			return (SteamAPICall_t) 0;
		}
		/// Gets published file details for the given publishedfileid.  If unMaxSecondsOld is greater than 0,
		/// cached data may be returned, depending on how long ago it was cached.  A value of 0 will force a refresh.
		/// A value of k_WorkshopForceLoadPublishedFileDetailsFromCache will use cached data if it exists, no matter how old it is.
		public static SteamAPICall_t GetPublishedFileDetails(PublishedFileId_t unPublishedFileId, uint unMaxSecondsOld) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t DeletePublishedFile(PublishedFileId_t unPublishedFileId) {
			return (SteamAPICall_t) 0;
		}
		/// enumerate the files that the current user published with this app
		public static SteamAPICall_t EnumerateUserPublishedFiles(uint unStartIndex) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t SubscribePublishedFile(PublishedFileId_t unPublishedFileId) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t EnumerateUserSubscribedFiles(uint unStartIndex) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t UnsubscribePublishedFile(PublishedFileId_t unPublishedFileId) {
			return (SteamAPICall_t) 0;
		}
		public static bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle_t updateHandle, string pchChangeDescription) {
			return false;
		}
		public static SteamAPICall_t GetPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t UpdateUserPublishedItemVote(PublishedFileId_t unPublishedFileId, bool bVoteUp) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t GetUserPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t EnumerateUserSharedWorkshopFiles(CSteamID steamId, uint unStartIndex, System.Collections.Generic.IList<string> pRequiredTags, System.Collections.Generic.IList<string> pExcludedTags) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t PublishVideo(EWorkshopVideoProvider eVideoProvider, string pchVideoAccount, string pchVideoIdentifier, string pchPreviewFile, AppId_t nConsumerAppId, string pchTitle, string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, System.Collections.Generic.IList<string> pTags) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t SetUserPublishedFileAction(PublishedFileId_t unPublishedFileId, EWorkshopFileAction eAction) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, uint unStartIndex) {
			return (SteamAPICall_t) 0;
		}
		/// this method enumerates the public view of workshop files
		public static SteamAPICall_t EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eEnumerationType, uint unStartIndex, uint unCount, uint unDays, System.Collections.Generic.IList<string> pTags, System.Collections.Generic.IList<string> pUserTags) {
			return (SteamAPICall_t) 0;
		}
		public static SteamAPICall_t UGCDownloadToLocation(UGCHandle_t hContent, string pchLocation, uint unPriority) {
			return (SteamAPICall_t) 0;
		}
	}
}
