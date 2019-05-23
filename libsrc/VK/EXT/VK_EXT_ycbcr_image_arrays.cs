using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_ycbcr_image_arrays = "VK_EXT_ycbcr_image_arrays";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceYcbcrImageArraysFeaturesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 ycbcrImageArrays;          
      };
      
      #endregion

      //no functions
   }
}
