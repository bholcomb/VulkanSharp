using System;
using System.Collections.Generic;

using Vulkan;

namespace VulkanTest
{
	class Program
	{
		static Instance instance;
		static PhysicalDevice physicalDevice;
		static PhysicalDeviceFeatures supportedFeatures;
		static Device device;

		static void Main(String[] args)
		{
			initVulkan();
			getPhysicalDevice();
			getDevice();

			destroyDevice();
			destroyInstance();
		}

		static void initVulkan()
		{
			Console.Write("Creating Instance...");
			InstanceCreateInfo info = new InstanceCreateInfo()
			{
				SType = StructureType.InstanceCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				ApplicationInfo = new ApplicationInfo()
				{
					SType = StructureType.ApplicationInfo,
					Next = IntPtr.Zero,
					ApplicationName = "Test VK Bindings",
					ApplicationVersion = Vulkan.Version.Make(1, 0, 0),
					EngineName = "Bobatron",
					EngineVersion = 1,
					ApiVersion = Vulkan.Version.Make(1, 0, 0)
				},
				EnabledLayerNames = new List<string>() { },
				EnabledExtensionNames = new List<string>() { InstanceExtensions.VK_KHR_surface, InstanceExtensions.VK_KHR_win32_surface, InstanceExtensions.VK_EXT_debug_report }  
			}; 

			Result result = VK.CreateInstance(info, out instance);

			if (result == Result.Success)
				Console.WriteLine("Success");
			else
				Console.WriteLine("Failed");
		}

		static void getPhysicalDevice()
		{
			Console.WriteLine("Getting physical devices...");

			UInt32 deviceCount = 0;
			Result result = VK.EnumeratePhysicalDevices(instance, ref deviceCount, null);
			Console.WriteLine("\tFound {0} devices", deviceCount);

			PhysicalDevice[] physicalDevices = new PhysicalDevice[deviceCount];
			result = VK.EnumeratePhysicalDevices(instance, ref deviceCount, physicalDevices);

			for (int i = 0; i < physicalDevices.Length; i++)
			{
				PhysicalDeviceProperties props;
				VK.GetPhysicalDeviceProperties(physicalDevices[i], out props);

				Console.WriteLine("\tFound Physical Device {0} of type {1}", props.DeviceName, props.DeviceType);

				VK.GetPhysicalDeviceFeatures(physicalDevices[i], out supportedFeatures);

				Console.WriteLine("\tDevice has Geometry Shader:{0}  Tesselation Shader:{1}", supportedFeatures.geometryShader, supportedFeatures.tessellationShader);

				PhysicalDeviceMemoryProperties memProps;
				VK.GetPhysicalDeviceMemoryProperties(physicalDevices[i], out memProps);

				Console.WriteLine("\tDevice has {0} memory types and {1} heaps", memProps.MemoryTypeCount, memProps.MemoryHeapCount);

				
				UInt32 queueFamilyCount = 0;
				VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevices[i], out queueFamilyCount, null);
				Console.WriteLine("\tFound {0} queue families", queueFamilyCount);

				QueueFamilyProperties[] queueFamilyProps = new QueueFamilyProperties[queueFamilyCount];
				VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevices[i], out queueFamilyCount, queueFamilyProps);

				for(int j= 0; j< queueFamilyProps.Length; j++)
				{
					Console.WriteLine("\t\tQueue Family {0} has {1} queues with flags {2}", j, queueFamilyProps[j].queueCount, queueFamilyProps[j].QueueFlags);
				}
			}

			Console.WriteLine("\tSuccess. Using first physical device");
			physicalDevice = physicalDevices[0];
		}

		static void getDevice()
		{
			Console.WriteLine("Creating Logical Device...");

			DeviceCreateInfo info = new DeviceCreateInfo()
			{
				SType = StructureType.DeviceCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				QueueCreateInfos = new List<DeviceQueueCreateInfo>()
				{
					new DeviceQueueCreateInfo()
					{
						SType = StructureType.DeviceQueueCreateInfo,
						Next = IntPtr.Zero,
						Flags = 0,
						QueueFamilyIndex = 0,
						QueueCount = 4,
						QueuePriorities = new float[4] {1.0f, 1.0f, 1.0f, 1.0f}
					}
				},
				EnabledFeatures = supportedFeatures,
				EnabledExtensionNames = new List<string>() {DeviceExtensions.VK_KHR_swapchain },
				EnabledLayerNames = new List<string>() { }
			};

			Result res = VK.CreateDevice(physicalDevice, info, out device);

			if (res == Result.Success)
				Console.WriteLine("\tSuccess");
			else
				Console.WriteLine("\tFailed");
		}

		static void destroyDevice()
		{
			VK.DestroyDevice(device);
		}

		static void destroyInstance()
		{
			VK.DestroyInstance(instance);
		}
	}
}