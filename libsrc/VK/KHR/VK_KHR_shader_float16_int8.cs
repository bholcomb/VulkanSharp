using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_shader_float16_int8 = "VK_KHR_shader_float16_int8";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFloat16Int8FeaturesKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 shaderFloat16;          
         public Bool32 shaderInt8;          
      };
      
      #endregion

      //no functions
   }
}
