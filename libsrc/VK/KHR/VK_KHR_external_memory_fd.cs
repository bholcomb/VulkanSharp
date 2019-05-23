using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_memory_fd = "VK_KHR_external_memory_fd";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportMemoryFdInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ExternalMemoryHandleTypeFlags handleType;          
         public int fd;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryFdPropertiesKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 memoryTypeBits;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryGetFdInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DeviceMemory memory;          
         public ExternalMemoryHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetMemoryFdKHR(VkDevice device, VkMemoryGetFdInfoKHR* pGetFdInfo, int* pFd);
      //VkResult vkGetMemoryFdPropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlags handleType, int fd, VkMemoryFdPropertiesKHR* pMemoryFdProperties);
      
      //delegate definitions
      public delegate Result GetMemoryFdKHRDelegate(Device device, ref MemoryGetFdInfoKHR pGetFdInfo, ref int pFd);
      public delegate Result GetMemoryFdPropertiesKHRDelegate(Device device, ExternalMemoryHandleTypeFlags handleType, int fd, ref MemoryFdPropertiesKHR pMemoryFdProperties);
      
      //delegate instances
      public static GetMemoryFdKHRDelegate GetMemoryFdKHR;
      public static GetMemoryFdPropertiesKHRDelegate GetMemoryFdPropertiesKHR;
      #endregion

      #region interop
      public static class VK_KHR_external_memory_fd
      {
         public static void init(VK.Device device)
         {
            VK.GetMemoryFdKHR = ExternalFunction.getDeviceFunction<VK.GetMemoryFdKHRDelegate>(device, "vkGetMemoryFdKHR");
            VK.GetMemoryFdPropertiesKHR = ExternalFunction.getDeviceFunction<VK.GetMemoryFdPropertiesKHRDelegate>(device, "vkGetMemoryFdPropertiesKHR");
         }
      }
      #endregion
   }
}
