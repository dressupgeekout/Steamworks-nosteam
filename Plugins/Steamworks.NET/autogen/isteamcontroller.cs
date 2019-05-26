// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamController {
		/// <para> Init and Shutdown must be called when starting/ending use of this interface</para>
		public static bool Init() {
			return false;
		}

		public static bool Shutdown() {
			return false;
		}

		/// <para> Synchronize API state with the latest Steam Controller inputs available. This</para>
		/// <para> is performed automatically by SteamAPI_RunCallbacks, but for the absolute lowest</para>
		/// <para> possible latency, you call this directly before reading controller state. This must</para>
		/// <para> be called from somewhere before GetConnectedControllers will return any handles</para>
		public static void RunFrame() {
		}

		/// <para> Enumerate currently connected controllers</para>
		/// <para> handlesOut should point to a STEAM_CONTROLLER_MAX_COUNT sized array of ControllerHandle_t handles</para>
		/// <para> Returns the number of handles written to handlesOut</para>
		public static int GetConnectedControllers(ControllerHandle_t[] handlesOut) {
			return 0;
		}

		/// <para> ACTION SETS</para>
		/// <para> Lookup the handle for an Action Set. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static ControllerActionSetHandle_t GetActionSetHandle(string pszActionSetName) {
			return (ControllerActionSetHandle_t) 0;
		}

		/// <para> Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')</para>
		/// <para> This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in</para>
		/// <para> your state loops, instead of trying to place it in all of your state transitions.</para>
		public static void ActivateActionSet(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle) {
		}

		public static ControllerActionSetHandle_t GetCurrentActionSet(ControllerHandle_t controllerHandle) {
			return (ControllerActionSetHandle_t) 0;
		}

		/// <para> ACTION SET LAYERS</para>
		public static void ActivateActionSetLayer(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle) {
		}

		public static void DeactivateActionSetLayer(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle) {
		}

		public static void DeactivateAllActionSetLayers(ControllerHandle_t controllerHandle) {
		}

		public static int GetActiveActionSetLayers(ControllerHandle_t controllerHandle, out ControllerActionSetHandle_t handlesOut) {
			handlesOut = (ControllerActionSetHandle_t) 0;
			return 0;
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> ACTIONS</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Lookup the handle for a digital action. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static ControllerDigitalActionHandle_t GetDigitalActionHandle(string pszActionName) {
			return (ControllerDigitalActionHandle_t) 0;
		}

		/// <para> Returns the current state of the supplied digital game action</para>
		public static ControllerDigitalActionData_t GetDigitalActionData(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle) {
			ControllerDigitalActionData_t ret = new ControllerDigitalActionData_t();
			return ret;
		}

		/// <para> Get the origin(s) for a digital action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.</para>
		/// <para> originsOut should point to a STEAM_CONTROLLER_MAX_ORIGINS sized array of EControllerActionOrigin handles. The EControllerActionOrigin enum will get extended as support for new controller controllers gets added to</para>
		/// <para> the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.</para>
		public static int GetDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, EControllerActionOrigin[] originsOut) {
			return 0;
		}

		/// <para> Lookup the handle for an analog action. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static ControllerAnalogActionHandle_t GetAnalogActionHandle(string pszActionName) {
			return (ControllerAnalogActionHandle_t) 0;
		}

		/// <para> Returns the current state of these supplied analog game action</para>
		public static ControllerAnalogActionData_t GetAnalogActionData(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle) {
			ControllerAnalogActionData_t ret = new ControllerAnalogActionData_t();
			return ret;
		}

		/// <para> Get the origin(s) for an analog action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.</para>
		/// <para> originsOut should point to a STEAM_CONTROLLER_MAX_ORIGINS sized array of EControllerActionOrigin handles. The EControllerActionOrigin enum will get extended as support for new controller controllers gets added to</para>
		/// <para> the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.</para>
		public static int GetAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, EControllerActionOrigin[] originsOut) {
			return 0;
		}

		/// <para> Get a local path to art for on-screen glyph for a particular origin - this call is cheap</para>
		public static string GetGlyphForActionOrigin(EControllerActionOrigin eOrigin) {
			return "";
		}

		/// <para> Returns a localized string (from Steam's language setting) for the specified origin - this call is serialized</para>
		public static string GetStringForActionOrigin(EControllerActionOrigin eOrigin) {
			return "";
		}

		public static void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction) {
		}

		/// <para> Returns raw motion data from the specified controller</para>
		public static ControllerMotionData_t GetMotionData(ControllerHandle_t controllerHandle) {
			ControllerMotionData_t ret = new ControllerMotionData_t();
			return ret;
		}

		/// <para> OUTPUTS</para>
		/// <para> Trigger a haptic pulse on a controller</para>
		/// </summary>
		public static void TriggerHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec) {
		}

		/// <para> Trigger a pulse with a duty cycle of usDurationMicroSec / usOffMicroSec, unRepeat times.</para>
		/// <para> nFlags is currently unused and reserved for future use.</para>
		public static void TriggerRepeatedHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags) {
		}

		/// <para> Trigger a vibration event on supported controllers.</para>
		public static void TriggerVibration(ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed) {
		}

		/// <para> Set the controller LED color on supported controllers.</para>
		public static void SetLEDColor(ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags) {
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Utility functions availible without using the rest of Steam Input API</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Invokes the Steam overlay and brings up the binding screen if the user is using Big Picture Mode</para>
		/// <para> If the user is not in Big Picture Mode it will open up the binding in a new window</para>
		public static bool ShowBindingPanel(ControllerHandle_t controllerHandle) {
			return false;
		}

		/// <para> Returns the input type for a particular handle</para>
		public static ESteamInputType GetInputTypeForHandle(ControllerHandle_t controllerHandle) {
			return (ESteamInputType) 0;
		}

		/// <para> Returns the associated controller handle for the specified emulated gamepad - can be used with the above 2 functions</para>
		/// <para> to identify controllers presented to your game over Xinput. Returns 0 if the Xinput index isn't associated with Steam Input</para>
		public static ControllerHandle_t GetControllerForGamepadIndex(int nIndex) {
			return (ControllerHandle_t) 0;
		}

		/// <para> Returns the associated gamepad index for the specified controller, if emulating a gamepad or -1 if not associated with an Xinput index</para>
		public static int GetGamepadIndexForController(ControllerHandle_t ulControllerHandle) {
			return 0;
		}

		/// <para> Returns a localized string (from Steam's language setting) for the specified Xbox controller origin. This function is cheap.</para>
		public static string GetStringForXboxOrigin(EXboxOrigin eOrigin) {
			return "";
		}

		/// <para> Get a local path to art for on-screen glyph for a particular Xbox controller origin. This function is serialized.</para>
		public static string GetGlyphForXboxOrigin(EXboxOrigin eOrigin) {
			return "";
		}

		/// <para> Get the equivalent ActionOrigin for a given Xbox controller origin this can be chained with GetGlyphForActionOrigin to provide future proof glyphs for</para>
		/// <para> non-Steam Input API action games. Note - this only translates the buttons directly and doesn't take into account any remapping a user has made in their configuration</para>
		public static EControllerActionOrigin GetActionOriginFromXboxOrigin(ControllerHandle_t controllerHandle, EXboxOrigin eOrigin) {
			return (EControllerActionOrigin) 0;
		}

		/// <para> Convert an origin to another controller type - for inputs not present on the other controller type this will return k_EControllerActionOrigin_None</para>
		public static EControllerActionOrigin TranslateActionOrigin(ESteamInputType eDestinationInputType, EControllerActionOrigin eSourceOrigin) {
			return (EControllerActionOrigin) 0;
		}
	}
}
