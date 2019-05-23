using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_scissor_exclusive = "VK_NV_scissor_exclusive";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineViewportExclusiveScissorStateCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 exclusiveScissorCount;          
         public Rect2D* pExclusiveScissors;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExclusiveScissorFeaturesNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 exclusiveScissor;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdSetExclusiveScissorNV(VkCommandBuffer commandBuffer, uint32_t firstExclusiveScissor, uint32_t exclusiveScissorCount, VkRect2D* pExclusiveScissors);
      
      //delegate definitions
      public delegate void CmdSetExclusiveScissorNVDelegate(CommandBuffer commandBuffer, UInt32 firstExclusiveScissor, UInt32 exclusiveScissorCount, ref Rect2D pExclusiveScissors);
      
      //delegate instances
      public static CmdSetExclusiveScissorNVDelegate CmdSetExclusiveScissorNV;
      #endregion

      #region interop
      public static class VK_NV_scissor_exclusive
      {
         public static void init(VK.Device device)
         {
            VK.CmdSetExclusiveScissorNV = ExternalFunction.getDeviceFunction<VK.CmdSetExclusiveScissorNVDelegate>(device, "vkCmdSetExclusiveScissorNV");
         }
      }
      #endregion
   }
}
