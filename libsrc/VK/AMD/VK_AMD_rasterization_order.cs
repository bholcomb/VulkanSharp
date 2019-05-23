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
      //no handles
      

      #region enums
      public enum RasterizationOrderAMD : int
      {  
         StrictAmd = 0,
         RelaxedAmd = 1,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRasterizationStateRasterizationOrderAMD 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public RasterizationOrderAMD rasterizationOrder;  //Rasterization order to use for the pipeline 
      };
      
      
      #endregion

      //no functions
   }
}
