using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_fragment_density_map = "VK_EXT_fragment_density_map";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFragmentDensityMapFeaturesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 fragmentDensityMap;          
         public Bool32 fragmentDensityMapDynamic;          
         public Bool32 fragmentDensityMapNonSubsampledImages;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceFragmentDensityMapPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Extent2D minFragmentDensityTexelSize;          
         public Extent2D maxFragmentDensityTexelSize;          
         public Bool32 fragmentDensityInvocations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct RenderPassFragmentDensityMapCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public AttachmentReference fragmentDensityMapAttachment;          
      };
      
      
      #endregion

      //no functions
   }
}
