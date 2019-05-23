using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_GOOGLE_display_timing = "VK_GOOGLE_display_timing";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RefreshCycleDurationGOOGLE 
      {
         public UInt64 refreshDuration;  //Number of nanoseconds from the start of one refresh cycle to the next 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PastPresentationTimingGOOGLE 
      {
         public UInt32 presentID;  //Application-provided identifier, previously given to vkQueuePresentKHR 
         public UInt64 desiredPresentTime;  //Earliest time an image should have been presented, previously given to vkQueuePresentKHR 
         public UInt64 actualPresentTime;  //Time the image was actually displayed 
         public UInt64 earliestPresentTime;  //Earliest time the image could have been displayed 
         public UInt64 presentMargin;  //How early vkQueuePresentKHR was processed vs. how soon it needed to be and make earliestPresentTime 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentTimesInfoGOOGLE 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 swapchainCount;  //Copy of VkPresentInfoKHR::swapchainCount 
         public PresentTimeGOOGLE* pTimes;  //The earliest times to present images 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentTimeGOOGLE 
      {
         public UInt32 presentID;  //Application-provided identifier 
         public UInt64 desiredPresentTime;  //Earliest time an image should be presented 
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetRefreshCycleDurationGOOGLE(VkDevice device, VkSwapchainKHR swapchain, VkRefreshCycleDurationGOOGLE* pDisplayTimingProperties);
      //VkResult vkGetPastPresentationTimingGOOGLE(VkDevice device, VkSwapchainKHR swapchain, uint32_t* pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings);
      
      //delegate definitions
      public delegate Result GetRefreshCycleDurationGOOGLEDelegate(Device device, SwapchainKHR swapchain, ref RefreshCycleDurationGOOGLE pDisplayTimingProperties);
      public delegate Result GetPastPresentationTimingGOOGLEDelegate(Device device, SwapchainKHR swapchain, ref UInt32 pPresentationTimingCount, ref PastPresentationTimingGOOGLE pPresentationTimings);
      
      //delegate instances
      public static GetRefreshCycleDurationGOOGLEDelegate GetRefreshCycleDurationGOOGLE;
      public static GetPastPresentationTimingGOOGLEDelegate GetPastPresentationTimingGOOGLE;
      #endregion

      #region interop
      public static class VK_GOOGLE_display_timing
      {
         public static void init(VK.Device device)
         {
            VK.GetRefreshCycleDurationGOOGLE = ExternalFunction.getDeviceFunction<VK.GetRefreshCycleDurationGOOGLEDelegate>(device, "vkGetRefreshCycleDurationGOOGLE");
            VK.GetPastPresentationTimingGOOGLE = ExternalFunction.getDeviceFunction<VK.GetPastPresentationTimingGOOGLEDelegate>(device, "vkGetPastPresentationTimingGOOGLE");
         }
      }
      #endregion
   }
}
