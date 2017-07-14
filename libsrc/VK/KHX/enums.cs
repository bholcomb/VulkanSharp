using System;

namespace Vulkan
{
	#region enums

	#endregion

	#region flags
	[Flags]
	public enum ExternalMemoryHandleTypeFlagBitsKHX : int
	{
		ExternalMemoryHandleTypeOpaqueFdBitKhx = 0x1,
		ExternalMemoryHandleTypeOpaqueWin32BitKhx = 0x2,
		ExternalMemoryHandleTypeOpaqueWin32KmtBitKhx = 0x4,
		ExternalMemoryHandleTypeD3D11TextureBitKhx = 0x8,
		ExternalMemoryHandleTypeD3D11TextureKmtBitKhx = 0x10,
		ExternalMemoryHandleTypeD3D12HeapBitKhx = 0x20,
		ExternalMemoryHandleTypeD3D12ResourceBitKhx = 0x40,
	}

	[Flags]
	public enum ExternalMemoryFeatureFlagBitsKHX : int
	{
		ExternalMemoryFeatureDedicatedOnlyBitKhx = 0x1,
		ExternalMemoryFeatureExportableBitKhx = 0x2,
		ExternalMemoryFeatureImportableBitKhx = 0x4,
	}

	[Flags]
	public enum ExternalSemaphoreHandleTypeFlagBitsKHX : int
	{
		ExternalSemaphoreHandleTypeOpaqueFdBitKhx = 0x1,
		ExternalSemaphoreHandleTypeOpaqueWin32BitKhx = 0x2,
		ExternalSemaphoreHandleTypeOpaqueWin32KmtBitKhx = 0x4,
		ExternalSemaphoreHandleTypeD3D12FenceBitKhx = 0x8,
		ExternalSemaphoreHandleTypeFenceFdBitKhx = 0x10,
	}

	[Flags]
	public enum ExternalSemaphoreFeatureFlagBitsKHX : int
	{
		ExternalSemaphoreFeatureExportableBitKhx = 0x1,
		ExternalSemaphoreFeatureImportableBitKhx = 0x2,
	}

	[Flags]
	public enum PeerMemoryFeatureFlagBitsKHX : int
	{
		PeerMemoryFeatureCopySrcBitKhx = 0x1,
		PeerMemoryFeatureCopyDstBitKhx = 0x2,
		PeerMemoryFeatureGenericSrcBitKhx = 0x4,
		PeerMemoryFeatureGenericDstBitKhx = 0x8,
	}

	[Flags]
	public enum MemoryAllocateFlagBitsKHX : int
	{
		MemoryAllocateDeviceMaskBitKhx = 0x1,
	}

	[Flags]
	public enum DeviceGroupPresentModeFlagBitsKHX : int
	{
		DeviceGroupPresentModeLocalBitKhx = 0x1,
		DeviceGroupPresentModeRemoteBitKhx = 0x2,
		DeviceGroupPresentModeSumBitKhx = 0x4,
		DeviceGroupPresentModeLocalMultiDeviceBitKhx = 0x8,
	}
	#endregion
}