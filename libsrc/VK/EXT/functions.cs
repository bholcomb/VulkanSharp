using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		public unsafe delegate Result CreateDebugReportCallbackEXT(IntPtr instance, DebugReportCallbackCreateInfoExt* pCreateInfo, AllocationCallbacks* pAllocator, UInt64* pCallback);

		public unsafe delegate void DestroyDebugReportCallbackEXT(IntPtr instance, UInt64 callback, AllocationCallbacks* pAllocator);

		public unsafe delegate void DebugReportMessageEXT(IntPtr instance, DebugReportFlagsExt flags, DebugReportObjectTypeExt objectType, UInt64 @object, UIntPtr location, Int32 messageCode, string pLayerPrefix, string pMessage);

		[DllImport(VulkanLibrary, EntryPoint = "vkDebugMarkerSetObjectNameEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result DebugMarkerSetObjectNameEXT(IntPtr device, DebugMarkerObjectNameInfoExt* pNameInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkDebugMarkerSetObjectTagEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result DebugMarkerSetObjectTagEXT(IntPtr device, DebugMarkerObjectTagInfoExt* pTagInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDebugMarkerBeginEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDebugMarkerBeginEXT(IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDebugMarkerEndEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDebugMarkerEndEXT(IntPtr commandBuffer);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDebugMarkerInsertEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDebugMarkerInsertEXT(IntPtr commandBuffer, DebugMarkerMarkerInfoExt* pMarkerInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkReleaseDisplayEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ReleaseDisplayEXT(IntPtr physicalDevice, UInt64 display);

		[DllImport(VulkanLibrary, EntryPoint = "vkAcquireXlibDisplayEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AcquireXlibDisplayEXT(IntPtr physicalDevice, IntPtr* dpy, UInt64 display);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetRandROutputDisplayEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetRandROutputDisplayEXT(IntPtr physicalDevice, IntPtr* dpy, UInt32 rrOutput, UInt64* pDisplay);

		[DllImport(VulkanLibrary, EntryPoint = "vkDisplayPowerControlEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result DisplayPowerControlEXT(IntPtr device, UInt64 display, DisplayPowerInfoExt* pDisplayPowerInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkRegisterDeviceEventEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result RegisterDeviceEventEXT(IntPtr device, DeviceEventInfoExt* pDeviceEventInfo, AllocationCallbacks* pAllocator, UInt64* pFence);

		[DllImport(VulkanLibrary, EntryPoint = "vkRegisterDisplayEventEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result RegisterDisplayEventEXT(IntPtr device, UInt64 display, DisplayEventInfoExt* pDisplayEventInfo, AllocationCallbacks* pAllocator, UInt64* pFence);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetSwapchainCounterEXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetSwapchainCounterEXT(IntPtr device, UInt64 swapchain, SurfaceCounterFlagsExt counter, UInt64* pCounterValue);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilities2EXT", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceSurfaceCapabilities2EXT(IntPtr physicalDevice, UInt64 surface, SurfaceCapabilities2Ext* pSurfaceCapabilities);


		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void vkSetHdrMetadataEXT(IntPtr device, UInt32 swapchainCount, UInt64* pSwapchains, HdrMetadataExt* pMetadata);


		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void vkCmdSetDiscardRectangleEXT(IntPtr commandBuffer, UInt32 firstDiscardRectangle, UInt32 discardRectangleCount, Rect2D* pDiscardRectangles);


	}
}