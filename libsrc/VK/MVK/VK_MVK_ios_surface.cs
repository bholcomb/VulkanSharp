using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_MVK_ios_surface = "VK_MVK_ios_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct IOSSurfaceCreateInfoMVK 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr pView;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateIOSSurfaceMVK(VkInstance  instance, const VkIOSSurfaceCreateInfoMVK *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateIOSSurfaceMVKDelegate(Instance instance, ref IOSSurfaceCreateInfoMVK pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateIOSSurfaceMVKDelegate CreateIOSSurfaceMVK;
      #endregion

      #region interop
      public static class VK_MVK_ios_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateIOSSurfaceMVK = ExternalFunction.getInstanceFunction<VK.CreateIOSSurfaceMVKDelegate>(instance, "vkCreateIOSSurfaceMVK");
         }
      }
      #endregion
   }
}
