using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCreateViSurfaceNN", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateViSurfaceNN(IntPtr instance, ViSurfaceCreateInfoNn* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSurface);

	}
}