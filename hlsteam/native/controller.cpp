#include "steamwrap.h"

/*
void CallbackHandler::OnGamepadTextInputDismissed( GamepadTextInputDismissed_t *pCallback ){
	SendEvent(GamepadTextInputDismissed, pCallback->m_bSubmitted, NULL);
}
*/


//A simple data structure that holds on to the native 64-bit handles and maps them to regular ints.
//This is because it is cumbersome to pass back 64-bit values over CFFI, and strictly speaking, the haxe
//side never needs to know the actual values. So we just store the full 64-bit values locally and pass back
//0-based index values which easily fit into a regular int.
class steamHandleMap{

	private:
		std::map<int, uint64> values;
		std::map<int, uint64>::iterator it;
		int maxKey;

	public:

		void init()		{
			values.clear();
			maxKey = -1;
		}

		bool exists(uint64 val){
			return find(val) >= 0;
		}

		int find(uint64 val){
			for(int i = 0; i <= maxKey; i++){
				if(values[i] == val)
					return i;
			}
			return -1;
		}

		uint64 get(int index){
			return values[index];
		}

		int add(uint64 val)	{
			int i = find(val);

			if(i >= 0)
				return i;

			maxKey++;
			values[maxKey] = val;

			return maxKey;
		}
};

static steamHandleMap mapControllers;

HL_PRIM bool HL_NAME(init_controllers)(){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, init_controllers, _NO_ARG);

HL_PRIM bool HL_NAME(shutdown_controllers)(){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, shutdown_controllers, _NO_ARG);

HL_PRIM bool HL_NAME(show_binding_panel)(int controller){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, show_binding_panel, _I32);

HL_PRIM bool HL_NAME(show_gamepad_text_input)(int inputMode, int lineMode, vbyte *description, int charMax, vbyte *existingText){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, show_gamepad_text_input, _I32 _I32 _BYTES _I32 _BYTES);

HL_PRIM vbyte *HL_NAME(get_entered_gamepad_text_input)(){
	printf("%s\n", __func__);
	return (vbyte*)"";

}
DEFINE_PRIM(_BYTES, get_entered_gamepad_text_input, _NO_ARG);

HL_PRIM varray *HL_NAME(get_connected_controllers)(varray *arr){
	printf("%s\n", __func__);
	return nullptr;
}
DEFINE_PRIM(_ARR, get_connected_controllers, _ARR);

HL_PRIM int HL_NAME(get_action_set_handle)(vbyte *actionSetName){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_action_set_handle, _BYTES);

HL_PRIM int HL_NAME(get_digital_action_handle)(vbyte *actionName){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_digital_action_handle, _BYTES);

HL_PRIM int HL_NAME(get_analog_action_handle)(vbyte *actionName){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_analog_action_handle, _BYTES);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM int HL_NAME(get_digital_action_data)(int controllerHandle, int actionHandle){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_digital_action_data, _I32 _I32);


//-----------------------------------------------------------------------------------------------------------

typedef struct {
	hl_type *t;
	bool bActive;
	int eMode;
	double x;
	double y;
} analog_action_data;

HL_PRIM void HL_NAME(get_analog_action_data)(int controllerHandle, int actionHandle, analog_action_data *data){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, get_analog_action_data, _I32 _I32 _OBJ(_BOOL _I32 _F64 _F64));

HL_PRIM varray *HL_NAME(get_digital_action_origins)(int controllerHandle, int actionSetHandle, int digitalActionHandle){
	printf("%s\n", __func__);
	return nullptr;
}
DEFINE_PRIM(_ARR, get_digital_action_origins, _I32 _I32 _I32);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM varray *HL_NAME(get_analog_action_origins)(int controllerHandle, int actionSetHandle, int analogActionHandle){
	printf("%s\n", __func__);
	return nullptr;
}
DEFINE_PRIM(_ARR, get_analog_action_origins, _I32 _I32 _I32);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM vbyte *HL_NAME(get_glyph_for_action_origin)(int origin){
	printf("%s\n", __func__);
	return nullptr;
}
DEFINE_PRIM(_BYTES, get_glyph_for_action_origin, _I32);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM vbyte *HL_NAME(get_string_for_action_origin)(int origin){
	printf("%s\n", __func__);
	return NULL;
}
DEFINE_PRIM(_BYTES, get_string_for_action_origin, _I32);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM void HL_NAME(activate_action_set)(int controllerHandle, int actionSetHandle){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, activate_action_set, _I32 _I32);

//-----------------------------------------------------------------------------------------------------------
HL_PRIM int HL_NAME(get_current_action_set)(int controllerHandle){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_current_action_set, _I32);

HL_PRIM void HL_NAME(trigger_haptic_pulse)(int controllerHandle, int targetPad, int durationMicroSec){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, trigger_haptic_pulse, _I32 _I32 _I32);

HL_PRIM void HL_NAME(trigger_repeated_haptic_pulse)(int controllerHandle, int targetPad, int durationMicroSec, int offMicroSec, int repeat, int flags){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, trigger_repeated_haptic_pulse, _I32 _I32 _I32 _I32 _I32 _I32);

HL_PRIM void HL_NAME(trigger_vibration)(int controllerHandle, int leftSpeed, int rightSpeed){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, trigger_vibration, _I32 _I32 _I32);

HL_PRIM void HL_NAME(set_led_color)(int controllerHandle, int r, int g, int b, int flags){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, set_led_color, _I32 _I32 _I32 _I32 _I32);

//-----------------------------------------------------------------------------------------------------------
typedef struct {
	hl_type *t;
	double rotQuatX;
	double rotQuatY;
	double rotQuatZ;
	double rotQuatW;
	double posAccelX;
	double posAccelY;
	double posAccelZ;
	double rotVelX;
	double rotVelY;
	double rotVelZ;
} motion_data;

HL_PRIM void HL_NAME(get_motion_data)(int controllerHandle, motion_data *data){
	printf("%s\n", __func__);
}
DEFINE_PRIM(_VOID, get_motion_data, _I32 _OBJ(_F64 _F64 _F64 _F64 _F64 _F64 _F64 _F64 _F64 _F64));

HL_PRIM bool HL_NAME(show_digital_action_origins)(int controllerHandle, int digitalActionHandle, double scale, double xPosition, double yPosition){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, show_digital_action_origins, _I32 _I32 _F64 _F64 _F64);

HL_PRIM bool HL_NAME(show_analog_action_origins)(int controllerHandle, int analogActionHandle, double scale, double xPosition, double yPosition){
	printf("%s\n", __func__);
	return false;
}
DEFINE_PRIM(_BOOL, show_analog_action_origins, _I32 _I32 _F64 _F64 _F64);


//-----------------------------------------------------------------------------------------------------------
HL_PRIM int HL_NAME(get_controller_max_count)(){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_controller_max_count, _NO_ARG);

HL_PRIM int HL_NAME(get_controller_max_analog_actions)(){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_controller_max_analog_actions, _NO_ARG);

HL_PRIM int HL_NAME(get_controller_max_digital_actions)(){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_controller_max_digital_actions, _NO_ARG);

HL_PRIM int HL_NAME(get_controller_max_origins)(){
	printf("%s\n", __func__);
	return 0;
}
DEFINE_PRIM(_I32, get_controller_max_origins, _NO_ARG);

HL_PRIM double HL_NAME(get_controller_min_analog_action_data)(){
	printf("%s\n", __func__);
	return (double)0;
}
DEFINE_PRIM(_F64, get_controller_min_analog_action_data, _NO_ARG);

HL_PRIM double HL_NAME(get_controller_max_analog_action_data)(){
	printf("%s\n", __func__);
	return (double)0;
}
DEFINE_PRIM(_F64, get_controller_max_analog_action_data, _NO_ARG);

