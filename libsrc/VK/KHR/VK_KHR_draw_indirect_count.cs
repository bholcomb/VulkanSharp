using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_draw_indirect_count = "VK_KHR_draw_indirect_count";
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
      //void vkCmdDrawIndirectCountKHR(VkCommandBuffer  commandBuffer, VkBuffer  buffer, VkDeviceSize  offset, VkBuffer  countBuffer, VkDeviceSize  countBufferOffset, uint32_t  maxDrawCount, uint32_t  stride);
      //void vkCmdDrawIndexedIndirectCountKHR(VkCommandBuffer  commandBuffer, VkBuffer  buffer, VkDeviceSize  offset, VkBuffer  countBuffer, VkDeviceSize  countBufferOffset, uint32_t  maxDrawCount, uint32_t  stride);
      
      //delegate definitions
      public delegate void CmdDrawIndirectCountKHRDelegate(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, Buffer countBuffer, DeviceSize countBufferOffset, UInt32 maxDrawCount, UInt32 strides);
      public delegate void CmdDrawIndexedIndirectCountKHRDelegate(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, Buffer countBuffer, DeviceSize countBufferOffset, UInt32 maxDrawCount, UInt32 strides);
      
      //delegate instances
      public static CmdDrawIndirectCountKHRDelegate CmdDrawIndirectCountKHR;
      public static CmdDrawIndexedIndirectCountKHRDelegate CmdDrawIndexedIndirectCountKHR;
      #endregion

      #region interop
      public static class KHR_draw_indirect_count
      {
         public static void init(VK.Device device)
         {
            VK.CmdDrawIndirectCountKHR = ExternalFunction.getDeviceFunction<VK.CmdDrawIndirectCountKHRDelegate>(device, "vkCmdDrawIndirectCountKHR");
            VK.CmdDrawIndexedIndirectCountKHR = ExternalFunction.getDeviceFunction<VK.CmdDrawIndexedIndirectCountKHRDelegate>(device, "vkCmdDrawIndexedIndirectCountKHR");
         }
      }
      #endregion
   }
}
