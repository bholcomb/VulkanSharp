using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_framebuffer_mixed_samples = "VK_NV_framebuffer_mixed_samples";
   };
   
   public static partial class VK
   {
      #region enums
      public enum CoverageModulationModeNV : int
      {  
         NoneNv = 0,
         RgbNv = 1,
         AlphaNv = 2,
         RgbaNv = 3,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineCoverageModulationStateCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public CoverageModulationModeNV coverageModulationMode;
         public Bool32 coverageModulationTableEnable;
         public UInt32 coverageModulationTableCount;
         public float* pCoverageModulationTable;
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
