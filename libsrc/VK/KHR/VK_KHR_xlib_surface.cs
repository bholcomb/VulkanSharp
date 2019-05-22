using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_xlib_surface = "VK_KHR_xlib_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct XlibSurfaceCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr dpy;
         public IntPtr window;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateXlibSurfaceKHR(VkInstance  instance, const VkXlibSurfaceCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      //VkBool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(VkPhysicalDevice  physicalDevice, uint32_t  queueFamilyIndex, Display *  dpy, VisualID  visualID);
      
      //delegate definitions
      public delegate Result CreateXlibSurfaceKHRDelegate(Instance instance, ref XlibSurfaceCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      public delegate Bool32 GetPhysicalDeviceXlibPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualIDs);
      
      //delegate instances
      public static CreateXlibSurfaceKHRDelegate CreateXlibSurfaceKHR;
      public static GetPhysicalDeviceXlibPresentationSupportKHRDelegate GetPhysicalDeviceXlibPresentationSupportKHR;
      #endregion

      #region interop
      public static class KHR_xlib_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateXlibSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateXlibSurfaceKHRDelegate>(instance, "vkCreateXlibSurfaceKHR");
            VK.GetPhysicalDeviceXlibPresentationSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceXlibPresentationSupportKHRDelegate>(instance, "vkGetPhysicalDeviceXlibPresentationSupportKHR");
         }
      }
      #endregion
   }
}
