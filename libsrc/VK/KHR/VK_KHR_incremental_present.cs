using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_incremental_present = "VK_KHR_incremental_present";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentRegionsKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 swapchainCount;
         public PresentRegionKHR* pRegions;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentRegionKHR 
      {
         public UInt32 rectangleCount;
         public RectLayerKHR* pRectangles;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RectLayerKHR 
      {
         public Offset2D offset;
         public Extent2D extent;
         public UInt32 layer;
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
