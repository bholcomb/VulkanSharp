using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PipelineRasterizationStateRasterizationOrderAmd
	{
		public StructureType SType;
		public IntPtr Next;
		public RasterizationOrderAmd RasterizationOrder;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct TextureLODGatherFormatPropertiesAmd
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 SupportsTextureGatherLodbiasAmd;
	}
}