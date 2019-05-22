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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MacOSSurfaceCreateInfoMVK 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr pView;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateMacOSSurfaceMVK(VkInstance  instance, const VkMacOSSurfaceCreateInfoMVK *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateMacOSSurfaceMVKDelegate(Instance instance, ref MacOSSurfaceCreateInfoMVK pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateMacOSSurfaceMVKDelegate CreateMacOSSurfaceMVK;
      #endregion

      #region interop
      public static class MVK_macos_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateMacOSSurfaceMVK = ExternalFunction.getInstanceFunction<VK.CreateMacOSSurfaceMVKDelegate>(instance, "vkCreateMacOSSurfaceMVK");
         }
      }
      #endregion
   }
}
