using System;

namespace Vulkan
{
	#region enums

	public enum ViewportCoordinateSwizzleNv : int
	{
		PositiveX = 0,
		NegativeX = 1,
		PositiveY = 2,
		NegativeY = 3,
		PositiveZ = 4,
		NegativeZ = 5,
		PositiveW = 6,
		NegativeW = 7,
	}

	public enum CoverageModulationModeNv : int
	{
		None = 0,
		Rgb = 1,
		Alpha = 2,
		Rgba = 3,
	}
	#endregion

	#region flags

	[Flags]
	public enum ExternalMemoryHandleTypeFlagsNv : int
	{
		OpaqueWin32 = 0x1,
		OpaqueWin32Kmt = 0x2,
		D3D11Image = 0x4,
		D3D11ImageKmt = 0x8,
	}

	[Flags]
	public enum ExternalMemoryFeatureFlagsNv : int
	{
		DedicatedOnly = 0x1,
		Exportable = 0x2,
		Importable = 0x4,
	}
	#endregion





}