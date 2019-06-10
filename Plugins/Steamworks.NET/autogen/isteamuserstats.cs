// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamUserStats {
		/// Ask the server to send down this user's data and achievements for this game
		public static bool RequestCurrentStats() { return false; }
		/// Data accessors
		public static bool GetStat(string pchName, out int pData) {
			pData = 0;
			return false;
		}
		public static bool GetStat(string pchName, out float pData) {
			pData = 0;
			return false;
		}
		/// Set / update data
		public static bool SetStat(string pchName, int nData) { return false; }
		public static bool SetStat(string pchName, float fData) { return false; }
		public static bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength) {
			return false;
		}
		/// Achievement flag accessors
		public static bool GetAchievement(string pchName, out bool pbAchieved) {
			pbAchieved = false;
			return false;
		}
		public static bool SetAchievement(string pchName) { return false; }
		public static bool ClearAchievement(string pchName) { return false; }
		/// Get the achievement status, and the time it was unlocked if unlocked.
		/// If the return value is true, but the unlock time is zero, that means it was unlocked before Steam
		/// began tracking achievement unlock times (December 2009). Time is seconds since January 1, 1970.
		public static bool GetAchievementAndUnlockTime(string pchName, out bool pbAchieved, out uint punUnlockTime) {
			pbAchieved = false;
			punUnlockTime = (uint) 0;
			return false;
		}
		/// Store the current data on the server, will get a callback when set
		/// And one callback for every new achievement
		/// If the callback has a result of k_EResultInvalidParam, one or more stats
		/// uploaded has been rejected, either because they broke constraints
		/// or were out of date. In this case the server sends back updated values.
		/// The stats should be re-iterated to keep in sync.
		public static bool StoreStats() { return false; }
		/// Achievement / GroupAchievement metadata
		/// Gets the icon of the achievement, which is a handle to be used in ISteamUtils::GetImageRGBA(), or 0 if none set.
		/// A return value of 0 may indicate we are still fetching data, and you can wait for the UserAchievementIconFetched_t callback
		/// which will notify you when the bits are ready. If the callback still returns zero, then there is no image set for the
		/// specified achievement.
		public static int GetAchievementIcon(string pchName) { return 0; }
		/// Get general attributes for an achievement. Accepts the following keys:
		/// - "name" and "desc" for retrieving the localized achievement name and description (returned in UTF8)
		/// - "hidden" for retrieving if an achievement is hidden (returns "0" when not hidden, "1" when hidden)
		public static string GetAchievementDisplayAttribute(string pchName, string pchKey) {
			return "";
		}
		/// Achievement progress - triggers an AchievementProgress callback, that is all.
		/// Calling this w/ N out of N progress will NOT set the achievement, the game must still do that.
		public static bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress) {
			return false;
		}
		/// Used for iterating achievements. In general games should not need these functions because they should have a
		/// list of existing achievements compiled into them
		public static uint GetNumAchievements() { return (uint) 0; }
		/// Get achievement name iAchievement in [0,GetNumAchievements)
		public static string GetAchievementName(uint iAchievement) { return ""; }
		/// Friends stats &amp; achievements
		/// downloads stats for the user
		/// returns a UserStatsReceived_t received when completed
		/// if the other user has no stats, UserStatsReceived_t.m_eResult will be set to k_EResultFail
		/// these stats won't be auto-updated; you'll need to call RequestUserStats() again to refresh any data
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser) {
			return (SteamAPICall_t) 0;
		}
		/// requests stat information for a user, usable after a successful call to RequestUserStats()
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData) {
			pData = 0;
			return false;
		}
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData) {
			pData = (float) 0.0;
			return false;
		}
		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved) {
			pbAchieved = false;
			return false;
		}
		/// See notes for GetAchievementAndUnlockTime above
		public static bool GetUserAchievementAndUnlockTime(CSteamID steamIDUser, string pchName, out bool pbAchieved, out uint punUnlockTime) {
			pbAchieved = false;
			punUnlockTime = (uint) 0;
			return false;
		}
		/// Reset stats
		public static bool ResetAllStats(bool bAchievementsToo) { return false; }
		/// Leaderboard functions
		/// asks the Steam back-end for a leaderboard by name, and will create it if it's not yet
		/// This call is asynchronous, with the result returned in LeaderboardFindResult_t
		public static SteamAPICall_t FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType) {
			return (SteamAPICall_t) 0;
		}
		/// as above, but won't create the leaderboard if it's not found
		/// This call is asynchronous, with the result returned in LeaderboardFindResult_t
		public static SteamAPICall_t FindLeaderboard(string pchLeaderboardName) {
			return (SteamAPICall_t) 0;
		}
		/// returns the name of a leaderboard
		public static string GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard) {
			return "";
		}
		/// returns the total number of entries in a leaderboard, as of the last request
		public static int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard) {
			return 0;
		}
		/// returns the sort method of the leaderboard
		public static ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard) {
			return (ELeaderboardSortMethod) 0;
		}
		/// returns the display type of the leaderboard
		public static ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard) {
			return (ELeaderboardDisplayType) 0;
		}
		/// Asks the Steam back-end for a set of rows in the leaderboard.
		/// This call is asynchronous, with the result returned in LeaderboardScoresDownloaded_t
		/// LeaderboardScoresDownloaded_t will contain a handle to pull the results from GetDownloadedLeaderboardEntries() (below)
		/// You can ask for more entries than exist, and it will return as many as do exist.
		/// k_ELeaderboardDataRequestGlobal requests rows in the leaderboard from the full table, with nRangeStart &amp; nRangeEnd in the range [1, TotalEntries]
		/// k_ELeaderboardDataRequestGlobalAroundUser requests rows around the current user, nRangeStart being negate
		/// e.g. DownloadLeaderboardEntries( hLeaderboard, k_ELeaderboardDataRequestGlobalAroundUser, -3, 3 ) will return 7 rows, 3 before the user, 3 after
		/// k_ELeaderboardDataRequestFriends requests all the rows for friends of the current user
		public static SteamAPICall_t DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd) {
			return (SteamAPICall_t) 0;
		}
		/// as above, but downloads leaderboard entries for an arbitrary set of users - ELeaderboardDataRequest is k_ELeaderboardDataRequestUsers
		/// if a user doesn't have a leaderboard entry, they won't be included in the result
		/// a max of 100 users can be downloaded at a time, with only one outstanding call at a time
		public static SteamAPICall_t DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, CSteamID[] prgUsers, int cUsers) {
			return (SteamAPICall_t) 0;
		}
		/// Returns data about a single leaderboard entry
		/// use a for loop from 0 to LeaderboardScoresDownloaded_t::m_cEntryCount to get all the downloaded entries
		/// e.g.
		/// 		void OnLeaderboardScoresDownloaded( LeaderboardScoresDownloaded_t *pLeaderboardScoresDownloaded )
		/// 		{
		/// 			for ( int index = 0; index &lt; pLeaderboardScoresDownloaded-&gt;m_cEntryCount; index++ )
		/// 			{
		/// 				LeaderboardEntry_t leaderboardEntry;
		/// 				int32 details[3];		// we know this is how many we've stored previously
		/// 				GetDownloadedLeaderboardEntry( pLeaderboardScoresDownloaded-&gt;m_hSteamLeaderboardEntries, index, &amp;leaderboardEntry, details, 3 );
		/// 				assert( leaderboardEntry.m_cDetails == 3 );
		/// 				...
		/// 			}
		/// once you've accessed all the entries, the data will be free'd, and the SteamLeaderboardEntries_t handle will become invalid
		public static bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, out LeaderboardEntry_t pLeaderboardEntry, int[] pDetails, int cDetailsMax) {
			pLeaderboardEntry = new LeaderboardEntry_t();
			return false;
		}
		/// Uploads a user score to the Steam back-end.
		/// This call is asynchronous, with the result returned in LeaderboardScoreUploaded_t
		/// Details are extra game-defined information regarding how the user got that score
		/// pScoreDetails points to an array of int32's, cScoreDetailsCount is the number of int32's in the list
		public static SteamAPICall_t UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int[] pScoreDetails, int cScoreDetailsCount) {
			return (SteamAPICall_t) 0;
		}
		/// Attaches a piece of user generated content the user's entry on a leaderboard.
		/// hContent is a handle to a piece of user generated content that was shared using ISteamUserRemoteStorage::FileShare().
		/// This call is asynchronous, with the result returned in LeaderboardUGCSet_t.
		public static SteamAPICall_t AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC) {
			return (SteamAPICall_t) 0;
		}
		/// Retrieves the number of players currently playing your game (online + offline)
		/// This call is asynchronous, with the result returned in NumberOfCurrentPlayers_t
		public static SteamAPICall_t GetNumberOfCurrentPlayers() {
			return (SteamAPICall_t) 0;
		}
		/// Requests that Steam fetch data on the percentage of players who have received each achievement
		/// for the game globally.
		/// This call is asynchronous, with the result returned in GlobalAchievementPercentagesReady_t.
		public static SteamAPICall_t RequestGlobalAchievementPercentages() {
			return (SteamAPICall_t) 0;
		}
		/// Get the info on the most achieved achievement for the game, returns an iterator index you can use to fetch
		/// the next most achieved afterwards.  Will return -1 if there is no data on achievement
		/// percentages (ie, you haven't called RequestGlobalAchievementPercentages and waited on the callback).
		public static int GetMostAchievedAchievementInfo(out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved) {
			pchName = "";
			pflPercent = (float) 0.0;
			pbAchieved = false;
			return 0;
		}
		/// Get the info on the next most achieved achievement for the game. Call this after GetMostAchievedAchievementInfo or another
		/// GetNextMostAchievedAchievementInfo call passing the iterator from the previous call. Returns -1 after the last
		/// achievement has been iterated.
		public static int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved) {
			pchName = "";
			pflPercent = (float) 0.0;
			pbAchieved = false;
			return 0;
		}
		/// Returns the percentage of users who have achieved the specified achievement.
		public static bool GetAchievementAchievedPercent(string pchName, out float pflPercent) {
			pflPercent = (float) 0.0;
			return false;
		}
		/// Requests global stats data, which is available for stats marked as "aggregated".
		/// This call is asynchronous, with the results returned in GlobalStatsReceived_t.
		/// nHistoryDays specifies how many days of day-by-day history to retrieve in addition
		/// to the overall totals. The limit is 60.
		public static SteamAPICall_t RequestGlobalStats(int nHistoryDays) {
			return (SteamAPICall_t) 0;
		}
		/// Gets the lifetime totals for an aggregated stat
		public static bool GetGlobalStat(string pchStatName, out long pData) {
			pData = (long) 0;
			return false;
		}
		public static bool GetGlobalStat(string pchStatName, out double pData) {
			pData = (double) 0;
			return false;
		}
		/// Gets history for an aggregated stat. pData will be filled with daily values, starting with today.
		/// So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago,
		/// etc. cubData is the size in bytes of the pubData buffer. Returns the number of
		/// elements actually set.
		public static int GetGlobalStatHistory(string pchStatName, long[] pData, uint cubData) {
			return 0;
		}
		public static int GetGlobalStatHistory(string pchStatName, double[] pData, uint cubData) {
			return 0;
		}
#if _PS3
		/// Call to kick off installation of the PS3 trophies. This call is asynchronous, and the results will be returned in a PS3TrophiesInstalled_t
		/// callback.
		public static bool InstallPS3Trophies() { return false; }
		/// Returns the amount of space required at boot to install trophies. This value can be used when comparing the amount of space needed
		/// by the game to the available space value passed to the game at boot. The value is set during InstallPS3Trophies().
		public static ulong GetTrophySpaceRequiredBeforeInstall() { return (ulong) 0; }
		/// On PS3, user stats &amp; achievement progress through Steam must be stored with the user's saved game data.
		/// At startup, before calling RequestCurrentStats(), you must pass the user's stats data to Steam via this method.
		/// If you do not have any user data, call this function with pvData = NULL and cubData = 0
		public static bool SetUserStatsData(IntPtr pvData, uint cubData) { return false; }
		/// Call to get the user's current stats data. You should retrieve this data after receiving successful UserStatsReceived_t &amp; UserStatsStored_t
		/// callbacks, and store the data with the user's save game data. You can call this method with pvData = NULL and cubData = 0 to get the required
		/// buffer size.
		public static bool GetUserStatsData(IntPtr pvData, uint cubData, out uint pcubWritten) {
			pcubWritten = (uint) 0;
			return false;
		}
#endif
	}
}
