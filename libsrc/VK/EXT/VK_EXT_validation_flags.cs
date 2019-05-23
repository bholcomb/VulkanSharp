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
      //no handles
      

      #region enums
      public enum ValidationCheckEXT : int
      {  
         AllExt = 0,
         ShadersExt = 1,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ValidationFlagsEXT 
      {
         public StructureType type;  //Must be VK_STRUCTURE_TYPE_VALIDATION_FLAGS_EXT 
         public IntPtr next;          
         public UInt32 disabledValidationCheckCount;  //Number of validation checks to disable 
         public IntPtr /*ValidationCheckEXT* */ pDisabledValidationChecks;  //Validation checks to disable 
      };
      
      
      #endregion

      //no functions
   }
}
