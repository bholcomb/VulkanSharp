using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_fragment_coverage_to_color = "VK_NV_fragment_coverage_to_color";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineCoverageToColorStateCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public Bool32 coverageToColorEnable;
         public UInt32 coverageToColorLocation;
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
