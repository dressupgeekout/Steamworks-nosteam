// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class Packsize {
		public const int value = 4;
		public static bool Test() { return true; }

		[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
		struct ValvePackingSentinel_t {
			uint m_u32;
			ulong m_u64;
			ushort m_u16;
			double m_d;
		};
	}
}
