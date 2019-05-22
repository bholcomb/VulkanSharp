using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_host_query_reset = "VK_EXT_host_query_reset";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceHostQueryResetFeaturesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 hostQueryReset;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkResetQueryPoolEXT(VkDevice  device, VkQueryPool  queryPool, uint32_t  firstQuery, uint32_t  queryCount);
      
      //delegate definitions
      public delegate void ResetQueryPoolEXTDelegate(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCounts);
      
      //delegate instances
      public static ResetQueryPoolEXTDelegate ResetQueryPoolEXT;
      #endregion

      #region interop
      public static class EXT_host_query_reset
      {
         public static void init(VK.Device device)
         {
            VK.ResetQueryPoolEXT = ExternalFunction.getDeviceFunction<VK.ResetQueryPoolEXTDelegate>(device, "vkResetQueryPoolEXT");
         }
      }
      #endregion
   }
}
