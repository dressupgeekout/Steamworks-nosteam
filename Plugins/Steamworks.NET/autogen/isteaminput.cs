// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamInput {
		/// Init and Shutdown must be called when starting/ending use of this interface
		public static bool Init() { return false; }

		public static bool Shutdown() { return false; }

		/// Synchronize API state with the latest Steam Controller inputs available. This
		/// is performed automatically by SteamAPI_RunCallbacks, but for the absolute lowest
		/// possible latency, you call this directly before reading controller state. This must
		/// be called from somewhere before GetConnectedControllers will return any handles
		public static void RunFrame() { }

		/// Enumerate currently connected Steam Input enabled devices - developers can opt in controller by type (ex: Xbox/Playstation/etc) via
		/// the Steam Input settings in the Steamworks site or users can opt-in in their controller settings in Steam.
		/// handlesOut should point to a STEAM_INPUT_MAX_COUNT sized array of InputHandle_t handles
		/// Returns the number of handles written to handlesOut
		public static int GetConnectedControllers(InputHandle_t[] handlesOut) {
			return 0;
		}

		/// ACTION SETS

		/// Lookup the handle for an Action Set. Best to do this once on startup, and store the handles for all future API calls.
		public static InputActionSetHandle_t GetActionSetHandle(string pszActionSetName) {
			return (InputActionSetHandle_t) 0;
		}

		/// Reconfigure the controller to use the specified action set (ie 'Menu', 'Walk' or 'Drive')
		/// This is cheap, and can be safely called repeatedly. It's often easier to repeatedly call it in
		/// your state loops, instead of trying to place it in all of your state transitions.
		public static void ActivateActionSet(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle) { }

		public static InputActionSetHandle_t GetCurrentActionSet(InputHandle_t inputHandle) {
			return (InputActionSetHandle_t) 0;
		}

		/// ACTION SET LAYERS
		public static void ActivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle) { }

		public static void DeactivateActionSetLayer(InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle) { }

		public static void DeactivateAllActionSetLayers(InputHandle_t inputHandle) { }

		public static int GetActiveActionSetLayers(InputHandle_t inputHandle, out InputActionSetHandle_t handlesOut) {
			handlesOut = (InputActionSetHandle_t) 0;
			return 0;
		}

		/// ACTIONS

		/// Lookup the handle for a digital action. Best to do this once on startup, and store the handles for all future API calls.
		public static InputDigitalActionHandle_t GetDigitalActionHandle(string pszActionName) {
			return (InputDigitalActionHandle_t) 0;
		}

		/// Returns the current state of the supplied digital game action
		public static InputDigitalActionData_t GetDigitalActionData(InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle) {
			InputDigitalActionData_t ret = new InputDigitalActionData_t();
			return ret;
		}

		/// Get the origin(s) for a digital action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.
		/// originsOut should point to a STEAM_INPUT_MAX_ORIGINS sized array of EInputActionOrigin handles. The EInputActionOrigin enum will get extended as support for new controller controllers gets added to
		/// the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.
		public static int GetDigitalActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, EInputActionOrigin[] originsOut) {
			return 0;
		}

		/// Lookup the handle for an analog action. Best to do this once on startup, and store the handles for all future API calls.
		public static InputAnalogActionHandle_t GetAnalogActionHandle(string pszActionName) {
			return (InputAnalogActionHandle_t) 0;
		}

		/// Returns the current state of these supplied analog game action
		public static InputAnalogActionData_t GetAnalogActionData(InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle) {
			InputAnalogActionData_t ret = new InputAnalogActionData_t();
			return ret;
		}

		/// Get the origin(s) for an analog action within an action set. Returns the number of origins supplied in originsOut. Use this to display the appropriate on-screen prompt for the action.
		/// originsOut should point to a STEAM_INPUT_MAX_ORIGINS sized array of EInputActionOrigin handles. The EInputActionOrigin enum will get extended as support for new controller controllers gets added to
		/// the Steam client and will exceed the values from this header, please check bounds if you are using a look up table.
		public static int GetAnalogActionOrigins(InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, EInputActionOrigin[] originsOut) {
			return 0;
		}

		/// Get a local path to art for on-screen glyph for a particular origin - this call is cheap
		public static string GetGlyphForActionOrigin(EInputActionOrigin eOrigin) {
			return "";
		}

		/// Returns a localized string (from Steam's language setting) for the specified origin - this call is serialized
		public static string GetStringForActionOrigin(EInputActionOrigin eOrigin) {
			return "";
		}

		/// Stop analog momentum for the action if it is a mouse action in trackball mode
		public static void StopAnalogActionMomentum(InputHandle_t inputHandle, InputAnalogActionHandle_t eAction) { }

		/// Returns raw motion data from the specified device
		public static InputMotionData_t GetMotionData(InputHandle_t inputHandle) {
			InputMotionData_t ret = new InputMotionData_t();
			return ret;
		}

		/// OUTPUTS

		/// Trigger a vibration event on supported controllers - Steam will translate these commands into haptic pulses for Steam Controllers
		public static void TriggerVibration(InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed) { }

		/// Set the controller LED color on supported controllers. nFlags is a bitmask of values from ESteamInputLEDFlag - 0 will default to setting a color. Steam will handle
		/// the behavior on exit of your program so you don't need to try restore the default as you are shutting down
		public static void SetLEDColor(InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags) { }

		/// Trigger a haptic pulse on a Steam Controller - if you are approximating rumble you may want to use TriggerVibration instead.
		/// Good uses for Haptic pulses include chimes, noises, or directional gameplay feedback (taking damage, footstep locations, etc).
		public static void TriggerHapticPulse(InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec) { }

		/// Trigger a haptic pulse with a duty cycle of usDurationMicroSec / usOffMicroSec, unRepeat times. If you are approximating rumble you may want to use TriggerVibration instead.
		/// nFlags is currently unused and reserved for future use.
		public static void TriggerRepeatedHapticPulse(InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags) { }

		/// Utility functions availible without using the rest of Steam Input API

		/// Invokes the Steam overlay and brings up the binding screen if the user is using Big Picture Mode
		/// If the user is not in Big Picture Mode it will open up the binding in a new window
		public static bool ShowBindingPanel(InputHandle_t inputHandle) {
			return false;
		}

		/// Returns the input type for a particular handle
		public static ESteamInputType GetInputTypeForHandle(InputHandle_t inputHandle) {
			return (ESteamInputType) 0;
		}

		/// Returns the associated controller handle for the specified emulated gamepad - can be used with the above 2 functions
		/// to identify controllers presented to your game over Xinput. Returns 0 if the Xinput index isn't associated with Steam Input
		public static InputHandle_t GetControllerForGamepadIndex(int nIndex) {
			return (InputHandle_t) 0;
		}

		/// Returns the associated gamepad index for the specified controller, if emulating a gamepad or -1 if not associated with an Xinput index
		public static int GetGamepadIndexForController(InputHandle_t ulinputHandle) {
			return 0;
		}

		/// Returns a localized string (from Steam's language setting) for the specified Xbox controller origin. This function is cheap.
		public static string GetStringForXboxOrigin(EXboxOrigin eOrigin) {
			return "";
		}

		/// Get a local path to art for on-screen glyph for a particular Xbox controller origin. This function is serialized.
		public static string GetGlyphForXboxOrigin(EXboxOrigin eOrigin) {
			return "";
		}

		/// Get the equivalent ActionOrigin for a given Xbox controller origin this can be chained with GetGlyphForActionOrigin to provide future proof glyphs for
		/// non-Steam Input API action games. Note - this only translates the buttons directly and doesn't take into account any remapping a user has made in their configuration
		public static EInputActionOrigin GetActionOriginFromXboxOrigin(InputHandle_t inputHandle, EXboxOrigin eOrigin) {
			return (EInputActionOrigin) 0;
		}

		/// Convert an origin to another controller type - for inputs not present on the other controller type this will return k_EInputActionOrigin_None
		/// When a new input type is added you will be able to pass in k_ESteamInputType_Unknown amd the closest origin that your version of the SDK regonized will be returned
		/// ex: if a Playstation 5 controller was released this function would return Playstation 4 origins.
		public static EInputActionOrigin TranslateActionOrigin(ESteamInputType eDestinationInputType, EInputActionOrigin eSourceOrigin) {
			return (EInputActionOrigin) 0;
		}
	}
}
