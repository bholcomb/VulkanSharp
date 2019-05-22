using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_buffer_marker = "VK_AMD_buffer_marker";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdWriteBufferMarkerAMD(VkCommandBuffer  commandBuffer, VkPipelineStageFlagBits  pipelineStage, VkBuffer  dstBuffer, VkDeviceSize  dstOffset, uint32_t  marker);
      
      //delegate definitions
      public delegate void CmdWriteBufferMarkerAMDDelegate(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, Buffer dstBuffer, DeviceSize dstOffset, UInt32 markers);
      
      //delegate instances
      public static CmdWriteBufferMarkerAMDDelegate CmdWriteBufferMarkerAMD;
      #endregion

      #region interop
      public static class AMD_buffer_marker
      {
         public static void init(VK.Device device)
         {
            VK.CmdWriteBufferMarkerAMD = ExternalFunction.getDeviceFunction<VK.CmdWriteBufferMarkerAMDDelegate>(device, "vkCmdWriteBufferMarkerAMD");
         }
      }
      #endregion
   }
}
