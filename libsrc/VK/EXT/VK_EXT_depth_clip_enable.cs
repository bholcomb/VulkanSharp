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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum PipelineRasterizationDepthClipStateCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDepthClipEnableFeaturesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;  //Pointer to next structure 
         public Bool32 depthClipEnable;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationDepthClipStateCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineRasterizationDepthClipStateCreateFlagsEXT flags;          
         public Bool32 depthClipEnable;          
      };
      
      #endregion

      //no functions
   }
}
