using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_fence_fd = "VK_KHR_external_fence_fd";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportFenceFdInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Fence fence;          
         public FenceImportFlags flags;          
         public ExternalFenceHandleTypeFlags handleType;          
         public int fd;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FenceGetFdInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Fence fence;          
         public ExternalFenceHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkImportFenceFdKHR(VkDevice device, VkImportFenceFdInfoKHR* pImportFenceFdInfo);
      //VkResult vkGetFenceFdKHR(VkDevice device, VkFenceGetFdInfoKHR* pGetFdInfo, int* pFd);
      
      //delegate definitions
      public delegate Result ImportFenceFdKHRDelegate(Device device, ref ImportFenceFdInfoKHR pImportFenceFdInfo);
      public delegate Result GetFenceFdKHRDelegate(Device device, ref FenceGetFdInfoKHR pGetFdInfo, ref int pFd);
      
      //delegate instances
      public static ImportFenceFdKHRDelegate ImportFenceFdKHR;
      public static GetFenceFdKHRDelegate GetFenceFdKHR;
      #endregion

      #region interop
      public static class VK_KHR_external_fence_fd
      {
         public static void init(VK.Device device)
         {
            VK.ImportFenceFdKHR = ExternalFunction.getDeviceFunction<VK.ImportFenceFdKHRDelegate>(device, "vkImportFenceFdKHR");
            VK.GetFenceFdKHR = ExternalFunction.getDeviceFunction<VK.GetFenceFdKHRDelegate>(device, "vkGetFenceFdKHR");
         }
      }
      #endregion
   }
}
