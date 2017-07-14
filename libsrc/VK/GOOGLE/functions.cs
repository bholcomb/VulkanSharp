using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkGetRefreshCycleDurationGOOGLE", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetRefreshCycleDurationGOOGLE(IntPtr device, UInt64 swapchain, RefreshCycleDurationGOOGLE* pDisplayTimingProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPastPresentationTimingGOOGLE", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPastPresentationTimingGOOGLE(IntPtr device, UInt64 swapchain, UInt32* pPresentationTimingCount, PastPresentationTimingGOOGLE* pPresentationTimings);

	}
}