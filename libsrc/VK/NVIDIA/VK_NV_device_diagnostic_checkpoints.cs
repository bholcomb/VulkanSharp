using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_device_diagnostic_checkpoints = "VK_NV_device_diagnostic_checkpoints";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct QueueFamilyCheckpointPropertiesNV 
      {
         public StructureType sType;
         public PipelineStageFlags checkpointExecutionStageMask;
         public IntPtr pNext;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CheckpointDataNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public PipelineStageFlags stage;
         public IntPtr pCheckpointMarker;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdSetCheckpointNV(VkCommandBuffer  commandBuffer, const void *  pCheckpointMarker);
      //void vkGetQueueCheckpointDataNV(VkQueue  queue, uint32_t *  pCheckpointDataCount, VkCheckpointDataNV *  pCheckpointData);
      
      //delegate definitions
      public delegate void CmdSetCheckpointNVDelegate(CommandBuffer commandBuffer, IntPtr pCheckpointMarkers);
      public delegate void GetQueueCheckpointDataNVDelegate(Queue queue, ref UInt32 pCheckpointDataCount, ref CheckpointDataNV pCheckpointDatas);
      
      //delegate instances
      public static CmdSetCheckpointNVDelegate CmdSetCheckpointNV;
      public static GetQueueCheckpointDataNVDelegate GetQueueCheckpointDataNV;
      #endregion

      #region interop
      public static class NV_device_diagnostic_checkpoints
      {
         public static void init(VK.Device device)
         {
            VK.CmdSetCheckpointNV = ExternalFunction.getDeviceFunction<VK.CmdSetCheckpointNVDelegate>(device, "vkCmdSetCheckpointNV");
            VK.GetQueueCheckpointDataNV = ExternalFunction.getDeviceFunction<VK.GetQueueCheckpointDataNVDelegate>(device, "vkGetQueueCheckpointDataNV");
         }
      }
      #endregion
   }
}