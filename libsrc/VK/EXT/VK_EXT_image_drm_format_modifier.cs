using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_image_drm_format_modifier = "VK_EXT_image_drm_format_modifier";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DrmFormatModifierPropertiesListEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 drmFormatModifierCount;          
         public DrmFormatModifierPropertiesEXT* pDrmFormatModifierProperties;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DrmFormatModifierPropertiesEXT 
      {
         public UInt64 drmFormatModifier;          
         public UInt32 drmFormatModifierPlaneCount;          
         public FormatFeatureFlags drmFormatModifierTilingFeatures;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceImageDrmFormatModifierInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt64 drmFormatModifier;          
         public SharingMode sharingMode;          
         public UInt32 queueFamilyIndexCount;          
         public UInt32* pQueueFamilyIndices;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ImageDrmFormatModifierListCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 drmFormatModifierCount;          
         public UInt64* pDrmFormatModifiers;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ImageDrmFormatModifierExplicitCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt64 drmFormatModifier;          
         public UInt32 drmFormatModifierPlaneCount;          
         public SubresourceLayout* pPlaneLayouts;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageDrmFormatModifierPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt64 drmFormatModifier;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetImageDrmFormatModifierPropertiesEXT(VkDevice device, VkImage image, VkImageDrmFormatModifierPropertiesEXT* pProperties);
      
      //delegate definitions
      public delegate Result GetImageDrmFormatModifierPropertiesEXTDelegate(Device device, Image image, ref ImageDrmFormatModifierPropertiesEXT pProperties);
      
      //delegate instances
      public static GetImageDrmFormatModifierPropertiesEXTDelegate GetImageDrmFormatModifierPropertiesEXT;
      #endregion

      #region interop
      public static class VK_EXT_image_drm_format_modifier
      {
         public static void init(VK.Device device)
         {
            VK.GetImageDrmFormatModifierPropertiesEXT = ExternalFunction.getDeviceFunction<VK.GetImageDrmFormatModifierPropertiesEXTDelegate>(device, "vkGetImageDrmFormatModifierPropertiesEXT");
         }
      }
      #endregion
   }
}
