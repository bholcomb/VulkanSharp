using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class VK
   {

      #region Device initialization
      //VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateInstance(ref InstanceCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref InstancepInstance);


      //void vkDestroyInstance(VkInstance instance, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyInstance(Instance instance, ref AllocationCallbackspAllocator);


      //VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint32_t* pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumeratePhysicalDevices(Instance instance, ref UInt32pPhysicalDeviceCount, ref PhysicalDevicepPhysicalDevices);


      //void vkGetPhysicalDeviceFeatures(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures* pFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, ref PhysicalDeviceFeaturespFeatures);


      //void vkGetPhysicalDeviceFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, ref FormatPropertiespFormatProperties);


      //VkResult vkGetPhysicalDeviceImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkImageFormatProperties* pImageFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ref ImageFormatPropertiespImageFormatProperties);


      //void vkGetPhysicalDeviceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, ref PhysicalDevicePropertiespProperties);


      //void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, ref UInt32pQueueFamilyPropertyCount, ref QueueFamilyPropertiespQueueFamilyProperties);


      //void vkGetPhysicalDeviceMemoryProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceMemoryPropertiespMemoryProperties);


      //PFN_vkVoidFunction vkGetInstanceProcAddr(VkInstance instance, char* pName);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern VoidFunction GetInstanceProcAddr(Instance instance, ref charpName);


      //PFN_vkVoidFunction vkGetDeviceProcAddr(VkDevice device, char* pName);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern VoidFunction GetDeviceProcAddr(Device device, ref charpName);

      #endregion

      #region Device commands
      //VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDevice(PhysicalDevice physicalDevice, ref DeviceCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref DevicepDevice);


      //void vkDestroyDevice(VkDevice device, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDevice(Device device, ref AllocationCallbackspAllocator);

      #endregion

      #region Extension discovery commands
      //VkResult vkEnumerateInstanceExtensionProperties(char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateInstanceExtensionProperties(ref charpLayerName, ref UInt32pPropertyCount, ref ExtensionPropertiespProperties);


      //VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, ref charpLayerName, ref UInt32pPropertyCount, ref ExtensionPropertiespProperties);

      #endregion

      #region Layer discovery commands
      //VkResult vkEnumerateInstanceLayerProperties(uint32_t* pPropertyCount, VkLayerProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateInstanceLayerProperties(ref UInt32pPropertyCount, ref LayerPropertiespProperties);


      //VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkLayerProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, ref UInt32pPropertyCount, ref LayerPropertiespProperties);

      #endregion

      #region queue commands
      //void vkGetDeviceQueue(VkDevice device, uint32_t queueFamilyIndex, uint32_t queueIndex, VkQueue* pQueue);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, ref QueuepQueue);


      //VkResult vkQueueSubmit(VkQueue queue, uint32_t submitCount, VkSubmitInfo* pSubmits, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result QueueSubmit(Queue queue, UInt32 submitCount, ref SubmitInfopSubmits, Fence fence);


      //VkResult vkQueueWaitIdle(VkQueue queue);
      [DllImport(VulkanLibrary, EntryPoint = "vkQueueWaitIdle", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result QueueWaitIdle(Queue queue);


      //VkResult vkDeviceWaitIdle(VkDevice device);
      [DllImport(VulkanLibrary, EntryPoint = "vkDeviceWaitIdle", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result DeviceWaitIdle(Device device);

      #endregion

      #region Memory commands
      //VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, VkAllocationCallbacks* pAllocator, VkDeviceMemory* pMemory);
      [DllImport(VulkanLibrary, EntryPoint = "vkAllocateMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result AllocateMemory(Device device, ref MemoryAllocateInfopAllocateInfo, ref AllocationCallbackspAllocator, ref DeviceMemorypMemory);


      //void vkFreeMemory(VkDevice device, VkDeviceMemory memory, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void FreeMemory(Device device, DeviceMemory memory, ref AllocationCallbackspAllocator);


      //VkResult vkMapMemory(VkDevice device, VkDeviceMemory memory, VkDeviceSize offset, VkDeviceSize size, VkMemoryMapFlags flags, void ppData);
      [DllImport(VulkanLibrary, EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, void ppData);


      //void vkUnmapMemory(VkDevice device, VkDeviceMemory memory);
      [DllImport(VulkanLibrary, EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void UnmapMemory(Device device, DeviceMemory memory);


      //VkResult vkFlushMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRangepMemoryRanges);


      //VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRangepMemoryRanges);


      //void vkGetDeviceMemoryCommitment(VkDevice device, VkDeviceMemory memory, VkDeviceSize* pCommittedMemoryInBytes);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceMemoryCommitment(Device device, DeviceMemory memory, ref DeviceSizepCommittedMemoryInBytes);

      #endregion

      #region Memory management API commands
      //VkResult vkBindBufferMemory(VkDevice device, VkBuffer buffer, VkDeviceMemory memory, VkDeviceSize memoryOffset);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindBufferMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset);


      //VkResult vkBindImageMemory(VkDevice device, VkImage image, VkDeviceMemory memory, VkDeviceSize memoryOffset);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindImageMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset);


      //void vkGetBufferMemoryRequirements(VkDevice device, VkBuffer buffer, VkMemoryRequirements* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetBufferMemoryRequirements(Device device, Buffer buffer, ref MemoryRequirementspMemoryRequirements);


      //void vkGetImageMemoryRequirements(VkDevice device, VkImage image, VkMemoryRequirements* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageMemoryRequirements(Device device, Image image, ref MemoryRequirementspMemoryRequirements);

      #endregion

      #region Sparse resource memory management API commands
      //void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageSparseMemoryRequirements(Device device, Image image, ref UInt32pSparseMemoryRequirementCount, ref SparseImageMemoryRequirementspSparseMemoryRequirements);


      //void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, uint32_t* pPropertyCount, VkSparseImageFormatProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, ref UInt32pPropertyCount, ref SparseImageFormatPropertiespProperties);


      //VkResult vkQueueBindSparse(VkQueue queue, uint32_t bindInfoCount, VkBindSparseInfo* pBindInfo, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkQueueBindSparse", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result QueueBindSparse(Queue queue, UInt32 bindInfoCount, ref BindSparseInfopBindInfo, Fence fence);

      #endregion

      #region Fence commands
      //VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateFence(Device device, ref FenceCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref FencepFence);


      //void vkDestroyFence(VkDevice device, VkFence fence, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyFence(Device device, Fence fence, ref AllocationCallbackspAllocator);


      //VkResult vkResetFences(VkDevice device, uint32_t fenceCount, VkFence* pFences);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetFences(Device device, UInt32 fenceCount, ref FencepFences);


      //VkResult vkGetFenceStatus(VkDevice device, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetFenceStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetFenceStatus(Device device, Fence fence);


      //VkResult vkWaitForFences(VkDevice device, uint32_t fenceCount, VkFence* pFences, VkBool32 waitAll, uint64_t timeout);
      [DllImport(VulkanLibrary, EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result WaitForFences(Device device, UInt32 fenceCount, ref FencepFences, Bool32 waitAll, UInt64 timeout);

      #endregion

      #region Queue semaphore commands
      //VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSemaphore(Device device, ref SemaphoreCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref SemaphorepSemaphore);


      //void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySemaphore(Device device, Semaphore semaphore, ref AllocationCallbackspAllocator);

      #endregion

      #region Event commands
      //VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateEvent(Device device, ref EventCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref EventpEvent);


      //void vkDestroyEvent(VkDevice device, VkEvent event, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyEvent(Device device, Event event, ref AllocationCallbackspAllocator);


      //VkResult vkGetEventStatus(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetEventStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetEventStatus(Device device, Event event);


      //VkResult vkSetEvent(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result SetEvent(Device device, Event event);


      //VkResult vkResetEvent(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetEvent(Device device, Event event);

      #endregion

      #region Query commands
      //VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateQueryPool(Device device, ref QueryPoolCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref QueryPoolpQueryPool);


      //void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyQueryPool(Device device, QueryPool queryPool, ref AllocationCallbackspAllocator);


      //VkResult vkGetQueryPoolResults(VkDevice device, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount, size_t dataSize, void* pData, VkDeviceSize stride, VkQueryResultFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetQueryPoolResults", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UInt32 dataSize, ref voidpData, DeviceSize stride, QueryResultFlags flags);

      #endregion

      #region Buffer commands
      //VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateBuffer(Device device, ref BufferCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref BufferpBuffer);


      //void vkDestroyBuffer(VkDevice device, VkBuffer buffer, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyBuffer(Device device, Buffer buffer, ref AllocationCallbackspAllocator);

      #endregion

      #region Buffer view commands
      //VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateBufferView(Device device, ref BufferViewCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref BufferViewpView);


      //void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyBufferView(Device device, BufferView bufferView, ref AllocationCallbackspAllocator);

      #endregion

      #region Image commands
      //VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateImage(Device device, ref ImageCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref ImagepImage);


      //void vkDestroyImage(VkDevice device, VkImage image, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyImage(Device device, Image image, ref AllocationCallbackspAllocator);


      //void vkGetImageSubresourceLayout(VkDevice device, VkImage image, VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageSubresourceLayout(Device device, Image image, ref ImageSubresourcepSubresource, ref SubresourceLayoutpLayout);

      #endregion

      #region Image view commands
      //VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateImageView(Device device, ref ImageViewCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref ImageViewpView);


      //void vkDestroyImageView(VkDevice device, VkImageView imageView, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyImageView(Device device, ImageView imageView, ref AllocationCallbackspAllocator);

      #endregion

      #region Shader commands
      //VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateShaderModule(Device device, ref ShaderModuleCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref ShaderModulepShaderModule);


      //void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyShaderModule(Device device, ShaderModule shaderModule, ref AllocationCallbackspAllocator);

      #endregion

      #region Pipeline Cache commands
      //VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreatePipelineCache(Device device, ref PipelineCacheCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref PipelineCachepPipelineCache);


      //void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipelineCache(Device device, PipelineCache pipelineCache, ref AllocationCallbackspAllocator);


      //VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, size_t* pDataSize, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPipelineCacheData", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPipelineCacheData(Device device, PipelineCache pipelineCache, ref UInt32pDataSize, ref voidpData);


      //VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint32_t srcCacheCount, VkPipelineCache* pSrcCaches);
      [DllImport(VulkanLibrary, EntryPoint = "vkMergePipelineCaches", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, ref PipelineCachepSrcCaches);

      #endregion

      #region Pipeline commands
      //VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ref GraphicsPipelineCreateInfopCreateInfos, ref AllocationCallbackspAllocator, ref PipelinepPipelines);


      //VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateComputePipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ref ComputePipelineCreateInfopCreateInfos, ref AllocationCallbackspAllocator, ref PipelinepPipelines);


      //void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipeline(Device device, Pipeline pipeline, ref AllocationCallbackspAllocator);

      #endregion

      #region Pipeline layout commands
      //VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreatePipelineLayout(Device device, ref PipelineLayoutCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref PipelineLayoutpPipelineLayout);


      //void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, ref AllocationCallbackspAllocator);

      #endregion

      #region Sampler commands
      //VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSampler(Device device, ref SamplerCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref SamplerpSampler);


      //void vkDestroySampler(VkDevice device, VkSampler sampler, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySampler(Device device, Sampler sampler, ref AllocationCallbackspAllocator);

      #endregion

      #region Descriptor set commands
      //VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDescriptorSetLayout(Device device, ref DescriptorSetLayoutCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref DescriptorSetLayoutpSetLayout);


      //void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, ref AllocationCallbackspAllocator);


      //VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDescriptorPool(Device device, ref DescriptorPoolCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref DescriptorPoolpDescriptorPool);


      //void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, ref AllocationCallbackspAllocator);


      //VkResult vkResetDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkDescriptorPoolResetFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags);


      //VkResult vkAllocateDescriptorSets(VkDevice device, VkDescriptorSetAllocateInfo* pAllocateInfo, VkDescriptorSet* pDescriptorSets);
      [DllImport(VulkanLibrary, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result AllocateDescriptorSets(Device device, ref DescriptorSetAllocateInfopAllocateInfo, ref DescriptorSetpDescriptorSets);


      //VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint32_t descriptorSetCount, VkDescriptorSet* pDescriptorSets);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, ref DescriptorSetpDescriptorSets);


      //void vkUpdateDescriptorSets(VkDevice device, uint32_t descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint32_t descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies);
      [DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, ref WriteDescriptorSetpDescriptorWrites, UInt32 descriptorCopyCount, ref CopyDescriptorSetpDescriptorCopies);

      #endregion

      #region Pass commands
      //VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateFramebuffer(Device device, ref FramebufferCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref FramebufferpFramebuffer);


      //void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyFramebuffer(Device device, Framebuffer framebuffer, ref AllocationCallbackspAllocator);


      //VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateRenderPass(Device device, ref RenderPassCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref RenderPasspRenderPass);


      //void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyRenderPass(Device device, RenderPass renderPass, ref AllocationCallbackspAllocator);


      //void vkGetRenderAreaGranularity(VkDevice device, VkRenderPass renderPass, VkExtent2D* pGranularity);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetRenderAreaGranularity(Device device, RenderPass renderPass, ref Extent2DpGranularity);

      #endregion

      #region Command pool commands
      //VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateCommandPool(Device device, ref CommandPoolCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref CommandPoolpCommandPool);


      //void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyCommandPool(Device device, CommandPool commandPool, ref AllocationCallbackspAllocator);


      //VkResult vkResetCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolResetFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags);

      #endregion

      #region Command buffer commands
      //VkResult vkAllocateCommandBuffers(VkDevice device, VkCommandBufferAllocateInfo* pAllocateInfo, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result AllocateCommandBuffers(Device device, ref CommandBufferAllocateInfopAllocateInfo, ref CommandBufferpCommandBuffers);


      //void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, ref CommandBufferpCommandBuffers);


      //VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferBeginInfo* pBeginInfo);
      [DllImport(VulkanLibrary, EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BeginCommandBuffer(CommandBuffer commandBuffer, ref CommandBufferBeginInfopBeginInfo);


      //VkResult vkEndCommandBuffer(VkCommandBuffer commandBuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkEndCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EndCommandBuffer(CommandBuffer commandBuffer);


      //VkResult vkResetCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferResetFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags);

      #endregion

      #region Command buffer building commands
      //void vkCmdBindPipeline(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipeline pipeline);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindPipeline", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline);


      //void vkCmdSetViewport(VkCommandBuffer commandBuffer, uint32_t firstViewport, uint32_t viewportCount, VkViewport* pViewports);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetViewport", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ref ViewportpViewports);


      //void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint32_t firstScissor, uint32_t scissorCount, VkRect2D* pScissors);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, ref Rect2DpScissors);


      //void vkCmdSetLineWidth(VkCommandBuffer commandBuffer, float lineWidth);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetLineWidth", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetLineWidth(CommandBuffer commandBuffer, float lineWidth);


      //void vkCmdSetDepthBias(VkCommandBuffer commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDepthBias", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetDepthBias(CommandBuffer commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);


      //void vkCmdSetBlendConstants(VkCommandBuffer commandBuffer, float blendConstants);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetBlendConstants", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetBlendConstants(CommandBuffer commandBuffer, float blendConstants);


      //void vkCmdSetDepthBounds(VkCommandBuffer commandBuffer, float minDepthBounds, float maxDepthBounds);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDepthBounds", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetDepthBounds(CommandBuffer commandBuffer, float minDepthBounds, float maxDepthBounds);


      //void vkCmdSetStencilCompareMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t compareMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);


      //void vkCmdSetStencilWriteMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t writeMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);


      //void vkCmdSetStencilReference(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t reference);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetStencilReference", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference);


      //void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint32_t firstSet, uint32_t descriptorSetCount, VkDescriptorSet* pDescriptorSets, uint32_t dynamicOffsetCount, uint32_t* pDynamicOffsets);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, ref DescriptorSetpDescriptorSets, UInt32 dynamicOffsetCount, ref UInt32pDynamicOffsets);


      //void vkCmdBindIndexBuffer(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkIndexType indexType);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType);


      //void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint32_t firstBinding, uint32_t bindingCount, VkBuffer* pBuffers, VkDeviceSize* pOffsets);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, ref BufferpBuffers, ref DeviceSizepOffsets);


      //void vkCmdDraw(VkCommandBuffer commandBuffer, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDraw", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);


      //void vkCmdDrawIndexed(VkCommandBuffer commandBuffer, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t vertexOffset, uint32_t firstInstance);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndexed", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);


      //void vkCmdDrawIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, uint32_t drawCount, uint32_t stride);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);


      //void vkCmdDrawIndexedIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, uint32_t drawCount, uint32_t stride);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);


      //void vkCmdDispatch(VkCommandBuffer commandBuffer, uint32_t groupCountX, uint32_t groupCountY, uint32_t groupCountZ);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatch", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDispatch(CommandBuffer commandBuffer, UInt32 groupCountX, UInt32 groupCountY, UInt32 groupCountZ);


      //void vkCmdDispatchIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatchIndirect", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset);


      //void vkCmdCopyBuffer(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkBuffer dstBuffer, uint32_t regionCount, VkBufferCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, ref BufferCopypRegions);


      //void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageCopypRegions);


      //void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageBlit* pRegions, VkFilter filter);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBlitImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageBlitpRegions, Filter filter);


      //void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkBufferImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref BufferImageCopypRegions);


      //void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint32_t regionCount, VkBufferImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, ref BufferImageCopypRegions);


      //void vkCmdUpdateBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize dataSize, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, ref voidpData);


      //void vkCmdFillBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize size, uint32_t data);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdFillBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);


      //void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint32_t rangeCount, VkImageSubresourceRange* pRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearColorImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearColorValuepColor, UInt32 rangeCount, ref ImageSubresourceRangepRanges);


      //void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint32_t rangeCount, VkImageSubresourceRange* pRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearDepthStencilValuepDepthStencil, UInt32 rangeCount, ref ImageSubresourceRangepRanges);


      //void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint32_t attachmentCount, VkClearAttachment* pAttachments, uint32_t rectCount, VkClearRect* pRects);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearAttachments", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ref ClearAttachmentpAttachments, UInt32 rectCount, ref ClearRectpRects);


      //void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageResolve* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdResolveImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ref ImageResolvepRegions);


      //void vkCmdSetEvent(VkCommandBuffer commandBuffer, VkEvent event, VkPipelineStageFlags stageMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetEvent(CommandBuffer commandBuffer, Event event, PipelineStageFlags stageMask);


      //void vkCmdResetEvent(VkCommandBuffer commandBuffer, VkEvent event, VkPipelineStageFlags stageMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdResetEvent(CommandBuffer commandBuffer, Event event, PipelineStageFlags stageMask);


      //void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint32_t eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdWaitEvents", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, ref EventpEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, ref MemoryBarrierpMemoryBarriers, UInt32 bufferMemoryBarrierCount, ref BufferMemoryBarrierpBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ref ImageMemoryBarrierpImageMemoryBarriers);


      //void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, ref MemoryBarrierpMemoryBarriers, UInt32 bufferMemoryBarrierCount, ref BufferMemoryBarrierpBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ref ImageMemoryBarrierpImageMemoryBarriers);


      //void vkCmdBeginQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query, VkQueryControlFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBeginQuery", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags);


      //void vkCmdEndQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdEndQuery", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query);


      //void vkCmdResetQueryPool(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdResetQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount);


      //void vkCmdWriteTimestamp(VkCommandBuffer commandBuffer, VkPipelineStageFlags pipelineStage, VkQueryPool queryPool, uint32_t query);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdWriteTimestamp", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query);


      //void vkCmdCopyQueryPoolResults(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize stride, VkQueryResultFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);


      //void vkCmdPushConstants(VkCommandBuffer commandBuffer, VkPipelineLayout layout, VkShaderStageFlags stageFlags, uint32_t offset, uint32_t size, void* pValues);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdPushConstants", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, ref voidpValues);


      //void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBeginRenderPass(CommandBuffer commandBuffer, ref RenderPassBeginInfopRenderPassBegin, SubpassContents contents);


      //void vkCmdNextSubpass(VkCommandBuffer commandBuffer, VkSubpassContents contents);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdNextSubpass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents);


      //void vkCmdEndRenderPass(VkCommandBuffer commandBuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdEndRenderPass(CommandBuffer commandBuffer);


      //void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdExecuteCommands", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, ref CommandBufferpCommandBuffers);

      #endregion

      #region Device Initialization
      //VkResult vkEnumerateInstanceVersion(uint32_t* pApiVersion);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceVersion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateInstanceVersion(ref UInt32pApiVersion);

      #endregion

      #region Promoted from VK_KHR_bind_memory2
      //VkResult vkBindBufferMemory2(VkDevice device, uint32_t bindInfoCount, VkBindBufferMemoryInfo* pBindInfos);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindBufferMemory2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindBufferMemory2(Device device, UInt32 bindInfoCount, ref BindBufferMemoryInfopBindInfos);


      //VkResult vkBindImageMemory2(VkDevice device, uint32_t bindInfoCount, VkBindImageMemoryInfo* pBindInfos);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindImageMemory2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindImageMemory2(Device device, UInt32 bindInfoCount, ref BindImageMemoryInfopBindInfos);

      #endregion

      #region Promoted from VK_KHR_device_group
      //void vkGetDeviceGroupPeerMemoryFeatures(VkDevice device, uint32_t heapIndex, uint32_t localDeviceIndex, uint32_t remoteDeviceIndex, VkPeerMemoryFeatureFlags* pPeerMemoryFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceGroupPeerMemoryFeatures", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceGroupPeerMemoryFeatures(Device device, UInt32 heapIndex, UInt32 localDeviceIndex, UInt32 remoteDeviceIndex, ref PeerMemoryFeatureFlagspPeerMemoryFeatures);


      //void vkCmdSetDeviceMask(VkCommandBuffer commandBuffer, uint32_t deviceMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetDeviceMask", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetDeviceMask(CommandBuffer commandBuffer, UInt32 deviceMask);


      //void vkCmdDispatchBase(VkCommandBuffer commandBuffer, uint32_t baseGroupX, uint32_t baseGroupY, uint32_t baseGroupZ, uint32_t groupCountX, uint32_t groupCountY, uint32_t groupCountZ);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdDispatchBase", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdDispatchBase(CommandBuffer commandBuffer, UInt32 baseGroupX, UInt32 baseGroupY, UInt32 baseGroupZ, UInt32 groupCountX, UInt32 groupCountY, UInt32 groupCountZ);

      #endregion

      #region Promoted from VK_KHR_device_group_creation
      //VkResult vkEnumeratePhysicalDeviceGroups(VkInstance instance, uint32_t* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumeratePhysicalDeviceGroups", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumeratePhysicalDeviceGroups(Instance instance, ref UInt32pPhysicalDeviceGroupCount, ref PhysicalDeviceGroupPropertiespPhysicalDeviceGroupProperties);

      #endregion

      #region Promoted from VK_KHR_get_memory_requirements2
      //void vkGetImageMemoryRequirements2(VkDevice device, VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageMemoryRequirements2(Device device, ref ImageMemoryRequirementsInfo2pInfo, ref MemoryRequirements2pMemoryRequirements);


      //void vkGetBufferMemoryRequirements2(VkDevice device, VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetBufferMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetBufferMemoryRequirements2(Device device, ref BufferMemoryRequirementsInfo2pInfo, ref MemoryRequirements2pMemoryRequirements);


      //void vkGetImageSparseMemoryRequirements2(VkDevice device, VkImageSparseMemoryRequirementsInfo2* pInfo, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSparseMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageSparseMemoryRequirements2(Device device, ref ImageSparseMemoryRequirementsInfo2pInfo, ref UInt32pSparseMemoryRequirementCount, ref SparseImageMemoryRequirements2pSparseMemoryRequirements);

      #endregion

      #region Promoted from VK_KHR_get_physical_device_properties2
      //void vkGetPhysicalDeviceFeatures2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFeatures2(PhysicalDevice physicalDevice, ref PhysicalDeviceFeatures2pFeatures);


      //void vkGetPhysicalDeviceProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties2* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceProperties2pProperties);


      //void vkGetPhysicalDeviceFormatProperties2(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFormatProperties2(PhysicalDevice physicalDevice, Format format, ref FormatProperties2pFormatProperties);


      //VkResult vkGetPhysicalDeviceImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPhysicalDeviceImageFormatProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceImageFormatInfo2pImageFormatInfo, ref ImageFormatProperties2pImageFormatProperties);


      //void vkGetPhysicalDeviceQueueFamilyProperties2(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceQueueFamilyProperties2(PhysicalDevice physicalDevice, ref UInt32pQueueFamilyPropertyCount, ref QueueFamilyProperties2pQueueFamilyProperties);


      //void vkGetPhysicalDeviceMemoryProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceMemoryProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceMemoryProperties2pMemoryProperties);


      //void vkGetPhysicalDeviceSparseImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, uint32_t* pPropertyCount, VkSparseImageFormatProperties2* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceSparseImageFormatProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceSparseImageFormatInfo2pFormatInfo, ref UInt32pPropertyCount, ref SparseImageFormatProperties2pProperties);

      #endregion

      #region Promoted from VK_KHR_maintenance1
      //void vkTrimCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolTrimFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkTrimCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void TrimCommandPool(Device device, CommandPool commandPool, CommandPoolTrimFlags flags);

      #endregion

      #region Originally based on VK_KHR_protected_memory (extension 146), which was never published; thus the mystifying large value= numbers below. These are not aliased since they weren't actually promoted from an extension.
      //void vkGetDeviceQueue2(VkDevice device, VkDeviceQueueInfo2* pQueueInfo, VkQueue* pQueue);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceQueue2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceQueue2(Device device, ref DeviceQueueInfo2pQueueInfo, ref QueuepQueue);

      #endregion

      #region Promoted from VK_KHR_sampler_ycbcr_conversion
      //VkResult vkCreateSamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversionCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversion* pYcbcrConversion);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSamplerYcbcrConversion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSamplerYcbcrConversion(Device device, ref SamplerYcbcrConversionCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref SamplerYcbcrConversionpYcbcrConversion);


      //void vkDestroySamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversion ycbcrConversion, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySamplerYcbcrConversion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySamplerYcbcrConversion(Device device, SamplerYcbcrConversion ycbcrConversion, ref AllocationCallbackspAllocator);

      #endregion

      #region Promoted from VK_KHR_descriptor_update_template
      //VkResult vkCreateDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplate* pDescriptorUpdateTemplate);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorUpdateTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDescriptorUpdateTemplate(Device device, ref DescriptorUpdateTemplateCreateInfopCreateInfo, ref AllocationCallbackspAllocator, ref DescriptorUpdateTemplatepDescriptorUpdateTemplate);


      //void vkDestroyDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplate descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorUpdateTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorUpdateTemplate(Device device, DescriptorUpdateTemplate descriptorUpdateTemplate, ref AllocationCallbackspAllocator);


      //void vkUpdateDescriptorSetWithTemplate(VkDevice device, VkDescriptorSet descriptorSet, VkDescriptorUpdateTemplate descriptorUpdateTemplate, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSetWithTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void UpdateDescriptorSetWithTemplate(Device device, DescriptorSet descriptorSet, DescriptorUpdateTemplate descriptorUpdateTemplate, ref voidpData);

      #endregion

      #region Promoted from VK_KHR_external_memory_capabilities
      //void vkGetPhysicalDeviceExternalBufferProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalBufferProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalBufferProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalBufferInfopExternalBufferInfo, ref ExternalBufferPropertiespExternalBufferProperties);

      #endregion

      #region Promoted from VK_KHR_external_fence_capabilities
      //void vkGetPhysicalDeviceExternalFenceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalFenceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalFenceProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalFenceInfopExternalFenceInfo, ref ExternalFencePropertiespExternalFenceProperties);

      #endregion

      #region Promoted from VK_KHR_external_semaphore_capabilities
      //void vkGetPhysicalDeviceExternalSemaphoreProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalSemaphoreProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalSemaphoreProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalSemaphoreInfopExternalSemaphoreInfo, ref ExternalSemaphorePropertiespExternalSemaphoreProperties);

      #endregion

      #region Promoted from VK_KHR_maintenance3
      //void vkGetDescriptorSetLayoutSupport(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDescriptorSetLayoutSupport", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDescriptorSetLayoutSupport(Device device, ref DescriptorSetLayoutCreateInfopCreateInfo, ref DescriptorSetLayoutSupportpSupport);

      #endregion
   }
}
