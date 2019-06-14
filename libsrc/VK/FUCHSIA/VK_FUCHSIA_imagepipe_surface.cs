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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum ImagePipeSurfaceCreateFlagsFUCHSIA : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImagePipeSurfaceCreateInfoFUCHSIA 
      {
         public StructureType type;          
         public IntPtr next;          
         public ImagePipeSurfaceCreateFlagsFUCHSIA flags;          
         public IntPtr/*zx_handle_t*/ imagePipeHandle;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateImagePipeSurfaceFUCHSIA(VkInstance instance, VkImagePipeSurfaceCreateInfoFUCHSIA* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateImagePipeSurfaceFUCHSIADelegate(Instance instance, ref ImagePipeSurfaceCreateInfoFUCHSIA pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateImagePipeSurfaceFUCHSIADelegate CreateImagePipeSurfaceFUCHSIA;
      #endregion

      #region interop
      public static class FUCHSIA_imagepipe_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateImagePipeSurfaceFUCHSIA = ExternalFunction.getInstanceFunction<VK.CreateImagePipeSurfaceFUCHSIADelegate>(instance, "vkCreateImagePipeSurfaceFUCHSIA");
         }
      }
      #endregion
   }
}
