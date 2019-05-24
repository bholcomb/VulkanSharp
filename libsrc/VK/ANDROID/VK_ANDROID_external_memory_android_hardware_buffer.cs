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
         public StructureType type;          
         public IntPtr next;          
         public UInt64 androidHardwareBufferUsage;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferPropertiesANDROID 
      {
         public StructureType type;          
         public IntPtr next;          
         public DeviceSize allocationSize;          
         public UInt32 memoryTypeBits;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AndroidHardwareBufferFormatPropertiesANDROID 
      {
         public StructureType type;          
         public IntPtr next;          
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
      public unsafe struct ImportAndroidHardwareBufferInfoANDROID
      {
         public StructureType type;
         public IntPtr next;
         public IntPtr /* AHardwareBuffer* */ buffer;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryGetAndroidHardwareBufferInfoANDROID 
      {
         public StructureType type;          
         public IntPtr next;          
         public DeviceMemory memory;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalFormatANDROID 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt64 externalFormat;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetAndroidHardwareBufferPropertiesANDROID(VkDevice device, AHardwareBuffer* buffer, VkAndroidHardwareBufferPropertiesANDROID* pProperties);
      //VkResult vkGetMemoryAndroidHardwareBufferANDROID(VkDevice device, VkMemoryGetAndroidHardwareBufferInfoANDROID* pInfo, AHardwareBuffer pBuffer);
      
      //delegate definitions
      public delegate Result GetAndroidHardwareBufferPropertiesANDROIDDelegate(Device device, IntPtr buffer, ref AndroidHardwareBufferPropertiesANDROID pProperties);
      public delegate Result GetMemoryAndroidHardwareBufferANDROIDDelegate(Device device, ref MemoryGetAndroidHardwareBufferInfoANDROID pInfo, IntPtr pBuffer);
      
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
