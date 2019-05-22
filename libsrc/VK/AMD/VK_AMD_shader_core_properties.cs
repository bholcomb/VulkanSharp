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
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceShaderCorePropertiesAMD 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 shaderEngineCount;
         public UInt32 shaderArraysPerEngineCount;
         public UInt32 computeUnitsPerShaderArray;
         public UInt32 simdPerComputeUnit;
         public UInt32 wavefrontsPerSimd;
         public UInt32 wavefrontSize;
         public UInt32 sgprsPerSimd;
         public UInt32 minSgprAllocation;
         public UInt32 maxSgprAllocation;
         public UInt32 sgprAllocationGranularity;
         public UInt32 vgprsPerSimd;
         public UInt32 minVgprAllocation;
         public UInt32 maxVgprAllocation;
         public UInt32 vgprAllocationGranularity;
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
