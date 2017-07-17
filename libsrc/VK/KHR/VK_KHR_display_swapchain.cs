using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	#region enums

	#endregion

	#region flags

	#endregion

	#region structs
	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayPresentInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public Rect2D SrcRect;
		public Rect2D DstRect;
		public Bool32 Persistent;
	}
	#endregion

	#region functions
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKhr[] pCreateInfos, AllocationCallbacks pAllocator, out SwapchainKhr[] pSwapchains);

	}
	#endregion

	#region interop

	#endregion
}
