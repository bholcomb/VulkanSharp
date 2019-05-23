using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_memory_win32 = "VK_KHR_external_memory_win32";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportMemoryWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public ExternalMemoryHandleTypeFlags handleType;          
         public IntPtr/*HANDLE*/ handle;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ExportMemoryWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public IntPtr/*SECURITY_ATTRIBUTES**/ pAttributes;          
         public UInt32/*DWORD*/ dwAccess;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryWin32HandlePropertiesKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 memoryTypeBits;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryGetWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public DeviceMemory memory;          
         public ExternalMemoryHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetMemoryWin32HandleKHR(VkDevice device, VkMemoryGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle);
      //VkResult vkGetMemoryWin32HandlePropertiesKHR(VkDevice device, VkExternalMemoryHandleTypeFlags handleType, HANDLE handle, VkMemoryWin32HandlePropertiesKHR* pMemoryWin32HandleProperties);
      
      //delegate definitions
      public delegate Result GetMemoryWin32HandleKHRDelegate(Device device, ref MemoryGetWin32HandleInfoKHR pGetWin32HandleInfo, ref IntPtr pHandle);
      public delegate Result GetMemoryWin32HandlePropertiesKHRDelegate(Device device, ExternalMemoryHandleTypeFlags handleType, IntPtr handle, ref MemoryWin32HandlePropertiesKHR pMemoryWin32HandleProperties);
      
      //delegate instances
      public static GetMemoryWin32HandleKHRDelegate GetMemoryWin32HandleKHR;
      public static GetMemoryWin32HandlePropertiesKHRDelegate GetMemoryWin32HandlePropertiesKHR;
      #endregion

      #region interop
      public static class VK_KHR_external_memory_win32
      {
         public static void init(VK.Device device)
         {
            VK.GetMemoryWin32HandleKHR = ExternalFunction.getDeviceFunction<VK.GetMemoryWin32HandleKHRDelegate>(device, "vkGetMemoryWin32HandleKHR");
            VK.GetMemoryWin32HandlePropertiesKHR = ExternalFunction.getDeviceFunction<VK.GetMemoryWin32HandlePropertiesKHRDelegate>(device, "vkGetMemoryWin32HandlePropertiesKHR");
         }
      }
      #endregion
   }
}
