using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_swapchain = "VK_KHR_swapchain";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct SwapchainKHR { public UInt64 native; }
      #endregion 
      

      //no enums

       
      #region flags
      [Flags]
      public enum SwapchainCreateFlagsKHR : int
      {  
         SwapchainCreateSplitInstanceBindRegionsBitKhr = 1 << 0,
         SwapchainCreateProtectedBitKhr = 1 << 1,
         SwapchainCreateMutableFormatBitKhr = 1 << 2,
      };
      
      [Flags]
      public enum DeviceGroupPresentModeFlagsKHR : int
      {  
         DeviceGroupPresentModeLocalBitKhr = 1 << 0,
         DeviceGroupPresentModeRemoteBitKhr = 1 << 1,
         DeviceGroupPresentModeSumBitKhr = 1 << 2,
         DeviceGroupPresentModeLocalMultiDeviceBitKhr = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SwapchainCreateInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public SwapchainCreateFlagsKHR flags;
         public SurfaceKHR surface;
         public UInt32 minImageCount;
         public Format imageFormat;
         public ColorSpaceKHR imageColorSpace;
         public Extent2D imageExtent;
         public UInt32 imageArrayLayers;
         public ImageUsageFlags imageUsage;
         public SharingMode imageSharingMode;
         public UInt32 queueFamilyIndexCount;
         public UInt32 pQueueFamilyIndices;
         public SurfaceTransformFlagsKHR preTransform;
         public CompositeAlphaFlagsKHR compositeAlpha;
         public PresentModeKHR presentMode;
         public Bool32 clipped;
         public SwapchainKHR oldSwapchain;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 waitSemaphoreCount;
         public Semaphore pWaitSemaphores;
         public UInt32 swapchainCount;
         public SwapchainKHR pSwapchains;
         public UInt32 pImageIndices;
         public Result pResults;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSwapchainCreateInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public SwapchainKHR swapchain;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindImageMemorySwapchainInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public SwapchainKHR swapchain;
         public UInt32 imageIndex;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AcquireNextImageInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public SwapchainKHR swapchain;
         public UInt64 timeout;
         public Semaphore semaphore;
         public Fence fence;
         public UInt32 deviceMask;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupPresentCapabilitiesKHR 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 presentMask;
         public DeviceGroupPresentModeFlagsKHR modes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupPresentInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 swapchainCount;
         public UInt32 pDeviceMasks;
         public DeviceGroupPresentModeFlagsKHR mode;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupSwapchainCreateInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public DeviceGroupPresentModeFlagsKHR modes;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateSwapchainKHR(VkDevice device, VkSwapchainCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSwapchainKHR* pSwapchain);
      //void vkDestroySwapchainKHR(VkDevice device, VkSwapchainKHR swapchain, VkAllocationCallbacks* pAllocator);
      //VkResult vkGetSwapchainImagesKHR(VkDevice device, VkSwapchainKHR swapchain, uint32_t* pSwapchainImageCount, VkImage* pSwapchainImages);
      //VkResult vkAcquireNextImageKHR(VkDevice device, VkSwapchainKHR swapchain, uint64_t timeout, VkSemaphore semaphore, VkFence fence, uint32_t* pImageIndex);
      //VkResult vkQueuePresentKHR(VkQueue queue, VkPresentInfoKHR* pPresentInfo);
      //VkResult vkGetDeviceGroupPresentCapabilitiesKHR(VkDevice device, VkDeviceGroupPresentCapabilitiesKHR* pDeviceGroupPresentCapabilities);
      //VkResult vkGetDeviceGroupSurfacePresentModesKHR(VkDevice device, VkSurfaceKHR surface, VkDeviceGroupPresentModeFlagsKHR* pModes);
      //VkResult vkGetPhysicalDevicePresentRectanglesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint32_t* pRectCount, VkRect2D* pRects);
      //VkResult vkAcquireNextImage2KHR(VkDevice device, VkAcquireNextImageInfoKHR* pAcquireInfo, uint32_t* pImageIndex);
      
      //delegate definitions
      public delegate Result CreateSwapchainKHRDelegate(Device device, ref SwapchainCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SwapchainKHR pSwapchain);
      public delegate void DestroySwapchainKHRDelegate(Device device, SwapchainKHR swapchain, ref AllocationCallbacks pAllocator);
      public delegate Result GetSwapchainImagesKHRDelegate(Device device, SwapchainKHR swapchain, ref UInt32 pSwapchainImageCount, ref Image pSwapchainImages);
      public delegate Result AcquireNextImageKHRDelegate(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, ref UInt32 pImageIndex);
      public delegate Result QueuePresentKHRDelegate(Queue queue, ref PresentInfoKHR pPresentInfo);
      public delegate Result GetDeviceGroupPresentCapabilitiesKHRDelegate(Device device, ref DeviceGroupPresentCapabilitiesKHR pDeviceGroupPresentCapabilities);
      public delegate Result GetDeviceGroupSurfacePresentModesKHRDelegate(Device device, SurfaceKHR surface, ref DeviceGroupPresentModeFlagsKHR pModes);
      public delegate Result GetPhysicalDevicePresentRectanglesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pRectCount, ref Rect2D pRects);
      public delegate Result AcquireNextImage2KHRDelegate(Device device, ref AcquireNextImageInfoKHR pAcquireInfo, ref UInt32 pImageIndex);
      
      //delegate instances
      public static CreateSwapchainKHRDelegate CreateSwapchainKHR;
      public static DestroySwapchainKHRDelegate DestroySwapchainKHR;
      public static GetSwapchainImagesKHRDelegate GetSwapchainImagesKHR;
      public static AcquireNextImageKHRDelegate AcquireNextImageKHR;
      public static QueuePresentKHRDelegate QueuePresentKHR;
      public static GetDeviceGroupPresentCapabilitiesKHRDelegate GetDeviceGroupPresentCapabilitiesKHR;
      public static GetDeviceGroupSurfacePresentModesKHRDelegate GetDeviceGroupSurfacePresentModesKHR;
      public static GetPhysicalDevicePresentRectanglesKHRDelegate GetPhysicalDevicePresentRectanglesKHR;
      public static AcquireNextImage2KHRDelegate AcquireNextImage2KHR;
      #endregion

      #region interop
      public static class VK_KHR_swapchain
      {
         public static void init(VK.Device device)
         {
            VK.CreateSwapchainKHR = ExternalFunction.getDeviceFunction<VK.CreateSwapchainKHRDelegate>(device, "vkCreateSwapchainKHR");
            VK.DestroySwapchainKHR = ExternalFunction.getDeviceFunction<VK.DestroySwapchainKHRDelegate>(device, "vkDestroySwapchainKHR");
            VK.GetSwapchainImagesKHR = ExternalFunction.getDeviceFunction<VK.GetSwapchainImagesKHRDelegate>(device, "vkGetSwapchainImagesKHR");
            VK.AcquireNextImageKHR = ExternalFunction.getDeviceFunction<VK.AcquireNextImageKHRDelegate>(device, "vkAcquireNextImageKHR");
            VK.QueuePresentKHR = ExternalFunction.getDeviceFunction<VK.QueuePresentKHRDelegate>(device, "vkQueuePresentKHR");
            VK.GetDeviceGroupPresentCapabilitiesKHR = ExternalFunction.getDeviceFunction<VK.GetDeviceGroupPresentCapabilitiesKHRDelegate>(device, "vkGetDeviceGroupPresentCapabilitiesKHR");
            VK.GetDeviceGroupSurfacePresentModesKHR = ExternalFunction.getDeviceFunction<VK.GetDeviceGroupSurfacePresentModesKHRDelegate>(device, "vkGetDeviceGroupSurfacePresentModesKHR");
            VK.GetPhysicalDevicePresentRectanglesKHR = ExternalFunction.getDeviceFunction<VK.GetPhysicalDevicePresentRectanglesKHRDelegate>(device, "vkGetPhysicalDevicePresentRectanglesKHR");
            VK.AcquireNextImage2KHR = ExternalFunction.getDeviceFunction<VK.AcquireNextImage2KHRDelegate>(device, "vkAcquireNextImage2KHR");
         }
      }
      #endregion
   }
}
