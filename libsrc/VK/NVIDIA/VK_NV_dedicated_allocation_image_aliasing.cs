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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDedicatedAllocationImageAliasingFeaturesNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 dedicatedAllocationImageAliasing;
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
