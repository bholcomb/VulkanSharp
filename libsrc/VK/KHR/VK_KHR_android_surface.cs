using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_android_surface = "VK_KHR_android_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidSurfaceCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr window;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateAndroidSurfaceKHR(VkInstance  instance, const VkAndroidSurfaceCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateAndroidSurfaceKHRDelegate(Instance instance, ref AndroidSurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateAndroidSurfaceKHRDelegate CreateAndroidSurfaceKHR;
      #endregion

      #region interop
      public static class VK_KHR_android_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateAndroidSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateAndroidSurfaceKHRDelegate>(instance, "vkCreateAndroidSurfaceKHR");
         }
      }
      #endregion
   }
}
