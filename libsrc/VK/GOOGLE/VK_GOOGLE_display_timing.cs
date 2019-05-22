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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RefreshCycleDurationGOOGLE 
      {
         public UInt64 refreshDuration;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PastPresentationTimingGOOGLE 
      {
         public UInt32 presentID;
         public UInt64 desiredPresentTime;
         public UInt64 actualPresentTime;
         public UInt64 earliestPresentTime;
         public UInt64 presentMargin;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentTimesInfoGOOGLE 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 swapchainCount;
         public PresentTimeGOOGLE* pTimes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentTimeGOOGLE 
      {
         public UInt32 presentID;
         public UInt64 desiredPresentTime;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetRefreshCycleDurationGOOGLE(VkDevice  device, VkSwapchainKHR  swapchain, VkRefreshCycleDurationGOOGLE *  pDisplayTimingProperties);
      //VkResult vkGetPastPresentationTimingGOOGLE(VkDevice  device, VkSwapchainKHR  swapchain, uint32_t *  pPresentationTimingCount, VkPastPresentationTimingGOOGLE *  pPresentationTimings);
      
      //delegate definitions
      public delegate Result GetRefreshCycleDurationGOOGLEDelegate(Device device, SwapchainKHR swapchain, ref RefreshCycleDurationGOOGLE pDisplayTimingPropertiess);
      public delegate Result GetPastPresentationTimingGOOGLEDelegate(Device device, SwapchainKHR swapchain, ref UInt32 pPresentationTimingCount, ref PastPresentationTimingGOOGLE pPresentationTimingss);
      
      //delegate instances
      public static GetRefreshCycleDurationGOOGLEDelegate GetRefreshCycleDurationGOOGLE;
      public static GetPastPresentationTimingGOOGLEDelegate GetPastPresentationTimingGOOGLE;
      #endregion

      #region interop
      public static class GOOGLE_display_timing
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
