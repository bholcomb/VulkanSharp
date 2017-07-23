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
	public enum SwapchainCreateFlagsKHR : int
	{
		BindSfrBitKHX = 0x1,
	}
	#endregion

	#region structs
	[StructLayout(LayoutKind.Sequential)]
	public struct SwapchainKHR { public UInt64 native; }

	public struct SwapchainCreateInfoKHR
	{
		public StructureType SType;
		public IntPtr Next;
		public SwapchainCreateFlagsKHR Flags;
		public SurfaceKHR Surface;
		public UInt32 MinImageCount;
		public Format ImageFormat;
		public ColorSpaceKHR ImageColorSpace;
		public Extent2D ImageExtent;
		public UInt32 ImageArrayLayers;
		public ImageUsageFlags ImageUsage;
		public SharingMode ImageSharingMode;
		public List<UInt32> QueueFamilyIndices;
		public SurfaceTransformFlagsKHR PreTransform;
		public CompositeAlphaFlagsKHR CompositeAlpha;
		public PresentModeKHR PresentMode;
		public Bool32 Clipped;
		public SwapchainKHR OldSwapchain;
	}

	public struct PresentInfoKHR
	{
		public StructureType SType;
		public IntPtr Next;
		public List<Semaphore> WaitSemaphores;
		public List<SwapchainKHR> Swapchains;
		public List<UInt32> Indices;
		public List<Result> Results;
	}

	#endregion

	#region functions
	public static partial class VK
	{

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateSwapchainKHR(Device device, ref _SwapchainCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, out SwapchainKHR pSwapchain);
		public static Result CreateSwapchainKHR(Device device, ref SwapchainCreateInfoKHR pCreateInfo,out SwapchainKHR pSwapchain, AllocationCallbacks pAllocator = null)
		{
			_SwapchainCreateInfoKHR info = new _SwapchainCreateInfoKHR(pCreateInfo);

			Result res = _CreateSwapchainKHR(device, ref info, pAllocator, out pSwapchain);

			info.destroy();

			return res;
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, out UInt32 pSwapchainImageCount, IntPtr pSwapchainImages);
		public unsafe static Result GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, out UInt32 pSwapchainImageCount, Image[] pSwapchainImages)
		{
			fixed (Image* ptr = pSwapchainImages)
			{
				return _GetSwapchainImagesKHR(device, swapchain, out pSwapchainImageCount, (IntPtr)ptr);
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, out UInt32 pImageIndex);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _QueuePresentKHR(Queue queue, ref _PresentInfoKHR pPresentInfo);
		public unsafe static Result QueuePresentKHR(Queue queue, ref PresentInfoKHR pPresentInfo)
		{
			_PresentInfoKHR p = new _PresentInfoKHR(pPresentInfo);

			int resultsCount = (pPresentInfo.Results == null || pPresentInfo.Results.Count == 0) ? 0 : pPresentInfo.Results.Count;

			Result res = _QueuePresentKHR(queue, ref p);

			if(resultsCount > 0)
			{
				pPresentInfo.Results =  p.getResults(resultsCount);
			}

			p.destroy();

			return res;
		}
	}
	#endregion

	#region interop
	[StructLayout(LayoutKind.Sequential)]
	internal struct _SwapchainCreateInfoKHR
	{
		public StructureType SType;
		public IntPtr Next;
		public SwapchainCreateFlagsKHR Flags;
		public SurfaceKHR Surface;
		public UInt32 MinImageCount;
		public Format ImageFormat;
		public ColorSpaceKHR ImageColorSpace;
		public Extent2D ImageExtent;
		public UInt32 ImageArrayLayers;
		public ImageUsageFlags ImageUsage;
		public SharingMode ImageSharingMode;
		public UInt32 QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
		public SurfaceTransformFlagsKHR PreTransform;
		public CompositeAlphaFlagsKHR CompositeAlpha;
		public PresentModeKHR PresentMode;
		public Bool32 Clipped;
		public SwapchainKHR OldSwapchain;

		public _SwapchainCreateInfoKHR(SwapchainCreateInfoKHR info)
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
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct _PresentInfoKHR
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public UInt32 SwapchainCount;
		public IntPtr Swapchains;
		public IntPtr ImageIndices;
		public IntPtr Results;

		public _PresentInfoKHR(PresentInfoKHR info)
		{
			SType = info.SType;
			Next = info.Next;
			WaitSemaphoreCount = (UInt32)info.WaitSemaphores.Count;
			SwapchainCount = (UInt32)info.Swapchains.Count;

			WaitSemaphores = Alloc.alloc(info.WaitSemaphores);
			Swapchains = Alloc.alloc(info.Swapchains);
			ImageIndices = Alloc.alloc(info.Indices);

			List<UInt32> res;
			if (info.Results == null || info.Results.Count == 0)
			{
				Results = IntPtr.Zero;
			}
			else
			{
				res = new List<UInt32>(info.Results.Count);
				Results = Alloc.alloc(res);
			}
		}

		public List<Result> getResults(int count)
		{
			int[] vals = new int[count];
			Marshal.Copy(Results, vals, 0, count);

			List<Result> ret = new List<Result>(count);
			foreach (int v in vals)
			{
				ret.Add((Result)v);
			}

			return ret;
		}

		public void destroy()
		{
			Alloc.free(WaitSemaphores);
			Alloc.free(Swapchains);
			Alloc.free(ImageIndices);
			Alloc.free(Results);
		}
	}
	#endregion
}
