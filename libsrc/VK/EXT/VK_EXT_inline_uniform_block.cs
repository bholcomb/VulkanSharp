using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_inline_uniform_block = "VK_EXT_inline_uniform_block";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceInlineUniformBlockFeaturesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 inlineUniformBlock;          
         public Bool32 descriptorBindingInlineUniformBlockUpdateAfterBind;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceInlineUniformBlockPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxInlineUniformBlockSize;          
         public UInt32 maxPerStageDescriptorInlineUniformBlocks;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;          
         public UInt32 maxDescriptorSetInlineUniformBlocks;          
         public UInt32 maxDescriptorSetUpdateAfterBindInlineUniformBlocks;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct WriteDescriptorSetInlineUniformBlockEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 dataSize;          
         public IntPtr pData;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorPoolInlineUniformBlockCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxInlineUniformBlockBindings;          
      };
      
      
      #endregion

      //no functions
   }
}
