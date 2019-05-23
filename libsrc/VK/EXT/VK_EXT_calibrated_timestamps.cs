using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_calibrated_timestamps = "VK_EXT_calibrated_timestamps";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum TimeDomainEXT : int
      {  
         DeviceExt = 0,
         ClockMonotonicExt = 1,
         ClockMonotonicRawExt = 2,
         QueryPerformanceCounterExt = 3,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CalibratedTimestampInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public TimeDomainEXT timeDomain;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsEXT(VkPhysicalDevice physicalDevice, uint32_t* pTimeDomainCount, VkTimeDomainEXT* pTimeDomains);
      //VkResult vkGetCalibratedTimestampsEXT(VkDevice device, uint32_t timestampCount, VkCalibratedTimestampInfoEXT* pTimestampInfos, uint64_t* pTimestamps, uint64_t* pMaxDeviation);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceCalibrateableTimeDomainsEXTDelegate(PhysicalDevice physicalDevice, ref UInt32 pTimeDomainCount, ref TimeDomainEXT pTimeDomains);
      public delegate Result GetCalibratedTimestampsEXTDelegate(Device device, UInt32 timestampCount, ref CalibratedTimestampInfoEXT pTimestampInfos, ref UInt64 pTimestamps, ref UInt64 pMaxDeviation);
      
      //delegate instances
      public static GetPhysicalDeviceCalibrateableTimeDomainsEXTDelegate GetPhysicalDeviceCalibrateableTimeDomainsEXT;
      public static GetCalibratedTimestampsEXTDelegate GetCalibratedTimestampsEXT;
      #endregion

      #region interop
      public static class VK_EXT_calibrated_timestamps
      {
         public static void init(VK.Device device)
         {
            VK.GetPhysicalDeviceCalibrateableTimeDomainsEXT = ExternalFunction.getDeviceFunction<VK.GetPhysicalDeviceCalibrateableTimeDomainsEXTDelegate>(device, "vkGetPhysicalDeviceCalibrateableTimeDomainsEXT");
            VK.GetCalibratedTimestampsEXT = ExternalFunction.getDeviceFunction<VK.GetCalibratedTimestampsEXTDelegate>(device, "vkGetCalibratedTimestampsEXT");
         }
      }
      #endregion
   }
}
