using System;

namespace Vulkan
{
	#region enums
	public enum IndirectCommandsTokenTypeNvx : int
	{
		Pipeline = 0,
		DescriptorSet = 1,
		IndexBuffer = 2,
		VertexBuffer = 3,
		PushConstant = 4,
		DrawIndexed = 5,
		Draw = 6,
		Dispatch = 7,
	}

	public enum ObjectEntryTypeNvx : int
	{
		DescriptorSet = 0,
		Pipeline = 1,
		IndexBuffer = 2,
		VertexBuffer = 3,
		PushConstant = 4,
	}
	#endregion

	#region flags
	[Flags]
	public enum IndirectCommandsLayoutUsageFlagsNvx : int
	{
		UnorderedSequences = 0x1,
		SparseSequences = 0x2,
		EmptyExecutions = 0x4,
		IndexedSequences = 0x8,
	}

	[Flags]
	public enum ObjectEntryUsageFlagsNvx : int
	{
		Graphics = 0x1,
		Compute = 0x2,
	}
	#endregion
}