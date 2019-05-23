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
      public unsafe struct ImageFormatListCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 viewFormatCount;          
         public Format* pViewFormats;          
      };
      
      
      #endregion

      //no functions
   }
}
