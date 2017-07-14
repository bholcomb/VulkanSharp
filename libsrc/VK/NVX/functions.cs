using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCmdProcessCommandsNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdProcessCommandsNVX(IntPtr commandBuffer, CmdProcessCommandsInfoNvx* pProcessCommandsInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdReserveSpaceForCommandsNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdReserveSpaceForCommandsNVX(IntPtr commandBuffer, CmdReserveSpaceForCommandsInfoNvx* pReserveSpaceInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateIndirectCommandsLayoutNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateIndirectCommandsLayoutNVX(IntPtr device, IndirectCommandsLayoutCreateInfoNvx* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pIndirectCommandsLayout);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyIndirectCommandsLayoutNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyIndirectCommandsLayoutNVX(IntPtr device, UInt64 indirectCommandsLayout, AllocationCallbacks* pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateObjectTableNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateObjectTableNVX(IntPtr device, ObjectTableCreateInfoNvx* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pObjectTable);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyObjectTableNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyObjectTableNVX(IntPtr device, UInt64 objectTable, AllocationCallbacks* pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkRegisterObjectsNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result RegisterObjectsNVX(IntPtr device, UInt64 objectTable, UInt32 objectCount, ObjectTableEntryNvx* ppObjectTableEntries, UInt32* pObjectIndices);

		[DllImport(VulkanLibrary, EntryPoint = "vkUnregisterObjectsNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result UnregisterObjectsNVX(IntPtr device, UInt64 objectTable, UInt32 objectCount, ObjectEntryTypeNvx* pObjectEntryTypes, UInt32* pObjectIndices);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceGeneratedCommandsPropertiesNVX(IntPtr physicalDevice, DeviceGeneratedCommandsFeaturesNvx* pFeatures, DeviceGeneratedCommandsLimitsNvx* pLimits);
	}
}