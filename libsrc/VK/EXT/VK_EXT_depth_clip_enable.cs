using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_depth_clip_enable = "VK_EXT_depth_clip_enable";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDepthClipEnableFeaturesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 depthClipEnable;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationDepthClipStateCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public Bool32 depthClipEnable;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
