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
      public unsafe struct PresentRegionsKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 swapchainCount;  //Copy of VkPresentInfoKHR::swapchainCount 
         public PresentRegionKHR* pRegions;  //The regions that have changed 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PresentRegionKHR 
      {
         public UInt32 rectangleCount;  //Number of rectangles in pRectangles 
         public RectLayerKHR* pRectangles;  //Array of rectangles that have changed in a swapchain's image(s) 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RectLayerKHR 
      {
         public Offset2D offset;  //upper-left corner of a rectangle that has not changed, in pixels of a presentation images 
         public Extent2D extent;  //Dimensions of a rectangle that has not changed, in pixels of a presentation images 
         public UInt32 layer;  //Layer of a swapchain's image(s), for stereoscopic-3D images 
      };
      
      
      #endregion

      //no functions
   }
}
