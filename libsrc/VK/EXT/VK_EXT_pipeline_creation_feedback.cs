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
         ValidBitExt = 1 << 0,
         ApplicationPipelineCacheHitBitExt = 1 << 1,
         BasePipelineAccelerationBitExt = 1 << 2,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PipelineCreationFeedbackCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public PipelineCreationFeedbackEXT* pPipelineCreationFeedback;  //Output pipeline creation feedback. 
         public UInt32 pipelineStageCreationFeedbackCount;          
         public PipelineCreationFeedbackEXT* pPipelineStageCreationFeedbacks;  //One entry for each shader stage specified in the parent Vk*PipelineCreateInfo struct 
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
