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
      public unsafe struct ValidationFeaturesEXT 
      {
         public StructureType sType;  //Must be VK_STRUCTURE_TYPE_VALIDATION_FEATURES_EXT 
         public IntPtr pNext;          
         public UInt32 enabledValidationFeatureCount;  //Number of validation features to enable 
         public IntPtr /*ValidationFeatureEnableEXT* */ pEnabledValidationFeatures;  //Validation features to enable 
         public UInt32 disabledValidationFeatureCount;  //Number of validation features to disable 
         public IntPtr /*ValidationFeatureDisableEXT* */ pDisabledValidationFeatures;  //Validation features to disable 
      };
      
      
      #endregion

      //no functions
   }
}
