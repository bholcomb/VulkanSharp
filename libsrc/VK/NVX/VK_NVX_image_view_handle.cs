using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NVX_image_view_handle = "VK_NVX_image_view_handle";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageViewHandleInfoNVX 
      {
         public StructureType sType;
         public void pNext;
         public ImageView imageView;
         public DescriptorType descriptorType;
         public Sampler sampler;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //uint32_t vkGetImageViewHandleNVX(VkDevice device, VkImageViewHandleInfoNVX* pInfo);
      
      //delegate definitions
      public delegate UInt32 GetImageViewHandleNVXDelegate(Device device, ref ImageViewHandleInfoNVX pInfo);
      
      //delegate instances
      public static GetImageViewHandleNVXDelegate GetImageViewHandleNVX;
      #endregion

      #region interop
      public static class VK_NVX_image_view_handle
      {
         public static void init(VK.Device device)
         {
            VK.GetImageViewHandleNVX = ExternalFunction.getDeviceFunction<VK.GetImageViewHandleNVXDelegate>(device, "vkGetImageViewHandleNVX");
         }
      }
      #endregion
   }
}
