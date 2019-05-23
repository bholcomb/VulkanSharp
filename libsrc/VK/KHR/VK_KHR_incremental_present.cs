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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentRegionsKHR 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 swapchainCount;
         public PresentRegionKHR pRegions;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentRegionKHR 
      {
         public UInt32 rectangleCount;
         public RectLayerKHR pRectangles;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RectLayerKHR 
      {
         public Offset2D offset;
         public Extent2D extent;
         public UInt32 layer;
      };
      
      #endregion

      //no functions
   }
}
