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
      [StructLayout(LayoutKind.Sequential)] public struct SurfaceKHR { public UInt64 native; }
      #region enums
      public enum ColorSpaceKHR : int
      {
         SRGB_NONLINEAR_KHR = 0,
         DISPLAY_P3_NONLINEAR_EXT = 1000104001,
         EXTENDED_SRGB_LINEAR_EXT = 1000104002,
         DCI_P3_LINEAR_EXT = 1000104003,
         DCI_P3_NONLINEAR_EXT = 1000104004,
         BT709_LINEAR_EXT = 1000104005,
         BT709_NONLINEAR_EXT = 1000104006,
         BT2020_LINEAR_EXT = 1000104007,
         HDR10_ST2084_EXT = 1000104008,
         DOLBYVISION_EXT = 1000104009,
         HDR10_HLG_EXT = 1000104010,
         ADOBERGB_LINEAR_EXT = 1000104011,
         ADOBERGB_NONLINEAR_EXT = 1000104012,
         PASS_THROUGH_EXT = 1000104013,
         EXTENDED_SRGB_NONLINEAR_EXT = 1000104014,
      };

      public enum PresentModeKHR : int
      {
         Immediate = 0,
         Mailbox = 1,
         Fifo = 2,
         FifoRelaxed = 3,
         SharedDemandRefresh = 1000111000,
         SharedContinousRefresh = 1000111001,
      };


      #endregion

      #region flags
      public enum SurfaceTransformFlagsKHR : int
      {
         IDENTITY_BIT_KHR = 0x00000001,
         ROTATE_90_BIT_KHR = 0x00000002,
         ROTATE_180_BIT_KHR = 0x00000004,
         ROTATE_270_BIT_KHR = 0x00000008,
         HORIZONTAL_MIRROR_BIT_KHR = 0x00000010,
         HORIZONTAL_MIRROR_ROTATE_90_BIT_KHR = 0x00000020,
         HORIZONTAL_MIRROR_ROTATE_180_BIT_KHR = 0x00000040,
         HORIZONTAL_MIRROR_ROTATE_270_BIT_KHR = 0x00000080,
         INHERIT_BIT_KHR = 0x00000100,
      };

      [Flags]
      public enum CompositeAlphaFlagsKHR : int
      {
         OPAQUE_BIT_KHR = 0x00000001,
         PRE_MULTIPLIED_BIT_KHR = 0x00000002,
         POST_MULTIPLIED_BIT_KHR = 0x00000004,
         INHERIT_BIT_KHR = 0x00000008,
         FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF
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
         public UInt32 supportedTransforms;
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
      //void vkDestroySurfaceKHR(VkInstance  instance, VkSurfaceKHR  surface, const VkAllocationCallbacks *  pAllocator);
      //VkResult vkGetPhysicalDeviceSurfaceSupportKHR(VkPhysicalDevice  physicalDevice, uint32_t  queueFamilyIndex, VkSurfaceKHR  surface, VkBool32 *  pSupported);
      //VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(VkPhysicalDevice  physicalDevice, VkSurfaceKHR  surface, VkSurfaceCapabilitiesKHR *  pSurfaceCapabilities);
      //VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(VkPhysicalDevice  physicalDevice, VkSurfaceKHR  surface, uint32_t *  pSurfaceFormatCount, VkSurfaceFormatKHR *  pSurfaceFormats);
      //VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(VkPhysicalDevice  physicalDevice, VkSurfaceKHR  surface, uint32_t *  pPresentModeCount, VkPresentModeKHR *  pPresentModes);

      //delegate definitions
      public delegate void DestroySurfaceKHRDelegate(Instance instance, SurfaceKHR surface, AllocationCallbacks pAllocators);
      public delegate Result GetPhysicalDeviceSurfaceSupportKHRDelegate(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, out Bool32 pSupporteds);
      public delegate Result GetPhysicalDeviceSurfaceCapabilitiesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, out SurfaceCapabilitiesKHR pSurfaceCapabilitiess);
      public delegate Result GetPhysicalDeviceSurfaceFormatsKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref UInt32 pSurfaceFormatCount, ref SurfaceFormatKHR pSurfaceFormatss);
      public delegate Result GetPhysicalDeviceSurfacePresentModesKHRDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, out UInt32 pPresentModeCount, out PresentModeKHR pPresentModess);
      
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
