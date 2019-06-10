// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

namespace Steamworks {
	class CallbackIdentities {
		public static int GetCallbackIdentity(System.Type callbackStruct) { return 0; }
	}

	[System.AttributeUsage(System.AttributeTargets.Struct, AllowMultiple = false)]
	internal class CallbackIdentityAttribute : System.Attribute {
		public int Identity { get; set; }
		public CallbackIdentityAttribute(int callbackNum) { Identity = callbackNum; }
	}
}
