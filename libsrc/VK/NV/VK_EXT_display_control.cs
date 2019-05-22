using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_display_control = "VK_EXT_display_control";
   };
   
   public static partial class VK
   {
      #region enums
      public enum DisplayPowerStateEXT : int
      {  
         OffExt = 0,
         SuspendExt = 1,
         OnExt = 2,
         
      };
      
      public enum DeviceEventTypeEXT : int
      {  
         DisplayHotplugExt = 0,
         
      };
      
      public enum DisplayEventTypeEXT : int
      {  
         FirstPixelOutExt = 0,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPowerInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public DisplayPowerStateEXT powerState;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceEventInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public DeviceEventTypeEXT deviceEvent;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayEventInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public DisplayEventTypeEXT displayEvent;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SwapchainCounterCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public SurfaceCounterFlagsEXT surfaceCounters;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkDisplayPowerControlEXT(VkDevice  device, VkDisplayKHR  display, const VkDisplayPowerInfoEXT *  pDisplayPowerInfo);
      //VkResult vkRegisterDeviceEventEXT(VkDevice  device, const VkDeviceEventInfoEXT *  pDeviceEventInfo, const VkAllocationCallbacks *  pAllocator, VkFence *  pFence);
      //VkResult vkRegisterDisplayEventEXT(VkDevice  device, VkDisplayKHR  display, const VkDisplayEventInfoEXT *  pDisplayEventInfo, const VkAllocationCallbacks *  pAllocator, VkFence *  pFence);
      //VkResult vkGetSwapchainCounterEXT(VkDevice  device, VkSwapchainKHR  swapchain, VkSurfaceCounterFlagBitsEXT  counter, uint64_t *  pCounterValue);
      
      //delegate definitions
      public delegate Result DisplayPowerControlEXTDelegate(Device device, DisplayKHR display, ref DisplayPowerInfoEXT pDisplayPowerInfos);
      public delegate Result RegisterDeviceEventEXTDelegate(Device device, ref DeviceEventInfoEXT pDeviceEventInfo, ref AllocationCallbacks pAllocator, ref Fence pFences);
      public delegate Result RegisterDisplayEventEXTDelegate(Device device, DisplayKHR display, ref DisplayEventInfoEXT pDisplayEventInfo, ref AllocationCallbacks pAllocator, ref Fence pFences);
      public delegate Result GetSwapchainCounterEXTDelegate(Device device, SwapchainKHR swapchain, SurfaceCounterFlagsEXT counter, ref UInt64 pCounterValues);
      
      //delegate instances
      public static DisplayPowerControlEXTDelegate DisplayPowerControlEXT;
      public static RegisterDeviceEventEXTDelegate RegisterDeviceEventEXT;
      public static RegisterDisplayEventEXTDelegate RegisterDisplayEventEXT;
      public static GetSwapchainCounterEXTDelegate GetSwapchainCounterEXT;
      #endregion

      #region interop
      public static class VK_EXT_display_control
      {
         public static void init(VK.Device device)
         {
            VK.DisplayPowerControlEXT = ExternalFunction.getDeviceFunction<VK.DisplayPowerControlEXTDelegate>(device, "vkDisplayPowerControlEXT");
            VK.RegisterDeviceEventEXT = ExternalFunction.getDeviceFunction<VK.RegisterDeviceEventEXTDelegate>(device, "vkRegisterDeviceEventEXT");
            VK.RegisterDisplayEventEXT = ExternalFunction.getDeviceFunction<VK.RegisterDisplayEventEXTDelegate>(device, "vkRegisterDisplayEventEXT");
            VK.GetSwapchainCounterEXT = ExternalFunction.getDeviceFunction<VK.GetSwapchainCounterEXTDelegate>(device, "vkGetSwapchainCounterEXT");
         }
      }
      #endregion
   }
}
