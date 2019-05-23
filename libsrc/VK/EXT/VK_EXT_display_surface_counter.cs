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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum SurfaceCounterFlagsEXT : int
      {  
         SurfaceCounterVblankExt = 1 << 0,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilities2EXT 
      {
         public StructureType type;          
         public IntPtr next;          
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
         public SurfaceCounterFlagsEXT supportedSurfaceCounters;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, VkSurfaceCapabilities2EXT* pSurfaceCapabilities);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceSurfaceCapabilities2EXTDelegate(PhysicalDevice physicalDevice, SurfaceKHR surface, ref SurfaceCapabilities2EXT pSurfaceCapabilities);
      
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
