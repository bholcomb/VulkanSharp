using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_semaphore_fd = "VK_KHR_external_semaphore_fd";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportSemaphoreFdInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Semaphore semaphore;          
         public SemaphoreImportFlags flags;          
         public ExternalSemaphoreHandleTypeFlags handleType;          
         public int fd;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SemaphoreGetFdInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Semaphore semaphore;          
         public ExternalSemaphoreHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkImportSemaphoreFdKHR(VkDevice device, VkImportSemaphoreFdInfoKHR* pImportSemaphoreFdInfo);
      //VkResult vkGetSemaphoreFdKHR(VkDevice device, VkSemaphoreGetFdInfoKHR* pGetFdInfo, int* pFd);
      
      //delegate definitions
      public delegate Result ImportSemaphoreFdKHRDelegate(Device device, ref ImportSemaphoreFdInfoKHR pImportSemaphoreFdInfo);
      public delegate Result GetSemaphoreFdKHRDelegate(Device device, ref SemaphoreGetFdInfoKHR pGetFdInfo, ref int pFd);
      
      //delegate instances
      public static ImportSemaphoreFdKHRDelegate ImportSemaphoreFdKHR;
      public static GetSemaphoreFdKHRDelegate GetSemaphoreFdKHR;
      #endregion

      #region interop
      public static class VK_KHR_external_semaphore_fd
      {
         public static void init(VK.Device device)
         {
            VK.ImportSemaphoreFdKHR = ExternalFunction.getDeviceFunction<VK.ImportSemaphoreFdKHRDelegate>(device, "vkImportSemaphoreFdKHR");
            VK.GetSemaphoreFdKHR = ExternalFunction.getDeviceFunction<VK.GetSemaphoreFdKHRDelegate>(device, "vkGetSemaphoreFdKHR");
         }
      }
      #endregion
   }
}
