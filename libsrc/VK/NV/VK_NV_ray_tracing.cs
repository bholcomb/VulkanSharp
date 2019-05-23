using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_ray_tracing = "VK_NV_ray_tracing";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct AccelerationStructureNV { public UInt64 native; }
      #endregion 
      

      #region enums
      public enum RayTracingShaderGroupTypeNV : int
      {  
         GeneralNv = 0,
         TrianglesHitGroupNv = 1,
         ProceduralHitGroupNv = 2,
      };
      
      public enum GeometryTypeNV : int
      {  
         TrianglesNv = 0,
         AabbsNv = 1,
      };
      
      public enum AccelerationStructureTypeNV : int
      {  
         TopLevelNv = 0,
         BottomLevelNv = 1,
      };
      
      public enum CopyAccelerationStructureModeNV : int
      {  
         CloneNv = 0,
         CompactNv = 1,
      };
      
      public enum AccelerationStructureMemoryRequirementsTypeNV : int
      {  
         ObjectNv = 0,
         BuildScratchNv = 1,
         UpdateScratchNv = 2,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum GeometryFlagsNV : int
      {  
         GeometryOpaqueBitNv = 1 << 0,
         GeometryNoDuplicateAnyHitInvocationBitNv = 1 << 1,
      };
      
      [Flags]
      public enum GeometryInstanceFlagsNV : int
      {  
         GeometryInstanceTriangleCullDisableBitNv = 1 << 0,
         GeometryInstanceTriangleFrontCounterclockwiseBitNv = 1 << 1,
         GeometryInstanceForceOpaqueBitNv = 1 << 2,
         GeometryInstanceForceNoOpaqueBitNv = 1 << 3,
      };
      
      [Flags]
      public enum BuildAccelerationStructureFlagsNV : int
      {  
         BuildAccelerationStructureAllowUpdateBitNv = 1 << 0,
         BuildAccelerationStructureAllowCompactionBitNv = 1 << 1,
         BuildAccelerationStructurePreferFastTraceBitNv = 1 << 2,
         BuildAccelerationStructurePreferFastBuildBitNv = 1 << 3,
         BuildAccelerationStructureLowMemoryBitNv = 1 << 4,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RayTracingShaderGroupCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public RayTracingShaderGroupTypeNV type;          
         public UInt32 generalShader;          
         public UInt32 closestHitShader;          
         public UInt32 anyHitShader;          
         public UInt32 intersectionShader;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RayTracingPipelineCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineCreateFlags flags;  //Pipeline creation flags 
         public UInt32 stageCount;          
         public IntPtr/*PipelineShaderStageCreateInfo**/ pStages;  //One entry for each active shader stage 
         public UInt32 groupCount;          
         public RayTracingShaderGroupCreateInfoNV* pGroups;          
         public UInt32 maxRecursionDepth;          
         public PipelineLayout layout;  //Interface layout of the pipeline 
         public Pipeline basePipelineHandle;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of 
         public Int32 basePipelineIndex;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct GeometryTrianglesNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Buffer vertexData;          
         public DeviceSize vertexOffset;          
         public UInt32 vertexCount;          
         public DeviceSize vertexStride;          
         public Format vertexFormat;          
         public Buffer indexData;          
         public DeviceSize indexOffset;          
         public UInt32 indexCount;          
         public IndexType indexType;          
         public Buffer transformData;  //Optional reference to array of floats representing a 3x4 row major affine transformation matrix. 
         public DeviceSize transformOffset;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct GeometryAABBNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Buffer aabbData;          
         public UInt32 numAABBs;          
         public UInt32 stride;  //Stride in bytes between AABBs 
         public DeviceSize offset;  //Offset in bytes of the first AABB in aabbData 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct GeometryDataNV 
      {
         public GeometryTrianglesNV triangles;          
         public GeometryAABBNV aabbs;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct GeometryNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public GeometryTypeNV geometryType;          
         public GeometryDataNV geometry;          
         public GeometryFlagsNV flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct AccelerationStructureInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccelerationStructureTypeNV type;          
         public BuildAccelerationStructureFlagsNV flags;          
         public UInt32 instanceCount;          
         public UInt32 geometryCount;          
         public GeometryNV* pGeometries;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AccelerationStructureCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceSize compactedSize;          
         public AccelerationStructureInfoNV info;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct BindAccelerationStructureMemoryInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccelerationStructureNV accelerationStructure;          
         public DeviceMemory memory;          
         public DeviceSize memoryOffset;          
         public UInt32 deviceIndexCount;          
         public UInt32* pDeviceIndices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct WriteDescriptorSetAccelerationStructureNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 accelerationStructureCount;          
         public AccelerationStructureNV* pAccelerationStructures;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AccelerationStructureMemoryRequirementsInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public AccelerationStructureMemoryRequirementsTypeNV type;          
         public AccelerationStructureNV accelerationStructure;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceRayTracingPropertiesNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 shaderGroupHandleSize;          
         public UInt32 maxRecursionDepth;          
         public UInt32 maxShaderGroupStride;          
         public UInt32 shaderGroupBaseAlignment;          
         public UInt64 maxGeometryCount;          
         public UInt64 maxInstanceCount;          
         public UInt64 maxTriangleCount;          
         public UInt32 maxDescriptorSetAccelerationStructures;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateAccelerationStructureNV(VkDevice device, VkAccelerationStructureCreateInfoNV* pCreateInfo, VkAllocationCallbacks* pAllocator, VkAccelerationStructureNV* pAccelerationStructure);
      //void vkDestroyAccelerationStructureNV(VkDevice device, VkAccelerationStructureNV accelerationStructure, VkAllocationCallbacks* pAllocator);
      //void vkGetAccelerationStructureMemoryRequirementsNV(VkDevice device, VkAccelerationStructureMemoryRequirementsInfoNV* pInfo, VkMemoryRequirements2KHR* pMemoryRequirements);
      //VkResult vkBindAccelerationStructureMemoryNV(VkDevice device, uint32_t bindInfoCount, VkBindAccelerationStructureMemoryInfoNV* pBindInfos);
      //void vkCmdBuildAccelerationStructureNV(VkCommandBuffer commandBuffer, VkAccelerationStructureInfoNV* pInfo, VkBuffer instanceData, VkDeviceSize instanceOffset, VkBool32 update, VkAccelerationStructureNV dst, VkAccelerationStructureNV src, VkBuffer scratch, VkDeviceSize scratchOffset);
      //void vkCmdCopyAccelerationStructureNV(VkCommandBuffer commandBuffer, VkAccelerationStructureNV dst, VkAccelerationStructureNV src, VkCopyAccelerationStructureModeNV mode);
      //void vkCmdTraceRaysNV(VkCommandBuffer commandBuffer, VkBuffer raygenShaderBindingTableBuffer, VkDeviceSize raygenShaderBindingOffset, VkBuffer missShaderBindingTableBuffer, VkDeviceSize missShaderBindingOffset, VkDeviceSize missShaderBindingStride, VkBuffer hitShaderBindingTableBuffer, VkDeviceSize hitShaderBindingOffset, VkDeviceSize hitShaderBindingStride, VkBuffer callableShaderBindingTableBuffer, VkDeviceSize callableShaderBindingOffset, VkDeviceSize callableShaderBindingStride, uint32_t width, uint32_t height, uint32_t depth);
      //VkResult vkCreateRayTracingPipelinesNV(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkRayTracingPipelineCreateInfoNV* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);
      //VkResult vkGetRayTracingShaderGroupHandlesNV(VkDevice device, VkPipeline pipeline, uint32_t firstGroup, uint32_t groupCount, size_t dataSize, void* pData);
      //VkResult vkGetAccelerationStructureHandleNV(VkDevice device, VkAccelerationStructureNV accelerationStructure, size_t dataSize, void* pData);
      //void vkCmdWriteAccelerationStructuresPropertiesNV(VkCommandBuffer commandBuffer, uint32_t accelerationStructureCount, VkAccelerationStructureNV* pAccelerationStructures, VkQueryType queryType, VkQueryPool queryPool, uint32_t firstQuery);
      //VkResult vkCompileDeferredNV(VkDevice device, VkPipeline pipeline, uint32_t shader);
      
      //delegate definitions
      public delegate Result CreateAccelerationStructureNVDelegate(Device device, ref AccelerationStructureCreateInfoNV pCreateInfo, ref AllocationCallbacks pAllocator, ref AccelerationStructureNV pAccelerationStructure);
      public delegate void DestroyAccelerationStructureNVDelegate(Device device, AccelerationStructureNV accelerationStructure, ref AllocationCallbacks pAllocator);
      public delegate void GetAccelerationStructureMemoryRequirementsNVDelegate(Device device, ref AccelerationStructureMemoryRequirementsInfoNV pInfo, ref MemoryRequirements2 pMemoryRequirements);
      public delegate Result BindAccelerationStructureMemoryNVDelegate(Device device, UInt32 bindInfoCount, ref BindAccelerationStructureMemoryInfoNV pBindInfos);
      public delegate void CmdBuildAccelerationStructureNVDelegate(CommandBuffer commandBuffer, ref AccelerationStructureInfoNV pInfo, Buffer instanceData, DeviceSize instanceOffset, Bool32 update, AccelerationStructureNV dst, AccelerationStructureNV src, Buffer scratch, DeviceSize scratchOffset);
      public delegate void CmdCopyAccelerationStructureNVDelegate(CommandBuffer commandBuffer, AccelerationStructureNV dst, AccelerationStructureNV src, CopyAccelerationStructureModeNV mode);
      public delegate void CmdTraceRaysNVDelegate(CommandBuffer commandBuffer, Buffer raygenShaderBindingTableBuffer, DeviceSize raygenShaderBindingOffset, Buffer missShaderBindingTableBuffer, DeviceSize missShaderBindingOffset, DeviceSize missShaderBindingStride, Buffer hitShaderBindingTableBuffer, DeviceSize hitShaderBindingOffset, DeviceSize hitShaderBindingStride, Buffer callableShaderBindingTableBuffer, DeviceSize callableShaderBindingOffset, DeviceSize callableShaderBindingStride, UInt32 width, UInt32 height, UInt32 depth);
      public delegate Result CreateRayTracingPipelinesNVDelegate(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ref RayTracingPipelineCreateInfoNV pCreateInfos, ref AllocationCallbacks pAllocator, ref Pipeline pPipelines);
      public delegate Result GetRayTracingShaderGroupHandlesNVDelegate(Device device, Pipeline pipeline, UInt32 firstGroup, UInt32 groupCount, UInt32 dataSize, IntPtr pData);
      public delegate Result GetAccelerationStructureHandleNVDelegate(Device device, AccelerationStructureNV accelerationStructure, UInt32 dataSize, IntPtr pData);
      public delegate void CmdWriteAccelerationStructuresPropertiesNVDelegate(CommandBuffer commandBuffer, UInt32 accelerationStructureCount, ref AccelerationStructureNV pAccelerationStructures, QueryType queryType, QueryPool queryPool, UInt32 firstQuery);
      public delegate Result CompileDeferredNVDelegate(Device device, Pipeline pipeline, UInt32 shader);
      
      //delegate instances
      public static CreateAccelerationStructureNVDelegate CreateAccelerationStructureNV;
      public static DestroyAccelerationStructureNVDelegate DestroyAccelerationStructureNV;
      public static GetAccelerationStructureMemoryRequirementsNVDelegate GetAccelerationStructureMemoryRequirementsNV;
      public static BindAccelerationStructureMemoryNVDelegate BindAccelerationStructureMemoryNV;
      public static CmdBuildAccelerationStructureNVDelegate CmdBuildAccelerationStructureNV;
      public static CmdCopyAccelerationStructureNVDelegate CmdCopyAccelerationStructureNV;
      public static CmdTraceRaysNVDelegate CmdTraceRaysNV;
      public static CreateRayTracingPipelinesNVDelegate CreateRayTracingPipelinesNV;
      public static GetRayTracingShaderGroupHandlesNVDelegate GetRayTracingShaderGroupHandlesNV;
      public static GetAccelerationStructureHandleNVDelegate GetAccelerationStructureHandleNV;
      public static CmdWriteAccelerationStructuresPropertiesNVDelegate CmdWriteAccelerationStructuresPropertiesNV;
      public static CompileDeferredNVDelegate CompileDeferredNV;
      #endregion

      #region interop
      public static class VK_NV_ray_tracing
      {
         public static void init(VK.Device device)
         {
            VK.CreateAccelerationStructureNV = ExternalFunction.getDeviceFunction<VK.CreateAccelerationStructureNVDelegate>(device, "vkCreateAccelerationStructureNV");
            VK.DestroyAccelerationStructureNV = ExternalFunction.getDeviceFunction<VK.DestroyAccelerationStructureNVDelegate>(device, "vkDestroyAccelerationStructureNV");
            VK.GetAccelerationStructureMemoryRequirementsNV = ExternalFunction.getDeviceFunction<VK.GetAccelerationStructureMemoryRequirementsNVDelegate>(device, "vkGetAccelerationStructureMemoryRequirementsNV");
            VK.BindAccelerationStructureMemoryNV = ExternalFunction.getDeviceFunction<VK.BindAccelerationStructureMemoryNVDelegate>(device, "vkBindAccelerationStructureMemoryNV");
            VK.CmdBuildAccelerationStructureNV = ExternalFunction.getDeviceFunction<VK.CmdBuildAccelerationStructureNVDelegate>(device, "vkCmdBuildAccelerationStructureNV");
            VK.CmdCopyAccelerationStructureNV = ExternalFunction.getDeviceFunction<VK.CmdCopyAccelerationStructureNVDelegate>(device, "vkCmdCopyAccelerationStructureNV");
            VK.CmdTraceRaysNV = ExternalFunction.getDeviceFunction<VK.CmdTraceRaysNVDelegate>(device, "vkCmdTraceRaysNV");
            VK.CreateRayTracingPipelinesNV = ExternalFunction.getDeviceFunction<VK.CreateRayTracingPipelinesNVDelegate>(device, "vkCreateRayTracingPipelinesNV");
            VK.GetRayTracingShaderGroupHandlesNV = ExternalFunction.getDeviceFunction<VK.GetRayTracingShaderGroupHandlesNVDelegate>(device, "vkGetRayTracingShaderGroupHandlesNV");
            VK.GetAccelerationStructureHandleNV = ExternalFunction.getDeviceFunction<VK.GetAccelerationStructureHandleNVDelegate>(device, "vkGetAccelerationStructureHandleNV");
            VK.CmdWriteAccelerationStructuresPropertiesNV = ExternalFunction.getDeviceFunction<VK.CmdWriteAccelerationStructuresPropertiesNVDelegate>(device, "vkCmdWriteAccelerationStructuresPropertiesNV");
            VK.CompileDeferredNV = ExternalFunction.getDeviceFunction<VK.CompileDeferredNVDelegate>(device, "vkCompileDeferredNV");
         }
      }
      #endregion
   }
}
