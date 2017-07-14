using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DebugReportCallbackCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportFlagsExt Flags;
		public IntPtr PfnCallback;
		public IntPtr UserData;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ValidationFlagsExt
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 DisabledValidationCheckCount;
		public IntPtr DisabledValidationChecks;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DebugMarkerObjectNameInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportObjectTypeExt ObjectType;
		public UInt64 Object;
		public IntPtr ObjectName;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DebugMarkerObjectTagInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DebugReportObjectTypeExt ObjectType;
		public UInt64 Object;
		public UInt64 TagName;
		public UIntPtr TagSize;
		public IntPtr Tag;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct DebugMarkerMarkerInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public IntPtr MarkerName;
		public fixed float Color[4];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SurfaceCapabilities2Ext
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MinImageCount;
		public UInt32 MaxImageCount;
		public Extent2D CurrentExtent;
		public Extent2D MinImageExtent;
		public Extent2D MaxImageExtent;
		public UInt32 MaxImageArrayLayers;
		public SurfaceTransformFlagsKhr SupportedTransforms;
		public SurfaceTransformFlagsKhr CurrentTransform;
		public CompositeAlphaFlagsKhr SupportedCompositeAlpha;
		public ImageUsageFlags SupportedUsageFlags;
		public SurfaceCounterFlagsExt SupportedSurfaceCounters;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayPowerInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DisplayPowerStateExt PowerState;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceEventInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DeviceEventTypeExt DeviceEvent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DisplayEventInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public DisplayEventTypeExt DisplayEvent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SwapchainCounterCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public SurfaceCounterFlagsExt SurfaceCounters;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct HdrMetadataExt
	{
		public StructureType SType;
		public IntPtr Next;
		public XYColorExt DisplayPrimaryRed;
		public XYColorExt DisplayPrimaryGreen;
		public XYColorExt DisplayPrimaryBlue;
		public XYColorExt WhitePoint;
		public float MaxLuminance;
		public float MinLuminance;
		public float MaxContentLightLevel;
		public float MaxFrameAverageLightLevel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceDiscardRectanglePropertiesExt
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MaxDiscardRectangles;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineDiscardRectangleStateCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public DiscardRectangleModeExt DiscardRectangleMode;
		public UInt32 DiscardRectangleCount;
		public IntPtr DiscardRectangles;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceSamplerFilterMinmaxPropertiesExt
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 FilterMinmaxSingleComponentFormats;
		public Bool32 FilterMinmaxImageComponentMapping;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SamplerReductionModeCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public SamplerReductionModeExt ReductionMode;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceBlendOperationAdvancedFeaturesExt
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 AdvancedBlendCoherentOperations;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceBlendOperationAdvancedPropertiesExt
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 AdvancedBlendMaxColorAttachments;
		public Bool32 AdvancedBlendIndependentBlend;
		public Bool32 AdvancedBlendNonPremultipliedSrcColor;
		public Bool32 AdvancedBlendNonPremultipliedDstColor;
		public Bool32 AdvancedBlendCorrelatedOverlap;
		public Bool32 AdvancedBlendAllOperations;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineColorBlendAdvancedStateCreateInfoExt
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 SrcPremultiplied;
		public Bool32 DstPremultiplied;
		public BlendOverlapExt BlendOverlap;
	}
}