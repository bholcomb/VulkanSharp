using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_shader_atomic_int64 = "VK_KHR_shader_atomic_int64";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShaderAtomicInt64FeaturesKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 shaderBufferInt64Atomics;          
         public Bool32 shaderSharedInt64Atomics;          
      };
      
      
      #endregion

      //no functions
   }
}
