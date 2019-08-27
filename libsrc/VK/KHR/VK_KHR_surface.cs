using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_surface = "VK_KHR_surface";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct SurfaceKHR { public UInt64 native; }
      #endregion 
      

      #region enums
      public enum ColorSpaceKHR : int
      {
         SrgbNonlinear = 0,
         DisplayP3Nonlinear = 1000105001,
         ExtendedSrgbLinear = 1000105002,
         DciP3Linear = 1000105003,
         DciP3Nonlinear = 1000105004,
         Bt709Linear = 1000105005,
         Bt709Nonlinear = 1000105006,
         Bt2020Linear = 1000105007,
         Hdr10St2084 = 1000105008,
         Dolbyvision = 1000105009,
         Hdr10Hlg = 1000105010,
         AdobergbLinear = 1000105011,
         AdobergbNonlinear = 1000105012,
         PassThrough = 1000105013,
         ExtendedSrgbNonlinear = 1000105014,
         DisplayNative = 1000214000,
      };
      
      public enum PresentModeKHR : int
      {  
         Immediate = 0,
         Mailbox = 1,
         Fifo = 2,
         FifoRelaxed = 3,
         SharedDemandRefresh = 1000112000,
         SharedContinuousRefresh = 1000112001,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum SurfaceTransformFlagsKHR : int
      {  
         IdentityBit = 1 << 0,
         Rotate90Bit = 1 << 1,
         Rotate180Bit = 1 << 2,
         Rotate270Bit = 1 << 3,
         HorizontalMirrorBit = 1 << 4,
         HorizontalMirrorRotate90Bit = 1 << 5,
         HorizontalMirrorRotate180Bit = 1 << 6,
         HorizontalMirrorRotate270Bit = 1 << 7,
         InheritBit = 1 << 8,
      };
      
      [Flags]
      public enum CompositeAlphaFlagsKHR : int
      {  
         OpaqueBit = 1 << 0,
         PreMultipliedBit = 1 << 1,
         PostMultipliedBit = 1 << 2,
         InheritBit = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilitiesKHR 
      {
         public UInt32 minImageCount;  //Supported minimum number of images for the surface 
         public UInt32 maxImageCount;  //Supported maximum number of images for the surface, 0 for unlimited 
         public Extent2D currentExtent;  //Current image width and height for the surface, (0, 0) if undefined 
         public Extent2D minImageExtent;  //Supported minimum image width and height for the surface 
         public Extent2D maxImageExtent;  //Supported maximum image width and height for the surface 
         public UInt32 maxImageArrayLayers;  //Supported maximum number of image layers for the surface 
         public SurfaceTransformFlagsKHR supportedTransforms;  //1 or more bits representing the transforms supported 
         public SurfaceTransformFlagsKHR currentTransform;  //The surface's current transform relative to the device's natural orientation 
         public CompositeAlphaFlagsKHR supportedCompositeAlpha;  //1 or more bits representing the alpha compositing modes supported 
         public ImageUsageFlags supportedUsageFlags;  //Supported image usage flags for the surface 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceFormatKHR 
      {
         public Format format;  //Supported pair of rendering format 
         public ColorSpaceKHR colorSpace;  //and color space for the surface 
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //void vkDestroySurfaceKHR(VkInstance instance, VkSurfaceKHR surface, VkAllocationCallbacks* pAllocator);
      //VkResult vkGetPhysicalDeviceSurfaceSupportKHR(VkPhysicalDevice physicalDevice, uint32_t queueFamilyIndex, VkSurfaceKHR surface, VkBool32* pSupported);
      //VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, VkSurfaceCapabilitiesKHR* pSurfaceCapabilities);
      //VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint32_t* pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats);
      //VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, uint32_t* pPresentModeCount, VkPresentModeKHR* pPresentModes);
      
      //delegate definitions
      public delegate void DestroySurfaceKHRDelegate(Instance instance, SurfaceKHR surface, AllocationCallbacks pAllocator = null);
      public delegate Result GetPhysicalDeviceSurfaceSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, out Bool32 pSupported);
      public delegate Result GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, out SurfaceCapabilitiesKHR pSurfaceCapabilities);
      delegate Result GetPhysicalDeviceSurfaceFormatsKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pSurfaceFormatCount, IntPtr pSurfaceFormats);
      delegate Result GetPhysicalDeviceSurfacePresentModesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pPresentModeCount, IntPtr pPresentModes);
      
      //delegate instances
      public static DestroySurfaceKHRDelegate DestroySurfaceKHR;
      public static GetPhysicalDeviceSurfaceSupportKHRDelegate GetPhysicalDeviceSurfaceSupportKHR;
      public static GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate GetPhysicalDeviceSurfaceCapabilitiesKHR;
      static GetPhysicalDeviceSurfaceFormatsKHRDelegate _GetPhysicalDeviceSurfaceFormatsKHR;
      static GetPhysicalDeviceSurfacePresentModesKHRDelegate _GetPhysicalDeviceSurfacePresentModesKHR;
      #endregion

      #region interop
      public static unsafe Result GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pSurfaceFormatCount, SurfaceFormatKHR[] pSurfaceFormats)
      {
         if(pSurfaceFormats == null)
         {
            return _GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, ref pSurfaceFormatCount, IntPtr.Zero);
         }
         else
         {
            fixed (SurfaceFormatKHR* ptr = pSurfaceFormats)
            {
               return _GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, ref pSurfaceFormatCount, (IntPtr)ptr);
            }
         }
      }

      public static unsafe Result GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pPresentModeCount, PresentModeKHR[] pPresentModes)
      {
         if(pPresentModes == null)
         {
            return _GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, ref pPresentModeCount, IntPtr.Zero);
         }
         else
         {
            fixed (PresentModeKHR* ptr = pPresentModes)
            {
               return _GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, ref pPresentModeCount, (IntPtr)ptr);
            }
         }
      }

      public static class KHR_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.DestroySurfaceKHR = ExternalFunction.getInstanceFunction<VK.DestroySurfaceKHRDelegate>(instance, "vkDestroySurfaceKHR");
            VK.GetPhysicalDeviceSurfaceSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceSupportKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceSupportKHR");
            VK.GetPhysicalDeviceSurfaceCapabilitiesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
            VK._GetPhysicalDeviceSurfaceFormatsKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceFormatsKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceFormatsKHR");
            VK._GetPhysicalDeviceSurfacePresentModesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfacePresentModesKHRDelegate>(instance, "vkGetPhysicalDeviceSurfacePresentModesKHR");
         }
      }
      #endregion
   }
}
