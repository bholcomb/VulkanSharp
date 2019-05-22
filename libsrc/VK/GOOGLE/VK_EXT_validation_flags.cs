using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_validation_flags = "VK_EXT_validation_flags";
   };
   
   public static partial class VK
   {
      #region enums
      public enum ValidationCheckEXT : int
      {
         AllExt = 0,
         ShadersExt = 1,
      };

      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ValidationFlagsEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 disabledValidationCheckCount;
         public ValidationCheckEXT* pDisabledValidationChecks;
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
