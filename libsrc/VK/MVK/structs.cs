using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct IOSSurfaceCreateInfoMVK
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public IntPtr View;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MacOSSurfaceCreateInfoMVK
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public IntPtr View;
	}
}