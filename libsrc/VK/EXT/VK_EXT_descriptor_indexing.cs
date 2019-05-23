using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_descriptor_indexing = "VK_EXT_descriptor_indexing";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum DescriptorBindingFlagsEXT : int
      {  
         DescriptorBindingUpdateAfterBindBitExt = 1 << 0,
         DescriptorBindingUpdateUnusedWhilePendingBitExt = 1 << 1,
         DescriptorBindingPartiallyBoundBitExt = 1 << 2,
         DescriptorBindingVariableDescriptorCountBitExt = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorSetLayoutBindingFlagsCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 bindingCount;          
         public DescriptorBindingFlagsEXT* pBindingFlags;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDescriptorIndexingFeaturesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 shaderInputAttachmentArrayDynamicIndexing;          
         public Bool32 shaderUniformTexelBufferArrayDynamicIndexing;          
         public Bool32 shaderStorageTexelBufferArrayDynamicIndexing;          
         public Bool32 shaderUniformBufferArrayNonUniformIndexing;          
         public Bool32 shaderSampledImageArrayNonUniformIndexing;          
         public Bool32 shaderStorageBufferArrayNonUniformIndexing;          
         public Bool32 shaderStorageImageArrayNonUniformIndexing;          
         public Bool32 shaderInputAttachmentArrayNonUniformIndexing;          
         public Bool32 shaderUniformTexelBufferArrayNonUniformIndexing;          
         public Bool32 shaderStorageTexelBufferArrayNonUniformIndexing;          
         public Bool32 descriptorBindingUniformBufferUpdateAfterBind;          
         public Bool32 descriptorBindingSampledImageUpdateAfterBind;          
         public Bool32 descriptorBindingStorageImageUpdateAfterBind;          
         public Bool32 descriptorBindingStorageBufferUpdateAfterBind;          
         public Bool32 descriptorBindingUniformTexelBufferUpdateAfterBind;          
         public Bool32 descriptorBindingStorageTexelBufferUpdateAfterBind;          
         public Bool32 descriptorBindingUpdateUnusedWhilePending;          
         public Bool32 descriptorBindingPartiallyBound;          
         public Bool32 descriptorBindingVariableDescriptorCount;          
         public Bool32 runtimeDescriptorArray;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDescriptorIndexingPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 maxUpdateAfterBindDescriptorsInAllPools;          
         public Bool32 shaderUniformBufferArrayNonUniformIndexingNative;          
         public Bool32 shaderSampledImageArrayNonUniformIndexingNative;          
         public Bool32 shaderStorageBufferArrayNonUniformIndexingNative;          
         public Bool32 shaderStorageImageArrayNonUniformIndexingNative;          
         public Bool32 shaderInputAttachmentArrayNonUniformIndexingNative;          
         public Bool32 robustBufferAccessUpdateAfterBind;          
         public Bool32 quadDivergentImplicitLod;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindSamplers;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindUniformBuffers;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindStorageBuffers;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindSampledImages;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindStorageImages;          
         public UInt32 maxPerStageDescriptorUpdateAfterBindInputAttachments;          
         public UInt32 maxPerStageUpdateAfterBindResources;          
         public UInt32 maxDescriptorSetUpdateAfterBindSamplers;          
         public UInt32 maxDescriptorSetUpdateAfterBindUniformBuffers;          
         public UInt32 maxDescriptorSetUpdateAfterBindUniformBuffersDynamic;          
         public UInt32 maxDescriptorSetUpdateAfterBindStorageBuffers;          
         public UInt32 maxDescriptorSetUpdateAfterBindStorageBuffersDynamic;          
         public UInt32 maxDescriptorSetUpdateAfterBindSampledImages;          
         public UInt32 maxDescriptorSetUpdateAfterBindStorageImages;          
         public UInt32 maxDescriptorSetUpdateAfterBindInputAttachments;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DescriptorSetVariableDescriptorCountAllocateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 descriptorSetCount;          
         public UInt32* pDescriptorCounts;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DescriptorSetVariableDescriptorCountLayoutSupportEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 maxVariableDescriptorCount;          
      };
      
      
      #endregion

      //no functions
   }
}
