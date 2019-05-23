using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_scalar_block_layout = "VK_EXT_scalar_block_layout";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceScalarBlockLayoutFeaturesEXT 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 scalarBlockLayout;
      };
      
      #endregion

      //no functions
   }
}
