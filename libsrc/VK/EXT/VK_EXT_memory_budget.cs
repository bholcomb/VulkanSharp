using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_memory_budget = "VK_EXT_memory_budget";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMemoryBudgetPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public fixed DeviceSize heapBudget[(int)VK.MAX_MEMORY_HEAPS];          
         public fixed DeviceSize heapUsage[(int)VK.MAX_MEMORY_HEAPS];          
      };
      
      #endregion

      //no functions
   }
}
