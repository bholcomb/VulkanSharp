using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_dedicated_allocation = "VK_NV_dedicated_allocation";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationImageCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 dedicatedAllocation;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationBufferCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 dedicatedAllocation;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationMemoryAllocateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Image image;
         public Buffer buffer;
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
