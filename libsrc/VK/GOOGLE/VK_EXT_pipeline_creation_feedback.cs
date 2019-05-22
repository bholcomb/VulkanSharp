using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_pipeline_creation_feedback = "VK_EXT_pipeline_creation_feedback";
   };

   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      [Flags]
      public enum PipelineCreationFeedbackFlagBitsEXT : int
      { 
         ValidBitExt = 1 << 0,
         ApplicationPipelineCacheHitBitExt = 1 << 1,
         BasePipelineAccelerationBitExt = 1 << 2
      }
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineCreationFeedbackCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public PipelineCreationFeedbackEXT* pPipelineCreationFeedback;
         public UInt32 pipelineStageCreationFeedbackCount;
         public PipelineCreationFeedbackEXT* pPipelineStageCreationFeedbacks;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineCreationFeedbackEXT 
      {
         public UInt32 flags;
         public UInt64 duration;
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
