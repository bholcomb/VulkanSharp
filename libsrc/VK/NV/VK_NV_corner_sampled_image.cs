using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_corner_sampled_image = "VK_NV_corner_sampled_image";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceCornerSampledImageFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 cornerSampledImage;          
      };
      
      
      #endregion

      //no functions
   }
}
