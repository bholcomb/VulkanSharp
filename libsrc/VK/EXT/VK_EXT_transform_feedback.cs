using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_transform_feedback = "VK_EXT_transform_feedback";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum PipelineRasterizationStateStreamCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceTransformFeedbackFeaturesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 transformFeedback;          
         public Bool32 geometryStreams;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceTransformFeedbackPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxTransformFeedbackStreams;          
         public UInt32 maxTransformFeedbackBuffers;          
         public DeviceSize maxTransformFeedbackBufferSize;          
         public UInt32 maxTransformFeedbackStreamDataSize;          
         public UInt32 maxTransformFeedbackBufferDataSize;          
         public UInt32 maxTransformFeedbackBufferDataStride;          
         public Bool32 transformFeedbackQueries;          
         public Bool32 transformFeedbackStreamsLinesTriangles;          
         public Bool32 transformFeedbackRasterizationStreamSelect;          
         public Bool32 transformFeedbackDraw;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationStateStreamCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public PipelineRasterizationStateStreamCreateFlagsEXT flags;          
         public UInt32 rasterizationStream;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdBindTransformFeedbackBuffersEXT(VkCommandBuffer commandBuffer, uint32_t firstBinding, uint32_t bindingCount, VkBuffer* pBuffers, VkDeviceSize* pOffsets, VkDeviceSize* pSizes);
      //void vkCmdBeginTransformFeedbackEXT(VkCommandBuffer commandBuffer, uint32_t firstCounterBuffer, uint32_t counterBufferCount, VkBuffer* pCounterBuffers, VkDeviceSize* pCounterBufferOffsets);
      //void vkCmdEndTransformFeedbackEXT(VkCommandBuffer commandBuffer, uint32_t firstCounterBuffer, uint32_t counterBufferCount, VkBuffer* pCounterBuffers, VkDeviceSize* pCounterBufferOffsets);
      //void vkCmdBeginQueryIndexedEXT(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query, VkQueryControlFlags flags, uint32_t index);
      //void vkCmdEndQueryIndexedEXT(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query, uint32_t index);
      //void vkCmdDrawIndirectByteCountEXT(VkCommandBuffer commandBuffer, uint32_t instanceCount, uint32_t firstInstance, VkBuffer counterBuffer, VkDeviceSize counterBufferOffset, uint32_t counterOffset, uint32_t vertexStride);
      
      //delegate definitions
      public delegate void CmdBindTransformFeedbackBuffersEXTDelegate(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, ref Buffer pBuffers, ref DeviceSize pOffsets, ref DeviceSize pSizes);
      public delegate void CmdBeginTransformFeedbackEXTDelegate(CommandBuffer commandBuffer, UInt32 firstCounterBuffer, UInt32 counterBufferCount, ref Buffer pCounterBuffers, ref DeviceSize pCounterBufferOffsets);
      public delegate void CmdEndTransformFeedbackEXTDelegate(CommandBuffer commandBuffer, UInt32 firstCounterBuffer, UInt32 counterBufferCount, ref Buffer pCounterBuffers, ref DeviceSize pCounterBufferOffsets);
      public delegate void CmdBeginQueryIndexedEXTDelegate(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags, UInt32 index);
      public delegate void CmdEndQueryIndexedEXTDelegate(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, UInt32 index);
      public delegate void CmdDrawIndirectByteCountEXTDelegate(CommandBuffer commandBuffer, UInt32 instanceCount, UInt32 firstInstance, Buffer counterBuffer, DeviceSize counterBufferOffset, UInt32 counterOffset, UInt32 vertexStride);
      
      //delegate instances
      public static CmdBindTransformFeedbackBuffersEXTDelegate CmdBindTransformFeedbackBuffersEXT;
      public static CmdBeginTransformFeedbackEXTDelegate CmdBeginTransformFeedbackEXT;
      public static CmdEndTransformFeedbackEXTDelegate CmdEndTransformFeedbackEXT;
      public static CmdBeginQueryIndexedEXTDelegate CmdBeginQueryIndexedEXT;
      public static CmdEndQueryIndexedEXTDelegate CmdEndQueryIndexedEXT;
      public static CmdDrawIndirectByteCountEXTDelegate CmdDrawIndirectByteCountEXT;
      #endregion

      #region interop
      public static class VK_EXT_transform_feedback
      {
         public static void init(VK.Device device)
         {
            VK.CmdBindTransformFeedbackBuffersEXT = ExternalFunction.getDeviceFunction<VK.CmdBindTransformFeedbackBuffersEXTDelegate>(device, "vkCmdBindTransformFeedbackBuffersEXT");
            VK.CmdBeginTransformFeedbackEXT = ExternalFunction.getDeviceFunction<VK.CmdBeginTransformFeedbackEXTDelegate>(device, "vkCmdBeginTransformFeedbackEXT");
            VK.CmdEndTransformFeedbackEXT = ExternalFunction.getDeviceFunction<VK.CmdEndTransformFeedbackEXTDelegate>(device, "vkCmdEndTransformFeedbackEXT");
            VK.CmdBeginQueryIndexedEXT = ExternalFunction.getDeviceFunction<VK.CmdBeginQueryIndexedEXTDelegate>(device, "vkCmdBeginQueryIndexedEXT");
            VK.CmdEndQueryIndexedEXT = ExternalFunction.getDeviceFunction<VK.CmdEndQueryIndexedEXTDelegate>(device, "vkCmdEndQueryIndexedEXT");
            VK.CmdDrawIndirectByteCountEXT = ExternalFunction.getDeviceFunction<VK.CmdDrawIndirectByteCountEXTDelegate>(device, "vkCmdDrawIndirectByteCountEXT");
         }
      }
      #endregion
   }
}
