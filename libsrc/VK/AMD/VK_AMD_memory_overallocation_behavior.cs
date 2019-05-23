using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_memory_overallocation_behavior = "VK_AMD_memory_overallocation_behavior";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum MemoryOverallocationBehaviorAMD : int
      {  
         DefaultAmd = 0,
         AllowedAmd = 1,
         DisallowedAmd = 2,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceMemoryOverallocationCreateInfoAMD 
      {
         public StructureType sType;
         public void pNext;
         public MemoryOverallocationBehaviorAMD overallocationBehavior;
      };
      
      #endregion

      //no functions
   }
}
