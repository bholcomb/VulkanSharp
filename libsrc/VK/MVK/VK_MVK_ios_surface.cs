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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum IOSSurfaceCreateFlagsMVK : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct IOSSurfaceCreateInfoMVK 
      {
         public StructureType type;          
         public IntPtr next;          
         public IOSSurfaceCreateFlagsMVK flags;          
         public IntPtr pView;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateIOSSurfaceMVK(VkInstance instance, VkIOSSurfaceCreateInfoMVK* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateIOSSurfaceMVKDelegate(Instance instance, ref IOSSurfaceCreateInfoMVK pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
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
