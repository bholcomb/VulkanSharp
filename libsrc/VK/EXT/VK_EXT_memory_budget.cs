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
         public void pNext;
         public DeviceSize heapBudget;
         public DeviceSize heapUsage;
      };
      
      #endregion

      //no functions
   }
}
