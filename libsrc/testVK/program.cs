using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;
using System.IO;
using System.Reflection;

using Vulkan;

namespace VulkanTest
{

   public struct Vertex
   {
      public Vector3 pos;
      public Vector2 uv;
   }

   public struct TextureObject
   {
      public VK.Sampler sampler;
      public VK.Image image;
      public VK.ImageLayout imageLayout;
      public VK.MemoryAllocateInfo memInfo;
      public VK.DeviceMemory mem;
      public VK.ImageView view;
      public int width;
      public int height;
   }
   class VulkanApp
	{
		class Context
		{
			public VK.Instance instance;
			public VK.PhysicalDevice physicalDevice;
			public VK.PhysicalDeviceProperties deviceProperties;
			public VK.PhysicalDeviceFeatures deviceFeatures;
			public VK.PhysicalDeviceMemoryProperties deviceMemoryProperties;
			public int presentQueueIndex = -1;
			public int graphicsQueueIndex = -1;
			public int transferQueueIndex = -1;
			public int computeQueueIndex = -1;
			public int sparseQueueIndex = -1;

			public VK.Queue presentQueue;
			public VK.Queue graphicsQueue;
			public VK.Queue transferQueue;
			public VK.Queue computeQueue;
			public VK.Queue sparseQueue;

			public VK.SurfaceKHR surface;
			public VK.SurfaceCapabilitiesKHR surfaceCapabilities;
			public VK.SwapchainKHR swapChain;
			public VK.Image[] swapChainImages;
			public VK.ImageView[] swapChainImageViews;
			public VK.Format swapChainFormat;
			public VK.Extent2D swapChainExtent;
			public VK.Semaphore imageAvailable;
			public VK.Semaphore renderingFinished;

			public VK.CommandPool presentCommandPool;
			public VK.CommandBuffer[] presentCommandBuffers;

			public VK.Device device;
		};

		Context context = new Context();

		VK.DebugReportCallbackEXT debugCallbackHandle;

		IntPtr HInstance;
		IntPtr Hwnd;

      Vertex[] verts = new Vertex[]
      {
         new Vertex() {pos = new Vector3( 1, -1, -1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3(-1, -1, -1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3(-1,  1, -1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3( 1,  1, -1), uv = new Vector2(0, 1)},

         new Vertex() {pos = new Vector3(-1, -1, -1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3(-1, -1,  1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3(-1,  1,  1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3(-1,  1, -1), uv = new Vector2(0, 1)},

         new Vertex() {pos = new Vector3( 1, -1,  1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3( 1, -1, -1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3( 1,  1, -1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3( 1,  1,  1), uv = new Vector2(0, 1)},

         new Vertex() {pos = new Vector3(-1,  1,  1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3( 1,  1,  1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3( 1,  1, -1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3(-1,  1, -1), uv = new Vector2(0, 1)},

         new Vertex() {pos = new Vector3(-1, -1, -1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3( 1, -1, -1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3( 1, -1,  1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3(-1, -1,  1), uv = new Vector2(0, 1)},

         new Vertex() {pos = new Vector3(-1, -1,  1), uv = new Vector2(0, 0)},
         new Vertex() {pos = new Vector3( 1, -1,  1), uv = new Vector2(1, 0)},
         new Vertex() {pos = new Vector3( 1,  1,  1), uv = new Vector2(1, 1)},
         new Vertex() {pos = new Vector3(-1,  1,  1), uv = new Vector2(0, 1)}
      };

      ushort[] index ={0, 1, 2,
                        0, 2, 3, //front
                        4, 5, 6,
                        4,6, 7, //left
                        8,9,10,
                        8,10,11, //right
                        12,13,14,
                        12,14,15, // top 
                        16,17,18,
                        16,18,19, // bottom
                        20,21,22,
                        20,22,23  // back
                        };

      Matrix4x4 projectionMat;
      Matrix4x4 viewMatrix;
      Matrix4x4 modelMatrix;

      float spinAngle;
      float spinIncrement;
      bool pause;

      VK.ShaderModule vertShader;
      VK.ShaderModule fragShader;

      VK.DescriptorPool descriptorPool;

      TextureObject texture;

      Int32 frameCount;

      public void init(IntPtr appHandle, IntPtr windowHandle)
		{
			HInstance = appHandle;
			Hwnd = windowHandle;

			enumerateInstanceLayers();
			enumerateInstanceExtensions();
			initVulkan();
			setupDebugCallback();
			createSurface();
			getPhysicalDevice();
			enumerateDeviceLayers();
			enumerateDeviceExtensions();
			getDevice();
			getQueues();
			createSwapChain();
			createSemaphores();
			createCommandBuffers();
			recordCommandBuffers();

         createGraphicsPipeline();
         loadVbo();
         loadTexture();
         loadShaders();

		}

		public void shutdown()
		{
			destroySwapChain();
			destroyDevice();
			destroyInstance();
		}

		void enumerateInstanceLayers()
		{
			Console.WriteLine("Enumerating Instance Layer Properties");
			UInt32 count = 0;
			VK.EnumerateInstanceLayerProperties(out count, null);

         VK.LayerProperties[] props = new VK.LayerProperties[count];
			VK.EnumerateInstanceLayerProperties(out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tLayer Name: {0}", props[i].LayerName);
				Console.WriteLine("\t\tDescription: {0}", props[i].Description);
			}
		}

		void enumerateInstanceExtensions()
		{
			Console.WriteLine("Enumerating Instance Extensions");
			UInt32 count = 0;
			VK.EnumerateInstanceExtensionProperties(null, out count, null);

         VK.ExtensionProperties[] props = new VK.ExtensionProperties[count];
			VK.EnumerateInstanceExtensionProperties(null, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tExtensions Name: {0}", props[i].ExtensionName);
			}
		}

		void enumerateDeviceLayers()
		{
			Console.WriteLine("Enumerating Device Layer Properties");
			UInt32 count = 0;
			VK.EnumerateDeviceLayerProperties(context.physicalDevice, out count, null);

         VK.LayerProperties[] props = new VK.LayerProperties[count];
			VK.EnumerateDeviceLayerProperties(context.physicalDevice, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tLayer Name: {0}", props[i].LayerName);
				Console.WriteLine("\t\tDescription: {0}", props[i].Description);
			}
		}

		void enumerateDeviceExtensions()
		{
			Console.WriteLine("Enumerating Device Extensions");
			UInt32 count = 0;
			VK.EnumerateDeviceExtensionProperties(context.physicalDevice, null, out count, null);

         VK.ExtensionProperties[] props = new VK.ExtensionProperties[count];
			VK.EnumerateDeviceExtensionProperties(context.physicalDevice, null, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tExtensions Name: {0}", props[i].ExtensionName);
			}
		}

		void initVulkan()
		{
			Console.Write("Creating Instance...");
         VK.InstanceCreateInfo info = new VK.InstanceCreateInfo()
			{
				SType = VK.StructureType.InstanceCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
            ApplicationInfo = new VK.ApplicationInfo()
				{
					SType = VK.StructureType.ApplicationInfo,
					Next = IntPtr.Zero,
					ApplicationName = "Test VK Bindings",
					ApplicationVersion = Vulkan.Version.Make(1, 0, 0),
					EngineName = "Bobatron",
					EngineVersion = 1,
					ApiVersion = Vulkan.Version.Make(1, 0, 0)
				},
				EnabledLayerNames = new List<string>() {
					InstanceLayers.VK_LAYER_LUNARG_standard_validation
				},
				EnabledExtensionNames = new List<string>() {
					InstanceExtensions.VK_KHR_surface,
					InstanceExtensions.VK_KHR_win32_surface,
					InstanceExtensions.VK_EXT_debug_report
				}
			};

         VK.Result result = VK.CreateInstance(info, out context.instance);

			if (result == VK.Result.Success)
				Console.WriteLine("Success");
			else
				Console.WriteLine("Failed");
		}

		void setupDebugCallback()
		{
			Console.WriteLine("Initializing debug report extension");
			VK_EXT_debug_report.init(context.instance);

         VK.DebugReportCallbackCreateInfoEXT info = new VK.DebugReportCallbackCreateInfoEXT()
			{
				sType = VK.StructureType.DebugReportCallbackCreateInfoEXT,
				pNext = IntPtr.Zero,
				flags = VK.DebugReportFlagsEXT.Error | VK.DebugReportFlagsEXT.Warning,
				pfnCallback = debugCallback,
				pUserData = IntPtr.Zero
			};

         VK.Result res = VK.CreateDebugReportCallbackEXT(context.instance, ref info, null, out debugCallbackHandle);
			if (res != VK.Result.Success)
			{
				Console.WriteLine("Failed to install debug callback");
			}
		}

		void createSurface()
		{
			Console.WriteLine("Creating surface");
         VK.Win32SurfaceCreateInfoKHR info = new VK.Win32SurfaceCreateInfoKHR()
			{
				sType = VK.StructureType.Win32SurfaceCreateInfoKHR,
				pNext = IntPtr.Zero,
				flags = 0,
				hinstance = HInstance,
				hwnd = Hwnd
			};

         VK.Result res = VK.CreateWin32SurfaceKHR(context.instance, ref info, null, out context.surface);
			if (res != VK.Result.Success)
			{
				Console.WriteLine("Failed to create surface");
			}
		}

		void getPhysicalDevice()
		{
			Console.WriteLine("Getting physical devices...");

			UInt32 deviceCount = 0;
         VK.Result result = VK.EnumeratePhysicalDevices(context.instance, ref deviceCount, null);
			Console.WriteLine("\tFound {0} devices", deviceCount);

         VK.PhysicalDevice[] physicalDevices = new VK.PhysicalDevice[deviceCount];
			result = VK.EnumeratePhysicalDevices(context.instance, ref deviceCount, physicalDevices);

			for (int i = 0; i < physicalDevices.Length; i++)
			{
            VK.PhysicalDeviceProperties props;
				VK.GetPhysicalDeviceProperties(physicalDevices[i], out props);

				Console.WriteLine("\tFound Physical Device {0} of type {1}", props.DeviceName, props.DeviceType);
				Console.WriteLine("\tWith Driver version {0}", Vulkan.Version.ToString(props.ApiVersion));

            VK.PhysicalDeviceFeatures supportedFeatures;
				VK.GetPhysicalDeviceFeatures(physicalDevices[i], out supportedFeatures);

				Console.WriteLine("\tDevice has Geometry Shader:{0}  Tesselation Shader:{1}", supportedFeatures.geometryShader, supportedFeatures.tessellationShader);

            VK.PhysicalDeviceMemoryProperties memProps;
				VK.GetPhysicalDeviceMemoryProperties(physicalDevices[i], out memProps);

				Console.WriteLine("\tDevice has {0} memory types and {1} heaps", memProps.MemoryTypeCount, memProps.MemoryHeapCount);


				UInt32 queueFamilyCount = 0;
				VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevices[i], out queueFamilyCount, null);
				Console.WriteLine("\tFound {0} queue families", queueFamilyCount);

            VK.QueueFamilyProperties[] queueFamilyProps = new VK.QueueFamilyProperties[queueFamilyCount];
				VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevices[i], out queueFamilyCount, queueFamilyProps);

				bool presentFound = false;
				bool graphicsFound = false;
				bool computeFound = false;
				bool transferFound = false;
				bool sparseFound = false;

				for (int j = 0; j < queueFamilyProps.Length; j++)
				{
					Console.WriteLine("\t\tQueue Family {0} has {1} queues with flags {2}", j, queueFamilyProps[j].queueCount, queueFamilyProps[j].QueueFlags);
					Bool32 supportsPresent;
					VK.GetPhysicalDeviceSurfaceSupportKHR(physicalDevices[i], (UInt32)j, context.surface, out supportsPresent);

					if (!presentFound && supportsPresent == true)
					{
						Console.WriteLine("\tFound queue family supporting present: {0}", j);
						context.presentQueueIndex = j;
						presentFound = true;
					}

					if (!graphicsFound && queueFamilyProps[j].QueueFlags.HasFlag(VK.QueueFlags.Graphics))
					{
						context.graphicsQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting graphics: {0}", j);
						graphicsFound = true;
					}

					if (!transferFound && queueFamilyProps[j].QueueFlags.HasFlag(VK.QueueFlags.Transfer))
					{
						context.transferQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting transfer: {0}", j);
						transferFound = true;
					}

					if (!computeFound && queueFamilyProps[j].QueueFlags.HasFlag(VK.QueueFlags.Compute))
					{
						context.computeQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting compute: {0}", j);
						computeFound = true;
					}

					if (!sparseFound && queueFamilyProps[j].QueueFlags.HasFlag(VK.QueueFlags.SparseBinding))
					{
						context.sparseQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting sparse: {0}", j);
						sparseFound = true;
					}
				}

				if (presentFound && graphicsFound && computeFound && transferFound /* && sparseFound */) //sparse really isn't needed
				{
					context.physicalDevice = physicalDevices[i];
					context.deviceProperties = props;
					context.deviceFeatures = supportedFeatures;
					context.deviceMemoryProperties = memProps;
					break;
				}
			}

			Console.WriteLine("\tSuccess.");
		}

		void getDevice()
		{
			Console.Write("Creating Logical Device...");

			SortedSet<UInt32> queueFamilies = new SortedSet<UInt32>();
			if (context.presentQueueIndex != -1) queueFamilies.Add((UInt32)context.presentQueueIndex);
			if (context.graphicsQueueIndex != -1) queueFamilies.Add((UInt32)context.graphicsQueueIndex);
			if (context.computeQueueIndex != -1) queueFamilies.Add((UInt32)context.computeQueueIndex);
			if (context.transferQueueIndex != -1) queueFamilies.Add((UInt32)context.transferQueueIndex);
			if (context.sparseQueueIndex != -1) queueFamilies.Add((UInt32)context.sparseQueueIndex);



         VK.DeviceCreateInfo info = new VK.DeviceCreateInfo()
			{
				SType = VK.StructureType.DeviceCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				QueueCreateInfos = new List<VK.DeviceQueueCreateInfo>(),
				EnabledFeatures = context.deviceFeatures,
				EnabledExtensionNames = new List<string>()
				{
					DeviceExtensions.VK_KHR_swapchain
				},
				EnabledLayerNames = new List<string>() { }
			};

			foreach (UInt32 familyIndex in queueFamilies)
			{
				info.QueueCreateInfos.Add(
					new VK.DeviceQueueCreateInfo()
					{
						SType = VK.StructureType.DeviceQueueCreateInfo,
						Next = IntPtr.Zero,
						Flags = 0,
						QueueFamilyIndex = familyIndex,
						QueueCount = 1,
						QueuePriorities = new float[1] { 1.0f }
					}
				);
			}

         VK.Result res = VK.CreateDevice(context.physicalDevice, info, out context.device);

			if (res == VK.Result.Success)
				Console.WriteLine("\tSuccess");
			else
				Console.WriteLine("\tFailed");
		}

		void getQueues()
		{
			if (context.presentQueueIndex != -1) VK.GetDeviceQueue(context.device, (UInt32)context.presentQueueIndex, 0, out context.presentQueue);
			if (context.graphicsQueueIndex != -1) VK.GetDeviceQueue(context.device, (UInt32)context.graphicsQueueIndex, 0, out context.graphicsQueue);
			if (context.computeQueueIndex != -1) VK.GetDeviceQueue(context.device, (UInt32)context.computeQueueIndex, 0, out context.computeQueue);
			if (context.transferQueueIndex != -1) VK.GetDeviceQueue(context.device, (UInt32)context.transferQueueIndex, 0, out context.transferQueue);
			if (context.sparseQueueIndex != -1) VK.GetDeviceQueue(context.device, (UInt32)context.sparseQueueIndex, 0, out context.sparseQueue);
		}

		void createSwapChain()
		{
			Console.Write("Creating swapchain...");

         VK.Result res = VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(context.physicalDevice, context.surface, out context.surfaceCapabilities);
			checkResult(res, "Failed to get physical device surface capabilities");

			UInt32 formatCount = 0;
			res = VK.GetPhysicalDeviceSurfaceFormatsKHR(context.physicalDevice, context.surface, out formatCount, null);
			checkResult(res, "Failed to get physical device surface format count");

			Console.WriteLine("Found {0} formats for display surface", formatCount);
         VK.SurfaceFormatKHR[] surfaceFormats = new VK.SurfaceFormatKHR[formatCount];
			res = VK.GetPhysicalDeviceSurfaceFormatsKHR(context.physicalDevice, context.surface, out formatCount, surfaceFormats);
			checkResult(res, "Failed to get physical device surface format values");

         //just use the first format/colorspace
         VK.Format bestFormat = surfaceFormats[0].format;
         VK.ColorSpaceKHR bestColorspace = surfaceFormats[0].colorSpace;

			UInt32 presentModeCount = 0;
			res = VK.GetPhysicalDeviceSurfacePresentModesKHR(context.physicalDevice, context.surface, out presentModeCount, null);
			checkResult(res, "Failed to get physical device surface present mode count");

			Console.WriteLine("Found {0} present modes for display surface", presentModeCount);
         VK.PresentModeKHR[] presentModes = new VK.PresentModeKHR[presentModeCount];
			res = VK.GetPhysicalDeviceSurfacePresentModesKHR(context.physicalDevice, context.surface, out presentModeCount, presentModes);
			checkResult(res, "Failed to get physical device surface present mode values");

         //prefer mailbox, but use fifo as a fallback
         VK.PresentModeKHR bestPresentMode = VK.PresentModeKHR.Fifo;
			foreach (VK.PresentModeKHR availableMode in presentModes)
			{
				if (availableMode == VK.PresentModeKHR.Mailbox)
				{
					bestPresentMode = availableMode;
					break;
				}
			}

         VK.ImageUsageFlags usageFlags;
			if (context.surfaceCapabilities.supportedUsageFlags.HasFlag(VK.ImageUsageFlags.TransferDst))
				usageFlags = VK.ImageUsageFlags.ColorAttachment | VK.ImageUsageFlags.TransferDst;
			else
				usageFlags = VK.ImageUsageFlags.ColorAttachment;

         VK.SwapchainCreateInfoKHR info = new VK.SwapchainCreateInfoKHR()
			{
				SType = VK.StructureType.SwapchainCreateInfoKHR,
				Next = IntPtr.Zero,
				Flags = 0,
				Surface = context.surface,
				MinImageCount = context.surfaceCapabilities.minImageCount + 1,
				ImageFormat = bestFormat,
				ImageColorSpace = bestColorspace,
				ImageExtent = context.surfaceCapabilities.currentExtent,
				ImageArrayLayers = 1,
				ImageUsage = usageFlags,
				PresentMode = bestPresentMode,
				PreTransform = context.surfaceCapabilities.currentTransform,
				CompositeAlpha = VK.CompositeAlphaFlagsKHR.Opaque,
				Clipped = true,
				OldSwapchain = new VK.SwapchainKHR()
			};

			if (context.presentQueueIndex != context.graphicsQueueIndex)
			{
				info.ImageSharingMode = VK.SharingMode.Concurrent;
				info.QueueFamilyIndices = new List<UInt32>() { (UInt32)context.presentQueueIndex, (UInt32)context.graphicsQueueIndex };
			}
			else
			{
				info.ImageSharingMode = VK.SharingMode.Exclusive;
				info.QueueFamilyIndices = new List<UInt32>() { 0 };
			}

			res = VK.CreateSwapchainKHR(context.device, ref info, out context.swapChain);
			checkResult(res, "Failed to create swap chain");

			UInt32 imageCount = 0;
			res = VK.GetSwapchainImagesKHR(context.device, context.swapChain, out imageCount, null);
			checkResult(res, "Failed to get swamp chain image count");

			Console.WriteLine("Found {0} swapchain  images", imageCount);
			context.swapChainImages = new VK.Image[imageCount];

			res = VK.GetSwapchainImagesKHR(context.device, context.swapChain, out imageCount, context.swapChainImages);
			checkResult(res, "Failed to get swap chain images");


			context.swapChainExtent = context.surfaceCapabilities.currentExtent;
			context.swapChainFormat = bestFormat;

			context.swapChainImageViews = new VK.ImageView[context.swapChainImages.Length];
			for (int i = 0; i < context.swapChainImages.Length; i++)
			{
            VK.ImageViewCreateInfo viewInfo = new VK.ImageViewCreateInfo()
				{
					SType = VK.StructureType.ImageViewCreateInfo,
					Next = IntPtr.Zero,
					Flags = 0,
					image = context.swapChainImages[i],
					ViewType = VK.ImageViewType.View2D,
					Format = context.swapChainFormat,
					Components = new VK.ComponentMapping()
					{
						R = VK.ComponentSwizzle.Identity,
						G = VK.ComponentSwizzle.Identity,
						B = VK.ComponentSwizzle.Identity,
						A = VK.ComponentSwizzle.Identity
					},
					SubresourceRange = new VK.ImageSubresourceRange()
					{
						aspectMask = VK.ImageAspectFlags.Color,
						baseMipLevel = 0,
						levelCount = 1,
						baseArrayLayer = 0,
						layerCount = 1
					}
				};

				res = VK.CreateImageView(context.device, ref viewInfo, out context.swapChainImageViews[i]);
				checkResult(res, "Failed to create swap chain image view");
			}

			Console.WriteLine("Success");
		}

		void createSemaphores()
		{
			Console.Write("Creating semaphores...");
         VK.SemaphoreCreateInfo info = new VK.SemaphoreCreateInfo()
			{
				SType = VK.StructureType.SemaphoreCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0
			};

         VK.Result res = VK.CreateSemaphore(context.device, ref info, out context.imageAvailable);
			checkResult(res, "Creating image available semaphore");

			res = VK.CreateSemaphore(context.device, ref info, out context.renderingFinished);
			checkResult(res, "Creating rendering finished semaphore");

			Console.WriteLine("Success");
		}

		void createCommandBuffers()
		{
			Console.Write("Creating command buffers...");
         VK.CommandPoolCreateInfo info = new VK.CommandPoolCreateInfo()
			{
				SType = VK.StructureType.CommandPoolCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				QueueFamilyIndex = (UInt32)context.presentQueueIndex
			};

         VK.Result res = VK.CreateCommandPool(context.device, ref info, out context.presentCommandPool);
			checkResult(res, "Creating present command pool");

			context.presentCommandBuffers = new VK.CommandBuffer[context.swapChainImages.Length];

         VK.CommandBufferAllocateInfo allocInfo = new VK.CommandBufferAllocateInfo()
			{
				SType = VK.StructureType.CommandBufferAllocateInfo,
				Next = IntPtr.Zero,
				CommandPool = context.presentCommandPool,
				Level = VK.CommandBufferLevel.Primary,
				CommandBufferCount = (UInt32)context.swapChainImages.Length
			};

			res = VK.AllocateCommandBuffers(context.device, ref allocInfo, context.presentCommandBuffers);
			checkResult(res, "Create present command buffers");

			Console.WriteLine("Success");
		}

		void recordCommandBuffers()
		{
			Console.Write("Record command buffers...");
         VK.CommandBufferBeginInfo beginInfo = new VK.CommandBufferBeginInfo()
			{
				SType = VK.StructureType.CommandBufferBeginInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				InheritanceInfo = IntPtr.Zero
			};

         VK.ClearColorValue clearColor = new VK.ClearColorValue() { r = 1.0f, g = 0.8f, b = 0.4f, a = 0.0f };

         VK.ImageSubresourceRange imageSubresourceRange = new VK.ImageSubresourceRange()
				{
					aspectMask = VK.ImageAspectFlags.Color,
					baseMipLevel = 0,
					levelCount = 1,
					baseArrayLayer = 0,
					layerCount = 1
				};

			for (int i = 0; i < context.swapChainImages.Length; i++)
			{
            VK.ImageMemoryBarrier barrierFromPresentToClear = new VK.ImageMemoryBarrier()
					{
						SType = VK.StructureType.ImageMemoryBarrier,
						Next = IntPtr.Zero,
						SrcAccessMask = VK.AccessFlags.MemoryRead,
						DstAccessMask = VK.AccessFlags.TransferWrite,
						OldLayout = VK.ImageLayout.Undefined,
						NewLayout = VK.ImageLayout.TransferDstOptimal,
						SrcQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						DstQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
                  Image = context.swapChainImages[i],
						SubresourceRange = imageSubresourceRange
					};

            VK.ImageMemoryBarrier barrierFromClearToPresent =
					new VK.ImageMemoryBarrier()
					{
						SType = VK.StructureType.ImageMemoryBarrier,
						Next = IntPtr.Zero,
						SrcAccessMask = VK.AccessFlags.TransferWrite,
						DstAccessMask = VK.AccessFlags.MemoryRead,
						OldLayout = VK.ImageLayout.TransferDstOptimal,
						NewLayout = VK.ImageLayout.PresentSrcKHR,
						SrcQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						DstQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
                  Image = context.swapChainImages[i],
						SubresourceRange = imageSubresourceRange
					};


            VK.Result res = VK.BeginCommandBuffer(context.presentCommandBuffers[i], ref beginInfo);
				checkResult(res, "Begin command buffer");

				VK.CmdPipelineBarrier(context.presentCommandBuffers[i], VK.PipelineStageFlags.Transfer, VK.PipelineStageFlags.Transfer, 0, 0, null, 0, null, 1, new VK.ImageMemoryBarrier[] { barrierFromPresentToClear });
				
				VK.CmdClearColorImage(context.presentCommandBuffers[i], context.swapChainImages[i], VK.ImageLayout.TransferDstOptimal, ref clearColor, 1, new VK.ImageSubresourceRange[] { imageSubresourceRange });
				
				VK.CmdPipelineBarrier(context.presentCommandBuffers[i], VK.PipelineStageFlags.Transfer, VK.PipelineStageFlags.BottomOfPipe, 0, 0, null, 0, null, 1, new VK.ImageMemoryBarrier[] { barrierFromClearToPresent});

				res = VK.EndCommandBuffer(context.presentCommandBuffers[i]);
				checkResult(res, "End command buffer");

				Console.WriteLine("Success");
			}
		}

		void createGraphicsPipeline()
		{

		}

      void loadVbo()
      {

      }

      void loadTexture()
      {

      }

      void loadShaders()
      {
         byte[] vsSpv = getEmbeddedResource("Test Vulkan.shaders.vs.glsl.spv");

         VK.ShaderModuleCreateInfo createInfo = new VK.ShaderModuleCreateInfo()
         {
            SType = VK.StructureType.ShaderModuleCreateInfo,
            CodeSize = 0,
            Code = ,
            Flags = 0
         };

         createInfo.sType = VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
         createInfo.codeSize = code.size();
         createInfo.pCode = reinterpret_cast <const uint32_t*> (code.data());

         VkShaderModule shaderModule;
         if (vkCreateShaderModule(device, &createInfo, nullptr, &shaderModule) != VK_SUCCESS)
         {
            throw std::runtime_error("failed to create shader module!");
         }

         VkPipelineShaderStageCreateInfo vertShaderStageInfo = { };
         vertShaderStageInfo.sType = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
         vertShaderStageInfo.stage = VK_SHADER_STAGE_VERTEX_BIT;

         vertShaderStageInfo.module = vertShaderModule;
         vertShaderStageInfo.pName = "main";

         VkPipelineShaderStageCreateInfo fragShaderStageInfo = { };
         fragShaderStageInfo.sType = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
         fragShaderStageInfo.stage = VK_SHADER_STAGE_FRAGMENT_BIT;
         fragShaderStageInfo.module = fragShaderModule;
         fragShaderStageInfo.pName = "main";

         VkPipelineShaderStageCreateInfo shaderStages[] = { vertShaderStageInfo, fragShaderStageInfo };
      }

      byte[] getEmbeddedResource(string resourceName)
      {
         Assembly[] asses = AppDomain.CurrentDomain.GetAssemblies();
         foreach (Assembly ass in asses)
         {
            string[] resources = ass.GetManifestResourceNames();
            foreach (string s in resources)
            {
               if (s == resourceName)
               {
                  Stream stream = ass.GetManifestResourceStream(resourceName);
                  if (stream == null)
                  {
                     Console.WriteLine("Cannot find embedded resource {0}", resourceName);
                     return null;
                  }

                  using (var memoryStream = new MemoryStream())
                  {
                     stream.CopyTo(memoryStream);
                     return memoryStream.ToArray();
                  }
               }
            }
         }

         return null;
      }

		public void draw()
		{
			UInt32 index = 0;
         VK.Result res = VK.AcquireNextImageKHR(context.device, context.swapChain, UInt64.MaxValue, context.imageAvailable, VK.NULL_FENCE, out index);
			checkResult(res, "Acquire next image");

         VK.SubmitInfo submitInfo = new VK.SubmitInfo()
			{
				SType = VK.StructureType.SubmitInfo,
				Next = IntPtr.Zero,
				WaitSemaphores = new List<VK.Semaphore>() { context.imageAvailable },
				WaitDstStageMask = VK.PipelineStageFlags.Transfer,
				CommandBuffers = new List<VK.CommandBuffer>() { context.presentCommandBuffers[index] },
				SignalSemaphores = new List<VK.Semaphore>() { context.renderingFinished }
			};

			res = VK.QueueSubmit(context.presentQueue, 1, new VK.SubmitInfo[] { submitInfo }, VK.NULL_FENCE);
			checkResult(res, "submit queue");

         VK.PresentInfoKHR presentInfo = new VK.PresentInfoKHR()
			{
				SType = VK.StructureType.PresentInfoKHR,
				Next = IntPtr.Zero,
				WaitSemaphores = new List<VK.Semaphore>() { context.renderingFinished },
				Swapchains = new List<VK.SwapchainKHR>() { context.swapChain },
				Indices = new List<uint>() { index },
				Results = new List<VK.Result>() { VK.Result.NotReady}
			};

			res = VK.QueuePresentKHR(context.presentQueue, ref presentInfo);
			checkResult(res, "Queue present");
		}

		void destroySwapChain()
		{
			Console.Write("Destroying SwapChain...");

			VK.DeviceWaitIdle(context.device);

			VK.FreeCommandBuffers(context.device, context.presentCommandPool, (UInt32)context.presentCommandBuffers.Length, context.presentCommandBuffers);
			VK.DestroyCommandPool(context.device, context.presentCommandPool);

			VK.DestroySemaphore(context.device, context.imageAvailable);
			VK.DestroySemaphore(context.device, context.renderingFinished);


			for (int i = 0; i < context.swapChainImageViews.Length; i++)
			{
				VK.DestroyImageView(context.device, context.swapChainImageViews[i]);
			}

			VK.DestroySwapchainKHR(context.device, context.swapChain);

			Console.WriteLine("Success");
		}

		void destroyDevice()
		{
			Console.Write("Destroying Logical Device...");
			VK.DeviceWaitIdle(context.device);
			VK.DestroyDevice(context.device);
			Console.WriteLine("Success!");
		}

		void destroyInstance()
		{
			Console.Write("Destroying Instance...");
			VK.DestroySurfaceKHR(context.instance, context.surface);
			VK.DestroyDebugReportCallbackEXT(context.instance, debugCallbackHandle);
			VK.DestroyInstance(context.instance);
			Console.WriteLine("Success!");
		}

		static Bool32 debugCallback(VK.DebugReportFlagsEXT flags, VK.DebugReportObjectTypeEXT objectType, UInt64 _object, IntPtr location, Int32 messageCode, string layerPrefix, string message, IntPtr userData)
		{
			string level = "";
			if (flags.HasFlag(VK.DebugReportFlagsEXT.Error)) level = "Error";
			if (flags.HasFlag(VK.DebugReportFlagsEXT.Warning)) level = "Warning";

			Console.WriteLine("{0}: {1}-{2} ", level, objectType, message);

			return false;
		}

		void checkResult(VK.Result res, String msg)
		{
			if (res != VK.Result.Success)
			{
				Console.WriteLine("Result Failed-{0}: {1}", res, msg);
			}
		}
	}
}