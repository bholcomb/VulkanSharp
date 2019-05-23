using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_vertex_attribute_divisor = "VK_EXT_vertex_attribute_divisor";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceVertexAttributeDivisorPropertiesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxVertexAttribDivisor;  //max value of vertex attribute divisor 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct VertexInputBindingDivisorDescriptionEXT 
      {
         public UInt32 binding;          
         public UInt32 divisor;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineVertexInputDivisorStateCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 vertexBindingDivisorCount;          
         public VertexInputBindingDivisorDescriptionEXT* pVertexBindingDivisors;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceVertexAttributeDivisorFeaturesEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 vertexAttributeInstanceRateDivisor;          
         public Bool32 vertexAttributeInstanceRateZeroDivisor;          
      };
      
      
      #endregion

      //no functions
   }
}
