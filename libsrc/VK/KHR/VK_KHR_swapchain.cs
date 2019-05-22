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
      [StructLayout(LayoutKind.Sequential)] public struct SwapchainKHR { public UInt64 native; }
      #region enums
      #endregion

      #region flags
      [Flags]
      public enum SwapchainCreateFlags : int
      {
        SplitInstanceBindRegionsBitKhr = 1 << 0 ,
        ProtectedBitKhr = 1 << 1,
        MutableFormatBitKhr = 1 << 2,
      };

      [Flags]
      public enum DeviceGroupPresentMode : int
      {  
         LocalBitKhr = 1 << 0,
         RemoteBitKhr = 1 << 1,
         SumBitKhr = 1 << 2,
         LocalMultiDeviceBitKhr = 1 << 3,
      };

      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SwapchainCreateInfoKHR
      {
         StructureType type;
         IntPtr next;
         UInt32 flags;
         SurfaceKHR surface;
         UInt32 minImageCount;
         Format imageFormat;
         ColorSpaceKHR imageColorSpace;
         Extent2D imageExtent;
         UInt32 imageArrayLayers;
         ImageUsageFlags imageUsage;
         SharingMode imageSharingMode;
         UInt32 queueFamilyIndexCount;
         IntPtr queueFamilyIndices;
         UInt32 preTransform;
         UInt32 compositeAlpha;
         PresentModeKHR presentMode;
         Bool32 clipped;
         SwapchainKHR oldSwapchain;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentInfoKHR
      {
         StructureType type;
         IntPtr next;
         UInt32 waitSemaphoreCount;
         Semaphore* waitSemaphores;
         UInt32 swapchainCount;
         SwapchainKHR* swapchains;
         IntPtr imageIndices;
         Result* results;
      }

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSwapchainCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public SwapchainKHR swapchain;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindImageMemorySwapchainInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public SwapchainKHR swapchain;
         public UInt32 imageIndex;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AcquireNextImageInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public SwapchainKHR swapchain;
         public UInt64 timeout;
         public Semaphore semaphore;
         public Fence fence;
         public UInt32 deviceMask;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupPresentCapabilitiesKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public fixed UInt32 presentMask[(int)VK.MAX_DEVICE_GROUP_SIZE];
         public UInt32 modes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupPresentInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 swapchainCount;
         public IntPtr pDeviceMasks;
         public UInt32 mode;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupSwapchainCreateInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 modes;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateSwapchainKHR(VkDevice  device, const VkSwapchainCreateInfoKHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSwapchainKHR *  pSwapchain);
      //void vkDestroySwapchainKHR(VkDevice  device, VkSwapchainKHR  swapchain, const VkAllocationCallbacks *  pAllocator);
      //VkResult vkGetSwapchainImagesKHR(VkDevice  device, VkSwapchainKHR  swapchain, uint32_t *  pSwapchainImageCount, VkImage *  pSwapchainImages);
      //VkResult vkAcquireNextImageKHR(VkDevice  device, VkSwapchainKHR  swapchain, uint64_t  timeout, VkSemaphore  semaphore, VkFence  fence, uint32_t *  pImageIndex);
      //VkResult vkQueuePresentKHR(VkQueue  queue, const VkPresentInfoKHR *  pPresentInfo);
      //VkResult vkGetDeviceGroupPresentCapabilitiesKHR(VkDevice  device, VkDeviceGroupPresentCapabilitiesKHR *  pDeviceGroupPresentCapabilities);
      //VkResult vkGetDeviceGroupSurfacePresentModesKHR(VkDevice  device, VkSurfaceKHR  surface, VkDeviceGroupPresentModeFlagsKHR *  pModes);
      //VkResult vkGetPhysicalDevicePresentRectanglesKHR(VkPhysicalDevice  physicalDevice, VkSurfaceKHR  surface, uint32_t *  pRectCount, VkRect2D *  pRects);
      //VkResult vkAcquireNextImage2KHR(VkDevice  device, const VkAcquireNextImageInfoKHR *  pAcquireInfo, uint32_t *  pImageIndex);
      
      //delegate definitions
      public delegate Result CreateSwapchainKHRDelegate(Device device, ref SwapchainCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, ref SwapchainKHR pSwapchains);
      public delegate void DestroySwapchainKHRDelegate(Device device, SwapchainKHR swapchain, AllocationCallbacks pAllocators);
      public delegate Result GetSwapchainImagesKHRDelegate(Device device, SwapchainKHR swapchain, ref UInt32 pSwapchainImageCount, ref Image pSwapchainImagess);
      public delegate Result AcquireNextImageKHRDelegate(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, ref UInt32 pImageIndexs);
      public delegate Result QueuePresentKHRDelegate(Queue queue, ref PresentInfoKHR pPresentInfos);
      public delegate Result GetDeviceGroupPresentCapabilitiesKHRDelegate(Device device, ref DeviceGroupPresentCapabilitiesKHR pDeviceGroupPresentCapabilitiess);
      public delegate Result GetDeviceGroupSurfacePresentModesKHRDelegate(Device device, SurfaceKHR surface, ref UInt32 pModess);
      public delegate Result GetPhysicalDevicePresentRectanglesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pRectCount, ref Rect2D pRectss);
      public delegate Result AcquireNextImage2KHRDelegate(Device device, ref AcquireNextImageInfoKHR pAcquireInfo, ref UInt32 pImageIndexs);
      
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
      public static class KHR_swapchain
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
