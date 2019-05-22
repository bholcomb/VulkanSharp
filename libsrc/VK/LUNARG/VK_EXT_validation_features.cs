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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ValidationFeaturesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 enabledValidationFeatureCount;
         public ValidationFeatureEnableEXT* pEnabledValidationFeatures;
         public UInt32 disabledValidationFeatureCount;
         public ValidationFeatureDisableEXT* pDisabledValidationFeatures;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
