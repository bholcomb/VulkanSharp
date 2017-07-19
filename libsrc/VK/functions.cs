using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
	public static partial class VK
	{
		[DllImport(VulkanLibrary, EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static unsafe extern Result _CreateInstance(ref _InstanceCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Instance pInstance);
		public static Result CreateInstance(InstanceCreateInfo createInfo, out Instance pInstance, AllocationCallbacks alloc = null)
		{
			//marshal to the internal structure
			_InstanceCreateInfo info = new _InstanceCreateInfo(createInfo);

			//call the native function
			Result ret = _CreateInstance(ref info, alloc, out pInstance);

			//cleanup the marshaling memory
			info.destroy();

			//return
			return ret;
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyInstance(Instance instance, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _EnumeratePhysicalDevices(Instance instance, out UInt32 pPhysicalDeviceCount, IntPtr pPhysicalDevices);
		public unsafe static Result EnumeratePhysicalDevices(Instance instance, ref UInt32 pPhysicalDeviceCount, PhysicalDevice[] pPhysicalDevices)
		{
			if(pPhysicalDevices == null)
			{
				return _EnumeratePhysicalDevices(instance, out pPhysicalDeviceCount, IntPtr.Zero);
			}

			Result res;
			fixed(PhysicalDevice* ptr = pPhysicalDevices)
			{
				res = _EnumeratePhysicalDevices(instance, out pPhysicalDeviceCount, (IntPtr)ptr);
			}
			
			return res;
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr GetDeviceProcAddr(Device device, string pName);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr GetInstanceProcAddr(Instance instance, string pName);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, out PhysicalDeviceProperties pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern void _GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, out UInt32 pQueueFamilyPropertyCount, IntPtr pQueueFamilyProperties);
		public unsafe static void GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, out UInt32 pQueueFamilyPropertyCount, QueueFamilyProperties[] pQueueFamilyProperties)
		{
			if (pQueueFamilyProperties == null)
			{
				_GetPhysicalDeviceQueueFamilyProperties(physicalDevice, out pQueueFamilyPropertyCount, IntPtr.Zero);
			}
			else
			{
				fixed (QueueFamilyProperties* ptr = pQueueFamilyProperties)
				{
					_GetPhysicalDeviceQueueFamilyProperties(physicalDevice, out pQueueFamilyPropertyCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, out PhysicalDeviceMemoryProperties pMemoryProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, out PhysicalDeviceFeatures pFeatures);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, out FormatProperties pFormatProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, out ImageFormatProperties pImageFormatProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateDevice(PhysicalDevice physicalDevice, ref _DeviceCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Device pDevice);
		public static Result CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo pCreateInfo, out Device pDevice, AllocationCallbacks pAllocator = null)
		{
			//marshal to the internal structure
			_DeviceCreateInfo info = new _DeviceCreateInfo(pCreateInfo);

			//call the native function
			Result ret = _CreateDevice(physicalDevice, ref info, pAllocator, out pDevice);

			//cleanup the marshaling memory
			info.destroy();

			//return
			return ret;
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyDevice(Device device, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _EnumerateInstanceLayerProperties(out UInt32 pPropertyCount, IntPtr pProperties);
		public unsafe static Result EnumerateInstanceLayerProperties(out UInt32 pPropertyCount, LayerProperties[] pProperties)
		{
			if(pProperties == null)
			{
				return _EnumerateInstanceLayerProperties(out pPropertyCount, IntPtr.Zero);
			}
			else
			{
				fixed (LayerProperties* ptr = pProperties)
				{
					return _EnumerateInstanceLayerProperties(out pPropertyCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity]
		static extern Result _EnumerateInstanceExtensionProperties(string pLayerName, out UInt32 pPropertyCount, IntPtr pProperties);
		public unsafe static Result EnumerateInstanceExtensionProperties(string pLayerName, out UInt32 pPropertyCount, ExtensionProperties[] pProperties)
		{
			if (pProperties == null)
			{
				return _EnumerateInstanceExtensionProperties(pLayerName, out pPropertyCount, IntPtr.Zero);
			}
			else
			{
				fixed (ExtensionProperties* ptr = pProperties)
				{
					return _EnumerateInstanceExtensionProperties(pLayerName, out pPropertyCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, IntPtr pProperties);
		public unsafe static Result EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, LayerProperties[] pProperties)
		{
			if (pProperties == null)
			{
				return _EnumerateDeviceLayerProperties(physicalDevice, out pPropertyCount, IntPtr.Zero);
			}
			else
			{
				fixed (LayerProperties* ptr = pProperties)
				{
					return _EnumerateDeviceLayerProperties(physicalDevice, out pPropertyCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity]
		static extern Result _EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, string pLayerName, out UInt32 pPropertyCount, IntPtr pProperties);
		public unsafe static Result EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, string pLayerName, out UInt32 pPropertyCount, ExtensionProperties[] pProperties)
		{
			if(pProperties == null)
			{
				return _EnumerateDeviceExtensionProperties(physicalDevice, pLayerName, out pPropertyCount, IntPtr.Zero);
			}
			else
			{
				fixed (ExtensionProperties* ptr = pProperties)
				{
					return _EnumerateDeviceExtensionProperties(physicalDevice, pLayerName, out pPropertyCount, (IntPtr)ptr);
				}
			}
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, out Queue pQueue);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueueSubmit(Queue queue, UInt32 submitCount, ref SubmitInfo pSubmits, Fence fence);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueueWaitIdle", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueueWaitIdle(Queue queue);

		[DllImport(VulkanLibrary, EntryPoint = "vkDeviceWaitIdle", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result DeviceWaitIdle(Device device);

		[DllImport(VulkanLibrary, EntryPoint = "vkAllocateMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _AllocateMemory(Device device, ref MemoryAllocateInfo pAllocateInfo, AllocationCallbacks pAllocator, out UInt64 pMemory);
		public static Result AllocateMemory(Device device, ref MemoryAllocateInfo pAllocateInfo, out UInt64 pMemory, AllocationCallbacks pAllocator = null)
		{
			return _AllocateMemory(device, ref pAllocateInfo, pAllocator, out pMemory);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void FreeMemory(Device device, UInt64 memory, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result MapMemory(Device device, UInt64 memory, DeviceSize offset, DeviceSize size, UInt32 flags, out IntPtr ppData);

		[DllImport(VulkanLibrary, EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void UnmapMemory(Device device, UInt64 memory);

		[DllImport(VulkanLibrary, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRange pMemoryRanges);

		[DllImport(VulkanLibrary, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRange pMemoryRanges);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetDeviceMemoryCommitment(Device device, UInt64 memory, out DeviceSize pCommittedMemoryInBytes);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetBufferMemoryRequirements(Device device, UInt64 buffer, out MemoryRequirements pMemoryRequirements);

		[DllImport(VulkanLibrary, EntryPoint = "vkBindBufferMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result BindBufferMemory(Device device, UInt64 buffer, UInt64 memory, DeviceSize memoryOffset);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetImageMemoryRequirements(Device device, UInt64 image, out MemoryRequirements pMemoryRequirements);

		[DllImport(VulkanLibrary, EntryPoint = "vkBindImageMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result BindImageMemory(Device device, UInt64 image, UInt64 memory, DeviceSize memoryOffset);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetImageSparseMemoryRequirements(Device device, UInt64 image, out UInt32 pSparseMemoryRequirementCount, out SparseImageMemoryRequirements[] pSparseMemoryRequirements);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, out UInt32 pPropertyCount, out SparseImageFormatProperties[] pProperties);

		[DllImport(VulkanLibrary, EntryPoint = "vkQueueBindSparse", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result QueueBindSparse(IntPtr queue, UInt32 bindInfoCount, ref BindSparseInfo[] pBindInfo, UInt64 fence);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateFence(Device device, ref FenceCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Fence pFence);
		public static Result CreateFence(Device device, ref FenceCreateInfo pCreateInfo, out Fence pFence, AllocationCallbacks pAllocator = null)
		{
			return _CreateFence(device, ref pCreateInfo, pAllocator, out pFence);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyFence(Device device, Fence fence, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ResetFences(Device device, UInt32 fenceCount, Fence[] pFences);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetFenceStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetFenceStatus(Device device, UInt64 fence);

		[DllImport(VulkanLibrary, EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result WaitForFences(Device device, UInt32 fenceCount, Fence[] pFences, Bool32 waitAll, UInt64 timeout);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateSemaphore(Device device, ref SemaphoreCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Semaphore pSemaphore);
		public static Result CreateSemaphore(Device device, ref SemaphoreCreateInfo pCreateInfo, out Semaphore pSemaphore, AllocationCallbacks pAllocator = null)
		{
			return _CreateSemaphore(device, ref pCreateInfo, pAllocator, out pSemaphore);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySemaphore(Device device, UInt64 semaphore, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateEvent(Device device, ref EventCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Event pEvent);
		public static Result CreateEvent(Device device, ref EventCreateInfo pCreateInfo, out Event pEvent, AllocationCallbacks pAllocator = null)
		{
			return _CreateEvent(device, ref pCreateInfo, pAllocator, out pEvent);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyEvent(Device device, Event _event, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetEventStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetEventStatus(Device device, Event _event);

		[DllImport(VulkanLibrary, EntryPoint = "vkSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result SetEvent(Device device, Event _event);

		[DllImport(VulkanLibrary, EntryPoint = "vkResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ResetEvent(Device device, Event _event);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateQueryPool(Device device, ref QueryPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out QueryPool pQueryPool);
		public static Result CreateQueryPool(Device device, ref QueryPoolCreateInfo pCreateInfo, out QueryPool pQueryPool, AllocationCallbacks pAllocator = null)
		{
			return _CreateQueryPool(device, ref pCreateInfo, pAllocator, out pQueryPool);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetQueryPoolResults", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UInt32 dataSize, IntPtr pData, DeviceSize stride, QueryResultFlags flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateBuffer(Device device, ref BufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Buffer pBuffer);
		public static Result CreateBuffer(Device device, ref BufferCreateInfo pCreateInfo, out Buffer pBuffer, AllocationCallbacks pAllocator = null)
		{
			return _CreateBuffer(device, ref pCreateInfo, pAllocator, out pBuffer);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateBufferView(Device device, ref BufferViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out BufferView pView);
		public static Result CreateBufferView(Device device, ref BufferViewCreateInfo pCreateInfo, out BufferView pView, AllocationCallbacks pAllocator = null)
		{
			return _CreateBufferView(device, ref pCreateInfo, pAllocator, out pView);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateImage(Device device, ref ImageCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Image pImage);
		public static Result CreateImage(Device device, ref ImageCreateInfo pCreateInfo, out Image pImage, AllocationCallbacks pAllocator = null)
		{
			return _CreateImage(device, ref pCreateInfo, pAllocator, out pImage);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyImage(Device device, Image image, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetImageSubresourceLayout(Device device, Image image, ref ImageSubresource pSubresource, out SubresourceLayout pLayout);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		static extern Result _CreateImageView(Device device, ref ImageViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out ImageView pView);
		public static Result CreateImageView(Device device, ref ImageViewCreateInfo pCreateInfo, out ImageView pView, AllocationCallbacks pAllocator = null)
		{
			return _CreateImageView(device, ref pCreateInfo, pAllocator, out pView);
		}

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateShaderModule(Device device, ref ShaderModuleCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out ShaderModule pShaderModule);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreatePipelineCache(Device device, ref PipelineCacheCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out PipelineCache pPipelineCache);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetPipelineCacheData", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result GetPipelineCacheData(Device device, PipelineCache pipelineCache, out UIntPtr pDataSize, out IntPtr pData);

		[DllImport(VulkanLibrary, EntryPoint = "vkMergePipelineCaches", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, out PipelineCache[] pSrcCaches);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ref GraphicsPipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator, out Pipeline[] pPipelines);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateComputePipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ref ComputePipelineCreateInfo pCreateInfos, AllocationCallbacks pAllocator, out Pipeline[] pPipelines);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreatePipelineLayout(Device device, ref PipelineLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out PipelineLayout pPipelineLayout);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateSampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateSampler(Device device, ref SamplerCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Sampler pSampler);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroySampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroySampler(Device device, Sampler sampler, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDescriptorSetLayout(Device device, ref DescriptorSetLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out DescriptorSetLayout pSetLayout);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateDescriptorPool(Device device, ref DescriptorPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out DescriptorPool pDescriptorPool);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkResetDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ResetDescriptorPool(Device device, DescriptorPool descriptorPool, UInt32 flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AllocateDescriptorSets(Device device, ref DescriptorSetAllocateInfo pAllocateInfo, out DescriptorSet[] pDescriptorSets);

		[DllImport(VulkanLibrary, EntryPoint = "vkFreeDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet[] pDescriptorSets);

		[DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, ref WriteDescriptorSet pDescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet[] pDescriptorCopies);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateFramebuffer(Device device, ref FramebufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Framebuffer pFramebuffer);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateRenderPass(Device device, ref RenderPassCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out RenderPass pRenderPass);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void GetRenderAreaGranularity(Device device, RenderPass renderPass, out Extent2D pGranularity);

		[DllImport(VulkanLibrary, EntryPoint = "vkCreateCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result CreateCommandPool(Device device, ref CommandPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, CommandPool pCommandPool);

		[DllImport(VulkanLibrary, EntryPoint = "vkDestroyCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks pAllocator = null);

		[DllImport(VulkanLibrary, EntryPoint = "vkResetCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result AllocateCommandBuffers(Device device, ref CommandBufferAllocateInfo pAllocateInfo, out CommandBuffer[] pCommandBuffers);

		[DllImport(VulkanLibrary, EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer[] pCommandBuffers);

		[DllImport(VulkanLibrary, EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result BeginCommandBuffer(CommandBuffer commandBuffer, ref CommandBufferBeginInfo pBeginInfo);

		[DllImport(VulkanLibrary, EntryPoint = "vkEndCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result EndCommandBuffer(CommandBuffer commandBuffer);

		[DllImport(VulkanLibrary, EntryPoint = "vkResetCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern Result ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBindPipeline", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetViewport", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ref Viewport pViewports);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, ref Rect2D pScissors);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetLineWidth", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetLineWidth(CommandBuffer commandBuffer, float lineWidth);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDepthBias", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetDepthBias(CommandBuffer commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetBlendConstants", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetBlendConstants(CommandBuffer commandBuffer, float blendConstants);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDepthBounds", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetDepthBounds(CommandBuffer commandBuffer, float minDepthBounds, float maxDepthBounds);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilReference", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, ref DescriptorSet[] pDescriptorSets, UInt32 dynamicOffsetCount, ref UInt32[] pDynamicOffsets);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, ref Buffer[] pBuffers, ref DeviceSize pOffsets);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDraw", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndexed", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatch", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDispatch(CommandBuffer commandBuffer, UInt32 groupCountX, UInt32 groupCountY, UInt32 groupCountZ);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatchIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, ref BufferCopy[] pRegions);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageCopy[] pRegions);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBlitImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageBlit[] pRegions, Filter filter);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref BufferImageCopy[] pRegions);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, ref BufferImageCopy[] pRegions);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, IntPtr pData);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdFillBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdClearColorImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearColorValue pColor, UInt32 rangeCount, ref ImageSubresourceRange[] pRanges);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearDepthStencilValue pDepthStencil, UInt32 rangeCount, ref ImageSubresourceRange[] pRanges);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdClearAttachments", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ref ClearAttachment pAttachments, UInt32 rectCount, ref ClearRect[] pRects);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdResolveImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageResolve[] pRegions);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdSetEvent(CommandBuffer commandBuffer, Event _event, PipelineStageFlags stageMask);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdResetEvent(CommandBuffer commandBuffer, Event _event, PipelineStageFlags stageMask);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdWaitEvents", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, ref Event[] pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, ref MemoryBarrier[] pMemoryBarriers, UInt32 bufferMemoryBarrierCount, ref BufferMemoryBarrier[] pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ref ImageMemoryBarrier[] pImageMemoryBarriers);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, ref MemoryBarrier[] pMemoryBarriers, UInt32 bufferMemoryBarrierCount, ref BufferMemoryBarrier[] pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ref ImageMemoryBarrier[] pImageMemoryBarriers);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBeginQuery", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdEndQuery", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdResetQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdWriteTimestamp", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdPushConstants", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr pValues);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdBeginRenderPass(CommandBuffer commandBuffer, ref RenderPassBeginInfo pRenderPassBegin, SubpassContents contents);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdNextSubpass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdEndRenderPass(IntPtr commandBuffer);

		[DllImport(VulkanLibrary, EntryPoint = "vkCmdExecuteCommands", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
		public static extern void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, ref CommandBuffer[] pCommandBuffers);

	}
}