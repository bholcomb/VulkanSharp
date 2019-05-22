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
      #region enums
      public enum QueueGlobalPriorityEXT : int
      {  
         LowExt = 128,
         MediumExt = 256,
         HighExt = 512,
         RealtimeExt = 1024,
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DeviceQueueGlobalPriorityCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public QueueGlobalPriorityEXT globalPriority;
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
