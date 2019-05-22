using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_surface_protected_capabilities = "VK_KHR_surface_protected_capabilities";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceProtectedCapabilitiesKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 supportsProtected;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
