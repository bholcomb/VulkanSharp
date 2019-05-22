using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_FUCHSIA_imagepipe_surface = "VK_FUCHSIA_imagepipe_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImagePipeSurfaceCreateInfoFUCHSIA 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr imagePipeHandle;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateImagePipeSurfaceFUCHSIA(VkInstance  instance, const VkImagePipeSurfaceCreateInfoFUCHSIA *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateImagePipeSurfaceFUCHSIADelegate(Instance instance, ref ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateImagePipeSurfaceFUCHSIADelegate CreateImagePipeSurfaceFUCHSIA;
      #endregion

      #region interop
      public static class VK_FUCHSIA_imagepipe_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateImagePipeSurfaceFUCHSIA = ExternalFunction.getInstanceFunction<VK.CreateImagePipeSurfaceFUCHSIADelegate>(instance, "vkCreateImagePipeSurfaceFUCHSIA");
         }
      }
      #endregion
   }
}
