using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_shared_presentable_image = "VK_KHR_shared_presentable_image";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SharedPresentSurfaceCapabilitiesKHR 
      {
         public StructureType sType;
         public ImageUsageFlags sharedPresentSupportedUsageFlags;
         public IntPtr pNext;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetSwapchainStatusKHR(VkDevice  device, VkSwapchainKHR  swapchain);
      
      //delegate definitions
      public delegate Result GetSwapchainStatusKHRDelegate(Device device, SwapchainKHR swapchains);
      
      //delegate instances
      public static GetSwapchainStatusKHRDelegate GetSwapchainStatusKHR;
      #endregion

      #region interop
      public static class KHR_shared_presentable_image
      {
         public static void init(VK.Device device)
         {
            VK.GetSwapchainStatusKHR = ExternalFunction.getDeviceFunction<VK.GetSwapchainStatusKHRDelegate>(device, "vkGetSwapchainStatusKHR");
         }
      }
      #endregion
   }
}
