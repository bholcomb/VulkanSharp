using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_discard_rectangles = "VK_EXT_discard_rectangles";
   };
   
   public static partial class VK
   {
      #region enums
      public enum DiscardRectangleModeEXT : int
      {  
         InclusiveExt = 0,
         ExclusiveExt = 1,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDiscardRectanglePropertiesEXT 
      {
         public StructureType sType;
         public UInt32 maxDiscardRectangles;
         public IntPtr pNext;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineDiscardRectangleStateCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public DiscardRectangleModeEXT discardRectangleMode;
         public UInt32 discardRectangleCount;
         public Rect2D* pDiscardRectangles;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdSetDiscardRectangleEXT(VkCommandBuffer  commandBuffer, uint32_t  firstDiscardRectangle, uint32_t  discardRectangleCount, const VkRect2D *  pDiscardRectangles);
      
      //delegate definitions
      public delegate void CmdSetDiscardRectangleEXTDelegate(CommandBuffer commandBuffer, UInt32 firstDiscardRectangle, UInt32 discardRectangleCount, ref Rect2D pDiscardRectangless);
      
      //delegate instances
      public static CmdSetDiscardRectangleEXTDelegate CmdSetDiscardRectangleEXT;
      #endregion

      #region interop
      public static class VK_EXT_discard_rectangles
      {
         public static void init(VK.Device device)
         {
            VK.CmdSetDiscardRectangleEXT = ExternalFunction.getDeviceFunction<VK.CmdSetDiscardRectangleEXTDelegate>(device, "vkCmdSetDiscardRectangleEXT");
         }
      }
      #endregion
   }
}
