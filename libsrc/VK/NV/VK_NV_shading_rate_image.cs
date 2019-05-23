using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_shading_rate_image = "VK_NV_shading_rate_image";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum ShadingRatePaletteEntryNV : int
      {  
         NoInvocationsNv = 0,
         _16InvocationsPerPixelNv = 1,
         _8InvocationsPerPixelNv = 2,
         _4InvocationsPerPixelNv = 3,
         _2InvocationsPerPixelNv = 4,
         _1InvocationPerPixelNv = 5,
         _1InvocationPer2x1PixelsNv = 6,
         _1InvocationPer1x2PixelsNv = 7,
         _1InvocationPer2x2PixelsNv = 8,
         _1InvocationPer4x2PixelsNv = 9,
         _1InvocationPer2x4PixelsNv = 10,
         _1InvocationPer4x4PixelsNv = 11,
      };
      
      public enum CoarseSampleOrderTypeNV : int
      {  
         DefaultNv = 0,
         CustomNv = 1,
         PixelMajorNv = 2,
         SampleMajorNv = 3,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ShadingRatePaletteNV 
      {
         public UInt32 shadingRatePaletteEntryCount;
         public ShadingRatePaletteEntryNV pShadingRatePaletteEntries;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineViewportShadingRateImageStateCreateInfoNV 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 shadingRateImageEnable;
         public UInt32 viewportCount;
         public ShadingRatePaletteNV pShadingRatePalettes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShadingRateImageFeaturesNV 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 shadingRateImage;
         public Bool32 shadingRateCoarseSampleOrder;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShadingRateImagePropertiesNV 
      {
         public StructureType sType;
         public void pNext;
         public Extent2D shadingRateTexelSize;
         public UInt32 shadingRatePaletteSize;
         public UInt32 shadingRateMaxCoarseSamples;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CoarseSampleLocationNV 
      {
         public UInt32 pixelX;
         public UInt32 pixelY;
         public UInt32 sample;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CoarseSampleOrderCustomNV 
      {
         public ShadingRatePaletteEntryNV shadingRate;
         public UInt32 sampleCount;
         public UInt32 sampleLocationCount;
         public CoarseSampleLocationNV pSampleLocations;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineViewportCoarseSampleOrderStateCreateInfoNV 
      {
         public StructureType sType;
         public void pNext;
         public CoarseSampleOrderTypeNV sampleOrderType;
         public UInt32 customSampleOrderCount;
         public CoarseSampleOrderCustomNV pCustomSampleOrders;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdBindShadingRateImageNV(VkCommandBuffer commandBuffer, VkImageView imageView, VkImageLayout imageLayout);
      //void vkCmdSetViewportShadingRatePaletteNV(VkCommandBuffer commandBuffer, uint32_t firstViewport, uint32_t viewportCount, VkShadingRatePaletteNV* pShadingRatePalettes);
      //void vkCmdSetCoarseSampleOrderNV(VkCommandBuffer commandBuffer, VkCoarseSampleOrderTypeNV sampleOrderType, uint32_t customSampleOrderCount, VkCoarseSampleOrderCustomNV* pCustomSampleOrders);
      
      //delegate definitions
      public delegate void CmdBindShadingRateImageNVDelegate(CommandBuffer commandBuffer, ImageView imageView, ImageLayout imageLayout);
      public delegate void CmdSetViewportShadingRatePaletteNVDelegate(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ref ShadingRatePaletteNV pShadingRatePalettes);
      public delegate void CmdSetCoarseSampleOrderNVDelegate(CommandBuffer commandBuffer, CoarseSampleOrderTypeNV sampleOrderType, UInt32 customSampleOrderCount, ref CoarseSampleOrderCustomNV pCustomSampleOrders);
      
      //delegate instances
      public static CmdBindShadingRateImageNVDelegate CmdBindShadingRateImageNV;
      public static CmdSetViewportShadingRatePaletteNVDelegate CmdSetViewportShadingRatePaletteNV;
      public static CmdSetCoarseSampleOrderNVDelegate CmdSetCoarseSampleOrderNV;
      #endregion

      #region interop
      public static class VK_NV_shading_rate_image
      {
         public static void init(VK.Device device)
         {
            VK.CmdBindShadingRateImageNV = ExternalFunction.getDeviceFunction<VK.CmdBindShadingRateImageNVDelegate>(device, "vkCmdBindShadingRateImageNV");
            VK.CmdSetViewportShadingRatePaletteNV = ExternalFunction.getDeviceFunction<VK.CmdSetViewportShadingRatePaletteNVDelegate>(device, "vkCmdSetViewportShadingRatePaletteNV");
            VK.CmdSetCoarseSampleOrderNV = ExternalFunction.getDeviceFunction<VK.CmdSetCoarseSampleOrderNVDelegate>(device, "vkCmdSetCoarseSampleOrderNV");
         }
      }
      #endregion
   }
}
