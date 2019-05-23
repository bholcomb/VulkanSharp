using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_validation_features = "VK_EXT_validation_features";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum ValidationFeatureEnableEXT : int
      {  
         GpuAssistedExt = 0,
         GpuAssistedReserveBindingSlotExt = 1,
      };
      
      public enum ValidationFeatureDisableEXT : int
      {  
         AllExt = 0,
         ShadersExt = 1,
         ThreadSafetyExt = 2,
         ApiParametersExt = 3,
         ObjectLifetimesExt = 4,
         CoreChecksExt = 5,
         UniqueHandlesExt = 6,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ValidationFeaturesEXT 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 enabledValidationFeatureCount;
         public ValidationFeatureEnableEXT pEnabledValidationFeatures;
         public UInt32 disabledValidationFeatureCount;
         public ValidationFeatureDisableEXT pDisabledValidationFeatures;
      };
      
      #endregion

      //no functions
   }
}
