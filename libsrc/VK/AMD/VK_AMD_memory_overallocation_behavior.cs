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
      #region enums
      public enum MemoryOverallocationBehaviorAMD : int
      {  
         DefaultAmd = 0,
         AllowedAmd = 1,
         DisallowedAmd = 2,
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceMemoryOverallocationCreateInfoAMD 
      {
         public StructureType sType;
         public IntPtr pNext;
         public MemoryOverallocationBehaviorAMD overallocationBehavior;
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
