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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportMemoryWin32HandleInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 handleType;
         public IntPtr handle;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportMemoryWin32HandleInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public IntPtr pAttributes;
         public UInt32 dwAccess;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetMemoryWin32HandleNV(VkDevice  device, VkDeviceMemory  memory, VkExternalMemoryHandleTypeFlagsNV  handleType, HANDLE *  pHandle);
      
      //delegate definitions
      public delegate Result GetMemoryWin32HandleNVDelegate(Device device, DeviceMemory memory, UInt32 handleType, ref IntPtr pHandles);
      
      //delegate instances
      public static GetMemoryWin32HandleNVDelegate GetMemoryWin32HandleNV;
      #endregion

      #region interop
      public static class NV_external_memory_win32
      {
         public static void init(VK.Device device)
         {
            VK.GetMemoryWin32HandleNV = ExternalFunction.getDeviceFunction<VK.GetMemoryWin32HandleNVDelegate>(device, "vkGetMemoryWin32HandleNV");
         }
      }
      #endregion
   }
}
