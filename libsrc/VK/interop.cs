using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct _InstanceCreateInfo
	{
		public StructureType sType;
		public IntPtr next;
		public UInt32 flags;
		public IntPtr applicationInfo;
		public UInt32 enabledLayerCount;
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public String[] enabledLayerNames;
		public UInt32 enabledExtensionCount;
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public String[] enabledExtensionNames;

		public _InstanceCreateInfo(InstanceCreateInfo info)
		{
			sType = info.SType;
			next = info.Next;
			flags = info.Flags;
			applicationInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ApplicationInfo)));
			Marshal.StructureToPtr(info.ApplicationInfo, applicationInfo, false);
			enabledLayerCount = (UInt32)info.EnabledLayerNames.Count;
			enabledExtensionCount = (UInt32)info.EnabledExtensionNames.Count;
			enabledLayerNames = info.EnabledLayerNames.ToArray();
			enabledExtensionNames = info.EnabledExtensionNames.ToArray();
		}

		public void destroy()
		{
			Marshal.FreeHGlobal(applicationInfo);
		}
	}


	[StructLayout(LayoutKind.Sequential)]
	internal struct _DeviceCreateInfo
	{
		public StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 QueueCreateInfoCount;
		[MarshalAs(UnmanagedType.LPArray, ArraySubType =UnmanagedType.Struct)]
		public DeviceQueueCreateInfo[] QueueCreateInfos;
		public UInt32 EnabledLayerCount;
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] EnabledLayerNames;
		public UInt32 EnabledExtensionCount;
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] EnabledExtensionNames;
		public IntPtr EnabledFeatures;

		public _DeviceCreateInfo(DeviceCreateInfo info)
		{
			SType = info.SType;
			Next = info.Next;
			Flags = info.Flags;

			QueueCreateInfoCount = (UInt32)info.QueueCreateInfos.Count;
			QueueCreateInfos = info.QueueCreateInfos.ToArray();

			EnabledLayerCount = (UInt32)info.EnabledLayerNames.Count;
			EnabledLayerNames = info.EnabledLayerNames.ToArray();

			EnabledExtensionCount = (UInt32)info.EnabledExtensionNames.Count;
			EnabledExtensionNames = info.EnabledExtensionNames.ToArray();

			EnabledFeatures = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PhysicalDeviceFeatures)));
			Marshal.StructureToPtr(info.EnabledFeatures, EnabledFeatures, false);
		}

		public void destroy()
		{
			
			Marshal.FreeHGlobal(EnabledFeatures);
		}
	}


}