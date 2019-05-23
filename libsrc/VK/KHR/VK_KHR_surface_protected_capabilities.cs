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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceProtectedCapabilitiesKHR 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 supportsProtected;
      };
      
      #endregion

      //no functions
   }
}
