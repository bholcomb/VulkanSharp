using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_GGP_frame_token = "VK_GGP_frame_token";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentFrameTokenGGP 
      {
         public StructureType sType;
         public IntPtr pNext;
         public IntPtr frameToken;
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
