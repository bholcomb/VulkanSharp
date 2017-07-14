using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceDisplayPropertiesKHR(IntPtr physicalDevice, UInt32* pPropertyCount, DisplayPropertiesKhr* pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceDisplayPlanePropertiesKHR(IntPtr physicalDevice, UInt32* pPropertyCount, DisplayPlanePropertiesKhr* pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayPlaneSupportedDisplaysKHR(IntPtr physicalDevice, UInt32 planeIndex, UInt32* pDisplayCount, UInt64* pDisplays);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayModePropertiesKHR(IntPtr physicalDevice, UInt64 display, UInt32* pPropertyCount, DisplayModePropertiesKhr* pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDisplayModeKHR(IntPtr physicalDevice, UInt64 display, DisplayModeCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pMode);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetDisplayPlaneCapabilitiesKHR(IntPtr physicalDevice, UInt64 mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKhr* pCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDisplayPlaneSurfaceKHR(IntPtr instance, DisplaySurfaceCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSurface);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateSharedSwapchainsKHR(IntPtr device, UInt32 swapchainCount, SwapchainCreateInfoKhr* pCreateInfos, AllocationCallbacks* pAllocator, UInt64* pSwapchains);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySurfaceKHR(IntPtr instance, UInt64 surface, AllocationCallbacks* pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, UInt64 surface, Bool32* pSupported);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceCapabilitiesKHR(IntPtr physicalDevice, UInt64 surface, SurfaceCapabilitiesKhr* pSurfaceCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceFormatsKHR(IntPtr physicalDevice, UInt64 surface, UInt32* pSurfaceFormatCount, SurfaceFormatKhr* pSurfaceFormats);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfacePresentModesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfacePresentModesKHR(IntPtr physicalDevice, UInt64 surface, UInt32* pPresentModeCount, PresentModeKhr* pPresentModes);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateSwapchainKHR(IntPtr device, SwapchainCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pSwapchain);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySwapchainKHR(IntPtr device, UInt64 swapchain, AllocationCallbacks* pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSwapchainImagesKHR(IntPtr device, UInt64 swapchain, UInt32* pSwapchainImageCount, UInt64* pSwapchainImages);

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireNextImageKHR(IntPtr device, UInt64 swapchain, UInt64 timeout, UInt64 semaphore, UInt64 fence, UInt32* pImageIndex);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueuePresentKHR(IntPtr queue, PresentInfoKhr* pPresentInfo);



		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceFeatures2KHR(IntPtr physicalDevice, PhysicalDeviceFeatures2Khr* pFeatures);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceProperties2KHR(IntPtr physicalDevice, PhysicalDeviceProperties2Khr* pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceFormatProperties2KHR(IntPtr physicalDevice, Format format, FormatProperties2Khr* pFormatProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceImageFormatProperties2KHR(IntPtr physicalDevice, PhysicalDeviceImageFormatInfo2Khr* pImageFormatInfo, ImageFormatProperties2Khr* pImageFormatProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceQueueFamilyProperties2KHR(IntPtr physicalDevice, UInt32* pQueueFamilyPropertyCount, QueueFamilyProperties2Khr* pQueueFamilyProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceMemoryProperties2KHR(IntPtr physicalDevice, PhysicalDeviceMemoryProperties2Khr* pMemoryProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceSparseImageFormatProperties2KHR(IntPtr physicalDevice, PhysicalDeviceSparseImageFormatInfo2Khr* pFormatInfo, UInt32* pPropertyCount, SparseImageFormatProperties2Khr* pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdPushDescriptorSetKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdPushDescriptorSetKHR(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, UInt64 layout, UInt32 set, UInt32 descriptorWriteCount, WriteDescriptorSet* pDescriptorWrites);

		[DllImport(VulkanLibrary, EntryPoint = "vkTrimCommandPoolKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void TrimCommandPoolKHR(IntPtr device, UInt64 commandPool, UInt32 flags);


		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorUpdateTemplateKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDescriptorUpdateTemplateKHR(IntPtr device, DescriptorUpdateTemplateCreateInfoKhr* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pDescriptorUpdateTemplate);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorUpdateTemplateKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyDescriptorUpdateTemplateKHR(IntPtr device, UInt64 descriptorUpdateTemplate, AllocationCallbacks* pAllocator);

		[DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSetWithTemplateKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void UpdateDescriptorSetWithTemplateKHR(IntPtr device, UInt64 descriptorSet, UInt64 descriptorUpdateTemplate, IntPtr pData);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdPushDescriptorSetWithTemplateKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdPushDescriptorSetWithTemplateKHR(IntPtr commandBuffer, UInt64 descriptorUpdateTemplate, UInt64 layout, UInt32 set, IntPtr pData);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainStatusKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSwapchainStatusKHR(IntPtr device, UInt64 swapchain);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilities2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceCapabilities2KHR(IntPtr physicalDevice, PhysicalDeviceSurfaceInfo2Khr* pSurfaceInfo, SurfaceCapabilities2Khr* pSurfaceCapabilities);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceFormats2KHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceFormats2KHR(IntPtr physicalDevice, PhysicalDeviceSurfaceInfo2Khr* pSurfaceInfo, UInt32* pSurfaceFormatCount, SurfaceFormat2Khr* pSurfaceFormats);


	}
}