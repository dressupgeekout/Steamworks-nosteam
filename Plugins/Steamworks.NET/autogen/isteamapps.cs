// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamApps {
		public static bool BIsSubscribed() {
			return false;
		}

		public static bool BIsLowViolence() {
			return false;
		}

		public static bool BIsCybercafe() {
			return false;
		}

		public static bool BIsVACBanned() {
			return false;
		}

		public static string GetCurrentGameLanguage() {
			return "english";
		}

		public static string GetAvailableGameLanguages() {
			return "english";
		}

		/// <summary>
		/// <para> only use this member if you need to check ownership of another game related to yours, a demo for example</para>
		/// </summary>
		public static bool BIsSubscribedApp(AppId_t appID) {
			return false;
		}

		/// <summary>
		/// <para> Takes AppID of DLC and checks if the user owns the DLC &amp; if the DLC is installed</para>
		/// </summary>
		public static bool BIsDlcInstalled(AppId_t appID) {
			return false;
		}

		/// <summary>
		/// <para> returns the Unix time of the purchase of the app</para>
		/// </summary>
		public static uint GetEarliestPurchaseUnixTime(AppId_t nAppID) {
			return (uint) 0;
		}

		/// <summary>
		/// <para> Checks if the user is subscribed to the current app through a free weekend</para>
		/// <para> This function will return false for users who have a retail or other type of license</para>
		/// <para> Before using, please ask your Valve technical contact how to package and secure your free weekened</para>
		/// </summary>
		public static bool BIsSubscribedFromFreeWeekend() {
			return false;
		}

		/// <summary>
		/// <para> Returns the number of DLC pieces for the running app</para>
		/// </summary>
		public static int GetDLCCount() {
			return 0;
		}

		/// <summary>
		/// <para> Returns metadata for DLC by index, of range [0, GetDLCCount()]</para>
		/// </summary>
		public static bool BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize) {
			pAppID = (AppId_t) 0;
			pbAvailable = false;
			pchName = "";
			return false;
		}

		/// <summary>
		/// <para> Install/Uninstall control for optional DLC</para>
		/// </summary>
		public static void InstallDLC(AppId_t nAppID) {
		}

		public static void UninstallDLC(AppId_t nAppID) {
		}

		/// <summary>
		/// <para> Request legacy cd-key for yourself or owned DLC. If you are interested in this</para>
		/// <para> data then make sure you provide us with a list of valid keys to be distributed</para>
		/// <para> to users when they purchase the game, before the game ships.</para>
		/// <para> You'll receive an AppProofOfPurchaseKeyResponse_t callback when</para>
		/// <para> the key is available (which may be immediately).</para>
		/// </summary>
		public static void RequestAppProofOfPurchaseKey(AppId_t nAppID) {
		}

		/// <summary>
		/// <para> returns current beta branch name, 'public' is the default branch</para>
		/// </summary>
		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize) {
			pchName = "";
			return false;
		}

		/// <summary>
		/// <para> signal Steam that game files seems corrupt or missing</para>
		/// </summary>
		public static bool MarkContentCorrupt(bool bMissingFilesOnly) {
			return false;
		}

		/// <summary>
		/// <para> return installed depots in mount order</para>
		/// </summary>
		public static uint GetInstalledDepots(AppId_t appID, DepotId_t[] pvecDepots, uint cMaxDepots) {
			return (uint) 0;
		}

		/// <summary>
		/// <para> returns current app install folder for AppID, returns folder name length</para>
		/// </summary>
		public static uint GetAppInstallDir(AppId_t appID, out string pchFolder, uint cchFolderBufferSize) {
			pchFolder = "";
			return (uint) 0;
		}

		/// <summary>
		/// <para> returns true if that app is installed (not necessarily owned)</para>
		/// </summary>
		public static bool BIsAppInstalled(AppId_t appID) {
			return false;
		}

		/// <summary>
		/// <para> returns the SteamID of the original owner. If this CSteamID is different from ISteamUser::GetSteamID(),</para>
		/// <para> the user has a temporary license borrowed via Family Sharing</para>
		/// </summary>
		public static CSteamID GetAppOwner() {
			return (CSteamID) 0;
		}

		/// <summary>
		/// <para> Returns the associated launch param if the game is run via steam://run/&lt;appid&gt;//?param1=value1&amp;param2=value2&amp;param3=value3 etc.</para>
		/// <para> Parameter names starting with the character '@' are reserved for internal use and will always return and empty string.</para>
		/// <para> Parameter names starting with an underscore '_' are reserved for steam features -- they can be queried by the game,</para>
		/// <para> but it is advised that you not param names beginning with an underscore for your own features.</para>
		/// <para> Check for new launch parameters on callback NewUrlLaunchParameters_t</para>
		/// </summary>
		public static string GetLaunchQueryParam(string pchKey) {
			return "";
		}

		/// <summary>
		/// <para> get download progress for optional DLC</para>
		/// </summary>
		public static bool GetDlcDownloadProgress(AppId_t nAppID, out ulong punBytesDownloaded, out ulong punBytesTotal) {
			punBytesDownloaded = (ulong) 0;
			punBytesTotal = (ulong) 0;
			return false;
		}

		/// <summary>
		/// <para> return the buildid of this app, may change at any time based on backend updates to the game</para>
		/// </summary>
		public static int GetAppBuildId() {
			return 0;
		}

		/// <summary>
		/// <para> Request all proof of purchase keys for the calling appid and asociated DLC.</para>
		/// <para> A series of AppProofOfPurchaseKeyResponse_t callbacks will be sent with</para>
		/// <para> appropriate appid values, ending with a final callback where the m_nAppId</para>
		/// <para> member is k_uAppIdInvalid (zero).</para>
		/// </summary>
		public static void RequestAllProofOfPurchaseKeys() {
		}

		public static SteamAPICall_t GetFileDetails(string pszFileName) {
			return (SteamAPICall_t) 0;
		}

		/// <summary>
		/// <para> Get command line if game was launched via Steam URL, e.g. steam://run/&lt;appid&gt;//&lt;command line&gt;/.</para>
		/// <para> This method of passing a connect string (used when joining via rich presence, accepting an</para>
		/// <para> invite, etc) is preferable to passing the connect string on the operating system command</para>
		/// <para> line, which is a security risk.  In order for rich presence joins to go through this</para>
		/// <para> path and not be placed on the OS command line, you must set a value in your app's</para>
		/// <para> configuration on Steam.  Ask Valve for help with this.</para>
		/// <para> If game was already running and launched again, the NewUrlLaunchParameters_t will be fired.</para>
		/// </summary>
		public static int GetLaunchCommandLine(out string pszCommandLine, int cubCommandLine) {
			pszCommandLine = "";
			return 0;
		}

		/// <summary>
		/// <para> Check if user borrowed this game via Family Sharing, If true, call GetAppOwner() to get the lender SteamID</para>
		/// </summary>
		public static bool BIsSubscribedFromFamilySharing() {
			return false;
		}
	}
}
