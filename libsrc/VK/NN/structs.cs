using System;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ViSurfaceCreateInfoNn
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public IntPtr Window;
	}
}