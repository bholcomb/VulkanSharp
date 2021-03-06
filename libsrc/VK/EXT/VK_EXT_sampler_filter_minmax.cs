using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_sampler_filter_minmax = "VK_EXT_sampler_filter_minmax";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum SamplerReductionModeEXT : int
      {  
         WeightedAverageExt = 0,
         MinExt = 1,
         MaxExt = 2,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerReductionModeCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public SamplerReductionModeEXT reductionMode;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSamplerFilterMinmaxPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 filterMinmaxSingleComponentFormats;          
         public Bool32 filterMinmaxImageComponentMapping;          
      };
      
      
      #endregion

      //no functions
   }
}
