using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_xcb_surface = "VK_KHR_xcb_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct XcbSurfaceCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr connection;
         public IntPtr window;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateXcbSurfaceKHR(VkInstance  instance, const VkXcbSurfaceCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      //VkBool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(VkPhysicalDevice  physicalDevice, uint32_t  queueFamilyIndex, xcb_connection_t *  connection, xcb_visualid_t  visual_id);
      
      //delegate definitions
      public delegate Result CreateXcbSurfaceKHRDelegate(Instance instance, ref XcbSurfaceCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      public delegate Bool32 GetPhysicalDeviceXcbPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_ids);
      
      //delegate instances
      public static CreateXcbSurfaceKHRDelegate CreateXcbSurfaceKHR;
      public static GetPhysicalDeviceXcbPresentationSupportKHRDelegate GetPhysicalDeviceXcbPresentationSupportKHR;
      #endregion

      #region interop
      public static class KHR_xcb_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateXcbSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateXcbSurfaceKHRDelegate>(instance, "vkCreateXcbSurfaceKHR");
            VK.GetPhysicalDeviceXcbPresentationSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceXcbPresentationSupportKHRDelegate>(instance, "vkGetPhysicalDeviceXcbPresentationSupportKHR");
         }
      }
      #endregion
   }
}
