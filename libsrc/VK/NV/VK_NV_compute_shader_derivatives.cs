using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_compute_shader_derivatives = "VK_NV_compute_shader_derivatives";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceComputeShaderDerivativesFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 computeDerivativeGroupQuads;          
         public Bool32 computeDerivativeGroupLinear;          
      };
      
      
      #endregion

      //no functions
   }
}
