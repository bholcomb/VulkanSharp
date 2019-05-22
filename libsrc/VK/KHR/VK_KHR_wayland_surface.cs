using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_wayland_surface = "VK_KHR_wayland_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct WaylandSurfaceCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr display;
         public IntPtr surface;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateWaylandSurfaceKHR(VkInstance  instance, const VkWaylandSurfaceCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      //VkBool32 vkGetPhysicalDeviceWaylandPresentationSupportKHR(VkPhysicalDevice  physicalDevice, uint32_t  queueFamilyIndex, struct wl_display *  display);
      
      //delegate definitions
      public delegate Result CreateWaylandSurfaceKHRDelegate(Instance instance, ref WaylandSurfaceCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      public delegate Bool32 GetPhysicalDeviceWaylandPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr displays);
      
      //delegate instances
      public static CreateWaylandSurfaceKHRDelegate CreateWaylandSurfaceKHR;
      public static GetPhysicalDeviceWaylandPresentationSupportKHRDelegate GetPhysicalDeviceWaylandPresentationSupportKHR;
      #endregion

      #region interop
      public static class KHR_wayland_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateWaylandSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateWaylandSurfaceKHRDelegate>(instance, "vkCreateWaylandSurfaceKHR");
            VK.GetPhysicalDeviceWaylandPresentationSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceWaylandPresentationSupportKHRDelegate>(instance, "vkGetPhysicalDeviceWaylandPresentationSupportKHR");
         }
      }
      #endregion
   }
}
