using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_semaphore_win32 = "VK_KHR_external_semaphore_win32";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportSemaphoreWin32HandleInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Semaphore semaphore;
         public SemaphoreImportFlags flags;
         public ExternalSemaphoreHandleTypeFlags handleType;
         public IntPtr handle;
         public IntPtr name;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportSemaphoreWin32HandleInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public IntPtr pAttributes;
         public UInt32 dwAccess;
         public IntPtr name;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct D3D12FenceSubmitInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 waitSemaphoreValuesCount;
         public UInt64* pWaitSemaphoreValues;
         public UInt32 signalSemaphoreValuesCount;
         public UInt64* pSignalSemaphoreValues;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SemaphoreGetWin32HandleInfoKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Semaphore semaphore;
         public ExternalSemaphoreHandleTypeFlags handleType;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkImportSemaphoreWin32HandleKHR(VkDevice  device, const VkImportSemaphoreWin32HandleInfoKHR *  pImportSemaphoreWin32HandleInfo);
      //VkResult vkGetSemaphoreWin32HandleKHR(VkDevice  device, const VkSemaphoreGetWin32HandleInfoKHR *  pGetWin32HandleInfo, HANDLE *  pHandle);
      
      //delegate definitions
      public delegate Result ImportSemaphoreWin32HandleKHRDelegate(Device device, ref ImportSemaphoreWin32HandleInfoKHR pImportSemaphoreWin32HandleInfos);
      public delegate Result GetSemaphoreWin32HandleKHRDelegate(Device device, ref SemaphoreGetWin32HandleInfoKHR pGetWin32HandleInfo, IntPtr pHandles);
      
      //delegate instances
      public static ImportSemaphoreWin32HandleKHRDelegate ImportSemaphoreWin32HandleKHR;
      public static GetSemaphoreWin32HandleKHRDelegate GetSemaphoreWin32HandleKHR;
      #endregion

      #region interop
      public static class VK_KHR_external_semaphore_win32
      {
         public static void init(VK.Device device)
         {
            VK.ImportSemaphoreWin32HandleKHR = ExternalFunction.getDeviceFunction<VK.ImportSemaphoreWin32HandleKHRDelegate>(device, "vkImportSemaphoreWin32HandleKHR");
            VK.GetSemaphoreWin32HandleKHR = ExternalFunction.getDeviceFunction<VK.GetSemaphoreWin32HandleKHRDelegate>(device, "vkGetSemaphoreWin32HandleKHR");
         }
      }
      #endregion
   }
}
