using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_full_screen_exclusive = "VK_EXT_full_screen_exclusive";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum FullScreenExclusiveEXT : int
      {  
         DefaultExt = 0,
         AllowedExt = 1,
         DisallowedExt = 2,
         ApplicationControlledExt = 3,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceFullScreenExclusiveInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public FullScreenExclusiveEXT fullScreenExclusive;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceCapabilitiesFullScreenExclusiveEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 fullScreenExclusiveSupported;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SurfaceFullScreenExclusiveWin32InfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public IntPtr /*HMONITOR*/ hmonitor;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetPhysicalDeviceSurfacePresentModes2EXT(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint32_t* pPresentModeCount, VkPresentModeKHR* pPresentModes);
      //VkResult vkAcquireFullScreenExclusiveModeEXT(VkDevice device, VkSwapchainKHR swapchain);
      //VkResult vkReleaseFullScreenExclusiveModeEXT(VkDevice device, VkSwapchainKHR swapchain);
      //VkResult vkGetDeviceGroupSurfacePresentModes2EXT(VkDevice device, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, VkDeviceGroupPresentModeFlagsKHR* pModes);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceSurfacePresentModes2EXTDelegate(PhysicalDevice physicalDevice, ref PhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref UInt32 pPresentModeCount, ref PresentModeKHR pPresentModes);
      public delegate Result AcquireFullScreenExclusiveModeEXTDelegate(Device device, SwapchainKHR swapchain);
      public delegate Result ReleaseFullScreenExclusiveModeEXTDelegate(Device device, SwapchainKHR swapchain);
      public delegate Result GetDeviceGroupSurfacePresentModes2EXTDelegate(Device device, ref PhysicalDeviceSurfaceInfo2KHR pSurfaceInfo, ref DeviceGroupPresentModeFlagsKHR pModes);
      
      //delegate instances
      public static GetPhysicalDeviceSurfacePresentModes2EXTDelegate GetPhysicalDeviceSurfacePresentModes2EXT;
      public static AcquireFullScreenExclusiveModeEXTDelegate AcquireFullScreenExclusiveModeEXT;
      public static ReleaseFullScreenExclusiveModeEXTDelegate ReleaseFullScreenExclusiveModeEXT;
      public static GetDeviceGroupSurfacePresentModes2EXTDelegate GetDeviceGroupSurfacePresentModes2EXT;
      #endregion

      #region interop
      public static class EXT_full_screen_exclusive
      {
         public static void init(VK.Device device)
         {
            VK.GetPhysicalDeviceSurfacePresentModes2EXT = ExternalFunction.getDeviceFunction<VK.GetPhysicalDeviceSurfacePresentModes2EXTDelegate>(device, "vkGetPhysicalDeviceSurfacePresentModes2EXT");
            VK.AcquireFullScreenExclusiveModeEXT = ExternalFunction.getDeviceFunction<VK.AcquireFullScreenExclusiveModeEXTDelegate>(device, "vkAcquireFullScreenExclusiveModeEXT");
            VK.ReleaseFullScreenExclusiveModeEXT = ExternalFunction.getDeviceFunction<VK.ReleaseFullScreenExclusiveModeEXTDelegate>(device, "vkReleaseFullScreenExclusiveModeEXT");
            VK.GetDeviceGroupSurfacePresentModes2EXT = ExternalFunction.getDeviceFunction<VK.GetDeviceGroupSurfacePresentModes2EXTDelegate>(device, "vkGetDeviceGroupSurfacePresentModes2EXT");
         }
      }
      #endregion
   }
}
