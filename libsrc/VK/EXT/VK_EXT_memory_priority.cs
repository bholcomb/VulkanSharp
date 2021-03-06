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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMemoryPriorityFeaturesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 memoryPriority;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MemoryPriorityAllocateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public float priority;          
      };
      
      
      #endregion

      //no functions
   }
}
