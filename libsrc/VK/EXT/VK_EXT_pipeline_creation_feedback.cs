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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum PipelineCreationFeedbackFlagsEXT : int
      {  
         PipelineCreationFeedbackValidBitExt = 1 << 0,
         PipelineCreationFeedbackApplicationPipelineCacheHitBitExt = 1 << 1,
         PipelineCreationFeedbackBasePipelineAccelerationBitExt = 1 << 2,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineCreationFeedbackCreateInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public PipelineCreationFeedbackEXT pPipelineCreationFeedback;
         public UInt32 pipelineStageCreationFeedbackCount;
         public PipelineCreationFeedbackEXT pPipelineStageCreationFeedbacks;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineCreationFeedbackEXT 
      {
         public PipelineCreationFeedbackFlagsEXT flags;
         public UInt64 duration;
      };
      
      #endregion

      //no functions
   }
}
