using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_representative_fragment_test = "VK_NV_representative_fragment_test";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceRepresentativeFragmentTestFeaturesNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 representativeFragmentTest;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRepresentativeFragmentTestStateCreateInfoNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 representativeFragmentTestEnable;
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
