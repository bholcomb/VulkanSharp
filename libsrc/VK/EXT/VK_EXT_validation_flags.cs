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
      public struct ValidationFlagsEXT 
      {
         public StructureType sType;
         public void pNext;
         public UInt32 disabledValidationCheckCount;
         public ValidationCheckEXT pDisabledValidationChecks;
      };
      
      #endregion

      //no functions
   }
}
