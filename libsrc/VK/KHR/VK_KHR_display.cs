using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	#region enums

	#endregion

	#region flags
	[Flags]
	public enum DisplayPlaneAlphaFlagsKhr : int
	{
		Opaque = 0x1,
		Global = 0x2,
		PerPixel = 0x4,
		PerPixelPremultiplied = 0x8,
	}
	#endregion

	#region structs
	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayKhr { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayModeKhr { public UInt64 native; }

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayPropertiesKhr
	{
		public UInt64 Display;
		public IntPtr DisplayName;
		public Extent2D PhysicalDimensions;
		public Extent2D PhysicalResolution;
		public SurfaceTransformFlagsKhr SupportedTransforms;
		public Bool32 PlaneReorderPossible;
		public Bool32 PersistentContent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayModeParametersKhr
	{
		Extent2D visibleRegion;
		UInt32 refreshRate;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayModePropertiesKhr
	{
		public UInt64 DisplayMode;
		public DisplayModeParametersKhr Parameters;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayModeCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public DisplayModeParametersKhr Parameters;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayPlaneCapabilitiesKhr
	{
		DisplayPlaneAlphaFlagsKhr supportedAlpha;
		Offset2D minSrcPosition;
		Offset2D maxSrcPosition;
		Extent2D minSrcExtent;
		Extent2D maxSrcExtent;
		Offset2D minDstPosition;
		Offset2D maxDstPosition;
		Extent2D minDstExtent;
		Extent2D maxDstExtent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayPlanePropertiesKhr
	{
		public UInt64 CurrentDisplay;
		public UInt32 CurrentStackIndex;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplaySurfaceCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt64 DisplayMode;
		public UInt32 PlaneIndex;
		public UInt32 PlaneStackIndex;
		public SurfaceTransformFlagsKhr Transform;
		public float GlobalAlpha;
		public DisplayPlaneAlphaFlagsKhr AlphaMode;
		public Extent2D ImageExtent;
	}
	#endregion

	#region functions
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, DisplayPropertiesKhr[] pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, DisplayPlanePropertiesKhr[] pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, out UInt32 pDisplayCount, DisplayKhr[] pDisplays);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKhr display, out UInt32 pPropertyCount, DisplayModePropertiesKhr[] pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKhr display, ref DisplayModeCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator, out DisplayModeKhr pMode);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKhr mode, UInt32 planeIndex, out DisplayPlaneCapabilitiesKhr pCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDisplayPlaneSurfaceKHR(PhysicalDevice instance, ref DisplaySurfaceCreateInfoKhr pCreateInfo, AllocationCallbacks pAllocator, out SurfaceKhr pSurface);


	}
	#endregion

	#region interop

	#endregion
}
