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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceRepresentativeFragmentTestFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 representativeFragmentTest;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineRepresentativeFragmentTestStateCreateInfoNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 representativeFragmentTestEnable;          
      };
      
      
      #endregion

      //no functions
   }
}
