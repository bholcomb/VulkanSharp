using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_external_memory = "VK_NV_external_memory";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExternalMemoryImageCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ExternalMemoryHandleTypeFlagsNV handleTypes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ExportMemoryAllocateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ExternalMemoryHandleTypeFlagsNV handleTypes;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
