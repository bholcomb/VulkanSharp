using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_rasterization_order = "VK_AMD_rasterization_order";
   };
   
   public static partial class VK
   {
      #region enums
      public enum RasterizationOrderAMD : int
      {  
         StrictAmd = 0,
         RelaxedAmd = 1,
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationStateRasterizationOrderAMD 
      {
         public StructureType sType;
         public IntPtr pNext;
         public RasterizationOrderAMD rasterizationOrder;
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
