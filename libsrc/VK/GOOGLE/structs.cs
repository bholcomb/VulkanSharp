using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PresentTimesInfoGOOGLE
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 SwapchainCount;
		public IntPtr Times;
	}
}