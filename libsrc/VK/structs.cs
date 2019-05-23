using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Vulkan
{
   public static partial class VK
   {
      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct InstanceCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public InstanceCreateFlags flags;          
         public ApplicationInfo* pApplicationInfo;          
         public UInt32 enabledLayerCount;          
         public IntPtr ppEnabledLayerNames;  //Ordered list of layer names to be enabled 
         public UInt32 enabledExtensionCount;          
         public IntPtr ppEnabledExtensionNames;  //Extension names to be enabled 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ApplicationInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public string pApplicationName;          
         public UInt32 applicationVersion;          
         public string pEngineName;          
         public UInt32 engineVersion;          
         public UInt32 apiVersion;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AllocationCallbacks 
      {
         public IntPtr pUserData;          
         public AllocationFunction pfnAllocation;          
         public ReallocationFunction pfnReallocation;          
         public FreeFunction pfnFree;          
         public InternalAllocationNotification pfnInternalAllocation;          
         public InternalFreeNotification pfnInternalFree;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFeatures 
      {
         public Bool32 robustBufferAccess;  //out of bounds buffer accesses are well defined 
         public Bool32 fullDrawIndexUint32;  //full 32-bit range of indices for indexed draw calls 
         public Bool32 imageCubeArray;  //image views which are arrays of cube maps 
         public Bool32 independentBlend;  //blending operations are controlled per-attachment 
         public Bool32 geometryShader;  //geometry stage 
         public Bool32 tessellationShader;  //tessellation control and evaluation stage 
         public Bool32 sampleRateShading;  //per-sample shading and interpolation 
         public Bool32 dualSrcBlend;  //blend operations which take two sources 
         public Bool32 logicOp;  //logic operations 
         public Bool32 multiDrawIndirect;  //multi draw indirect 
         public Bool32 drawIndirectFirstInstance;  //indirect draws can use non-zero firstInstance 
         public Bool32 depthClamp;  //depth clamping 
         public Bool32 depthBiasClamp;  //depth bias clamping 
         public Bool32 fillModeNonSolid;  //point and wireframe fill modes 
         public Bool32 depthBounds;  //depth bounds test 
         public Bool32 wideLines;  //lines with width greater than 1 
         public Bool32 largePoints;  //points with size greater than 1 
         public Bool32 alphaToOne;  //the fragment alpha component can be forced to maximum representable alpha value 
         public Bool32 multiViewport;  //viewport arrays 
         public Bool32 samplerAnisotropy;  //anisotropic sampler filtering 
         public Bool32 textureCompressionETC2;  //ETC texture compression formats 
         public Bool32 textureCompressionASTC_LDR;  //ASTC LDR texture compression formats 
         public Bool32 textureCompressionBC;  //BC1-7 texture compressed formats 
         public Bool32 occlusionQueryPrecise;  //precise occlusion queries returning actual sample counts 
         public Bool32 pipelineStatisticsQuery;  //pipeline statistics query 
         public Bool32 vertexPipelineStoresAndAtomics;  //stores and atomic ops on storage buffers and images are supported in vertex, tessellation, and geometry stages 
         public Bool32 fragmentStoresAndAtomics;  //stores and atomic ops on storage buffers and images are supported in the fragment stage 
         public Bool32 shaderTessellationAndGeometryPointSize;  //tessellation and geometry stages can export point size 
         public Bool32 shaderImageGatherExtended;  //image gather with run-time values and independent offsets 
         public Bool32 shaderStorageImageExtendedFormats;  //the extended set of formats can be used for storage images 
         public Bool32 shaderStorageImageMultisample;  //multisample images can be used for storage images 
         public Bool32 shaderStorageImageReadWithoutFormat;  //read from storage image does not require format qualifier 
         public Bool32 shaderStorageImageWriteWithoutFormat;  //write to storage image does not require format qualifier 
         public Bool32 shaderUniformBufferArrayDynamicIndexing;  //arrays of uniform buffers can be accessed with dynamically uniform indices 
         public Bool32 shaderSampledImageArrayDynamicIndexing;  //arrays of sampled images can be accessed with dynamically uniform indices 
         public Bool32 shaderStorageBufferArrayDynamicIndexing;  //arrays of storage buffers can be accessed with dynamically uniform indices 
         public Bool32 shaderStorageImageArrayDynamicIndexing;  //arrays of storage images can be accessed with dynamically uniform indices 
         public Bool32 shaderClipDistance;  //clip distance in shaders 
         public Bool32 shaderCullDistance;  //cull distance in shaders 
         public Bool32 shaderFloat64;  //64-bit floats (doubles) in shaders 
         public Bool32 shaderInt64;  //64-bit integers in shaders 
         public Bool32 shaderInt16;  //16-bit integers in shaders 
         public Bool32 shaderResourceResidency;  //shader can use texture operations that return resource residency information (requires sparseNonResident support) 
         public Bool32 shaderResourceMinLod;  //shader can use texture operations that specify minimum resource LOD 
         public Bool32 sparseBinding;  //Sparse resources support: Resource memory can be managed at opaque page level rather than object level 
         public Bool32 sparseResidencyBuffer;  //Sparse resources support: GPU can access partially resident buffers 
         public Bool32 sparseResidencyImage2D;  //Sparse resources support: GPU can access partially resident 2D (non-MSAA non-depth/stencil) images 
         public Bool32 sparseResidencyImage3D;  //Sparse resources support: GPU can access partially resident 3D images 
         public Bool32 sparseResidency2Samples;  //Sparse resources support: GPU can access partially resident MSAA 2D images with 2 samples 
         public Bool32 sparseResidency4Samples;  //Sparse resources support: GPU can access partially resident MSAA 2D images with 4 samples 
         public Bool32 sparseResidency8Samples;  //Sparse resources support: GPU can access partially resident MSAA 2D images with 8 samples 
         public Bool32 sparseResidency16Samples;  //Sparse resources support: GPU can access partially resident MSAA 2D images with 16 samples 
         public Bool32 sparseResidencyAliased;  //Sparse resources support: GPU can correctly access data aliased into multiple locations (opt-in) 
         public Bool32 variableMultisampleRate;  //multisample rate must be the same for all pipelines in a subpass 
         public Bool32 inheritedQueries;  //Queries may be inherited from primary to secondary command buffers 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FormatProperties 
      {
         public FormatFeatureFlags linearTilingFeatures;  //Format features in case of linear tiling 
         public FormatFeatureFlags optimalTilingFeatures;  //Format features in case of optimal tiling 
         public FormatFeatureFlags bufferFeatures;  //Format features supported by buffers 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageFormatProperties 
      {
         public Extent3D maxExtent;  //max image dimensions for this resource type 
         public UInt32 maxMipLevels;  //max number of mipmap levels for this resource type 
         public UInt32 maxArrayLayers;  //max array size for this resource type 
         public SampleCountFlags sampleCounts;  //supported sample counts for this resource type 
         public DeviceSize maxResourceSize;  //max size (in bytes) of this resource type 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Extent3D 
      {
         public UInt32 width;          
         public UInt32 height;          
         public UInt32 depth;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceProperties 
      {
         public UInt32 apiVersion;          
         public UInt32 driverVersion;          
         public UInt32 vendorID;          
         public UInt32 deviceID;          
         public PhysicalDeviceType deviceType;          
         public fixed char deviceName[VK.MAX_PHYSICAL_DEVICE_NAME_SIZE];          
         public fixed byte pipelineCacheUUID[VK.UUID_SIZE];          
         public PhysicalDeviceLimits limits;          
         public PhysicalDeviceSparseProperties sparseProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceLimits 
      {
         public UInt32 maxImageDimension1D;  //max 1D image dimension 
         public UInt32 maxImageDimension2D;  //max 2D image dimension 
         public UInt32 maxImageDimension3D;  //max 3D image dimension 
         public UInt32 maxImageDimensionCube;  //max cubemap image dimension 
         public UInt32 maxImageArrayLayers;  //max layers for image arrays 
         public UInt32 maxTexelBufferElements;  //max texel buffer size (fstexels) 
         public UInt32 maxUniformBufferRange;  //max uniform buffer range (bytes) 
         public UInt32 maxStorageBufferRange;  //max storage buffer range (bytes) 
         public UInt32 maxPushConstantsSize;  //max size of the push constants pool (bytes) 
         public UInt32 maxMemoryAllocationCount;  //max number of device memory allocations supported 
         public UInt32 maxSamplerAllocationCount;  //max number of samplers that can be allocated on a device 
         public DeviceSize bufferImageGranularity;  //Granularity (in bytes) at which buffers and images can be bound to adjacent memory for simultaneous usage 
         public DeviceSize sparseAddressSpaceSize;  //Total address space available for sparse allocations (bytes) 
         public UInt32 maxBoundDescriptorSets;  //max number of descriptors sets that can be bound to a pipeline 
         public UInt32 maxPerStageDescriptorSamplers;  //max number of samplers allowed per-stage in a descriptor set 
         public UInt32 maxPerStageDescriptorUniformBuffers;  //max number of uniform buffers allowed per-stage in a descriptor set 
         public UInt32 maxPerStageDescriptorStorageBuffers;  //max number of storage buffers allowed per-stage in a descriptor set 
         public UInt32 maxPerStageDescriptorSampledImages;  //max number of sampled images allowed per-stage in a descriptor set 
         public UInt32 maxPerStageDescriptorStorageImages;  //max number of storage images allowed per-stage in a descriptor set 
         public UInt32 maxPerStageDescriptorInputAttachments;  //max number of input attachments allowed per-stage in a descriptor set 
         public UInt32 maxPerStageResources;  //max number of resources allowed by a single stage 
         public UInt32 maxDescriptorSetSamplers;  //max number of samplers allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetUniformBuffers;  //max number of uniform buffers allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetUniformBuffersDynamic;  //max number of dynamic uniform buffers allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetStorageBuffers;  //max number of storage buffers allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetStorageBuffersDynamic;  //max number of dynamic storage buffers allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetSampledImages;  //max number of sampled images allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetStorageImages;  //max number of storage images allowed in all stages in a descriptor set 
         public UInt32 maxDescriptorSetInputAttachments;  //max number of input attachments allowed in all stages in a descriptor set 
         public UInt32 maxVertexInputAttributes;  //max number of vertex input attribute slots 
         public UInt32 maxVertexInputBindings;  //max number of vertex input binding slots 
         public UInt32 maxVertexInputAttributeOffset;  //max vertex input attribute offset added to vertex buffer offset 
         public UInt32 maxVertexInputBindingStride;  //max vertex input binding stride 
         public UInt32 maxVertexOutputComponents;  //max number of output components written by vertex shader 
         public UInt32 maxTessellationGenerationLevel;  //max level supported by tessellation primitive generator 
         public UInt32 maxTessellationPatchSize;  //max patch size (vertices) 
         public UInt32 maxTessellationControlPerVertexInputComponents;  //max number of input components per-vertex in TCS 
         public UInt32 maxTessellationControlPerVertexOutputComponents;  //max number of output components per-vertex in TCS 
         public UInt32 maxTessellationControlPerPatchOutputComponents;  //max number of output components per-patch in TCS 
         public UInt32 maxTessellationControlTotalOutputComponents;  //max total number of per-vertex and per-patch output components in TCS 
         public UInt32 maxTessellationEvaluationInputComponents;  //max number of input components per vertex in TES 
         public UInt32 maxTessellationEvaluationOutputComponents;  //max number of output components per vertex in TES 
         public UInt32 maxGeometryShaderInvocations;  //max invocation count supported in geometry shader 
         public UInt32 maxGeometryInputComponents;  //max number of input components read in geometry stage 
         public UInt32 maxGeometryOutputComponents;  //max number of output components written in geometry stage 
         public UInt32 maxGeometryOutputVertices;  //max number of vertices that can be emitted in geometry stage 
         public UInt32 maxGeometryTotalOutputComponents;  //max total number of components (all vertices) written in geometry stage 
         public UInt32 maxFragmentInputComponents;  //max number of input components read in fragment stage 
         public UInt32 maxFragmentOutputAttachments;  //max number of output attachments written in fragment stage 
         public UInt32 maxFragmentDualSrcAttachments;  //max number of output attachments written when using dual source blending 
         public UInt32 maxFragmentCombinedOutputResources;  //max total number of storage buffers, storage images and output buffers 
         public UInt32 maxComputeSharedMemorySize;  //max total storage size of work group local storage (bytes) 
         public fixed UInt32 maxComputeWorkGroupCount[3];  //max num of compute work groups that may be dispatched by a single command (x,y,z) 
         public UInt32 maxComputeWorkGroupInvocations;  //max total compute invocations in a single local work group 
         public fixed UInt32 maxComputeWorkGroupSize[3];  //max local size of a compute work group (x,y,z) 
         public UInt32 subPixelPrecisionBits;  //number bits of subpixel precision in screen x and y 
         public UInt32 subTexelPrecisionBits;  //number bits of precision for selecting texel weights 
         public UInt32 mipmapPrecisionBits;  //number bits of precision for selecting mipmap weights 
         public UInt32 maxDrawIndexedIndexValue;  //max index value for indexed draw calls (for 32-bit indices) 
         public UInt32 maxDrawIndirectCount;  //max draw count for indirect draw calls 
         public float maxSamplerLodBias;  //max absolute sampler LOD bias 
         public float maxSamplerAnisotropy;  //max degree of sampler anisotropy 
         public UInt32 maxViewports;  //max number of active viewports 
         public fixed UInt32 maxViewportDimensions[2];  //max viewport dimensions (x,y) 
         public fixed float viewportBoundsRange[2];  //viewport bounds range (min,max) 
         public UInt32 viewportSubPixelBits;  //number bits of subpixel precision for viewport 
         public UInt32 minMemoryMapAlignment;  //min required alignment of pointers returned by MapMemory (bytes) 
         public DeviceSize minTexelBufferOffsetAlignment;  //min required alignment for texel buffer offsets (bytes) 
         public DeviceSize minUniformBufferOffsetAlignment;  //min required alignment for uniform buffer sizes and offsets (bytes) 
         public DeviceSize minStorageBufferOffsetAlignment;  //min required alignment for storage buffer offsets (bytes) 
         public Int32 minTexelOffset;  //min texel offset for OpTextureSampleOffset 
         public UInt32 maxTexelOffset;  //max texel offset for OpTextureSampleOffset 
         public Int32 minTexelGatherOffset;  //min texel offset for OpTextureGatherOffset 
         public UInt32 maxTexelGatherOffset;  //max texel offset for OpTextureGatherOffset 
         public float minInterpolationOffset;  //furthest negative offset for interpolateAtOffset 
         public float maxInterpolationOffset;  //furthest positive offset for interpolateAtOffset 
         public UInt32 subPixelInterpolationOffsetBits;  //number of subpixel bits for interpolateAtOffset 
         public UInt32 maxFramebufferWidth;  //max width for a framebuffer 
         public UInt32 maxFramebufferHeight;  //max height for a framebuffer 
         public UInt32 maxFramebufferLayers;  //max layer count for a layered framebuffer 
         public SampleCountFlags framebufferColorSampleCounts;  //supported color sample counts for a framebuffer 
         public SampleCountFlags framebufferDepthSampleCounts;  //supported depth sample counts for a framebuffer 
         public SampleCountFlags framebufferStencilSampleCounts;  //supported stencil sample counts for a framebuffer 
         public SampleCountFlags framebufferNoAttachmentsSampleCounts;  //supported sample counts for a framebuffer with no attachments 
         public UInt32 maxColorAttachments;  //max number of color attachments per subpass 
         public SampleCountFlags sampledImageColorSampleCounts;  //supported color sample counts for a non-integer sampled image 
         public SampleCountFlags sampledImageIntegerSampleCounts;  //supported sample counts for an integer image 
         public SampleCountFlags sampledImageDepthSampleCounts;  //supported depth sample counts for a sampled image 
         public SampleCountFlags sampledImageStencilSampleCounts;  //supported stencil sample counts for a sampled image 
         public SampleCountFlags storageImageSampleCounts;  //supported sample counts for a storage image 
         public UInt32 maxSampleMaskWords;  //max number of sample mask words 
         public Bool32 timestampComputeAndGraphics;  //timestamps on graphics and compute queues 
         public float timestampPeriod;  //number of nanoseconds it takes for timestamp query value to increment by 1 
         public UInt32 maxClipDistances;  //max number of clip distances 
         public UInt32 maxCullDistances;  //max number of cull distances 
         public UInt32 maxCombinedClipAndCullDistances;  //max combined number of user clipping 
         public UInt32 discreteQueuePriorities;  //distinct queue priorities available 
         public fixed float pointSizeRange[2];  //range (min,max) of supported point sizes 
         public fixed float lineWidthRange[2];  //range (min,max) of supported line widths 
         public float pointSizeGranularity;  //granularity of supported point sizes 
         public float lineWidthGranularity;  //granularity of supported line widths 
         public Bool32 strictLines;  //line rasterization follows preferred rules 
         public Bool32 standardSampleLocations;  //supports standard sample locations for all supported sample counts 
         public DeviceSize optimalBufferCopyOffsetAlignment;  //optimal offset of buffer copies 
         public DeviceSize optimalBufferCopyRowPitchAlignment;  //optimal pitch of buffer copies 
         public DeviceSize nonCoherentAtomSize;  //minimum size and alignment for non-coherent host-mapped device memory access 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSparseProperties 
      {
         public Bool32 residencyStandard2DBlockShape;  //Sparse resources support: GPU will access all 2D (single sample) sparse resources using the standard sparse image block shapes (based on pixel format) 
         public Bool32 residencyStandard2DMultisampleBlockShape;  //Sparse resources support: GPU will access all 2D (multisample) sparse resources using the standard sparse image block shapes (based on pixel format) 
         public Bool32 residencyStandard3DBlockShape;  //Sparse resources support: GPU will access all 3D sparse resources using the standard sparse image block shapes (based on pixel format) 
         public Bool32 residencyAlignedMipSize;  //Sparse resources support: Images with mip level dimensions that are NOT a multiple of the sparse image block dimensions will be placed in the mip tail 
         public Bool32 residencyNonResidentStrict;  //Sparse resources support: GPU can consistently access non-resident regions of a resource, all reads return as if data is 0, writes are discarded 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct QueueFamilyProperties 
      {
         public QueueFlags queueFlags;  //Queue flags 
         public UInt32 queueCount;          
         public UInt32 timestampValidBits;          
         public Extent3D minImageTransferGranularity;  //Minimum alignment requirement for image transfers 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceMemoryProperties 
      {
         public UInt32 memoryTypeCount;          
         public fixed MemoryType memoryTypes[VK.MAX_MEMORY_TYPES];          
         public UInt32 memoryHeapCount;          
         public fixed MemoryHeap memoryHeaps[VK.MAX_MEMORY_HEAPS];          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryType 
      {
         public MemoryPropertyFlags propertyFlags;  //Memory properties of this memory type 
         public UInt32 heapIndex;  //Index of the memory heap allocations of this memory type are taken from 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryHeap 
      {
         public DeviceSize size;  //Available memory in the heap 
         public MemoryHeapFlags flags;  //Flags for the heap 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceCreateFlags flags;          
         public UInt32 queueCreateInfoCount;          
         public DeviceQueueCreateInfo* pQueueCreateInfos;          
         public UInt32 enabledLayerCount;          
         public IntPtr ppEnabledLayerNames;  //Ordered list of layer names to be enabled 
         public UInt32 enabledExtensionCount;          
         public IntPtr ppEnabledExtensionNames;          
         public PhysicalDeviceFeatures* pEnabledFeatures;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceQueueCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceQueueCreateFlags flags;          
         public UInt32 queueFamilyIndex;          
         public UInt32 queueCount;          
         public float* pQueuePriorities;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ExtensionProperties 
      {
         public fixed char extensionName[VK.MAX_EXTENSION_NAME_SIZE];  //extension name 
         public UInt32 specVersion;  //version of the extension specification implemented 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct LayerProperties 
      {
         public fixed char layerName[VK.MAX_EXTENSION_NAME_SIZE];  //layer name 
         public UInt32 specVersion;  //version of the layer specification implemented 
         public UInt32 implementationVersion;  //build or release version of the layer's library 
         public fixed char description[VK.MAX_DESCRIPTION_SIZE];  //Free-form description of the layer 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SubmitInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 waitSemaphoreCount;          
         public Semaphore* pWaitSemaphores;          
         public PipelineStageFlags* pWaitDstStageMask;          
         public UInt32 commandBufferCount;          
         public CommandBuffer* pCommandBuffers;          
         public UInt32 signalSemaphoreCount;          
         public Semaphore* pSignalSemaphores;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryAllocateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceSize allocationSize;  //Size of memory allocation 
         public UInt32 memoryTypeIndex;  //Index of the of the memory type to allocate from 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MappedMemoryRange 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceMemory memory;  //Mapped memory object 
         public DeviceSize offset;  //Offset within the memory object where the range starts 
         public DeviceSize size;  //Size of the range within the memory object 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryRequirements 
      {
         public DeviceSize size;  //Specified in bytes 
         public DeviceSize alignment;  //Specified in bytes 
         public UInt32 memoryTypeBits;  //Bitmask of the allowed memory type indices into memoryTypes[] for this object 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseImageMemoryRequirements 
      {
         public SparseImageFormatProperties formatProperties;          
         public UInt32 imageMipTailFirstLod;          
         public DeviceSize imageMipTailSize;  //Specified in bytes, must be a multiple of sparse block size in bytes / alignment 
         public DeviceSize imageMipTailOffset;  //Specified in bytes, must be a multiple of sparse block size in bytes / alignment 
         public DeviceSize imageMipTailStride;  //Specified in bytes, must be a multiple of sparse block size in bytes / alignment 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseImageFormatProperties 
      {
         public ImageAspectFlags aspectMask;          
         public Extent3D imageGranularity;          
         public SparseImageFormatFlags flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BindSparseInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 waitSemaphoreCount;          
         public Semaphore* pWaitSemaphores;          
         public UInt32 bufferBindCount;          
         public SparseBufferMemoryBindInfo* pBufferBinds;          
         public UInt32 imageOpaqueBindCount;          
         public SparseImageOpaqueMemoryBindInfo* pImageOpaqueBinds;          
         public UInt32 imageBindCount;          
         public SparseImageMemoryBindInfo* pImageBinds;          
         public UInt32 signalSemaphoreCount;          
         public Semaphore* pSignalSemaphores;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SparseBufferMemoryBindInfo 
      {
         public Buffer buffer;          
         public UInt32 bindCount;          
         public SparseMemoryBind* pBinds;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseMemoryBind 
      {
         public DeviceSize resourceOffset;  //Specified in bytes 
         public DeviceSize size;  //Specified in bytes 
         public DeviceMemory memory;          
         public DeviceSize memoryOffset;  //Specified in bytes 
         public SparseMemoryBindFlags flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SparseImageOpaqueMemoryBindInfo 
      {
         public Image image;          
         public UInt32 bindCount;          
         public SparseMemoryBind* pBinds;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SparseImageMemoryBindInfo 
      {
         public Image image;          
         public UInt32 bindCount;          
         public SparseImageMemoryBind* pBinds;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseImageMemoryBind 
      {
         public ImageSubresource subresource;          
         public Offset3D offset;          
         public Extent3D extent;          
         public DeviceMemory memory;          
         public DeviceSize memoryOffset;  //Specified in bytes 
         public SparseMemoryBindFlags flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSubresource 
      {
         public ImageAspectFlags aspectMask;          
         public UInt32 mipLevel;          
         public UInt32 arrayLayer;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Offset3D 
      {
         public Int32 x;          
         public Int32 y;          
         public Int32 z;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FenceCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public FenceCreateFlags flags;  //Fence creation flags 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SemaphoreCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SemaphoreCreateFlags flags;  //Semaphore creation flags 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct EventCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public EventCreateFlags flags;  //Event creation flags 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct QueryPoolCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public QueryPoolCreateFlags flags;          
         public QueryType queryType;          
         public UInt32 queryCount;          
         public QueryPipelineStatisticFlags pipelineStatistics;  //Optional 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BufferCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public BufferCreateFlags flags;  //Buffer creation flags 
         public DeviceSize size;  //Specified in bytes 
         public BufferUsageFlags usage;  //Buffer usage flags 
         public SharingMode sharingMode;          
         public UInt32 queueFamilyIndexCount;          
         public UInt32* pQueueFamilyIndices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferViewCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public BufferViewCreateFlags flags;          
         public Buffer buffer;          
         public Format format;  //Optionally specifies format of elements 
         public DeviceSize offset;  //Specified in bytes 
         public DeviceSize range;  //View size specified in bytes 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ImageCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageCreateFlags flags;  //Image creation flags 
         public ImageType imageType;          
         public Format format;          
         public Extent3D extent;          
         public UInt32 mipLevels;          
         public UInt32 arrayLayers;          
         public SampleCountFlags samples;          
         public ImageTiling tiling;          
         public ImageUsageFlags usage;  //Image usage flags 
         public SharingMode sharingMode;  //Cross-queue-family sharing mode 
         public UInt32 queueFamilyIndexCount;  //Number of queue families to share across 
         public UInt32* pQueueFamilyIndices;  //Array of queue family indices to share across 
         public ImageLayout initialLayout;  //Initial image layout for all subresources 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubresourceLayout 
      {
         public DeviceSize offset;  //Specified in bytes 
         public DeviceSize size;  //Specified in bytes 
         public DeviceSize rowPitch;  //Specified in bytes 
         public DeviceSize arrayPitch;  //Specified in bytes 
         public DeviceSize depthPitch;  //Specified in bytes 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageViewCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageViewCreateFlags flags;          
         public Image image;          
         public ImageViewType viewType;          
         public Format format;          
         public ComponentMapping components;          
         public ImageSubresourceRange subresourceRange;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ComponentMapping 
      {
         public ComponentSwizzle r;          
         public ComponentSwizzle g;          
         public ComponentSwizzle b;          
         public ComponentSwizzle a;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSubresourceRange 
      {
         public ImageAspectFlags aspectMask;          
         public UInt32 baseMipLevel;          
         public UInt32 levelCount;          
         public UInt32 baseArrayLayer;          
         public UInt32 layerCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ShaderModuleCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ShaderModuleCreateFlags flags;          
         public UInt32 codeSize;  //Specified in bytes 
         public UInt32* pCode;  //Binary code of size codeSize 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineCacheCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineCacheCreateFlags flags;          
         public UInt32 initialDataSize;  //Size of initial data to populate cache, in bytes 
         public IntPtr pInitialData;  //Initial data to populate cache 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct GraphicsPipelineCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineCreateFlags flags;  //Pipeline creation flags 
         public UInt32 stageCount;          
         public PipelineShaderStageCreateInfo* pStages;  //One entry for each active shader stage 
         public PipelineVertexInputStateCreateInfo* pVertexInputState;          
         public PipelineInputAssemblyStateCreateInfo* pInputAssemblyState;          
         public PipelineTessellationStateCreateInfo* pTessellationState;          
         public PipelineViewportStateCreateInfo* pViewportState;          
         public PipelineRasterizationStateCreateInfo* pRasterizationState;          
         public PipelineMultisampleStateCreateInfo* pMultisampleState;          
         public PipelineDepthStencilStateCreateInfo* pDepthStencilState;          
         public PipelineColorBlendStateCreateInfo* pColorBlendState;          
         public PipelineDynamicStateCreateInfo* pDynamicState;          
         public PipelineLayout layout;  //Interface layout of the pipeline 
         public RenderPass renderPass;          
         public UInt32 subpass;          
         public Pipeline basePipelineHandle;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of 
         public Int32 basePipelineIndex;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineShaderStageCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineShaderStageCreateFlags flags;          
         public ShaderStageFlags stage;  //Shader stage 
         public ShaderModule module;  //Module containing entry point 
         public string pName;  //Null-terminated entry point name 
         public SpecializationInfo* pSpecializationInfo;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SpecializationInfo 
      {
         public UInt32 mapEntryCount;  //Number of entries in the map 
         public SpecializationMapEntry* pMapEntries;  //Array of map entries 
         public UInt32 dataSize;  //Size in bytes of pData 
         public IntPtr pData;  //Pointer to SpecConstant data 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SpecializationMapEntry 
      {
         public UInt32 constantID;  //The SpecConstant ID specified in the BIL 
         public UInt32 offset;  //Offset of the value in the data block 
         public UInt32 size;  //Size in bytes of the SpecConstant 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineVertexInputStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineVertexInputStateCreateFlags flags;          
         public UInt32 vertexBindingDescriptionCount;  //number of bindings 
         public VertexInputBindingDescription* pVertexBindingDescriptions;          
         public UInt32 vertexAttributeDescriptionCount;  //number of attributes 
         public VertexInputAttributeDescription* pVertexAttributeDescriptions;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct VertexInputBindingDescription 
      {
         public UInt32 binding;  //Vertex buffer binding id 
         public UInt32 stride;  //Distance between vertices in bytes (0 = no advancement) 
         public VertexInputRate inputRate;  //The rate at which the vertex data is consumed 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct VertexInputAttributeDescription 
      {
         public UInt32 location;  //location of the shader vertex attrib 
         public UInt32 binding;  //Vertex buffer binding id 
         public Format format;  //format of source data 
         public UInt32 offset;  //Offset of first element in bytes from base of vertex 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineInputAssemblyStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineInputAssemblyStateCreateFlags flags;          
         public PrimitiveTopology topology;          
         public Bool32 primitiveRestartEnable;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineTessellationStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineTessellationStateCreateFlags flags;          
         public UInt32 patchControlPoints;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineViewportStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineViewportStateCreateFlags flags;          
         public UInt32 viewportCount;          
         public Viewport* pViewports;          
         public UInt32 scissorCount;          
         public Rect2D* pScissors;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Viewport 
      {
         public float x;          
         public float y;          
         public float width;          
         public float height;          
         public float minDepth;          
         public float maxDepth;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Rect2D 
      {
         public Offset2D offset;          
         public Extent2D extent;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Offset2D 
      {
         public Int32 x;          
         public Int32 y;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Extent2D 
      {
         public UInt32 width;          
         public UInt32 height;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineRasterizationStateCreateFlags flags;          
         public Bool32 depthClampEnable;          
         public Bool32 rasterizerDiscardEnable;          
         public PolygonMode polygonMode;  //optional (GL45) 
         public CullModeFlags cullMode;          
         public FrontFace frontFace;          
         public Bool32 depthBiasEnable;          
         public float depthBiasConstantFactor;          
         public float depthBiasClamp;          
         public float depthBiasSlopeFactor;          
         public float lineWidth;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineMultisampleStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineMultisampleStateCreateFlags flags;          
         public SampleCountFlags rasterizationSamples;  //Number of samples used for rasterization 
         public Bool32 sampleShadingEnable;  //optional (GL45) 
         public float minSampleShading;  //optional (GL45) 
         public SampleMask* pSampleMask;  //Array of sampleMask words 
         public Bool32 alphaToCoverageEnable;          
         public Bool32 alphaToOneEnable;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineDepthStencilStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineDepthStencilStateCreateFlags flags;          
         public Bool32 depthTestEnable;          
         public Bool32 depthWriteEnable;          
         public CompareOp depthCompareOp;          
         public Bool32 depthBoundsTestEnable;  //optional (depth_bounds_test) 
         public Bool32 stencilTestEnable;          
         public StencilOpState front;          
         public StencilOpState back;          
         public float minDepthBounds;          
         public float maxDepthBounds;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct StencilOpState 
      {
         public StencilOp failOp;          
         public StencilOp passOp;          
         public StencilOp depthFailOp;          
         public CompareOp compareOp;          
         public UInt32 compareMask;          
         public UInt32 writeMask;          
         public UInt32 reference;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineColorBlendStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineColorBlendStateCreateFlags flags;          
         public Bool32 logicOpEnable;          
         public LogicOp logicOp;          
         public UInt32 attachmentCount;  //# of pAttachments 
         public PipelineColorBlendAttachmentState* pAttachments;          
         public fixed float blendConstants[4];          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
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
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineDynamicStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineDynamicStateCreateFlags flags;          
         public UInt32 dynamicStateCount;          
         public DynamicState* pDynamicStates;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ComputePipelineCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineCreateFlags flags;  //Pipeline creation flags 
         public PipelineShaderStageCreateInfo stage;          
         public PipelineLayout layout;  //Interface layout of the pipeline 
         public Pipeline basePipelineHandle;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of 
         public Int32 basePipelineIndex;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineLayoutCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineLayoutCreateFlags flags;          
         public UInt32 setLayoutCount;  //Number of descriptor sets interfaced by the pipeline 
         public DescriptorSetLayout* pSetLayouts;  //Array of setCount number of descriptor set layout objects defining the layout of the 
         public UInt32 pushConstantRangeCount;  //Number of push-constant ranges used by the pipeline 
         public PushConstantRange* pPushConstantRanges;  //Array of pushConstantRangeCount number of ranges used by various shader stages 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PushConstantRange 
      {
         public ShaderStageFlags stageFlags;  //Which stages use the range 
         public UInt32 offset;  //Start of the range, in bytes 
         public UInt32 size;  //Size of the range, in bytes 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SamplerCreateFlags flags;          
         public Filter magFilter;  //Filter mode for magnification 
         public Filter minFilter;  //Filter mode for minifiation 
         public SamplerMipmapMode mipmapMode;  //Mipmap selection mode 
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
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorSetLayoutCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorSetLayoutCreateFlags flags;          
         public UInt32 bindingCount;  //Number of bindings in the descriptor set layout 
         public DescriptorSetLayoutBinding* pBindings;  //Array of descriptor set layout bindings 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorSetLayoutBinding 
      {
         public UInt32 binding;  //Binding number for this entry 
         public DescriptorType descriptorType;  //Type of the descriptors in this binding 
         public UInt32 descriptorCount;  //Number of descriptors in this binding 
         public ShaderStageFlags stageFlags;  //Shader stages this binding is visible to 
         public Sampler* pImmutableSamplers;  //Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements) 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorPoolCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorPoolCreateFlags flags;          
         public UInt32 maxSets;          
         public UInt32 poolSizeCount;          
         public DescriptorPoolSize* pPoolSizes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorPoolSize 
      {
         public DescriptorType type;          
         public UInt32 descriptorCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorSetAllocateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorPool descriptorPool;          
         public UInt32 descriptorSetCount;          
         public DescriptorSetLayout* pSetLayouts;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct WriteDescriptorSet 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorSet dstSet;  //Destination descriptor set 
         public UInt32 dstBinding;  //Binding within the destination descriptor set to write 
         public UInt32 dstArrayElement;  //Array element within the destination binding to write 
         public UInt32 descriptorCount;  //Number of descriptors to write (determines the size of the array pointed by pDescriptors) 
         public DescriptorType descriptorType;  //Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used) 
         public DescriptorImageInfo* pImageInfo;  //Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types. 
         public DescriptorBufferInfo* pBufferInfo;  //Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types. 
         public BufferView* pTexelBufferView;  //Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorImageInfo 
      {
         public Sampler sampler;  //Sampler to write to the descriptor in case it is a SAMPLER or COMBINED_IMAGE_SAMPLER descriptor. Ignored otherwise. 
         public ImageView imageView;  //Image view to write to the descriptor in case it is a SAMPLED_IMAGE, STORAGE_IMAGE, COMBINED_IMAGE_SAMPLER, or INPUT_ATTACHMENT descriptor. Ignored otherwise. 
         public ImageLayout imageLayout;  //Layout the image is expected to be in when accessed using this descriptor (only used if imageView is not VK_NULL_HANDLE). 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorBufferInfo 
      {
         public Buffer buffer;  //Buffer used for this descriptor slot. 
         public DeviceSize offset;  //Base offset from buffer start in bytes to update in the descriptor set. 
         public DeviceSize range;  //Size in bytes of the buffer resource for this descriptor update. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CopyDescriptorSet 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorSet srcSet;  //Source descriptor set 
         public UInt32 srcBinding;  //Binding within the source descriptor set to copy from 
         public UInt32 srcArrayElement;  //Array element within the source binding to copy from 
         public DescriptorSet dstSet;  //Destination descriptor set 
         public UInt32 dstBinding;  //Binding within the destination descriptor set to copy to 
         public UInt32 dstArrayElement;  //Array element within the destination binding to copy to 
         public UInt32 descriptorCount;  //Number of descriptors to write (determines the size of the array pointed by pDescriptors) 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct FramebufferCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public FramebufferCreateFlags flags;          
         public RenderPass renderPass;          
         public UInt32 attachmentCount;          
         public ImageView* pAttachments;          
         public UInt32 width;          
         public UInt32 height;          
         public UInt32 layers;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public RenderPassCreateFlags flags;          
         public UInt32 attachmentCount;          
         public AttachmentDescription* pAttachments;          
         public UInt32 subpassCount;          
         public SubpassDescription* pSubpasses;          
         public UInt32 dependencyCount;          
         public SubpassDependency* pDependencies;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AttachmentDescription 
      {
         public AttachmentDescriptionFlags flags;          
         public Format format;          
         public SampleCountFlags samples;          
         public AttachmentLoadOp loadOp;  //Load operation for color or depth data 
         public AttachmentStoreOp storeOp;  //Store operation for color or depth data 
         public AttachmentLoadOp stencilLoadOp;  //Load operation for stencil data 
         public AttachmentStoreOp stencilStoreOp;  //Store operation for stencil data 
         public ImageLayout initialLayout;          
         public ImageLayout finalLayout;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SubpassDescription 
      {
         public SubpassDescriptionFlags flags;          
         public PipelineBindPoint pipelineBindPoint;  //Must be VK_PIPELINE_BIND_POINT_GRAPHICS for now 
         public UInt32 inputAttachmentCount;          
         public AttachmentReference* pInputAttachments;          
         public UInt32 colorAttachmentCount;          
         public AttachmentReference* pColorAttachments;          
         public AttachmentReference* pResolveAttachments;          
         public AttachmentReference* pDepthStencilAttachment;          
         public UInt32 preserveAttachmentCount;          
         public UInt32* pPreserveAttachments;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AttachmentReference 
      {
         public UInt32 attachment;          
         public ImageLayout layout;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassDependency 
      {
         public UInt32 srcSubpass;          
         public UInt32 dstSubpass;          
         public PipelineStageFlags srcStageMask;          
         public PipelineStageFlags dstStageMask;          
         public AccessFlags srcAccessMask;  //Memory accesses from the source of the dependency to synchronize 
         public AccessFlags dstAccessMask;  //Memory accesses from the destination of the dependency to synchronize 
         public DependencyFlags dependencyFlags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CommandPoolCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public CommandPoolCreateFlags flags;  //Command pool creation flags 
         public UInt32 queueFamilyIndex;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CommandBufferAllocateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public CommandPool commandPool;          
         public CommandBufferLevel level;          
         public UInt32 commandBufferCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct CommandBufferBeginInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public CommandBufferUsageFlags flags;  //Command buffer usage flags 
         public CommandBufferInheritanceInfo* pInheritanceInfo;  //Pointer to inheritance info for secondary command buffers 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CommandBufferInheritanceInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public RenderPass renderPass;  //Render pass for secondary command buffers 
         public UInt32 subpass;          
         public Framebuffer framebuffer;  //Framebuffer for secondary command buffers 
         public Bool32 occlusionQueryEnable;  //Whether this secondary command buffer may be executed during an occlusion query 
         public QueryControlFlags queryFlags;  //Query flags used by this secondary command buffer, if executed during an occlusion query 
         public QueryPipelineStatisticFlags pipelineStatistics;  //Pipeline statistics that may be counted for this secondary command buffer 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferCopy 
      {
         public DeviceSize srcOffset;  //Specified in bytes 
         public DeviceSize dstOffset;  //Specified in bytes 
         public DeviceSize size;  //Specified in bytes 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageCopy 
      {
         public ImageSubresourceLayers srcSubresource;          
         public Offset3D srcOffset;  //Specified in pixels for both compressed and uncompressed images 
         public ImageSubresourceLayers dstSubresource;          
         public Offset3D dstOffset;  //Specified in pixels for both compressed and uncompressed images 
         public Extent3D extent;  //Specified in pixels for both compressed and uncompressed images 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSubresourceLayers 
      {
         public ImageAspectFlags aspectMask;          
         public UInt32 mipLevel;          
         public UInt32 baseArrayLayer;          
         public UInt32 layerCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ImageBlit 
      {
         public ImageSubresourceLayers srcSubresource;          
         public fixed Offset3D srcOffsets[2];  //Specified in pixels for both compressed and uncompressed images 
         public ImageSubresourceLayers dstSubresource;          
         public fixed Offset3D dstOffsets[2];  //Specified in pixels for both compressed and uncompressed images 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferImageCopy 
      {
         public DeviceSize bufferOffset;  //Specified in bytes 
         public UInt32 bufferRowLength;  //Specified in texels 
         public UInt32 bufferImageHeight;          
         public ImageSubresourceLayers imageSubresource;          
         public Offset3D imageOffset;  //Specified in pixels for both compressed and uncompressed images 
         public Extent3D imageExtent;  //Specified in pixels for both compressed and uncompressed images 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ClearDepthStencilValue 
      {
         public float depth;          
         public UInt32 stencil;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ClearAttachment 
      {
         public ImageAspectFlags aspectMask;          
         public UInt32 colorAttachment;          
         public ClearValue clearValue;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ClearRect 
      {
         public Rect2D rect;          
         public UInt32 baseArrayLayer;          
         public UInt32 layerCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageResolve 
      {
         public ImageSubresourceLayers srcSubresource;          
         public Offset3D srcOffset;          
         public ImageSubresourceLayers dstSubresource;          
         public Offset3D dstOffset;          
         public Extent3D extent;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryBarrier 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccessFlags srcAccessMask;  //Memory accesses from the source of the dependency to synchronize 
         public AccessFlags dstAccessMask;  //Memory accesses from the destination of the dependency to synchronize 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferMemoryBarrier 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccessFlags srcAccessMask;  //Memory accesses from the source of the dependency to synchronize 
         public AccessFlags dstAccessMask;  //Memory accesses from the destination of the dependency to synchronize 
         public UInt32 srcQueueFamilyIndex;  //Queue family to transition ownership from 
         public UInt32 dstQueueFamilyIndex;  //Queue family to transition ownership to 
         public Buffer buffer;  //Buffer to sync 
         public DeviceSize offset;  //Offset within the buffer to sync 
         public DeviceSize size;  //Amount of bytes to sync 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageMemoryBarrier 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccessFlags srcAccessMask;  //Memory accesses from the source of the dependency to synchronize 
         public AccessFlags dstAccessMask;  //Memory accesses from the destination of the dependency to synchronize 
         public ImageLayout oldLayout;  //Current layout of the image 
         public ImageLayout newLayout;  //New layout to transition the image to 
         public UInt32 srcQueueFamilyIndex;  //Queue family to transition ownership from 
         public UInt32 dstQueueFamilyIndex;  //Queue family to transition ownership to 
         public Image image;  //Image to sync 
         public ImageSubresourceRange subresourceRange;  //Subresource range to sync 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassBeginInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public RenderPass renderPass;          
         public Framebuffer framebuffer;          
         public Rect2D renderArea;          
         public UInt32 clearValueCount;          
         public ClearValue* pClearValues;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DispatchIndirectCommand 
      {
         public UInt32 x;          
         public UInt32 y;          
         public UInt32 z;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DrawIndexedIndirectCommand 
      {
         public UInt32 indexCount;          
         public UInt32 instanceCount;          
         public UInt32 firstIndex;          
         public Int32 vertexOffset;          
         public UInt32 firstInstance;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DrawIndirectCommand 
      {
         public UInt32 vertexCount;          
         public UInt32 instanceCount;          
         public UInt32 firstVertex;          
         public UInt32 firstInstance;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BaseOutStructure 
      {
         public StructureType sType;          
         public BaseOutStructure* pNext;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BaseInStructure 
      {
         public StructureType sType;          
         public BaseInStructure* pNext;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSubgroupProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 subgroupSize;  //The size of a subgroup for this queue. 
         public ShaderStageFlags supportedStages;  //Bitfield of what shader stages support subgroup operations 
         public SubgroupFeatureFlags supportedOperations;  //Bitfield of what subgroup operations are supported. 
         public Bool32 quadOperationsInAllStages;  //Flag to specify whether quad operations are available in all stages. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindBufferMemoryInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Buffer buffer;          
         public DeviceMemory memory;          
         public DeviceSize memoryOffset;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindImageMemoryInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Image image;          
         public DeviceMemory memory;          
         public DeviceSize memoryOffset;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevice16BitStorageFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 storageBuffer16BitAccess;  //16-bit integer/floating-point variables supported in BufferBlock 
         public Bool32 uniformAndStorageBuffer16BitAccess;  //16-bit integer/floating-point variables supported in BufferBlock and Block 
         public Bool32 storagePushConstant16;  //16-bit integer/floating-point variables supported in PushConstant 
         public Bool32 storageInputOutput16;  //16-bit integer/floating-point variables supported in shader inputs and outputs 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryDedicatedRequirements 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 prefersDedicatedAllocation;          
         public Bool32 requiresDedicatedAllocation;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryDedicatedAllocateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Image image;  //Image that this allocation will be bound to 
         public Buffer buffer;  //Buffer that this allocation will be bound to 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryAllocateFlagsInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public MemoryAllocateFlags flags;          
         public UInt32 deviceMask;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupRenderPassBeginInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 deviceMask;          
         public UInt32 deviceRenderAreaCount;          
         public Rect2D* pDeviceRenderAreas;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupCommandBufferBeginInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 deviceMask;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupSubmitInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 waitSemaphoreCount;          
         public UInt32* pWaitSemaphoreDeviceIndices;          
         public UInt32 commandBufferCount;          
         public UInt32* pCommandBufferDeviceMasks;          
         public UInt32 signalSemaphoreCount;          
         public UInt32* pSignalSemaphoreDeviceIndices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupBindSparseInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 resourceDeviceIndex;          
         public UInt32 memoryDeviceIndex;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BindBufferMemoryDeviceGroupInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 deviceIndexCount;          
         public UInt32* pDeviceIndices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BindImageMemoryDeviceGroupInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 deviceIndexCount;          
         public UInt32* pDeviceIndices;          
         public UInt32 splitInstanceBindRegionCount;          
         public Rect2D* pSplitInstanceBindRegions;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceGroupProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 physicalDeviceCount;          
         public fixed PhysicalDevice physicalDevices[VK.MAX_DEVICE_GROUP_SIZE];          
         public Bool32 subsetAllocation;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupDeviceCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 physicalDeviceCount;          
         public PhysicalDevice* pPhysicalDevices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferMemoryRequirementsInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Buffer buffer;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageMemoryRequirementsInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Image image;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSparseMemoryRequirementsInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Image image;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryRequirements2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public MemoryRequirements memoryRequirements;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseImageMemoryRequirements2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SparseImageMemoryRequirements memoryRequirements;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFeatures2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PhysicalDeviceFeatures features;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PhysicalDeviceProperties properties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FormatProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public FormatProperties formatProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageFormatProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageFormatProperties imageFormatProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceImageFormatInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Format format;          
         public ImageType type;          
         public ImageTiling tiling;          
         public ImageUsageFlags usage;          
         public ImageCreateFlags flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct QueueFamilyProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public QueueFamilyProperties queueFamilyProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMemoryProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PhysicalDeviceMemoryProperties memoryProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SparseImageFormatProperties2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SparseImageFormatProperties properties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSparseImageFormatInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Format format;          
         public ImageType type;          
         public SampleCountFlags samples;          
         public ImageUsageFlags usage;          
         public ImageTiling tiling;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevicePointClippingProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PointClippingBehavior pointClippingBehavior;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassInputAttachmentAspectCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 aspectReferenceCount;          
         public InputAttachmentAspectReference* pAspectReferences;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct InputAttachmentAspectReference 
      {
         public UInt32 subpass;          
         public UInt32 inputAttachmentIndex;          
         public ImageAspectFlags aspectMask;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageViewUsageCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageUsageFlags usage;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineTessellationDomainOriginStateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public TessellationDomainOrigin domainOrigin;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassMultiviewCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 subpassCount;          
         public UInt32* pViewMasks;          
         public UInt32 dependencyCount;          
         public Int32* pViewOffsets;          
         public UInt32 correlationMaskCount;          
         public UInt32* pCorrelationMasks;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMultiviewFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 multiview;  //Multiple views in a renderpass 
         public Bool32 multiviewGeometryShader;  //Multiple views in a renderpass w/ geometry shader 
         public Bool32 multiviewTessellationShader;  //Multiple views in a renderpass w/ tessellation shader 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMultiviewProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 maxMultiviewViewCount;  //max number of views in a subpass 
         public UInt32 maxMultiviewInstanceIndex;  //max instance index for a draw in a multiview subpass 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceVariablePointersFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 variablePointersStorageBuffer;          
         public Bool32 variablePointers;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceProtectedMemoryFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 protectedMemory;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceProtectedMemoryProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 protectedNoFault;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceQueueInfo2 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceQueueCreateFlags flags;          
         public UInt32 queueFamilyIndex;          
         public UInt32 queueIndex;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ProtectedSubmitInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 protectedSubmit;  //Submit protected command buffers 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerYcbcrConversionCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Format format;          
         public SamplerYcbcrModelConversion ycbcrModel;          
         public SamplerYcbcrRange ycbcrRange;          
         public ComponentMapping components;          
         public ChromaLocation xChromaOffset;          
         public ChromaLocation yChromaOffset;          
         public Filter chromaFilter;          
         public Bool32 forceExplicitReconstruction;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerYcbcrConversionInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SamplerYcbcrConversion conversion;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindImagePlaneMemoryInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageAspectFlags planeAspect;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImagePlaneMemoryRequirementsInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageAspectFlags planeAspect;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSamplerYcbcrConversionFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 samplerYcbcrConversion;  //Sampler color conversion supported 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerYcbcrConversionImageFormatProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 combinedImageSamplerDescriptorCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorUpdateTemplateCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DescriptorUpdateTemplateCreateFlags flags;          
         public UInt32 descriptorUpdateEntryCount;  //Number of descriptor update entries to use for the update template 
         public DescriptorUpdateTemplateEntry* pDescriptorUpdateEntries;  //Descriptor update entries for the template 
         public DescriptorUpdateTemplateType templateType;          
         public DescriptorSetLayout descriptorSetLayout;          
         public PipelineBindPoint pipelineBindPoint;          
         public PipelineLayout pipelineLayout;  //If used for push descriptors, this is the only allowed layout 
         public UInt32 set;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorUpdateTemplateEntry 
      {
         public UInt32 dstBinding;  //Binding within the destination descriptor set to write 
         public UInt32 dstArrayElement;  //Array element within the destination binding to write 
         public UInt32 descriptorCount;  //Number of descriptors to write 
         public DescriptorType descriptorType;  //Descriptor type to write 
         public UInt32 offset;  //Offset into pData where the descriptors to update are stored 
         public UInt32 stride;  //Stride between two descriptors in pData when writing more than one descriptor 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalMemoryProperties 
      {
         public ExternalMemoryFeatureFlags externalMemoryFeatures;          
         public ExternalMemoryHandleTypeFlags exportFromImportedHandleTypes;          
         public ExternalMemoryHandleTypeFlags compatibleHandleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExternalImageFormatInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryHandleTypeFlags handleType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalImageFormatProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryProperties externalMemoryProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExternalBufferInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public BufferCreateFlags flags;          
         public BufferUsageFlags usage;          
         public ExternalMemoryHandleTypeFlags handleType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalBufferProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryProperties externalMemoryProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceIDProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public fixed byte deviceUUID[VK.UUID_SIZE];          
         public fixed byte driverUUID[VK.UUID_SIZE];          
         public fixed byte deviceLUID[VK.LUID_SIZE];          
         public UInt32 deviceNodeMask;          
         public Bool32 deviceLUIDValid;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalMemoryImageCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryHandleTypeFlags handleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalMemoryBufferCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryHandleTypeFlags handleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportMemoryAllocateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryHandleTypeFlags handleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExternalFenceInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalFenceHandleTypeFlags handleType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalFenceProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalFenceHandleTypeFlags exportFromImportedHandleTypes;          
         public ExternalFenceHandleTypeFlags compatibleHandleTypes;          
         public ExternalFenceFeatureFlags externalFenceFeatures;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportFenceCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalFenceHandleTypeFlags handleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportSemaphoreCreateInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalSemaphoreHandleTypeFlags handleTypes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExternalSemaphoreInfo 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalSemaphoreHandleTypeFlags handleType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalSemaphoreProperties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalSemaphoreHandleTypeFlags exportFromImportedHandleTypes;          
         public ExternalSemaphoreHandleTypeFlags compatibleHandleTypes;          
         public ExternalSemaphoreFeatureFlags externalSemaphoreFeatures;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMaintenance3Properties 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 maxPerSetDescriptors;          
         public DeviceSize maxMemoryAllocationSize;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorSetLayoutSupport 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 supported;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShaderDrawParametersFeatures 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 shaderDrawParameters;          
      };
      
      #endregion
      
      #region unions
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ClearColorValue 
      {
         public fixed float float32[4];           
         public fixed Int32 int32[4];           
         public fixed UInt32 uint32[4];           
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ClearValue 
      {
         public ClearColorValue color;           
         public ClearDepthStencilValue depthStencil;           
      };
      
      #end region
   }
}
