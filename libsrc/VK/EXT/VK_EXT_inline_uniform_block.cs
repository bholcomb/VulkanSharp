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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceInlineUniformBlockFeaturesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 inlineUniformBlock;
         public Bool32 descriptorBindingInlineUniformBlockUpdateAfterBind;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceInlineUniformBlockPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 maxInlineUniformBlockSize;
         public UInt32 maxPerStageDescriptorInlineUniformBlocks;
         public UInt32 maxDescriptorSetUpdateAfterBindInlineUniformBlocks;
         public UInt32 maxDescriptorSetInlineUniformBlocks;
         public UInt32 maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct WriteDescriptorSetInlineUniformBlockEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 dataSize;
         public IntPtr pData;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorPoolInlineUniformBlockCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 maxInlineUniformBlockBindings;
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
