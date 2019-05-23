using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_push_descriptor = "VK_KHR_push_descriptor";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevicePushDescriptorPropertiesKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 maxPushDescriptors;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdPushDescriptorSetKHR(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint32_t set, uint32_t descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites);
      //void vkCmdPushDescriptorSetWithTemplateKHR(VkCommandBuffer commandBuffer, VkDescriptorUpdateTemplate descriptorUpdateTemplate, VkPipelineLayout layout, uint32_t set, void* pData);
      
      //delegate definitions
      public delegate void CmdPushDescriptorSetKHRDelegate(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 set, UInt32 descriptorWriteCount, ref WriteDescriptorSet pDescriptorWrites);
      public delegate void CmdPushDescriptorSetWithTemplateKHRDelegate(CommandBuffer commandBuffer, DescriptorUpdateTemplate descriptorUpdateTemplate, PipelineLayout layout, UInt32 set, ref void pData);
      
      //delegate instances
      public static CmdPushDescriptorSetKHRDelegate CmdPushDescriptorSetKHR;
      public static CmdPushDescriptorSetWithTemplateKHRDelegate CmdPushDescriptorSetWithTemplateKHR;
      #endregion

      #region interop
      public static class VK_KHR_push_descriptor
      {
         public static void init(VK.Device device)
         {
            VK.CmdPushDescriptorSetKHR = ExternalFunction.getDeviceFunction<VK.CmdPushDescriptorSetKHRDelegate>(device, "vkCmdPushDescriptorSetKHR");
            VK.CmdPushDescriptorSetWithTemplateKHR = ExternalFunction.getDeviceFunction<VK.CmdPushDescriptorSetWithTemplateKHRDelegate>(device, "vkCmdPushDescriptorSetWithTemplateKHR");
         }
      }
      #endregion
   }
}
