using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	public struct PhysicalDeviceExternalImageFormatInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagBitsKHX HandleType;
	}

	public struct ExternalImageFormatPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryPropertiesKHX ExternalMemoryProperties;
	}

	public struct PhysicalDeviceExternalBufferInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public BufferCreateFlags Flags;
		public BufferUsageFlags Usage;
		public ExternalMemoryHandleTypeFlagBitsKHX HandleType;
	}

	public struct ExternalBufferPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryPropertiesKHX ExternalMemoryProperties;
	}

	public struct PhysicalDeviceIDPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public fixed byte DeviceUuid[16];
		public fixed byte DriverUuid[16];
		public fixed byte DeviceLuid[8];
		public Bool32 DeviceLuidvalid;
	}

	public struct ExternalMemoryImageCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagsKHX HandleTypes;
	}

	public struct ExternalMemoryBufferCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagsKHX HandleTypes;
	}

	public struct ExportMemoryAllocateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagsKHX HandleTypes;
	}

	public struct ImportMemoryWin32HandleInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagBitsKHX HandleType;
		public IntPtr Handle;
	}

	public struct ExportMemoryWin32HandleInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public IntPtr Attributes;
		public UInt32 DwAccess;
		public LPCWSTR Name;
	}

	public struct MemoryWin32HandlePropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MemoryTypeBits;
	}

	public struct ImportMemoryFdInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalMemoryHandleTypeFlagBitsKHX HandleType;
		public int Fd;
	}

	public struct MemoryFdPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MemoryTypeBits;
	}

	public struct Win32KeyedMutexAcquireReleaseInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 AcquireCount;
		public IntPtr AcquireSyncs;
		public IntPtr AcquireKeys;
		public IntPtr AcquireTimeouts;
		public UInt32 ReleaseCount;
		public IntPtr ReleaseSyncs;
		public IntPtr ReleaseKeys;
	}

	public struct PhysicalDeviceExternalSemaphoreInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalSemaphoreHandleTypeFlagBitsKHX HandleType;
	}

	public struct ExternalSemaphorePropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalSemaphoreHandleTypeFlagsKHX ExportFromImportedHandleTypes;
		public ExternalSemaphoreHandleTypeFlagsKHX CompatibleHandleTypes;
		public ExternalSemaphoreFeatureFlagsKHX ExternalSemaphoreFeatures;
	}

	public struct ExportSemaphoreCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public ExternalSemaphoreHandleTypeFlagsKHX HandleTypes;
	}

	public struct ImportSemaphoreWin32HandleInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Semaphore;
		public ExternalSemaphoreHandleTypeFlagsKHX HandleType;
		public IntPtr Handle;
	}

	public struct ExportSemaphoreWin32HandleInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public IntPtr Attributes;
		public UInt32 DwAccess;
		public LPCWSTR Name;
	}

	public struct D3D12FenceSubmitInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 WaitSemaphoreValuesCount;
		public IntPtr WaitSemaphoreValues;
		public UInt32 SignalSemaphoreValuesCount;
		public IntPtr SignalSemaphoreValues;
	}

	public struct ImportSemaphoreFdInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Semaphore;
		public ExternalSemaphoreHandleTypeFlagBitsKHX HandleType;
		public int Fd;
	}

	public struct PhysicalDeviceMultiviewFeaturesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public Bool32 Multiview;
		public Bool32 MultiviewGeometryShader;
		public Bool32 MultiviewTessellationShader;
	}

	public struct PhysicalDeviceMultiviewPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 MaxMultiviewViewCount;
		public UInt32 MaxMultiviewInstanceIndex;
	}

	public struct RenderPassMultiviewCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 SubpassCount;
		public IntPtr ViewMasks;
		public UInt32 DependencyCount;
		public IntPtr ViewOffsets;
		public UInt32 CorrelationMaskCount;
		public IntPtr CorrelationMasks;
	}

	public struct PhysicalDeviceGroupPropertiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 PhysicalDeviceCount;
		public fixed IntPtr PhysicalDevices[32];
		public Bool32 SubsetAllocation;
	}

	public struct MemoryAllocateFlagsInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public MemoryAllocateFlagsKHX Flags;
		public UInt32 DeviceMask;
	}

	public struct BindBufferMemoryInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Buffer;
		public UInt64 Memory;
		public DeviceSize MemoryOffset;
		public UInt32 DeviceIndexCount;
		public IntPtr DeviceIndices;
	}

	public struct BindImageMemoryInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Image;
		public UInt64 Memory;
		public DeviceSize MemoryOffset;
		public UInt32 DeviceIndexCount;
		public IntPtr DeviceIndices;
		public UInt32 SfrrectCount;
		public IntPtr Sfrrects;
	}

	public struct DeviceGroupRenderPassBeginInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 DeviceMask;
		public UInt32 DeviceRenderAreaCount;
		public IntPtr DeviceRenderAreas;
	}

	public struct DeviceGroupCommandBufferBeginInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 DeviceMask;
	}

	public struct DeviceGroupSubmitInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 WaitSemaphoreCount;
		public IntPtr WaitSemaphoreDeviceIndices;
		public UInt32 CommandBufferCount;
		public IntPtr CommandBufferDeviceMasks;
		public UInt32 SignalSemaphoreCount;
		public IntPtr SignalSemaphoreDeviceIndices;
	}

	public struct DeviceGroupBindSparseInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 ResourceDeviceIndex;
		public UInt32 MemoryDeviceIndex;
	}

	public struct DeviceGroupPresentCapabilitiesKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public fixed UInt32 PresentMask[32];
		public DeviceGroupPresentModeFlagsKHX Modes;
	}

	public struct ImageSwapchainCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Swapchain;
	}

	public struct BindImageMemorySwapchainInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Swapchain;
		public UInt32 ImageIndex;
	}

	public struct AcquireNextImageInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt64 Swapchain;
		public UInt64 Timeout;
		public UInt64 Semaphore;
		public UInt64 Fence;
		public UInt32 DeviceMask;
	}

	public struct DeviceGroupPresentInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 SwapchainCount;
		public IntPtr DeviceMasks;
		public DeviceGroupPresentModeFlagBitsKHX Mode;
	}

	public struct DeviceGroupDeviceCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 PhysicalDeviceCount;
		public IntPtr PhysicalDevices;
	}

	public struct DeviceGroupSwapchainCreateInfoKHX
	{
		public StructureType SType;
		public IntPtr Next;
		public DeviceGroupPresentModeFlagsKHX Modes;
	}
}