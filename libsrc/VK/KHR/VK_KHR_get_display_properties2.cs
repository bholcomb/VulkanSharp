using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_get_display_properties2 = "VK_KHR_get_display_properties2";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayProperties2KHR 
      {
         public StructureType sType;
         public void pNext;
         public DisplayPropertiesKHR displayProperties;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPlaneProperties2KHR 
      {
         public StructureType sType;
         public void pNext;
         public DisplayPlanePropertiesKHR displayPlaneProperties;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayModeProperties2KHR 
      {
         public StructureType sType;
         public void pNext;
         public DisplayModePropertiesKHR displayModeProperties;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPlaneInfo2KHR 
      {
         public StructureType sType;
         public void pNext;
         public DisplayModeKHR mode;
         public UInt32 planeIndex;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPlaneCapabilities2KHR 
      {
         public StructureType sType;
         public void pNext;
         public DisplayPlaneCapabilitiesKHR capabilities;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceDisplayProperties2KHR(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkDisplayProperties2KHR* pProperties);
      //VkResult vkGetPhysicalDeviceDisplayPlaneProperties2KHR(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkDisplayPlaneProperties2KHR* pProperties);
      //VkResult vkGetDisplayModeProperties2KHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, uint32_t* pPropertyCount, VkDisplayModeProperties2KHR* pProperties);
      //VkResult vkGetDisplayPlaneCapabilities2KHR(VkPhysicalDevice physicalDevice, VkDisplayPlaneInfo2KHR* pDisplayPlaneInfo, VkDisplayPlaneCapabilities2KHR* pCapabilities);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceDisplayProperties2KHRDelegate(PhysicalDevice physicalDevice, ref UInt32 pPropertyCount, ref DisplayProperties2KHR pProperties);
      public delegate Result GetPhysicalDeviceDisplayPlaneProperties2KHRDelegate(PhysicalDevice physicalDevice, ref UInt32 pPropertyCount, ref DisplayPlaneProperties2KHR pProperties);
      public delegate Result GetDisplayModeProperties2KHRDelegate(PhysicalDevice physicalDevice, DisplayKHR display, ref UInt32 pPropertyCount, ref DisplayModeProperties2KHR pProperties);
      public delegate Result GetDisplayPlaneCapabilities2KHRDelegate(PhysicalDevice physicalDevice, ref DisplayPlaneInfo2KHR pDisplayPlaneInfo, ref DisplayPlaneCapabilities2KHR pCapabilities);
      
      //delegate instances
      public static GetPhysicalDeviceDisplayProperties2KHRDelegate GetPhysicalDeviceDisplayProperties2KHR;
      public static GetPhysicalDeviceDisplayPlaneProperties2KHRDelegate GetPhysicalDeviceDisplayPlaneProperties2KHR;
      public static GetDisplayModeProperties2KHRDelegate GetDisplayModeProperties2KHR;
      public static GetDisplayPlaneCapabilities2KHRDelegate GetDisplayPlaneCapabilities2KHR;
      #endregion

      #region interop
      public static class VK_KHR_get_display_properties2
      {
         public static void init(VK.Instance instance)
         {
            VK.GetPhysicalDeviceDisplayProperties2KHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceDisplayProperties2KHRDelegate>(instance, "vkGetPhysicalDeviceDisplayProperties2KHR");
            VK.GetPhysicalDeviceDisplayPlaneProperties2KHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceDisplayPlaneProperties2KHRDelegate>(instance, "vkGetPhysicalDeviceDisplayPlaneProperties2KHR");
            VK.GetDisplayModeProperties2KHR = ExternalFunction.getInstanceFunction<VK.GetDisplayModeProperties2KHRDelegate>(instance, "vkGetDisplayModeProperties2KHR");
            VK.GetDisplayPlaneCapabilities2KHR = ExternalFunction.getInstanceFunction<VK.GetDisplayPlaneCapabilities2KHRDelegate>(instance, "vkGetDisplayPlaneCapabilities2KHR");
         }
      }
      #endregion
   }
}
