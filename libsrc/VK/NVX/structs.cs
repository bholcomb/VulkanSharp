using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceGeneratedCommandsFeaturesNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 ComputeBindingPointSupport;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceGeneratedCommandsLimitsNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MaxIndirectCommandsLayoutTokenCount;
		public UInt32 MaxObjectEntryCounts;
		public UInt32 MinSequenceCountBufferOffsetAlignment;
		public UInt32 MinSequenceIndexBufferOffsetAlignment;
		public UInt32 MinCommandsTokenBufferOffsetAlignment;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct IndirectCommandsTokenNvx
	{
		public IndirectCommandsTokenTypeNvx TokenType;
		public UInt64 Buffer;
		public DeviceSize Offset;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct IndirectCommandsLayoutCreateInfoNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public PipelineBindPoint PipelineBindPoint;
		public IndirectCommandsLayoutUsageFlagsNvx Flags;
		public UInt32 TokenCount;
		public IntPtr Tokens;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CmdProcessCommandsInfoNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 ObjectTable;
		public UInt64 IndirectCommandsLayout;
		public UInt32 IndirectCommandsTokenCount;
		public IntPtr IndirectCommandsTokens;
		public UInt32 MaxSequencesCount;
		public IntPtr TargetCommandBuffer;
		public UInt64 SequencesCountBuffer;
		public DeviceSize SequencesCountOffset;
		public UInt64 SequencesIndexBuffer;
		public DeviceSize SequencesIndexOffset;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CmdReserveSpaceForCommandsInfoNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 ObjectTable;
		public UInt64 IndirectCommandsLayout;
		public UInt32 MaxSequencesCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTableCreateInfoNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 ObjectCount;
		public IntPtr ObjectEntryTypes;
		public IntPtr ObjectEntryCounts;
		public IntPtr ObjectEntryUsageFlags;
		public UInt32 MaxUniformBuffersPerDescriptor;
		public UInt32 MaxStorageBuffersPerDescriptor;
		public UInt32 MaxStorageImagesPerDescriptor;
		public UInt32 MaxSampledImagesPerDescriptor;
		public UInt32 MaxPipelineLayouts;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTablePipelineEntryNvx
	{
		public ObjectEntryTypeNvx Type;
		public ObjectEntryUsageFlagsNvx Flags;
		public UInt64 Pipeline;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTableDescriptorSetEntryNvx
	{
		public ObjectEntryTypeNvx Type;
		public ObjectEntryUsageFlagsNvx Flags;
		public UInt64 PipelineLayout;
		public UInt64 DescriptorSet;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTableVertexBufferEntryNvx
	{
		public ObjectEntryTypeNvx Type;
		public ObjectEntryUsageFlagsNvx Flags;
		public UInt64 Buffer;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTableIndexBufferEntryNvx
	{
		public ObjectEntryTypeNvx Type;
		public ObjectEntryUsageFlagsNvx Flags;
		public UInt64 Buffer;
		public IndexType IndexType;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ObjectTablePushConstantEntryNvx
	{
		public ObjectEntryTypeNvx Type;
		public ObjectEntryUsageFlagsNvx Flags;
		public UInt64 PipelineLayout;
		public ShaderStageFlags StageFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PhysicalDeviceMultiviewPerViewAttributesPropertiesNvx
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 PerViewPositionAllComponents;
	}
}