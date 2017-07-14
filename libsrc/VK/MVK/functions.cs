using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCreateIOSSurfaceMVK", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateIOSSurfaceMVK(IntPtr instance, IOSSurfaceCreateInfoMVK* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSurface);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateMacOSSurfaceMVK", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateMacOSSurfaceMVK(IntPtr instance, MacOSSurfaceCreateInfoMVK* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSurface);
	}
}