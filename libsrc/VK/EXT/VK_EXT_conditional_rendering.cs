using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_conditional_rendering = "VK_EXT_conditional_rendering";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum ConditionalRenderingFlagsEXT : int
      {  
         ConditionalRenderingInvertedBitExt = 1 << 0,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ConditionalRenderingBeginInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public Buffer buffer;
         public DeviceSize offset;
         public ConditionalRenderingFlagsEXT flags;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceConditionalRenderingFeaturesEXT 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 conditionalRendering;
         public Bool32 inheritedConditionalRendering;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CommandBufferInheritanceConditionalRenderingInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 conditionalRenderingEnable;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdBeginConditionalRenderingEXT(VkCommandBuffer commandBuffer, VkConditionalRenderingBeginInfoEXT* pConditionalRenderingBegin);
      //void vkCmdEndConditionalRenderingEXT(VkCommandBuffer commandBuffer);
      
      //delegate definitions
      public delegate void CmdBeginConditionalRenderingEXTDelegate(CommandBuffer commandBuffer, ref ConditionalRenderingBeginInfoEXT pConditionalRenderingBegin);
      public delegate void CmdEndConditionalRenderingEXTDelegate(CommandBuffer commandBuffer);
      
      //delegate instances
      public static CmdBeginConditionalRenderingEXTDelegate CmdBeginConditionalRenderingEXT;
      public static CmdEndConditionalRenderingEXTDelegate CmdEndConditionalRenderingEXT;
      #endregion

      #region interop
      public static class VK_EXT_conditional_rendering
      {
         public static void init(VK.Device device)
         {
            VK.CmdBeginConditionalRenderingEXT = ExternalFunction.getDeviceFunction<VK.CmdBeginConditionalRenderingEXTDelegate>(device, "vkCmdBeginConditionalRenderingEXT");
            VK.CmdEndConditionalRenderingEXT = ExternalFunction.getDeviceFunction<VK.CmdEndConditionalRenderingEXTDelegate>(device, "vkCmdEndConditionalRenderingEXT");
         }
      }
      #endregion
   }
}
