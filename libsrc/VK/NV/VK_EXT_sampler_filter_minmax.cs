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
      #region enums
      public enum SamplerReductionModeEXT : int
      {  
         WeightedAverageExt = 0,
         MinExt = 1,
         MaxExt = 2,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SamplerReductionModeCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public SamplerReductionModeEXT reductionMode;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceSamplerFilterMinmaxPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 filterMinmaxSingleComponentFormats;
         public Bool32 filterMinmaxImageComponentMapping;
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
