using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_external_fence_win32 = "VK_KHR_external_fence_win32";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImportFenceWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Fence fence;          
         public FenceImportFlags flags;          
         public ExternalFenceHandleTypeFlags handleType;          
         public IntPtr/*HANDLE*/ handle;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ExportFenceWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public IntPtr/*SECURITY_ATTRIBUTES**/ pAttributes;          
         public UInt32/*DWORD*/ dwAccess;          
         public string/*LPCWSTR*/ name;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FenceGetWin32HandleInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public Fence fence;          
         public ExternalFenceHandleTypeFlags handleType;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkImportFenceWin32HandleKHR(VkDevice device, VkImportFenceWin32HandleInfoKHR* pImportFenceWin32HandleInfo);
      //VkResult vkGetFenceWin32HandleKHR(VkDevice device, VkFenceGetWin32HandleInfoKHR* pGetWin32HandleInfo, HANDLE* pHandle);
      
      //delegate definitions
      public delegate Result ImportFenceWin32HandleKHRDelegate(Device device, ref ImportFenceWin32HandleInfoKHR pImportFenceWin32HandleInfo);
      public delegate Result GetFenceWin32HandleKHRDelegate(Device device, ref FenceGetWin32HandleInfoKHR pGetWin32HandleInfo, ref IntPtr pHandle);
      
      //delegate instances
      public static ImportFenceWin32HandleKHRDelegate ImportFenceWin32HandleKHR;
      public static GetFenceWin32HandleKHRDelegate GetFenceWin32HandleKHR;
      #endregion

      #region interop
      public static class KHR_external_fence_win32
      {
         public static void init(VK.Device device)
         {
            VK.ImportFenceWin32HandleKHR = ExternalFunction.getDeviceFunction<VK.ImportFenceWin32HandleKHRDelegate>(device, "vkImportFenceWin32HandleKHR");
            VK.GetFenceWin32HandleKHR = ExternalFunction.getDeviceFunction<VK.GetFenceWin32HandleKHRDelegate>(device, "vkGetFenceWin32HandleKHR");
         }
      }
      #endregion
   }
}
