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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum XlibSurfaceCreateFlagsKHR : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct XlibSurfaceCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public XlibSurfaceCreateFlagsKHR flags;          
         public IntPtr/*Display**/ dpy;          
         public IntPtr/*Window*/ window;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateXlibSurfaceKHR(VkInstance instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      //VkBool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(VkPhysicalDevice physicalDevice, uint32_t queueFamilyIndex, Display* dpy, VisualID visualID);
      
      //delegate definitions
      public delegate Result CreateXlibSurfaceKHRDelegate(Instance instance, ref XlibSurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      public delegate Bool32 GetPhysicalDeviceXlibPresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID);
      
      //delegate instances
      public static CreateXlibSurfaceKHRDelegate CreateXlibSurfaceKHR;
      public static GetPhysicalDeviceXlibPresentationSupportKHRDelegate GetPhysicalDeviceXlibPresentationSupportKHR;
      #endregion

      #region interop
      public static class VK_KHR_xlib_surface
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
