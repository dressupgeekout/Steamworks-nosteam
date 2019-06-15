// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamInventory {
		/// INVENTORY ASYNC RESULT MANAGEMENT
		/// Asynchronous inventory queries always output a result handle which can be used with
		/// GetResultStatus, GetResultItems, etc. A SteamInventoryResultReady_t callback will
		/// be triggered when the asynchronous result becomes ready (or fails).
		/// Find out the status of an asynchronous inventory result handle. Possible values:
		///  k_EResultPending - still in progress
		///  k_EResultOK - done, result ready
		///  k_EResultExpired - done, result ready, maybe out of date (see DeserializeResult)
		///  k_EResultInvalidParam - ERROR: invalid API call parameters
		///  k_EResultServiceUnavailable - ERROR: service temporarily down, you may retry later
		///  k_EResultLimitExceeded - ERROR: operation would exceed per-user inventory limits
		///  k_EResultFail - ERROR: unknown / generic error
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle) {
			return (EResult) 0;
		}

		/// Copies the contents of a result set into a flat array. The specific
		/// contents of the result set depend on which query which was used.
		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize) {
			return false;
		}

		/// In combination with GetResultItems, you can use GetResultItemProperty to retrieve
		/// dynamic string properties for a given item returned in the result set.
		/// Property names are always composed of ASCII letters, numbers, and/or underscores.
		/// Pass a NULL pointer for pchPropertyName to get a comma - separated list of available
		/// property names.
		/// If pchValueBuffer is NULL, *punValueBufferSize will contain the
		/// suggested buffer size. Otherwise it will be the number of bytes actually copied
		/// to pchValueBuffer. If the results do not fit in the given buffer, partial
		/// results may be copied.
		public static bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut) {
			pchValueBuffer = "";
			return false;
		}

		/// Returns the server time at which the result was generated. Compare against
		/// the value of IClientUtils::GetServerRealTime() to determine age.
		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle) {
			return (uint) 0;
		}

		/// Returns true if the result belongs to the target steam ID, false if the
		/// result does not. This is important when using DeserializeResult, to verify
		/// that a remote player is not pretending to have a different user's inventory.
		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected) {
			return false;
		}

		/// Destroys a result handle and frees all associated memory.
		public static void DestroyResult(SteamInventoryResult_t resultHandle) { }

		/// INVENTORY ASYNC QUERY
		/// Captures the entire state of the current user's Steam inventory.
		/// You must call DestroyResult on this handle when you are done with it.
		/// Returns false and sets *pResultHandle to zero if inventory is unavailable.
		/// Note: calls to this function are subject to rate limits and may return
		/// cached results if called too frequently. It is suggested that you call
		/// this function only when you are about to display the user's full inventory,
		/// or if you expect that the inventory may have changed.
		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// Captures the state of a subset of the current user's Steam inventory,
		/// identified by an array of item instance IDs. The results from this call
		/// can be serialized and passed to other players to "prove" that the current
		/// user owns specific items, without exposing the user's entire inventory.
		/// For example, you could call GetItemsByID with the IDs of the user's
		/// currently equipped cosmetic items and serialize this to a buffer, and
		/// then transmit this buffer to other players upon joining a game.
		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// RESULT SERIALIZATION AND AUTHENTICATION
		/// Serialized result sets contain a short signature which can't be forged
		/// or replayed across different game sessions. A result set can be serialized
		/// on the local client, transmitted to other players via your game networking,
		/// and deserialized by the remote players. This is a secure way of preventing
		/// hackers from lying about posessing rare/high-value items.
		/// Serializes a result set with signature bytes to an output buffer. Pass
		/// NULL as an output buffer to get the required size via punOutBufferSize.
		/// The size of a serialized result depends on the number items which are being
		/// serialized. When securely transmitting items to other players, it is
		/// recommended to use "GetItemsByID" first to create a minimal result set.
		/// Results have a built-in timestamp which will be considered "expired" after
		/// an hour has elapsed. See DeserializeResult for expiration handling.
		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize) {
			punOutBufferSize = (uint) 0;
			return false;
		}

		/// Deserializes a result set and verifies the signature bytes. Returns false
		/// if bRequireFullOnlineVerify is set but Steam is running in Offline mode.
		/// Otherwise returns true and then delivers error codes via GetResultStatus.
		/// The bRESERVED_MUST_BE_FALSE flag is reserved for future use and should not
		/// be set to true by your game at this time.
		/// DeserializeResult has a potential soft-failure mode where the handle status
		/// is set to k_EResultExpired. GetResultItems() still succeeds in this mode.
		/// The "expired" result could indicate that the data may be out of date - not
		/// just due to timed expiration (one hour), but also because one of the items
		/// in the result set may have been traded or consumed since the result set was
		/// generated. You could compare the timestamp from GetResultTimestamp() to
		/// ISteamUtils::GetServerRealTime() to determine how old the data is. You could
		/// simply ignore the "expired" result code and continue as normal, or you
		/// could challenge the player with expired data to send an updated result set.
		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false) {
			pOutResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// INVENTORY ASYNC MODIFICATION
		/// GenerateItems() creates one or more items and then generates a SteamInventoryCallback_t
		/// notification with a matching nCallbackContext parameter. This API is only intended
		/// for prototyping - it is only usable by Steam accounts that belong to the publisher group
		/// for your game.
		/// If punArrayQuantity is not NULL, it should be the same length as pArrayItems and should
		/// describe the quantity of each item to generate.
		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// GrantPromoItems() checks the list of promotional items for which the user may be eligible
		/// and grants the items (one time only).  On success, the result set will include items which
		/// were granted, if any. If no items were granted because the user isn't eligible for any
		/// promotions, this is still considered a success.
		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// AddPromoItem() / AddPromoItems() are restricted versions of GrantPromoItems(). Instead of
		/// scanning for all eligible promotional items, the check is restricted to a single item
		/// definition or set of item definitions. This can be useful if your game has custom UI for
		/// showing a specific promo item to the user.
		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// ConsumeItem() removes items from the inventory, permanently. They cannot be recovered.
		/// Not for the faint of heart - if your game implements item removal at all, a high-friction
		/// UI confirmation process is highly recommended.
		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// ExchangeItems() is an atomic combination of item generation and consumption.
		/// It can be used to implement crafting recipes or transmutations, or items which unpack
		/// themselves into other items (e.g., a chest).
		/// Exchange recipes are defined in the ItemDef, and explicitly list the required item
		/// types and resulting generated type.
		/// Exchange recipes are evaluated atomically by the Inventory Service; if the supplied
		/// components do not match the recipe, or do not contain sufficient quantity, the
		/// exchange will fail.
		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// TransferItemQuantity() is intended for use with items which are "stackable" (can have
		/// quantity greater than one). It can be used to split a stack into two, or to transfer
		/// quantity from one stack into another stack of identical items. To split one stack into
		/// two, pass k_SteamItemInstanceIDInvalid for itemIdDest and a new item will be generated.
		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// TIMED DROPS AND PLAYTIME CREDIT
		/// Deprecated. Calling this method is not required for proper playtime accounting.
		public static void SendItemDropHeartbeat() { }

		/// Playtime credit must be consumed and turned into item drops by your game. Only item
		/// definitions which are marked as "playtime item generators" can be spawned. The call
		/// will return an empty result set if there is not enough playtime credit for a drop.
		/// Your game should call TriggerItemDrop at an appropriate time for the user to receive
		/// new items, such as between rounds or while the player is dead. Note that players who
		/// hack their clients could modify the value of "dropListDefinition", so do not use it
		/// to directly control rarity.
		/// See your Steamworks configuration to set playtime drop rates for individual itemdefs.
		/// The client library will suppress too-frequent calls to this method.
		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// Deprecated. This method is not supported.
		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}

		/// ITEM DEFINITIONS
		/// Item definitions are a mapping of "definition IDs" (integers between 1 and 1000000)
		/// to a set of string properties. Some of these properties are required to display items
		/// on the Steam community web site. Other properties can be defined by applications.
		/// Use of these functions is optional; there is no reason to call LoadItemDefinitions
		/// if your game hardcodes the numeric definition IDs (eg, purple face mask = 20, blue
		/// weapon mod = 55) and does not allow for adding new item types without a client patch.
		/// LoadItemDefinitions triggers the automatic load and refresh of item definitions.
		/// Every time new item definitions are available (eg, from the dynamic addition of new
		/// item types while players are still in-game), a SteamInventoryDefinitionUpdate_t
		/// callback will be fired.
		public static bool LoadItemDefinitions() { return false; }

		/// GetItemDefinitionIDs returns the set of all defined item definition IDs (which are
		/// defined via Steamworks configuration, and not necessarily contiguous integers).
		/// If pItemDefIDs is null, the call will return true and *punItemDefIDsArraySize will
		/// contain the total size necessary for a subsequent call. Otherwise, the call will
		/// return false if and only if there is not enough space in the output array.
		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize) {
			punItemDefIDsArraySize = (uint) 0;
			return false;
		}

		/// GetItemDefinitionProperty returns a string property from a given item definition.
		/// Note that some properties (for example, "name") may be localized and will depend
		/// on the current Steam language settings (see ISteamApps::GetCurrentGameLanguage).
		/// Property names are always composed of ASCII letters, numbers, and/or underscores.
		/// Pass a NULL pointer for pchPropertyName to get a comma - separated list of available
		/// property names. If pchValueBuffer is NULL, *punValueBufferSize will contain the
		/// suggested buffer size. Otherwise it will be the number of bytes actually copied
		/// to pchValueBuffer. If the results do not fit in the given buffer, partial
		/// results may be copied.
		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut) {
			pchValueBuffer = "";
			return false;
		}

		/// Request the list of "eligible" promo items that can be manually granted to the given
		/// user.  These are promo items of type "manual" that won't be granted automatically.
		/// An example usage of this is an item that becomes available every week.
		public static SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs(CSteamID steamID) {
			return (SteamAPICall_t) 0;
		}

		/// After handling a SteamInventoryEligiblePromoItemDefIDs_t call result, use this
		/// function to pull out the list of item definition ids that the user can be
		/// manually granted via the AddPromoItems() call.
		public static bool GetEligiblePromoItemDefinitionIDs(CSteamID steamID, SteamItemDef_t[] pItemDefIDs, ref uint punItemDefIDsArraySize) {
			return false;
		}

		/// Starts the purchase process for the given item definitions.  The callback SteamInventoryStartPurchaseResult_t
		/// will be posted if Steam was able to initialize the transaction.
		/// Once the purchase has been authorized and completed by the user, the callback SteamInventoryResultReady_t
		/// will be posted.
		public static SteamAPICall_t StartPurchase(SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength) {
			return (SteamAPICall_t) 0;
		}

		/// Request current prices for all applicable item definitions
		public static SteamAPICall_t RequestPrices() { return (SteamAPICall_t) 0; }

		/// Returns the number of items with prices.  Need to call RequestPrices() first.
		public static uint GetNumItemsWithPrices() { return (uint) 0; }

		/// Returns item definition ids and their prices in the user's local currency.
		/// Need to call RequestPrices() first.
		public static bool GetItemsWithPrices(SteamItemDef_t[] pArrayItemDefs, ulong[] pCurrentPrices, ulong[] pBasePrices, uint unArrayLength) {
			return false;
		}

		/// Retrieves the price for the item definition id
		/// Returns false if there is no price stored for the item definition.
		public static bool GetItemPrice(SteamItemDef_t iDefinition, out ulong pCurrentPrice, out ulong pBasePrice) {
			pCurrentPrice = (ulong) 0;
			pBasePrice = (ulong) 0;
			return false;
		}

		/// Create a request to update properties on items
		public static SteamInventoryUpdateHandle_t StartUpdateProperties() {
			return (SteamInventoryUpdateHandle_t) 0;
		}

		/// Remove the property on the item
		public static bool RemoveProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName) {
			return false;
		}

		/// Accessor methods to set properties on items
		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, string pchPropertyValue) {
			return false;
		}

		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, bool bValue) {
			return false;
		}
		public static bool SetProperty1(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, long nValue) {
			return false;
		}
		public static bool SetProperty2(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, float flValue) {
			return false;
		}

		/// Submit the update request by handle
		public static bool SubmitUpdateProperties(SteamInventoryUpdateHandle_t handle, out SteamInventoryResult_t pResultHandle) {
			pResultHandle = (SteamInventoryResult_t) 0;
			return false;
		}
	}
}
