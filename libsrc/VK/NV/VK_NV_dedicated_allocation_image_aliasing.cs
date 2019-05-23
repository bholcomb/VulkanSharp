using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_dedicated_allocation_image_aliasing = "VK_NV_dedicated_allocation_image_aliasing";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDedicatedAllocationImageAliasingFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 dedicatedAllocationImageAliasing;          
      };
      
      
      #endregion

      //no functions
   }
}
