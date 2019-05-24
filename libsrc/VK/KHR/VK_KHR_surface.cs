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
         SrgbNonlinearKhr = 0,
         DisplayP3NonlinearExt = 1000105001,
         ExtendedSrgbLinearExt = 1000105002,
         DciP3LinearExt = 1000105003,
         DciP3NonlinearExt = 1000105004,
         Bt709LinearExt = 1000105005,
         Bt709NonlinearExt = 1000105006,
         Bt2020LinearExt = 1000105007,
         Hdr10St2084Ext = 1000105008,
         DolbyvisionExt = 1000105009,
         Hdr10HlgExt = 1000105010,
         AdobergbLinearExt = 1000105011,
         AdobergbNonlinearExt = 1000105012,
         PassThroughExt = 1000105013,
         ExtendedSrgbNonlinearExt = 1000105014,
         DisplayNativeAmd = 1000214000,
      };
      
      public enum PresentModeKHR : int
      {  
         ImmediateKhr = 0,
         MailboxKhr = 1,
         FifoKhr = 2,
         FifoRelaxedKhr = 3,
         SharedDemandRefreshKhr = 1000112000,
         SharedContinuousRefreshKhr = 1000112001,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum SurfaceTransformFlagsKHR : int
      {  
         IdentityBitKhr = 1 << 0,
         Rotate90BitKhr = 1 << 1,
         Rotate180BitKhr = 1 << 2,
         Rotate270BitKhr = 1 << 3,
         HorizontalMirrorBitKhr = 1 << 4,
         HorizontalMirrorRotate90BitKhr = 1 << 5,
         HorizontalMirrorRotate180BitKhr = 1 << 6,
         HorizontalMirrorRotate270BitKhr = 1 << 7,
         InheritBitKhr = 1 << 8,
      };
      
      [Flags]
      public enum CompositeAlphaFlagsKHR : int
      {  
         OpaqueBitKhr = 1 << 0,
         PreMultipliedBitKhr = 1 << 1,
         PostMultipliedBitKhr = 1 << 2,
         InheritBitKhr = 1 << 3,
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
      public delegate void DestroySurfaceKHRDelegate(Instance instance, SurfaceKHR surface, ref AllocationCallbacks pAllocator);
      public delegate Result GetPhysicalDeviceSurfaceSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, ref Bool32 pSupported);
      public delegate Result GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref SurfaceCapabilitiesKHR pSurfaceCapabilities);
      public delegate Result GetPhysicalDeviceSurfaceFormatsKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pSurfaceFormatCount, ref SurfaceFormatKHR pSurfaceFormats);
      public delegate Result GetPhysicalDeviceSurfacePresentModesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pPresentModeCount, ref PresentModeKHR pPresentModes);
      
      //delegate instances
      public static DestroySurfaceKHRDelegate DestroySurfaceKHR;
      public static GetPhysicalDeviceSurfaceSupportKHRDelegate GetPhysicalDeviceSurfaceSupportKHR;
      public static GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate GetPhysicalDeviceSurfaceCapabilitiesKHR;
      public static GetPhysicalDeviceSurfaceFormatsKHRDelegate GetPhysicalDeviceSurfaceFormatsKHR;
      public static GetPhysicalDeviceSurfacePresentModesKHRDelegate GetPhysicalDeviceSurfacePresentModesKHR;
      #endregion

      #region interop
      public static class KHR_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.DestroySurfaceKHR = ExternalFunction.getInstanceFunction<VK.DestroySurfaceKHRDelegate>(instance, "vkDestroySurfaceKHR");
            VK.GetPhysicalDeviceSurfaceSupportKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceSupportKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceSupportKHR");
            VK.GetPhysicalDeviceSurfaceCapabilitiesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
            VK.GetPhysicalDeviceSurfaceFormatsKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceFormatsKHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceFormatsKHR");
            VK.GetPhysicalDeviceSurfacePresentModesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfacePresentModesKHRDelegate>(instance, "vkGetPhysicalDeviceSurfacePresentModesKHR");
         }
      }
      #endregion
   }
}
