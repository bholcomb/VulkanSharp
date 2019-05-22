using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_vulkan_memory_model = "VK_KHR_vulkan_memory_model";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceVulkanMemoryModelFeaturesKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 vulkanMemoryModel;
         public Bool32 vulkanMemoryModelDeviceScope;
         public Bool32 vulkanMemoryModelAvailabilityVisibilityChains;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
