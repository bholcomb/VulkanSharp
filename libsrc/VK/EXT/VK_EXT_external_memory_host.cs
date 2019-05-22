using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_external_memory_host = "VK_EXT_external_memory_host";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportMemoryHostPointerInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ExternalMemoryHandleTypeFlags handleType;
         public IntPtr pHostPointer;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryHostPointerPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 memoryTypeBits;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceExternalMemoryHostPropertiesEXT 
      {
         public StructureType sType;
         public DeviceSize minImportedHostPointerAlignment;
         public IntPtr pNext;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetMemoryHostPointerPropertiesEXT(VkDevice  device, VkExternalMemoryHandleTypeFlagBits  handleType, const void *  pHostPointer, VkMemoryHostPointerPropertiesEXT *  pMemoryHostPointerProperties);
      
      //delegate definitions
      public delegate Result GetMemoryHostPointerPropertiesEXTDelegate(Device device, ExternalMemoryHandleTypeFlags handleType, IntPtr pHostPointer, ref MemoryHostPointerPropertiesEXT pMemoryHostPointerPropertiess);
      
      //delegate instances
      public static GetMemoryHostPointerPropertiesEXTDelegate GetMemoryHostPointerPropertiesEXT;
      #endregion

      #region interop
      public static class VK_EXT_external_memory_host
      {
         public static void init(VK.Device device)
         {
            VK.GetMemoryHostPointerPropertiesEXT = ExternalFunction.getDeviceFunction<VK.GetMemoryHostPointerPropertiesEXTDelegate>(device, "vkGetMemoryHostPointerPropertiesEXT");
         }
      }
      #endregion
   }
}
