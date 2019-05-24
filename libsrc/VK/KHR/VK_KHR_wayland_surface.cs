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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum WaylandSurfaceCreateFlagsKHR : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct WaylandSurfaceCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public WaylandSurfaceCreateFlagsKHR flags;          
         public IntPtr/*wl_display**/ display;          
         public IntPtr/*wl_surface**/ surface;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateWaylandSurfaceKHR(VkInstance instance, VkWaylandSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      //VkBool32 vkGetPhysicalDeviceWaylandPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint32_t queueFamilyIndex, wl_display* display);
      
      //delegate definitions
      public delegate Result CreateWaylandSurfaceKHRDelegate(Instance instance, ref WaylandSurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      public delegate Bool32 GetPhysicalDeviceWaylandPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr display);
      
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
