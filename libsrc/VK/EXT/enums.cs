using System;

namespace Vulkan
{
	#region enums

	public enum SamplerReductionModeExt : int
	{
		WeightedAverage = 0,
		Min = 1,
		Max = 2,
	}

	public enum BlendOverlapExt : int
	{
		Uncorrelated = 0,
		Disjoint = 1,
		Conjoint = 2,
	}

	public enum DisplayPowerStateExt : int
	{
		Off = 0,
		Suspend = 1,
		On = 2,
	}

	public enum DeviceEventTypeExt : int
	{
		DisplayHotplug = 0,
	}

	public enum DisplayEventTypeExt : int
	{
		FirstPixelOut = 0,
	}

	public enum ValidationCheckExt : int
	{
		All = 0,
		Shaders = 1,
	}

	public enum DiscardRectangleModeExt : int
	{
		Inclusive = 0,
		Exclusive = 1,
	}

	public enum DebugReportObjectTypeExt : int
	{
		Unknown = 0,
		Instance = 1,
		PhysicalDevice = 2,
		Device = 3,
		Queue = 4,
		Semaphore = 5,
		CommandBuffer = 6,
		Fence = 7,
		DeviceMemory = 8,
		Buffer = 9,
		Image = 10,
		Event = 11,
		QueryPool = 12,
		BufferView = 13,
		ImageView = 14,
		ShaderModule = 15,
		PipelineCache = 16,
		PipelineLayout = 17,
		RenderPass = 18,
		Pipeline = 19,
		DescriptorSetLayout = 20,
		Sampler = 21,
		DescriptorPool = 22,
		DescriptorSet = 23,
		Framebuffer = 24,
		CommandPool = 25,
		SurfaceKhr = 26,
		SwapchainKhr = 27,
		DebugReportCallbackExt = 28,
		DisplayKhr = 29,
		DisplayModeKhr = 30,
		ObjectTableNvx = 31,
		IndirectCommandsLayoutNvx = 32,
		DescriptorUpdateTemplateKhr = 1000085000,
	}
	#endregion

	#region flags

	[Flags]
	public enum SurfaceCounterFlagsExt : int
	{
		VblankExt = 0x1,
	}

	[Flags]
	public enum DebugReportFlagsExt : int
	{
		Information = 0x1,
		Warning = 0x2,
		PerformanceWarning = 0x4,
		Error = 0x8,
		Debug = 0x10,
	}
	#endregion
}