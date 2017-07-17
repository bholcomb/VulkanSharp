using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	#region enums

	#endregion

	#region flags
	[Flags]
	public enum SwapchainCreateFlagsKhr : int
	{
		BindSfrBitKhx = 0x1,
	}
	#endregion

	#region structs
	[StructLayout(LayoutKind.Sequential)]
	public struct SwapchainKhr { public UInt64 native; }

	[StructLayout(LayoutKind.Sequential)]
	public struct SwapchainCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public SwapchainCreateFlagsKhr Flags;
		public SurfaceKhr Surface;
		public UInt32 MinImageCount;
		public Format ImageFormat;
		public ColorSpaceKhr ImageColorSpace;
		public Extent2D ImageExtent;
		public UInt32 ImageArrayLayers;
		public ImageUsageFlags ImageUsage;
		public SharingMode ImageSharingMode;
		public UInt32 QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
		public SurfaceTransformFlagsKhr PreTransform;
		public CompositeAlphaFlagsKhr CompositeAlpha;
		public PresentModeKhr PresentMode;
		public Bool32 Clipped;
		public SwapchainKhr OldSwapchain;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PresentInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public UInt32 SwapchainCount;
		public IntPtr Swapchains;
		public IntPtr ImageIndices;
		public IntPtr Results;
	}

	#endregion

	#region functions
	public static partial class VK
	{

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateSwapchainKHR(Device device, ref SwapchainCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator, out SwapchainKhr pSwapchain);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySwapchainKHR(Device device, SwapchainKhr swapchain, AllocationCallbacks pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSwapchainImagesKHR(Device device, SwapchainKhr swapchain, out UInt32 pSwapchainImageCount, Image[] pSwapchainImages);

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireNextImageKHR(Device device, SwapchainKhr swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, out UInt32 pImageIndex);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueuePresentKHR(Device queue, ref PresentInfoKhr pPresentInfo);

	}
	#endregion

	#region interop

	#endregion
}
