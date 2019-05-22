using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_viewport_swizzle = "VK_NV_viewport_swizzle";
   };
   
   public static partial class VK
   {
      #region enums
      public enum ViewportCoordinateSwizzleNV : int
      {  
         PositiveXNv = 0,
         NegativeXNv = 1,
         PositiveYNv = 2,
         NegativeYNv = 3,
         PositiveZNv = 4,
         NegativeZNv = 5,
         PositiveWNv = 6,
         NegativeWNv = 7,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ViewportSwizzleNV 
      {
         public ViewportCoordinateSwizzleNV x;
         public ViewportCoordinateSwizzleNV y;
         public ViewportCoordinateSwizzleNV z;
         public ViewportCoordinateSwizzleNV w;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineViewportSwizzleStateCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public UInt32 viewportCount;
         public ViewportSwizzleNV* pViewportSwizzles;
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
