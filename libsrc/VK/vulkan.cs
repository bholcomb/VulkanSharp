using System;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Vulkan
{
	#region handles
	[StructLayout(LayoutKind.Sequential)] public struct Instance { public IntPtr native; }
	[StructLayout(LayoutKind.Sequential)] public struct PhysicalDevice { public IntPtr native; }
	[StructLayout(LayoutKind.Sequential)] public struct Device { public IntPtr native; }
	[StructLayout(LayoutKind.Sequential)] public struct Queue { public IntPtr native; }
	[StructLayout(LayoutKind.Sequential)] public struct Semaphore { public UInt64 native;}
	[StructLayout(LayoutKind.Sequential)] public struct CommandBuffer { public IntPtr native; }
	[StructLayout(LayoutKind.Sequential)] public struct Fence { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct DeviceMemory { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Buffer { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Image { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Event { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct QueryPool { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct BufferView { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct ImageView { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct ShaderModule { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct PipelineCache { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct PipelineLayout { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct RenderPass { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Pipeline { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct DescriptorSetLayout { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Sampler { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct DescriptorPool { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct DescriptorSet { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct Framebuffer { public UInt64 native; }
	[StructLayout(LayoutKind.Sequential)] public struct CommandPool { public UInt64 native; }
	#endregion

	#region allocation callback functions
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr AllocationFunction(IntPtr userData, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr ReallocationFunction(IntPtr userData, IntPtr original, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void FreeFunction(IntPtr userData, IntPtr memory);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void InternalAllocationNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void InternalFreeNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
	#endregion

	#region Extension and Layer Names
	public partial class InstanceExtensions
	{
		public const string VK_KHR_android_surface = "VK_KHR_android_surface";
		public const string VK_KHR_display = "VK_KHR_display";
		public const string VK_KHR_external_fence_capabilities = "VK_KHR_external_fence_capabilities";
		public const string VK_KHR_external_memory_capabilities = "VK_KHR_external_memory_capabilities";
		public const string VK_KHR_external_semaphore_capabilities = "VK_KHR_external_semaphore_capabilities";
		public const string VK_KHR_get_physical_device_properties2 = "VK_KHR_get_physical_device_properties2";
		public const string VK_KHR_get_surface_capabilities2 = "VK_KHR_get_surface_capabilities2";
		public const string VK_KHR_mir_surface = "VK_KHR_mir_surface";
		public const string VK_KHR_surface = "VK_KHR_surface";
		public const string VK_KHR_wayland_surface = "VK_KHR_wayland_surface";
		public const string VK_KHR_win32_surface = "VK_KHR_win32_surface";
		public const string VK_KHR_xcb_surface = "VK_KHR_xcb_surface";
		public const string VK_KHR_xlib_surface = "VK_KHR_xlib_surface";

		public const string VK_KHX_device_group_creation = "VK_KHX_device_group_creation";

		public const string VK_EXT_acquire_xlib_display = "VK_EXT_acquire_xlib_display";
		public const string VK_EXT_debug_report = "VK_EXT_debug_report";
		public const string VK_EXT_direct_mode_display = "VK_EXT_direct_mode_display";
		public const string VK_EXT_display_surface_counter = "VK_EXT_display_surface_counter";
		public const string VK_EXT_swapchain_colorspace = "VK_EXT_swapchain_colorspace";
		public const string VK_EXT_validation_flags = "VK_EXT_validation_flags";

		public const string VK_MVK_ios_surface = "VK_MVK_ios_surface";
		public const string VK_MVK_macos_surface = "VK_MVK_macos_surface";

		public const string VK_NN_vi_surface = "VK_NN_vi_surface";

		public const string VK_NV_external_memory_capabilities = "VK_NV_external_memory_capabilities";
	}

	public partial class InstanceLayers
	{
		public const string VK_LAYER_LUNARG_standard_validation = "VK_LAYER_LUNARG_standard_validation";
	}

	public partial class DeviceExtensions
	{
		public const string VK_KHR_16bit_storage = "VK_KHR_16bit_storage";
		public const string VK_KHR_descriptor_update_template = "VK_KHR_descriptor_update_template";
		public const string VK_KHR_dedicated_allocation = "VK_KHR_dedicated_allocation";
		public const string VK_KHR_display_swapchain = "VK_KHR_display_swapchain";
		public const string VK_KHR_external_fence = "VK_KHR_external_fence";
		public const string VK_KHR_external_fence_fd = "VK_KHR_external_fence_fd";
		public const string VK_KHR_external_fence_win32 = "VK_KHR_external_fence_win32";
		public const string VK_KHR_external_memory = "VK_KHR_external_memory";
		public const string VK_KHR_external_memory_fd = "VK_KHR_external_memory_fd";
		public const string VK_KHR_external_memory_win32 = "VK_KHR_external_memory_win32";
		public const string VK_KHR_external_semaphore = "VK_KHR_external_semaphore";
		public const string VK_KHR_external_semaphore_fd = "VK_KHR_external_semaphore_fd";
		public const string VK_KHR_external_semaphore_win32 = "VK_KHR_external_semaphore_win32";
		public const string VK_KHR_get_memory_requirements2 = "VK_KHR_get_memory_requirements2";
		public const string VK_KHR_incremental_present = "VK_KHR_incremental_present";
		public const string VK_KHR_maintenance1 = "VK_KHR_maintenance1";
		public const string VK_KHR_push_descriptor = "VK_KHR_push_descriptor";
		public const string VK_KHR_sampler_mirror_clamp_to_edge = "VK_KHR_sampler_mirror_clamp_to_edge";
		public const string VK_KHR_shader_draw_parameters = "VK_KHR_shader_draw_parameters";
		public const string VK_KHR_shared_presentable_image = "VK_KHR_shared_presentable_image";
		public const string VK_KHR_storage_buffer_storage_class = "VK_KHR_storage_buffer_storage_class";
		public const string VK_KHR_swapchain = "VK_KHR_swapchain";
		public const string VK_KHR_variable_pointers = "VK_KHR_variable_pointers";
		public const string VK_KHR_win32_keyed_mutex = "VK_KHR_win32_keyed_mutex";

		public const string VK_KHX_device_group = "VK_KHX_device_group";
		public const string VK_KHX_multiview = "VK_KHX_multiview";

		public const string VK_EXT_blend_operation_advanced = "VK_EXT_blend_operation_advanced";
		public const string VK_EXT_debug_marker = "VK_EXT_debug_marker";
		public const string VK_EXT_discard_rectangles = "VK_EXT_discard_rectangles";
		public const string VK_EXT_display_control = "VK_EXT_display_control";
		public const string VK_EXT_hdr_metadata = "VK_EXT_hdr_metadata";
		public const string VK_EXT_sampler_filter_minmax = "VK_EXT_sampler_filter_minmax";
		public const string VK_EXT_shader_subgroup_ballot = "VK_EXT_shader_subgroup_ballot";
		public const string VK_EXT_shader_subgroup_vote = "VK_EXT_shader_subgroup_vote";

		public const string VK_AMD_draw_indirect_count = "VK_AMD_draw_indirect_count";
		public const string VK_AMD_gcn_shader = "VK_AMD_gcn_shader";
		public const string VK_AMD_gpu_shader_half_float = "VK_AMD_gpu_shader_half_float";
		public const string VK_AMD_gpu_shader_int16 = "VK_AMD_gpu_shader_int16";
		public const string VK_AMD_negative_viewport_height = "VK_AMD_negative_viewport_height";
		public const string VK_AMD_rasterization_order = "VK_AMD_rasterization_order";
		public const string VK_AMD_shader_ballot = "VK_AMD_shader_ballot";
		public const string VK_AMD_shader_explicit_vertex_parameter = "VK_AMD_shader_explicit_vertex_parameter";
		public const string VK_AMD_shader_trinary_minmax = "VK_AMD_shader_trinary_minmax";
		public const string VK_AMD_texture_gather_bias_lod = "VK_AMD_texture_gather_bias_lod";

		public const string VK_GOOGLE_display_timing = "VK_GOOGLE_display_timing";

		public const string VK_IMG_filter_cubic = "VK_IMG_filter_cubic";

		public const string VK_NV_clip_space_w_scaling = "VK_NV_clip_space_w_scaling";
		public const string VK_NV_dedicated_allocation = "VK_NV_dedicated_allocation";
		public const string VK_NV_external_memory = "VK_NV_external_memory";
		public const string VK_NV_external_memory_win32 = "VK_NV_external_memory_win32";
		public const string VK_NV_fill_rectangle = "VK_NV_fill_rectangle";
		public const string VK_NV_fragment_coverage_to_color = "VK_NV_fragment_coverage_to_color";
		public const string VK_NV_framebuffer_mixed_samples = "VK_NV_framebuffer_mixed_samples";
		public const string VK_NV_geometry_shader_passthrough = "VK_NV_geometry_shader_passthrough";
		public const string VK_NV_glsl_shader = "VK_NV_glsl_shader";
		public const string VK_NV_sample_mask_override_coverage = "VK_NV_sample_mask_override_coverage";
		public const string VK_NV_viewport_array2 = "VK_NV_viewport_array2";
		public const string VK_NV_viewport_swizzle = "VK_NV_viewport_swizzle";
		public const string VK_NV_win32_keyed_mutex = "VK_NV_win32_keyed_mutex";

		public const string VK_NVX_device_generated_commands = "VK_NVX_device_generated_commands";
		public const string VK_NVX_multiview_per_view_attributes = "VK_NVX_multiview_per_view_attributes";
	}
	#endregion

	#region Helper classes
	public class Version
	{
		public static uint Make(uint major, uint minor, uint patch)
		{
			return (major << 22) | (minor << 12) | patch;
		}

		public static string ToString(uint version)
		{
			return string.Format("{0}.{1}.{2}", version >> 22, (version >> 12) & 0x3ff, version & 0xfff);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Bool32
	{
		UInt32 value;

		public Bool32(bool bValue)
		{
			value = bValue ? 1u : 0;
		}

		public static implicit operator Bool32(bool bValue)
		{
			return new Bool32(bValue);
		}

		public static implicit operator bool(Bool32 bValue)
		{
			return bValue.value == 0 ? false : true;
		}

		public override string ToString()
		{
			bool b = value == 1 ? true : false;
			return b.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceSize
	{
		UInt64 value;

		public static implicit operator DeviceSize(UInt64 iValue)
		{
			return new DeviceSize { value = iValue };
		}

		public static implicit operator DeviceSize(uint iValue)
		{
			return new DeviceSize { value = iValue };
		}

		public static implicit operator DeviceSize(int iValue)
		{
			return new DeviceSize { value = (ulong)iValue };
		}

		public static implicit operator UInt64(DeviceSize size)
		{
			return size.value;
		}
	}

	#endregion

	#region DLL Loading

	public class DllLoader
	{
		IntPtr myDllPtr { get; set; }

		public DllLoader(String dllName)
		{
			loadSystemDll(dllName);
		}

		/// <summary>
		/// Loads a dll into process memory.
		/// </summary>
		/// <param name="lpFileName">Filename to load.</param>
		/// <returns>Pointer to the loaded library.</returns>
		/// <remarks>
		/// This method is used to load a dll into memory, before calling any of it's DllImported methods.
		/// 
		/// This is done to allow loading an x86 version of a dllfor an x86 process, or an x64 version of it
		/// for an x64 process.
		/// </remarks>
		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
		public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]String lpFileName);

		/// <summary>
		/// Frees a previously loaded dll, from process memory.
		/// </summary>
		/// <param name="hModule">Pointer to the previously loaded library (This pointer comes from a call to LoadLibrary).</param>
		/// <returns>Returns true if the library was successfully freed.</returns>
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeLibrary(IntPtr hModule);

		/// <summary>
		/// This method is used to load the dll into memory, before calling any of it's DllImported methods.
		/// 
		/// This is done to allow loading an x86 or x64 version of the dll depending on the process
		/// </summary>
		private void loadDll(String dllName)
		{
			if (myDllPtr == IntPtr.Zero)
			{
				// Retrieve the folder of the OculusWrap.dll.
				string executingAssemblyFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

				string subfolder;

				if (Environment.Is64BitProcess)
					subfolder = "x64";
				else
					subfolder = "x32";

				string filename = Path.Combine(executingAssemblyFolder, subfolder, dllName);

				// Check that the dll file exists.
				bool exists = File.Exists(filename);
				if (!exists)
					throw new DllNotFoundException("Unable to load the file \"" + filename + "\", the file wasn't found.");

				myDllPtr = LoadLibrary(filename);
				if (myDllPtr == IntPtr.Zero)
				{
					int win32Error = Marshal.GetLastWin32Error();
					throw new Win32Exception(win32Error, "Unable to load the file \"" + filename + "\", LoadLibrary reported error code: " + win32Error + ".");
				}
			}
		}

		private void loadSystemDll(String dllName)
		{
			myDllPtr = LoadLibrary(dllName);
		}

		/// <summary>
		/// Frees previously loaded dll, from process memory.
		/// </summary>
		private void UnloadDll()
		{
			if (myDllPtr != IntPtr.Zero)
			{
				bool success = FreeLibrary(myDllPtr);
				if (success)
					myDllPtr = IntPtr.Zero;
			}
		}
	};

	#endregion


	public static partial class VK
	{
		public const string VulkanLibrary = "vulkan-1.dll";
		static DllLoader theDll;

		static VK()
		{
			theDll = new DllLoader(VulkanLibrary);
		}


		#region defines
		public static Semaphore NULL_SEMAPHORE = new Semaphore();
		public static Fence NULL_FENCE = new Fence();

		public const float LOD_CLAMP_NONE = 1000.0f;
		public const UInt32 REMAINING_MIP_LEVELS = (~0U);
		public const UInt32 REMAINING_ARRAY_LAYERS = (~0U);
		public const UInt64 WHOLE_SIZE = (~0UL);
		public const UInt32 ATTACHMENT_UNUSED = (~0U);
		public const UInt32 TRUE = 1;
		public const UInt32 FALSE = 0;
		public const UInt32 QUEUE_FAMILY_IGNORED = (~0U);
		public const UInt32 SUBPASS_EXTERNAL = (~0U);
		public const UInt32 MAX_PHYSICAL_DEVICE_NAME_SIZE = 256;
		public const UInt32 UUID_SIZE = 16;
		public const UInt32 MAX_MEMORY_TYPES = 32;
		public const UInt32 MAX_MEMORY_HEAPS = 16;
		public const UInt32 MAX_EXTENSION_NAME_SIZE = 256;
		public const UInt32 MAX_DESCRIPTION_SIZE = 256;
		#endregion
	}

}