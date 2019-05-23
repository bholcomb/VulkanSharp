using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_image_format_list = "VK_KHR_image_format_list";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageFormatListCreateInfoKHR 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 viewFormatCount;
         public Format pViewFormats;
      };
      
      #endregion

      //no functions
   }
}
