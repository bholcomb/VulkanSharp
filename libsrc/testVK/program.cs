using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;
using System.IO;
using System.Reflection;

using Vulkan;

namespace VulkanTest
{
   class QueueFamilyIndices
   {
      public Int32 graphicsFamily = -1;
      public Int32 presentFamily = -1;

      public bool isComplete()
      {
         return (graphicsFamily != -1) && (presentFamily != -1);
      }
   };

   class SwapChainSupportDetails
   {
      public VK.SurfaceCapabilitiesKHR capabilities;
      public VK.SurfaceFormatKHR[] formats;
      public VK.PresentModeKHR[] presentModes;
   };

   class VulkanApp
   {
      const int WIDTH = 800;
      const int HEIGHT = 600;
      const int MAX_FRAMES_IN_FLIGHT = 2;

      List<string> validationLayers = new List<string>() { InstanceLayers.VK_LAYER_LUNARG_standard_validation};
      List<string> instanceExtensions = new List<string>() { InstanceExtensions.VK_KHR_surface,
                                                                InstanceExtensions.VK_KHR_win32_surface,
                                                                InstanceExtensions.VK_EXT_debug_utils};
      List<string> deviceExtensions = new List<string>() { DeviceExtensions.VK_KHR_swapchain };

#if DEBUG
      const bool enableValidationLayers = true;
#else
      const bool enableValidationLayers = false;
#endif


      IntPtr HInstance;
      IntPtr Hwnd;

      VK.Instance instance;
      VK.DebugUtilsMessengerEXT debugMessenger;
      VK.SurfaceKHR surface;

      VK.PhysicalDevice physicalDevice;
      VK.Device device;

      VK.Queue graphicsQueue;
      VK.Queue presentQueue;

      VK.SwapchainKHR swapChain;
      VK.Image[] swapChainImages;
      VK.Format swapChainImageFormat;
      VK.Extent2D swapChainExtent;
      VK.ImageView[] swapChainImageViews;
      VK.Framebuffer[] swapChainFramebuffers;

      VK.RenderPass renderPass;
      VK.PipelineLayout pipelineLayout;
      VK.Pipeline graphicsPipeline;

      VK.CommandPool commandPool;
      VK.CommandBuffer[] commandBuffers;

      VK.Semaphore[] imageAvailableSemaphores;
      VK.Semaphore[] renderFinishedSemaphores;
      VK.Fence[] inFlightFences;
      UInt64 currentFrame = 0;

      bool framebufferResized = false;

      public void init(IntPtr appHandle, IntPtr windowHandle)
      {
         initWindow(appHandle, windowHandle);
         initVulkan();
      }

      void initWindow(IntPtr appHandle, IntPtr windowHandle)
      {
         HInstance = appHandle;
         Hwnd = windowHandle;
      }

      void initVulkan()
      {
         createInstance();
         setupDebugCallback();
         createSurface();
         pickPhysicalDevice();
         createLogicalDevice();
         createSwapChain();
         createImageViews();
         createRenderPass();
         createGraphicsPipeline();
         createFramebuffers();
         createCommandPool();
         createCommandBuffers();
         createSyncObjects();
      }

      public void cleanup()
      {
         cleanupSwapChain();

         for(int i = 0; i < MAX_FRAMES_IN_FLIGHT; i++)
         {
            VK.DestroySemaphore(device, renderFinishedSemaphores[i]);
            VK.DestroySemaphore(device, imageAvailableSemaphores[i]);
            VK.DestroyFence(device, inFlightFences[i]);
         }

         VK.DestroyCommandPool(device, commandPool);

         VK.DestroyDevice(device);

         if(enableValidationLayers)
         {
            VK.DestroyDebugUtilsMessengerEXT(instance, debugMessenger);
         }

         VK.DestroySurfaceKHR(instance, surface);
         VK.DestroyInstance(instance);
      }

      void cleanupSwapChain()
      {
         foreach(VK.Framebuffer framebuffer in swapChainFramebuffers)
         {
            VK.DestroyFramebuffer(device, framebuffer);
         }

         VK.FreeCommandBuffers(device, commandPool, (UInt32)commandBuffers.Length, commandBuffers);

         VK.DestroyPipeline(device, graphicsPipeline);
         VK.DestroyPipelineLayout(device, pipelineLayout);
         VK.DestroyRenderPass(device, renderPass);

         foreach(VK.ImageView imageView in swapChainImageViews)
         {
            VK.DestroyImageView(device, imageView);
         }

         VK.DestroySwapchainKHR(device, swapChain);
      }

      void recreateSwapChain()
      {
         int width = 0, height = 0;
         while(width == 0 || height == 0)
         {
            //                glfwGetFramebufferSize(window, &width, &height);
            //                glfwWaitEvents();
         }

         VK.DeviceWaitIdle(device);

         cleanupSwapChain();

         createSwapChain();
         createImageViews();
         createRenderPass();
         createGraphicsPipeline();
         createFramebuffers();
         createCommandBuffers();
      }

      void createInstance()
      {
         if(enableValidationLayers && !checkValidationLayerSupport())
         {
            throw new Exception("validation layers requested, but not available!");
         }

         if(enableValidationLayers)
         {
            instanceExtensions.Add(InstanceExtensions.VK_EXT_debug_utils);
         }

         VK.InstanceCreateInfo info = new VK.InstanceCreateInfo()
         {
            type = VK.StructureType.InstanceCreateInfo,
            next = IntPtr.Zero,
            flags = 0,
            applicationInfo = new VK.ApplicationInfo()
            {
               type = VK.StructureType.ApplicationInfo,
               next = IntPtr.Zero,
               applicationName = "Hello Triangle",
               applicationVersion = Vulkan.Version.Make(1, 0, 0),
               engineName = "Bobatron",
               engineVersion = 1,
               apiVersion = Vulkan.Version.Make(1, 1, 0)
            },
            enabledLayerNames = validationLayers,
            enabledExtensionNames = instanceExtensions
         };

         VK.Result result = VK.CreateInstance(info, out instance);
         if(result != VK.Result.Success)
         {
            throw new Exception("Failed to create Vulkan instance");
         }

         initInstanceExtensions();
      }

      void initInstanceExtensions()
      {
         VK.KHR_surface.init(instance);
         VK.KHR_win32_surface.init(instance);

         if(enableValidationLayers)
         {
            VK.EXT_debug_utils.init(instance);
         }
      }

      void initDeviceExtensions()
      {
         VK.KHR_swapchain.init(device);
      }

      void setupDebugCallback()
      {
         Console.WriteLine("Initializing debug utils callback");

         VK.DebugUtilsMessengerCreateInfoEXT info = new VK.DebugUtilsMessengerCreateInfoEXT()
         {
            type = VK.StructureType.DebugUtilsMessengerCreateInfoExt,
            next = IntPtr.Zero,
            flags = 0,
            messageSeverity = VK.DebugUtilsMessageSeverityFlagsEXT.ErrorBitExt |
                              VK.DebugUtilsMessageSeverityFlagsEXT.WarningBitExt,
            messageType = VK.DebugUtilsMessageTypeFlagsEXT.GeneralBitExt | VK.DebugUtilsMessageTypeFlagsEXT.PerformanceBitExt | VK.DebugUtilsMessageTypeFlagsEXT.ValidationBitExt,
            pfnUserCallback = debugCallback,
            pUserData = IntPtr.Zero
         };

         VK.Result res = VK.CreateDebugUtilsMessengerEXT(instance, ref info, null, out debugMessenger);
         if(res != VK.Result.Success)
         {
            Console.WriteLine("Failed to install debug utils callback");
         }
      }

      Bool32 debugCallback(VK.DebugUtilsMessageSeverityFlagsEXT messageSeverity, VK.DebugUtilsMessageTypeFlagsEXT messageTypes, ref VK.DebugUtilsMessengerCallbackDataEXT pCallbackData, IntPtr pUserData)
      {

         if(messageSeverity.HasFlag(VK.DebugUtilsMessageSeverityFlagsEXT.VerboseBitExt)) Console.Write("VERBOSE: ");
         if(messageSeverity.HasFlag(VK.DebugUtilsMessageSeverityFlagsEXT.InfoBitExt)) Console.Write("INFO: ");
         if(messageSeverity.HasFlag(VK.DebugUtilsMessageSeverityFlagsEXT.WarningBitExt)) Console.Write("WARNING: ");
         if(messageSeverity.HasFlag(VK.DebugUtilsMessageSeverityFlagsEXT.ErrorBitExt)) Console.Write("ERROR: ");

         if(messageTypes.HasFlag(VK.DebugUtilsMessageTypeFlagsEXT.GeneralBitExt)) Console.Write("GENERAL ");
         if(messageTypes.HasFlag(VK.DebugUtilsMessageTypeFlagsEXT.ValidationBitExt)) Console.Write("VALIDATION ");
         if(messageTypes.HasFlag(VK.DebugUtilsMessageTypeFlagsEXT.PerformanceBitExt)) Console.Write("PERFORMANCE ");

         Console.WriteLine(": ID: {0} Name: {1} \n\t {2}", pCallbackData.messageIdNumber, pCallbackData.pMessageIdName, pCallbackData.pMessage);

         // Don't bail out, but keep going.
         return false;
      }

      void createSurface()
      {
         Console.WriteLine("Creating surface");
         VK.Win32SurfaceCreateInfoKHR info = new VK.Win32SurfaceCreateInfoKHR()
         {
            type = VK.StructureType.Win32SurfaceCreateInfoKhr,
            next = IntPtr.Zero,
            flags = 0,
            hinstance = HInstance,
            hwnd = Hwnd
         };

         VK.Result res = VK.CreateWin32SurfaceKHR(instance, ref info, null, ref surface);
         if(res != VK.Result.Success)
         {
            Console.WriteLine("Failed to create surface");
         }
      }

      void pickPhysicalDevice()
      {
         UInt32 deviceCount = 0;
         VK.EnumeratePhysicalDevices(instance, ref deviceCount, null);

         if(deviceCount == 0)
         {
            throw new Exception("failed to find GPUs with Vulkan support!");
         }

         VK.PhysicalDevice[] devices = new VK.PhysicalDevice[deviceCount];
         VK.EnumeratePhysicalDevices(instance, ref deviceCount, devices);

         foreach(VK.PhysicalDevice device in devices)
         {
            if(isDeviceSuitable(device))
            {
               physicalDevice = device;
               break;
            }
         }

         if(physicalDevice.native == IntPtr.Zero)
         {
            throw new Exception("failed to find a suitable GPU!");
         }
      }

      void createLogicalDevice()
      {
         QueueFamilyIndices indices = findQueueFamilies(physicalDevice);

         List<VK.DeviceQueueCreateInfo> queueCreateInfos = new List<VK.DeviceQueueCreateInfo>();
         List<UInt32> queueFamilies = new List<UInt32>();
         queueFamilies.Add((UInt32)indices.graphicsFamily);
         queueFamilies.Add((UInt32)indices.presentFamily);

         foreach(UInt32 familyIndex in queueFamilies)
         {
            queueCreateInfos.Add(
               new VK.DeviceQueueCreateInfo()
               {
                  type = VK.StructureType.DeviceQueueCreateInfo,
                  next = IntPtr.Zero,
                  flags = 0,
                  queueFamilyIndex = familyIndex,
                  queueCount = 1,
                  queuePriorities = new float[1] { 1.0f }
               }
            );
         }


         VK.PhysicalDeviceFeatures deviceFeatures = new VK.PhysicalDeviceFeatures();

         VK.DeviceCreateInfo info = new VK.DeviceCreateInfo()
         {
            type = VK.StructureType.DeviceCreateInfo,
            next = IntPtr.Zero,
            flags = 0,
            queueCreateInfos = queueCreateInfos,
            enabledFeatures = deviceFeatures,
            enabledExtensionNames = deviceExtensions,
            enabledLayerNames = new List<string>() { }
         };


         if(VK.CreateDevice(physicalDevice, info, out device) != VK.Result.Success)
         {
            throw new Exception("failed to create logical device!");
         }

         VK.GetDeviceQueue(device, (UInt32)indices.graphicsFamily, 0, out graphicsQueue);
         VK.GetDeviceQueue(device, (UInt32)indices.presentFamily, 0, out presentQueue);

         initDeviceExtensions();
      }

      void createSwapChain()
      {
         SwapChainSupportDetails swapChainSupport = querySwapChainSupport(physicalDevice);

         VK.SurfaceFormatKHR surfaceFormat = chooseSwapSurfaceFormat(swapChainSupport.formats);
         VK.PresentModeKHR presentMode = chooseSwapPresentMode(swapChainSupport.presentModes);
         VK.Extent2D extent = chooseSwapExtent(swapChainSupport.capabilities);

         UInt32 imageCount = swapChainSupport.capabilities.minImageCount + 1;
         if(swapChainSupport.capabilities.maxImageCount > 0 && imageCount > swapChainSupport.capabilities.maxImageCount)
         {
            imageCount = swapChainSupport.capabilities.maxImageCount;
         }

         VK.SwapchainCreateInfoKHR createInfo = new VK.SwapchainCreateInfoKHR();
         createInfo.type = VK.StructureType.SwapchainCreateInfoKhr;
         createInfo.surface = surface;
         createInfo.minImageCount = imageCount;
         createInfo.imageFormat = surfaceFormat.format;
         createInfo.imageColorSpace = surfaceFormat.colorSpace;
         createInfo.imageExtent = extent;
         createInfo.imageArrayLayers = 1;
         createInfo.imageUsage = VK.ImageUsageFlags.ColorAttachmentBit;

         QueueFamilyIndices indices = findQueueFamilies(physicalDevice);
         List<UInt32> queueFamilyIndices = new List<UInt32> { (UInt32)indices.graphicsFamily, (UInt32)indices.presentFamily };

         if(indices.graphicsFamily != indices.presentFamily)
         {
            createInfo.imageSharingMode = VK.SharingMode.Concurrent;
            createInfo.queueFamilyIndices = queueFamilyIndices;
         }
         else
         {
            createInfo.imageSharingMode = VK.SharingMode.Exclusive;
            createInfo.queueFamilyIndices = null;
         }

         createInfo.preTransform = swapChainSupport.capabilities.currentTransform;
         createInfo.compositeAlpha = VK.CompositeAlphaFlagsKHR.OpaqueBit;
         createInfo.presentMode = presentMode;
         createInfo.clipped = true;

         if(VK.CreateSwapchainKHR(device, ref createInfo, ref swapChain) != VK.Result.Success)
         {
            throw new Exception("failed to create swap chain!");
         }

         VK.GetSwapchainImagesKHR(device, swapChain, ref imageCount, null);
         swapChainImages = new VK.Image[imageCount];
         VK.GetSwapchainImagesKHR(device, swapChain, ref imageCount, swapChainImages);

         swapChainImageFormat = surfaceFormat.format;
         swapChainExtent = extent;
      }

      void createImageViews()
      {
         swapChainImageViews = new VK.ImageView[swapChainImages.Length];

         for(int i = 0; i < swapChainImages.Length; i++)
         {
            VK.ImageViewCreateInfo createInfo = new VK.ImageViewCreateInfo();
            createInfo.type = VK.StructureType.ImageViewCreateInfo;
            createInfo.image = swapChainImages[i];
            createInfo.viewType = VK.ImageViewType._2d;
            createInfo.format = swapChainImageFormat;
            createInfo.components.r = VK.ComponentSwizzle.Identity;
            createInfo.components.g = VK.ComponentSwizzle.Identity;
            createInfo.components.b = VK.ComponentSwizzle.Identity;
            createInfo.components.a = VK.ComponentSwizzle.Identity; ;
            createInfo.subresourceRange.aspectMask = VK.ImageAspectFlags.ColorBit;
            createInfo.subresourceRange.baseMipLevel = 0;
            createInfo.subresourceRange.levelCount = 1;
            createInfo.subresourceRange.baseArrayLayer = 0;
            createInfo.subresourceRange.layerCount = 1;

            if(VK.CreateImageView(device, ref createInfo, out swapChainImageViews[i]) != VK.Result.Success)
            {
               throw new Exception("failed to create image views!");
            }
         }
      }

      void createRenderPass()
      {
         VK.AttachmentDescription colorAttachment = new VK.AttachmentDescription();
         colorAttachment.format = swapChainImageFormat;
         colorAttachment.samples = VK.SampleCountFlags._1Bit;
         colorAttachment.loadOp = VK.AttachmentLoadOp.Clear;
         colorAttachment.storeOp = VK.AttachmentStoreOp.Store;
         colorAttachment.stencilLoadOp = VK.AttachmentLoadOp.DontCare;
         colorAttachment.stencilStoreOp = VK.AttachmentStoreOp.DontCare;
         colorAttachment.initialLayout = VK.ImageLayout.Undefined;
         colorAttachment.finalLayout = VK.ImageLayout.PresentSrcKhr;

         VK.AttachmentReference colorAttachmentRef = new VK.AttachmentReference();
         colorAttachmentRef.attachment = 0;
         colorAttachmentRef.layout = VK.ImageLayout.ColorAttachmentOptimal;

         VK.SubpassDescription subpass = new VK.SubpassDescription();
         subpass.pipelineBindPoint = VK.PipelineBindPoint.Graphics;
         subpass.colorAttachments = new List<VK.AttachmentReference> { colorAttachmentRef };

         VK.SubpassDependency dependency = new VK.SubpassDependency();
         dependency.srcSubpass = VK.SUBPASS_EXTERNAL;
         dependency.dstSubpass = 0;
         dependency.srcStageMask = VK.PipelineStageFlags.ColorAttachmentOutputBit;
         dependency.srcAccessMask = 0;
         dependency.dstStageMask = VK.PipelineStageFlags.ColorAttachmentOutputBit;
         dependency.dstAccessMask = VK.AccessFlags.ColorAttachmentReadBit | VK.AccessFlags.ColorAttachmentWriteBit;

         VK.RenderPassCreateInfo renderPassInfo = new VK.RenderPassCreateInfo();
         renderPassInfo.type = VK.StructureType.RenderPassCreateInfo;
         renderPassInfo.attachments = new List<VK.AttachmentDescription> { colorAttachment };
         renderPassInfo.subpasses = new List<VK.SubpassDescription> { subpass };
         renderPassInfo.dependencies = new List<VK.SubpassDependency> { dependency };

         if(VK.CreateRenderPass(device, ref renderPassInfo, out renderPass) != VK.Result.Success)
         {
            throw new Exception("failed to create render pass!");
         }
      }

      void createGraphicsPipeline()
      {
         byte[] vertShaderCode = getEmbeddedResource("VulkanTest.libsrc.testVK.shaders.simpleTri.vert.glsl.spv");
         byte[] fragShaderCode = getEmbeddedResource("VulkanTest.libsrc.testVK.shaders.simpleTri.frag.glsl.spv");

         VK.ShaderModule vertShaderModule = createShaderModule(vertShaderCode);
         VK.ShaderModule fragShaderModule = createShaderModule(fragShaderCode);

         VK.PipelineShaderStageCreateInfo vertShaderStageInfo = new VK.PipelineShaderStageCreateInfo();
         vertShaderStageInfo.type = VK.StructureType.PipelineShaderStageCreateInfo;
         vertShaderStageInfo.stage = VK.ShaderStageFlags.VertexBit;
         vertShaderStageInfo.module = vertShaderModule;
         vertShaderStageInfo.name = "main";

         VK.PipelineShaderStageCreateInfo fragShaderStageInfo = new VK.PipelineShaderStageCreateInfo();
         fragShaderStageInfo.type = VK.StructureType.PipelineShaderStageCreateInfo;
         fragShaderStageInfo.stage = VK.ShaderStageFlags.FragmentBit;
         fragShaderStageInfo.module = fragShaderModule;
         fragShaderStageInfo.name = "main";

         List<VK.PipelineShaderStageCreateInfo> shaderStages = new List<VK.PipelineShaderStageCreateInfo> { vertShaderStageInfo, fragShaderStageInfo };

         VK.PipelineVertexInputStateCreateInfo vertexInputInfo = new VK.PipelineVertexInputStateCreateInfo();
         vertexInputInfo.type = VK.StructureType.PipelineVertexInputStateCreateInfo;
         vertexInputInfo.vertexBindingDescriptions = null;
         vertexInputInfo.vertexAttributeDescriptions = null;

         VK.PipelineInputAssemblyStateCreateInfo inputAssembly = new VK.PipelineInputAssemblyStateCreateInfo();
         inputAssembly.type = VK.StructureType.PipelineInputAssemblyStateCreateInfo;
         inputAssembly.topology = VK.PrimitiveTopology.TriangleList;
         inputAssembly.primitiveRestartEnable = false;

         VK.Viewport viewport = new VK.Viewport();
         viewport.x = 0.0f;
         viewport.y = 0.0f;
         viewport.width = (float)swapChainExtent.width;
         viewport.height = (float)swapChainExtent.height;
         viewport.minDepth = 0.0f;
         viewport.maxDepth = 1.0f;

         VK.Rect2D scissor = new VK.Rect2D();
         scissor.offset = new VK.Offset2D { x = 0, y = 0 };
         scissor.extent = swapChainExtent;

         VK.PipelineViewportStateCreateInfo viewportState = new VK.PipelineViewportStateCreateInfo();
         viewportState.type = VK.StructureType.PipelineViewportStateCreateInfo;
         viewportState.viewports = new List<VK.Viewport> { viewport };
         viewportState.scissors = new List<VK.Rect2D> { scissor };

         VK.PipelineRasterizationStateCreateInfo rasterizer = new VK.PipelineRasterizationStateCreateInfo();
         rasterizer.type = VK.StructureType.PipelineRasterizationStateCreateInfo;
         rasterizer.depthClampEnable = false;
         rasterizer.rasterizerDiscardEnable = false;
         rasterizer.polygonMode = VK.PolygonMode.Fill;
         rasterizer.lineWidth = 1.0f;
         rasterizer.cullMode = VK.CullModeFlags.BackBit;
         rasterizer.frontFace = VK.FrontFace.Clockwise;
         rasterizer.depthBiasEnable = false;

         VK.PipelineMultisampleStateCreateInfo multisampling = new VK.PipelineMultisampleStateCreateInfo();
         multisampling.type = VK.StructureType.PipelineMultisampleStateCreateInfo;
         multisampling.sampleShadingEnable = false;
         multisampling.rasterizationSamples = VK.SampleCountFlags._1Bit;

         VK.PipelineColorBlendAttachmentState colorBlendAttachment = new VK.PipelineColorBlendAttachmentState();
         colorBlendAttachment.colorWriteMask = VK.ColorComponentFlags.RBit | VK.ColorComponentFlags.GBit | VK.ColorComponentFlags.BBit | VK.ColorComponentFlags.ABit;
         colorBlendAttachment.blendEnable = false;

         VK.PipelineColorBlendStateCreateInfo colorBlending = new VK.PipelineColorBlendStateCreateInfo();
         colorBlending.type = VK.StructureType.PipelineColorBlendStateCreateInfo;
         colorBlending.logicOpEnable = false;
         colorBlending.logicOp = VK.LogicOp.Copy;
         colorBlending.attachments = new List<VK.PipelineColorBlendAttachmentState> { colorBlendAttachment };
         colorBlending.blendConstants = new List<float> { 0.0f, 0.0f, 0.0f, 0.0f };

         VK.PipelineLayoutCreateInfo pipelineLayoutInfo = new VK.PipelineLayoutCreateInfo();
         pipelineLayoutInfo.type = VK.StructureType.PipelineLayoutCreateInfo;
         pipelineLayoutInfo.setLayouts = null;
         pipelineLayoutInfo.pushConstantRanges = null;

         if(VK.CreatePipelineLayout(device, ref pipelineLayoutInfo, out pipelineLayout) != VK.Result.Success)
         {
            throw new Exception("failed to create pipeline layout!");
         }

         VK.GraphicsPipelineCreateInfo pipelineInfo = new VK.GraphicsPipelineCreateInfo();
         pipelineInfo.type = VK.StructureType.GraphicsPipelineCreateInfo;
         pipelineInfo.stages = shaderStages;
         pipelineInfo.vertexInputState = vertexInputInfo;
         pipelineInfo.inputAssemblyState = inputAssembly;
         pipelineInfo.viewportState = viewportState;
         pipelineInfo.rasterizationState = rasterizer;
         pipelineInfo.multisampleState = multisampling;
         pipelineInfo.colorBlendState = colorBlending;
         pipelineInfo.layout = pipelineLayout;
         pipelineInfo.renderPass = renderPass;
         pipelineInfo.subpass = 0;
         pipelineInfo.basePipelineHandle = VK.NullPipeline;

         if(VK.CreateGraphicsPipelines(device, VK.NullPipelineCache, 1, new VK.GraphicsPipelineCreateInfo[] { pipelineInfo }, new VK.Pipeline[] { graphicsPipeline }) != VK.Result.Success)
         {
            throw new Exception("failed to create graphics pipeline!");
         }

         VK.DestroyShaderModule(device, fragShaderModule);
         VK.DestroyShaderModule(device, vertShaderModule);
      }

      void createFramebuffers()
      {
         swapChainFramebuffers = new VK.Framebuffer[swapChainImageViews.Length];

         for(int i = 0; i < swapChainImageViews.Length; i++)
         {
            List<VK.ImageView> attachments = new List<VK.ImageView> { swapChainImageViews[i] };

            VK.FramebufferCreateInfo framebufferInfo = new VK.FramebufferCreateInfo();
            framebufferInfo.type = VK.StructureType.FramebufferCreateInfo;
            framebufferInfo.renderPass = renderPass;
            framebufferInfo.attachments = attachments;
            framebufferInfo.width = swapChainExtent.width;
            framebufferInfo.height = swapChainExtent.height;
            framebufferInfo.layers = 1;

            if(VK.CreateFramebuffer(device, framebufferInfo, out swapChainFramebuffers[i]) != VK.Result.Success)
            {
               throw new Exception("failed to create framebuffer!");
            }
         }
      }

      void createCommandPool()
      {
         QueueFamilyIndices queueFamilyIndices = findQueueFamilies(physicalDevice);

         VK.CommandPoolCreateInfo poolInfo = new VK.CommandPoolCreateInfo();
         poolInfo.type = VK.StructureType.CommandPoolCreateInfo;
         poolInfo.queueFamilyIndex = (UInt32)queueFamilyIndices.graphicsFamily;

         if(VK.CreateCommandPool(device, ref poolInfo, out commandPool) != VK.Result.Success)
         {
            throw new Exception("failed to create command pool!");
         }
      }

      void createCommandBuffers()
      {
         commandBuffers = new VK.CommandBuffer[swapChainFramebuffers.Length];

         VK.CommandBufferAllocateInfo allocInfo = new VK.CommandBufferAllocateInfo();
         allocInfo.type = VK.StructureType.CommandBufferAllocateInfo;
         allocInfo.commandPool = commandPool;
         allocInfo.level = VK.CommandBufferLevel.Primary;
         allocInfo.commandBufferCount = (UInt32)commandBuffers.Length;

         if(VK.AllocateCommandBuffers(device, ref allocInfo, commandBuffers) != VK.Result.Success)
         {
            throw new Exception("failed to allocate command buffers!");
         }

         for(int i = 0; i < commandBuffers.Length; i++)
         {
            VK.CommandBufferBeginInfo beginInfo = new VK.CommandBufferBeginInfo();
            beginInfo.type = VK.StructureType.CommandBufferBeginInfo;

            if(VK.BeginCommandBuffer(commandBuffers[i], ref beginInfo) != VK.Result.Success)
            {
               throw new Exception("failed to begin recording command buffer!");
            }

            VK.RenderPassBeginInfo renderPassInfo = new VK.RenderPassBeginInfo();
            renderPassInfo.type = VK.StructureType.RenderPassBeginInfo;
            renderPassInfo.renderPass = renderPass;
            renderPassInfo.framebuffer = swapChainFramebuffers[i];
            renderPassInfo.renderArea.offset = new VK.Offset2D() { x = 0, y = 0 };
            renderPassInfo.renderArea.extent = swapChainExtent;

            VK.ClearValue clearColor = new VK.ClearValue();
            clearColor.color.r = 0.0f;
            clearColor.color.g = 0.0f;
            clearColor.color.b = 0.0f;
            clearColor.color.a = 1.0f;
            renderPassInfo.clearValues = new List<VK.ClearValue> { clearColor };

            VK.CmdBeginRenderPass(commandBuffers[i], ref renderPassInfo, VK.SubpassContents.Inline);

            VK.CmdBindPipeline(commandBuffers[i], VK.PipelineBindPoint.Graphics, graphicsPipeline);

            VK.CmdDraw(commandBuffers[i], 3, 1, 0, 0);

            VK.CmdEndRenderPass(commandBuffers[i]);

            if(VK.EndCommandBuffer(commandBuffers[i]) != VK.Result.Success)
            {
               throw new Exception("failed to record command buffer!");
            }
         }
      }

      void createSyncObjects()
      {
         imageAvailableSemaphores = new VK.Semaphore[MAX_FRAMES_IN_FLIGHT];
         renderFinishedSemaphores = new VK.Semaphore[MAX_FRAMES_IN_FLIGHT];
         inFlightFences = new VK.Fence[MAX_FRAMES_IN_FLIGHT];

         VK.SemaphoreCreateInfo semaphoreInfo = new VK.SemaphoreCreateInfo();
         semaphoreInfo.type = VK.StructureType.SemaphoreCreateInfo;

         VK.FenceCreateInfo fenceInfo = new VK.FenceCreateInfo();
         fenceInfo.type = VK.StructureType.FenceCreateInfo;
         fenceInfo.flags = VK.FenceCreateFlags.SignaledBit;

         for(int i = 0; i < MAX_FRAMES_IN_FLIGHT; i++)
         {
            if(VK.CreateSemaphore(device, ref semaphoreInfo, out imageAvailableSemaphores[i]) != VK.Result.Success ||
                VK.CreateSemaphore(device, ref semaphoreInfo, out renderFinishedSemaphores[i]) != VK.Result.Success ||
                VK.CreateFence(device, ref fenceInfo, out inFlightFences[i]) != VK.Result.Success)
            {
               throw new Exception("failed to create synchronization objects for a frame!");
            }
         }
      }

      public void drawFrame()
      {
         VK.WaitForFences(device, 1, new VK.Fence[] { inFlightFences[currentFrame] }, true, UInt64.MaxValue);

         UInt32 imageIndex = 0;
         VK.Result result = VK.AcquireNextImageKHR(device, swapChain, UInt64.MaxValue, imageAvailableSemaphores[currentFrame], VK.NULL_FENCE, ref imageIndex);

         if(result == VK.Result.ErrorOutOfDateKhr)
         {
            recreateSwapChain();
            return;
         }
         else if(result != VK.Result.Success && result != VK.Result.SuboptimalKhr)
         {
            throw new Exception("failed to acquire swap chain image!");
         }

         List<VK.Semaphore> signalSemaphores = new List<VK.Semaphore> { renderFinishedSemaphores[currentFrame] };
         VK.SubmitInfo submitInfo = new VK.SubmitInfo();
         submitInfo.type = VK.StructureType.SubmitInfo;
         submitInfo.waitSemaphores = new List<VK.Semaphore> { imageAvailableSemaphores[currentFrame] };
         submitInfo.waitDstStageMask = new List<VK.PipelineStageFlags> { VK.PipelineStageFlags.ColorAttachmentOutputBit };
         submitInfo.commandBuffers = new List<VK.CommandBuffer> { commandBuffers[imageIndex] };
         submitInfo.signalSemaphores = signalSemaphores;

         VK.ResetFences(device, 1, new VK.Fence[] { inFlightFences[currentFrame] });

         if(VK.QueueSubmit(graphicsQueue, 1, new VK.SubmitInfo[] { submitInfo }, inFlightFences[currentFrame]) != VK.Result.Success)
         {
            throw new Exception("failed to submit draw command buffer!");
         }

         VK.PresentInfoKHR presentInfo = new VK.PresentInfoKHR();
         presentInfo.type = VK.StructureType.PresentInfoKhr;
         presentInfo.waitSemaphores = signalSemaphores;
         presentInfo.swapchains = new List<VK.SwapchainKHR> { swapChain };
         presentInfo.indices = new List<UInt32>() { imageIndex };

         result = VK.QueuePresentKHR(presentQueue, ref presentInfo);

         if(result == VK.Result.ErrorOutOfDateKhr || result == VK.Result.SuboptimalKhr || framebufferResized)
         {
            framebufferResized = false;
            recreateSwapChain();
         }
         else if(result != VK.Result.Success)
         {
            throw new Exception("failed to present swap chain image!");
         }

         currentFrame = (currentFrame + 1) % MAX_FRAMES_IN_FLIGHT;
      }

      VK.ShaderModule createShaderModule(byte[] code)
      {
         VK.ShaderModuleCreateInfo createInfo = new VK.ShaderModuleCreateInfo();
         createInfo.type = VK.StructureType.ShaderModuleCreateInfo;
         createInfo.code = code;

         VK.ShaderModule shaderModule;
         if(VK.CreateShaderModule(device, ref createInfo, out shaderModule) != VK.Result.Success)
         {
            throw new Exception("failed to create shader module!");
         }

         return shaderModule;
      }

      VK.SurfaceFormatKHR chooseSwapSurfaceFormat(VK.SurfaceFormatKHR[] availableFormats)
      {
         foreach(VK.SurfaceFormatKHR availableFormat in availableFormats)
         {
            if(availableFormat.format == VK.Format.B8g8r8a8Unorm && availableFormat.colorSpace == VK.ColorSpaceKHR.SrgbNonlinear)
            {
               return availableFormat;
            }
         }

         return availableFormats[0];
      }

      VK.PresentModeKHR chooseSwapPresentMode(VK.PresentModeKHR[] availablePresentModes)
      {
         foreach(VK.PresentModeKHR availablePresentMode in availablePresentModes)
         {
            if(availablePresentMode == VK.PresentModeKHR.Mailbox)
            {
               return availablePresentMode;
            }
         }

         return VK.PresentModeKHR.Fifo;
      }

      VK.Extent2D chooseSwapExtent(VK.SurfaceCapabilitiesKHR capabilities)
      {
         if(capabilities.currentExtent.width != UInt32.MaxValue)
         {
            return capabilities.currentExtent;
         }
         else
         {
            int width = WIDTH;
            int height = HEIGHT;
            //glfwGetFramebufferSize(window, &width, &height);

            VK.Extent2D actualExtent = new VK.Extent2D();
            actualExtent.width = (UInt32)width;
            actualExtent.height = (UInt32)height;

            actualExtent.width = Math.Max(capabilities.minImageExtent.width, Math.Min(capabilities.maxImageExtent.width, actualExtent.width));
            actualExtent.height = Math.Max(capabilities.minImageExtent.height, Math.Min(capabilities.maxImageExtent.height, actualExtent.height));

            return actualExtent;
         }
      }

      SwapChainSupportDetails querySwapChainSupport(VK.PhysicalDevice device)
      {
         SwapChainSupportDetails details = new SwapChainSupportDetails();

         VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(device, surface, out details.capabilities);

         UInt32 formatCount = 0;
         VK.GetPhysicalDeviceSurfaceFormatsKHR(device, surface, ref formatCount, null);

         if(formatCount != 0)
         {
            details.formats = new VK.SurfaceFormatKHR[formatCount];
            VK.GetPhysicalDeviceSurfaceFormatsKHR(device, surface, ref formatCount, details.formats);
         }

         UInt32 presentModeCount = 0;
         VK.GetPhysicalDeviceSurfacePresentModesKHR(device, surface, ref presentModeCount, null);

         if(presentModeCount != 0)
         {
            details.presentModes = new VK.PresentModeKHR[presentModeCount];
            VK.GetPhysicalDeviceSurfacePresentModesKHR(device, surface, ref presentModeCount, details.presentModes);
         }

         return details;
      }

      bool isDeviceSuitable(VK.PhysicalDevice device)
      {
         QueueFamilyIndices indices = findQueueFamilies(device);
         bool extensionsSupported = checkDeviceExtensionSupport(device);

         bool swapChainAdequate = false;
         if(extensionsSupported)
         {
            SwapChainSupportDetails swapChainSupport = querySwapChainSupport(device);
            swapChainAdequate = (swapChainSupport.formats.Length > 0) && (swapChainSupport.presentModes.Length > 0);
         }

         VK.PhysicalDeviceProperties props;
         VK.GetPhysicalDeviceProperties(device, out props);

         VK.PhysicalDeviceFeatures supportedFeatures;
         VK.GetPhysicalDeviceFeatures(device, out supportedFeatures);

         if(props.deviceType != VK.PhysicalDeviceType.DiscreteGpu)
         {
            return false;
         }

         return indices.isComplete() && extensionsSupported && swapChainAdequate;
      }

      bool checkDeviceExtensionSupport(VK.PhysicalDevice device)
      {
         UInt32 extensionCount = 0;
         VK.EnumerateDeviceExtensionProperties(device, null, ref extensionCount, null);

         VK.ExtensionProperties[] availableExtensions = new VK.ExtensionProperties[extensionCount];
         VK.EnumerateDeviceExtensionProperties(device, null, ref extensionCount, availableExtensions);

         bool allFound = true;
         foreach(string extension in deviceExtensions)
         {
            bool found = false;
            foreach(VK.ExtensionProperties ext in availableExtensions)
            {
               if(ext.extensionName == extension)
               {
                  found = true;
                  break;
               }
            }

            allFound = allFound && found;
         }

         return allFound;
      }


      QueueFamilyIndices findQueueFamilies(VK.PhysicalDevice device)
      {
         QueueFamilyIndices indices = new QueueFamilyIndices();

         UInt32 queueFamilyCount = 0;
         VK.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilyCount, null);

         VK.QueueFamilyProperties[] queueFamilies = new VK.QueueFamilyProperties[queueFamilyCount];
         VK.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilyCount, queueFamilies);

         Int32 i = 0;
         foreach(VK.QueueFamilyProperties queueFamily in queueFamilies)
         {
            if((queueFamily.queueCount > 0) && queueFamily.queueFlags.HasFlag(VK.QueueFlags.GraphicsBit))
            {
               indices.graphicsFamily = i;
            }

            Bool32 presentSupport = false;
            VK.GetPhysicalDeviceSurfaceSupportKHR(device, (UInt32)i, surface, out presentSupport);

            if(queueFamily.queueCount > 0 && presentSupport)
            {
               indices.presentFamily = i;
            }

            if(indices.isComplete())
            {
               break;
            }

            i++;
         }

         return indices;
      }

      bool checkValidationLayerSupport()
      {
         UInt32 layerCount = 0;
         VK.EnumerateInstanceLayerProperties(ref layerCount, null);

         VK.LayerProperties[] availableLayers = new VK.LayerProperties[layerCount];
         VK.EnumerateInstanceLayerProperties(ref layerCount, availableLayers);

         foreach(String layerName in validationLayers)
         {
            bool layerFound = false;

            foreach(VK.LayerProperties layerProperties in availableLayers)
            {
               if(layerName == layerProperties.layerName)
               {
                  layerFound = true;
                  break;
               }
            }

            if(!layerFound)
            {
               return false;
            }
         }

         return true;
      }

      void enumerateInstanceLayers()
      {
         Console.WriteLine("Enumerating Instance Layer Properties");
         UInt32 count = 0;
         VK.EnumerateInstanceLayerProperties(ref count, null);

         VK.LayerProperties[] props = new VK.LayerProperties[count];
         VK.EnumerateInstanceLayerProperties(ref count, props);

         for(int i = 0; i < props.Length; i++)
         {
            Console.WriteLine("\tLayer Name: {0}", props[i].layerName);
            Console.WriteLine("\t\tDescription: {0}", props[i].description);
         }
      }

      void enumerateInstanceExtensions()
      {
         Console.WriteLine("Enumerating Instance Extensions");
         UInt32 count = 0;
         VK.EnumerateInstanceExtensionProperties(null, out count, null);

         VK.ExtensionProperties[] props = new VK.ExtensionProperties[count];
         VK.EnumerateInstanceExtensionProperties(null, out count, props);

         for(int i = 0; i < props.Length; i++)
         {
            Console.WriteLine("\tExtensions Name: {0}", props[i].extensionName);
         }
      }

      void enumerateDeviceLayers()
      {
         Console.WriteLine("Enumerating Device Layer Properties");
         UInt32 count = 0;
         VK.EnumerateDeviceLayerProperties(physicalDevice, out count, null);

         VK.LayerProperties[] props = new VK.LayerProperties[count];
         VK.EnumerateDeviceLayerProperties(physicalDevice, out count, props);

         for(int i = 0; i < props.Length; i++)
         {
            Console.WriteLine("\tLayer Name: {0}", props[i].layerName);
            Console.WriteLine("\t\tDescription: {0}", props[i].description);
         }
      }

      void enumerateDeviceExtensions()
      {
         Console.WriteLine("Enumerating Device Extensions");
         UInt32 count = 0;
         VK.EnumerateDeviceExtensionProperties(physicalDevice, null, ref count, null);

         VK.ExtensionProperties[] props = new VK.ExtensionProperties[count];
         VK.EnumerateDeviceExtensionProperties(physicalDevice, null, ref count, props);

         for(int i = 0; i < props.Length; i++)
         {
            Console.WriteLine("\tExtensions Name: {0}", props[i].extensionName);
         }
      }

      byte[] getEmbeddedResource(string resourceName)
      {
         Assembly[] asses = AppDomain.CurrentDomain.GetAssemblies();
         foreach(Assembly ass in asses)
         {
            string[] resources = ass.GetManifestResourceNames();
            foreach(string s in resources)
            {
               if(s == resourceName)
               {
                  Stream stream = ass.GetManifestResourceStream(resourceName);
                  if(stream == null)
                  {
                     Console.WriteLine("Cannot find embedded resource {0}", resourceName);
                     return null;
                  }

                  using(var memoryStream = new MemoryStream())
                  {
                     stream.CopyTo(memoryStream);
                     return memoryStream.ToArray();
                  }
               }
            }
         }

         return null;
      }
   };
}