using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_ANDROID_external_memory_android_hardware_buffer = "VK_ANDROID_external_memory_android_hardware_buffer";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferUsageANDROID 
      {
         public StructureType sType;
         public void pNext;
         public UInt64 androidHardwareBufferUsage;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferPropertiesANDROID 
      {
         public StructureType sType;
         public void pNext;
         public DeviceSize allocationSize;
         public UInt32 memoryTypeBits;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferFormatPropertiesANDROID 
      {
         public StructureType sType;
         public void pNext;
         public Format format;
         public UInt64 externalFormat;
         public FormatFeatureFlags formatFeatures;
         public ComponentMapping samplerYcbcrConversionComponents;
         public SamplerYcbcrModelConversion suggestedYcbcrModel;
         public SamplerYcbcrRange suggestedYcbcrRange;
         public ChromaLocation suggestedXChromaOffset;
         public ChromaLocation suggestedYChromaOffset;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportAndroidHardwareBufferInfoANDROID 
      {
         public StructureType sType;
         public void pNext;
         public AHardwareBuffer buffer;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryGetAndroidHardwareBufferInfoANDROID 
      {
         public StructureType sType;
         public void pNext;
         public DeviceMemory memory;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalFormatANDROID 
      {
         public StructureType sType;
         public void pNext;
         public UInt64 externalFormat;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetAndroidHardwareBufferPropertiesANDROID(VkDevice device, AHardwareBuffer* buffer, VkAndroidHardwareBufferPropertiesANDROID* pProperties);
      //VkResult vkGetMemoryAndroidHardwareBufferANDROID(VkDevice device, VkMemoryGetAndroidHardwareBufferInfoANDROID* pInfo, AHardwareBuffer pBuffer);
      
      //delegate definitions
      public delegate Result GetAndroidHardwareBufferPropertiesANDROIDDelegate(Device device, ref AHardwareBuffer buffer, ref AndroidHardwareBufferPropertiesANDROID pProperties);
      public delegate Result GetMemoryAndroidHardwareBufferANDROIDDelegate(Device device, ref MemoryGetAndroidHardwareBufferInfoANDROID pInfo, AHardwareBuffer pBuffer);
      
      //delegate instances
      public static GetAndroidHardwareBufferPropertiesANDROIDDelegate GetAndroidHardwareBufferPropertiesANDROID;
      public static GetMemoryAndroidHardwareBufferANDROIDDelegate GetMemoryAndroidHardwareBufferANDROID;
      #endregion

      #region interop
      public static class VK_ANDROID_external_memory_android_hardware_buffer
      {
         public static void init(VK.Device device)
         {
            VK.GetAndroidHardwareBufferPropertiesANDROID = ExternalFunction.getDeviceFunction<VK.GetAndroidHardwareBufferPropertiesANDROIDDelegate>(device, "vkGetAndroidHardwareBufferPropertiesANDROID");
            VK.GetMemoryAndroidHardwareBufferANDROID = ExternalFunction.getDeviceFunction<VK.GetMemoryAndroidHardwareBufferANDROIDDelegate>(device, "vkGetMemoryAndroidHardwareBufferANDROID");
         }
      }
      #endregion
   }
}
