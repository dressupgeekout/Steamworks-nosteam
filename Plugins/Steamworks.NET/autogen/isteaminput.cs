// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamInput {
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

		/// <para> Enumerate currently connected Steam Input enabled devices - developers can opt in controller by type (ex: Xbox/Playstation/etc) via</para>
		/// <para> the Steam Input settings in the Steamworks site or users can opt-in in their controller settings in Steam.</para>
		/// <para> handlesOut should point to a STEAM_INPUT_MAX_COUNT sized array of InputHandle_t handles</para>
		/// <para> Returns the number of handles written to handlesOut</para>
		public static int GetConnectedControllers(InputHandle_t[] handlesOut) {
			return 0;
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> ACTION SETS</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Lookup the handle for an Action Set. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static InputActionSetHandle_t GetActionSetHandle(string pszActionSetName) {
			return (InputActionSetHandle_t) 0;
		}

		/// <para> Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')</para>
		/// <para> This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in</para>
		/// <para> your state loops, instead of trying to place it in all of your state transitions.</para>
		public static void ActivateActionSet(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle) {
		}

		public static InputActionSetHandle_t GetCurrentActionSet(InputHandle_t inputHandle) {
			return (InputActionSetHandle_t) 0;
		}

		/// <para> ACTION SET LAYERS</para>
		public static void ActivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle) {
		}

		public static void DeactivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle) {
		}

		public static void DeactivateAllActionSetLayers(InputHandle_t inputHandle) {
		}

		public static int GetActiveActionSetLayers(InputHandle_t inputHandle, out InputActionSetHandle_t handlesOut) {
			handlesOut = (InputActionSetHandle_t) 0;
			return 0;
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> ACTIONS</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Lookup the handle for a digital action. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static InputDigitalActionHandle_t GetDigitalActionHandle(string pszActionName) {
			return (InputDigitalActionHandle_t) 0;
		}

		/// <para> Returns the current state of the supplied digital game action</para>
		public static InputDigitalActionData_t GetDigitalActionData(InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle) {
			InputDigitalActionData_t ret = new InputDigitalActionData_t();
			return ret;
		}

		/// <para> Get the origin(s) for a digital action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.</para>
		/// <para> originsOut should point to a STEAM_INPUT_MAX_ORIGINS sized array of EInputActionOrigin handles. The EInputActionOrigin enum will get extended as support for new controller controllers gets added to</para>
		/// <para> the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.</para>
		public static int GetDigitalActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, EInputActionOrigin[] originsOut) {
			return 0;
		}

		/// <para> Lookup the handle for an analog action. Best to do this once on startup, and store the handles for all future API calls.</para>
		public static InputAnalogActionHandle_t GetAnalogActionHandle(string pszActionName) {
			return (InputAnalogActionHandle_t) 0;
		}

		/// <para> Returns the current state of these supplied analog game action</para>
		public static InputAnalogActionData_t GetAnalogActionData(InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle) {
			InputAnalogActionData_t ret = new InputAnalogActionData_t();
			return ret;
		}

		/// <para> Get the origin(s) for an analog action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.</para>
		/// <para> originsOut should point to a STEAM_INPUT_MAX_ORIGINS sized array of EInputActionOrigin handles. The EInputActionOrigin enum will get extended as support for new controller controllers gets added to</para>
		/// <para> the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.</para>
		public static int GetAnalogActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, EInputActionOrigin[] originsOut) {
			return 0;
		}

		/// <para> Get a local path to art for on-screen glyph for a particular origin - this call is cheap</para>
		public static string GetGlyphForActionOrigin(EInputActionOrigin eOrigin) {
			return "";
		}

		/// <para> Returns a localized string (from Steam's language setting) for the specified origin - this call is serialized</para>
		public static string GetStringForActionOrigin(EInputActionOrigin eOrigin) {
			return "";
		}

		/// <para> Stop analog momentum for the action if it is a mouse action in trackball mode</para>
		public static void StopAnalogActionMomentum(InputHandle_t inputHandle, InputAnalogActionHandle_t eAction) {
		}

		/// <para> Returns raw motion data from the specified device</para>
		public static InputMotionData_t GetMotionData(InputHandle_t inputHandle) {
			InputMotionData_t ret = new InputMotionData_t();
			return ret;
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> OUTPUTS</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Trigger a vibration event on supported controllers - Steam will translate these commands into haptic pulses for Steam Controllers</para>
		public static void TriggerVibration(InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed) {
		}

		/// <para> Set the controller LED color on supported controllers. nFlags is a bitmask of values from ESteamInputLEDFlag - 0 will default to setting a color. Steam will handle</para>
		/// <para> the behavior on exit of your program so you don't need to try restore the default as you are shutting down</para>
		public static void SetLEDColor(InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags) {
		}

		/// <para> Trigger a haptic pulse on a Steam Controller - if you are approximating rumble you may want to use TriggerVibration instead.</para>
		/// <para> Good uses for Haptic pulses include chimes, noises, or directional gameplay feedback (taking damage, footstep locations, etc).</para>
		public static void TriggerHapticPulse(InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec) {
		}

		/// <para> Trigger a haptic pulse with a duty cycle of usDurationMicroSec / usOffMicroSec, unRepeat times. If you are approximating rumble you may want to use TriggerVibration instead.</para>
		/// <para> nFlags is currently unused and reserved for future use.</para>
		public static void TriggerRepeatedHapticPulse(InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags) {
		}

		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Utility functions availible without using the rest of Steam Input API</para>
		/// <para>-----------------------------------------------------------------------------</para>
		/// <para> Invokes the Steam overlay and brings up the binding screen if the user is using Big Picture Mode</para>
		/// <para> If the user is not in Big Picture Mode it will open up the binding in a new window</para>
		public static bool ShowBindingPanel(InputHandle_t inputHandle) {
			return false;
		}

		/// <para> Returns the input type for a particular handle</para>
		public static ESteamInputType GetInputTypeForHandle(InputHandle_t inputHandle) {
			return (ESteamInputType) 0;
		}

		/// <para> Returns the associated controller handle for the specified emulated gamepad - can be used with the above 2 functions</para>
		/// <para> to identify controllers presented to your game over Xinput. Returns 0 if the Xinput index isn't associated with Steam Input</para>
		public static InputHandle_t GetControllerForGamepadIndex(int nIndex) {
			return (InputHandle_t) 0;
		}

		/// <para> Returns the associated gamepad index for the specified controller, if emulating a gamepad or -1 if not associated with an Xinput index</para>
		public static int GetGamepadIndexForController(InputHandle_t ulinputHandle) {
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
		public static EInputActionOrigin GetActionOriginFromXboxOrigin(InputHandle_t inputHandle, EXboxOrigin eOrigin) {
			return (EInputActionOrigin) 0;
		}

		/// <para> Convert an origin to another controller type - for inputs not present on the other controller type this will return k_EInputActionOrigin_None</para>
		/// <para> When a new input type is added you will be able to pass in k_ESteamInputType_Unknown amd the closest origin that your version of the SDK regonized will be returned</para>
		/// <para> ex: if a Playstation 5 controller was released this function would return Playstation 4 origins.</para>
		public static EInputActionOrigin TranslateActionOrigin(ESteamInputType eDestinationInputType, EInputActionOrigin eSourceOrigin) {
			return (EInputActionOrigin) 0;
		}
	}
}
