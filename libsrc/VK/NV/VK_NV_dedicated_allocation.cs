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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationImageCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 dedicatedAllocation;  //Whether this image uses a dedicated allocation 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationBufferCreateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 dedicatedAllocation;  //Whether this buffer uses a dedicated allocation 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DedicatedAllocationMemoryAllocateInfoNV 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Image image;  //Image that this allocation will be bound to 
         public Buffer buffer;  //Buffer that this allocation will be bound to 
      };
      
      #endregion

      //no functions
   }
}
