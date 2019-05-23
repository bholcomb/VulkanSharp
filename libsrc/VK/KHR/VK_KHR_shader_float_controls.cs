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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFloatControlsPropertiesKHR 
      {
         public StructureType type;          
         public IntPtr next;          
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
         public Bool32 shaderRoundingModeRTZFloat16;          
         public Bool32 shaderRoundingModeRTZFloat32;          
         public Bool32 shaderRoundingModeRTZFloat64;          
      };
      
      
      #endregion

      //no functions
   }
}
