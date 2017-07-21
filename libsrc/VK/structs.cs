using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct ApplicationInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public string ApplicationName;
		public UInt32 ApplicationVersion;
		public string EngineName;
		public UInt32 EngineVersion;
		public UInt32 ApiVersion;
	}

	//public instance of object, there is an internal version used in the function
	public struct InstanceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public ApplicationInfo ApplicationInfo;
		public List<String> EnabledLayerNames;
		public List<String> EnabledExtensionNames;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class AllocationCallbacks
	{
		public IntPtr UserData;
		public AllocationFunction PfnAllocation;
		public ReallocationFunction PfnReallocation;
		public FreeFunction PfnFree;
		public InternalAllocationNotification PfnInternalAllocation;
		public InternalFreeNotification PfnInternalFree;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceFeatures
	{
		public Bool32 robustBufferAccess;
		public Bool32 fullDrawIndexUint32;
		public Bool32 imageCubeArray;
		public Bool32 independentBlend;
		public Bool32 geometryShader;
		public Bool32 tessellationShader;
		public Bool32 sampleRateShading;
		public Bool32 dualSrcBlend;
		public Bool32 logicOp;
		public Bool32 multiDrawIndirect;
		public Bool32 drawIndirectFirstInstance;
		public Bool32 depthClamp;
		public Bool32 depthBiasClamp;
		public Bool32 fillModeNonSolid;
		public Bool32 depthBounds;
		public Bool32 wideLines;
		public Bool32 largePoints;
		public Bool32 alphaToOne;
		public Bool32 multiViewport;
		public Bool32 samplerAnisotropy;
		public Bool32 textureCompressionETC2;
		public Bool32 textureCompressionASTC_LDR;
		public Bool32 textureCompressionBC;
		public Bool32 occlusionQueryPrecise;
		public Bool32 pipelineStatisticsQuery;
		public Bool32 vertexPipelineStoresAndAtomics;
		public Bool32 fragmentStoresAndAtomics;
		public Bool32 shaderTessellationAndGeometryPointSize;
		public Bool32 shaderImageGatherExtended;
		public Bool32 shaderStorageImageExtendedFormats;
		public Bool32 shaderStorageImageMultisample;
		public Bool32 shaderStorageImageReadWithoutFormat;
		public Bool32 shaderStorageImageWriteWithoutFormat;
		public Bool32 shaderUniformBufferArrayDynamicIndexing;
		public Bool32 shaderSampledImageArrayDynamicIndexing;
		public Bool32 shaderStorageBufferArrayDynamicIndexing;
		public Bool32 shaderStorageImageArrayDynamicIndexing;
		public Bool32 shaderClipDistance;
		public Bool32 shaderCullDistance;
		public Bool32 shaderFloat64;
		public Bool32 shaderInt64;
		public Bool32 shaderInt16;
		public Bool32 shaderResourceResidency;
		public Bool32 shaderResourceMinLod;
		public Bool32 sparseBinding;
		public Bool32 sparseResidencyBuffer;
		public Bool32 sparseResidencyImage2D;
		public Bool32 sparseResidencyImage3D;
		public Bool32 sparseResidency2Samples;
		public Bool32 sparseResidency4Samples;
		public Bool32 sparseResidency8Samples;
		public Bool32 sparseResidency16Samples;
		public Bool32 sparseResidencyAliased;
		public Bool32 variableMultisampleRate;
		public Bool32 inheritedQueries;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FormatProperties
	{
		public FormatFeatureFlags linearTilingFeatures;
		public FormatFeatureFlags optimalTilingFeatures;
		public FormatFeatureFlags bufferFeatures;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Extent3D
	{
		public UInt32 Width;
		public UInt32 Height;
		public UInt32 Depth;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageFormatProperties
	{
		public Extent3D maxExtent;
		public UInt32 maxMipLevels;
		public UInt32 maxArrayLayers;
		public SampleCountFlags sampleCounts;
		public DeviceSize maxResourceSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PhysicalDeviceLimits
	{
		public UInt32 MaxImageDimension1D;
		public UInt32 MaxImageDimension2D;
		public UInt32 MaxImageDimension3D;
		public UInt32 MaxImageDimensionCube;
		public UInt32 MaxImageArrayLayers;
		public UInt32 MaxTexelBufferElements;
		public UInt32 MaxUniformBufferRange;
		public UInt32 MaxStorageBufferRange;
		public UInt32 MaxPushConstantsSize;
		public UInt32 MaxMemoryAllocationCount;
		public UInt32 MaxSamplerAllocationCount;
		public DeviceSize BufferImageGranularity;
		public DeviceSize SparseAddressSpaceSize;
		public UInt32 MaxBoundDescriptorSets;
		public UInt32 MaxPerStageDescriptorSamplers;
		public UInt32 MaxPerStageDescriptorUniformBuffers;
		public UInt32 MaxPerStageDescriptorStorageBuffers;
		public UInt32 MaxPerStageDescriptorSampledImages;
		public UInt32 MaxPerStageDescriptorStorageImages;
		public UInt32 MaxPerStageDescriptorInputAttachments;
		public UInt32 MaxPerStageResources;
		public UInt32 MaxDescriptorSetSamplers;
		public UInt32 MaxDescriptorSetUniformBuffers;
		public UInt32 MaxDescriptorSetUniformBuffersDynamic;
		public UInt32 MaxDescriptorSetStorageBuffers;
		public UInt32 MaxDescriptorSetStorageBuffersDynamic;
		public UInt32 MaxDescriptorSetSampledImages;
		public UInt32 MaxDescriptorSetStorageImages;
		public UInt32 MaxDescriptorSetInputAttachments;
		public UInt32 MaxVertexInputAttributes;
		public UInt32 MaxVertexInputBindings;
		public UInt32 MaxVertexInputAttributeOffset;
		public UInt32 MaxVertexInputBindingStride;
		public UInt32 MaxVertexOutputComponents;
		public UInt32 MaxTessellationGenerationLevel;
		public UInt32 MaxTessellationPatchSize;
		public UInt32 MaxTessellationControlPerVertexInputComponents;
		public UInt32 MaxTessellationControlPerVertexOutputComponents;
		public UInt32 MaxTessellationControlPerPatchOutputComponents;
		public UInt32 MaxTessellationControlTotalOutputComponents;
		public UInt32 MaxTessellationEvaluationInputComponents;
		public UInt32 MaxTessellationEvaluationOutputComponents;
		public UInt32 MaxGeometryShaderInvocations;
		public UInt32 MaxGeometryInputComponents;
		public UInt32 MaxGeometryOutputComponents;
		public UInt32 MaxGeometryOutputVertices;
		public UInt32 MaxGeometryTotalOutputComponents;
		public UInt32 MaxFragmentInputComponents;
		public UInt32 MaxFragmentOutputAttachments;
		public UInt32 MaxFragmentDualSrcAttachments;
		public UInt32 MaxFragmentCombinedOutputResources;
		public UInt32 MaxComputeSharedMemorySize;
		public fixed UInt32 MaxComputeWorkGroupCount[3];
		public UInt32 MaxComputeWorkGroupInvocations;
		public fixed UInt32 MaxComputeWorkGroupSize[3];
		public UInt32 SubPixelPrecisionBits;
		public UInt32 SubTexelPrecisionBits;
		public UInt32 MipmapPrecisionBits;
		public UInt32 MaxDrawIndexedIndexValue;
		public UInt32 MaxDrawIndirectCount;
		public float MaxSamplerLodBias;
		public float MaxSamplerAnisotropy;
		public UInt32 MaxViewports;
		public fixed UInt32 MaxViewportDimensions[2];
		public fixed float ViewportBoundsRange[2];
		public UInt32 ViewportSubPixelBits;
		public UIntPtr MinMemoryMapAlignment;
		public DeviceSize MinTexelBufferOffsetAlignment;
		public DeviceSize MinUniformBufferOffsetAlignment;
		public DeviceSize MinStorageBufferOffsetAlignment;
		public Int32 MinTexelOffset;
		public UInt32 MaxTexelOffset;
		public Int32 MinTexelGatherOffset;
		public UInt32 MaxTexelGatherOffset;
		public float MinInterpolationOffset;
		public float MaxInterpolationOffset;
		public UInt32 SubPixelInterpolationOffsetBits;
		public UInt32 MaxFramebufferWidth;
		public UInt32 MaxFramebufferHeight;
		public UInt32 MaxFramebufferLayers;
		public SampleCountFlags FramebufferColorSampleCounts;
		public SampleCountFlags FramebufferDepthSampleCounts;
		public SampleCountFlags FramebufferStencilSampleCounts;
		public SampleCountFlags FramebufferNoAttachmentsSampleCounts;
		public UInt32 MaxColorAttachments;
		public SampleCountFlags SampledImageColorSampleCounts;
		public SampleCountFlags SampledImageIntegerSampleCounts;
		public SampleCountFlags SampledImageDepthSampleCounts;
		public SampleCountFlags SampledImageStencilSampleCounts;
		public SampleCountFlags StorageImageSampleCounts;
		public UInt32 MaxSampleMaskWords;
		public Bool32 TimestampComputeAndGraphics;
		public float TimestampPeriod;
		public UInt32 MaxClipDistances;
		public UInt32 MaxCullDistances;
		public UInt32 MaxCombinedClipAndCullDistances;
		public UInt32 DiscreteQueuePriorities;
		public fixed float PointSizeRange[2];
		public fixed float LineWidthRange[2];
		public float PointSizeGranularity;
		public float LineWidthGranularity;
		public Bool32 StrictLines;
		public Bool32 StandardSampleLocations;
		public DeviceSize OptimalBufferCopyOffsetAlignment;
		public DeviceSize OptimalBufferCopyRowPitchAlignment;
		public DeviceSize NonCoherentAtomSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceSparseProperties
	{
		public Bool32 residencyStandard2DBlockShape;
		public Bool32 residencyStandard2DMultisampleBlockShape;
		public Bool32 residencyStandard3DBlockShape;
		public Bool32 residencyAlignedMipSize;
		public Bool32 residencyNonResidentStrict;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PhysicalDeviceProperties
	{
		public UInt32 ApiVersion;
		public UInt32 DriverVersion;
		public UInt32 VendorId;
		public UInt32 DeviceId;
		public PhysicalDeviceType DeviceType;
		fixed byte _DeviceName[256];
		public string DeviceName
		{
			get
			{
				fixed (byte* p = _DeviceName)
				{
					return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
		}
		fixed byte _PipelineCacheUuid[16];
		public string PipelineCacheUuid
		{
			get
			{
				fixed (byte* p = _PipelineCacheUuid)
				{
					return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
		}
		public PhysicalDeviceLimits Limits;
		public PhysicalDeviceSparseProperties SparseProperties;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct QueueFamilyProperties
	{
		public QueueFlags QueueFlags;
		public UInt32 queueCount;
		public UInt32 timestampValidBits;
		public Extent3D minImageTransferGranularity;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MemoryType
	{
		public MemoryPropertyFlags propertyFlags;
		public UInt32 heapIndex;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MemoryHeap
	{
		public DeviceSize size;
		public MemoryHeapFlags flags;
	}

	public struct PhysicalDeviceMemoryProperties
	{
		public UInt32 MemoryTypeCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst =32)]
		public MemoryType[] MemoryTypes;
		public UInt32 MemoryHeapCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public MemoryHeap[] MemoryHeaps;
	}

	public struct DeviceQueueCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 QueueFamilyIndex;
		public UInt32 QueueCount;
		public float[] QueuePriorities;
	}

	//public instance of object, there is an internal version used in the function
	public struct DeviceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public List<DeviceQueueCreateInfo> QueueCreateInfos;
		public List<string> EnabledLayerNames;
		public List<string> EnabledExtensionNames;
		public PhysicalDeviceFeatures EnabledFeatures;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ExtensionProperties
	{
		fixed byte _ExtensionName[256];
		public string ExtensionName
		{
			get
			{
				fixed (byte* p = _ExtensionName)
				{
					return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
		}
		public UInt32 SpecVersion;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct LayerProperties
	{
		fixed byte _LayerName[256];
		public string LayerName
		{
			get
			{
				fixed (byte* p = _LayerName)
				{
					return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
		}
		public UInt32 SpecVersion;
		public UInt32 ImplementationVersion;
		fixed byte _Description[256];
		public string Description
		{
			get
			{
				fixed (byte* p = _Description)
				{
					return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
		}
	}

	public struct SubmitInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public List<Semaphore> WaitSemaphores;
		public PipelineStageFlags WaitDstStageMask;
		public List<CommandBuffer> CommandBuffers;
		public List<Semaphore> SignalSemaphores;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MemoryAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public DeviceSize AllocationSize;
		public UInt32 MemoryTypeIndex;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MappedMemoryRange
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Memory;
		public DeviceSize Offset;
		public DeviceSize Size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MemoryRequirements
	{
		public DeviceSize size;
		public DeviceSize alignment;
		public UInt32 memoryTypeBits;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseImageFormatProperties
	{
		public ImageAspectFlags aspectMask;
		public Extent3D imageGranularity;
		public SparseImageFormatFlags flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseImageMemoryRequirements
	{
		public SparseImageFormatProperties formatProperties;
		public UInt32 imageMipTailFirstLod;
		public DeviceSize imageMipTailSize;
		public DeviceSize imageMipTailOffset;
		public DeviceSize imageMipTailStride;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseMemoryBind
	{
		public DeviceSize ResourceOffset;
		public DeviceSize Size;
		public DeviceMemory Memory;
		public DeviceSize MemoryOffset;
		public SparseMemoryBindFlags Flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseBufferMemoryBindInfo
	{
		public Buffer Buffer;
		public UInt32 BindCount;
		public IntPtr Binds;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseImageOpaqueMemoryBindInfo
	{
		public Image Image;
		public UInt32 BindCount;
		public IntPtr Binds;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageSubresource
	{
		public ImageAspectFlags aspectMask;
		public UInt32 mipLevel;
		public UInt32 arrayLayer;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Offset3D
	{
		public Int32 X;
		public Int32 Y;
		public Int32 Z;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseImageMemoryBind
	{
		public ImageSubresource Subresource;
		public Offset3D Offset;
		public Extent3D Extent;
		public UInt64 Memory;
		public DeviceSize MemoryOffset;
		public SparseMemoryBindFlags Flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SparseImageMemoryBindInfo
	{
		public UInt64 Image;
		public UInt32 BindCount;
		public IntPtr Binds;
	}

	public struct BindSparseInfo
	{
		public StructureType sType;
		public IntPtr pNext;
		public List<Semaphore> pWaitSemaphores;
		public List<SparseBufferMemoryBindInfo> pBufferBinds;
		public List<SparseImageOpaqueMemoryBindInfo> pImageOpaqueBinds;
		public List<SparseImageMemoryBindInfo> pImageBinds;
		public List<Semaphore> pSignalSemaphores;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FenceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public FenceCreateFlags Flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SemaphoreCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct EventCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct QueryPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public QueryType QueryType;
		public UInt32 QueryCount;
		public QueryPipelineStatisticFlags PipelineStatistics;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BufferCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public BufferCreateFlags Flags;
		public DeviceSize Size;
		public BufferUsageFlags Usage;
		public SharingMode SharingMode;
		public UInt32 QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BufferViewCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt64 Buffer;
		public Format Format;
		public DeviceSize Offset;
		public DeviceSize Range;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public ImageCreateFlags Flags;
		public ImageType ImageType;
		public Format Format;
		public Extent3D Extent;
		public UInt32 MipLevels;
		public UInt32 ArrayLayers;
		public SampleCountFlags Samples;
		public ImageTiling Tiling;
		public ImageUsageFlags Usage;
		public SharingMode SharingMode;
		public UInt32 QueueFamilyIndexCount;
		public IntPtr QueueFamilyIndices;
		public ImageLayout InitialLayout;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SubresourceLayout
	{
		public DeviceSize offset;
		public DeviceSize size;
		public DeviceSize rowPitch;
		public DeviceSize arrayPitch;
		public DeviceSize depthPitch;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ComponentMapping
	{
		public ComponentSwizzle R;
		public ComponentSwizzle G;
		public ComponentSwizzle B;
		public ComponentSwizzle A;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageSubresourceRange
	{
		public ImageAspectFlags aspectMask;
		public UInt32 baseMipLevel;
		public UInt32 levelCount;
		public UInt32 baseArrayLayer;
		public UInt32 layerCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageViewCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Image image;
		public ImageViewType ViewType;
		public Format Format;
		public ComponentMapping Components;
		public ImageSubresourceRange SubresourceRange;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ShaderModuleCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UIntPtr CodeSize;
		public IntPtr Code;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineCacheCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UIntPtr InitialDataSize;
		public IntPtr InitialData;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SpecializationMapEntry
	{
		public UInt32 constantId;
		public UInt32 offset;
		public UInt32 size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SpecializationInfo
	{
		public UInt32 MapEntryCount;
		public SpecializationMapEntry[] MapEntries;
		public UIntPtr DataSize;
		public IntPtr Data;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineShaderStageCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public ShaderStageFlags Stage;
		public UInt64 Module;
		public IntPtr Name;
		public IntPtr SpecializationInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VertexInputBindingDescription
	{
		public UInt32 binding;
		public UInt32 stride;
		public VertexInputRate inputRate;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct VertexInputAttributeDescription
	{
		public UInt32 location;
		public UInt32 binding;
		public Format format;
		public UInt32 offset;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineVertexInputStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 VertexBindingDescriptionCount;
		public VertexInputBindingDescription[] VertexBindingDescriptions;
		public UInt32 VertexAttributeDescriptionCount;
		public VertexInputAttributeDescription[] VertexAttributeDescriptions;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineInputAssemblyStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public PrimitiveTopology Topology;
		public Bool32 PrimitiveRestartEnable;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineTessellationStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 PatchControlPoints;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Viewport
	{
		public float X;
		public float Y;
		public float Width;
		public float Height;
		public float MinDepth;
		public float MaxDepth;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Offset2D
	{
		public Int32 X;
		public Int32 Y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Extent2D
	{
		public UInt32 Width;
		public UInt32 Height;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Rect2D
	{
		public Offset2D Offset;
		public Extent2D Extent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineViewportStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 ViewportCount;
		public IntPtr Viewports;
		public UInt32 ScissorCount;
		public IntPtr Scissors;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineRasterizationStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Bool32 DepthClampEnable;
		public Bool32 RasterizerDiscardEnable;
		public PolygonMode PolygonMode;
		public CullModeFlags CullMode;
		public FrontFace FrontFace;
		public Bool32 DepthBiasEnable;
		public float DepthBiasConstantFactor;
		public float DepthBiasClamp;
		public float DepthBiasSlopeFactor;
		public float LineWidth;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineMultisampleStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public SampleCountFlags RasterizationSamples;
		public Bool32 SampleShadingEnable;
		public float MinSampleShading;
		public IntPtr SampleMask;
		public Bool32 AlphaToCoverageEnable;
		public Bool32 AlphaToOneEnable;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct StencilOpState
	{
		public StencilOp failOp;
		public StencilOp passOp;
		public StencilOp depthFailOp;
		public CompareOp compareOp;
		public UInt32 compareMask;
		public UInt32 writeMask;
		public UInt32 reference;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineDepthStencilStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Bool32 DepthTestEnable;
		public Bool32 DepthWriteEnable;
		public CompareOp DepthCompareOp;
		public Bool32 DepthBoundsTestEnable;
		public Bool32 StencilTestEnable;
		public StencilOpState Front;
		public StencilOpState Back;
		public float MinDepthBounds;
		public float MaxDepthBounds;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineColorBlendAttachmentState
	{
		public Bool32 blendEnable;
		public BlendFactor srcColorBlendFactor;
		public BlendFactor dstColorBlendFactor;
		public BlendOp colorBlendOp;
		public BlendFactor srcAlphaBlendFactor;
		public BlendFactor dstAlphaBlendFactor;
		public BlendOp alphaBlendOp;
		public ColorComponentFlags colorWriteMask;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PipelineColorBlendStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Bool32 LogicOpEnable;
		public LogicOp LogicOp;
		public UInt32 AttachmentCount;
		public IntPtr Attachments;
		public fixed float BlendConstants[4];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineDynamicStateCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 DynamicStateCount;
		public IntPtr DynamicStates;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct GraphicsPipelineCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public PipelineCreateFlags Flags;
		public UInt32 StageCount;
		public IntPtr Stages;
		public IntPtr VertexInputState;
		public IntPtr InputAssemblyState;
		public IntPtr TessellationState;
		public IntPtr ViewportState;
		public IntPtr RasterizationState;
		public IntPtr MultisampleState;
		public IntPtr DepthStencilState;
		public IntPtr ColorBlendState;
		public IntPtr DynamicState;
		public UInt64 Layout;
		public UInt64 RenderPass;
		public UInt32 Subpass;
		public UInt64 BasePipelineHandle;
		public Int32 BasePipelineIndex;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct ComputePipelineCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public PipelineCreateFlags Flags;
		public PipelineShaderStageCreateInfo Stage;
		public UInt64 Layout;
		public UInt64 BasePipelineHandle;
		public Int32 BasePipelineIndex;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PushConstantRange
	{
		public ShaderStageFlags stageFlags;
		public UInt32 offset;
		public UInt32 size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineLayoutCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 SetLayoutCount;
		public IntPtr SetLayouts;
		public UInt32 PushConstantRangeCount;
		public IntPtr PushConstantRanges;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SamplerCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Filter MagFilter;
		public Filter MinFilter;
		public SamplerMipmapMode MipmapMode;
		public SamplerAddressMode AddressModeU;
		public SamplerAddressMode AddressModeV;
		public SamplerAddressMode AddressModeW;
		public float MipLodBias;
		public Bool32 AnisotropyEnable;
		public float MaxAnisotropy;
		public Bool32 CompareEnable;
		public CompareOp CompareOp;
		public float MinLod;
		public float MaxLod;
		public BorderColor BorderColor;
		public Bool32 UnnormalizedCoordinates;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorSetLayoutBinding
	{
		public UInt32 Binding;
		public DescriptorType DescriptorType;
		public UInt32 DescriptorCount;
		public ShaderStageFlags StageFlags;
		public IntPtr ImmutableSamplers;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorSetLayoutCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public DescriptorSetLayoutCreateFlags Flags;
		public UInt32 BindingCount;
		public IntPtr Bindings;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorPoolSize
	{
		DescriptorType type;
		UInt32 descriptorCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public DescriptorPoolCreateFlags Flags;
		public UInt32 MaxSets;
		public UInt32 PoolSizeCount;
		public DescriptorPoolSize[] PoolSizes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorSetAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 DescriptorPool;
		public UInt32 DescriptorSetCount;
		public IntPtr SetLayouts;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorBufferInfo
	{
		public UInt64 Buffer;
		public DeviceSize Offset;
		public DeviceSize Range;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DescriptorImageInfo
	{
		public UInt64 Sampler;
		public UInt64 ImageView;
		public ImageLayout ImageLayout;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WriteDescriptorSet
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 DstSet;
		public UInt32 DstBinding;
		public UInt32 DstArrayElement;
		public UInt32 DescriptorCount;
		public DescriptorType DescriptorType;
		public IntPtr ImageInfo;
		public IntPtr BufferInfo;
		public IntPtr TexelBufferView;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CopyDescriptorSet
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 SrcSet;
		public UInt32 SrcBinding;
		public UInt32 SrcArrayElement;
		public UInt64 DstSet;
		public UInt32 DstBinding;
		public UInt32 DstArrayElement;
		public UInt32 DescriptorCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FramebufferCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt64 RenderPass;
		public UInt32 AttachmentCount;
		public IntPtr Attachments;
		public UInt32 Width;
		public UInt32 Height;
		public UInt32 Layers;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct AttachmentDescription
	{
		public AttachmentDescriptionFlags flags;
		public Format format;
		public SampleCountFlags samples;
		public AttachmentLoadOp loadOp;
		public AttachmentStoreOp storeOp;
		public AttachmentLoadOp stencilLoadOp;
		public AttachmentStoreOp stencilStoreOp;
		public ImageLayout initialLayout;
		public ImageLayout finalLayout;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct AttachmentReference
	{
		public UInt32 attachment;
		public ImageLayout layout;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SubpassDescription
	{
		public SubpassDescriptionFlags Flags;
		public PipelineBindPoint PipelineBindPoint;
		public UInt32 InputAttachmentCount;
		public IntPtr InputAttachments;
		public UInt32 ColorAttachmentCount;
		public IntPtr ColorAttachments;
		public IntPtr ResolveAttachments;
		public IntPtr DepthStencilAttachment;
		public UInt32 PreserveAttachmentCount;
		public IntPtr PreserveAttachments;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SubpassDependency
	{
		public UInt32 srcSubpass;
		public UInt32 dstSubpass;
		public PipelineStageFlags srcStageMask;
		public PipelineStageFlags dstStageMask;
		public AccessFlags srcAccessMask;
		public AccessFlags dstAccessMask;
		public DependencyFlags dependencyFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RenderPassCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 AttachmentCount;
		public IntPtr Attachments;
		public UInt32 SubpassCount;
		public IntPtr Subpasses;
		public UInt32 DependencyCount;
		public IntPtr Dependencies;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CommandPoolCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public CommandPoolCreateFlags Flags;
		public UInt32 QueueFamilyIndex;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CommandBufferAllocateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public CommandPool CommandPool;
		public CommandBufferLevel Level;
		public UInt32 CommandBufferCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CommandBufferInheritanceInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public RenderPass RenderPass;
		public UInt32 Subpass;
		public Framebuffer Framebuffer;
		public Bool32 OcclusionQueryEnable;
		public QueryControlFlags QueryFlags;
		public QueryPipelineStatisticFlags PipelineStatistics;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CommandBufferBeginInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public CommandBufferUsageFlags Flags;
		public IntPtr InheritanceInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BufferCopy
	{
		public DeviceSize srcOffset;
		public DeviceSize dstOffset;
		public DeviceSize size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageSubresourceLayers
	{
		public ImageAspectFlags aspectMask;
		public UInt32 mipLevel;
		public UInt32 baseArrayLayer;
		public UInt32 layerCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageCopy
	{
		public ImageSubresourceLayers srcSubresource;
		public Offset3D srcOffset;
		public ImageSubresourceLayers dstSubresource;
		public Offset3D dstOffset;
		public Extent3D extent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageBlit
	{
		public ImageSubresourceLayers SrcSubresource;
		public Offset3D SrcOffsets0;
		public Offset3D SrcOffsets1;
		public ImageSubresourceLayers DstSubresource;
		public Offset3D DstOffsets0;
		public Offset3D DstOffsets1;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BufferImageCopy
	{
		public DeviceSize bufferOffset;
		public UInt32 bufferRowLength;
		public UInt32 bufferImageHeight;
		public ImageSubresourceLayers imageSubresource;
		public Offset3D imageOffset;
		public Extent3D imageExtent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ClearColorValue
	{
		public float r;
		public float g;
		public float b;
		public float a;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ClearDepthStencilValue
	{
		public float depth;
		public UInt32 stencil;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct ClearValue
	{
		[FieldOffset(0)]
		public ClearColorValue Color;
		[FieldOffset(0)]
		public ClearDepthStencilValue DepthStencil;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ClearAttachment
	{
		public ImageAspectFlags AspectMask;
		public UInt32 ColorAttachment;
		public ClearValue ClearValue;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ClearRect
	{
		public Rect2D Rect;
		public UInt32 BaseArrayLayer;
		public UInt32 LayerCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageResolve
	{
		public ImageSubresourceLayers srcSubresource;
		public Offset3D srcOffset;
		public ImageSubresourceLayers dstSubresource;
		public Offset3D dstOffset;
		public Extent3D extent;	
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BufferMemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public UInt32 SrcQueueFamilyIndex;
		public UInt32 DstQueueFamilyIndex;
		public UInt64 Buffer;
		public DeviceSize Offset;
		public DeviceSize Size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ImageMemoryBarrier
	{
		public StructureType SType;
		public IntPtr Next;
		public AccessFlags SrcAccessMask;
		public AccessFlags DstAccessMask;
		public ImageLayout OldLayout;
		public ImageLayout NewLayout;
		public UInt32 SrcQueueFamilyIndex;
		public UInt32 DstQueueFamilyIndex;
		public Image Image;
		public ImageSubresourceRange SubresourceRange;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RenderPassBeginInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 RenderPass;
		public UInt64 Framebuffer;
		public Rect2D RenderArea;
		public UInt32 ClearValueCount;
		public IntPtr ClearValues;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DispatchIndirectCommand
	{
		public UInt32 x;
		public UInt32 y;
		public UInt32 z;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DrawIndexedIndirectCommand
	{
		public UInt32 indexCount;
		public UInt32 instanceCount;
		public UInt32 firstIndex;
		public Int32 vertexOffset;
		public UInt32 firstInstance;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DrawIndirectCommand
	{
		public UInt32 vertexCount;
		public UInt32 instanceCount;
		public UInt32 firstVertex;
		public UInt32 firstInstance;
	}
}