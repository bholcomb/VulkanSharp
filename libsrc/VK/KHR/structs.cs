using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
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

	public struct DisplayPlanePropertiesKhr
	{
		public UInt64 CurrentDisplay;
		public UInt32 CurrentStackIndex;
	}

	public struct DisplayModePropertiesKhr
	{
		public UInt64 DisplayMode;
		public DisplayModeParametersKhr Parameters;
	}

	public struct DisplayModeCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public DisplayModeParametersKhr Parameters;
	}

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

	public struct DisplayPresentInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public Rect2D SrcRect;
		public Rect2D DstRect;
		public Bool32 Persistent;
	}

	public struct SwapchainCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public SwapchainCreateFlagsKhr Flags;
		public UInt64 Surface;
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
		public UInt64 OldSwapchain;
	}

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

	public struct PhysicalDeviceFeatures2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public PhysicalDeviceFeatures Features;
	}

	public struct PhysicalDeviceProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public PhysicalDeviceProperties Properties;
	}

	public struct FormatProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public FormatProperties FormatProperties;
	}

	public struct ImageFormatProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public ImageFormatProperties ImageFormatProperties;
	}

	public struct PhysicalDeviceImageFormatInfo2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public Format Format;
		public ImageType Type;
		public ImageTiling Tiling;
		public ImageUsageFlags Usage;
		public ImageCreateFlags Flags;
	}

	public struct QueueFamilyProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public QueueFamilyProperties QueueFamilyProperties;
	}

	public struct PhysicalDeviceMemoryProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public PhysicalDeviceMemoryProperties MemoryProperties;
	}

	public struct SparseImageFormatProperties2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public SparseImageFormatProperties Properties;
	}

	public struct PhysicalDeviceSparseImageFormatInfo2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public Format Format;
		public ImageType Type;
		public SampleCountFlags Samples;
		public ImageUsageFlags Usage;
		public ImageTiling Tiling;
	}

	public struct PhysicalDevicePushDescriptorPropertiesKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MaxPushDescriptors;
	}

	public struct PresentRegionsKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 SwapchainCount;
		public IntPtr Regions;
	}

	public struct PresentRegionKhr
	{
		public UInt32 RectangleCount;
		public IntPtr Rectangles;
	}

	public struct DescriptorUpdateTemplateCreateInfoKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 DescriptorUpdateEntryCount;
		public IntPtr DescriptorUpdateEntries;
		public DescriptorUpdateTemplateTypeKhr TemplateType;
		public UInt64 DescriptorSetLayout;
		public PipelineBindPoint PipelineBindPoint;
		public UInt64 PipelineLayout;
		public UInt32 Set;
	}


	public struct PhysicalDeviceSurfaceInfo2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Surface;
	}

	public struct SurfaceCapabilities2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public SurfaceCapabilitiesKhr SurfaceCapabilities;
	}

	public struct SurfaceFormat2Khr
	{
		public StructureType SType;
		public IntPtr Next;
		public SurfaceFormatKhr SurfaceFormat;
	}

	public struct SharedPresentSurfaceCapabilitiesKhr
	{
		public StructureType SType;
		public IntPtr Next;
		public ImageUsageFlags SharedPresentSupportedUsageFlags;
	}
}