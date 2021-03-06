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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportSemaphoreWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Semaphore semaphore;          
         public SemaphoreImportFlags flags;          
         public ExternalSemaphoreHandleTypeFlags handleType;          
         public IntPtr/*HANDLE*/ handle;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ExportSemaphoreWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public IntPtr/*SECURITY_ATTRIBUTES**/ pAttributes;          
         public UInt32/*DWORD*/ dwAccess;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct D3D12FenceSubmitInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 waitSemaphoreValuesCount;          
         public UInt64* pWaitSemaphoreValues;          
         public UInt32 signalSemaphoreValuesCount;          
         public UInt64* pSignalSemaphoreValues;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SemaphoreGetWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Semaphore semaphore;          
         public ExternalSemaphoreHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkImportSemaphoreWin32HandleKHR(VkDevice device, VkImportSemaphoreWin32HandleInfoKHR* pImportSemaphoreWin32HandleInfo);
      //VkResult vkGetSemaphoreWin32HandleKHR(VkDevice device, VkSemaphoreGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle);
      
      //delegate definitions
      public delegate Result ImportSemaphoreWin32HandleKHRDelegate(Device device, ref ImportSemaphoreWin32HandleInfoKHR pImportSemaphoreWin32HandleInfo);
      public delegate Result GetSemaphoreWin32HandleKHRDelegate(Device device, ref SemaphoreGetWin32HandleInfoKHR pGetWin32HandleInfo, ref IntPtr pHandle);
      
      //delegate instances
      public static ImportSemaphoreWin32HandleKHRDelegate ImportSemaphoreWin32HandleKHR;
      public static GetSemaphoreWin32HandleKHRDelegate GetSemaphoreWin32HandleKHR;
      #endregion

      #region interop
      public static class KHR_external_semaphore_win32
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
