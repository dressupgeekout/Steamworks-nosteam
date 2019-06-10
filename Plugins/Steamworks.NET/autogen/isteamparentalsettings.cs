// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamParentalSettings {
		public static bool BIsParentalLockEnabled() { return false; }
		public static bool BIsParentalLockLocked() { return false; }
		public static bool BIsAppBlocked(AppId_t nAppID) { return false; }
		public static bool BIsAppInBlockList(AppId_t nAppID) { return false; }
		public static bool BIsFeatureBlocked(EParentalFeature eFeature) { return false; }
		public static bool BIsFeatureInBlockList(EParentalFeature eFeature) { return false; }
	}
}
