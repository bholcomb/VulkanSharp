using System;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Vulkan
{
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct Instance { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct PhysicalDevice { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Device { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Queue { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Semaphore { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct CommandBuffer { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Fence { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DeviceMemory { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Buffer { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Image { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Event { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct QueryPool { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct BufferView { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct ImageView { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct ShaderModule { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct PipelineCache { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct PipelineLayout { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct RenderPass { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Pipeline { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DescriptorSetLayout { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Sampler { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DescriptorPool { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DescriptorSet { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct Framebuffer { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct CommandPool { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct SamplerYcbcrConversion { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DescriptorUpdateTemplate { public UInt64 native; }
      #endregion 
   }
}
