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
         public IntPtr pNext;  //Pointer to next structure 
         public float primitiveOverestimationSize;  //The size in pixels the primitive is enlarged at each edge during conservative rasterization 
         public float maxExtraPrimitiveOverestimationSize;  //The maximum additional overestimation the client can specify in the pipeline state 
         public float extraPrimitiveOverestimationSizeGranularity;  //The granularity of extra overestimation sizes the implementations supports between 0 and maxExtraOverestimationSize 
         public Bool32 primitiveUnderestimation;  //true if the implementation supports conservative rasterization underestimation mode 
         public Bool32 conservativePointAndLineRasterization;  //true if conservative rasterization also applies to points and lines 
         public Bool32 degenerateTrianglesRasterized;  //true if degenerate triangles (those with zero area after snap) are rasterized 
         public Bool32 degenerateLinesRasterized;  //true if degenerate lines (those with zero length after snap) are rasterized 
         public Bool32 fullyCoveredFragmentShaderInputVariable;  //true if the implementation supports the FullyCoveredEXT SPIR-V builtin fragment shader input variable 
         public Bool32 conservativeRasterizationPostDepthCoverage;  //true if the implementation supports both conservative rasterization and post depth coverage sample coverage mask 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationConservativeStateCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public PipelineRasterizationConservativeStateCreateFlagsEXT flags;          
         public ConservativeRasterizationModeEXT conservativeRasterizationMode;          
         public float extraPrimitiveOverestimationSize;          
      };
      
      #endregion

      //no functions
   }
}
