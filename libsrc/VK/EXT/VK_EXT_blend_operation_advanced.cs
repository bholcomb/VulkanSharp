using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_blend_operation_advanced = "VK_EXT_blend_operation_advanced";
   };
   
   public static partial class VK
   {
      //no handles
      

      #region enums
      public enum BlendOverlapEXT : int
      {  
         UncorrelatedExt = 0,
         DisjointExt = 1,
         ConjointExt = 2,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceBlendOperationAdvancedFeaturesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 advancedBlendCoherentOperations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceBlendOperationAdvancedPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 advancedBlendMaxColorAttachments;          
         public Bool32 advancedBlendIndependentBlend;          
         public Bool32 advancedBlendNonPremultipliedSrcColor;          
         public Bool32 advancedBlendNonPremultipliedDstColor;          
         public Bool32 advancedBlendCorrelatedOverlap;          
         public Bool32 advancedBlendAllOperations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineColorBlendAdvancedStateCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 srcPremultiplied;          
         public Bool32 dstPremultiplied;          
         public BlendOverlapEXT blendOverlap;          
      };
      
      #endregion

      //no functions
   }
}
