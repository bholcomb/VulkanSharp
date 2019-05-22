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
      #region enums
      public enum ConservativeRasterizationModeEXT : int
      {  
         DisabledExt = 0,
         OverestimateExt = 1,
         UnderestimateExt = 2,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceConservativeRasterizationPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public float primitiveOverestimationSize;
         public float maxExtraPrimitiveOverestimationSize;
         public float extraPrimitiveOverestimationSizeGranularity;
         public Bool32 primitiveUnderestimation;
         public Bool32 conservativePointAndLineRasterization;
         public Bool32 degenerateTrianglesRasterized;
         public Bool32 conservativeRasterizationPostDepthCoverage;
         public Bool32 fullyCoveredFragmentShaderInputVariable;
         public Bool32 degenerateLinesRasterized;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationConservativeStateCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public ConservativeRasterizationModeEXT conservativeRasterizationMode;
         public float extraPrimitiveOverestimationSize;
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
