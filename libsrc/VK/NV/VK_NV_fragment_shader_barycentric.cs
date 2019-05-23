using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_fragment_shader_barycentric = "VK_NV_fragment_shader_barycentric";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFragmentShaderBarycentricFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 fragmentShaderBarycentric;          
      };
      
      
      #endregion

      //no functions
   }
}
