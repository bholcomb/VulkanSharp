using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_MVK_macos_surface = "VK_MVK_macos_surface";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum MacOSSurfaceCreateFlagsMVK : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MacOSSurfaceCreateInfoMVK 
      {
         public StructureType sType;
         public void pNext;
         public MacOSSurfaceCreateFlagsMVK flags;
         public void pView;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateMacOSSurfaceMVK(VkInstance instance, VkMacOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateMacOSSurfaceMVKDelegate(Instance instance, ref MacOSSurfaceCreateInfoMVK pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateMacOSSurfaceMVKDelegate CreateMacOSSurfaceMVK;
      #endregion

      #region interop
      public static class VK_MVK_macos_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateMacOSSurfaceMVK = ExternalFunction.getInstanceFunction<VK.CreateMacOSSurfaceMVKDelegate>(instance, "vkCreateMacOSSurfaceMVK");
         }
      }
      #endregion
   }
}
