using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_shader_float_controls = "VK_KHR_shader_float_controls";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFloatControlsPropertiesKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 separateDenormSettings;
         public Bool32 separateRoundingModeSettings;
         public Bool32 shaderSignedZeroInfNanPreserveFloat16;
         public Bool32 shaderSignedZeroInfNanPreserveFloat32;
         public Bool32 shaderSignedZeroInfNanPreserveFloat64;
         public Bool32 shaderDenormPreserveFloat16;
         public Bool32 shaderDenormPreserveFloat32;
         public Bool32 shaderDenormPreserveFloat64;
         public Bool32 shaderDenormFlushToZeroFloat16;
         public Bool32 shaderDenormFlushToZeroFloat32;
         public Bool32 shaderDenormFlushToZeroFloat64;
         public Bool32 shaderRoundingModeRTEFloat16;
         public Bool32 shaderRoundingModeRTEFloat32;
         public Bool32 shaderRoundingModeRTEFloat64;
         public Bool32 shaderRoundingModeRTZFloat32;
         public Bool32 shaderRoundingModeRTZFloat64;
         public Bool32 shaderRoundingModeRTZFloat16;
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
