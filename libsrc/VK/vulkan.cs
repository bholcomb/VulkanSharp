using System;
using System.Runtime.InteropServices;


namespace Vulkan
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
	#endregion

	#region allocation callback functions
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr AllocationFunction(IntPtr userData, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr ReallocationFunction(IntPtr userData, IntPtr original, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void FreeFunction(IntPtr userData, IntPtr memory);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void InternalAllocationNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void InternalFreeNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
	#region

	#region Helper classes
	public class Version
	{
		public static uint Make(uint major, uint minor, uint patch)
		{
			return (major << 22) | (minor << 12) | patch;
		}

		public static string ToString(uint version)
		{
			return string.Format("{0}.{1}.{2}", version >> 22, (version >> 12) & 0x3ff, version & 0xfff);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Bool32
	{
		UInt32 value;

		public Bool32(bool bValue)
		{
			value = bValue ? 1u : 0;
		}

		public static implicit operator Bool32(bool bValue)
		{
			return new Bool32(bValue);
		}

		public static implicit operator bool(Bool32 bValue)
		{
			return bValue.value == 0 ? false : true;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceSize
	{
		UInt64 value;

		public static implicit operator DeviceSize(UInt64 iValue)
		{
			return new DeviceSize { value = iValue };
		}

		public static implicit operator DeviceSize(uint iValue)
		{
			return new DeviceSize { value = iValue };
		}

		public static implicit operator DeviceSize(int iValue)
		{
			return new DeviceSize { value = (ulong)iValue };
		}

		public static implicit operator UInt64(DeviceSize size)
		{
			return size.value;
		}
	}

	#endregion
}