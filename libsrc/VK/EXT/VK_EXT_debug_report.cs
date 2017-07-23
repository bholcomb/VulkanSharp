using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	#region enums
	public enum DebugReportObjectTypeEXT : int
	{
		Unknown = 0,
		Instance = 1,
		PhysicalDevice = 2,
		Device = 3,
		Queue = 4,
		Semaphore = 5,
		CommandBuffer = 6,
		Fence = 7,
		DeviceMemory = 8,
		Buffer = 9,
		Image = 10,
		Event = 11,
		QueryPool = 12,
		BufferView = 13,
		ImageView = 14,
		ShaderModule = 15,
		PipelineCache = 16,
		PipelineLayout = 17,
		RenderPass = 18,
		Pipeline = 19,
		DescriptorSetLayout = 20,
		Sampler = 21,
		DescriptorPool = 22,
		DescriptorSet = 23,
		Framebuffer = 24,
		CommandPool = 25,
		SurfaceKHR = 26,
		SwapchainKHR = 27,
		DebugReportCallbackEXT = 28,
		DisplayKHR = 29,
		DisplayModeKHR = 30,
		ObjectTableNVX = 31,
		IndirectCommandsLayoutNVX = 32,
		DescriptorUpdateTemplateKHR = 1000085000,
	}
	#endregion

	#region flags
	[Flags]
	public enum DebugReportFlagsEXT : int
	{
		Information = 0x1,
		Warning = 0x2,
		PerformanceWarning = 0x4,
		Error = 0x8,
		Debug = 0x10,
	}
	#endregion

	#region structs
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate Bool32 DebugReportCallbackFunction( DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 _object, IntPtr location, Int32 messageCode, string layerPrefix, string message, IntPtr userData);

	[StructLayout(LayoutKind.Sequential)] public struct DebugReportCallbackEXT { public UInt64 native; }

	[StructLayout(LayoutKind.Sequential)]
	public struct DebugReportCallbackCreateInfoEXT
	{
		public StructureType sType;
		public IntPtr pNext;
		public DebugReportFlagsEXT flags;
		public DebugReportCallbackFunction pfnCallback;
		public IntPtr pUserData;
	}
	#endregion

	#region functions
	//external functions we need to get from the instance
	public delegate Result CreateDebugReportCallbackEXTDelegate(Instance instance, ref DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator, out DebugReportCallbackEXT callback);
	public delegate Result DestroyDebugReportCallbackEXTDelegate(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = null);
	public delegate void DebugReportMessageEXTDelegate(Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 _object, IntPtr location, Int32 messageCode, String pLayerPrefix, String pMessage);

	public static partial class VK
	{
		public static CreateDebugReportCallbackEXTDelegate CreateDebugReportCallbackEXT;

		public static DestroyDebugReportCallbackEXTDelegate DestroyDebugReportCallbackEXT;

		public static DebugReportMessageEXTDelegate DebugReportMessageEXT;
	}

	public static class VK_EXT_debug_report
	{
		public static void init(Instance instance)
		{
			VK.CreateDebugReportCallbackEXT = ExternalFunction.getInstanceFunction<CreateDebugReportCallbackEXTDelegate>(instance, "vkCreateDebugReportCallbackEXT");
			VK.DestroyDebugReportCallbackEXT = ExternalFunction.getInstanceFunction<DestroyDebugReportCallbackEXTDelegate>(instance, "vkDestroyDebugReportCallbackEXT");
			VK.DebugReportMessageEXT = ExternalFunction.getInstanceFunction<DebugReportMessageEXTDelegate>(instance, "vkDebugReportMessageEXT");
		}
	}
	#endregion

	#region interop

	#endregion
}
