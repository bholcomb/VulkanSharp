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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum XcbSurfaceCreateFlagsKHR : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct XcbSurfaceCreateInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public XcbSurfaceCreateFlagsKHR flags;          
         public xcb_connection_t* connection;          
         public xcb_window_t window;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateXcbSurfaceKHR(VkInstance instance, VkXcbSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      //VkBool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint32_t queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id);
      
      //delegate definitions
      public delegate Result CreateXcbSurfaceKHRDelegate(Instance instance, ref XcbSurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      public delegate Bool32 GetPhysicalDeviceXcbPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, ref xcb_connection_t connection, xcb_visualid_t visual_id);
      
      //delegate instances
      public static CreateXcbSurfaceKHRDelegate CreateXcbSurfaceKHR;
      public static GetPhysicalDeviceXcbPresentationSupportKHRDelegate GetPhysicalDeviceXcbPresentationSupportKHR;
      #endregion

      #region interop
      public static class VK_KHR_xcb_surface
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
