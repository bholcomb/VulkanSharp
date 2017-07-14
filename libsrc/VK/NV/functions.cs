using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalImageFormatPropertiesNV", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceExternalImageFormatPropertiesNV(IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ExternalMemoryHandleTypeFlagsNv externalHandleType, ExternalImageFormatPropertiesNv* pExternalImageFormatProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetViewportWScalingNV", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetViewportWScalingNV(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ViewportWScalingNv* pViewportWScalings);

	}
}