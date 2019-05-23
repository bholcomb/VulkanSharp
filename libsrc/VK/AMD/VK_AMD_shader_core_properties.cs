using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_shader_core_properties = "VK_AMD_shader_core_properties";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShaderCorePropertiesAMD 
      {
         public StructureType sType;          
         public IntPtr pNext;  //Pointer to next structure 
         public UInt32 shaderEngineCount;  //number of shader engines 
         public UInt32 shaderArraysPerEngineCount;  //number of shader arrays 
         public UInt32 computeUnitsPerShaderArray;  //number of CUs per shader array 
         public UInt32 simdPerComputeUnit;  //number of SIMDs per compute unit 
         public UInt32 wavefrontsPerSimd;  //number of wavefront slots in each SIMD 
         public UInt32 wavefrontSize;  //number of threads per wavefront 
         public UInt32 sgprsPerSimd;  //number of physical SGPRs per SIMD 
         public UInt32 minSgprAllocation;  //minimum number of SGPRs that can be allocated by a wave 
         public UInt32 maxSgprAllocation;  //number of available SGPRs 
         public UInt32 sgprAllocationGranularity;  //SGPRs are allocated in groups of this size 
         public UInt32 vgprsPerSimd;  //number of physical VGPRs per SIMD 
         public UInt32 minVgprAllocation;  //minimum number of VGPRs that can be allocated by a wave 
         public UInt32 maxVgprAllocation;  //number of available VGPRs 
         public UInt32 vgprAllocationGranularity;  //VGPRs are allocated in groups of this size 
      };
      
      
      #endregion

      //no functions
   }
}
