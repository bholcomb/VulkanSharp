using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vulkan;

namespace VulkanTest
{
	class VulkanApp
	{
		class Context
		{
			public Instance instance;
			public PhysicalDevice physicalDevice;
			public PhysicalDeviceProperties deviceProperties;
			public PhysicalDeviceFeatures deviceFeatures;
			public PhysicalDeviceMemoryProperties deviceMemoryProperties;
			public int presentQueueIndex = -1;
			public int graphicsQueueIndex = -1;
			public int transferQueueIndex = -1;
			public int computeQueueIndex = -1;
			public int sparseQueueIndex = -1;

			public Queue presentQueue;
			public Queue graphicsQueue;
			public Queue transferQueue;
			public Queue computeQueue;
			public Queue sparseQueue;

			public SurfaceKHR surface;
			public SurfaceCapabilitiesKHR surfaceCapabilities;
			public SwapchainKHR swapChain;
			public Image[] swapChainImages;
			public ImageView[] swapChainImageViews;
			public Format swapChainFormat;
			public Extent2D swapChainExtent;
			public Semaphore imageAvailable;
			public Semaphore renderingFinished;

			public CommandPool presentCommandPool;
			public CommandBuffer[] presentCommandBuffers;

			public Device device;
		};

		Context context = new Context();

		DebugReportCallbackEXT debugCallbackHandle;

		IntPtr HInstance;
		IntPtr Hwnd;

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

			LayerProperties[] props = new LayerProperties[count];
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

			ExtensionProperties[] props = new ExtensionProperties[count];
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

			LayerProperties[] props = new LayerProperties[count];
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

			ExtensionProperties[] props = new ExtensionProperties[count];
			VK.EnumerateDeviceExtensionProperties(context.physicalDevice, null, out count, props);

			for (int i = 0; i < props.Length; i++)
			{
				Console.WriteLine("\tExtensions Name: {0}", props[i].ExtensionName);
			}
		}

		void initVulkan()
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
				EnabledLayerNames = new List<string>() {
					InstanceLayers.VK_LAYER_LUNARG_standard_validation
				},
				EnabledExtensionNames = new List<string>() {
					InstanceExtensions.VK_KHR_surface,
					InstanceExtensions.VK_KHR_win32_surface,
					InstanceExtensions.VK_EXT_debug_report
				}
			};

			Result result = VK.CreateInstance(info, out context.instance);

			if (result == Result.Success)
				Console.WriteLine("Success");
			else
				Console.WriteLine("Failed");
		}

		void setupDebugCallback()
		{
			Console.WriteLine("Initializing debug report extension");
			VK_EXT_debug_report.init(context.instance);

			DebugReportCallbackCreateInfoEXT info = new DebugReportCallbackCreateInfoEXT()
			{
				sType = StructureType.DebugReportCallbackCreateInfoEXT,
				pNext = IntPtr.Zero,
				flags = DebugReportFlagsEXT.Error | DebugReportFlagsEXT.Warning,
				pfnCallback = debugCallback,
				pUserData = IntPtr.Zero
			};

			Result res = VK.CreateDebugReportCallbackEXT(context.instance, ref info, null, out debugCallbackHandle);
			if (res != Result.Success)
			{
				Console.WriteLine("Failed to install debug callback");
			}
		}

		void createSurface()
		{
			Console.WriteLine("Creating surface");
			Win32SurfaceCreateInfoKHR info = new Win32SurfaceCreateInfoKHR()
			{
				sType = StructureType.Win32SurfaceCreateInfoKHR,
				pNext = IntPtr.Zero,
				flags = 0,
				hinstance = HInstance,
				hwnd = Hwnd
			};

			Result res = VK.CreateWin32SurfaceKHR(context.instance, ref info, null, out context.surface);
			if (res != Result.Success)
			{
				Console.WriteLine("Failed to create surface");
			}
		}

		void getPhysicalDevice()
		{
			Console.WriteLine("Getting physical devices...");

			UInt32 deviceCount = 0;
			Result result = VK.EnumeratePhysicalDevices(context.instance, ref deviceCount, null);
			Console.WriteLine("\tFound {0} devices", deviceCount);

			PhysicalDevice[] physicalDevices = new PhysicalDevice[deviceCount];
			result = VK.EnumeratePhysicalDevices(context.instance, ref deviceCount, physicalDevices);

			for (int i = 0; i < physicalDevices.Length; i++)
			{
				PhysicalDeviceProperties props;
				VK.GetPhysicalDeviceProperties(physicalDevices[i], out props);

				Console.WriteLine("\tFound Physical Device {0} of type {1}", props.DeviceName, props.DeviceType);
				Console.WriteLine("\tWith Driver version {0}", Vulkan.Version.ToString(props.ApiVersion));

				PhysicalDeviceFeatures supportedFeatures;
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

					if (!graphicsFound && queueFamilyProps[j].QueueFlags.HasFlag(QueueFlags.Graphics))
					{
						context.graphicsQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting graphics: {0}", j);
						graphicsFound = true;
					}

					if (!transferFound && queueFamilyProps[j].QueueFlags.HasFlag(QueueFlags.Transfer))
					{
						context.transferQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting transfer: {0}", j);
						transferFound = true;
					}

					if (!computeFound && queueFamilyProps[j].QueueFlags.HasFlag(QueueFlags.Compute))
					{
						context.computeQueueIndex = j;
						Console.WriteLine("\tFound queue family supporting compute: {0}", j);
						computeFound = true;
					}

					if (!sparseFound && queueFamilyProps[j].QueueFlags.HasFlag(QueueFlags.SparseBinding))
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



			DeviceCreateInfo info = new DeviceCreateInfo()
			{
				SType = StructureType.DeviceCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				QueueCreateInfos = new List<DeviceQueueCreateInfo>(),
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
					new DeviceQueueCreateInfo()
					{
						SType = StructureType.DeviceQueueCreateInfo,
						Next = IntPtr.Zero,
						Flags = 0,
						QueueFamilyIndex = familyIndex,
						QueueCount = 1,
						QueuePriorities = new float[1] { 1.0f }
					}
				);
			}

			Result res = VK.CreateDevice(context.physicalDevice, info, out context.device);

			if (res == Result.Success)
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

			Result res = VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(context.physicalDevice, context.surface, out context.surfaceCapabilities);
			checkResult(res, "Failed to get physical device surface capabilities");

			UInt32 formatCount = 0;
			res = VK.GetPhysicalDeviceSurfaceFormatsKHR(context.physicalDevice, context.surface, out formatCount, null);
			checkResult(res, "Failed to get physical device surface format count");

			Console.WriteLine("Found {0} formats for display surface", formatCount);
			SurfaceFormatKHR[] surfaceFormats = new SurfaceFormatKHR[formatCount];
			res = VK.GetPhysicalDeviceSurfaceFormatsKHR(context.physicalDevice, context.surface, out formatCount, surfaceFormats);
			checkResult(res, "Failed to get physical device surface format values");

			//just use the first format/colorspace
			Format bestFormat = surfaceFormats[0].format;
			ColorSpaceKHR bestColorspace = surfaceFormats[0].colorSpace;

			UInt32 presentModeCount = 0;
			res = VK.GetPhysicalDeviceSurfacePresentModesKHR(context.physicalDevice, context.surface, out presentModeCount, null);
			checkResult(res, "Failed to get physical device surface present mode count");

			Console.WriteLine("Found {0} present modes for display surface", presentModeCount);
			PresentModeKHR[] presentModes = new PresentModeKHR[presentModeCount];
			res = VK.GetPhysicalDeviceSurfacePresentModesKHR(context.physicalDevice, context.surface, out presentModeCount, presentModes);
			checkResult(res, "Failed to get physical device surface present mode values");

			//prefer mailbox, but use fifo as a fallback
			PresentModeKHR bestPresentMode = PresentModeKHR.Fifo;
			foreach (PresentModeKHR availableMode in presentModes)
			{
				if (availableMode == PresentModeKHR.Mailbox)
				{
					bestPresentMode = availableMode;
					break;
				}
			}

			ImageUsageFlags usageFlags;
			if (context.surfaceCapabilities.supportedUsageFlags.HasFlag(ImageUsageFlags.TransferDst))
				usageFlags = ImageUsageFlags.ColorAttachment | ImageUsageFlags.TransferDst;
			else
				usageFlags = ImageUsageFlags.ColorAttachment;

			SwapchainCreateInfoKHR info = new SwapchainCreateInfoKHR()
			{
				SType = StructureType.SwapchainCreateInfoKHR,
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
				CompositeAlpha = CompositeAlphaFlagsKHR.Opaque,
				Clipped = true,
				OldSwapchain = new SwapchainKHR()
			};

			if (context.presentQueueIndex != context.graphicsQueueIndex)
			{
				info.ImageSharingMode = SharingMode.Concurrent;
				info.QueueFamilyIndices = new List<UInt32>() { (UInt32)context.presentQueueIndex, (UInt32)context.graphicsQueueIndex };
			}
			else
			{
				info.ImageSharingMode = SharingMode.Exclusive;
				info.QueueFamilyIndices = new List<UInt32>() { 0 };
			}

			res = VK.CreateSwapchainKHR(context.device, ref info, out context.swapChain);
			checkResult(res, "Failed to create swap chain");

			UInt32 imageCount = 0;
			res = VK.GetSwapchainImagesKHR(context.device, context.swapChain, out imageCount, null);
			checkResult(res, "Failed to get swamp chain image count");

			Console.WriteLine("Found {0} swapchain  images", imageCount);
			context.swapChainImages = new Image[imageCount];

			res = VK.GetSwapchainImagesKHR(context.device, context.swapChain, out imageCount, context.swapChainImages);
			checkResult(res, "Failed to get swap chain images");


			context.swapChainExtent = context.surfaceCapabilities.currentExtent;
			context.swapChainFormat = bestFormat;

			context.swapChainImageViews = new ImageView[context.swapChainImages.Length];
			for (int i = 0; i < context.swapChainImages.Length; i++)
			{
				ImageViewCreateInfo viewInfo = new ImageViewCreateInfo()
				{
					SType = StructureType.ImageViewCreateInfo,
					Next = IntPtr.Zero,
					Flags = 0,
					image = context.swapChainImages[i],
					ViewType = ImageViewType.View2D,
					Format = context.swapChainFormat,
					Components = new ComponentMapping()
					{
						R = ComponentSwizzle.Identity,
						G = ComponentSwizzle.Identity,
						B = ComponentSwizzle.Identity,
						A = ComponentSwizzle.Identity
					},
					SubresourceRange = new ImageSubresourceRange()
					{
						aspectMask = ImageAspectFlags.Color,
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
			SemaphoreCreateInfo info = new SemaphoreCreateInfo()
			{
				SType = StructureType.SemaphoreCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0
			};

			Result res = VK.CreateSemaphore(context.device, ref info, out context.imageAvailable);
			checkResult(res, "Creating image available semaphore");

			res = VK.CreateSemaphore(context.device, ref info, out context.renderingFinished);
			checkResult(res, "Creating rendering finished semaphore");

			Console.WriteLine("Success");
		}

		void createCommandBuffers()
		{
			Console.Write("Creating command buffers...");
			CommandPoolCreateInfo info = new CommandPoolCreateInfo()
			{
				SType = StructureType.CommandPoolCreateInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				QueueFamilyIndex = (UInt32)context.presentQueueIndex
			};

			Result res = VK.CreateCommandPool(context.device, ref info, out context.presentCommandPool);
			checkResult(res, "Creating present command pool");

			context.presentCommandBuffers = new CommandBuffer[context.swapChainImages.Length];

			CommandBufferAllocateInfo allocInfo = new CommandBufferAllocateInfo()
			{
				SType = StructureType.CommandBufferAllocateInfo,
				Next = IntPtr.Zero,
				CommandPool = context.presentCommandPool,
				Level = CommandBufferLevel.Primary,
				CommandBufferCount = (UInt32)context.swapChainImages.Length
			};

			res = VK.AllocateCommandBuffers(context.device, ref allocInfo, context.presentCommandBuffers);
			checkResult(res, "Create present command buffers");

			Console.WriteLine("Success");
		}

		void recordCommandBuffers()
		{
			Console.Write("Record command buffers...");
			CommandBufferBeginInfo beginInfo = new CommandBufferBeginInfo()
			{
				SType = StructureType.CommandBufferBeginInfo,
				Next = IntPtr.Zero,
				Flags = 0,
				InheritanceInfo = IntPtr.Zero
			};

			ClearColorValue clearColor = new ClearColorValue() { r = 1.0f, g = 0.8f, b = 0.4f, a = 0.0f };

			ImageSubresourceRange imageSubresourceRange =
				new ImageSubresourceRange()
				{
					aspectMask = ImageAspectFlags.Color,
					baseMipLevel = 0,
					levelCount = 1,
					baseArrayLayer = 0,
					layerCount = 1
				};

			for (int i = 0; i < context.swapChainImages.Length; i++)
			{
				ImageMemoryBarrier barrierFromPresentToClear =
					new ImageMemoryBarrier()
					{
						SType = StructureType.ImageMemoryBarrier,
						Next = IntPtr.Zero,
						SrcAccessMask = AccessFlags.MemoryRead,
						DstAccessMask = AccessFlags.TransferWrite,
						OldLayout = Vulkan.ImageLayout.Undefined,
						NewLayout = Vulkan.ImageLayout.TransferDstOptimal,
						SrcQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						DstQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						Image = context.swapChainImages[i],
						SubresourceRange = imageSubresourceRange
					};

				ImageMemoryBarrier barrierFromClearToPresent =
					new ImageMemoryBarrier()
					{
						SType = StructureType.ImageMemoryBarrier,
						Next = IntPtr.Zero,
						SrcAccessMask = AccessFlags.TransferWrite,
						DstAccessMask = AccessFlags.MemoryRead,
						OldLayout = Vulkan.ImageLayout.TransferDstOptimal,
						NewLayout = Vulkan.ImageLayout.PresentSrcKHR,
						SrcQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						DstQueueFamilyIndex = VK.QUEUE_FAMILY_IGNORED,
						Image = context.swapChainImages[i],
						SubresourceRange = imageSubresourceRange
					};


				Result res = VK.BeginCommandBuffer(context.presentCommandBuffers[i], ref beginInfo);
				checkResult(res, "Begin command buffer");

				VK.CmdPipelineBarrier(context.presentCommandBuffers[i], PipelineStageFlags.Transfer, PipelineStageFlags.Transfer, 0, 0, null, 0, null, 1, new ImageMemoryBarrier[] { barrierFromPresentToClear });
				
				VK.CmdClearColorImage(context.presentCommandBuffers[i], context.swapChainImages[i], Vulkan.ImageLayout.TransferDstOptimal, ref clearColor, 1, new ImageSubresourceRange[] { imageSubresourceRange });
				
				VK.CmdPipelineBarrier(context.presentCommandBuffers[i], PipelineStageFlags.Transfer, PipelineStageFlags.BottomOfPipe, 0, 0, null, 0, null, 1, new ImageMemoryBarrier[] { barrierFromClearToPresent});

				res = VK.EndCommandBuffer(context.presentCommandBuffers[i]);
				checkResult(res, "End command buffer");

				Console.WriteLine("Success");
			}
		}

		void createGraphicsPipeline()
		{

		}

		public void draw()
		{
			UInt32 index = 0;
			Result res = VK.AcquireNextImageKHR(context.device, context.swapChain, UInt64.MaxValue, context.imageAvailable, VK.NULL_FENCE, out index);
			checkResult(res, "Acquire next image");

			SubmitInfo submitInfo = new SubmitInfo()
			{
				SType = StructureType.SubmitInfo,
				Next = IntPtr.Zero,
				WaitSemaphores = new List<Semaphore>() { context.imageAvailable },
				WaitDstStageMask = PipelineStageFlags.Transfer,
				CommandBuffers = new List<CommandBuffer>() { context.presentCommandBuffers[index] },
				SignalSemaphores = new List<Semaphore>() { context.renderingFinished }
			};

			res = VK.QueueSubmit(context.presentQueue, 1, new SubmitInfo[] { submitInfo }, VK.NULL_FENCE);
			checkResult(res, "submit queue");

			PresentInfoKHR presentInfo = new PresentInfoKHR()
			{
				SType = StructureType.PresentInfoKHR,
				Next = IntPtr.Zero,
				WaitSemaphores = new List<Semaphore>() { context.renderingFinished },
				Swapchains = new List<SwapchainKHR>() { context.swapChain },
				Indices = new List<uint>() { index },
				Results = new List<Result>() { Result.NotReady}
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

		static Bool32 debugCallback(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 _object, IntPtr location, Int32 messageCode, string layerPrefix, string message, IntPtr userData)
		{
			string level = "";
			if (flags.HasFlag(DebugReportFlagsEXT.Error)) level = "Error";
			if (flags.HasFlag(DebugReportFlagsEXT.Warning)) level = "Warning";

			Console.WriteLine("{0}: {1}-{2} ", level, objectType, message);

			return false;
		}

		void checkResult(Result res, String msg)
		{
			if (res != Result.Success)
			{
				Console.WriteLine("Result Failed-{0}: {1}", res, msg);
			}
		}
	}
}