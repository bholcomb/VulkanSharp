using System;
using System.Collections.Generic;
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
		public List<UInt32> QueueFamilyIndices;
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
		static extern Result _CreateSwapchainKHR(Device device, ref _SwapchainCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator, out SwapchainKhr pSwapchain);
		public static Result CreateSwapchainKHR(Device device, ref SwapchainCreateInfoKhr pCreateInfo,out SwapchainKhr pSwapchain, AllocationCallbacks pAllocator = null)
		{
			_SwapchainCreateInfoKhr info = new _SwapchainCreateInfoKhr(pCreateInfo);

			Result res = _CreateSwapchainKHR(device, ref info, pAllocator, out pSwapchain);

			info.destroy();

			return res;
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySwapchainKHR(Device device, SwapchainKhr swapchain, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _GetSwapchainImagesKHR(Device device, SwapchainKhr swapchain, out UInt32 pSwapchainImageCount, IntPtr pSwapchainImages);
		public unsafe static Result GetSwapchainImagesKHR(Device device, SwapchainKhr swapchain, out UInt32 pSwapchainImageCount, Image[] pSwapchainImages)
		{
			if (pSwapchainImages == null)
			{
				return _GetSwapchainImagesKHR(device, swapchain, out pSwapchainImageCount, IntPtr.Zero);
			}
			else
			{
				fixed (Image* ptr = pSwapchainImages)
				{
					return _GetSwapchainImagesKHR(device, swapchain, out pSwapchainImageCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireNextImageKHR(Device device, SwapchainKhr swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, out UInt32 pImageIndex);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueuePresentKHR(Device queue, ref PresentInfoKhr pPresentInfo);

	}
	#endregion

	#region interop
	[StructLayout(LayoutKind.Sequential)]
	internal struct _SwapchainCreateInfoKhr
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

		public _SwapchainCreateInfoKhr(SwapchainCreateInfoKhr info)
		{
			SType = info.SType;
			Next = info.Next;
			Flags = info.Flags;
			Surface = info.Surface;
			MinImageCount = info.MinImageCount;
			ImageFormat = info.ImageFormat;
			ImageColorSpace = info.ImageColorSpace;
			ImageExtent = info.ImageExtent;
			ImageArrayLayers = info.ImageArrayLayers;
			ImageUsage = info.ImageUsage;
			ImageSharingMode = info.ImageSharingMode;
			QueueFamilyIndexCount = (UInt32)info.QueueFamilyIndices.Count;
			QueueFamilyIndices = Alloc.alloc(info.QueueFamilyIndices);
			PreTransform = info.PreTransform;
			CompositeAlpha = info.CompositeAlpha;
			PresentMode = info.PresentMode;
			Clipped = info.Clipped;
			OldSwapchain = info.OldSwapchain;
		}

		public void destroy()
		{
			Alloc.free(QueueFamilyIndices);
		}
	}
	#endregion
}
