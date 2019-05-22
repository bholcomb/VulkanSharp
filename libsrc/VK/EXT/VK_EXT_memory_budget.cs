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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceMemoryBudgetPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)VK.MAX_MEMORY_HEAPS)]
         public DeviceSize[] heapBudget;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)VK.MAX_MEMORY_HEAPS)]
         public DeviceSize[] heapUsage;
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
