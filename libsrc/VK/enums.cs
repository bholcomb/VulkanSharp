using System;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums
    
      public enum PipelineCacheHeaderVersion: int
      {  
         One = 1,
      };
    
      public enum Result: int
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
         ErrorSurfaceLostKhr = -1000000000,
         ErrorNativeWindowInUseKhr = -1000000001,
          //VK_KHR_swapchain
         SuboptimalKhr = 1000001003,
         ErrorOutOfDateKhr = -1000001004,
          //VK_KHR_display_swapchain
         ErrorIncompatibleDisplayKhr = -1000003001,
          //VK_EXT_image_drm_format_modifier
         ErrorInvalidDrmFormatModifierPlaneLayoutExt = -1000158000,
          //VK_EXT_descriptor_indexing
         ErrorFragmentationExt = -1000161000,
          //VK_EXT_global_priority
         ErrorNotPermittedExt = -1000174001,
          //VK_EXT_buffer_device_address
         ErrorInvalidDeviceAddressExt = -1000244000,
          //VK_EXT_full_screen_exclusive
         ErrorFullScreenExclusiveModeLostExt = -1000255000,
      };
    
      public enum StructureType: int
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
         PhysicalDeviceSubgroupProperties = 1000094000,
         BindBufferMemoryInfo = 1000157000,
         BindImageMemoryInfo = 1000157001,
         PhysicalDevice16bitStorageFeatures = 1000083000,
         MemoryDedicatedRequirements = 1000127000,
         MemoryDedicatedAllocateInfo = 1000127001,
         MemoryAllocateFlagsInfo = 1000060000,
         DeviceGroupRenderPassBeginInfo = 1000060003,
         DeviceGroupCommandBufferBeginInfo = 1000060004,
         DeviceGroupSubmitInfo = 1000060005,
         DeviceGroupBindSparseInfo = 1000060006,
         BindBufferMemoryDeviceGroupInfo = 1000060013,
         BindImageMemoryDeviceGroupInfo = 1000060014,
         PhysicalDeviceGroupProperties = 1000070000,
         DeviceGroupDeviceCreateInfo = 1000070001,
         BufferMemoryRequirementsInfo2 = 1000146000,
         ImageMemoryRequirementsInfo2 = 1000146001,
         ImageSparseMemoryRequirementsInfo2 = 1000146002,
         MemoryRequirements2 = 1000146003,
         SparseImageMemoryRequirements2 = 1000146004,
         PhysicalDeviceFeatures2 = 1000059000,
         PhysicalDeviceProperties2 = 1000059001,
         FormatProperties2 = 1000059002,
         ImageFormatProperties2 = 1000059003,
         PhysicalDeviceImageFormatInfo2 = 1000059004,
         QueueFamilyProperties2 = 1000059005,
         PhysicalDeviceMemoryProperties2 = 1000059006,
         SparseImageFormatProperties2 = 1000059007,
         PhysicalDeviceSparseImageFormatInfo2 = 1000059008,
         PhysicalDevicePointClippingProperties = 1000117000,
         RenderPassInputAttachmentAspectCreateInfo = 1000117001,
         ImageViewUsageCreateInfo = 1000117002,
         PipelineTessellationDomainOriginStateCreateInfo = 1000117003,
         RenderPassMultiviewCreateInfo = 1000053000,
         PhysicalDeviceMultiviewFeatures = 1000053001,
         PhysicalDeviceMultiviewProperties = 1000053002,
         PhysicalDeviceVariablePointersFeatures = 1000120000,
         ProtectedSubmitInfo = 1000145000,
         PhysicalDeviceProtectedMemoryFeatures = 1000145001,
         PhysicalDeviceProtectedMemoryProperties = 1000145002,
         DeviceQueueInfo2 = 1000145003,
         SamplerYcbcrConversionCreateInfo = 1000156000,
         SamplerYcbcrConversionInfo = 1000156001,
         BindImagePlaneMemoryInfo = 1000156002,
         ImagePlaneMemoryRequirementsInfo = 1000156003,
         PhysicalDeviceSamplerYcbcrConversionFeatures = 1000156004,
         SamplerYcbcrConversionImageFormatProperties = 1000156005,
         DescriptorUpdateTemplateCreateInfo = 1000085000,
         PhysicalDeviceExternalImageFormatInfo = 1000071000,
         ExternalImageFormatProperties = 1000071001,
         PhysicalDeviceExternalBufferInfo = 1000071002,
         ExternalBufferProperties = 1000071003,
         PhysicalDeviceIdProperties = 1000071004,
         ExternalMemoryBufferCreateInfo = 1000072000,
         ExternalMemoryImageCreateInfo = 1000072001,
         ExportMemoryAllocateInfo = 1000072002,
         PhysicalDeviceExternalFenceInfo = 1000112000,
         ExternalFenceProperties = 1000112001,
         ExportFenceCreateInfo = 1000113000,
         ExportSemaphoreCreateInfo = 1000077000,
         PhysicalDeviceExternalSemaphoreInfo = 1000076000,
         ExternalSemaphoreProperties = 1000076001,
         PhysicalDeviceMaintenance3Properties = 1000168000,
         DescriptorSetLayoutSupport = 1000168001,
         PhysicalDeviceShaderDrawParametersFeatures = 1000063000,
          //VK_KHR_swapchain
         SwapchainCreateInfoKhr = 1000001000,
         PresentInfoKhr = 1000001001,
         DeviceGroupPresentCapabilitiesKhr = 1000001007,
         ImageSwapchainCreateInfoKhr = 1000001008,
         BindImageMemorySwapchainInfoKhr = 1000001009,
         AcquireNextImageInfoKhr = 1000001010,
         DeviceGroupPresentInfoKhr = 1000001011,
         DeviceGroupSwapchainCreateInfoKhr = 1000001012,
          //VK_KHR_display
         DisplayModeCreateInfoKhr = 1000002000,
         DisplaySurfaceCreateInfoKhr = 1000002001,
          //VK_KHR_display_swapchain
         DisplayPresentInfoKhr = 1000003000,
          //VK_KHR_xlib_surface
         XlibSurfaceCreateInfoKhr = 1000004000,
          //VK_KHR_xcb_surface
         XcbSurfaceCreateInfoKhr = 1000005000,
          //VK_KHR_wayland_surface
         WaylandSurfaceCreateInfoKhr = 1000006000,
          //VK_KHR_android_surface
         AndroidSurfaceCreateInfoKhr = 1000008000,
          //VK_KHR_win32_surface
         Win32SurfaceCreateInfoKhr = 1000009000,
          //VK_AMD_rasterization_order
         PipelineRasterizationStateRasterizationOrderAmd = 1000018000,
          //VK_EXT_transform_feedback
         PhysicalDeviceTransformFeedbackFeaturesExt = 1000028000,
         PhysicalDeviceTransformFeedbackPropertiesExt = 1000028001,
         PipelineRasterizationStateStreamCreateInfoExt = 1000028002,
          //VK_NVX_image_view_handle
         ImageViewHandleInfoNvx = 1000030000,
          //VK_AMD_texture_gather_bias_lod
         TextureLodGatherFormatPropertiesAmd = 1000041000,
          //VK_GGP_stream_descriptor_surface
         StreamDescriptorSurfaceCreateInfoGgp = 1000049000,
          //VK_NV_corner_sampled_image
         PhysicalDeviceCornerSampledImageFeaturesNv = 1000050000,
          //VK_EXT_validation_flags
         ValidationFlagsExt = 1000061000,
          //VK_NN_vi_surface
         ViSurfaceCreateInfoNn = 1000062000,
          //VK_EXT_astc_decode_mode
         ImageViewAstcDecodeModeExt = 1000067000,
         PhysicalDeviceAstcDecodeFeaturesExt = 1000067001,
          //VK_KHR_external_memory_win32
         ImportMemoryWin32HandleInfoKhr = 1000073000,
         ExportMemoryWin32HandleInfoKhr = 1000073001,
         MemoryWin32HandlePropertiesKhr = 1000073002,
         MemoryGetWin32HandleInfoKhr = 1000073003,
          //VK_KHR_external_memory_fd
         ImportMemoryFdInfoKhr = 1000074000,
         MemoryFdPropertiesKhr = 1000074001,
         MemoryGetFdInfoKhr = 1000074002,
          //VK_KHR_win32_keyed_mutex
         Win32KeyedMutexAcquireReleaseInfoKhr = 1000075000,
          //VK_KHR_external_semaphore_win32
         ImportSemaphoreWin32HandleInfoKhr = 1000078000,
         ExportSemaphoreWin32HandleInfoKhr = 1000078001,
         D3d12FenceSubmitInfoKhr = 1000078002,
         SemaphoreGetWin32HandleInfoKhr = 1000078003,
          //VK_KHR_external_semaphore_fd
         ImportSemaphoreFdInfoKhr = 1000079000,
         SemaphoreGetFdInfoKhr = 1000079001,
          //VK_KHR_push_descriptor
         PhysicalDevicePushDescriptorPropertiesKhr = 1000080000,
          //VK_EXT_conditional_rendering
         CommandBufferInheritanceConditionalRenderingInfoExt = 1000081000,
         PhysicalDeviceConditionalRenderingFeaturesExt = 1000081001,
         ConditionalRenderingBeginInfoExt = 1000081002,
          //VK_KHR_shader_float16_int8
         PhysicalDeviceFloat16Int8FeaturesKhr = 1000082000,
          //VK_KHR_incremental_present
         PresentRegionsKhr = 1000084000,
          //VK_NVX_device_generated_commands
         ObjectTableCreateInfoNvx = 1000086000,
         IndirectCommandsLayoutCreateInfoNvx = 1000086001,
         CmdProcessCommandsInfoNvx = 1000086002,
         CmdReserveSpaceForCommandsInfoNvx = 1000086003,
         DeviceGeneratedCommandsLimitsNvx = 1000086004,
         DeviceGeneratedCommandsFeaturesNvx = 1000086005,
          //VK_NV_clip_space_w_scaling
         PipelineViewportWScalingStateCreateInfoNv = 1000087000,
          //VK_EXT_display_surface_counter
         SurfaceCapabilities2Ext = 1000090000,
          //VK_EXT_display_control
         DisplayPowerInfoExt = 1000091000,
         DeviceEventInfoExt = 1000091001,
         DisplayEventInfoExt = 1000091002,
         SwapchainCounterCreateInfoExt = 1000091003,
          //VK_GOOGLE_display_timing
         PresentTimesInfoGoogle = 1000092000,
          //VK_NVX_multiview_per_view_attributes
         PhysicalDeviceMultiviewPerViewAttributesPropertiesNvx = 1000097000,
          //VK_NV_viewport_swizzle
         PipelineViewportSwizzleStateCreateInfoNv = 1000098000,
          //VK_EXT_discard_rectangles
         PhysicalDeviceDiscardRectanglePropertiesExt = 1000099000,
         PipelineDiscardRectangleStateCreateInfoExt = 1000099001,
          //VK_EXT_conservative_rasterization
         PhysicalDeviceConservativeRasterizationPropertiesExt = 1000101000,
         PipelineRasterizationConservativeStateCreateInfoExt = 1000101001,
          //VK_EXT_depth_clip_enable
         PhysicalDeviceDepthClipEnableFeaturesExt = 1000102000,
         PipelineRasterizationDepthClipStateCreateInfoExt = 1000102001,
          //VK_EXT_hdr_metadata
         HdrMetadataExt = 1000105000,
          //VK_KHR_create_renderpass2
         AttachmentDescription2Khr = 1000109000,
         AttachmentReference2Khr = 1000109001,
         SubpassDescription2Khr = 1000109002,
         SubpassDependency2Khr = 1000109003,
         RenderPassCreateInfo2Khr = 1000109004,
         SubpassBeginInfoKhr = 1000109005,
         SubpassEndInfoKhr = 1000109006,
          //VK_KHR_shared_presentable_image
         SharedPresentSurfaceCapabilitiesKhr = 1000111000,
          //VK_KHR_external_fence_win32
         ImportFenceWin32HandleInfoKhr = 1000114000,
         ExportFenceWin32HandleInfoKhr = 1000114001,
         FenceGetWin32HandleInfoKhr = 1000114002,
          //VK_KHR_external_fence_fd
         ImportFenceFdInfoKhr = 1000115000,
         FenceGetFdInfoKhr = 1000115001,
          //VK_KHR_get_surface_capabilities2
         PhysicalDeviceSurfaceInfo2Khr = 1000119000,
         SurfaceCapabilities2Khr = 1000119001,
         SurfaceFormat2Khr = 1000119002,
          //VK_KHR_get_display_properties2
         DisplayProperties2Khr = 1000121000,
         DisplayPlaneProperties2Khr = 1000121001,
         DisplayModeProperties2Khr = 1000121002,
         DisplayPlaneInfo2Khr = 1000121003,
         DisplayPlaneCapabilities2Khr = 1000121004,
          //VK_MVK_ios_surface
         IosSurfaceCreateInfoMvk = 1000122000,
          //VK_MVK_macos_surface
         MacosSurfaceCreateInfoMvk = 1000123000,
          //VK_EXT_debug_utils
         DebugUtilsObjectNameInfoExt = 1000128000,
         DebugUtilsObjectTagInfoExt = 1000128001,
         DebugUtilsLabelExt = 1000128002,
         DebugUtilsMessengerCallbackDataExt = 1000128003,
         DebugUtilsMessengerCreateInfoExt = 1000128004,
          //VK_ANDROID_external_memory_android_hardware_buffer
         AndroidHardwareBufferUsageAndroid = 1000129000,
         AndroidHardwareBufferPropertiesAndroid = 1000129001,
         AndroidHardwareBufferFormatPropertiesAndroid = 1000129002,
         ImportAndroidHardwareBufferInfoAndroid = 1000129003,
         MemoryGetAndroidHardwareBufferInfoAndroid = 1000129004,
         ExternalFormatAndroid = 1000129005,
          //VK_EXT_sampler_filter_minmax
         PhysicalDeviceSamplerFilterMinmaxPropertiesExt = 1000130000,
         SamplerReductionModeCreateInfoExt = 1000130001,
          //VK_EXT_inline_uniform_block
         PhysicalDeviceInlineUniformBlockFeaturesExt = 1000138000,
         PhysicalDeviceInlineUniformBlockPropertiesExt = 1000138001,
         WriteDescriptorSetInlineUniformBlockExt = 1000138002,
         DescriptorPoolInlineUniformBlockCreateInfoExt = 1000138003,
          //VK_EXT_sample_locations
         SampleLocationsInfoExt = 1000143000,
         RenderPassSampleLocationsBeginInfoExt = 1000143001,
         PipelineSampleLocationsStateCreateInfoExt = 1000143002,
         PhysicalDeviceSampleLocationsPropertiesExt = 1000143003,
         MultisamplePropertiesExt = 1000143004,
          //VK_KHR_image_format_list
         ImageFormatListCreateInfoKhr = 1000147000,
          //VK_EXT_blend_operation_advanced
         PhysicalDeviceBlendOperationAdvancedFeaturesExt = 1000148000,
         PhysicalDeviceBlendOperationAdvancedPropertiesExt = 1000148001,
         PipelineColorBlendAdvancedStateCreateInfoExt = 1000148002,
          //VK_NV_fragment_coverage_to_color
         PipelineCoverageToColorStateCreateInfoNv = 1000149000,
          //VK_NV_framebuffer_mixed_samples
         PipelineCoverageModulationStateCreateInfoNv = 1000152000,
          //VK_EXT_image_drm_format_modifier
         DrmFormatModifierPropertiesListExt = 1000158000,
         DrmFormatModifierPropertiesExt = 1000158001,
         PhysicalDeviceImageDrmFormatModifierInfoExt = 1000158002,
         ImageDrmFormatModifierListCreateInfoExt = 1000158003,
         ImageDrmFormatModifierExplicitCreateInfoExt = 1000158004,
         ImageDrmFormatModifierPropertiesExt = 1000158005,
          //VK_EXT_validation_cache
         ValidationCacheCreateInfoExt = 1000160000,
         ShaderModuleValidationCacheCreateInfoExt = 1000160001,
          //VK_EXT_descriptor_indexing
         DescriptorSetLayoutBindingFlagsCreateInfoExt = 1000161000,
         PhysicalDeviceDescriptorIndexingFeaturesExt = 1000161001,
         PhysicalDeviceDescriptorIndexingPropertiesExt = 1000161002,
         DescriptorSetVariableDescriptorCountAllocateInfoExt = 1000161003,
         DescriptorSetVariableDescriptorCountLayoutSupportExt = 1000161004,
          //VK_NV_shading_rate_image
         PipelineViewportShadingRateImageStateCreateInfoNv = 1000164000,
         PhysicalDeviceShadingRateImageFeaturesNv = 1000164001,
         PhysicalDeviceShadingRateImagePropertiesNv = 1000164002,
         PipelineViewportCoarseSampleOrderStateCreateInfoNv = 1000164005,
          //VK_NV_ray_tracing
         RayTracingPipelineCreateInfoNv = 1000165000,
         AccelerationStructureCreateInfoNv = 1000165001,
         GeometryNv = 1000165003,
         GeometryTrianglesNv = 1000165004,
         GeometryAabbNv = 1000165005,
         BindAccelerationStructureMemoryInfoNv = 1000165006,
         WriteDescriptorSetAccelerationStructureNv = 1000165007,
         AccelerationStructureMemoryRequirementsInfoNv = 1000165008,
         PhysicalDeviceRayTracingPropertiesNv = 1000165009,
         RayTracingShaderGroupCreateInfoNv = 1000165011,
         AccelerationStructureInfoNv = 1000165012,
          //VK_NV_representative_fragment_test
         PhysicalDeviceRepresentativeFragmentTestFeaturesNv = 1000166000,
         PipelineRepresentativeFragmentTestStateCreateInfoNv = 1000166001,
          //VK_EXT_filter_cubic
         PhysicalDeviceImageViewImageFormatInfoExt = 1000170000,
         FilterCubicImageViewImageFormatPropertiesExt = 1000170001,
          //VK_EXT_global_priority
         DeviceQueueGlobalPriorityCreateInfoExt = 1000174000,
          //VK_KHR_8bit_storage
         PhysicalDevice8bitStorageFeaturesKhr = 1000177000,
          //VK_EXT_external_memory_host
         ImportMemoryHostPointerInfoExt = 1000178000,
         MemoryHostPointerPropertiesExt = 1000178001,
         PhysicalDeviceExternalMemoryHostPropertiesExt = 1000178002,
          //VK_KHR_shader_atomic_int64
         PhysicalDeviceShaderAtomicInt64FeaturesKhr = 1000180000,
          //VK_EXT_calibrated_timestamps
         CalibratedTimestampInfoExt = 1000184000,
          //VK_AMD_shader_core_properties
         PhysicalDeviceShaderCorePropertiesAmd = 1000185000,
          //VK_AMD_memory_overallocation_behavior
         DeviceMemoryOverallocationCreateInfoAmd = 1000189000,
          //VK_EXT_vertex_attribute_divisor
         PhysicalDeviceVertexAttributeDivisorPropertiesExt = 1000190000,
         PipelineVertexInputDivisorStateCreateInfoExt = 1000190001,
         PhysicalDeviceVertexAttributeDivisorFeaturesExt = 1000190002,
          //VK_GGP_frame_token
         PresentFrameTokenGgp = 1000191000,
          //VK_EXT_pipeline_creation_feedback
         PipelineCreationFeedbackCreateInfoExt = 1000192000,
          //VK_KHR_driver_properties
         PhysicalDeviceDriverPropertiesKhr = 1000196000,
          //VK_KHR_shader_float_controls
         PhysicalDeviceFloatControlsPropertiesKhr = 1000197000,
          //VK_KHR_depth_stencil_resolve
         PhysicalDeviceDepthStencilResolvePropertiesKhr = 1000199000,
         SubpassDescriptionDepthStencilResolveKhr = 1000199001,
          //VK_NV_compute_shader_derivatives
         PhysicalDeviceComputeShaderDerivativesFeaturesNv = 1000201000,
          //VK_NV_mesh_shader
         PhysicalDeviceMeshShaderFeaturesNv = 1000202000,
         PhysicalDeviceMeshShaderPropertiesNv = 1000202001,
          //VK_NV_fragment_shader_barycentric
         PhysicalDeviceFragmentShaderBarycentricFeaturesNv = 1000203000,
          //VK_NV_shader_image_footprint
         PhysicalDeviceShaderImageFootprintFeaturesNv = 1000204000,
          //VK_NV_scissor_exclusive
         PipelineViewportExclusiveScissorStateCreateInfoNv = 1000205000,
         PhysicalDeviceExclusiveScissorFeaturesNv = 1000205002,
          //VK_NV_device_diagnostic_checkpoints
         CheckpointDataNv = 1000206000,
         QueueFamilyCheckpointPropertiesNv = 1000206001,
          //VK_KHR_vulkan_memory_model
         PhysicalDeviceVulkanMemoryModelFeaturesKhr = 1000211000,
          //VK_EXT_pci_bus_info
         PhysicalDevicePciBusInfoPropertiesExt = 1000212000,
          //VK_AMD_display_native_hdr
         DisplayNativeHdrSurfaceCapabilitiesAmd = 1000213000,
         SwapchainDisplayNativeHdrCreateInfoAmd = 1000213001,
          //VK_FUCHSIA_imagepipe_surface
         ImagepipeSurfaceCreateInfoFuchsia = 1000214000,
          //VK_EXT_metal_surface
         MetalSurfaceCreateInfoExt = 1000217000,
          //VK_EXT_fragment_density_map
         PhysicalDeviceFragmentDensityMapFeaturesExt = 1000218000,
         PhysicalDeviceFragmentDensityMapPropertiesExt = 1000218001,
         RenderPassFragmentDensityMapCreateInfoExt = 1000218002,
          //VK_EXT_scalar_block_layout
         PhysicalDeviceScalarBlockLayoutFeaturesExt = 1000221000,
          //VK_EXT_memory_budget
         PhysicalDeviceMemoryBudgetPropertiesExt = 1000237000,
          //VK_EXT_memory_priority
         PhysicalDeviceMemoryPriorityFeaturesExt = 1000238000,
         MemoryPriorityAllocateInfoExt = 1000238001,
          //VK_KHR_surface_protected_capabilities
         SurfaceProtectedCapabilitiesKhr = 1000239000,
          //VK_NV_dedicated_allocation_image_aliasing
         PhysicalDeviceDedicatedAllocationImageAliasingFeaturesNv = 1000240000,
          //VK_EXT_buffer_device_address
         PhysicalDeviceBufferDeviceAddressFeaturesExt = 1000244000,
         BufferDeviceAddressInfoExt = 1000244001,
         BufferDeviceAddressCreateInfoExt = 1000244002,
          //VK_EXT_separate_stencil_usage
         ImageStencilUsageCreateInfoExt = 1000246000,
          //VK_EXT_validation_features
         ValidationFeaturesExt = 1000247000,
          //VK_NV_cooperative_matrix
         PhysicalDeviceCooperativeMatrixFeaturesNv = 1000249000,
         CooperativeMatrixPropertiesNv = 1000249001,
         PhysicalDeviceCooperativeMatrixPropertiesNv = 1000249002,
          //VK_EXT_ycbcr_image_arrays
         PhysicalDeviceYcbcrImageArraysFeaturesExt = 1000252000,
          //VK_EXT_full_screen_exclusive
         SurfaceFullScreenExclusiveInfoExt = 1000255000,
         SurfaceCapabilitiesFullScreenExclusiveExt = 1000255002,
         SurfaceFullScreenExclusiveWin32InfoExt = 1000255001,
          //VK_EXT_headless_surface
         HeadlessSurfaceCreateInfoExt = 1000256000,
          //VK_EXT_host_query_reset
         PhysicalDeviceHostQueryResetFeaturesExt = 1000261000,
      };
    
      public enum SystemAllocationScope: int
      {  
         Command = 0,
         Object = 1,
         Cache = 2,
         Device = 3,
         Instance = 4,
      };
    
      public enum InternalAllocationType: int
      {  
         Executable = 0,
      };
    
      public enum Format: int
      {  
         Undefined = 0,
         R4g4UnormPack8 = 1,
         R4g4b4a4UnormPack16 = 2,
         B4g4r4a4UnormPack16 = 3,
         R5g6b5UnormPack16 = 4,
         B5g6r5UnormPack16 = 5,
         R5g5b5a1UnormPack16 = 6,
         B5g5r5a1UnormPack16 = 7,
         A1r5g5b5UnormPack16 = 8,
         R8Unorm = 9,
         R8Snorm = 10,
         R8Uscaled = 11,
         R8Sscaled = 12,
         R8Uint = 13,
         R8Sint = 14,
         R8Srgb = 15,
         R8g8Unorm = 16,
         R8g8Snorm = 17,
         R8g8Uscaled = 18,
         R8g8Sscaled = 19,
         R8g8Uint = 20,
         R8g8Sint = 21,
         R8g8Srgb = 22,
         R8g8b8Unorm = 23,
         R8g8b8Snorm = 24,
         R8g8b8Uscaled = 25,
         R8g8b8Sscaled = 26,
         R8g8b8Uint = 27,
         R8g8b8Sint = 28,
         R8g8b8Srgb = 29,
         B8g8r8Unorm = 30,
         B8g8r8Snorm = 31,
         B8g8r8Uscaled = 32,
         B8g8r8Sscaled = 33,
         B8g8r8Uint = 34,
         B8g8r8Sint = 35,
         B8g8r8Srgb = 36,
         R8g8b8a8Unorm = 37,
         R8g8b8a8Snorm = 38,
         R8g8b8a8Uscaled = 39,
         R8g8b8a8Sscaled = 40,
         R8g8b8a8Uint = 41,
         R8g8b8a8Sint = 42,
         R8g8b8a8Srgb = 43,
         B8g8r8a8Unorm = 44,
         B8g8r8a8Snorm = 45,
         B8g8r8a8Uscaled = 46,
         B8g8r8a8Sscaled = 47,
         B8g8r8a8Uint = 48,
         B8g8r8a8Sint = 49,
         B8g8r8a8Srgb = 50,
         A8b8g8r8UnormPack32 = 51,
         A8b8g8r8SnormPack32 = 52,
         A8b8g8r8UscaledPack32 = 53,
         A8b8g8r8SscaledPack32 = 54,
         A8b8g8r8UintPack32 = 55,
         A8b8g8r8SintPack32 = 56,
         A8b8g8r8SrgbPack32 = 57,
         A2r10g10b10UnormPack32 = 58,
         A2r10g10b10SnormPack32 = 59,
         A2r10g10b10UscaledPack32 = 60,
         A2r10g10b10SscaledPack32 = 61,
         A2r10g10b10UintPack32 = 62,
         A2r10g10b10SintPack32 = 63,
         A2b10g10r10UnormPack32 = 64,
         A2b10g10r10SnormPack32 = 65,
         A2b10g10r10UscaledPack32 = 66,
         A2b10g10r10SscaledPack32 = 67,
         A2b10g10r10UintPack32 = 68,
         A2b10g10r10SintPack32 = 69,
         R16Unorm = 70,
         R16Snorm = 71,
         R16Uscaled = 72,
         R16Sscaled = 73,
         R16Uint = 74,
         R16Sint = 75,
         R16Sfloat = 76,
         R16g16Unorm = 77,
         R16g16Snorm = 78,
         R16g16Uscaled = 79,
         R16g16Sscaled = 80,
         R16g16Uint = 81,
         R16g16Sint = 82,
         R16g16Sfloat = 83,
         R16g16b16Unorm = 84,
         R16g16b16Snorm = 85,
         R16g16b16Uscaled = 86,
         R16g16b16Sscaled = 87,
         R16g16b16Uint = 88,
         R16g16b16Sint = 89,
         R16g16b16Sfloat = 90,
         R16g16b16a16Unorm = 91,
         R16g16b16a16Snorm = 92,
         R16g16b16a16Uscaled = 93,
         R16g16b16a16Sscaled = 94,
         R16g16b16a16Uint = 95,
         R16g16b16a16Sint = 96,
         R16g16b16a16Sfloat = 97,
         R32Uint = 98,
         R32Sint = 99,
         R32Sfloat = 100,
         R32g32Uint = 101,
         R32g32Sint = 102,
         R32g32Sfloat = 103,
         R32g32b32Uint = 104,
         R32g32b32Sint = 105,
         R32g32b32Sfloat = 106,
         R32g32b32a32Uint = 107,
         R32g32b32a32Sint = 108,
         R32g32b32a32Sfloat = 109,
         R64Uint = 110,
         R64Sint = 111,
         R64Sfloat = 112,
         R64g64Uint = 113,
         R64g64Sint = 114,
         R64g64Sfloat = 115,
         R64g64b64Uint = 116,
         R64g64b64Sint = 117,
         R64g64b64Sfloat = 118,
         R64g64b64a64Uint = 119,
         R64g64b64a64Sint = 120,
         R64g64b64a64Sfloat = 121,
         B10g11r11UfloatPack32 = 122,
         E5b9g9r9UfloatPack32 = 123,
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
         Bc6hUfloatBlock = 143,
         Bc6hSfloatBlock = 144,
         Bc7UnormBlock = 145,
         Bc7SrgbBlock = 146,
         Etc2R8g8b8UnormBlock = 147,
         Etc2R8g8b8SrgbBlock = 148,
         Etc2R8g8b8a1UnormBlock = 149,
         Etc2R8g8b8a1SrgbBlock = 150,
         Etc2R8g8b8a8UnormBlock = 151,
         Etc2R8g8b8a8SrgbBlock = 152,
         EacR11UnormBlock = 153,
         EacR11SnormBlock = 154,
         EacR11g11UnormBlock = 155,
         EacR11g11SnormBlock = 156,
         Astc4x4UnormBlock = 157,
         Astc4x4SrgbBlock = 158,
         Astc5x4UnormBlock = 159,
         Astc5x4SrgbBlock = 160,
         Astc5x5UnormBlock = 161,
         Astc5x5SrgbBlock = 162,
         Astc6x5UnormBlock = 163,
         Astc6x5SrgbBlock = 164,
         Astc6x6UnormBlock = 165,
         Astc6x6SrgbBlock = 166,
         Astc8x5UnormBlock = 167,
         Astc8x5SrgbBlock = 168,
         Astc8x6UnormBlock = 169,
         Astc8x6SrgbBlock = 170,
         Astc8x8UnormBlock = 171,
         Astc8x8SrgbBlock = 172,
         Astc10x5UnormBlock = 173,
         Astc10x5SrgbBlock = 174,
         Astc10x6UnormBlock = 175,
         Astc10x6SrgbBlock = 176,
         Astc10x8UnormBlock = 177,
         Astc10x8SrgbBlock = 178,
         Astc10x10UnormBlock = 179,
         Astc10x10SrgbBlock = 180,
         Astc12x10UnormBlock = 181,
         Astc12x10SrgbBlock = 182,
         Astc12x12UnormBlock = 183,
         Astc12x12SrgbBlock = 184,
         G8b8g8r8422Unorm = 1000156000,
         B8g8r8g8422Unorm = 1000156001,
         G8B8R83plane420Unorm = 1000156002,
         G8B8r82plane420Unorm = 1000156003,
         G8B8R83plane422Unorm = 1000156004,
         G8B8r82plane422Unorm = 1000156005,
         G8B8R83plane444Unorm = 1000156006,
         R10x6UnormPack16 = 1000156007,
         R10x6g10x6Unorm2pack16 = 1000156008,
         R10x6g10x6b10x6a10x6Unorm4pack16 = 1000156009,
         G10x6b10x6g10x6r10x6422Unorm4pack16 = 1000156010,
         B10x6g10x6r10x6g10x6422Unorm4pack16 = 1000156011,
         G10x6B10x6R10x63plane420Unorm3pack16 = 1000156012,
         G10x6B10x6r10x62plane420Unorm3pack16 = 1000156013,
         G10x6B10x6R10x63plane422Unorm3pack16 = 1000156014,
         G10x6B10x6r10x62plane422Unorm3pack16 = 1000156015,
         G10x6B10x6R10x63plane444Unorm3pack16 = 1000156016,
         R12x4UnormPack16 = 1000156017,
         R12x4g12x4Unorm2pack16 = 1000156018,
         R12x4g12x4b12x4a12x4Unorm4pack16 = 1000156019,
         G12x4b12x4g12x4r12x4422Unorm4pack16 = 1000156020,
         B12x4g12x4r12x4g12x4422Unorm4pack16 = 1000156021,
         G12x4B12x4R12x43plane420Unorm3pack16 = 1000156022,
         G12x4B12x4r12x42plane420Unorm3pack16 = 1000156023,
         G12x4B12x4R12x43plane422Unorm3pack16 = 1000156024,
         G12x4B12x4r12x42plane422Unorm3pack16 = 1000156025,
         G12x4B12x4R12x43plane444Unorm3pack16 = 1000156026,
         G16b16g16r16422Unorm = 1000156027,
         B16g16r16g16422Unorm = 1000156028,
         G16B16R163plane420Unorm = 1000156029,
         G16B16r162plane420Unorm = 1000156030,
         G16B16R163plane422Unorm = 1000156031,
         G16B16r162plane422Unorm = 1000156032,
         G16B16R163plane444Unorm = 1000156033,
          //VK_IMG_format_pvrtc
         Pvrtc12bppUnormBlockImg = 1000054000,
         Pvrtc14bppUnormBlockImg = 1000054001,
         Pvrtc22bppUnormBlockImg = 1000054002,
         Pvrtc24bppUnormBlockImg = 1000054003,
         Pvrtc12bppSrgbBlockImg = 1000054004,
         Pvrtc14bppSrgbBlockImg = 1000054005,
         Pvrtc22bppSrgbBlockImg = 1000054006,
         Pvrtc24bppSrgbBlockImg = 1000054007,
      };
    
      public enum ImageType: int
      {  
         _1d = 0,
         _2d = 1,
         _3d = 2,
      };
    
      public enum ImageTiling: int
      {  
         Optimal = 0,
         Linear = 1,
          //VK_EXT_image_drm_format_modifier
         DrmFormatModifierExt = 1000158000,
      };
    
      public enum PhysicalDeviceType: int
      {  
         Other = 0,
         IntegratedGpu = 1,
         DiscreteGpu = 2,
         VirtualGpu = 3,
         Cpu = 4,
      };
    
      public enum QueryType: int
      {  
         Occlusion = 0,
         PipelineStatistics = 1,
         Timestamp = 2,
          //VK_EXT_transform_feedback
         TransformFeedbackStreamExt = 1000028004,
          //VK_NV_ray_tracing
         AccelerationStructureCompactedSizeNv = 1000165000,
      };
    
      public enum SharingMode: int
      {  
         Exclusive = 0,
         Concurrent = 1,
      };
    
      public enum ImageLayout: int
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
         DepthReadOnlyStencilAttachmentOptimal = 1000117000,
         DepthAttachmentStencilReadOnlyOptimal = 1000117001,
          //VK_KHR_swapchain
         PresentSrcKhr = 1000001002,
          //VK_KHR_shared_presentable_image
         SharedPresentKhr = 1000111000,
          //VK_NV_shading_rate_image
         ShadingRateOptimalNv = 1000164003,
          //VK_EXT_fragment_density_map
         FragmentDensityMapOptimalExt = 1000218000,
      };
    
      public enum ImageViewType: int
      {  
         _1d = 0,
         _2d = 1,
         _3d = 2,
         Cube = 3,
         _1dArray = 4,
         _2dArray = 5,
         CubeArray = 6,
      };
    
      public enum ComponentSwizzle: int
      {  
         Identity = 0,
         Zero = 1,
         One = 2,
         R = 3,
         G = 4,
         B = 5,
         A = 6,
      };
    
      public enum VertexInputRate: int
      {  
         Vertex = 0,
         Instance = 1,
      };
    
      public enum PrimitiveTopology: int
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
      };
    
      public enum PolygonMode: int
      {  
         Fill = 0,
         Line = 1,
         Point = 2,
          //VK_NV_fill_rectangle
         FillRectangleNv = 1000153000,
      };
    
      public enum FrontFace: int
      {  
         CounterClockwise = 0,
         Clockwise = 1,
      };
    
      public enum CompareOp: int
      {  
         Never = 0,
         Less = 1,
         Equal = 2,
         LessOrEqual = 3,
         Greater = 4,
         NotEqual = 5,
         GreaterOrEqual = 6,
         Always = 7,
      };
    
      public enum StencilOp: int
      {  
         Keep = 0,
         Zero = 1,
         Replace = 2,
         IncrementAndClamp = 3,
         DecrementAndClamp = 4,
         Invert = 5,
         IncrementAndWrap = 6,
         DecrementAndWrap = 7,
      };
    
      public enum LogicOp: int
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
      };
    
      public enum BlendFactor: int
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
      };
    
      public enum BlendOp: int
      {  
         Add = 0,
         Subtract = 1,
         ReverseSubtract = 2,
         Min = 3,
         Max = 4,
          //VK_EXT_blend_operation_advanced
         ZeroExt = 1000148000,
         SrcExt = 1000148001,
         DstExt = 1000148002,
         SrcOverExt = 1000148003,
         DstOverExt = 1000148004,
         SrcInExt = 1000148005,
         DstInExt = 1000148006,
         SrcOutExt = 1000148007,
         DstOutExt = 1000148008,
         SrcAtopExt = 1000148009,
         DstAtopExt = 1000148010,
         XorExt = 1000148011,
         MultiplyExt = 1000148012,
         ScreenExt = 1000148013,
         OverlayExt = 1000148014,
         DarkenExt = 1000148015,
         LightenExt = 1000148016,
         ColordodgeExt = 1000148017,
         ColorburnExt = 1000148018,
         HardlightExt = 1000148019,
         SoftlightExt = 1000148020,
         DifferenceExt = 1000148021,
         ExclusionExt = 1000148022,
         InvertExt = 1000148023,
         InvertRgbExt = 1000148024,
         LineardodgeExt = 1000148025,
         LinearburnExt = 1000148026,
         VividlightExt = 1000148027,
         LinearlightExt = 1000148028,
         PinlightExt = 1000148029,
         HardmixExt = 1000148030,
         HslHueExt = 1000148031,
         HslSaturationExt = 1000148032,
         HslColorExt = 1000148033,
         HslLuminosityExt = 1000148034,
         PlusExt = 1000148035,
         PlusClampedExt = 1000148036,
         PlusClampedAlphaExt = 1000148037,
         PlusDarkerExt = 1000148038,
         MinusExt = 1000148039,
         MinusClampedExt = 1000148040,
         ContrastExt = 1000148041,
         InvertOvgExt = 1000148042,
         RedExt = 1000148043,
         GreenExt = 1000148044,
         BlueExt = 1000148045,
      };
    
      public enum DynamicState: int
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
         ViewportWScalingNv = 1000087000,
          //VK_EXT_discard_rectangles
         DiscardRectangleExt = 1000099000,
          //VK_EXT_sample_locations
         SampleLocationsExt = 1000143000,
          //VK_NV_shading_rate_image
         ViewportShadingRatePaletteNv = 1000164004,
         ViewportCoarseSampleOrderNv = 1000164006,
          //VK_NV_scissor_exclusive
         ExclusiveScissorNv = 1000205001,
      };
    
      public enum Filter: int
      {  
         Nearest = 0,
         Linear = 1,
          //VK_IMG_filter_cubic
         CubicImg = 1000015000,
      };
    
      public enum SamplerMipmapMode: int
      {  
         Nearest = 0,
         Linear = 1,
      };
    
      public enum SamplerAddressMode: int
      {  
         Repeat = 0,
         MirroredRepeat = 1,
         ClampToEdge = 2,
         ClampToBorder = 3,
      };
    
      public enum BorderColor: int
      {  
         FloatTransparentBlack = 0,
         IntTransparentBlack = 1,
         FloatOpaqueBlack = 2,
         IntOpaqueBlack = 3,
         FloatOpaqueWhite = 4,
         IntOpaqueWhite = 5,
      };
    
      public enum DescriptorType: int
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
          //VK_EXT_inline_uniform_block
         InlineUniformBlockExt = 1000138000,
          //VK_NV_ray_tracing
         AccelerationStructureNv = 1000165000,
      };
    
      public enum AttachmentLoadOp: int
      {  
         Load = 0,
         Clear = 1,
         DontCare = 2,
      };
    
      public enum AttachmentStoreOp: int
      {  
         Store = 0,
         DontCare = 1,
      };
    
      public enum PipelineBindPoint: int
      {  
         Graphics = 0,
         Compute = 1,
          //VK_NV_ray_tracing
         RayTracingNv = 1000165000,
      };
    
      public enum CommandBufferLevel: int
      {  
         Primary = 0,
         Secondary = 1,
      };
    
      public enum IndexType: int
      {  
         Uint16 = 0,
         Uint32 = 1,
          //VK_NV_ray_tracing
         NoneNv = 1000165000,
      };
    
      public enum SubpassContents: int
      {  
         Inline = 0,
         SecondaryCommandBuffers = 1,
      };
    
      public enum ObjectType: int
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
         SamplerYcbcrConversion = 1000156000,
         DescriptorUpdateTemplate = 1000085000,
          //VK_KHR_surface
         SurfaceKhr = 1000000000,
          //VK_KHR_swapchain
         SwapchainKhr = 1000001000,
          //VK_KHR_display
         DisplayKhr = 1000002000,
         DisplayModeKhr = 1000002001,
          //VK_NVX_device_generated_commands
         ObjectTableNvx = 1000086000,
         IndirectCommandsLayoutNvx = 1000086001,
          //VK_EXT_debug_utils
         DebugUtilsMessengerExt = 1000128000,
          //VK_EXT_validation_cache
         ValidationCacheExt = 1000160000,
          //VK_NV_ray_tracing
         AccelerationStructureNv = 1000165000,
      };
    
      public enum VendorId: int
      {  
         Viv = 0x10001,
         Vsi = 0x10002,
         Kazan = 0x10003,
      };
    
      public enum PointClippingBehavior: int
      {  
         AllClipPlanes = 0,
         UserClipPlanesOnly = 1,
      };
    
      public enum TessellationDomainOrigin: int
      {  
         UpperLeft = 0,
         LowerLeft = 1,
      };
    
      public enum SamplerYcbcrModelConversion: int
      {  
         RgbIdentity = 0,
         YcbcrIdentity = 1,
         Ycbcr709 = 2,
         Ycbcr601 = 3,
         Ycbcr2020 = 4,
      };
    
      public enum SamplerYcbcrRange: int
      {  
         ItuFull = 0,
         ItuNarrow = 1,
      };
    
      public enum ChromaLocation: int
      {  
         CositedEven = 0,
         Midpoint = 1,
      };
    
      public enum DescriptorUpdateTemplateType: int
      {  
         DescriptorSet = 0,
      };
      #endregion

      #region bitmasks
      [Flags]
      public enum InstanceCreateFlags : int
      {
      };

      [Flags]
      public enum FormatFeatureFlags : int
      {
         SampledImageBit = 1 << 0,
         StorageImageBit = 1 << 1,
         StorageImageAtomicBit = 1 << 2,
         UniformTexelBufferBit = 1 << 3,
         StorageTexelBufferBit = 1 << 4,
         StorageTexelBufferAtomicBit = 1 << 5,
         VertexBufferBit = 1 << 6,
         ColorAttachmentBit = 1 << 7,
         ColorAttachmentBlendBit = 1 << 8,
         DepthStencilAttachmentBit = 1 << 9,
         BlitSrcBit = 1 << 10,
         BlitDstBit = 1 << 11,
         SampledImageFilterLinearBit = 1 << 12,
         TransferSrcBit = 1 << 14,
         TransferDstBit = 1 << 15,
         MidpointChromaSamplesBit = 1 << 17,
         SampledImageYcbcrConversionLinearFilterBit = 1 << 18,
         SampledImageYcbcrConversionSeparateReconstructionFilterBit = 1 << 19,
         SampledImageYcbcrConversionChromaReconstructionExplicitBit = 1 << 20,
         SampledImageYcbcrConversionChromaReconstructionExplicitForceableBit = 1 << 21,
         DisjointBit = 1 << 22,
         CositedChromaSamplesBit = 1 << 23,
         //VK_IMG_filter_cubic
         SampledImageFilterCubicBitImg = 1 << 13,
         //VK_EXT_sampler_filter_minmax
         SampledImageFilterMinmaxBitExt = 1 << 16,
         //VK_EXT_fragment_density_map
         FragmentDensityMapBitExt = 1 << 24,
      };

      [Flags]
      public enum ImageUsageFlags : int
      {
         TransferSrcBit = 1 << 0,
         TransferDstBit = 1 << 1,
         SampledBit = 1 << 2,
         StorageBit = 1 << 3,
         ColorAttachmentBit = 1 << 4,
         DepthStencilAttachmentBit = 1 << 5,
         TransientAttachmentBit = 1 << 6,
         InputAttachmentBit = 1 << 7,
         //VK_NV_shading_rate_image
         ShadingRateImageBitNv = 1 << 8,
         //VK_EXT_fragment_density_map
         FragmentDensityMapBitExt = 1 << 9,
      };

      [Flags]
      public enum ImageCreateFlags : int
      {
         SparseBindingBit = 1 << 0,
         SparseResidencyBit = 1 << 1,
         SparseAliasedBit = 1 << 2,
         MutableFormatBit = 1 << 3,
         CubeCompatibleBit = 1 << 4,
         AliasBit = 1 << 10,
         SplitInstanceBindRegionsBit = 1 << 6,
         _2dArrayCompatibleBit = 1 << 5,
         BlockTexelViewCompatibleBit = 1 << 7,
         ExtendedUsageBit = 1 << 8,
         ProtectedBit = 1 << 11,
         DisjointBit = 1 << 9,
         //VK_NV_corner_sampled_image
         CornerSampledBitNv = 1 << 13,
         //VK_EXT_sample_locations
         SampleLocationsCompatibleDepthBitExt = 1 << 12,
         //VK_EXT_fragment_density_map
         SubsampledBitExt = 1 << 14,
      };

      [Flags]
      public enum SampleCountFlags : int
      {
         _1Bit = 1 << 0,
         _2Bit = 1 << 1,
         _4Bit = 1 << 2,
         _8Bit = 1 << 3,
         _16Bit = 1 << 4,
         _32Bit = 1 << 5,
         _64Bit = 1 << 6,
      };

      [Flags]
      public enum QueueFlags : int
      {
         GraphicsBit = 1 << 0,
         ComputeBit = 1 << 1,
         TransferBit = 1 << 2,
         SparseBindingBit = 1 << 3,
         ProtectedBit = 1 << 4,
      };

      [Flags]
      public enum MemoryPropertyFlags : int
      {
         DeviceLocalBit = 1 << 0,
         HostVisibleBit = 1 << 1,
         HostCoherentBit = 1 << 2,
         HostCachedBit = 1 << 3,
         LazilyAllocatedBit = 1 << 4,
         ProtectedBit = 1 << 5,
      };

      [Flags]
      public enum MemoryHeapFlags : int
      {
         DeviceLocalBit = 1 << 0,
         MultiInstanceBit = 1 << 1,
      };

      [Flags]
      public enum DeviceCreateFlags : int
      {
      };

      [Flags]
      public enum DeviceQueueCreateFlags : int
      {
         ProtectedBit = 1 << 0,
      };

      [Flags]
      public enum PipelineStageFlags : int
      {
         TopOfPipeBit = 1 << 0,
         DrawIndirectBit = 1 << 1,
         VertexInputBit = 1 << 2,
         VertexShaderBit = 1 << 3,
         TessellationControlShaderBit = 1 << 4,
         TessellationEvaluationShaderBit = 1 << 5,
         GeometryShaderBit = 1 << 6,
         FragmentShaderBit = 1 << 7,
         EarlyFragmentTestsBit = 1 << 8,
         LateFragmentTestsBit = 1 << 9,
         ColorAttachmentOutputBit = 1 << 10,
         ComputeShaderBit = 1 << 11,
         TransferBit = 1 << 12,
         BottomOfPipeBit = 1 << 13,
         HostBit = 1 << 14,
         AllGraphicsBit = 1 << 15,
         AllCommandsBit = 1 << 16,
         //VK_EXT_transform_feedback
         TransformFeedbackBitExt = 1 << 24,
         //VK_EXT_conditional_rendering
         ConditionalRenderingBitExt = 1 << 18,
         //VK_NVX_device_generated_commands
         CommandProcessBitNvx = 1 << 17,
         //VK_NV_shading_rate_image
         ShadingRateImageBitNv = 1 << 22,
         //VK_NV_ray_tracing
         RayTracingShaderBitNv = 1 << 21,
         AccelerationStructureBuildBitNv = 1 << 25,
         //VK_NV_mesh_shader
         TaskShaderBitNv = 1 << 19,
         MeshShaderBitNv = 1 << 20,
         //VK_EXT_fragment_density_map
         FragmentDensityProcessBitExt = 1 << 23,
      };

      [Flags]
      public enum MemoryMapFlags : int
      {
      };

      [Flags]
      public enum ImageAspectFlags : int
      {
         ColorBit = 1 << 0,
         DepthBit = 1 << 1,
         StencilBit = 1 << 2,
         MetadataBit = 1 << 3,
         Plane0Bit = 1 << 4,
         Plane1Bit = 1 << 5,
         Plane2Bit = 1 << 6,
         //VK_EXT_image_drm_format_modifier
         MemoryPlane0BitExt = 1 << 7,
         MemoryPlane1BitExt = 1 << 8,
         MemoryPlane2BitExt = 1 << 9,
         MemoryPlane3BitExt = 1 << 10,
      };

      [Flags]
      public enum SparseImageFormatFlags : int
      {
         SingleMiptailBit = 1 << 0,
         AlignedMipSizeBit = 1 << 1,
         NonstandardBlockSizeBit = 1 << 2,
      };

      [Flags]
      public enum SparseMemoryBindFlags : int
      {
         MetadataBit = 1 << 0,
      };

      [Flags]
      public enum FenceCreateFlags : int
      {
         SignaledBit = 1 << 0,
      };

      [Flags]
      public enum SemaphoreCreateFlags : int
      {
      };

      [Flags]
      public enum EventCreateFlags : int
      {
      };

      [Flags]
      public enum QueryPoolCreateFlags : int
      {
      };

      [Flags]
      public enum QueryPipelineStatisticFlags : int
      {
         InputAssemblyVerticesBit = 1 << 0,
         InputAssemblyPrimitivesBit = 1 << 1,
         VertexShaderInvocationsBit = 1 << 2,
         GeometryShaderInvocationsBit = 1 << 3,
         GeometryShaderPrimitivesBit = 1 << 4,
         ClippingInvocationsBit = 1 << 5,
         ClippingPrimitivesBit = 1 << 6,
         FragmentShaderInvocationsBit = 1 << 7,
         TessellationControlShaderPatchesBit = 1 << 8,
         TessellationEvaluationShaderInvocationsBit = 1 << 9,
         ComputeShaderInvocationsBit = 1 << 10,
      };

      [Flags]
      public enum QueryResultFlags : int
      {
         _64Bit = 1 << 0,
         WaitBit = 1 << 1,
         WithAvailabilityBit = 1 << 2,
         PartialBit = 1 << 3,
      };

      [Flags]
      public enum BufferCreateFlags : int
      {
         SparseBindingBit = 1 << 0,
         SparseResidencyBit = 1 << 1,
         SparseAliasedBit = 1 << 2,
         ProtectedBit = 1 << 3,
         //VK_EXT_buffer_device_address
         DeviceAddressCaptureReplayBitExt = 1 << 4,
      };

      [Flags]
      public enum BufferUsageFlags : int
      {
         TransferSrcBit = 1 << 0,
         TransferDstBit = 1 << 1,
         UniformTexelBufferBit = 1 << 2,
         StorageTexelBufferBit = 1 << 3,
         UniformBufferBit = 1 << 4,
         StorageBufferBit = 1 << 5,
         IndexBufferBit = 1 << 6,
         VertexBufferBit = 1 << 7,
         IndirectBufferBit = 1 << 8,
         //VK_EXT_transform_feedback
         TransformFeedbackBufferBitExt = 1 << 11,
         TransformFeedbackCounterBufferBitExt = 1 << 12,
         //VK_EXT_conditional_rendering
         ConditionalRenderingBitExt = 1 << 9,
         //VK_NV_ray_tracing
         RayTracingBitNv = 1 << 10,
         //VK_EXT_buffer_device_address
         ShaderDeviceAddressBitExt = 1 << 17,
      };

      [Flags]
      public enum BufferViewCreateFlags : int
      {
      };

      [Flags]
      public enum ImageViewCreateFlags : int
      {
         //VK_EXT_fragment_density_map
         FragmentDensityMapDynamicBitExt = 1 << 0,
      };

      [Flags]
      public enum ShaderModuleCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineCacheCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineCreateFlags : int
      {
         DisableOptimizationBit = 1 << 0,
         AllowDerivativesBit = 1 << 1,
         DerivativeBit = 1 << 2,
         ViewIndexFromDeviceIndexBit = 1 << 3,
         DispatchBase = 1 << 4,
         //VK_NV_ray_tracing
         DeferCompileBitNv = 1 << 5,
      };

      [Flags]
      public enum PipelineShaderStageCreateFlags : int
      {
      };

      [Flags]
      public enum ShaderStageFlags : int
      {
         VertexBit = 1 << 0,
         TessellationControlBit = 1 << 1,
         TessellationEvaluationBit = 1 << 2,
         GeometryBit = 1 << 3,
         FragmentBit = 1 << 4,
         ComputeBit = 1 << 5,
         //VK_NV_ray_tracing
         RaygenBitNv = 1 << 8,
         AnyHitBitNv = 1 << 9,
         ClosestHitBitNv = 1 << 10,
         MissBitNv = 1 << 11,
         IntersectionBitNv = 1 << 12,
         CallableBitNv = 1 << 13,
         //VK_NV_mesh_shader
         TaskBitNv = 1 << 6,
         MeshBitNv = 1 << 7,
      };

      [Flags]
      public enum PipelineVertexInputStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineInputAssemblyStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineTessellationStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineViewportStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineRasterizationStateCreateFlags : int
      {
      };

      [Flags]
      public enum CullModeFlags : int
      {
         FrontBit = 1 << 0,
         BackBit = 1 << 1,
      };

      [Flags]
      public enum PipelineMultisampleStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineDepthStencilStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineColorBlendStateCreateFlags : int
      {
      };

      [Flags]
      public enum ColorComponentFlags : int
      {
         RBit = 1 << 0,
         GBit = 1 << 1,
         BBit = 1 << 2,
         ABit = 1 << 3,
      };

      [Flags]
      public enum PipelineDynamicStateCreateFlags : int
      {
      };

      [Flags]
      public enum PipelineLayoutCreateFlags : int
      {
      };

      [Flags]
      public enum SamplerCreateFlags : int
      {
         //VK_EXT_fragment_density_map
         SubsampledBitExt = 1 << 0,
         SubsampledCoarseReconstructionBitExt = 1 << 1,
      };

      [Flags]
      public enum DescriptorSetLayoutCreateFlags : int
      {
         //VK_KHR_push_descriptor
         PushDescriptorBitKhr = 1 << 0,
         //VK_EXT_descriptor_indexing
         UpdateAfterBindPoolBitExt = 1 << 1,
      };

      [Flags]
      public enum DescriptorPoolCreateFlags : int
      {
         FreeDescriptorSetBit = 1 << 0,
         //VK_EXT_descriptor_indexing
         UpdateAfterBindBitExt = 1 << 1,
      };

      [Flags]
      public enum DescriptorPoolResetFlags : int
      {
      };

      [Flags]
      public enum FramebufferCreateFlags : int
      {
      };

      [Flags]
      public enum RenderPassCreateFlags : int
      {
      };

      [Flags]
      public enum AttachmentDescriptionFlags : int
      {
         MayAliasBit = 1 << 0,
      };

      [Flags]
      public enum SubpassDescriptionFlags : int
      {
         //VK_NVX_multiview_per_view_attributes
         PerViewAttributesBitNvx = 1 << 0,
         PerViewPositionXOnlyBitNvx = 1 << 1,
      };

      [Flags]
      public enum AccessFlags : int
      {
         IndirectCommandReadBit = 1 << 0,
         IndexReadBit = 1 << 1,
         VertexAttributeReadBit = 1 << 2,
         UniformReadBit = 1 << 3,
         InputAttachmentReadBit = 1 << 4,
         ShaderReadBit = 1 << 5,
         ShaderWriteBit = 1 << 6,
         ColorAttachmentReadBit = 1 << 7,
         ColorAttachmentWriteBit = 1 << 8,
         DepthStencilAttachmentReadBit = 1 << 9,
         DepthStencilAttachmentWriteBit = 1 << 10,
         TransferReadBit = 1 << 11,
         TransferWriteBit = 1 << 12,
         HostReadBit = 1 << 13,
         HostWriteBit = 1 << 14,
         MemoryReadBit = 1 << 15,
         MemoryWriteBit = 1 << 16,
         //VK_EXT_transform_feedback
         TransformFeedbackWriteBitExt = 1 << 25,
         TransformFeedbackCounterReadBitExt = 1 << 26,
         TransformFeedbackCounterWriteBitExt = 1 << 27,
         //VK_EXT_conditional_rendering
         ConditionalRenderingReadBitExt = 1 << 20,
         //VK_NVX_device_generated_commands
         CommandProcessReadBitNvx = 1 << 17,
         CommandProcessWriteBitNvx = 1 << 18,
         //VK_EXT_blend_operation_advanced
         ColorAttachmentReadNoncoherentBitExt = 1 << 19,
         //VK_NV_shading_rate_image
         ShadingRateImageReadBitNv = 1 << 23,
         //VK_NV_ray_tracing
         AccelerationStructureReadBitNv = 1 << 21,
         AccelerationStructureWriteBitNv = 1 << 22,
         //VK_EXT_fragment_density_map
         FragmentDensityMapReadBitExt = 1 << 24,
      };

      [Flags]
      public enum DependencyFlags : int
      {
         ByRegionBit = 1 << 0,
         DeviceGroupBit = 1 << 2,
         ViewLocalBit = 1 << 1,
      };

      [Flags]
      public enum CommandPoolCreateFlags : int
      {
         TransientBit = 1 << 0,
         ResetCommandBufferBit = 1 << 1,
         ProtectedBit = 1 << 2,
      };

      [Flags]
      public enum CommandPoolResetFlags : int
      {
         ReleaseResourcesBit = 1 << 0,
      };

      [Flags]
      public enum CommandBufferUsageFlags : int
      {
         OneTimeSubmitBit = 1 << 0,
         RenderPassContinueBit = 1 << 1,
         SimultaneousUseBit = 1 << 2,
      };

      [Flags]
      public enum QueryControlFlags : int
      {
         PreciseBit = 1 << 0,
      };

      [Flags]
      public enum CommandBufferResetFlags : int
      {
         ReleaseResourcesBit = 1 << 0,
      };

      [Flags]
      public enum StencilFaceFlags : int
      {
         FrontBit = 1 << 0,
         BackBit = 1 << 1,
      };

      [Flags]
      public enum SubgroupFeatureFlags : int
      {
         BasicBit = 1 << 0,
         VoteBit = 1 << 1,
         ArithmeticBit = 1 << 2,
         BallotBit = 1 << 3,
         ShuffleBit = 1 << 4,
         ShuffleRelativeBit = 1 << 5,
         ClusteredBit = 1 << 6,
         QuadBit = 1 << 7,
         //VK_NV_shader_subgroup_partitioned
         PartitionedBitNv = 1 << 8,
      };

      [Flags]
      public enum PeerMemoryFeatureFlags : int
      {
         CopySrcBit = 1 << 0,
         CopyDstBit = 1 << 1,
         GenericSrcBit = 1 << 2,
         GenericDstBit = 1 << 3,
      };

      [Flags]
      public enum MemoryAllocateFlags : int
      {
         DeviceMaskBit = 1 << 0,
      };

      [Flags]
      public enum CommandPoolTrimFlags : int
      {
      };

      [Flags]
      public enum DescriptorUpdateTemplateCreateFlags : int
      {
      };

      [Flags]
      public enum ExternalMemoryHandleTypeFlags : int
      {
         OpaqueFdBit = 1 << 0,
         OpaqueWin32Bit = 1 << 1,
         OpaqueWin32KmtBit = 1 << 2,
         D3d11TextureBit = 1 << 3,
         D3d11TextureKmtBit = 1 << 4,
         D3d12HeapBit = 1 << 5,
         D3d12ResourceBit = 1 << 6,
         //VK_EXT_external_memory_dma_buf
         DmaBufBitExt = 1 << 9,
         //VK_ANDROID_external_memory_android_hardware_buffer
         AndroidHardwareBufferBitAndroid = 1 << 10,
         //VK_EXT_external_memory_host
         HostAllocationBitExt = 1 << 7,
         HostMappedForeignMemoryBitExt = 1 << 8,
      };

      [Flags]
      public enum ExternalMemoryFeatureFlags : int
      {
         DedicatedOnlyBit = 1 << 0,
         ExportableBit = 1 << 1,
         ImportableBit = 1 << 2,
      };

      [Flags]
      public enum ExternalFenceHandleTypeFlags : int
      {
         OpaqueFdBit = 1 << 0,
         OpaqueWin32Bit = 1 << 1,
         OpaqueWin32KmtBit = 1 << 2,
         SyncFdBit = 1 << 3,
      };

      [Flags]
      public enum ExternalFenceFeatureFlags : int
      {
         ExportableBit = 1 << 0,
         ImportableBit = 1 << 1,
      };

      [Flags]
      public enum FenceImportFlags : int
      {
         TemporaryBit = 1 << 0,
      };

      [Flags]
      public enum SemaphoreImportFlags : int
      {
         TemporaryBit = 1 << 0,
      };

      [Flags]
      public enum ExternalSemaphoreHandleTypeFlags : int
      {
         OpaqueFdBit = 1 << 0,
         OpaqueWin32Bit = 1 << 1,
         OpaqueWin32KmtBit = 1 << 2,
         D3d12FenceBit = 1 << 3,
         SyncFdBit = 1 << 4,
      };

      [Flags]
      public enum ExternalSemaphoreFeatureFlags : int
      {
         ExportableBit = 1 << 0,
         ImportableBit = 1 << 1,
      };

      #endregion
   }
}
