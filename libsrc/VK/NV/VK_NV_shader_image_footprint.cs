using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_shader_image_footprint = "VK_NV_shader_image_footprint";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShaderImageFootprintFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 imageFootprint;          
      };
      
      
      #endregion

      //no functions
   }
}
