using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_display_native_hdr = "VK_AMD_display_native_hdr";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayNativeHdrSurfaceCapabilitiesAMD 
      {
         public StructureType sType;
         public Bool32 localDimmingSupport;
         public IntPtr pNext;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SwapchainDisplayNativeHdrCreateInfoAMD 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 localDimmingEnable;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkSetLocalDimmingAMD(VkDevice  device, VkSwapchainKHR  swapChain, VkBool32  localDimmingEnable);
      
      //delegate definitions
      public delegate void SetLocalDimmingAMDDelegate(Device device, SwapchainKHR swapChain, Bool32 localDimmingEnables);
      
      //delegate instances
      public static SetLocalDimmingAMDDelegate SetLocalDimmingAMD;
      #endregion

      #region interop
      public static class AMD_display_native_hdr
      {
         public static void init(VK.Device device)
         {
            VK.SetLocalDimmingAMD = ExternalFunction.getDeviceFunction<VK.SetLocalDimmingAMDDelegate>(device, "vkSetLocalDimmingAMD");
         }
      }
      #endregion
   }
}
