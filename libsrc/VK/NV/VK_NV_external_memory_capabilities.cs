using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_NV_external_memory_capabilities = "VK_NV_external_memory_capabilities";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum ExternalMemoryHandleTypeFlagsNV : int
      {  
         ExternalMemoryHandleTypeOpaqueWin32BitNv = 1 << 0,
         ExternalMemoryHandleTypeOpaqueWin32KmtBitNv = 1 << 1,
         ExternalMemoryHandleTypeD3d11ImageBitNv = 1 << 2,
         ExternalMemoryHandleTypeD3d11ImageKmtBitNv = 1 << 3,
      };
      
      [Flags]
      public enum ExternalMemoryFeatureFlagsNV : int
      {  
         ExternalMemoryFeatureDedicatedOnlyBitNv = 1 << 0,
         ExternalMemoryFeatureExportableBitNv = 1 << 1,
         ExternalMemoryFeatureImportableBitNv = 1 << 2,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalImageFormatPropertiesNV 
      {
         public ImageFormatProperties imageFormatProperties;
         public ExternalMemoryFeatureFlagsNV externalMemoryFeatures;
         public ExternalMemoryHandleTypeFlagsNV exportFromImportedHandleTypes;
         public ExternalMemoryHandleTypeFlagsNV compatibleHandleTypes;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkExternalMemoryHandleTypeFlagsNV externalHandleType, VkExternalImageFormatPropertiesNV* pExternalImageFormatProperties);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceExternalImageFormatPropertiesNVDelegate(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ExternalMemoryHandleTypeFlagsNV externalHandleType, ref ExternalImageFormatPropertiesNV pExternalImageFormatProperties);
      
      //delegate instances
      public static GetPhysicalDeviceExternalImageFormatPropertiesNVDelegate GetPhysicalDeviceExternalImageFormatPropertiesNV;
      #endregion

      #region interop
      public static class VK_NV_external_memory_capabilities
      {
         public static void init(VK.Instance instance)
         {
            VK.GetPhysicalDeviceExternalImageFormatPropertiesNV = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceExternalImageFormatPropertiesNVDelegate>(instance, "vkGetPhysicalDeviceExternalImageFormatPropertiesNV");
         }
      }
      #endregion
   }
}
