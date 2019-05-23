using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_conservative_rasterization = "VK_EXT_conservative_rasterization";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum ConservativeRasterizationModeEXT : int
      {  
         DisabledExt = 0,
         OverestimateExt = 1,
         UnderestimateExt = 2,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum PipelineRasterizationConservativeStateCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceConservativeRasterizationPropertiesEXT 
      {
         public StructureType sType;
         public void pNext;
         public float primitiveOverestimationSize;
         public float maxExtraPrimitiveOverestimationSize;
         public float extraPrimitiveOverestimationSizeGranularity;
         public Bool32 primitiveUnderestimation;
         public Bool32 conservativePointAndLineRasterization;
         public Bool32 degenerateTrianglesRasterized;
         public Bool32 degenerateLinesRasterized;
         public Bool32 fullyCoveredFragmentShaderInputVariable;
         public Bool32 conservativeRasterizationPostDepthCoverage;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationConservativeStateCreateInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public PipelineRasterizationConservativeStateCreateFlagsEXT flags;
         public ConservativeRasterizationModeEXT conservativeRasterizationMode;
         public float extraPrimitiveOverestimationSize;
      };
      
      #endregion

      //no functions
   }
}
