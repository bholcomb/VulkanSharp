using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	#region enums
	public enum ColorSpaceKHR : int
	{
		SrgbNonlinear = 0,
		DisplayP3NonlinearEXT = 1000104001,
		ExtendedSrgbLinearEXT = 1000104002,
		DciP3LinearEXT = 1000104003,
		DciP3NonlinearEXT = 1000104004,
		Bt709LinearEXT = 1000104005,
		Bt709NonlinearEXT = 1000104006,
		Bt2020LinearEXT = 1000104007,
		Hdr10St2084EXT = 1000104008,
		DolbyvisionEXT = 1000104009,
		Hdr10HlgEXT = 1000104010,
		AdobergbLinearEXT = 1000104011,
		AdobergbNonlinearEXT = 1000104012,
		PassThroughEXT = 1000104013,
	}

	public enum PresentModeKHR : int
	{
		Immediate = 0,
		Mailbox = 1,
		Fifo = 2,
		FifoRelaxed = 3,
		SharedDemandRefresh = 1000111000,
		SharedContinuousRefresh = 1000111001,
	}
	#endregion

	#region flags
	[Flags]
	public enum SurfaceTransformFlagsKHR : int
	{
		Identity = 0x1,
		Rotate90 = 0x2,
		Rotate180 = 0x4,
		Rotate270 = 0x8,
		HorizontalMirror = 0x10,
		HorizontalMirrorRotate90 = 0x20,
		HorizontalMirrorRotate180 = 0x40,
		HorizontalMirrorRotate270 = 0x80,
		Inherit = 0x100,
	}

	[Flags]
	public enum CompositeAlphaFlagsKHR : int
	{
		Opaque = 0x1,
		PreMultiplied = 0x2,
		PostMultiplied = 0x4,
		Inherit = 0x8,
	}
	#endregion

	#region structs
	[StructLayout(LayoutKind.Sequential)] public struct SurfaceKHR { public UInt64 native; }

	[StructLayout(LayoutKind.Sequential)]
	public struct SurfaceCapabilitiesKHR
	{
		public UInt32 minImageCount;
		public UInt32 maxImageCount;
		public Extent2D currentExtent;
		public Extent2D minImageExtent;
		public Extent2D maxImageExtent;
		public UInt32 maxImageArrayLayers;
		public SurfaceTransformFlagsKHR supportedTransforms;
		public SurfaceTransformFlagsKHR currentTransform;
		public SurfaceTransformFlagsKHR supportedCompositeAlpha;
		public ImageUsageFlags supportedUsageFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SurfaceFormatKHR
	{
		public Format format;
		public ColorSpaceKHR colorSpace;
	}

	#endregion

	#region functions
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, out Bool32 pSupported);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, out SurfaceCapabilitiesKHR pSurfaceCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, out UInt32 pSurfaceFormatCount, IntPtr pSurfaceFormats);
		public static unsafe Result GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, out UInt32 pSurfaceFormatCount, SurfaceFormatKHR[] pSurfaceFormats)
		{
			if (pSurfaceFormats == null)
			{
				return _GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, out pSurfaceFormatCount, IntPtr.Zero);
			}
			else
			{
				fixed (SurfaceFormatKHR* ptr = pSurfaceFormats)
				{
					return _GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, out pSurfaceFormatCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfacePresentModesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, out UInt32 pPresentModeCount, IntPtr pPresentModes);
		public static unsafe Result GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, out UInt32 pPresentModeCount, PresentModeKHR[] pPresentModes)
		{
			if (pPresentModes == null)
			{
				return _GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, out pPresentModeCount, IntPtr.Zero);
			}
			else
			{
				fixed (PresentModeKHR* ptr = pPresentModes)
				{
					return _GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, out pPresentModeCount, (IntPtr)ptr);
				}
			}
		}
	}
	#endregion

	#region interop

	#endregion
}
