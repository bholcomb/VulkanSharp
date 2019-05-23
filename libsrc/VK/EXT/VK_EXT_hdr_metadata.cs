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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct HdrMetadataEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public XYColorEXT displayPrimaryRed;  //Display primary's Red 
         public XYColorEXT displayPrimaryGreen;  //Display primary's Green 
         public XYColorEXT displayPrimaryBlue;  //Display primary's Blue 
         public XYColorEXT whitePoint;  //Display primary's Blue 
         public float maxLuminance;  //Display maximum luminance 
         public float minLuminance;  //Display minimum luminance 
         public float maxContentLightLevel;  //Content maximum luminance 
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
      //void vkSetHdrMetadataEXT(VkDevice device, uint32_t swapchainCount, VkSwapchainKHR* pSwapchains, VkHdrMetadataEXT* pMetadata);
      
      //delegate definitions
      public delegate void SetHdrMetadataEXTDelegate(Device device, UInt32 swapchainCount, ref SwapchainKHR pSwapchains, ref HdrMetadataEXT pMetadata);
      
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
