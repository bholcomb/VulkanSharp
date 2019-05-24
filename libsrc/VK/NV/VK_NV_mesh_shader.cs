using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_mesh_shader = "VK_NV_mesh_shader";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceMeshShaderFeaturesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public Bool32 taskShader;          
         public Bool32 meshShader;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceMeshShaderPropertiesNV 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 maxDrawMeshTasksCount;          
         public UInt32 maxTaskWorkGroupInvocations;          
         public fixed UInt32 maxTaskWorkGroupSize[3];          
         public UInt32 maxTaskTotalMemorySize;          
         public UInt32 maxTaskOutputCount;          
         public UInt32 maxMeshWorkGroupInvocations;          
         public fixed UInt32 maxMeshWorkGroupSize[3];          
         public UInt32 maxMeshTotalMemorySize;          
         public UInt32 maxMeshOutputVertices;          
         public UInt32 maxMeshOutputPrimitives;          
         public UInt32 maxMeshMultiviewViewCount;          
         public UInt32 meshOutputPerVertexGranularity;          
         public UInt32 meshOutputPerPrimitiveGranularity;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DrawMeshTasksIndirectCommandNV 
      {
         public UInt32 taskCount;          
         public UInt32 firstTask;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdDrawMeshTasksNV(VkCommandBuffer commandBuffer, uint32_t taskCount, uint32_t firstTask);
      //void vkCmdDrawMeshTasksIndirectNV(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, uint32_t drawCount, uint32_t stride);
      //void vkCmdDrawMeshTasksIndirectCountNV(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkBuffer countBuffer, VkDeviceSize countBufferOffset, uint32_t maxDrawCount, uint32_t stride);
      
      //delegate definitions
      public delegate void CmdDrawMeshTasksNVDelegate(CommandBuffer commandBuffer, UInt32 taskCount, UInt32 firstTask);
      public delegate void CmdDrawMeshTasksIndirectNVDelegate(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
      public delegate void CmdDrawMeshTasksIndirectCountNVDelegate(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, Buffer countBuffer, DeviceSize countBufferOffset, UInt32 maxDrawCount, UInt32 stride);
      
      //delegate instances
      public static CmdDrawMeshTasksNVDelegate CmdDrawMeshTasksNV;
      public static CmdDrawMeshTasksIndirectNVDelegate CmdDrawMeshTasksIndirectNV;
      public static CmdDrawMeshTasksIndirectCountNVDelegate CmdDrawMeshTasksIndirectCountNV;
      #endregion

      #region interop
      public static class NV_mesh_shader
      {
         public static void init(VK.Device device)
         {
            VK.CmdDrawMeshTasksNV = ExternalFunction.getDeviceFunction<VK.CmdDrawMeshTasksNVDelegate>(device, "vkCmdDrawMeshTasksNV");
            VK.CmdDrawMeshTasksIndirectNV = ExternalFunction.getDeviceFunction<VK.CmdDrawMeshTasksIndirectNVDelegate>(device, "vkCmdDrawMeshTasksIndirectNV");
            VK.CmdDrawMeshTasksIndirectCountNV = ExternalFunction.getDeviceFunction<VK.CmdDrawMeshTasksIndirectCountNVDelegate>(device, "vkCmdDrawMeshTasksIndirectCountNV");
         }
      }
      #endregion
   }
}
