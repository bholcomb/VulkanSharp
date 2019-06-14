using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NVX_device_generated_commands = "VK_NVX_device_generated_commands";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct ObjectTableNVX { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct IndirectCommandsLayoutNVX { public UInt64 native; }
      #endregion 
      

      #region enums
      public enum IndirectCommandsTokenTypeNVX : int
      {  
         PipelineNvx = 0,
         DescriptorSetNvx = 1,
         IndexBufferNvx = 2,
         VertexBufferNvx = 3,
         PushConstantNvx = 4,
         DrawIndexedNvx = 5,
         DrawNvx = 6,
         DispatchNvx = 7,
      };
      
      public enum ObjectEntryTypeNVX : int
      {  
         DescriptorSetNvx = 0,
         PipelineNvx = 1,
         IndexBufferNvx = 2,
         VertexBufferNvx = 3,
         PushConstantNvx = 4,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum IndirectCommandsLayoutUsageFlagsNVX : int
      {  
         UnorderedSequencesBitNvx = 1 << 0,
         SparseSequencesBitNvx = 1 << 1,
         EmptyExecutionsBitNvx = 1 << 2,
         IndexedSequencesBitNvx = 1 << 3,
      };
      
      [Flags]
      public enum ObjectEntryUsageFlagsNVX : int
      {  
         GraphicsBitNvx = 1 << 0,
         ComputeBitNvx = 1 << 1,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGeneratedCommandsFeaturesNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 computeBindingPointSupport;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGeneratedCommandsLimitsNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxIndirectCommandsLayoutTokenCount;          
         public UInt32 maxObjectEntryCounts;          
         public UInt32 minSequenceCountBufferOffsetAlignment;          
         public UInt32 minSequenceIndexBufferOffsetAlignment;          
         public UInt32 minCommandsTokenBufferOffsetAlignment;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct IndirectCommandsTokenNVX 
      {
         public IndirectCommandsTokenTypeNVX tokenType;          
         public Buffer buffer;  //buffer containing tableEntries and additional data for indirectCommands 
         public DeviceSize offset;  //offset from the base address of the buffer 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct IndirectCommandsLayoutTokenNVX 
      {
         public IndirectCommandsTokenTypeNVX tokenType;          
         public UInt32 bindingUnit;  //Binding unit for vertex attribute / descriptor set, offset for pushconstants 
         public UInt32 dynamicCount;  //Number of variable dynamic values for descriptor set / push constants 
         public UInt32 divisor;  //Rate the which the array is advanced per element (must be power of 2, minimum 1) 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct IndirectCommandsLayoutCreateInfoNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public PipelineBindPoint pipelineBindPoint;          
         public IndirectCommandsLayoutUsageFlagsNVX flags;          
         public UInt32 tokenCount;          
         public IndirectCommandsLayoutTokenNVX* pTokens;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct CmdProcessCommandsInfoNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public ObjectTableNVX objectTable;          
         public IndirectCommandsLayoutNVX indirectCommandsLayout;          
         public UInt32 indirectCommandsTokenCount;          
         public IndirectCommandsTokenNVX* pIndirectCommandsTokens;          
         public UInt32 maxSequencesCount;          
         public CommandBuffer targetCommandBuffer;          
         public Buffer sequencesCountBuffer;          
         public DeviceSize sequencesCountOffset;          
         public Buffer sequencesIndexBuffer;          
         public DeviceSize sequencesIndexOffset;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CmdReserveSpaceForCommandsInfoNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public ObjectTableNVX objectTable;          
         public IndirectCommandsLayoutNVX indirectCommandsLayout;          
         public UInt32 maxSequencesCount;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ObjectTableCreateInfoNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 objectCount;          
         public ObjectEntryTypeNVX* pObjectEntryTypes;          
         public UInt32* pObjectEntryCounts;          
         public ObjectEntryUsageFlagsNVX* pObjectEntryUsageFlags;          
         public UInt32 maxUniformBuffersPerDescriptor;          
         public UInt32 maxStorageBuffersPerDescriptor;          
         public UInt32 maxStorageImagesPerDescriptor;          
         public UInt32 maxSampledImagesPerDescriptor;          
         public UInt32 maxPipelineLayouts;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTableEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTablePipelineEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
         public Pipeline pipeline;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTableDescriptorSetEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
         public PipelineLayout pipelineLayout;          
         public DescriptorSet descriptorSet;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTableVertexBufferEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
         public Buffer buffer;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTableIndexBufferEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
         public Buffer buffer;          
         public IndexType indexType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ObjectTablePushConstantEntryNVX 
      {
         public ObjectEntryTypeNVX type;          
         public ObjectEntryUsageFlagsNVX flags;          
         public PipelineLayout pipelineLayout;          
         public ShaderStageFlags stageFlags;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdProcessCommandsNVX(VkCommandBuffer commandBuffer, VkCmdProcessCommandsInfoNVX* pProcessCommandsInfo);
      //void vkCmdReserveSpaceForCommandsNVX(VkCommandBuffer commandBuffer, VkCmdReserveSpaceForCommandsInfoNVX* pReserveSpaceInfo);
      //VkResult vkCreateIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, VkIndirectCommandsLayoutNVX* pIndirectCommandsLayout);
      //void vkDestroyIndirectCommandsLayoutNVX(VkDevice device, VkIndirectCommandsLayoutNVX indirectCommandsLayout, VkAllocationCallbacks* pAllocator);
      //VkResult vkCreateObjectTableNVX(VkDevice device, VkObjectTableCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, VkObjectTableNVX* pObjectTable);
      //void vkDestroyObjectTableNVX(VkDevice device, VkObjectTableNVX objectTable, VkAllocationCallbacks* pAllocator);
      //VkResult vkRegisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint32_t objectCount, VkObjectTableEntryNVX ppObjectTableEntries, uint32_t* pObjectIndices);
      //VkResult vkUnregisterObjectsNVX(VkDevice device, VkObjectTableNVX objectTable, uint32_t objectCount, VkObjectEntryTypeNVX* pObjectEntryTypes, uint32_t* pObjectIndices);
      //void vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX(VkPhysicalDevice physicalDevice, VkDeviceGeneratedCommandsFeaturesNVX* pFeatures, VkDeviceGeneratedCommandsLimitsNVX* pLimits);
      
      //delegate definitions
      public delegate void CmdProcessCommandsNVXDelegate(CommandBuffer commandBuffer, ref CmdProcessCommandsInfoNVX pProcessCommandsInfo);
      public delegate void CmdReserveSpaceForCommandsNVXDelegate(CommandBuffer commandBuffer, ref CmdReserveSpaceForCommandsInfoNVX pReserveSpaceInfo);
      public delegate Result CreateIndirectCommandsLayoutNVXDelegate(Device device, ref IndirectCommandsLayoutCreateInfoNVX pCreateInfo, AllocationCallbacks pAllocator, ref IndirectCommandsLayoutNVX pIndirectCommandsLayout);
      public delegate void DestroyIndirectCommandsLayoutNVXDelegate(Device device, IndirectCommandsLayoutNVX indirectCommandsLayout, AllocationCallbacks pAllocator);
      public delegate Result CreateObjectTableNVXDelegate(Device device, ref ObjectTableCreateInfoNVX pCreateInfo, AllocationCallbacks pAllocator, ref ObjectTableNVX pObjectTable);
      public delegate void DestroyObjectTableNVXDelegate(Device device, ObjectTableNVX objectTable, AllocationCallbacks pAllocator);
      public delegate Result RegisterObjectsNVXDelegate(Device device, ObjectTableNVX objectTable, UInt32 objectCount, ObjectTableEntryNVX ppObjectTableEntries, ref UInt32 pObjectIndices);
      public delegate Result UnregisterObjectsNVXDelegate(Device device, ObjectTableNVX objectTable, UInt32 objectCount, ref ObjectEntryTypeNVX pObjectEntryTypes, ref UInt32 pObjectIndices);
      public delegate void GetPhysicalDeviceGeneratedCommandsPropertiesNVXDelegate(PhysicalDevice physicalDevice, ref DeviceGeneratedCommandsFeaturesNVX pFeatures, ref DeviceGeneratedCommandsLimitsNVX pLimits);
      
      //delegate instances
      public static CmdProcessCommandsNVXDelegate CmdProcessCommandsNVX;
      public static CmdReserveSpaceForCommandsNVXDelegate CmdReserveSpaceForCommandsNVX;
      public static CreateIndirectCommandsLayoutNVXDelegate CreateIndirectCommandsLayoutNVX;
      public static DestroyIndirectCommandsLayoutNVXDelegate DestroyIndirectCommandsLayoutNVX;
      public static CreateObjectTableNVXDelegate CreateObjectTableNVX;
      public static DestroyObjectTableNVXDelegate DestroyObjectTableNVX;
      public static RegisterObjectsNVXDelegate RegisterObjectsNVX;
      public static UnregisterObjectsNVXDelegate UnregisterObjectsNVX;
      public static GetPhysicalDeviceGeneratedCommandsPropertiesNVXDelegate GetPhysicalDeviceGeneratedCommandsPropertiesNVX;
      #endregion

      #region interop
      public static class NVX_device_generated_commands
      {
         public static void init(VK.Device device)
         {
            VK.CmdProcessCommandsNVX = ExternalFunction.getDeviceFunction<VK.CmdProcessCommandsNVXDelegate>(device, "vkCmdProcessCommandsNVX");
            VK.CmdReserveSpaceForCommandsNVX = ExternalFunction.getDeviceFunction<VK.CmdReserveSpaceForCommandsNVXDelegate>(device, "vkCmdReserveSpaceForCommandsNVX");
            VK.CreateIndirectCommandsLayoutNVX = ExternalFunction.getDeviceFunction<VK.CreateIndirectCommandsLayoutNVXDelegate>(device, "vkCreateIndirectCommandsLayoutNVX");
            VK.DestroyIndirectCommandsLayoutNVX = ExternalFunction.getDeviceFunction<VK.DestroyIndirectCommandsLayoutNVXDelegate>(device, "vkDestroyIndirectCommandsLayoutNVX");
            VK.CreateObjectTableNVX = ExternalFunction.getDeviceFunction<VK.CreateObjectTableNVXDelegate>(device, "vkCreateObjectTableNVX");
            VK.DestroyObjectTableNVX = ExternalFunction.getDeviceFunction<VK.DestroyObjectTableNVXDelegate>(device, "vkDestroyObjectTableNVX");
            VK.RegisterObjectsNVX = ExternalFunction.getDeviceFunction<VK.RegisterObjectsNVXDelegate>(device, "vkRegisterObjectsNVX");
            VK.UnregisterObjectsNVX = ExternalFunction.getDeviceFunction<VK.UnregisterObjectsNVXDelegate>(device, "vkUnregisterObjectsNVX");
            VK.GetPhysicalDeviceGeneratedCommandsPropertiesNVX = ExternalFunction.getDeviceFunction<VK.GetPhysicalDeviceGeneratedCommandsPropertiesNVXDelegate>(device, "vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX");
         }
      }
      #endregion
   }
}
