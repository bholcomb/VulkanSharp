using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_display_surface_counter = "VK_EXT_display_surface_counter";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      [Flags]
      public enum SurfaceCounterFlagsEXT : int
      {  
         VblankExt = 1 << 0,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilities2EXT 
      {
         public StructureType sType;
         public IntPtr pNext;
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
         public SurfaceCounterFlagsEXT supportedSurfaceCounters;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(VkPhysicalDevice  physicalDevice, VkSurfaceKHR  surface, VkSurfaceCapabilities2EXT *  pSurfaceCapabilities);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceSurfaceCapabilities2EXTDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref SurfaceCapabilities2EXT pSurfaceCapabilitiess);
      
      //delegate instances
      public static GetPhysicalDeviceSurfaceCapabilities2EXTDelegate GetPhysicalDeviceSurfaceCapabilities2EXT;
      #endregion

      #region interop
      public static class VK_EXT_display_surface_counter
      {
         public static void init(VK.Instance instance)
         {
            VK.GetPhysicalDeviceSurfaceCapabilities2EXT = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceCapabilities2EXTDelegate>(instance, "vkGetPhysicalDeviceSurfaceCapabilities2EXT");
         }
      }
      #endregion
   }
}
