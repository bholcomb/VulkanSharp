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
         SurfaceTransformIdentityBitKhr = 1 << 0,
         SurfaceTransformRotate90BitKhr = 1 << 1,
         SurfaceTransformRotate180BitKhr = 1 << 2,
         SurfaceTransformRotate270BitKhr = 1 << 3,
         SurfaceTransformHorizontalMirrorBitKhr = 1 << 4,
         SurfaceTransformHorizontalMirrorRotate90BitKhr = 1 << 5,
         SurfaceTransformHorizontalMirrorRotate180BitKhr = 1 << 6,
         SurfaceTransformHorizontalMirrorRotate270BitKhr = 1 << 7,
         SurfaceTransformInheritBitKhr = 1 << 8,
      };
      
      [Flags]
      public enum CompositeAlphaFlagsKHR : int
      {  
         CompositeAlphaOpaqueBitKhr = 1 << 0,
         CompositeAlphaPreMultipliedBitKhr = 1 << 1,
         CompositeAlphaPostMultipliedBitKhr = 1 << 2,
         CompositeAlphaInheritBitKhr = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilitiesKHR 
      {
         public UInt32 minImageCount;
         public UInt32 maxImageCount;
         public Extent2D currentExtent;
         public Extent2D minImageExtent;
         public Extent2D maxImageExtent;
         public UInt32 maxImageArrayLayers;
         public SurfaceTransformFlagsKHR supportedTransforms;
         public SurfaceTransformFlagsKHR currentTransform;
         public CompositeAlphaFlagsKHR supportedCompositeAlpha;
         public ImageUsageFlags supportedUsageFlags;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceFormatKHR 
      {
         public Format format;
         public ColorSpaceKHR colorSpace;
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
      public static class VK_KHR_surface
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
