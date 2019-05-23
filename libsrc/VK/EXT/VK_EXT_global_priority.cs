using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_global_priority = "VK_EXT_global_priority";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum QueueGlobalPriorityEXT : int
      {  
         LowExt = 128,
         MediumExt = 256,
         HighExt = 512,
         RealtimeExt = 1024,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceQueueGlobalPriorityCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public QueueGlobalPriorityEXT globalPriority;          
      };
      
      
      #endregion

      //no functions
   }
}
