using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
	internal static class Alloc
	{
		internal static IntPtr alloc<T>(T data) where T: struct
		{
			IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data.GetType()));
			Marshal.StructureToPtr(data, ptr, false);
			return ptr;
		}

		internal unsafe static IntPtr* alloc(List<string> data)
		{
			IntPtr* ptr = (IntPtr*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * data.Count);
			for(int i=0; i< data.Count; i++)
			{
				ptr[i] = Marshal.StringToHGlobalAnsi(data[i]);
			}
			return ptr;
		}

		internal unsafe static IntPtr* alloc<T>(List<T> data) where T: struct
		{
			IntPtr* ptr = (IntPtr*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)) * data.Count);
			for (int i = 0; i < data.Count; i++)
			{
				Marshal.StructureToPtr(data[i], ptr[i], false);
			}
			return ptr;
		}

		internal static void free(IntPtr data)
		{
			Marshal.FreeHGlobal(data);
		}

		internal unsafe static void free(IntPtr* data, int count)
		{
			for (int i = 0; i < count; i++)
			{
				Marshal.FreeHGlobal(data[i]);
			}

			Marshal.FreeHGlobal(new IntPtr(data));
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct _InstanceCreateInfo
	{
		public StructureType sType;
		public IntPtr next;
		public UInt32 flags;
		public IntPtr applicationInfo;

		public UInt32 enabledLayerCount;
		public IntPtr* enabledLayerNames;

		public UInt32 enabledExtensionCount;
		public IntPtr* enabledExtensionNames;

		public _InstanceCreateInfo(InstanceCreateInfo info)
		{
			sType = info.SType;
			next = info.Next;
			flags = info.Flags;
			applicationInfo = Alloc.alloc(info.ApplicationInfo);
			enabledLayerCount = (UInt32)info.EnabledLayerNames.Count;
			enabledExtensionCount = (UInt32)info.EnabledExtensionNames.Count;

			enabledLayerNames = Alloc.alloc(info.EnabledLayerNames);
			enabledExtensionNames = Alloc.alloc(info.EnabledExtensionNames);
		}

		public void destroy()
		{
			Alloc.free(applicationInfo);
			Alloc.free(enabledLayerNames, (int)enabledLayerCount);
			Alloc.free(enabledExtensionNames, (int)enabledExtensionCount);
		}
	}


	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct _DeviceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;

		public UInt32 QueueCreateInfoCount;
		public IntPtr* QueueCreateInfos;

		public UInt32 enabledLayerCount;
		public IntPtr* enabledLayerNames;

		public UInt32 enabledExtensionCount;
		public IntPtr* enabledExtensionNames;

		public IntPtr EnabledFeatures;

		public _DeviceCreateInfo(DeviceCreateInfo info)
		{
			SType = info.SType;
			Next = info.Next;
			Flags = info.Flags;

			QueueCreateInfoCount = (UInt32)info.QueueCreateInfos.Count;
			List<_DeviceQueueCreateInfo> qArray = new List<_DeviceQueueCreateInfo>();
			for(int i=0; i < info.QueueCreateInfos.Count; i++)
			{
				qArray.Add(new _DeviceQueueCreateInfo(info.QueueCreateInfos[i]));
			}

			QueueCreateInfos = Alloc.alloc(qArray);

			enabledLayerCount = (UInt32)info.EnabledLayerNames.Count;
			enabledExtensionCount = (UInt32)info.EnabledExtensionNames.Count;

			enabledLayerNames = Alloc.alloc(info.EnabledLayerNames);
			enabledExtensionNames = Alloc.alloc(info.EnabledExtensionNames);

			EnabledFeatures = Alloc.alloc(info.EnabledFeatures);
		}

		public void destroy()
		{
			Alloc.free(enabledLayerNames, (int)enabledLayerCount);
			Alloc.free(enabledExtensionNames, (int)enabledExtensionCount);
			Alloc.free(QueueCreateInfos, (int)QueueCreateInfoCount);
			Alloc.free(EnabledFeatures);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct _DeviceQueueCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 QueueFamilyIndex;
		public UInt32 QueueCount;
		public IntPtr QueuePriorities;

		public _DeviceQueueCreateInfo(DeviceQueueCreateInfo info)
		{
			SType = info.SType;
			Next = info.Next;
			Flags = info.Flags;
			QueueFamilyIndex = info.QueueFamilyIndex;
			QueueCount = info.QueueCount;

			QueuePriorities = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * info.QueuePriorities.Length);
			Marshal.Copy(info.QueuePriorities, 0, QueuePriorities, info.QueuePriorities.Length);
		}

		public void destroy()
		{
			Alloc.free(QueuePriorities);
		}
	}
}