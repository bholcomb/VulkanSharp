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
	public struct Win32SurfaceCreateInfoKHR
	{
		public StructureType sType;
		public IntPtr pNext;
		public UInt32 flags;
		public IntPtr hinstance;
		public IntPtr hwnd;
	}
	#endregion

	#region functions
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCreateWin32SurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateWin32SurfaceKHR(Instance instance, ref Win32SurfaceCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, out SurfaceKHR pSurface);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceWin32PresentationSupportKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Bool32 GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex);
	}
	#endregion

	#region interop

	#endregion
}
