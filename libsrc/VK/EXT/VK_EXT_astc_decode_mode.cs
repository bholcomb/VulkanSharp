using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_astc_decode_mode = "VK_EXT_astc_decode_mode";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageViewASTCDecodeModeEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Format decodeMode;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceASTCDecodeFeaturesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 decodeModeSharedExponent;          
      };
      
      #endregion

      //no functions
   }
}
