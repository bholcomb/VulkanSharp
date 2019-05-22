using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_memory_priority = "VK_EXT_memory_priority";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMemoryPriorityFeaturesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 memoryPriority;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryPriorityAllocateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public float priority;
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
