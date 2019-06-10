// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamFriends {
		/// returns the local players name - guaranteed to not be NULL.
		/// this is the same name as on the users community profile page
		/// this is stored in UTF-8 format
		/// like all the other interface functions that return a char *, it's important that this pointer is not saved
		/// off; it will eventually be free'd or re-allocated
		public static string GetPersonaName() { return ""; }

		/// Sets the player name, stores it on the server and publishes the changes to all friends who are online.
		/// Changes take place locally immediately, and a PersonaStateChange_t is posted, presuming success.
		/// The final results are available through the return value SteamAPICall_t, using SetPersonaNameResponse_t.
		/// If the name change fails to happen on the server, then an additional global PersonaStateChange_t will be posted
		/// to change the name back, in addition to the SetPersonaNameResponse_t callback.
		public static SteamAPICall_t SetPersonaName(string pchPersonaName) {
			return (SteamAPICall_t) 0;
		}

		/// gets the status of the current user
		public static EPersonaState GetPersonaState() {
			return (EPersonaState) 0;
		}

		/// friend iteration
		/// takes a set of k_EFriendFlags, and returns the number of users the client knows about who meet that criteria
		/// then GetFriendByIndex() can then be used to return the id's of each of those users
		public static int GetFriendCount(EFriendFlags iFriendFlags) {
			return 0;
		}

		/// returns the steamID of a user
		/// iFriend is a index of range [0, GetFriendCount())
		/// iFriendsFlags must be the same value as used in GetFriendCount()
		/// the returned CSteamID can then be used by all the functions below to access details about the user
		public static CSteamID GetFriendByIndex(int iFriend, EFriendFlags iFriendFlags) {
			return (CSteamID) 0;
		}

		/// returns a relationship to a user
		public static EFriendRelationship GetFriendRelationship(CSteamID steamIDFriend) {
			return (EFriendRelationship) 0;
		}

		/// returns the current status of the specified user
		/// this will only be known by the local user if steamIDFriend is in their friends list; on the same game server; in a chat room or lobby; or in a small group with the local user
		public static EPersonaState GetFriendPersonaState(CSteamID steamIDFriend) {
			return (EPersonaState) 0;
		}

		/// returns the name another user - guaranteed to not be NULL.
		/// same rules as GetFriendPersonaState() apply as to whether or not the user knowns the name of the other user
		/// note that on first joining a lobby, chat room or game server the local user will not known the name of the other users automatically; that information will arrive asyncronously
		public static string GetFriendPersonaName(CSteamID steamIDFriend) {
			return "";
		}

		/// returns true if the friend is actually in a game, and fills in pFriendGameInfo with an extra details
		public static bool GetFriendGamePlayed(CSteamID steamIDFriend, out FriendGameInfo_t pFriendGameInfo) {
			pFriendGameInfo = new FriendGameInfo_t();
			return false;
		}

		/// accesses old friends names - returns an empty string when their are no more items in the history
		public static string GetFriendPersonaNameHistory(CSteamID steamIDFriend, int iPersonaName) {
			return "";
		}

		/// friends steam level
		public static int GetFriendSteamLevel(CSteamID steamIDFriend) {
			return 0;
		}

		/// Returns nickname the current user has set for the specified player. Returns NULL if the no nickname has been set for that player.
		/// DEPRECATED: GetPersonaName follows the Steam nickname preferences, so apps shouldn't need to care about nicknames explicitly.
		public static string GetPlayerNickname(CSteamID steamIDPlayer) {
			return "";
		}

		/// friend grouping (tag) apis
		/// returns the number of friends groups
		public static int GetFriendsGroupCount() {
			return 0;
		}

		/// returns the friends group ID for the given index (invalid indices return k_FriendsGroupID_Invalid)
		public static FriendsGroupID_t GetFriendsGroupIDByIndex(int iFG) {
			return (FriendsGroupID_t) 0;
		}

		/// returns the name for the given friends group (NULL in the case of invalid friends group IDs)
		public static string GetFriendsGroupName(FriendsGroupID_t friendsGroupID) {
			return "";
		}

		/// returns the number of members in a given friends group
		public static int GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID) {
			return 0;
		}

		/// gets up to nMembersCount members of the given friends group, if fewer exist than requested those positions' SteamIDs will be invalid.
		public static void GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, CSteamID[] pOutSteamIDMembers, int nMembersCount) {
		}

		/// returns true if the specified user meets any of the criteria specified in iFriendFlags
		/// iFriendFlags can be the union (binary or, |) of one or more k_EFriendFlags values
		public static bool HasFriend(CSteamID steamIDFriend, EFriendFlags iFriendFlags) {
			return false;
		}

		/// clan (group) iteration and access functions
		public static int GetClanCount() { return 0; }
		public static CSteamID GetClanByIndex(int iClan) { return (CSteamID) 0; }
		public static string GetClanName(CSteamID steamIDClan) { return ""; }
		public static string GetClanTag(CSteamID steamIDClan) { return ""; }

		/// returns the most recent information we have about what's happening in a clan
		public static bool GetClanActivityCounts(CSteamID steamIDClan, out int pnOnline, out int pnInGame, out int pnChatting) {
			pnOnline = 0;
			pnInGame = 0;
			pnChatting = 0;
			return false;
		}

		/// for clans a user is a member of, they will have reasonably up-to-date information, but for others you'll have to download the info to have the latest
		public static SteamAPICall_t DownloadClanActivityCounts(CSteamID[] psteamIDClans, int cClansToRequest) {
			return (SteamAPICall_t) 0;
		}

		/// iterators for getting users in a chat room, lobby, game server or clan
		/// note that large clans that cannot be iterated by the local user
		/// note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby
		/// steamIDSource can be the steamID of a group, game server, lobby or chat room
		public static int GetFriendCountFromSource(CSteamID steamIDSource) { return 0; }
		public static CSteamID GetFriendFromSourceByIndex(CSteamID steamIDSource, int iFriend) {
			return (CSteamID) 0;
		}

		/// returns true if the local user can see that steamIDUser is a member or in steamIDSource
		public static bool IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource) {
			return false;
		}

		/// User is in a game pressing the talk button (will suppress the microphone for all voice comms from the Steam friends UI)
		public static void SetInGameVoiceSpeaking(CSteamID steamIDUser, bool bSpeaking) {
		}

		/// activates the game overlay, with an optional dialog to open
		/// valid options include "Friends", "Community", "Players", "Settings", "OfficialGameGroup", "Stats", "Achievements",
		/// "chatroomgroup/nnnn"
		public static void ActivateGameOverlay(string pchDialog) { }

		/// activates game overlay to a specific place
		/// valid options are
		/// "steamid" - opens the overlay web browser to the specified user or groups profile
		/// "chat" - opens a chat window to the specified user, or joins the group chat
		/// "jointrade" - opens a window to a Steam Trading session that was started with the ISteamEconomy/StartTrade Web API
		/// "stats" - opens the overlay web browser to the specified user's stats
		/// "achievements" - opens the overlay web browser to the specified user's achievements
		/// "friendadd" - opens the overlay in minimal mode prompting the user to add the target user as a friend
		/// "friendremove" - opens the overlay in minimal mode prompting the user to remove the target friend
		/// "friendrequestaccept" - opens the overlay in minimal mode prompting the user to accept an incoming friend invite
		/// "friendrequestignore" - opens the overlay in minimal mode prompting the user to ignore an incoming friend invite
		public static void ActivateGameOverlayToUser(string pchDialog, CSteamID steamID) { }

		/// activates game overlay web browser directly to the specified URL
		/// full address with protocol type is required, e.g. http://www.steamgames.com/
		public static void ActivateGameOverlayToWebPage(string pchURL, EActivateGameOverlayToWebPageMode eMode = EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default) { }

		/// activates game overlay to store page for app
		public static void ActivateGameOverlayToStore(AppId_t nAppID, EOverlayToStoreFlag eFlag) { }

		/// Mark a target user as 'played with'. This is a client-side only feature that requires that the calling user is
		/// in game
		public static void SetPlayedWith(CSteamID steamIDUserPlayedWith) { }

		/// activates game overlay to open the invite dialog. Invitations will be sent for the provided lobby.
		public static void ActivateGameOverlayInviteDialog(CSteamID steamIDLobby) { }

		/// gets the small (32x32) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
		public static int GetSmallFriendAvatar(CSteamID steamIDFriend) { return 0; }

		/// gets the medium (64x64) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
		public static int GetMediumFriendAvatar(CSteamID steamIDFriend) { return 0; }

		/// gets the large (184x184) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
		/// returns -1 if this image has yet to be loaded, in this case wait for a AvatarImageLoaded_t callback and then call this again
		public static int GetLargeFriendAvatar(CSteamID steamIDFriend) { return 0; }

		/// requests information about a user - persona name &amp; avatar
		/// if bRequireNameOnly is set, then the avatar of a user isn't downloaded
		/// - it's a lot slower to download avatars and churns the local cache, so if you don't need avatars, don't request them
		/// if returns true, it means that data is being requested, and a PersonaStateChanged_t callback will be posted when it's retrieved
		/// if returns false, it means that we already have all the details about that user, and functions can be called immediately
		public static bool RequestUserInformation(CSteamID steamIDUser, bool bRequireNameOnly) {
			return false;
		}

		/// requests information about a clan officer list
		/// when complete, data is returned in ClanOfficerListResponse_t call result
		/// this makes available the calls below
		/// you can only ask about clans that a user is a member of
		/// note that this won't download avatars automatically; if you get an officer,
		/// and no avatar image is available, call RequestUserInformation( steamID, false ) to download the avatar
		public static SteamAPICall_t RequestClanOfficerList(CSteamID steamIDClan) {
			return (SteamAPICall_t) 0;
		}

		/// iteration of clan officers - can only be done when a RequestClanOfficerList() call has completed
		/// returns the steamID of the clan owner
		public static CSteamID GetClanOwner(CSteamID steamIDClan) { return (CSteamID) 0; }

		/// returns the number of officers in a clan (including the owner)
		public static int GetClanOfficerCount(CSteamID steamIDClan) { return 0; }

		/// returns the steamID of a clan officer, by index, of range [0,GetClanOfficerCount)
		public static CSteamID GetClanOfficerByIndex(CSteamID steamIDClan, int iOfficer) {
			return (CSteamID) 0;
		}

		/// if current user is chat restricted, he can't send or receive any text/voice chat messages.
		/// the user can't see custom avatars. But the user can be online and send/recv game invites.
		/// a chat restricted user can't add friends or join any groups.
		public static uint GetUserRestrictions() { return (uint) 0; }

		/// Rich Presence data is automatically shared between friends who are in the same game
		/// Each user has a set of Key/Value pairs
		/// Note the following limits: k_cchMaxRichPresenceKeys, k_cchMaxRichPresenceKeyLength, k_cchMaxRichPresenceValueLength
		/// There are two magic keys:
		/// "status"  - a UTF-8 string that will show up in the 'view game info' dialog in the Steam friends list
		/// "connect" - a UTF-8 string that contains the command-line for how a friend can connect to a game
		/// GetFriendRichPresence() returns an empty string "" if no value is set
		/// SetRichPresence() to a NULL or an empty string deletes the key
		/// You can iterate the current set of keys for a friend with GetFriendRichPresenceKeyCount()
		/// and GetFriendRichPresenceKeyByIndex() (typically only used for debugging)
		public static bool SetRichPresence(string pchKey, string pchValue) { return false; }
		public static void ClearRichPresence() { }
		public static string GetFriendRichPresence(CSteamID steamIDFriend, string pchKey) {
			return "";
		}
		public static int GetFriendRichPresenceKeyCount(CSteamID steamIDFriend) {
			return 0;
		}
		public static string GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, int iKey) {
			return "";
		}
		/// Requests rich presence for a specific user.
		public static void RequestFriendRichPresence(CSteamID steamIDFriend) { }

		/// Rich invite support.
		/// If the target accepts the invite, a GameRichPresenceJoinRequested_t callback is posted containing the connect string.
		/// (Or you can configure yout game so that it is passed on the command line instead.  This is a deprecated path; ask us if you really need this.)
		/// Invites can only be sent to friends.
		public static bool InviteUserToGame(CSteamID steamIDFriend, string pchConnectString) {
			return false;
		}

		/// recently-played-with friends iteration
		/// this iterates the entire list of users recently played with, across games
		/// GetFriendCoplayTime() returns as a unix time
		public static int GetCoplayFriendCount() { return 0; }
		public static CSteamID GetCoplayFriend(int iCoplayFriend) { return (CSteamID) 0; }
		public static int GetFriendCoplayTime(CSteamID steamIDFriend) { return 0; }
		public static AppId_t GetFriendCoplayGame(CSteamID steamIDFriend) { return (AppId_t) 0; }

		/// chat interface for games
		/// this allows in-game access to group (clan) chats from in the game
		/// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
		/// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
		public static SteamAPICall_t JoinClanChatRoom(CSteamID steamIDClan) {
			return (SteamAPICall_t) 0;
		}
		public static bool LeaveClanChatRoom(CSteamID steamIDClan) { return false; }
		public static int GetClanChatMemberCount(CSteamID steamIDClan) { return 0; }
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
		/// interact with the Steam (game overlay / desktop)
		public static bool IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat) {
			return false;
		}
		public static bool OpenClanChatWindowInSteam(CSteamID steamIDClanChat) {
			return false;
		}
		public static bool CloseClanChatWindowInSteam(CSteamID steamIDClanChat) {
			return false;
		}

		/// peer-to-peer chat interception
		/// this is so you can show P2P chats inline in the game
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

		/// following apis
		public static SteamAPICall_t GetFollowerCount(CSteamID steamID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t IsFollowing(CSteamID steamID) {
			return (SteamAPICall_t) 0;
		}

		public static SteamAPICall_t EnumerateFollowingList(uint unStartIndex) {
			return (SteamAPICall_t) 0;
		}

		public static bool IsClanPublic(CSteamID steamIDClan) { return false; }

		public static bool IsClanOfficialGameGroup(CSteamID steamIDClan) {
			return false;
		}

		/// / Return the number of chats (friends or chat rooms) with unread messages.
		/// / A "priority" message is one that would generate some sort of toast or
		/// / notification, and depends on user settings.
		/// / You can register for UnreadChatMessagesChanged_t callbacks to know when this
		/// / has potentially changed.
		public static int GetNumChatsWithUnreadPriorityMessages() { return 0; }
	}
}
