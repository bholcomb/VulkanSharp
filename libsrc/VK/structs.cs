using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Vulkan
{
   public static partial class VK
   {
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ApplicationInfo
      {
         public StructureType type;
         public IntPtr next;
         public string applicationName;
         public UInt32 applicationVersion;
         public string engineName;
         public UInt32 engineVersion;
         public UInt32 apiVersion;
      }

      //public instance of object, there is an internal version used in the function
      public struct InstanceCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public ApplicationInfo applicationInfo;
         public List<String> enabledLayerNames;
         public List<String> enabledExtensionNames;
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
         public UInt32 width;
         public UInt32 height;
         public UInt32 depth;
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
         public UInt32 maxImageDimension1D;
         public UInt32 maxImageDimension2D;
         public UInt32 maxImageDimension3D;
         public UInt32 maxImageDimensionCube;
         public UInt32 maxImageArrayLayers;
         public UInt32 maxTexelBufferElements;
         public UInt32 maxUniformBufferRange;
         public UInt32 maxStorageBufferRange;
         public UInt32 maxPushConstantsSize;
         public UInt32 maxMemoryAllocationCount;
         public UInt32 maxSamplerAllocationCount;
         public DeviceSize bufferImageGranularity;
         public DeviceSize sparseAddressSpaceSize;
         public UInt32 maxBoundDescriptorSets;
         public UInt32 maxPerStageDescriptorSamplers;
         public UInt32 maxPerStageDescriptorUniformBuffers;
         public UInt32 maxPerStageDescriptorStorageBuffers;
         public UInt32 maxPerStageDescriptorSampledImages;
         public UInt32 maxPerStageDescriptorStorageImages;
         public UInt32 maxPerStageDescriptorInputAttachments;
         public UInt32 maxPerStageResources;
         public UInt32 maxDescriptorSetSamplers;
         public UInt32 maxDescriptorSetUniformBuffers;
         public UInt32 maxDescriptorSetUniformBuffersDynamic;
         public UInt32 maxDescriptorSetStorageBuffers;
         public UInt32 maxDescriptorSetStorageBuffersDynamic;
         public UInt32 maxDescriptorSetSampledImages;
         public UInt32 maxDescriptorSetStorageImages;
         public UInt32 maxDescriptorSetInputAttachments;
         public UInt32 maxVertexInputAttributes;
         public UInt32 maxVertexInputBindings;
         public UInt32 maxVertexInputAttributeOffset;
         public UInt32 maxVertexInputBindingStride;
         public UInt32 maxVertexOutputComponents;
         public UInt32 maxTessellationGenerationLevel;
         public UInt32 maxTessellationPatchSize;
         public UInt32 maxTessellationControlPerVertexInputComponents;
         public UInt32 maxTessellationControlPerVertexOutputComponents;
         public UInt32 maxTessellationControlPerPatchOutputComponents;
         public UInt32 maxTessellationControlTotalOutputComponents;
         public UInt32 maxTessellationEvaluationInputComponents;
         public UInt32 maxTessellationEvaluationOutputComponents;
         public UInt32 maxGeometryShaderInvocations;
         public UInt32 maxGeometryInputComponents;
         public UInt32 maxGeometryOutputComponents;
         public UInt32 maxGeometryOutputVertices;
         public UInt32 maxGeometryTotalOutputComponents;
         public UInt32 maxFragmentInputComponents;
         public UInt32 maxFragmentOutputAttachments;
         public UInt32 maxFragmentDualSrcAttachments;
         public UInt32 maxFragmentCombinedOutputResources;
         public UInt32 maxComputeSharedMemorySize;
         public fixed UInt32 maxComputeWorkGroupCount[3];
         public UInt32 maxComputeWorkGroupInvocations;
         public fixed UInt32 maxComputeWorkGroupSize[3];
         public UInt32 subPixelPrecisionBits;
         public UInt32 subTexelPrecisionBits;
         public UInt32 mipmapPrecisionBits;
         public UInt32 maxDrawIndexedIndexValue;
         public UInt32 maxDrawIndirectCount;
         public float maxSamplerLodBias;
         public float maxSamplerAnisotropy;
         public UInt32 maxViewports;
         public fixed UInt32 maxViewportDimensions[2];
         public fixed float viewportBoundsRange[2];
         public UInt32 viewportSubPixelBits;
         public UIntPtr minMemoryMapAlignment;
         public DeviceSize minTexelBufferOffsetAlignment;
         public DeviceSize minUniformBufferOffsetAlignment;
         public DeviceSize minStorageBufferOffsetAlignment;
         public Int32 minTexelOffset;
         public UInt32 maxTexelOffset;
         public Int32 minTexelGatherOffset;
         public UInt32 maxTexelGatherOffset;
         public float minInterpolationOffset;
         public float maxInterpolationOffset;
         public UInt32 subPixelInterpolationOffsetBits;
         public UInt32 maxFramebufferWidth;
         public UInt32 maxFramebufferHeight;
         public UInt32 maxFramebufferLayers;
         public SampleCountFlags framebufferColorSampleCounts;
         public SampleCountFlags framebufferDepthSampleCounts;
         public SampleCountFlags framebufferStencilSampleCounts;
         public SampleCountFlags framebufferNoAttachmentsSampleCounts;
         public UInt32 maxColorAttachments;
         public SampleCountFlags sampledImageColorSampleCounts;
         public SampleCountFlags sampledImageIntegerSampleCounts;
         public SampleCountFlags sampledImageDepthSampleCounts;
         public SampleCountFlags sampledImageStencilSampleCounts;
         public SampleCountFlags storageImageSampleCounts;
         public UInt32 maxSampleMaskWords;
         public Bool32 timestampComputeAndGraphics;
         public float timestampPeriod;
         public UInt32 maxClipDistances;
         public UInt32 maxCullDistances;
         public UInt32 maxCombinedClipAndCullDistances;
         public UInt32 discreteQueuePriorities;
         public fixed float pointSizeRange[2];
         public fixed float lineWidthRange[2];
         public float pointSizeGranularity;
         public float lineWidthGranularity;
         public Bool32 strictLines;
         public Bool32 standardSampleLocations;
         public DeviceSize optimalBufferCopyOffsetAlignment;
         public DeviceSize optimalBufferCopyRowPitchAlignment;
         public DeviceSize nonCoherentAtomSize;
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
         public UInt32 apiVersion;
         public UInt32 driverVersion;
         public UInt32 VvendorId;
         public UInt32 deviceId;
         public PhysicalDeviceType deviceType;
         fixed byte _deviceName[(int)VK.MAX_PHYSICAL_DEVICE_NAME_SIZE];
         fixed byte _pipelineCacheUuid[(int)VK.UUID_SIZE];
         public PhysicalDeviceLimits limits;
         public PhysicalDeviceSparseProperties sparseProperties;

         public string deviceName
         {
            get
            {
               fixed (byte* p = _deviceName)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }

         public string pipelineCacheUuid
         {
            get
            {
               fixed (byte* p = _pipelineCacheUuid)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct QueueFamilyProperties
      {
         public QueueFlags queueFlags;
         public UInt32 queueCount;
         public UInt32 timestampValidBits;
         public Extent3D minImageTransferGranularity;
      };

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
         public UInt32 memoryTypeCount;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)VK.MAX_MEMORY_TYPES)]
         public MemoryType[] memoryTypes;
         public UInt32 memoryHeapCount;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)VK.MAX_MEMORY_HEAPS)]
         public MemoryHeap[] memoryHeaps;
      };

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceQueueCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 queueFamilyIndex;
         public UInt32 queueCount;
         public float[] queuePriorities;
      }

      //public instance of object, there is an internal version used in the function
      public struct DeviceCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public List<DeviceQueueCreateInfo> queueCreateInfos;
         public List<string> enabledLayerNames;
         public List<string> enabledExtensionNames;
         public PhysicalDeviceFeatures enabledFeatures;
      }

      [StructLayout(LayoutKind.Sequential)]
      public unsafe struct ExtensionProperties
      {
         fixed byte _extensionName[(int)VK.MAX_EXTENSION_NAME_SIZE];
         public UInt32 specVersion;

         public string extensionName
         {
            get
            {
               fixed (byte* p = _extensionName)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }
      }

      [StructLayout(LayoutKind.Sequential)]
      public unsafe struct LayerProperties
      {
         fixed byte _layerName[(int)VK.MAX_EXTENSION_NAME_SIZE];
         public UInt32 specVersion;
         public UInt32 implementationVersion;
         fixed byte _description[(int)VK.MAX_EXTENSION_NAME_SIZE];

         public string layerName
         {
            get
            {
               fixed (byte* p = _layerName)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }

         public string description
         {
            get
            {
               fixed (byte* p = _description)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }
      }

      public struct SubmitInfo
      {
         public StructureType type;
         public IntPtr next;
         public List<Semaphore> waitSemaphores;
         public PipelineStageFlags waitDstStageMask;
         public List<CommandBuffer> commandBuffers;
         public List<Semaphore> signalSemaphores;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MemoryAllocateInfo
      {
         public StructureType type;
         public IntPtr next;
         public DeviceSize allocationSize;
         public UInt32 memoryTypeIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MappedMemoryRange
      {
         public StructureType type;
         public IntPtr next;
         public UInt64 memory;
         public DeviceSize offset;
         public DeviceSize size;
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
         public DeviceSize resourceOffset;
         public DeviceSize size;
         public DeviceMemory memory;
         public DeviceSize memoryOffset;
         public SparseMemoryBindFlags flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseBufferMemoryBindInfo
      {
         public Buffer buffer;
         public UInt32 bindCount;
         public IntPtr binds;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseImageOpaqueMemoryBindInfo
      {
         public Image image;
         public UInt32 bindCount;
         public IntPtr binds;
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
         public Int32 x;
         public Int32 y;
         public Int32 z;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseImageMemoryBind
      {
         public ImageSubresource subresource;
         public Offset3D offset;
         public Extent3D extent;
         public UInt64 memory;
         public DeviceSize memoryOffset;
         public SparseMemoryBindFlags flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseImageMemoryBindInfo
      {
         public UInt64 image;
         public UInt32 bindCount;
         public IntPtr binds;
      }

      public struct BindSparseInfo
      {
         public StructureType type;
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
         public StructureType type;
         public IntPtr next;
         public FenceCreateFlags flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SemaphoreCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct EventCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct QueryPoolCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public QueryType queryType;
         public UInt32 queryCount;
         public QueryPipelineStatisticFlags pipelineStatistics;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BufferCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public BufferCreateFlags flags;
         public DeviceSize size;
         public BufferUsageFlags usage;
         public SharingMode sharingMode;
         public UInt32 queueFamilyIndexCount;
         public IntPtr queueFamilyIndices;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BufferViewCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt64 buffer;
         public Format format;
         public DeviceSize offset;
         public DeviceSize range;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ImageCreateFlags flags;
         public ImageType imageType;
         public Format format;
         public Extent3D extent;
         public UInt32 mipLevels;
         public UInt32 arrayLayers;
         public SampleCountFlags samples;
         public ImageTiling tiling;
         public ImageUsageFlags usage;
         public SharingMode sharingMode;
         public UInt32 queueFamilyIndexCount;
         public IntPtr queueFamilyIndices;
         public ImageLayout initialLayout;
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
         public ComponentSwizzle r;
         public ComponentSwizzle g;
         public ComponentSwizzle b;
         public ComponentSwizzle a;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public Image image;
         public ImageViewType viewType;
         public Format format;
         public ComponentMapping components;
         public ImageSubresourceRange subresourceRange;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ShaderModuleCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UIntPtr codeSize;
         public IntPtr code;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineCacheCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UIntPtr initialDataSize;
         public IntPtr initialData;
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
         public UInt32 mapEntryCount;
         public SpecializationMapEntry[] mapEntries;
         public UIntPtr dataSize;
         public IntPtr data;
      }

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineShaderStageCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public ShaderStageFlags stage;
         public UInt64 module;
         public IntPtr name;
         public IntPtr specializationInfo;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 vertexBindingDescriptionCount;
         public VertexInputBindingDescription[] vertexBindingDescriptions;
         public UInt32 vertexAttributeDescriptionCount;
         public VertexInputAttributeDescription[] vertexAttributeDescriptions;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineInputAssemblyStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public PrimitiveTopology topology;
         public Bool32 primitiveRestartEnable;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineTessellationStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 patchControlPoints;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct Viewport
      {
         public float x;
         public float y;
         public float width;
         public float height;
         public float minDepth;
         public float maxDepth;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct Offset2D
      {
         public Int32 x;
         public Int32 y;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct Extent2D
      {
         public UInt32 width;
         public UInt32 height;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct Rect2D
      {
         public Offset2D offset;
         public Extent2D extent;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineViewportStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 viewportCount;
         public IntPtr viewports;
         public UInt32 scissorCount;
         public IntPtr scissors;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineRasterizationStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public Bool32 depthClampEnable;
         public Bool32 rasterizerDiscardEnable;
         public PolygonMode polygonMode;
         public CullModeFlags cullMode;
         public FrontFace frontFace;
         public Bool32 depthBiasEnable;
         public float depthBiasConstantFactor;
         public float depthBiasClamp;
         public float depthBiasSlopeFactor;
         public float lineWidth;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineMultisampleStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public SampleCountFlags rasterizationSamples;
         public Bool32 sampleShadingEnable;
         public float minSampleShading;
         public IntPtr sampleMask;
         public Bool32 alphaToCoverageEnable;
         public Bool32 alphaToOneEnable;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public Bool32 depthTestEnable;
         public Bool32 depthWriteEnable;
         public CompareOp depthCompareOp;
         public Bool32 depthBoundsTestEnable;
         public Bool32 stencilTestEnable;
         public StencilOpState front;
         public StencilOpState back;
         public float minDepthBounds;
         public float maxDepthBounds;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public Bool32 logicOpEnable;
         public LogicOp logicOp;
         public UInt32 attachmentCount;
         public IntPtr attachments;
         public fixed float blendConstants[4];
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineDynamicStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 dynamicStateCount;
         public IntPtr dynamicStates;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct GraphicsPipelineCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public PipelineCreateFlags flags;
         public UInt32 stageCount;
         public IntPtr stages;
         public IntPtr vertexInputState;
         public IntPtr inputAssemblyState;
         public IntPtr tessellationState;
         public IntPtr viewportState;
         public IntPtr rasterizationState;
         public IntPtr multisampleState;
         public IntPtr depthStencilState;
         public IntPtr dolorBlendState;
         public IntPtr dynamicState;
         public PipelineLayout layout;
         public RenderPass renderPass;
         public UInt32 subpass;
         public Pipeline basePipelineHandle;
         public Int32 basePipelineIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ComputePipelineCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public PipelineCreateFlags flags;
         public PipelineShaderStageCreateInfo stage;
         public PipelineLayout layout;
         public Pipeline basePipelineHandle;
         public Int32 basePipelineIndex;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 setLayoutCount;
         public IntPtr setLayouts;
         public UInt32 pushConstantRangeCount;
         public IntPtr pushConstantRanges;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SamplerCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public Filter magFilter;
         public Filter minFilter;
         public SamplerMipmapMode mipmapMode;
         public SamplerAddressMode addressModeU;
         public SamplerAddressMode addressModeV;
         public SamplerAddressMode addressModeW;
         public float mipLodBias;
         public Bool32 anisotropyEnable;
         public float maxAnisotropy;
         public Bool32 compareEnable;
         public CompareOp compareOp;
         public float minLod;
         public float maxLod;
         public BorderColor borderColor;
         public Bool32 unnormalizedCoordinates;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorSetLayoutBinding
      {
         public UInt32 binding;
         public DescriptorType descriptorType;
         public UInt32 descriptorCount;
         public ShaderStageFlags stageFlags;
         public IntPtr immutableSamplers;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorSetLayoutCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public DescriptorSetLayoutCreateFlags flags;
         public UInt32 bindingCount;
         public IntPtr bindings;
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
         public StructureType type;
         public IntPtr next;
         public DescriptorPoolCreateFlags flags;
         public UInt32 maxSets;
         public UInt32 poolSizeCount;
         public DescriptorPoolSize[] poolSizes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorSetAllocateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt64 descriptorPool;
         public UInt32 descriptorSetCount;
         public IntPtr setLayouts;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorImageInfo
      {
         public Sampler sampler;
         public DeviceSize imageView;
         public ImageLayout imageLayout;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorBufferInfo
      {
         public Buffer buffer;
         public DeviceSize offset;
         public DeviceSize range;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct WriteDescriptorSet
      {
         public StructureType type;
         public IntPtr next;
         public DescriptorSet dstSet;
         public UInt32 dstBinding;
         public UInt32 dstArrayElement;
         public UInt32 descriptorCount;
         public DescriptorType descriptorType;
         public IntPtr imageInfo;
         public IntPtr bufferInfo;
         public IntPtr texelBufferView;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CopyDescriptorSet
      {
         public StructureType type;
         public IntPtr next;
         public DescriptorSet srcSet;
         public UInt32 srcBinding;
         public UInt32 srcArrayElement;
         public DescriptorSet dstSet;
         public UInt32 dstBinding;
         public UInt32 dstArrayElement;
         public UInt32 descriptorCount;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct FramebufferCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public RenderPass renderPass;
         public UInt32 attachmentCount;
         public IntPtr attachments;
         public UInt32 width;
         public UInt32 height;
         public UInt32 layers;
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
         public SubpassDescriptionFlags flags;
         public PipelineBindPoint pipelineBindPoint;
         public UInt32 inputAttachmentCount;
         public IntPtr inputAttachments;
         public UInt32 colorAttachmentCount;
         public IntPtr colorAttachments;
         public IntPtr resolveAttachments;
         public IntPtr depthStencilAttachment;
         public UInt32 preserveAttachmentCount;
         public IntPtr preserveAttachments;
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
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 attachmentCount;
         public IntPtr attachments;
         public UInt32 subpassCount;
         public IntPtr subpasses;
         public UInt32 dependencyCount;
         public IntPtr dependencies;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CommandPoolCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public CommandPoolCreateFlags flags;
         public UInt32 queueFamilyIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CommandBufferAllocateInfo
      {
         public StructureType type;
         public IntPtr next;
         public CommandPool dommandPool;
         public CommandBufferLevel level;
         public UInt32 commandBufferCount;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CommandBufferInheritanceInfo
      {
         public StructureType type;
         public IntPtr next;
         public RenderPass renderPass;
         public UInt32 subpass;
         public Framebuffer framebuffer;
         public Bool32 occlusionQueryEnable;
         public QueryControlFlags queryFlags;
         public QueryPipelineStatisticFlags pipelineStatistics;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CommandBufferBeginInfo
      {
         public StructureType type;
         public IntPtr next;
         public CommandBufferUsageFlags flags;
         public IntPtr inheritanceInfo;
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
         public ImageSubresourceLayers srcSubresource;
         public Offset3D srcOffsets0;
         public Offset3D srcOffsets1;
         public ImageSubresourceLayers dstSubresource;
         public Offset3D dstOffsets0;
         public Offset3D dstOffsets1;
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

      [StructLayout(LayoutKind.Explicit)]
      public unsafe struct ClearColorValue
      {
         [FieldOffset(0)]
         public fixed float float32[4];

         [FieldOffset(0)]
         public fixed Int32 int32[4];

         [FieldOffset(0)]
         public fixed UInt32 uint32[4];
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
         public ClearColorValue color;
         [FieldOffset(0)]
         public ClearDepthStencilValue depthStencil;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ClearAttachment
      {
         public ImageAspectFlags aspectMask;
         public UInt32 colorAttachment;
         public ClearValue clearValue;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ClearRect
      {
         public Rect2D rect;
         public UInt32 baseArrayLayer;
         public UInt32 layerCount;
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
         public StructureType type;
         public IntPtr next;
         public AccessFlags srcAccessMask;
         public AccessFlags dstAccessMask;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BufferMemoryBarrier
      {
         public StructureType type;
         public IntPtr next;
         public AccessFlags srcAccessMask;
         public AccessFlags dstAccessMask;
         public UInt32 srcQueueFamilyIndex;
         public UInt32 dstQueueFamilyIndex;
         public Buffer buffer;
         public DeviceSize offset;
         public DeviceSize size;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageMemoryBarrier
      {
         public StructureType type;
         public IntPtr next;
         public AccessFlags srcAccessMask;
         public AccessFlags dstAccessMask;
         public ImageLayout oldLayout;
         public ImageLayout newLayout;
         public UInt32 srcQueueFamilyIndex;
         public UInt32 dstQueueFamilyIndex;
         public Image image;
         public ImageSubresourceRange subresourceRange;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct RenderPassBeginInfo
      {
         public StructureType type;
         public IntPtr next;
         public RenderPass renderPass;
         public Framebuffer framebuffer;
         public Rect2D renderArea;
         public UInt32 clearValueCount;
         public IntPtr clearValues;
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

      [StructLayout(LayoutKind.Sequential)]
      public struct BaseOutStructure
      {
         public StructureType type;
         public IntPtr next;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BaseInStructure
      {
         public StructureType type;
         public IntPtr next;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceSubgroupProperties
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 subgroupSize;
         public ShaderStageFlags supportedStages;
         public SubgroupFeatureFlags supportedOperations;
         public Bool32 quadOperationsInAllStages;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BindBufferMemoryInfo
      {
         public StructureType type;
         public IntPtr next;
         public Buffer buffer;
         public DeviceMemory memory;
         public DeviceSize memoryOffset;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BindImageMemoryInfo
      {
         public StructureType type;
         public IntPtr next;
         public Image image;
         public DeviceMemory memory;
         public DeviceSize memoryOffset;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDevice16BitStorageFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 storageBuffer16BitAccess;
         public Bool32 uniformAndStorageBuffer16BitAccess;
         public Bool32 storagePushConstant16;
         public Bool32 storageInputOutput16;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MemoryDedicatedRequirements
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 prefersDedicatedAllocation;
         public Bool32 requiresDedicatedAllocation;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MemoryDedicatedAllocateInfo
      {
         public StructureType type;
         public IntPtr next;
         public Image image;
         public Buffer buffer;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MemoryAllocateFlagsInfo
      {
         public StructureType type;
         public IntPtr next;
         public MemoryAllocateFlags flags;
         public UInt32 deviceMask;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceGroupRenderPassBeginInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 deviceMask;
         public UInt32 deviceRenderAreaCount;
         public Rect2D pDeviceRenderAreas;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceGroupCommandBufferBeginInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 deviceMask;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceGroupSubmitInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 waitSemaphoreCount;
         public IntPtr pWaitSemaphoreDeviceIndices;
         public UInt32 commandBufferCount;
         public IntPtr pCommandBufferDeviceMasks;
         public UInt32 signalSemaphoreCount;
         public IntPtr pSignalSemaphoreDeviceIndices;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceGroupBindSparseInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 resourceDeviceIndex;
         public UInt32 memoryDeviceIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BindBufferMemoryDeviceGroupInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 deviceIndexCount;
         public IntPtr pDeviceIndices;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BindImageMemoryDeviceGroupInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 deviceIndexCount;
         public IntPtr pDeviceIndices;
         public UInt32 splitInstanceBindRegionCount;
         public Rect2D pSplitInstanceBindRegions;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceGroupProperties
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 physicalDeviceCount;
         //public fixed PhysicalDevice physicalDevices[(int)VK.MAX_DEVICE_GROUP_SIZE];
         public Bool32 subsetAllocation;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceGroupDeviceCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 physicalDeviceCount;
         public PhysicalDevice pPhysicalDevices;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BufferMemoryRequirementsInfo2
      {
         public StructureType type;
         public IntPtr next;
         public Buffer buffer;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageMemoryRequirementsInfo2
      {
         public StructureType type;
         public IntPtr next;
         public Image image;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageSparseMemoryRequirementsInfo2
      {
         public StructureType type;
         public IntPtr next;
         public Image image;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct MemoryRequirements2
      {
         public StructureType type;
         public IntPtr next;
         public MemoryRequirements memoryRequirements;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseImageMemoryRequirements2
      {
         public StructureType type;
         public IntPtr next;
         public SparseImageMemoryRequirements memoryRequirements;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceFeatures2
      {
         public StructureType type;
         public IntPtr next;
         public PhysicalDeviceFeatures features;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceProperties2
      {
         public StructureType type;
         public IntPtr next;
         public PhysicalDeviceProperties properties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct FormatProperties2
      {
         public StructureType type;
         public IntPtr next;
         public FormatProperties formatProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageFormatProperties2
      {
         public StructureType type;
         public IntPtr next;
         public ImageFormatProperties imageFormatProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceImageFormatInfo2
      {
         public StructureType type;
         public IntPtr next;
         public Format format;
         public ImageType imageType;
         public ImageTiling tiling;
         public ImageUsageFlags usage;
         public ImageCreateFlags flags;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct QueueFamilyProperties2
      {
         public StructureType type;
         public IntPtr next;
         public QueueFamilyProperties queueFamilyProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceMemoryProperties2
      {
         public StructureType type;
         public IntPtr next;
         public PhysicalDeviceMemoryProperties memoryProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SparseImageFormatProperties2
      {
         public StructureType type;
         public IntPtr next;
         public SparseImageFormatProperties properties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceSparseImageFormatInfo2
      {
         public StructureType type;
         public IntPtr next;
         public Format format;
         public ImageType imageType;
         public SampleCountFlags samples;
         public ImageUsageFlags usage;
         public ImageTiling tiling;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDevicePointClippingProperties
      {
         public StructureType type;
         public IntPtr next;
         public PointClippingBehavior pointClippingBehavior;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct InputAttachmentAspectReference
      {
         public UInt32 subpass;
         public UInt32 inputAttachmentIndex;
         public ImageAspectFlags aspectMask;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct RenderPassInputAttachmentAspectCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 aspectReferenceCount;
         public InputAttachmentAspectReference pAspectReferences;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImageViewUsageCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ImageUsageFlags usage;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PipelineTessellationDomainOriginStateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public TessellationDomainOrigin domainOrigin;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct RenderPassMultiviewCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 subpassCount;
         public IntPtr pViewMasks;
         public UInt32 dependencyCount;
         public IntPtr pViewOffsets;
         public UInt32 correlationMaskCount;
         public IntPtr pCorrelationMasks;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceMultiviewFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 multiview;
         public Bool32 multiviewGeometryShader;
         public Bool32 multiviewTessellationShader;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceMultiviewProperties
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 maxMultiviewViewCount;
         public UInt32 maxMultiviewInstanceIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceVariablePointerFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 variablePointersStorageBuffer;
         public Bool32 variablePointers;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceProtectedMemoryFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 protectedMemory;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceProtectedMemoryProperties
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 protectedNoFault;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DeviceQueueInfo2
      {
         public StructureType type;
         public IntPtr next;
         public DeviceQueueCreateFlags flags;
         public UInt32 queueFamilyIndex;
         public UInt32 queueIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ProtectedSubmitInfo
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 protectedSubmit;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SamplerYcbcrConversionCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public Format format;
         public SamplerYcbcrModelConversion ycbcrModel;
         public SamplerYcbcrRange ycbcrRange;
         public ComponentMapping components;
         public ChromaLocation xChromaOffset;
         public ChromaLocation yChromaOffset;
         public Filter chromaFilter;
         public Bool32 forceExplicitReconstruction;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SamplerYcbcrConversionInfo
      {
         public StructureType type;
         public IntPtr next;
         public SamplerYcbcrConversion conversion;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct BindImagePlaneMemoryInfo
      {
         public StructureType type;
         public IntPtr next;
         public ImageAspectFlags planeAspect;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ImagePlaneMemoryRequirementsInfo
      {
         public StructureType type;
         public IntPtr next;
         public ImageAspectFlags planeAspect;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceSamplerYcbcrConversionFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 samplerYcbcrConversion;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct SamplerYcbcrConversionImageFormatProperties
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 combinedImageSamplerDescriptorCount;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorUpdateTemplateEntry
      {
         public UInt32 dstBinding;
         public UInt32 dstArrayElement;
         public UInt32 descriptorCount;
         public DescriptorType descriptorType;
         public UInt32 offset;
         public UInt32 stride;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorUpdateTemplateCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 flags;
         public UInt32 descriptorUpdateEntryCount;
         public DescriptorUpdateTemplateEntry pDescriptorUpdateEntries;
         public DescriptorUpdateTemplateType templateType;
         public DescriptorSetLayout descriptorSetLayout;
         public PipelineBindPoint pipelineBindPoint;
         public PipelineLayout pipelineLayout;
         public UInt32 set;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalMemoryProperties
      {
         public ExternalMemoryFeatureFlags externalMemoryFeatures;
         public ExternalMemoryHandleTypeFlags exportFromImportedHandleTypes;
         public ExternalMemoryHandleTypeFlags compatibleHandleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct VkPhysicalDeviceExternalImageFormatInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryHandleTypeFlags handleType;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalImageFormatProperties
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryProperties externalMemoryProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceExternalBufferInfo
      {
         public StructureType type;
         public IntPtr next;
         public BufferCreateFlags flags;
         public BufferUsageFlags usage;
         public ExternalMemoryHandleTypeFlags handleType;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalBufferProperties
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryProperties externalMemoryProperties;
      }

      [StructLayout(LayoutKind.Sequential)]
      public unsafe struct PhysicalDeviceIDProperties
      {
         public StructureType type;
         public IntPtr next;
         public fixed byte deviceUUID[(int)VK.UUID_SIZE];
         public fixed byte driverUUID[(int)VK.UUID_SIZE];
         public fixed byte deviceLUID[(int)VK.UUID_SIZE];
         public UInt32 deviceNodeMask;
         public Bool32 deviceLUIDValid;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalMemoryImageCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryHandleTypeFlags handleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalMemoryBufferCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryHandleTypeFlags handleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExportMemoryAllocateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalMemoryHandleTypeFlags handleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceExternalFenceInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalFenceHandleTypeFlags handleType;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalFenceProperties
      {
         public StructureType type;
         public IntPtr next;
         public ExternalFenceHandleTypeFlags exportFromImportedHandleTypes;
         public ExternalFenceHandleTypeFlags compatibleHandleTypes;
         public ExternalFenceFeatureFlags externalFenceFeatures;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExportFenceCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalFenceHandleTypeFlags handleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExportSemaphoreCreateInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalSemaphoreHandleTypeFlags handleTypes;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceExternalSemaphoreInfo
      {
         public StructureType type;
         public IntPtr next;
         public ExternalSemaphoreHandleTypeFlags handleType;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct ExternalSemaphoreProperties
      {
         public StructureType type;
         public IntPtr next;
         public ExternalSemaphoreHandleTypeFlags exportFromImportedHandleTypes;
         public ExternalSemaphoreHandleTypeFlags compatibleHandleTypes;
         public ExternalSemaphoreFeatureFlags externalSemaphoreFeatures;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceMaintenance3Properties
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 maxPerSetDescriptors;
         public DeviceSize maxMemoryAllocationSize;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DescriptorSetLayoutSupport
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 supported;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct PhysicalDeviceShaderDrawParameterFeatures
      {
         public StructureType type;
         public IntPtr next;
         public Bool32 shaderDrawParameters;
      }
   }
}