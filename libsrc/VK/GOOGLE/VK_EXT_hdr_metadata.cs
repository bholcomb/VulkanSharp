using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_hdr_metadata = "VK_EXT_hdr_metadata";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct HdrMetadataEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public XYColorEXT displayPrimaryRed;
         public XYColorEXT displayPrimaryGreen;
         public XYColorEXT displayPrimaryBlue;
         public XYColorEXT whitePoint;
         public float maxLuminance;
         public float minLuminance;
         public float maxContentLightLevel;
         public float maxFrameAverageLightLevel;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct XYColorEXT 
      {
         public float x;
         public float y;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkSetHdrMetadataEXT(VkDevice  device, uint32_t  swapchainCount, const VkSwapchainKHR *  pSwapchains, const VkHdrMetadataEXT *  pMetadata);
      
      //delegate definitions
      public delegate void SetHdrMetadataEXTDelegate(Device device, UInt32 swapchainCount, ref SwapchainKHR pSwapchains, ref HdrMetadataEXT pMetadatas);
      
      //delegate instances
      public static SetHdrMetadataEXTDelegate SetHdrMetadataEXT;
      #endregion

      #region interop
      public static class VK_EXT_hdr_metadata
      {
         public static void init(VK.Device device)
         {
            VK.SetHdrMetadataEXT = ExternalFunction.getDeviceFunction<VK.SetHdrMetadataEXTDelegate>(device, "vkSetHdrMetadataEXT");
         }
      }
      #endregion
   }
}
