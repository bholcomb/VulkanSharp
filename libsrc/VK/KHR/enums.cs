using System;

namespace Vulkan
{
	#region enums
	public enum ColorSpaceKhr : int
	{
		SrgbNonlinear = 0,
		DisplayP3NonlinearExt = 1000104001,
		ExtendedSrgbLinearExt = 1000104002,
		DciP3LinearExt = 1000104003,
		DciP3NonlinearExt = 1000104004,
		Bt709LinearExt = 1000104005,
		Bt709NonlinearExt = 1000104006,
		Bt2020LinearExt = 1000104007,
		Hdr10St2084Ext = 1000104008,
		DolbyvisionExt = 1000104009,
		Hdr10HlgExt = 1000104010,
		AdobergbLinearExt = 1000104011,
		AdobergbNonlinearExt = 1000104012,
		PassThroughExt = 1000104013,
	}

	public enum PresentModeKhr : int
	{
		Immediate = 0,
		Mailbox = 1,
		Fifo = 2,
		FifoRelaxed = 3,
		SharedDemandRefresh = 1000111000,
		SharedContinuousRefresh = 1000111001,
	}

	public enum DescriptorUpdateTemplateTypeKhr : int
	{
		DescriptorSet = 0,
		PushDescriptors = 1,
	}

	#endregion

	#region flags
	[Flags]
	public enum SurfaceTransformFlagsKhr : int
	{
		Identity = 0x1,
		Rotate90 = 0x2,
		Rotate180 = 0x4,
		Rotate270 = 0x8,
		HorizontalMirror = 0x10,
		HorizontalMirrorRotate90 = 0x20,
		HorizontalMirrorRotate180 = 0x40,
		HorizontalMirrorRotate270 = 0x80,
		Inherit = 0x100,
	}

	[Flags]
	public enum CompositeAlphaFlagsKhr : int
	{
		Opaque = 0x1,
		PreMultiplied = 0x2,
		PostMultiplied = 0x4,
		Inherit = 0x8,
	}

	[Flags]
	public enum SwapchainCreateFlagsKhr : int
	{
		BindSfrBitKhx = 0x1,
	}

	[Flags]
	public enum DisplayPlaneAlphaFlagsKhr : int
	{
		Opaque = 0x1,
		Global = 0x2,
		PerPixel = 0x4,
		PerPixelPremultiplied = 0x8,
	}

	#endregion
}