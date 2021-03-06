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
      //no handles
      

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

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPowerInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public DisplayPowerStateEXT powerState;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceEventInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public DeviceEventTypeEXT deviceEvent;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayEventInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public DisplayEventTypeEXT displayEvent;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SwapchainCounterCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public SurfaceCounterFlagsEXT surfaceCounters;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkDisplayPowerControlEXT(VkDevice device, VkDisplayKHR display, VkDisplayPowerInfoEXT* pDisplayPowerInfo);
      //VkResult vkRegisterDeviceEventEXT(VkDevice device, VkDeviceEventInfoEXT* pDeviceEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence);
      //VkResult vkRegisterDisplayEventEXT(VkDevice device, VkDisplayKHR display, VkDisplayEventInfoEXT* pDisplayEventInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence);
      //VkResult vkGetSwapchainCounterEXT(VkDevice device, VkSwapchainKHR swapchain, VkSurfaceCounterFlagsEXT counter, uint64_t* pCounterValue);
      
      //delegate definitions
      public delegate Result DisplayPowerControlEXTDelegate(Device device, DisplayKHR display, ref DisplayPowerInfoEXT pDisplayPowerInfo);
      public delegate Result RegisterDeviceEventEXTDelegate(Device device, ref DeviceEventInfoEXT pDeviceEventInfo, AllocationCallbacks pAllocator, ref Fence pFence);
      public delegate Result RegisterDisplayEventEXTDelegate(Device device, DisplayKHR display, ref DisplayEventInfoEXT pDisplayEventInfo, AllocationCallbacks pAllocator, ref Fence pFence);
      public delegate Result GetSwapchainCounterEXTDelegate(Device device, SwapchainKHR swapchain, SurfaceCounterFlagsEXT counter, ref UInt64 pCounterValue);
      
      //delegate instances
      public static DisplayPowerControlEXTDelegate DisplayPowerControlEXT;
      public static RegisterDeviceEventEXTDelegate RegisterDeviceEventEXT;
      public static RegisterDisplayEventEXTDelegate RegisterDisplayEventEXT;
      public static GetSwapchainCounterEXTDelegate GetSwapchainCounterEXT;
      #endregion

      #region interop
      public static class EXT_display_control
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
