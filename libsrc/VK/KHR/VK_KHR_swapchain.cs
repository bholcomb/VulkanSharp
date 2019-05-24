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
         SplitInstanceBindRegionsBitKhr = 1 << 0,
         ProtectedBitKhr = 1 << 1,
         MutableFormatBitKhr = 1 << 2,
      };
      
      [Flags]
      public enum DeviceGroupPresentModeFlagsKHR : int
      {  
         LocalBitKhr = 1 << 0,
         RemoteBitKhr = 1 << 1,
         SumBitKhr = 1 << 2,
         LocalMultiDeviceBitKhr = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SwapchainCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SwapchainCreateFlagsKHR flags;          
         public SurfaceKHR surface;  //The swapchain's target surface 
         public UInt32 minImageCount;  //Minimum number of presentation images the application needs 
         public Format imageFormat;  //Format of the presentation images 
         public ColorSpaceKHR imageColorSpace;  //Colorspace of the presentation images 
         public Extent2D imageExtent;  //Dimensions of the presentation images 
         public UInt32 imageArrayLayers;  //Determines the number of views for multiview/stereo presentation 
         public ImageUsageFlags imageUsage;  //Bits indicating how the presentation images will be used 
         public SharingMode imageSharingMode;  //Sharing mode used for the presentation images 
         public UInt32 queueFamilyIndexCount;  //Number of queue families having access to the images in case of concurrent sharing mode 
         public UInt32* pQueueFamilyIndices;  //Array of queue family indices having access to the images in case of concurrent sharing mode 
         public SurfaceTransformFlagsKHR preTransform;  //The transform, relative to the device's natural orientation, applied to the image content prior to presentation 
         public CompositeAlphaFlagsKHR compositeAlpha;  //The alpha blending mode used when compositing this surface with other surfaces in the window system 
         public PresentModeKHR presentMode;  //Which presentation mode to use for presents on this swap chain 
         public Bool32 clipped;  //Specifies whether presentable images may be affected by window clip regions 
         public SwapchainKHR oldSwapchain;  //Existing swap chain to replace, if any 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 waitSemaphoreCount;  //Number of semaphores to wait for before presenting 
         public Semaphore* pWaitSemaphores;  //Semaphores to wait for before presenting 
         public UInt32 swapchainCount;  //Number of swapchains to present in this call 
         public SwapchainKHR* pSwapchains;  //Swapchains to present an image from 
         public UInt32* pImageIndices;  //Indices of which presentable images to present 
         public Result* pResults;  //Optional (i.e. if non-NULL) VkResult for each swapchain 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageSwapchainCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SwapchainKHR swapchain;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BindImageMemorySwapchainInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SwapchainKHR swapchain;          
         public UInt32 imageIndex;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AcquireNextImageInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SwapchainKHR swapchain;          
         public UInt64 timeout;          
         public Semaphore semaphore;          
         public Fence fence;          
         public UInt32 deviceMask;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupPresentCapabilitiesKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public fixed UInt32 presentMask[(int)VK.MAX_DEVICE_GROUP_SIZE];          
         public DeviceGroupPresentModeFlagsKHR modes;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DeviceGroupPresentInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 swapchainCount;          
         public UInt32* pDeviceMasks;          
         public DeviceGroupPresentModeFlagsKHR mode;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceGroupSwapchainCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
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
