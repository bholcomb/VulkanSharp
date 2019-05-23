using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_clip_space_w_scaling = "VK_NV_clip_space_w_scaling";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ViewportWScalingNV 
      {
         public float xcoeff;          
         public float ycoeff;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineViewportWScalingStateCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 viewportWScalingEnable;          
         public UInt32 viewportCount;          
         public ViewportWScalingNV* pViewportWScalings;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdSetViewportWScalingNV(VkCommandBuffer commandBuffer, uint32_t firstViewport, uint32_t viewportCount, VkViewportWScalingNV* pViewportWScalings);
      
      //delegate definitions
      public delegate void CmdSetViewportWScalingNVDelegate(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ref ViewportWScalingNV pViewportWScalings);
      
      //delegate instances
      public static CmdSetViewportWScalingNVDelegate CmdSetViewportWScalingNV;
      #endregion

      #region interop
      public static class VK_NV_clip_space_w_scaling
      {
         public static void init(VK.Device device)
         {
            VK.CmdSetViewportWScalingNV = ExternalFunction.getDeviceFunction<VK.CmdSetViewportWScalingNVDelegate>(device, "vkCmdSetViewportWScalingNV");
         }
      }
      #endregion
   }
}
