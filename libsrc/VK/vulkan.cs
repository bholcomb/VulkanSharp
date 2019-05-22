using System;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Vulkan
{
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct Instance { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct PhysicalDevice { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Device { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Queue { public IntPtr native; }
      [StructLayout(LayoutKind.Sequential)] public struct Semaphore { public UInt64 native; }
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
      //vulkan 1.1
      [StructLayout(LayoutKind.Sequential)] public struct SamplerYcbcrConversion { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DescriptorUpdateTemplate { public UInt64 native; }

      #endregion

      #region allocation callback functions
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate IntPtr AllocationFunction(IntPtr userData, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate IntPtr ReallocationFunction(IntPtr userData, IntPtr original, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate IntPtr FreeFunction(IntPtr userData, IntPtr memory);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate IntPtr InternalAllocationNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate IntPtr InternalFreeNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
      #endregion
   }

	#region Extension and Layer Names
	public partial class InstanceExtensions
	{
      //these are populated by the extensions in the extensions folder
   }

   public partial class InstanceLayers
	{
		public const string VK_LAYER_LUNARG_standard_validation = "VK_LAYER_LUNARG_standard_validation";
	}

	public partial class DeviceExtensions
	{
		//these are populated by the extensions in the extensions folder
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
		private IntPtr loadDll(String dllName)
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

         return myDllPtr;
		}

		private IntPtr loadSystemDll(String dllName)
		{
			myDllPtr = LoadLibrary(dllName);

         return myDllPtr;
		}

		/// <summary>
		/// Frees previously loaded dll, from process memory.
		/// </summary>
		private IntPtr UnloadDll()
		{
			if (myDllPtr != IntPtr.Zero)
			{
				bool success = FreeLibrary(myDllPtr);
				if (success)
					myDllPtr = IntPtr.Zero;
			}

         return IntPtr.Zero;
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
      //vulkan 1.1
      public const UInt32 MAX_DEVICE_GROUP_SIZE = 32;
      public const UInt32 LUID_SIZE = 8;
      public const UInt32 QUEUE_FAMILY_EXTERNAL = (~0U - 1);
      #endregion
   }

}