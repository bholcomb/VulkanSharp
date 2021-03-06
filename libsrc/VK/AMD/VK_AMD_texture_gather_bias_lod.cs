using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_texture_gather_bias_lod = "VK_AMD_texture_gather_bias_lod";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct TextureLODGatherFormatPropertiesAMD 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 supportsTextureGatherLODBiasAMD;          
      };
      
      
      #endregion

      //no functions
   }
}
