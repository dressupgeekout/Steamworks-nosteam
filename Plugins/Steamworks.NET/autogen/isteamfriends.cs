// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamFriends {
		/// <para> returns the local players name - guaranteed to not be NULL.</para>
		/// <para> this is the same name as on the users community profile page</para>
		/// <para> this is stored in UTF-8 format</para>
		/// <para> like all the other interface functions that return a char *, it's important that this pointer is not saved</para>
		/// <para> off; it will eventually be free'd or re-allocated</para>
		public static string GetPersonaName() {
			return "";
		}

		/// <para> Sets the player name, stores it on the server and publishes the changes to all friends who are online.</para>
		/// <para> Changes take place locally immediately, and a PersonaStateChange_t is posted, presuming success.</para>
		/// <para> The final results are available through the return value SteamAPICall_t, using SetPersonaNameResponse_t.</para>
		/// <para> If the name change fails to happen on the server, then an additional global PersonaStateChange_t will be posted</para>
		/// <para> to change the name back, in addition to the SetPersonaNameResponse_t callback.</para>
		public static SteamAPICall_t SetPersonaName(string pchPersonaName) {
			return (SteamAPICall_t) 0;
		}

		/// <para> gets the status of the current user</para>
		public static EPersonaState GetPersonaState() {
			return (EPersonaState) 0;
		}

		/// <para> friend iteration</para>
		/// <para> takes a set of k_EFriendFlags, and returns the number of users the client knows about who meet that criteria</para>
		/// <para> then GetFriendByIndex() can then be used to return the id's of each of those users</para>
		public static int GetFriendCount(EFriendFlags iFriendFlags) {
			return 0;
		}

		/// <para> returns the steamID of a user</para>
		/// <para> iFriend is a index of range [0, GetFriendCount())</para>
		/// <para> iFriendsFlags must be the same value as used in GetFriendCount()</para>
		/// <para> the returned CSteamID can then be used by all the functions below to access details about the user</para>
		public static CSteamID GetFriendByIndex(int iFriend, EFriendFlags iFriendFlags) {
			return (CSteamID) 0;
		}

		/// <para> returns a relationship to a user</para>
		public static EFriendRelationship GetFriendRelationship(CSteamID steamIDFriend) {
			return (EFriendRelationship) 0;
		}

		/// <para> returns the current status of the specified user</para>
		/// <para> this will only be known by the local user if steamIDFriend is in their friends list; on the same game server; in a chat room or lobby; or in a small group with the local user</para>
		public static EPersonaState GetFriendPersonaState(CSteamID steamIDFriend) {
			return (EPersonaState) 0;
		}

		/// <para> returns the name another user - guaranteed to not be NULL.</para>
		/// <para> same rules as GetFriendPersonaState() apply as to whether or not the user knowns the name of the other user</para>
		/// <para> note that on first joining a lobby, chat room or game server the local user will not known the name of the other users automatically; that information will arrive asyncronously</para>
		public static string GetFriendPersonaName(CSteamID steamIDFriend) {
			return "";
		}

		/// <para> returns true if the friend is actually in a game, and fills in pFriendGameInfo with an extra details</para>
		public static bool GetFriendGamePlayed(CSteamID steamIDFriend, out FriendGameInfo_t pFriendGameInfo) {
			pFriendGameInfo = new FriendGameInfo_t();
			return false;
		}

		/// <para> accesses old friends names - returns an empty string when their are no more items in the history</para>
		public static string GetFriendPersonaNameHistory(CSteamID steamIDFriend, int iPersonaName) {
			return "";
		}

		/// <para> friends steam level</para>
		public static int GetFriendSteamLevel(CSteamID steamIDFriend) {
			return 0;
		}

		/// <para> Returns nickname the current user has set for the specified player. Returns NULL if the no nickname has been set for that player.</para>
		/// <para> DEPRECATED: GetPersonaName follows the Steam nickname preferences, so apps shouldn't need to care about nicknames explicitly.</para>
		public static string GetPlayerNickname(CSteamID steamIDPlayer) {
			return "";
		}

		/// <para> friend grouping (tag) apis</para>
		/// <para> returns the number of friends groups</para>
		public static int GetFriendsGroupCount() {
			return 0;
		}

		/// <para> returns the friends group ID for the given index (invalid indices return k_FriendsGroupID_Invalid)</para>
		public static FriendsGroupID_t GetFriendsGroupIDByIndex(int iFG) {
			return (FriendsGroupID_t) 0;
		}

		/// <para> returns the name for the given friends group (NULL in the case of invalid friends group IDs)</para>
		public static string GetFriendsGroupName(FriendsGroupID_t friendsGroupID) {
			return "";
		}

		/// <para> returns the number of members in a given friends group</para>
		public static int GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID) {
			return 0;
		}

		/// <para> gets up to nMembersCount members of the given friends group, if fewer exist than requested those positions' SteamIDs will be invalid</para>
		public static void GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, CSteamID[] pOutSteamIDMembers, int nMembersCount) {
		}

		/// <para> returns true if the specified user meets any of the criteria specified in iFriendFlags</para>
		/// <para> iFriendFlags can be the union (binary or, |) of one or more k_EFriendFlags values</para>
		public static bool HasFriend(CSteamID steamIDFriend, EFriendFlags iFriendFlags) {
			return false;
		}

		/// <para> clan (group) iteration and access functions</para>
		public static int GetClanCount() {
			return 0;
		}

		public static CSteamID GetClanByIndex(int iClan) {
			return (CSteamID) 0;
		}

		public static string GetClanName(CSteamID steamIDClan) {
			return "";
		}

		public static string GetClanTag(CSteamID steamIDClan) {
			return "";
		}

		/// <para> returns the most recent information we have about what's happening in a clan</para>
		public static bool GetClanActivityCounts(CSteamID steamIDClan, out int pnOnline, out int pnInGame, out int pnChatting) {
			pnOnline = 0;
			pnInGame = 0;
			pnChatting = 0;
			return false;
		}

		/// <para> for clans a user is a member of, they will have reasonably up-to-date information, but for others you'll have to download the info to have the latest</para>
		public static SteamAPICall_t DownloadClanActivityCounts(CSteamID[] psteamIDClans, int cClansToRequest) {
			return (SteamAPICall_t) 0;
		}

		/// <para> iterators for getting users in a chat room, lobby, game server or clan</para>
		/// <para> note that large clans that cannot be iterated by the local user</para>
		/// <para> note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby</para>
		/// <para> steamIDSource can be the steamID of a group, game server, lobby or chat room</para>
		public static int GetFriendCountFromSource(CSteamID steamIDSource) {
			return 0;
		}

		public static CSteamID GetFriendFromSourceByIndex(CSteamID steamIDSource, int iFriend) {
			return (CSteamID) 0;
		}

		/// <para> returns true if the local user can see that steamIDUser is a member or in steamIDSource</para>
		public static bool IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource) {
			return false;
		}

		/// <para> User is in a game pressing the talk button (will suppress the microphone for all voice comms from the Steam friends UI)</para>
		public static void SetInGameVoiceSpeaking(CSteamID steamIDUser, bool bSpeaking) {
		}

		/// <para> activates the game overlay, with an optional dialog to open</para>
		/// <para> valid options include "Friends", "Community", "Players", "Settings", "OfficialGameGroup", "Stats", "Achievements",</para>
		/// <para> "chatroomgroup/nnnn"</para>
		public static void ActivateGameOverlay(string pchDialog) {
		}

		/// <para> activates game overlay to a specific place</para>
		/// <para> valid options are</para>
		/// <para>		"steamid" - opens the overlay web browser to the specified user or groups profile</para>
		/// <para>		"chat" - opens a chat window to the specified user, or joins the group chat</para>
		/// <para>		"jointrade" - opens a window to a Steam Trading session that was started with the ISteamEconomy/StartTrade Web API</para>
		/// <para>		"stats" - opens the overlay web browser to the specified user's stats</para>
		/// <para>		"achievements" - opens the overlay web browser to the specified user's achievements</para>
		/// <para>		"friendadd" - opens the overlay in minimal mode prompting the user to add the target user as a friend</para>
		/// <para>		"friendremove" - opens the overlay in minimal mode prompting the user to remove the target friend</para>
		/// <para>		"friendrequestaccept" - opens the overlay in minimal mode prompting the user to accept an incoming friend invite</para>
		/// <para>		"friendrequestignore" - opens the overlay in minimal mode prompting the user to ignore an incoming friend invite</para>
		public static void ActivateGameOverlayToUser(string pchDialog, CSteamID steamID) {
		}

		/// <para> activates game overlay web browser directly to the specified URL</para>
		/// <para> full address with protocol type is required, e.g. http://www.steamgames.com/</para>
		public static void ActivateGameOverlayToWebPage(string pchURL, EActivateGameOverlayToWebPageMode eMode = EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default) {
		}

		/// <para> activates game overlay to store page for app</para>
		public static void ActivateGameOverlayToStore(AppId_t nAppID, EOverlayToStoreFlag eFlag) {
		}

		/// <para> Mark a target user as 'played with'. This is a client-side only feature that requires that the calling user is</para>
		/// <para> in game</para>
		public static void SetPlayedWith(CSteamID steamIDUserPlayedWith) {
		}

		/// <para> activates game overlay to open the invite dialog. Invitations will be sent for the provided lobby.</para>
		public static void ActivateGameOverlayInviteDialog(CSteamID steamIDLobby) {
		}

		/// <para> gets the small (32x32) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set</para>
		public static int GetSmallFriendAvatar(CSteamID steamIDFriend) {
			return 0;
		}

		/// <para> gets the medium (64x64) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set</para>
		public static int GetMediumFriendAvatar(CSteamID steamIDFriend) {
			return 0;
		}

		/// <para> gets the large (184x184) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set</para>
		/// <para> returns -1 if this image has yet to be loaded, in this case wait for a AvatarImageLoaded_t callback and then call this again</para>
		public static int GetLargeFriendAvatar(CSteamID steamIDFriend) {
			return 0;
		}

		/// <para> requests information about a user - persona name &amp; avatar</para>
		/// <para> if bRequireNameOnly is set, then the avatar of a user isn't downloaded</para>
		/// <para> - it's a lot slower to download avatars and churns the local cache, so if you don't need avatars, don't request them</para>
		/// <para> if returns true, it means that data is being requested, and a PersonaStateChanged_t callback will be posted when it's retrieved</para>
		/// <para> if returns false, it means that we already have all the details about that user, and functions can be called immediately</para>
		public static bool RequestUserInformation(CSteamID steamIDUser, bool bRequireNameOnly) {
			return false;
		}

		/// <para> requests information about a clan officer list</para>
		/// <para> when complete, data is returned in ClanOfficerListResponse_t call result</para>
		/// <para> this makes available the calls below</para>
		/// <para> you can only ask about clans that a user is a member of</para>
		/// <para> note that this won't download avatars automatically; if you get an officer,</para>
		/// <para> and no avatar image is available, call RequestUserInformation( steamID, false ) to download the avatar</para>
		public static SteamAPICall_t RequestClanOfficerList(CSteamID steamIDClan) {
			return (SteamAPICall_t) 0;
		}

		/// <para> iteration of clan officers - can only be done when a RequestClanOfficerList() call has completed</para>
		/// <para> returns the steamID of the clan owner</para>
		public static CSteamID GetClanOwner(CSteamID steamIDClan) {
			return (CSteamID) 0;
		}

		/// <para> returns the number of officers in a clan (including the owner)</para>
		public static int GetClanOfficerCount(CSteamID steamIDClan) {
			return 0;
		}

		/// <para> returns the steamID of a clan officer, by index, of range [0,GetClanOfficerCount)</para>
		public static CSteamID GetClanOfficerByIndex(CSteamID steamIDClan, int iOfficer) {
			return (CSteamID) 0;
		}

		/// <para> if current user is chat restricted, he can't send or receive any text/voice chat messages.</para>
		/// <para> the user can't see custom avatars. But the user can be online and send/recv game invites.</para>
		/// <para> a chat restricted user can't add friends or join any groups.</para>
		public static uint GetUserRestrictions() {
			return (uint) 0;
		}

		/// <para> Rich Presence data is automatically shared between friends who are in the same game</para>
		/// <para> Each user has a set of Key/Value pairs</para>
		/// <para> Note the following limits: k_cchMaxRichPresenceKeys, k_cchMaxRichPresenceKeyLength, k_cchMaxRichPresenceValueLength</para>
		/// <para> There are two magic keys:</para>
		/// <para>		"status"  - a UTF-8 string that will show up in the 'view game info' dialog in the Steam friends list</para>
		/// <para>		"connect" - a UTF-8 string that contains the command-line for how a friend can connect to a game</para>
		/// <para> GetFriendRichPresence() returns an empty string "" if no value is set</para>
		/// <para> SetRichPresence() to a NULL or an empty string deletes the key</para>
		/// <para> You can iterate the current set of keys for a friend with GetFriendRichPresenceKeyCount()</para>
		/// <para> and GetFriendRichPresenceKeyByIndex() (typically only used for debugging)</para>
		public static bool SetRichPresence(string pchKey, string pchValue) {
			return false;
		}

		public static void ClearRichPresence() {
		}

		public static string GetFriendRichPresence(CSteamID steamIDFriend, string pchKey) {
			return "";
		}

		public static int GetFriendRichPresenceKeyCount(CSteamID steamIDFriend) {
			return 0;
		}

		public static string GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, int iKey) {
			return "";
		}

		/// <para> Requests rich presence for a specific user.</para>
		public static void RequestFriendRichPresence(CSteamID steamIDFriend) {
		}

		/// <para> Rich invite support.</para>
		/// <para> If the target accepts the invite, a GameRichPresenceJoinRequested_t callback is posted containing the connect string.</para>
		/// <para> (Or you can configure yout game so that it is passed on the command line instead.  This is a deprecated path; ask us if you really need this.)</para>
		/// <para> Invites can only be sent to friends.</para>
		public static bool InviteUserToGame(CSteamID steamIDFriend, string pchConnectString) {
			return false;
		}

		/// <para> recently-played-with friends iteration</para>
		/// <para> this iterates the entire list of users recently played with, across games</para>
		/// <para> GetFriendCoplayTime() returns as a unix time</para>
		public static int GetCoplayFriendCount() {
			return 0;
		}

		public static CSteamID GetCoplayFriend(int iCoplayFriend) {
			return (CSteamID) 0;
		}

		public static int GetFriendCoplayTime(CSteamID steamIDFriend) {
			return 0;
		}

		public static AppId_t GetFriendCoplayGame(CSteamID steamIDFriend) {
			return (AppId_t) 0;
		}

		/// <para> chat interface for games</para>
		/// <para> this allows in-game access to group (clan) chats from in the game</para>
		/// <para> the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay</para>
		/// <para> use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat</para>
		public static SteamAPICall_t JoinClanChatRoom(CSteamID steamIDClan) {
			return (SteamAPICall_t) 0;
		}

		public static bool LeaveClanChatRoom(CSteamID steamIDClan) {
			return false;
		}

		public static int GetClanChatMemberCount(CSteamID steamIDClan) {
			return 0;
		}

		public static CSteamID GetChatMemberByIndex(CSteamID steamIDClan, int iUser) {
			return (CSteamID) 0;
		}

		public static bool SendClanChatMessage(CSteamID steamIDClanChat, string pchText) {
			return false;
		}

		public static int GetClanChatMessage(CSteamID steamIDClanChat, int iMessage, out string prgchText, int cchTextMax, out EChatEntryType peChatEntryType, out CSteamID psteamidChatter) {
			prgchText = "";
			peChatEntryType = (EChatEntryType) 0;
			psteamidChatter = (CSteamID) 0;
			return 0;
		}

		public static bool IsClanChatAdmin(CSteamID steamIDClanChat, CSteamID steamIDUser) {
			return false;
		}

		/// <para> interact with the Steam (game overlay / desktop)</para>
		public static bool IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat) {
			return false;
		}

		public static bool OpenClanChatWindowInSteam(CSteamID steamIDClanChat) {
			return false;
		}

		public static bool CloseClanChatWindowInSteam(CSteamID steamIDClanChat) {
			return false;
		}

		/// <para> peer-to-peer chat interception</para>
		/// <para> this is so you can show P2P chats inline in the game</para>
		public static bool SetListenForFriendsMessages(bool bInterceptEnabled) {
			return false;
		}

		public static bool ReplyToFriendMessage(CSteamID steamIDFriend, string pchMsgToSend) {
			return false;
		}

		public static int GetFriendMessage(CSteamID steamIDFriend, int iMessageID, out string pvData, int cubData, out EChatEntryType peChatEntryType) {
			pvData = "";
			peChatEntryType = (EChatEntryType) 0;
			return 0;
		}

		/// <para> following apis</para>
		public static SteamAPICall_t GetFollowerCount(CSteamID steamID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t IsFollowing(CSteamID steamID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t EnumerateFollowingList(uint unStartIndex) {
			return (SteamAPICall_t) 0;
		}

		public static bool IsClanPublic(CSteamID steamIDClan) {
			return false;
		}

		public static bool IsClanOfficialGameGroup(CSteamID steamIDClan) {
			return false;
		}

		/// <para>/ Return the number of chats (friends or chat rooms) with unread messages.</para>
		/// <para>/ A "priority" message is one that would generate some sort of toast or</para>
		/// <para>/ notification, and depends on user settings.</para>
		/// <para>/</para>
		/// <para>/ You can register for UnreadChatMessagesChanged_t callbacks to know when this</para>
		/// <para>/ has potentially changed.</para>
		public static int GetNumChatsWithUnreadPriorityMessages() {
			return 0;
		}
	}
}
