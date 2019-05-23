using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_buffer_device_address = "VK_EXT_buffer_device_address";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceBufferDeviceAddressFeaturesEXT 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 bufferDeviceAddress;
         public Bool32 bufferDeviceAddressCaptureReplay;
         public Bool32 bufferDeviceAddressMultiDevice;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferDeviceAddressInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public Buffer buffer;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct BufferDeviceAddressCreateInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public DeviceAddress deviceAddress;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkDeviceAddress vkGetBufferDeviceAddressEXT(VkDevice device, VkBufferDeviceAddressInfoEXT* pInfo);
      
      //delegate definitions
      public delegate DeviceAddress GetBufferDeviceAddressEXTDelegate(Device device, ref BufferDeviceAddressInfoEXT pInfo);
      
      //delegate instances
      public static GetBufferDeviceAddressEXTDelegate GetBufferDeviceAddressEXT;
      #endregion

      #region interop
      public static class VK_EXT_buffer_device_address
      {
         public static void init(VK.Device device)
         {
            VK.GetBufferDeviceAddressEXT = ExternalFunction.getDeviceFunction<VK.GetBufferDeviceAddressEXTDelegate>(device, "vkGetBufferDeviceAddressEXT");
         }
      }
      #endregion
   }
}
