using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_external_memory_win32 = "VK_NV_external_memory_win32";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportMemoryWin32HandleInfoNV 
      {
         public StructureType sType;
         public void pNext;
         public ExternalMemoryHandleTypeFlagsNV handleType;
         public HANDLE handle;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportMemoryWin32HandleInfoNV 
      {
         public StructureType sType;
         public void pNext;
         public SECURITY_ATTRIBUTES pAttributes;
         public DWORD dwAccess;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetMemoryWin32HandleNV(VkDevice device, VkDeviceMemory memory, VkExternalMemoryHandleTypeFlagsNV handleType, HANDLE* pHandle);
      
      //delegate definitions
      public delegate Result GetMemoryWin32HandleNVDelegate(Device device, DeviceMemory memory, ExternalMemoryHandleTypeFlagsNV handleType, ref HANDLE pHandle);
      
      //delegate instances
      public static GetMemoryWin32HandleNVDelegate GetMemoryWin32HandleNV;
      #endregion

      #region interop
      public static class VK_NV_external_memory_win32
      {
         public static void init(VK.Device device)
         {
            VK.GetMemoryWin32HandleNV = ExternalFunction.getDeviceFunction<VK.GetMemoryWin32HandleNVDelegate>(device, "vkGetMemoryWin32HandleNV");
         }
      }
      #endregion
   }
}
