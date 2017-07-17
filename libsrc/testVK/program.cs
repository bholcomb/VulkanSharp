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
		static Queue queue;

		static void Main(String[] args)
		{
			enumerateInstanceLayers();
			enumerateInstanceExtensions();
			initVulkan();
			getPhysicalDevice();
			enumerateDeviceLayers();
			enumerateDeviceExtensions();
			getDevice();
			getQueue();

			destroyDevice();
			destroyInstance();
		}

		static void enumerateInstanceLayers()
		{
			Console.WriteLine("Enumerating Instance Layer Properties");
			UInt32 count = 0;
			VK.EnumerateInstanceLayerProperties(out count, null);

			LayerProperties[] props = new LayerProperties[count];
			VK.EnumerateInstanceLayerProperties(out count, props);

			for(int i=0; i<props.Length; i++)
			{
				Console.WriteLine("\tLayer Name: {0}", props[i].LayerName);
				Console.WriteLine("\t\tDescription: {0}", props[i].Description);
			}
		}

		static void enumerateInstanceExtensions()
		{
			Console.WriteLine("Enumerating Instance Extensions");
			UInt32 count = 0;
			VK.EnumerateInstanceExtensionProperties(null, out count, null);

			ExtensionProperties[] props = new ExtensionProperties[count];
			VK.EnumerateInstanceExtensionProperties(null, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tExtensions Name: {0}", props[i].ExtensionName);
			}
		}

		static void enumerateDeviceLayers()
		{
			Console.WriteLine("Enumerating Device Layer Properties");
			UInt32 count = 0;
			VK.EnumerateDeviceLayerProperties(physicalDevice, out count, null);

			LayerProperties[] props = new LayerProperties[count];
			VK.EnumerateDeviceLayerProperties(physicalDevice, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tLayer Name: {0}", props[i].LayerName);
				Console.WriteLine("\t\tDescription: {0}", props[i].Description);
			}
		}

		static void enumerateDeviceExtensions()
		{
			Console.WriteLine("Enumerating Device Extensions");
			UInt32 count = 0;
			VK.EnumerateDeviceExtensionProperties(physicalDevice, null, out count, null);

			ExtensionProperties[] props = new ExtensionProperties[count];
			VK.EnumerateDeviceExtensionProperties(physicalDevice, null, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tExtensions Name: {0}", props[i].ExtensionName);
			}
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
				EnabledExtensionNames = new List<string>() {
					InstanceExtensions.VK_KHR_surface,
					InstanceExtensions.VK_KHR_win32_surface,
					InstanceExtensions.VK_EXT_debug_report
				}  
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
				Console.WriteLine("\tWith Driver version {0}", Vulkan.Version.ToString(props.ApiVersion));

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
			Console.Write("Creating Logical Device...");

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
						QueueCount = 1,
						QueuePriorities = new float[1] {1.0f}
					}
				},
				EnabledFeatures = supportedFeatures,
				EnabledExtensionNames = new List<string>()
				{
					DeviceExtensions.VK_KHR_swapchain
				},
				EnabledLayerNames = new List<string>() { }
			};

			Result res = VK.CreateDevice(physicalDevice, info, out device);

			if (res == Result.Success)
				Console.WriteLine("\tSuccess");
			else
				Console.WriteLine("\tFailed");
		}

		static void getQueue()
		{
			VK.GetDeviceQueue(device, 0, 0, out queue);
		}

		static void createPresentationSurface()
		{

		}

		static void destroyDevice()
		{
			Console.Write("Destroying Logical Device...");
			VK.DeviceWaitIdle(device);
			VK.DestroyDevice(device);
			Console.WriteLine("Success!");
		}

		static void destroyInstance()
		{
			Console.Write("Destroying Instance...");
			VK.DestroyInstance(instance);
			Console.WriteLine("Success!");
		}
	}
}