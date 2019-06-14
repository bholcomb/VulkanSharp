using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;

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
      public struct SwapchainCreateInfoKHR
      {
         public StructureType type;
         public IntPtr next;
         public SwapchainCreateFlagsKHR flags;
         public SurfaceKHR surface;
         public UInt32 minImageCount;
         public Format imageFormat;
         public ColorSpaceKHR imageColorSpace;
         public Extent2D imageExtent;
         public UInt32 imageArrayLayers;
         public ImageUsageFlags imageUsage;
         public SharingMode imageSharingMode;
         public List<UInt32> queueFamilyIndices;
         public SurfaceTransformFlagsKHR preTransform;
         public CompositeAlphaFlagsKHR compositeAlpha;
         public PresentModeKHR presentMode;
         public Bool32 clipped;
         public SwapchainKHR oldSwapchain;
      }

      public struct PresentInfoKHR
      {
         public StructureType type;
         public IntPtr next;
         public List<Semaphore> waitSemaphores;
         public List<SwapchainKHR> swapchains;
         public List<UInt32> indices;
         public List<Result> results;
      }


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
      delegate Result CreateSwapchainKHRDelegate(Device device, ref _SwapchainCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, out SwapchainKHR pSwapchain);
      public delegate void DestroySwapchainKHRDelegate(Device device, SwapchainKHR swapchain, AllocationCallbacks pAllocator);
      delegate Result GetSwapchainImagesKHRDelegate(Device device, SwapchainKHR swapchain, ref UInt32 pSwapchainImageCount, IntPtr pSwapchainImages);
      public delegate Result AcquireNextImageKHRDelegate(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, ref UInt32 pImageIndex);
      delegate Result QueuePresentKHRDelegate(Queue queue, ref _PresentInfoKHR pPresentInfo);
      public delegate Result GetDeviceGroupPresentCapabilitiesKHRDelegate(Device device, ref DeviceGroupPresentCapabilitiesKHR pDeviceGroupPresentCapabilities);
      public delegate Result GetDeviceGroupSurfacePresentModesKHRDelegate(Device device, SurfaceKHR surface, ref DeviceGroupPresentModeFlagsKHR pModes);
      public delegate Result GetPhysicalDevicePresentRectanglesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pRectCount, ref Rect2D pRects);
      public delegate Result AcquireNextImage2KHRDelegate(Device device, ref AcquireNextImageInfoKHR pAcquireInfo, ref UInt32 pImageIndex);

      //delegate instances
      static CreateSwapchainKHRDelegate _CreateSwapchainKHR;
      public static DestroySwapchainKHRDelegate DestroySwapchainKHR;
      static GetSwapchainImagesKHRDelegate _GetSwapchainImagesKHR;
      public static AcquireNextImageKHRDelegate AcquireNextImageKHR;
      static QueuePresentKHRDelegate _QueuePresentKHR;
      public static GetDeviceGroupPresentCapabilitiesKHRDelegate GetDeviceGroupPresentCapabilitiesKHR;
      public static GetDeviceGroupSurfacePresentModesKHRDelegate GetDeviceGroupSurfacePresentModesKHR;
      public static GetPhysicalDevicePresentRectanglesKHRDelegate GetPhysicalDevicePresentRectanglesKHR;
      public static AcquireNextImage2KHRDelegate AcquireNextImage2KHR;

      #endregion

      #region interop
      public static Result CreateSwapchainKHR(Device device, ref SwapchainCreateInfoKHR pCreateInfo, ref SwapchainKHR pSwapchain, AllocationCallbacks pAllocator = null)
      {
         _SwapchainCreateInfoKHR info = new _SwapchainCreateInfoKHR(pCreateInfo);
         Result res = _CreateSwapchainKHR(device, ref info, pAllocator, out pSwapchain);
         info.destroy();

         return res;
      }

      public unsafe static Result GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, ref UInt32 pSwapchainImageCount, Image[] pSwapchainImages)
      {
         fixed (Image* ptr = pSwapchainImages)
         {
            return _GetSwapchainImagesKHR(device, swapchain, ref pSwapchainImageCount, (IntPtr)ptr);
         }
      }

      public unsafe static Result QueuePresentKHR(Queue queue, ref PresentInfoKHR pPresentInfo)
      {
         _PresentInfoKHR p = new _PresentInfoKHR(pPresentInfo);

         int resultsCount = (pPresentInfo.results == null || pPresentInfo.results.Count == 0) ? 0 : pPresentInfo.results.Count;

         Result res = _QueuePresentKHR(queue, ref p);

         if(resultsCount > 0)
         {
            pPresentInfo.results = p.getResults(resultsCount);
         }

         p.destroy();

         return res;
      }


      public static class KHR_swapchain
      {
         public static void init(VK.Device device)
         {
            VK._CreateSwapchainKHR = ExternalFunction.getDeviceFunction<VK.CreateSwapchainKHRDelegate>(device, "vkCreateSwapchainKHR");
            VK.DestroySwapchainKHR = ExternalFunction.getDeviceFunction<VK.DestroySwapchainKHRDelegate>(device, "vkDestroySwapchainKHR");
            VK._GetSwapchainImagesKHR = ExternalFunction.getDeviceFunction<VK.GetSwapchainImagesKHRDelegate>(device, "vkGetSwapchainImagesKHR");
            VK.AcquireNextImageKHR = ExternalFunction.getDeviceFunction<VK.AcquireNextImageKHRDelegate>(device, "vkAcquireNextImageKHR");
            VK._QueuePresentKHR = ExternalFunction.getDeviceFunction<VK.QueuePresentKHRDelegate>(device, "vkQueuePresentKHR");
            VK.GetDeviceGroupPresentCapabilitiesKHR = ExternalFunction.getDeviceFunction<VK.GetDeviceGroupPresentCapabilitiesKHRDelegate>(device, "vkGetDeviceGroupPresentCapabilitiesKHR");
            VK.GetDeviceGroupSurfacePresentModesKHR = ExternalFunction.getDeviceFunction<VK.GetDeviceGroupSurfacePresentModesKHRDelegate>(device, "vkGetDeviceGroupSurfacePresentModesKHR");
            VK.GetPhysicalDevicePresentRectanglesKHR = ExternalFunction.getDeviceFunction<VK.GetPhysicalDevicePresentRectanglesKHRDelegate>(device, "vkGetPhysicalDevicePresentRectanglesKHR");
            VK.AcquireNextImage2KHR = ExternalFunction.getDeviceFunction<VK.AcquireNextImage2KHRDelegate>(device, "vkAcquireNextImage2KHR");
         }
      }

      [StructLayout(LayoutKind.Sequential)]
      internal struct _SwapchainCreateInfoKHR
      {
         public StructureType SType;
         public IntPtr Next;
         public SwapchainCreateFlagsKHR Flags;
         public SurfaceKHR Surface;
         public UInt32 MinImageCount;
         public Format ImageFormat;
         public ColorSpaceKHR ImageColorSpace;
         public Extent2D ImageExtent;
         public UInt32 ImageArrayLayers;
         public ImageUsageFlags ImageUsage;
         public SharingMode ImageSharingMode;
         public UInt32 QueueFamilyIndexCount;
         public IntPtr QueueFamilyIndices;
         public SurfaceTransformFlagsKHR PreTransform;
         public CompositeAlphaFlagsKHR CompositeAlpha;
         public PresentModeKHR PresentMode;
         public Bool32 Clipped;
         public SwapchainKHR OldSwapchain;

         public _SwapchainCreateInfoKHR(SwapchainCreateInfoKHR info)
         {
            SType = info.type;
            Next = info.next;
            Flags = info.flags;
            Surface = info.surface;
            MinImageCount = info.minImageCount;
            ImageFormat = info.imageFormat;
            ImageColorSpace = info.imageColorSpace;
            ImageExtent = info.imageExtent;
            ImageArrayLayers = info.imageArrayLayers;
            ImageUsage = info.imageUsage;
            ImageSharingMode = info.imageSharingMode;
            QueueFamilyIndexCount = (UInt32)info.queueFamilyIndices.Count;
            QueueFamilyIndices = Alloc.alloc(info.queueFamilyIndices);
            PreTransform = info.preTransform;
            CompositeAlpha = info.compositeAlpha;
            PresentMode = info.presentMode;
            Clipped = info.clipped;
            OldSwapchain = info.oldSwapchain;
         }

         public void destroy()
         {
            Alloc.free(QueueFamilyIndices);
         }
      }

      [StructLayout(LayoutKind.Sequential)]
      internal struct _PresentInfoKHR
      {
         public StructureType SType;
         public IntPtr Next;
         public UInt32 WaitSemaphoreCount;
         public IntPtr WaitSemaphores;
         public UInt32 SwapchainCount;
         public IntPtr Swapchains;
         public IntPtr ImageIndices;
         public IntPtr Results;

         public _PresentInfoKHR(PresentInfoKHR info)
         {
            SType = info.type;
            Next = info.next;
            WaitSemaphoreCount = (UInt32)info.waitSemaphores.Count;
            SwapchainCount = (UInt32)info.swapchains.Count;

            WaitSemaphores = Alloc.alloc(info.waitSemaphores);
            Swapchains = Alloc.alloc(info.swapchains);
            ImageIndices = Alloc.alloc(info.indices);

            List<UInt32> res;
            if(info.results == null || info.results.Count == 0)
            {
               Results = IntPtr.Zero;
            }
            else
            {
               res = new List<UInt32>(info.results.Count);
               Results = Alloc.alloc(res);
            }
         }

         public List<Result> getResults(int count)
         {
            int[] vals = new int[count];
            Marshal.Copy(Results, vals, 0, count);

            List<Result> ret = new List<Result>(count);
            foreach(int v in vals)
            {
               ret.Add((Result)v);
            }

            return ret;
         }

         public void destroy()
         {
            Alloc.free(WaitSemaphores);
            Alloc.free(Swapchains);
            Alloc.free(ImageIndices);
            Alloc.free(Results);
         }
      }
      #endregion
   }
}
