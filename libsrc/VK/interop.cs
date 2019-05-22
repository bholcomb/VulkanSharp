using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
	internal static class ExternalFunction
	{
		internal static T getInstanceFunction<T>(VK.Instance instance, string name)
		{
			IntPtr funcPtr = VK.GetInstanceProcAddr(instance, name);
			if (funcPtr == IntPtr.Zero)
			{
				throw new Exception(String.Format("Instance function {0} not found, extension may not be present", name));
			}

			return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
		}

		internal static T getDeviceFunction<T>(VK.Device device, string name)
		{
			IntPtr funcPtr = VK.GetDeviceProcAddr(device, name);
			if (funcPtr == IntPtr.Zero)
			{
				throw new Exception(String.Format("Device function {0} not found, extension may not be present", name));
			}

			return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
		}
	}


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

		internal static IntPtr alloc<T>(List<T> data) where T: struct
		{
			IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)) * data.Count);
			Int64 addr = ptr.ToInt64();
			for (int i = 0; i < data.Count; i++)
			{
				IntPtr anItem = new IntPtr(addr);
				Marshal.StructureToPtr(data[i], anItem, false);
				addr += Marshal.SizeOf(typeof(T));
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
		public VK.StructureType sType;
		public IntPtr next;
		public UInt32 flags;
		public IntPtr applicationInfo;

		public UInt32 enabledLayerCount;
		public IntPtr* enabledLayerNames;

		public UInt32 enabledExtensionCount;
		public IntPtr* enabledExtensionNames;

		public _InstanceCreateInfo(VK.InstanceCreateInfo info)
		{
			sType = info.type;
			next = info.next;
			flags = info.flags;
			applicationInfo = Alloc.alloc(info.applicationInfo);
			enabledLayerCount = (UInt32)info.enabledLayerNames.Count;
			enabledExtensionCount = (UInt32)info.enabledExtensionNames.Count;

			enabledLayerNames = Alloc.alloc(info.enabledLayerNames);
			enabledExtensionNames = Alloc.alloc(info.enabledExtensionNames);
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
		public VK.StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;

		public UInt32 QueueCreateInfoCount;
		public IntPtr* QueueCreateInfos;

		public UInt32 enabledLayerCount;
		public IntPtr* enabledLayerNames;

		public UInt32 enabledExtensionCount;
		public IntPtr* enabledExtensionNames;

		public IntPtr EnabledFeatures;

		public _DeviceCreateInfo(VK.DeviceCreateInfo info)
		{
			SType = info.type;
			Next = info.next;
			Flags = info.flags;

			QueueCreateInfoCount = (UInt32)info.queueCreateInfos.Count;
         List<_DeviceQueueCreateInfo> qArray = new List<_DeviceQueueCreateInfo>();
			for(int i=0; i < info.queueCreateInfos.Count; i++)
			{
				qArray.Add(new _DeviceQueueCreateInfo(info.queueCreateInfos[i]));
			}

			QueueCreateInfos = (IntPtr*)Alloc.alloc(qArray);

			enabledLayerCount = (UInt32)info.enabledLayerNames.Count;
			enabledExtensionCount = (UInt32)info.enabledExtensionNames.Count;

			enabledLayerNames = Alloc.alloc(info.enabledLayerNames);
			enabledExtensionNames = Alloc.alloc(info.enabledExtensionNames);

			EnabledFeatures = Alloc.alloc(info.enabledFeatures);
		}

		public void destroy()
		{
			Alloc.free(enabledLayerNames, (int)enabledLayerCount);
			Alloc.free(enabledExtensionNames, (int)enabledExtensionCount);
			Alloc.free(new IntPtr(QueueCreateInfos)); //since this is allocated as a large blob and should be freed as one
			Alloc.free(EnabledFeatures);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct _DeviceQueueCreateInfo
	{
		public VK.StructureType SType;
		public IntPtr Next;
		public UInt32 Flags;
		public UInt32 QueueFamilyIndex;
		public UInt32 QueueCount;
		public IntPtr QueuePriorities;

		public _DeviceQueueCreateInfo(VK.DeviceQueueCreateInfo info)
		{
			SType = info.type;
			Next = info.next;
			Flags = info.flags;
			QueueFamilyIndex = info.queueFamilyIndex;
			QueueCount = info.queueCount;

			QueuePriorities = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * info.queuePriorities.Length);
			Marshal.Copy(info.queuePriorities, 0, QueuePriorities, info.queuePriorities.Length);
		}

		public void destroy()
		{
			Alloc.free(QueuePriorities);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct _BindSparseInfo
	{
      VK.StructureType sType;
		IntPtr pNext;
		UInt32 waitSemaphoreCount;
		IntPtr pWaitSemaphores;
		UInt32 bufferBindCount;
		IntPtr pBufferBinds;
		UInt32 imageOpaqueBindCount;
		IntPtr pImageOpaqueBinds;
		UInt32 imageBindCount;
		IntPtr pImageBinds;
		UInt32 signalSemaphoreCount;
		IntPtr pSignalSemaphores;

		public _BindSparseInfo(VK.BindSparseInfo info)
		{
			sType = info.type;
			pNext = info.pNext;
			waitSemaphoreCount = (UInt32)info.pWaitSemaphores.Count;
			bufferBindCount = (UInt32)info.pBufferBinds.Count;
			imageOpaqueBindCount = (UInt32)info.pImageOpaqueBinds.Count;
			imageBindCount = (UInt32)info.pImageBinds.Count;
			signalSemaphoreCount = (UInt32)info.pSignalSemaphores.Count;

			pWaitSemaphores = Alloc.alloc(info.pWaitSemaphores);
			pBufferBinds = Alloc.alloc(info.pBufferBinds);
			pImageOpaqueBinds = Alloc.alloc(info.pImageOpaqueBinds);
			pImageBinds = Alloc.alloc(info.pImageBinds);
			pSignalSemaphores = Alloc.alloc(info.pSignalSemaphores);
		}

		public void destroy()
		{
			Alloc.free(pWaitSemaphores);
			Alloc.free(pBufferBinds);
			Alloc.free(pImageOpaqueBinds);
			Alloc.free(pImageBinds);
			Alloc.free(pSignalSemaphores);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct _SubmitInfo
	{
		public VK.StructureType SType;
		public IntPtr Next;
		public UInt32 WaitSemaphoreCount;
		public IntPtr WaitSemaphores;
		public IntPtr WaitDstStageMask;
		public UInt32 CommandBufferCount;
		public IntPtr CommandBuffers;
		public UInt32 SignalSemaphoreCount;
		public IntPtr SignalSemaphores;

		public _SubmitInfo(VK.SubmitInfo info)
		{
			SType = info.type;
			Next = info.next;
			WaitSemaphoreCount = (UInt32)info.waitSemaphores.Count;
			CommandBufferCount = (UInt32)info.commandBuffers.Count;
			SignalSemaphoreCount = (UInt32)info.signalSemaphores.Count;

			WaitDstStageMask = Alloc.alloc((UInt32)info.waitDstStageMask);
			WaitSemaphores = Alloc.alloc(info.waitSemaphores);
			CommandBuffers = Alloc.alloc(info.commandBuffers);
			SignalSemaphores = Alloc.alloc(info.signalSemaphores);
		}

		public void destroy()
		{
			Alloc.free(WaitDstStageMask);
			Alloc.free(WaitSemaphores);
			Alloc.free(CommandBuffers);
			Alloc.free(SignalSemaphores);
		}
	}
}