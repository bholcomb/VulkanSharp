using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_win32_surface = "VK_KHR_win32_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Win32SurfaceCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr hinstance;
         public IntPtr hwnd;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateWin32SurfaceKHR(VkInstance  instance, const VkWin32SurfaceCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      //VkBool32 vkGetPhysicalDeviceWin32PresentationSupportKHR(VkPhysicalDevice  physicalDevice, uint32_t  queueFamilyIndex);
      
      //delegate definitions
      public delegate Result CreateWin32SurfaceKHRDelegate(Instance instance, ref Win32SurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      public delegate Bool32 GetPhysicalDeviceWin32PresentationSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndexs);
      
      //delegate instances
      public static CreateWin32SurfaceKHRDelegate CreateWin32SurfaceKHR;
      public static GetPhysicalDeviceWin32PresentationSupportKHRDelegate GetPhysicalDeviceWin32PresentationSupportKHR;
      #endregion

      #region interop
      public static class VK_KHR_win32_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateWin32SurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateWin32SurfaceKHRDelegate>(instance, "vkCreateWin32SurfaceKHR");
            VK.GetPhysicalDeviceWin32PresentationSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceWin32PresentationSupportKHRDelegate>(instance, "vkGetPhysicalDeviceWin32PresentationSupportKHR");
         }
      }
      #endregion
   }
}
