using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_AMD_shader_info = "VK_AMD_shader_info";
   };
   
   public static partial class VK
   {
      #region enums
      public enum ShaderInfoTypeAMD : int
      {  
         StatisticsAmd = 0,
         BinaryAmd = 1,
         DisassemblyAmd = 2,     
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ShaderResourceUsageAMD 
      {
         public UInt32 numUsedVgprs;
         public UInt32 numUsedSgprs;
         public UInt32 ldsSizePerLocalWorkGroup;
         public UInt32 ldsUsageSizeInBytes;
         public UInt32 scratchMemUsageInBytes;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct ShaderStatisticsInfoAMD 
      {
         public ShaderStageFlags shaderStageMask;
         public ShaderResourceUsageAMD resourceUsage;
         public UInt32 numPhysicalVgprs;
         public UInt32 numPhysicalSgprs;
         public UInt32 numAvailableVgprs;
         public UInt32 numAvailableSgprs;
         public fixed UInt32 computeWorkGroupSize[3];
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetShaderInfoAMD(VkDevice  device, VkPipeline  pipeline, VkShaderStageFlagBits  shaderStage, VkShaderInfoTypeAMD  infoType, size_t *  pInfoSize, void *  pInfo);
      
      //delegate definitions
      public delegate Result GetShaderInfoAMDDelegate(Device device, Pipeline pipeline, ShaderStageFlags shaderStage, ShaderInfoTypeAMD infoType, ref UInt32 pInfoSize, IntPtr pInfos);
      
      //delegate instances
      public static GetShaderInfoAMDDelegate GetShaderInfoAMD;
      #endregion

      #region interop
      public static class AMD_shader_info
      {
         public static void init(VK.Device device)
         {
            VK.GetShaderInfoAMD = ExternalFunction.getDeviceFunction<VK.GetShaderInfoAMDDelegate>(device, "vkGetShaderInfoAMD");
         }
      }
      #endregion
   }
}
