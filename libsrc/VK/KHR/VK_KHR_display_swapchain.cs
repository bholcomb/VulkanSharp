using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_display_swapchain = "VK_KHR_display_swapchain";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPresentInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Rect2D srcRect;  //Rectangle within the presentable image to read pixel data from when presenting to the display. 
         public Rect2D dstRect;  //Rectangle within the current display mode's visible region to display srcRectangle in. 
         public Bool32 persistent;  //For smart displays, use buffered mode.  If the display properties member "persistentMode" is VK_FALSE, this member must always be VK_FALSE. 
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateSharedSwapchainsKHR(VkDevice device, uint32_t swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchains);
      
      //delegate definitions
      public delegate Result CreateSharedSwapchainsKHRDelegate(Device device, UInt32 swapchainCount, ref SwapchainCreateInfoKHR pCreateInfos, ref AllocationCallbacks pAllocator, ref SwapchainKHR pSwapchains);
      
      //delegate instances
      public static CreateSharedSwapchainsKHRDelegate CreateSharedSwapchainsKHR;
      #endregion

      #region interop
      public static class VK_KHR_display_swapchain
      {
         public static void init(VK.Device device)
         {
            VK.CreateSharedSwapchainsKHR = ExternalFunction.getDeviceFunction<VK.CreateSharedSwapchainsKHRDelegate>(device, "vkCreateSharedSwapchainsKHR");
         }
      }
      #endregion
   }
}
