using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalBufferPropertiesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceExternalBufferPropertiesKHX(IntPtr physicalDevice, PhysicalDeviceExternalBufferInfoKHX* pExternalBufferInfo, ExternalBufferPropertiesKHX* pExternalBufferProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetMemoryWin32HandleKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetMemoryWin32HandleKHX(IntPtr device, UInt64 memory, ExternalMemoryHandleTypeFlagBitsKHX handleType, IntPtr* pHandle);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetMemoryWin32HandlePropertiesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetMemoryWin32HandlePropertiesKHX(IntPtr device, ExternalMemoryHandleTypeFlagBitsKHX handleType, IntPtr handle, MemoryWin32HandlePropertiesKHX* pMemoryWin32HandleProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetMemoryFdKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetMemoryFdKHX(IntPtr device, UInt64 memory, ExternalMemoryHandleTypeFlagBitsKHX handleType, int* pFd);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetMemoryFdPropertiesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetMemoryFdPropertiesKHX(IntPtr device, ExternalMemoryHandleTypeFlagBitsKHX handleType, int fd, MemoryFdPropertiesKHX* pMemoryFdProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalSemaphorePropertiesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceExternalSemaphorePropertiesKHX(IntPtr physicalDevice, PhysicalDeviceExternalSemaphoreInfoKHX* pExternalSemaphoreInfo, ExternalSemaphorePropertiesKHX* pExternalSemaphoreProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSemaphoreWin32HandleKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSemaphoreWin32HandleKHX(IntPtr device, UInt64 semaphore, ExternalSemaphoreHandleTypeFlagBitsKHX handleType, IntPtr* pHandle);

		[DllImport(VulkanLibrary, EntryPoint = "vkImportSemaphoreWin32HandleKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ImportSemaphoreWin32HandleKHX(IntPtr device, ImportSemaphoreWin32HandleInfoKHX* pImportSemaphoreWin32HandleInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSemaphoreFdKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSemaphoreFdKHX(IntPtr device, UInt64 semaphore, ExternalSemaphoreHandleTypeFlagBitsKHX handleType, int* pFd);

		[DllImport(VulkanLibrary, EntryPoint = "vkImportSemaphoreFdKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ImportSemaphoreFdKHX(IntPtr device, ImportSemaphoreFdInfoKHX* pImportSemaphoreFdInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumeratePhysicalDeviceGroupsKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result EnumeratePhysicalDeviceGroupsKHX(IntPtr instance, UInt32* pPhysicalDeviceGroupCount, PhysicalDeviceGroupPropertiesKHX* pPhysicalDeviceGroupProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceGroupPeerMemoryFeaturesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetDeviceGroupPeerMemoryFeaturesKHX(IntPtr device, UInt32 heapIndex, UInt32 localDeviceIndex, UInt32 remoteDeviceIndex, PeerMemoryFeatureFlagsKHX* pPeerMemoryFeatures);

		[DllImport(VulkanLibrary, EntryPoint = "vkBindBufferMemory2KHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result BindBufferMemory2KHX(IntPtr device, UInt32 bindInfoCount, BindBufferMemoryInfoKHX* pBindInfos);

		[DllImport(VulkanLibrary, EntryPoint = "vkBindImageMemory2KHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result BindImageMemory2KHX(IntPtr device, UInt32 bindInfoCount, BindImageMemoryInfoKHX* pBindInfos);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDeviceMaskKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetDeviceMaskKHX(IntPtr commandBuffer, UInt32 deviceMask);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceGroupPresentCapabilitiesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDeviceGroupPresentCapabilitiesKHX(IntPtr device, DeviceGroupPresentCapabilitiesKHX* pDeviceGroupPresentCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceGroupSurfacePresentModesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDeviceGroupSurfacePresentModesKHX(IntPtr device, UInt64 surface, DeviceGroupPresentModeFlagsKHX* pModes);

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireNextImage2KHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireNextImage2KHX(IntPtr device, AcquireNextImageInfoKHX* pAcquireInfo, UInt32* pImageIndex);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatchBaseKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDispatchBaseKHX(IntPtr commandBuffer, UInt32 baseGroupX, UInt32 baseGroupY, UInt32 baseGroupZ, UInt32 groupCountX, UInt32 groupCountY, UInt32 groupCountZ);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDevicePresentRectanglesKHX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDevicePresentRectanglesKHX(IntPtr physicalDevice, UInt64 surface, UInt32* pRectCount, Rect2D* pRects);
	}
}