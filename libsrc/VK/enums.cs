using System;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums
      public enum PipelineCacheHeaderVersion : int
      {
         One = 1,
         BeginRange = One,
         EndRange = One,
         RangeSize = (One - One + 1)
      }

      public enum Result : int
      {
         Success = 0,
         NotReady = 1,
         Timeout = 2,
         EventSet = 3,
         EventReset = 4,
         Incomplete = 5,
         ErrorOutOfHostMemory = -1,
         ErrorOutOfDeviceMemory = -2,
         ErrorInitializationFailed = -3,
         ErrorDeviceLost = -4,
         ErrorMemoryMapFailed = -5,
         ErrorLayerNotPresent = -6,
         ErrorExtensionNotPresent = -7,
         ErrorFeatureNotPresent = -8,
         ErrorIncompatibleDriver = -9,
         ErrorTooManyObjects = -10,
         ErrorFormatNotSupported = -11,
         ErrorFragmentedPool = -12,
         ErrorOutOfPoolMemory = -1000069000,
         ErrorInvalidExternalHandle = -1000072003,

         //VK_KHR_surface
         ErrorSurfaceLostKHR = -1000000000,
         ErrorNativeWindowInUseKHR = -1000000001,
         //VK_KHR_swapchain
         SuboptimalKHR = -1000001003,
         ErrorOutOfDateKHR = -1000001004,
         //VK_KHR_display_swapchain
         ErrorIncompatibleDisplayKHR = -1000003001,
         //VK_EXT_debug_report
         ErrorValidationFailedEXT = -1000011001,
         //VK_NV_glsl_shader
         ErrorInvalidShaderNV = -1000012000,         
         //VK_EXT_descriptor_indexing
         ErrorFragmentationEXT = -1000161000,
         //VK_EXT_global_priority
         ErrorNotPermittedEXT = -1000174001,
         
         BeginRange = ErrorFragmentedPool,
         EndRange = Incomplete,
         RangeSize = (Incomplete - ErrorFragmentedPool + 1),
      }

      public enum StructureType : int
      {
         ApplicationInfo = 0,
         InstanceCreateInfo = 1,
         DeviceQueueCreateInfo = 2,
         DeviceCreateInfo = 3,
         SubmitInfo = 4,
         MemoryAllocateInfo = 5,
         MappedMemoryRange = 6,
         BindSparseInfo = 7,
         FenceCreateInfo = 8,
         SemaphoreCreateInfo = 9,
         EventCreateInfo = 10,
         QueryPoolCreateInfo = 11,
         BufferCreateInfo = 12,
         BufferViewCreateInfo = 13,
         ImageCreateInfo = 14,
         ImageViewCreateInfo = 15,
         ShaderModuleCreateInfo = 16,
         PipelineCacheCreateInfo = 17,
         PipelineShaderStageCreateInfo = 18,
         PipelineVertexInputStateCreateInfo = 19,
         PipelineInputAssemblyStateCreateInfo = 20,
         PipelineTessellationStateCreateInfo = 21,
         PipelineViewportStateCreateInfo = 22,
         PipelineRasterizationStateCreateInfo = 23,
         PipelineMultisampleStateCreateInfo = 24,
         PipelineDepthStencilStateCreateInfo = 25,
         PipelineColorBlendStateCreateInfo = 26,
         PipelineDynamicStateCreateInfo = 27,
         GraphicsPipelineCreateInfo = 28,
         ComputePipelineCreateInfo = 29,
         PipelineLayoutCreateInfo = 30,
         SamplerCreateInfo = 31,
         DescriptorSetLayoutCreateInfo = 32,
         DescriptorPoolCreateInfo = 33,
         DescriptorSetAllocateInfo = 34,
         WriteDescriptorSet = 35,
         CopyDescriptorSet = 36,
         FramebufferCreateInfo = 37,
         RenderPassCreateInfo = 38,
         CommandPoolCreateInfo = 39,
         CommandBufferAllocateInfo = 40,
         CommandBufferInheritanceInfo = 41,
         CommandBufferBeginInfo = 42,
         RenderPassBeginInfo = 43,
         BufferMemoryBarrier = 44,
         ImageMemoryBarrier = 45,
         MemoryBarrier = 46,
         LoaderInstanceCreateInfo = 47,
         LoaderDeviceCreateInfo = 48,

         //VK_KHR_swapchain
         SwapchainCreateInfoKHR = 1000001000,
         PresentInfoKHR = 1000001001,
         //VK_KHR_display
         DisplayModeCreateInfoKHR = 1000002000,
         DisplaySurfaceCreateInfoKHR = 1000002001,
         //VK_KHR_display_swapchain
         DisplayPresentInfoKHR = 1000003000,
         //VK_KHR_xlib_surface
         XlibSurfaceCreateInfoKHR = 1000004000,
         //VK_KHR_xcb_surface
         XcbSurfaceCreateInfoKHR = 1000005000,
         //VK_KHR_wayland_surface
         WaylandSurfaceCreateInfoKHR = 1000006000,
         //VK_KHR_mir_surface
         MirSurfaceCreateInfoKHR = 1000007000,
         //VK_KHR_android_surface
         AndroidSurfaceCreateInfoKHR = 1000008000,
         //VK_KHR_win32_surface
         Win32SurfaceCreateInfoKHR = 1000009000,
         //VK_EXT_debug_report
         DebugReportCallbackCreateInfoEXT = 1000011000,
         //VK_AMD_rasterization_order
         PipelineRasterizationStateRasterizationOrderAMD = 1000018000,
         //VK_EXT_debug_marker
         DebugMarkerObjectNameInfoEXT = 1000022000,
         DebugMarkerObjectTagInfoEXT = 1000022001,
         DebugMarkerMarkerInfoEXT = 1000022002,
         //VK_NV_dedicated_allocation
         DedicatedAllocationImageCreateInfoNV = 1000026000,
         DedicatedAllocationBufferCreateInfoNV = 1000026001,
         DedicatedAllocationMemoryAllocateInfoNV = 1000026002,
         //VK_AMD_texture_gather_bias_lod
         TextureLodGatherFormatPropertiesAMD = 1000041000,
         //VK_NV_external_memory
         ExternalMemoryImageCreateInfoNV = 1000056000,
         ExportMemoryAllocateInfoNV = 1000056001,
         //VK_NV_external_memory_win32
         ImportMemoryWin32HandleInfoNV = 1000057000,
         ExportMemoryWin32HandleInfoNV = 1000057001,
         //VK_NV_win32_keyed_mutex
         Win32KeyedMutexAcquireReleaseInfoNV = 1000058000,
         //VK_KHR_device_group
         DeviceGroupPresentCapabilitiesKHR = 1000060007,
         ImageSwapchainCreateInfoKHR = 1000060008,
         BindImageMemorySwapchainInfoKHR = 1000060009,
         AcquireNextImageInfoKHR = 1000060010,
         DeviceGroupPresentInfoKHR = 1000060011,
         DeviceGroupSwapchainCreateInfoKHR = 1000060012,
         //VK_EXT_validation_flags
         ValidationFlagsEXT = 1000061000,
         //VK_NN_vi_surface
         ViSurfaceCreateInfoNN = 1000062000,
         //VK_KHR_external_memory_win32
         ImportMemoryWin32HandleInfoKHR = 1000073000,
         ExportMemoryWin32HandleInfoKHR = 1000073001,
         MemoryWin32HandlePropertiesKHR = 1000073002,
         MemoryGetWin32HandleInfoKHR = 1000073003,
         //VK_KHR_external_memory_fd
         ImportMemoryFdInfoKHR = 1000074000,
         MemoryFdPropertiesKHR = 1000074001,
         MemoryGetFdInfoKHR = 1000074002,
         //VK_KHR_win32_keyed_mutex
         Win32KeyedMutexAcquireReleaseInfoKHR = 1000075000,
         //VK_KHR_external_semaphore_win32
         ImportSemaphoreWin32HandleInfoKHR = 1000078000,
         ExportSemaphoreWin32HandleInfoKHR = 1000078001,
         D3d12FenceSubmitInfoKHR = 1000078002,
         SemaphoreGetWin32HandleInfoKHR = 1000078003,
         //VK_KHR_external_semaphore_fd
         ImportSemaphoreFdInfoKHR = 1000079000,
         SemaphoreGetFdInfoKHR = 1000079001,
         //VK_KHR_push_descriptor
         PhysicalDevicePushDescriptorPropertiesKHR = 1000080000,
         //VK_EXT_conditional_rendering
         CommandBufferInheritanceConditionalRenderingInfoEXT = 1000081000,
         PhysicalDeviceConditionalRenderingFeaturesEXT = 1000081001,
         ConditionalRenderingBeginInfoEXT = 1000081002,
         //VK_KHR_incremental_present
         PresentRegionsKHR = 1000084000,
         //VK_NVX_device_generated_commands
         ObjectTableCreateInfoNVX = 1000086000,
         IndirectCommandsLayoutCreateInfoNVX = 1000086001,
         CmdProcessCommandsInfoNVX = 1000086002,
         CmdReserveSpaceForCommandsInfoNVX = 1000086003,
         DeviceGeneratedCommandsLimitsNVX = 1000086004,
         DeviceGeneratedCommandsFeaturesNVX = 1000086005,
         //VK_NV_clip_space_w_scaling
         PipelineViewportWScalingStateCreateInfoNV = 1000087000,
         //VK_EXT_display_surface_counter
         SurfaceCapabilities2EXT = 1000090000,
         //VK_EXT_display_control
         DisplayPowerInfoEXT = 1000091000,
         DeviceEventInfoEXT = 1000091001,
         DisplayEventInfoEXT = 1000091002,
         SwapchainCounterCreateInfoEXT = 1000091003,
         //VK_GOOGLE_display_timing
         PresentTimesInfoGOOGLE = 1000092000,
         //VK_NVX_multiview_per_view_attributes
         PhysicalDeviceMultiviewPerViewAttributesPropertiesNVX = 1000097000,
         //VK_NV_viewport_swizzle
         PipelineViewportSwizzleStateCreateInfoNV = 1000098000,
         //VK_EXT_discard_rectangles
         PhysicalDeviceDiscardRectanglePropertiesEXT = 1000099000,
         PipelineDiscardRectangleStateCreateInfoEXT = 1000099001,
         //VK_EXT_conservative_rasterization
         PhysicalDeviceConservativeRasterizationPropertiesEXT = 1000101000,
         PipelineRasterizationConservativeStateCreateInfoEXT = 1000101001,
         //VK_EXT_hdr_metadata
         HdrMetadataEXT = 1000105000,
         //VK_KHR_create_renderpass2
         AttachmentDescription2KHR = 1000109000,
         AttachmentReference2KHR = 1000109001,
         SubpassDescription2KHR = 1000109002,
         SubpassDependency2KHR = 1000109003,
         RenderPassCreateInfo2KHR = 1000109004,
         SubpassBeginInfoKHR = 1000109005,
         SubpassEndInfoKHR = 1000109006,
         //VK_KHR_shared_presentable_image
         SharedPresentSurfaceCapabilitiesKHR = 1000111000,
         //VK_KHR_external_fence_win32
         ImportFenceWin32HandleInfoKHR = 1000114000,
         ExportFenceWin32HandleInfoKHR = 1000114001,
         FenceGetWin32HandleInfoKHR = 1000114002,
         //VK_KHR_external_fence_fd
         ImportFenceFdInfoKHR = 1000115000,
         FenceGetFdInfoKHR = 1000115001,
         //VK_KHR_get_surface_capabilities2
         PhysicalDeviceSurfaceInfo2KHR = 1000119000,
         SurfaceCapabilities2KHR = 1000119001,
         SurfaceFormat2KHR = 1000119002,
         //VK_KHR_get_display_properties2
         DisplayProperties2KHR = 1000121000,
         DisplayPlaneProperties2KHR = 1000121001,
         DisplayModeProperties2KHR = 1000121002,
         DisplayPlaneInfo2KHR = 1000121003,
         DisplayPlaneCapabilities2KHR = 1000121004,
         //VK_MVK_ios_surface
         IosSurfaceCreateInfoMVK = 1000122000,
         //VK_MVK_macos_surface
         MacosSurfaceCreateInfoMVK = 1000123000,
         //VK_EXT_debug_utils
         DebugUtilsObjectNameInfoEXT = 1000128000,
         DebugUtilsObjectTagInfoEXT = 1000128001,
         DebugUtilsLabelEXT = 1000128002,
         DebugUtilsMessengerCallbackDataEXT = 1000128003,
         DebugUtilsMessengerCreateInfoEXT = 1000128004,
         //VK_ANDROID_external_memory_android_hardware_buffer
         AndroidHardwareBufferUsageANDROID = 1000129000,
         AndroidHardwareBufferPropertiesANDROID = 1000129001,
         AndroidHardwareBufferFormatPropertiesANDROID = 1000129002,
         ImportAndroidHardwareBufferInfoANDROID = 1000129003,
         MemoryGetAndroidHardwareBufferInfoANDROID = 1000129004,
         ExternalFormatANDROID = 1000129005,
         //VK_EXT_sampler_filter_minmax
         PhysicalDeviceSamplerFilterMinmaxPropertiesEXT = 1000130000,
         SamplerReductionModeCreateInfoEXT = 1000130001,
         //VK_EXT_sample_locations
         SampleLocationsInfoEXT = 1000143000,
         RenderPassSampleLocationsBeginInfoEXT = 1000143001,
         PipelineSampleLocationsStateCreateInfoEXT = 1000143002,
         PhysicalDeviceSampleLocationsPropertiesEXT = 1000143003,
         MultisamplePropertiesEXT = 1000143004,
         //VK_KHR_image_format_list
         ImageFormatListCreateInfoKHR = 1000147000,
         //VK_EXT_blend_operation_advanced
         PhysicalDeviceBlendOperationAdvancedFeaturesEXT = 1000148000,
         PhysicalDeviceBlendOperationAdvancedPropertiesEXT = 1000148001,
         PipelineColorBlendAdvancedStateCreateInfoEXT = 1000148002,
         //VK_NV_fragment_coverage_to_color
         PipelineCoverageToColorStateCreateInfoNV = 1000149000,
         //VK_NV_framebuffer_mixed_samples
         PipelineCoverageModulationStateCreateInfoNV = 1000152000,
         //VK_EXT_validation_cache
         ValidationCacheCreateInfoEXT = 1000160000,
         ShaderModuleValidationCacheCreateInfoEXT = 1000160001,
         //VK_EXT_descriptor_indexing
         DescriptorSetLayoutBindingFlagsCreateInfoEXT = 1000161000,
         PhysicalDeviceDescriptorIndexingFeaturesEXT = 1000161001,
         PhysicalDeviceDescriptorIndexingPropertiesEXT = 1000161002,
         DescriptorSetVariableDescriptorCountAllocateInfoEXT = 1000161003,
         DescriptorSetVariableDescriptorCountLayoutSupportEXT = 1000161004,
         //VK_EXT_global_priority
         DeviceQueueGlobalPriorityCreateInfoEXT = 1000174000,
         //VK_KHR_8bit_storage
         PhysicalDevice8bitStorageFeaturesKHR = 1000177000,
         //VK_EXT_external_memory_host
         ImportMemoryHostPointerInfoEXT = 1000178000,
         MemoryHostPointerPropertiesEXT = 1000178001,
         PhysicalDeviceExternalMemoryHostPropertiesEXT = 1000178002,
         //VK_AMD_shader_core_properties
         PhysicalDeviceShaderCorePropertiesAMD = 1000185000,
         //VK_EXT_vertex_attribute_divisor
         PhysicalDeviceVertexAttributeDivisorPropertiesEXT = 1000190000,
         PipelineVertexInputDivisorStateCreateInfoEXT = 1000190001,
         //VK_NV_device_diagnostic_checkpoints
         CheckpointDataNV = 1000206000,
         QueueFamilyCheckpointPropertiesNV = 1000206001,
      }

      public enum SystemAllocationScope : int
      {
         Command = 0,
         Object = 1,
         Cache = 2,
         Device = 3,
         Instance = 4,
      }

      public enum InternalAllocationType : int
      {
         Executable = 0,
      }

      public enum Format : int
      {
         Undefined = 0,
         R4G4UnormPack8 = 1,
         R4G4B4A4UnormPack16 = 2,
         B4G4R4A4UnormPack16 = 3,
         R5G6B5UnormPack16 = 4,
         B5G6R5UnormPack16 = 5,
         R5G5B5A1UnormPack16 = 6,
         B5G5R5A1UnormPack16 = 7,
         A1R5G5B5UnormPack16 = 8,
         R8Unorm = 9,
         R8Snorm = 10,
         R8Uscaled = 11,
         R8Sscaled = 12,
         R8Uint = 13,
         R8Sint = 14,
         R8Srgb = 15,
         R8G8Unorm = 16,
         R8G8Snorm = 17,
         R8G8Uscaled = 18,
         R8G8Sscaled = 19,
         R8G8Uint = 20,
         R8G8Sint = 21,
         R8G8Srgb = 22,
         R8G8B8Unorm = 23,
         R8G8B8Snorm = 24,
         R8G8B8Uscaled = 25,
         R8G8B8Sscaled = 26,
         R8G8B8Uint = 27,
         R8G8B8Sint = 28,
         R8G8B8Srgb = 29,
         B8G8R8Unorm = 30,
         B8G8R8Snorm = 31,
         B8G8R8Uscaled = 32,
         B8G8R8Sscaled = 33,
         B8G8R8Uint = 34,
         B8G8R8Sint = 35,
         B8G8R8Srgb = 36,
         R8G8B8A8Unorm = 37,
         R8G8B8A8Snorm = 38,
         R8G8B8A8Uscaled = 39,
         R8G8B8A8Sscaled = 40,
         R8G8B8A8Uint = 41,
         R8G8B8A8Sint = 42,
         R8G8B8A8Srgb = 43,
         B8G8R8A8Unorm = 44,
         B8G8R8A8Snorm = 45,
         B8G8R8A8Uscaled = 46,
         B8G8R8A8Sscaled = 47,
         B8G8R8A8Uint = 48,
         B8G8R8A8Sint = 49,
         B8G8R8A8Srgb = 50,
         A8B8G8R8UnormPack32 = 51,
         A8B8G8R8SnormPack32 = 52,
         A8B8G8R8UscaledPack32 = 53,
         A8B8G8R8SscaledPack32 = 54,
         A8B8G8R8UintPack32 = 55,
         A8B8G8R8SintPack32 = 56,
         A8B8G8R8SrgbPack32 = 57,
         A2R10G10B10UnormPack32 = 58,
         A2R10G10B10SnormPack32 = 59,
         A2R10G10B10UscaledPack32 = 60,
         A2R10G10B10SscaledPack32 = 61,
         A2R10G10B10UintPack32 = 62,
         A2R10G10B10SintPack32 = 63,
         A2B10G10R10UnormPack32 = 64,
         A2B10G10R10SnormPack32 = 65,
         A2B10G10R10UscaledPack32 = 66,
         A2B10G10R10SscaledPack32 = 67,
         A2B10G10R10UintPack32 = 68,
         A2B10G10R10SintPack32 = 69,
         R16Unorm = 70,
         R16Snorm = 71,
         R16Uscaled = 72,
         R16Sscaled = 73,
         R16Uint = 74,
         R16Sint = 75,
         R16Sfloat = 76,
         R16G16Unorm = 77,
         R16G16Snorm = 78,
         R16G16Uscaled = 79,
         R16G16Sscaled = 80,
         R16G16Uint = 81,
         R16G16Sint = 82,
         R16G16Sfloat = 83,
         R16G16B16Unorm = 84,
         R16G16B16Snorm = 85,
         R16G16B16Uscaled = 86,
         R16G16B16Sscaled = 87,
         R16G16B16Uint = 88,
         R16G16B16Sint = 89,
         R16G16B16Sfloat = 90,
         R16G16B16A16Unorm = 91,
         R16G16B16A16Snorm = 92,
         R16G16B16A16Uscaled = 93,
         R16G16B16A16Sscaled = 94,
         R16G16B16A16Uint = 95,
         R16G16B16A16Sint = 96,
         R16G16B16A16Sfloat = 97,
         R32Uint = 98,
         R32Sint = 99,
         R32Sfloat = 100,
         R32G32Uint = 101,
         R32G32Sint = 102,
         R32G32Sfloat = 103,
         R32G32B32Uint = 104,
         R32G32B32Sint = 105,
         R32G32B32Sfloat = 106,
         R32G32B32A32Uint = 107,
         R32G32B32A32Sint = 108,
         R32G32B32A32Sfloat = 109,
         R64Uint = 110,
         R64Sint = 111,
         R64Sfloat = 112,
         R64G64Uint = 113,
         R64G64Sint = 114,
         R64G64Sfloat = 115,
         R64G64B64Uint = 116,
         R64G64B64Sint = 117,
         R64G64B64Sfloat = 118,
         R64G64B64A64Uint = 119,
         R64G64B64A64Sint = 120,
         R64G64B64A64Sfloat = 121,
         B10G11R11UfloatPack32 = 122,
         E5B9G9R9UfloatPack32 = 123,
         D16Unorm = 124,
         X8D24UnormPack32 = 125,
         D32Sfloat = 126,
         S8Uint = 127,
         D16UnormS8Uint = 128,
         D24UnormS8Uint = 129,
         D32SfloatS8Uint = 130,
         Bc1RgbUnormBlock = 131,
         Bc1RgbSrgbBlock = 132,
         Bc1RgbaUnormBlock = 133,
         Bc1RgbaSrgbBlock = 134,
         Bc2UnormBlock = 135,
         Bc2SrgbBlock = 136,
         Bc3UnormBlock = 137,
         Bc3SrgbBlock = 138,
         Bc4UnormBlock = 139,
         Bc4SnormBlock = 140,
         Bc5UnormBlock = 141,
         Bc5SnormBlock = 142,
         Bc6HUfloatBlock = 143,
         Bc6HSfloatBlock = 144,
         Bc7UnormBlock = 145,
         Bc7SrgbBlock = 146,
         Etc2R8G8B8UnormBlock = 147,
         Etc2R8G8B8SrgbBlock = 148,
         Etc2R8G8B8A1UnormBlock = 149,
         Etc2R8G8B8A1SrgbBlock = 150,
         Etc2R8G8B8A8UnormBlock = 151,
         Etc2R8G8B8A8SrgbBlock = 152,
         EacR11UnormBlock = 153,
         EacR11SnormBlock = 154,
         EacR11G11UnormBlock = 155,
         EacR11G11SnormBlock = 156,
         Astc4X4UnormBlock = 157,
         Astc4X4SrgbBlock = 158,
         Astc5X4UnormBlock = 159,
         Astc5X4SrgbBlock = 160,
         Astc5X5UnormBlock = 161,
         Astc5X5SrgbBlock = 162,
         Astc6X5UnormBlock = 163,
         Astc6X5SrgbBlock = 164,
         Astc6X6UnormBlock = 165,
         Astc6X6SrgbBlock = 166,
         Astc8X5UnormBlock = 167,
         Astc8X5SrgbBlock = 168,
         Astc8X6UnormBlock = 169,
         Astc8X6SrgbBlock = 170,
         Astc8X8UnormBlock = 171,
         Astc8X8SrgbBlock = 172,
         Astc10X5UnormBlock = 173,
         Astc10X5SrgbBlock = 174,
         Astc10X6UnormBlock = 175,
         Astc10X6SrgbBlock = 176,
         Astc10X8UnormBlock = 177,
         Astc10X8SrgbBlock = 178,
         Astc10X10UnormBlock = 179,
         Astc10X10SrgbBlock = 180,
         Astc12X10UnormBlock = 181,
         Astc12X10SrgbBlock = 182,
         Astc12X12UnormBlock = 183,
         Astc12X12SrgbBlock = 184,

         //VK_IMG_format_pvrtc
         Pvrtc12bppUnormBlockIMG = 1000054000,
         Pvrtc14bppUnormBlockIMG = 1000054001,
         Pvrtc22bppUnormBlockIMG = 1000054002,
         Pvrtc24bppUnormBlockIMG = 1000054003,
         Pvrtc12bppSrgbBlockIMG = 1000054004,
         Pvrtc14bppSrgbBlockIMG = 1000054005,
         Pvrtc22bppSrgbBlockIMG = 1000054006,
         Pvrtc24bppSrgbBlockIMG = 1000054007,
      }

      public enum ImageType : int
      {
         Image1D = 0,
         Image2D = 1,
         Image3D = 2,
      }

      public enum ImageTiling : int
      {
         Optimal = 0,
         Linear = 1,
      }

      public enum PhysicalDeviceType : int
      {
         Other = 0,
         IntegratedGpu = 1,
         DiscreteGpu = 2,
         VirtualGpu = 3,
         Cpu = 4,
      }

      public enum QueryType : int
      {
         Occlusion = 0,
         PipelineStatistics = 1,
         Timestamp = 2,
      }

      public enum SharingMode : int
      {
         Exclusive = 0,
         Concurrent = 1,
      }

      public enum ImageLayout : int
      {
         Undefined = 0,
         General = 1,
         ColorAttachmentOptimal = 2,
         DepthStencilAttachmentOptimal = 3,
         DepthStencilReadOnlyOptimal = 4,
         ShaderReadOnlyOptimal = 5,
         TransferSrcOptimal = 6,
         TransferDstOptimal = 7,
         Preinitialized = 8,

         //VK_KHR_swapchain
         PresentSrcKHR = 1000001002,
         //VK_KHR_shared_presentable_image
         SharedPresentKHR = 1000111000,
      }

      public enum ImageViewType : int
      {
         View1D = 0,
         View2D = 1,
         View3D = 2,
         Cube = 3,
         View1DArray = 4,
         View2DArray = 5,
         CubeArray = 6,
      }

      public enum ComponentSwizzle : int
      {
         Identity = 0,
         Zero = 1,
         One = 2,
         R = 3,
         G = 4,
         B = 5,
         A = 6,
      }

      public enum VertexInputRate : int
      {
         Vertex = 0,
         Instance = 1,
      }

      public enum PrimitiveTopology : int
      {
         PointList = 0,
         LineList = 1,
         LineStrip = 2,
         TriangleList = 3,
         TriangleStrip = 4,
         TriangleFan = 5,
         LineListWithAdjacency = 6,
         LineStripWithAdjacency = 7,
         TriangleListWithAdjacency = 8,
         TriangleStripWithAdjacency = 9,
         PatchList = 10,
      }

      public enum PolygonMode : int
      {
         Fill = 0,
         Line = 1,
         Point = 2,
         FillRectangleNV = 1000153000,
      }

      public enum FrontFace : int
      {
         CounterClockwise = 0,
         Clockwise = 1,
      }

      public enum CompareOp : int
      {
         Never = 0,
         Less = 1,
         Equal = 2,
         LessOrEqual = 3,
         Greater = 4,
         NotEqual = 5,
         GreaterOrEqual = 6,
         Always = 7,
      }

      public enum StencilOp : int
      {
         Keep = 0,
         Zero = 1,
         Replace = 2,
         IncrementAndClamp = 3,
         DecrementAndClamp = 4,
         Invert = 5,
         IncrementAndWrap = 6,
         DecrementAndWrap = 7,
      }

      public enum LogicOp : int
      {
         Clear = 0,
         And = 1,
         AndReverse = 2,
         Copy = 3,
         AndInverted = 4,
         NoOp = 5,
         Xor = 6,
         Or = 7,
         Nor = 8,
         Equivalent = 9,
         Invert = 10,
         OrReverse = 11,
         CopyInverted = 12,
         OrInverted = 13,
         Nand = 14,
         Set = 15,
      }

      public enum BlendFactor : int
      {
         Zero = 0,
         One = 1,
         SrcColor = 2,
         OneMinusSrcColor = 3,
         DstColor = 4,
         OneMinusDstColor = 5,
         SrcAlpha = 6,
         OneMinusSrcAlpha = 7,
         DstAlpha = 8,
         OneMinusDstAlpha = 9,
         ConstantColor = 10,
         OneMinusConstantColor = 11,
         ConstantAlpha = 12,
         OneMinusConstantAlpha = 13,
         SrcAlphaSaturate = 14,
         Src1Color = 15,
         OneMinusSrc1Color = 16,
         Src1Alpha = 17,
         OneMinusSrc1Alpha = 18,
      }

      public enum BlendOp : int
      {
         Add = 0,
         Subtract = 1,
         ReverseSubtract = 2,
         Min = 3,
         Max = 4,

         //VK_EXT_blend_operation_advanced
         ZeroEXT = 1000148000,
         SrcEXT = 1000148001,
         DstEXT = 1000148002,
         SrcOverEXT = 1000148003,
         DstOverEXT = 1000148004,
         SrcInEXT = 1000148005,
         DstInEXT = 1000148006,
         SrcOutEXT = 1000148007,
         DstOutEXT = 1000148008,
         SrcAtopEXT = 1000148009,
         DstAtopEXT = 1000148010,
         XorEXT = 1000148011,
         MultiplyEXT = 1000148012,
         ScreenEXT = 1000148013,
         OverlayEXT = 1000148014,
         DarkenEXT = 1000148015,
         LightenEXT = 1000148016,
         ColordodgeEXT = 1000148017,
         ColorburnEXT = 1000148018,
         HardlightEXT = 1000148019,
         SoftlightEXT = 1000148020,
         DifferenceEXT = 1000148021,
         ExclusionEXT = 1000148022,
         InvertEXT = 1000148023,
         InvertRgbEXT = 1000148024,
         LineardodgeEXT = 1000148025,
         LinearburnEXT = 1000148026,
         VividlightEXT = 1000148027,
         LinearlightEXT = 1000148028,
         PinlightEXT = 1000148029,
         HardmixEXT = 1000148030,
         HslHueEXT = 1000148031,
         HslSaturationEXT = 1000148032,
         HslColorEXT = 1000148033,
         HslLuminosityEXT = 1000148034,
         PlusEXT = 1000148035,
         PlusClampedEXT = 1000148036,
         PlusClampedAlphaEXT = 1000148037,
         PlusDarkerEXT = 1000148038,
         MinusEXT = 1000148039,
         MinusClampedEXT = 1000148040,
         ContrastEXT = 1000148041,
         InvertOvgEXT = 1000148042,
         RedEXT = 1000148043,
         GreenEXT = 1000148044,
         BlueEXT = 1000148045,
      }

      public enum DynamicState : int
      {
         Viewport = 0,
         Scissor = 1,
         LineWidth = 2,
         DepthBias = 3,
         BlendConstants = 4,
         DepthBounds = 5,
         StencilCompareMask = 6,
         StencilWriteMask = 7,
         StencilReference = 8,

         //VK_NV_clip_space_w_scaling
         ViewportWScalingNV = 1000087000,
         //VK_EXT_discard_rectangles
         DiscardRectangleEXT = 1000099000,
      }

      public enum Filter : int
      {
         Nearest = 0,
         Linear = 1,
         CubicImg = 1000015000,
      }

      public enum SamplerMipmapMode : int
      {
         Nearest = 0,
         Linear = 1,
      }

      public enum SamplerAddressMode : int
      {
         Repeat = 0,
         MirroredRepeat = 1,
         ClampToEdge = 2,
         ClampToBorder = 3,
         MirrorClampToEdge = 4,
      }

      public enum BorderColor : int
      {
         FloatTransparentBlack = 0,
         IntTransparentBlack = 1,
         FloatOpaqueBlack = 2,
         IntOpaqueBlack = 3,
         FloatOpaqueWhite = 4,
         IntOpaqueWhite = 5,
      }

      public enum DescriptorType : int
      {
         Sampler = 0,
         CombinedImageSampler = 1,
         SampledImage = 2,
         StorageImage = 3,
         UniformTexelBuffer = 4,
         StorageTexelBuffer = 5,
         UniformBuffer = 6,
         StorageBuffer = 7,
         UniformBufferDynamic = 8,
         StorageBufferDynamic = 9,
         InputAttachment = 10,
      }

      public enum AttachmentLoadOp : int
      {
         Load = 0,
         Clear = 1,
         DontCare = 2,
      }

      public enum AttachmentStoreOp : int
      {
         Store = 0,
         DontCare = 1,
      }

      public enum PipelineBindPoint : int
      {
         Graphics = 0,
         Compute = 1,
      }

      public enum CommandBufferLevel : int
      {
         Primary = 0,
         Secondary = 1,
      }

      public enum IndexType : int
      {
         Uint16 = 0,
         Uint32 = 1,
      }

      public enum SubpassContents : int
      {
         Inline = 0,
         SecondaryCommandBuffers = 1,
      }

      public enum ObjectType : int
      {
         Unknown = 0,
         Instance = 1,
         PhysicalDevice = 2,
         Device = 3,
         Queue = 4,
         Semaphore = 5,
         CommandBuffer = 6,
         Fence = 7,
         DeviceMemory = 8,
         Buffer = 9,
         Image = 10,
         Event = 11,
         QueryPool = 12,
         BufferView = 13,
         ImageView = 14,
         ShaderModule = 15,
         PipelineCache = 16,
         PipelineLayout = 17,
         RenderPass = 18,
         Pipeline = 19,
         DescriptorSetLayout = 20,
         Sampler = 21,
         DescriptorPool = 22,
         DescriptorSet = 23,
         Framebuffer = 24,
         CommandPool = 25,

         //VK_KHR_surface
         SurfaceKHR = 1000000000,
         //VK_KHR_swapchain
         SwapchainKHR = 1000001000,
         //VK_KHR_display
         DisplayKHR = 1000002000,
         DisplayModeKHR = 1000002001,
         //VK_EXT_debug_report
         DebugReportCallbackEXT = 1000011000,
         //VK_NVX_device_generated_commands
         ObjectTableNVX = 1000086000,
         IndirectCommandsLayoutNVX = 1000086001,
         //VK_EXT_debug_utils
         DebugUtilsMessengerEXT = 1000128000,
         //VK_EXT_validation_cache
         ValidationCacheEXT = 1000160000,
      }

      #endregion

      #region flags
      [Flags]
      public enum FormatFeatureFlags : int
      {
         SampledImage = 0x1,
         StorageImage = 0x2,
         StorageImageAtomic = 0x4,
         UniformTexelBuffer = 0x8,
         StorageTexelBuffer = 0x10,
         StorageTexelBufferAtomic = 0x20,
         VertexBuffer = 0x40,
         ColorAttachment = 0x80,
         ColorAttachmentBlend = 0x100,
         DepthStencilAttachment = 0x200,
         BlitSrc = 0x400,
         BlitDst = 0x800,
         SampledImageFilterLinear = 0x1000,
         SampledImageFilterCubicImg = 0x2000,
         TransferSrcKHR = 0x4000,
         TransferDstKHR = 0x8000,
         SampledImageFilterMinmaxEXT = 0x10000,
      }

      [Flags]
      public enum ImageUsageFlags : int
      {
         TransferSrc = 0x1,
         TransferDst = 0x2,
         Sampled = 0x4,
         Storage = 0x8,
         ColorAttachment = 0x10,
         DepthStencilAttachment = 0x20,
         TransientAttachment = 0x40,
         InputAttachment = 0x80,
      }

      [Flags]
      public enum ImageCreateFlags : int
      {
         SparseBinding = 0x1,
         SparseResidency = 0x2,
         SparseAliased = 0x4,
         MutableFormat = 0x8,
         CubeCompatible = 0x10,
         BindSfrBitKHX = 0x40,
         Create2DArrayCompatibleKHR = 0x20,
      }

      [Flags]
      public enum SampleCountFlags : int
      {
         Count1 = 0x1,
         Count2 = 0x2,
         Count4 = 0x4,
         Count8 = 0x8,
         Count16 = 0x10,
         Count32 = 0x20,
         Count64 = 0x40,
      }

      [Flags]
      public enum QueueFlags : int
      {
         Graphics = 0x1,
         Compute = 0x2,
         Transfer = 0x4,
         SparseBinding = 0x8,
      }


      [Flags]
      public enum MemoryPropertyFlags : int
      {
         DeviceLocal = 0x1,
         HostVisible = 0x2,
         HostCoherent = 0x4,
         HostCached = 0x8,
         LazilyAllocated = 0x10,
      }

      [Flags]
      public enum MemoryHeapFlags : int
      {
         DeviceLocal = 0x1,
         MultiInstanceBitKHX = 0x2,
      }

      [Flags]
      public enum PipelineStageFlags : int
      {
         TopOfPipe = 0x1,
         DrawIndirect = 0x2,
         VertexInput = 0x4,
         VertexShader = 0x8,
         TessellationControlShader = 0x10,
         TessellationEvaluationShader = 0x20,
         GeometryShader = 0x40,
         FragmentShader = 0x80,
         EarlyFragmentTests = 0x100,
         LateFragmentTests = 0x200,
         ColorAttachmentOutput = 0x400,
         ComputeShader = 0x800,
         Transfer = 0x1000,
         BottomOfPipe = 0x2000,
         Host = 0x4000,
         AllGraphics = 0x8000,
         AllCommands = 0x10000,
         CommandProcessNVX = 0x20000,
      }

      [Flags]
      public enum ImageAspectFlags : int
      {
         Color = 0x1,
         Depth = 0x2,
         Stencil = 0x4,
         Metadata = 0x8,
      }

      [Flags]
      public enum SparseImageFormatFlags : int
      {
         SingleMiptail = 0x1,
         AlignedMipSize = 0x2,
         NonstandardBlockSize = 0x4,
      }

      [Flags]
      public enum SparseMemoryBindFlags : int
      {
         Metadata = 0x1,
      }

      [Flags]
      public enum FenceCreateFlags : int
      {
         Signaled = 0x1,
      }

      [Flags]
      public enum QueryPipelineStatisticFlags : int
      {
         InputAssemblyVertices = 0x1,
         InputAssemblyPrimitives = 0x2,
         VertexShaderInvocations = 0x4,
         GeometryShaderInvocations = 0x8,
         GeometryShaderPrimitives = 0x10,
         ClippingInvocations = 0x20,
         ClippingPrimitives = 0x40,
         FragmentShaderInvocations = 0x80,
         TessellationControlShaderPatches = 0x100,
         TessellationEvaluationShaderInvocations = 0x200,
         ComputeShaderInvocations = 0x400,
      }

      [Flags]
      public enum QueryResultFlags : int
      {
         Result64 = 0x1,
         Wait = 0x2,
         WithAvailability = 0x4,
         Partial = 0x8,
      }

      [Flags]
      public enum BufferCreateFlags : int
      {
         SparseBinding = 0x1,
         SparseResidency = 0x2,
         SparseAliased = 0x4,
      }

      [Flags]
      public enum BufferUsageFlags : int
      {
         TransferSrc = 0x1,
         TransferDst = 0x2,
         UniformTexelBuffer = 0x4,
         StorageTexelBuffer = 0x8,
         UniformBuffer = 0x10,
         StorageBuffer = 0x20,
         IndexBuffer = 0x40,
         VertexBuffer = 0x80,
         IndirectBuffer = 0x100,
      }

      [Flags]
      public enum PipelineCreateFlags : int
      {
         DisableOptimization = 0x1,
         AllowDerivatives = 0x2,
         Derivative = 0x4,
         ViewIndexFromDeviceIndexBitKHX = 0x8,
         DispatchBaseKHX = 0x10,
      }

      [Flags]
      public enum ShaderStageFlags : int
      {
         Vertex = 0x1,
         TessellationControl = 0x2,
         TessellationEvaluation = 0x4,
         Geometry = 0x8,
         Fragment = 0x10,
         Compute = 0x20,
         AllGraphics = 0x0000001F,
         All = 0x7FFFFFFF,
      }

      [Flags]
      public enum CullModeFlags : int
      {
         None = 0,
         Front = 0x1,
         Back = 0x2,
         FrontAndBack = 0x00000003,
      }

      [Flags]
      public enum ColorComponentFlags : int
      {
         R = 0x1,
         G = 0x2,
         B = 0x4,
         A = 0x8,
      }

      [Flags]
      public enum DescriptorSetLayoutCreateFlags : int
      {
         PushDescriptorKHR = 0x1,
      }

      [Flags]
      public enum DescriptorPoolCreateFlags : int
      {
         FreeDescriptorSet = 0x1,
      }

      [Flags]
      public enum AttachmentDescriptionFlags : int
      {
         MayAlias = 0x1,
      }

      [Flags]
      public enum SubpassDescriptionFlags : int
      {
         PerViewAttributesNVX = 0x1,
         PerViewPositionXOnlyNVX = 0x2,
      }

      [Flags]
      public enum AccessFlags : int
      {
         IndirectCommandRead = 0x1,
         IndexRead = 0x2,
         VertexAttributeRead = 0x4,
         UniformRead = 0x8,
         InputAttachmentRead = 0x10,
         ShaderRead = 0x20,
         ShaderWrite = 0x40,
         ColorAttachmentRead = 0x80,
         ColorAttachmentWrite = 0x100,
         DepthStencilAttachmentRead = 0x200,
         DepthStencilAttachmentWrite = 0x400,
         TransferRead = 0x800,
         TransferWrite = 0x1000,
         HostRead = 0x2000,
         HostWrite = 0x4000,
         MemoryRead = 0x8000,
         MemoryWrite = 0x10000,
         CommandProcessReadNVX = 0x20000,
         CommandProcessWriteNVX = 0x40000,
         ColorAttachmentReadNoncoherentEXT = 0x80000,
      }

      [Flags]
      public enum DependencyFlags : int
      {
         ByRegion = 0x1,
         ViewLocalBitKHX = 0x2,
         DeviceGroupBitKHX = 0x4,
      }

      [Flags]
      public enum CommandPoolCreateFlags : int
      {
         Transient = 0x1,
         ResetCommandBuffer = 0x2,
      }

      [Flags]
      public enum CommandPoolResetFlags : int
      {
         ReleaseResources = 0x1,
      }

      [Flags]
      public enum CommandBufferUsageFlags : int
      {
         OneTimeSubmit = 0x1,
         RenderPassContinue = 0x2,
         SimultaneousUse = 0x4,
      }

      [Flags]
      public enum QueryControlFlags : int
      {
         Precise = 0x1,
      }

      [Flags]
      public enum CommandBufferResetFlags : int
      {
         ReleaseResources = 0x1,
      }

      [Flags]
      public enum StencilFaceFlags : int
      {
         Front = 0x1,
         Back = 0x2,
         StencilFrontAndBack = 0x00000003,
      }
      #endregion
   }
}
