using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Vulkan
{
	public static partial class VK
	{

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndirectCountAMD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDrawIndirectCountAMD(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt64 countBuffer, DeviceSize countBufferOffset, UInt32 maxDrawCount, UInt32 stride);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndexedIndirectCountAMD", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDrawIndexedIndirectCountAMD(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt64 countBuffer, DeviceSize countBufferOffset, UInt32 maxDrawCount, UInt32 stride);

	}
}