using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_separate_stencil_usage = "VK_EXT_separate_stencil_usage";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ImageStencilUsageCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ImageUsageFlags stencilUsage;          
      };
      
      
      #endregion

      //no functions
   }
}
