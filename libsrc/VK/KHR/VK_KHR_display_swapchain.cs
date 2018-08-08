using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums

      #endregion

      #region flags

      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayPresentInfoKHR
      {
         public VK.StructureType SType;
         public IntPtr Next;
         public VK.Rect2D SrcRect;
         public VK.Rect2D DstRect;
         public Bool32 Persistent;
      }
      #endregion

      #region functions

      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR[] pCreateInfos, AllocationCallbacks pAllocator, out SwapchainKHR[] pSwapchains);

   }
   #endregion

   #region interop

   #endregion
}
