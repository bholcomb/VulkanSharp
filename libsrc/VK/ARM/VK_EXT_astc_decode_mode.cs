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
      #region enums
      #endregion

      #region flags
      #endregion

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

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
