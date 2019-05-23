using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_filter_cubic = "VK_EXT_filter_cubic";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceImageViewImageFormatInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageViewType imageViewType;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct FilterCubicImageViewImageFormatPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 filterCubic;          
         public Bool32 filterCubicMinmax;          
      };
      
      #endregion

      //no functions
   }
}
