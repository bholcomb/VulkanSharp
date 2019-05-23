using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NVX_multiview_per_view_attributes = "VK_NVX_multiview_per_view_attributes";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMultiviewPerViewAttributesPropertiesNVX 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 perViewPositionAllComponents;          
      };
      
      
      #endregion

      //no functions
   }
}
