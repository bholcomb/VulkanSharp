using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_get_surface_capabilities2 = "VK_KHR_get_surface_capabilities2";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSurfaceInfo2KHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SurfaceKHR surface;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilities2KHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SurfaceCapabilitiesKHR surfaceCapabilities;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceFormat2KHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public SurfaceFormatKHR surfaceFormat;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities);
      //VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint32_t* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceSurfaceCapabilities2KHRDelegate(PhysicalDevice physicalDevice, ref PhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref SurfaceCapabilities2KHR pSurfaceCapabilities);
      public delegate Result GetPhysicalDeviceSurfaceFormats2KHRDelegate(PhysicalDevice physicalDevice, ref PhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref UInt32 pSurfaceFormatCount, ref SurfaceFormat2KHR pSurfaceFormats);
      
      //delegate instances
      public static GetPhysicalDeviceSurfaceCapabilities2KHRDelegate GetPhysicalDeviceSurfaceCapabilities2KHR;
      public static GetPhysicalDeviceSurfaceFormats2KHRDelegate GetPhysicalDeviceSurfaceFormats2KHR;
      #endregion

      #region interop
      public static class KHR_get_surface_capabilities2
      {
         public static void init(VK.Instance instance)
         {
            VK.GetPhysicalDeviceSurfaceCapabilities2KHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceCapabilities2KHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceCapabilities2KHR");
            VK.GetPhysicalDeviceSurfaceFormats2KHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceSurfaceFormats2KHRDelegate>(instance, "vkGetPhysicalDeviceSurfaceFormats2KHR");
         }
      }
      #endregion
   }
}
