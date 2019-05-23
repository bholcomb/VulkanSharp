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
      //no handles
      

      //no enums

      //no bitfields

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

      //no functions
   }
}
