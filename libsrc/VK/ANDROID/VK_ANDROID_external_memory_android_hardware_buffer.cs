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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferUsageANDROID 
      {
         public StructureType sType;
         public UInt64 androidHardwareBufferUsage;
         public IntPtr pNext;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferPropertiesANDROID 
      {
         public StructureType sType;
         public IntPtr pNext;
         public DeviceSize allocationSize;
         public UInt32 memoryTypeBits;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferFormatPropertiesANDROID 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Format format;
         public UInt64 externalFormat;
         public FormatFeatureFlags formatFeatures;
         public ComponentMapping samplerYcbcrConversionComponents;
         public SamplerYcbcrModelConversion suggestedYcbcrModel;
         public SamplerYcbcrRange suggestedYcbcrRange;
         public ChromaLocation suggestedYChromaOffset;
         public ChromaLocation suggestedXChromaOffset;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportAndroidHardwareBufferInfoANDROID 
      {
         public StructureType sType;
         public IntPtr pNext;
         public IntPtr buffer;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryGetAndroidHardwareBufferInfoANDROID 
      {
         public StructureType sType;
         public IntPtr pNext;
         public DeviceMemory memory;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalFormatANDROID 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt64 externalFormat;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetAndroidHardwareBufferPropertiesANDROID(VkDevice  device, const struct AHardwareBuffer *  buffer, VkAndroidHardwareBufferPropertiesANDROID *  pProperties);
      //VkResult vkGetMemoryAndroidHardwareBufferANDROID(VkDevice  device, const VkMemoryGetAndroidHardwareBufferInfoANDROID *  pInfo, struct AHardwareBuffer **  pBuffer);
      
      //delegate definitions
      public delegate Result GetAndroidHardwareBufferPropertiesANDROIDDelegate(Device device, IntPtr buffer, ref AndroidHardwareBufferPropertiesANDROID  pPropertiess);
      public delegate Result GetMemoryAndroidHardwareBufferANDROIDDelegate(Device device, ref MemoryGetAndroidHardwareBufferInfoANDROID  pInfo, ref IntPtr pBuffers);
      
      //delegate instances
      public static GetAndroidHardwareBufferPropertiesANDROIDDelegate GetAndroidHardwareBufferPropertiesANDROID;
      public static GetMemoryAndroidHardwareBufferANDROIDDelegate GetMemoryAndroidHardwareBufferANDROID;
      #endregion

      #region interop
      public static class ANDROID_external_memory_android_hardware_buffer
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
