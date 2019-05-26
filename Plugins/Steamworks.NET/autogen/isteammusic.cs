// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamMusic {
		public static bool BIsEnabled() {
			return false;
		}

		public static bool BIsPlaying() {
			return false;
		}

		public static AudioPlayback_Status GetPlaybackStatus() {
			return (AudioPlayback_Status) 0;
		}

		public static void Play() {
		}

		public static void Pause() {
		}

		public static void PlayPrevious() {
		}

		public static void PlayNext() {
		}

		/// <para> volume is between 0.0 and 1.0</para>
		public static void SetVolume(float flVolume) {
		}

		public static float GetVolume() {
			return (float) 0.0;
		}
	}
}
