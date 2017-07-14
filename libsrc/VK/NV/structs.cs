using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DedicatedAllocationImageCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 DedicatedAllocation;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DedicatedAllocationBufferCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 DedicatedAllocation;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DedicatedAllocationMemoryAllocateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Image;
		public UInt64 Buffer;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ExternalMemoryImageCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagsNv HandleTypes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ExportMemoryAllocateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagsNv HandleTypes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineViewportWScalingStateCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 ViewportWscalingEnable;
		public UInt32 ViewportCount;
		public IntPtr ViewportWscalings;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineViewportSwizzleStateCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 ViewportCount;
		public IntPtr ViewportSwizzles;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineCoverageToColorStateCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public Bool32 CoverageToColorEnable;
		public UInt32 CoverageToColorLocation;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineCoverageModulationStateCreateInfoNv
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public CoverageModulationModeNv CoverageModulationMode;
		public Bool32 CoverageModulationTableEnable;
		public UInt32 CoverageModulationTableCount;
		public IntPtr CoverageModulationTable;
	}
}