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

      //void vkDestroyInstance(VkInstance instance, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyInstance(Instance instance, AllocationCallbacks pAllocator);


      //VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint32_t* pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _EnumeratePhysicalDevices(Instance instance, out UInt32 pPhysicalDeviceCount, IntPtr pPhysicalDevices);
      public unsafe static Result EnumeratePhysicalDevices(Instance instance, out UInt32 pPhysicalDeviceCount, PhysicalDevice[] pPhysicalDevices)
      {
         fixed (PhysicalDevice* ptr = pPhysicalDevices)
         {
            return _EnumeratePhysicalDevices(instance, out pPhysicalDeviceCount, (IntPtr)ptr);
         }
      }

      //void vkGetPhysicalDeviceFeatures(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures* pFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, out PhysicalDeviceFeatures pFeatures);


      //void vkGetPhysicalDeviceFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, out FormatProperties pFormatProperties);


      //VkResult vkGetPhysicalDeviceImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkImageFormatProperties* pImageFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, out ImageFormatProperties pImageFormatProperties);


      //void vkGetPhysicalDeviceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, out PhysicalDeviceProperties pProperties);


      //void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, out UInt32 pQueueFamilyPropertyCount, IntPtr pQueueFamilyProperties);
      public unsafe static void GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, out UInt32 pQueueFamilyPropertyCount, QueueFamilyProperties[] pQueueFamilyProperties)
      {
         fixed (QueueFamilyProperties* ptr = pQueueFamilyProperties)
         {
            _GetPhysicalDeviceQueueFamilyProperties(physicalDevice, out pQueueFamilyPropertyCount, (IntPtr)ptr);
         }
      }

      //void vkGetPhysicalDeviceMemoryProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, out PhysicalDeviceMemoryProperties pMemoryProperties);


      //PFN_vkVoidFunction vkGetInstanceProcAddr(VkInstance instance, char* pName);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern IntPtr GetInstanceProcAddr(Instance instance, string pName);


      //PFN_vkVoidFunction vkGetDeviceProcAddr(VkDevice device, char* pName);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern IntPtr GetDeviceProcAddr(Device device, string pName);

      #endregion

      #region Device commands
      //VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice);
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

      //void vkDestroyDevice(VkDevice device, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDevice(Device device, AllocationCallbacks pAllocator = null);

      #endregion

      #region Extension discovery commands
      //VkResult vkEnumerateInstanceExtensionProperties(char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _EnumerateInstanceExtensionProperties(string pLayerName, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result EnumerateInstanceExtensionProperties(string pLayerName, out UInt32 pPropertyCount, ExtensionProperties[] pProperties)
      {
         fixed (ExtensionProperties* ptr = pProperties)
         {
            return _EnumerateInstanceExtensionProperties(pLayerName, out pPropertyCount, (IntPtr)ptr);
         }
      }

      //VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, string pLayerName, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, string pLayerName, out UInt32 pPropertyCount, ExtensionProperties[] pProperties)
      {
         fixed (ExtensionProperties* ptr = pProperties)
         {
            return _EnumerateDeviceExtensionProperties(physicalDevice, pLayerName, out pPropertyCount, (IntPtr)ptr);
         }
      }
      #endregion

      #region Layer discovery commands
      //VkResult vkEnumerateInstanceLayerProperties(uint32_t* pPropertyCount, VkLayerProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _EnumerateInstanceLayerProperties(out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result EnumerateInstanceLayerProperties(out UInt32 pPropertyCount, LayerProperties[] pProperties)
      {
         fixed (LayerProperties* ptr = pProperties)
         {
            return _EnumerateInstanceLayerProperties(out pPropertyCount, (IntPtr)ptr);
         }
      }


      //VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkLayerProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, LayerProperties[] pProperties)
      {
         fixed (LayerProperties* ptr = pProperties)
         {
            return _EnumerateDeviceLayerProperties(physicalDevice, out pPropertyCount, (IntPtr)ptr);
         }
      }
      #endregion

      #region queue commands
      //void vkGetDeviceQueue(VkDevice device, uint32_t queueFamilyIndex, uint32_t queueIndex, VkQueue* pQueue);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, out Queue pQueue);


      //VkResult vkQueueSubmit(VkQueue queue, uint32_t submitCount, VkSubmitInfo* pSubmits, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _QueueSubmit(Queue queue, UInt32 submitCount, IntPtr pSubmits, Fence fence);
      public unsafe static Result QueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo[] pSubmits, Fence fence)
      {
         _SubmitInfo[] s = new _SubmitInfo[pSubmits.Length];
         for(int i = 0; i < pSubmits.Length; i++)
         {
            s[i] = new _SubmitInfo(pSubmits[i]);
         }

         Result res;
         fixed (_SubmitInfo* ptr = s)
         {
            res = _QueueSubmit(queue, submitCount, (IntPtr)ptr, fence);
         }

         for(int i = 0; i < pSubmits.Length; i++)
         {
            s[i].destroy();
         }

         return res;
      }

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
      static extern Result _AllocateMemory(Device device, ref MemoryAllocateInfo pAllocateInfo, AllocationCallbacks pAllocator, out DeviceMemory pMemory);
      public static Result AllocateMemory(Device device, ref MemoryAllocateInfo pAllocateInfo, out DeviceMemory pMemory, AllocationCallbacks pAllocator = null)
      {
         return _AllocateMemory(device, ref pAllocateInfo, pAllocator, out pMemory);
      }


      //void vkFreeMemory(VkDevice device, VkDeviceMemory memory, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void FreeMemory(Device device, DeviceMemory memory, AllocationCallbacks pAllocator = null);


      //VkResult vkMapMemory(VkDevice device, VkDeviceMemory memory, VkDeviceSize offset, VkDeviceSize size, VkMemoryMapFlags flags, void** ppData);
      [DllImport(VulkanLibrary, EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, ref IntPtr ppData);


      //void vkUnmapMemory(VkDevice device, VkDeviceMemory memory);
      [DllImport(VulkanLibrary, EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void UnmapMemory(Device device, DeviceMemory memory);


      //VkResult vkFlushMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRange pMemoryRanges);


      //VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, ref MappedMemoryRange pMemoryRanges);


      //void vkGetDeviceMemoryCommitment(VkDevice device, VkDeviceMemory memory, VkDeviceSize* pCommittedMemoryInBytes);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceMemoryCommitment(Device device, DeviceMemory memory, ref DeviceSize pCommittedMemoryInBytes);

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
      public static extern void GetBufferMemoryRequirements(Device device, Buffer buffer, ref MemoryRequirements pMemoryRequirements);


      //void vkGetImageMemoryRequirements(VkDevice device, VkImage image, VkMemoryRequirements* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageMemoryRequirements(Device device, Image image, ref MemoryRequirements pMemoryRequirements);

      #endregion

      #region Sparse resource memory management API commands
      //void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _GetImageSparseMemoryRequirements(Device device, Image image, out UInt32 pSparseMemoryRequirementCount, IntPtr pSparseMemoryRequirements);
      public unsafe static void GetImageSparseMemoryRequirements(Device device, Image image, out UInt32 pSparseMemoryRequirementCount, SparseImageMemoryRequirements[] pSparseMemoryRequirements)
      {
         fixed (SparseImageMemoryRequirements* ptr = pSparseMemoryRequirements)
         {
            _GetImageSparseMemoryRequirements(device, image, out pSparseMemoryRequirementCount, (IntPtr)ptr);
         }
      }

      //void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlags samples, VkImageUsageFlags usage, VkImageTiling tiling, uint32_t* pPropertyCount, VkSparseImageFormatProperties* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static void GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, out UInt32 pPropertyCount, SparseImageFormatProperties[] pProperties)
      {
         fixed (SparseImageFormatProperties* ptr = pProperties)
         {
            _GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling, out pPropertyCount, (IntPtr)ptr);
         }
      }

      //VkResult vkQueueBindSparse(VkQueue queue, uint32_t bindInfoCount, VkBindSparseInfo* pBindInfo, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkQueueBindSparse", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _QueueBindSparse(Queue queue, UInt32 bindInfoCount, IntPtr pBindInfo, Fence fence);
      public unsafe static Result QueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo[] pBindInfo, Fence fence)
      {
         //convert to native format
         _BindSparseInfo[] _bsi = new _BindSparseInfo[pBindInfo.Length];
         for(int i = 0; i < pBindInfo.Length; i++)
         {
            _bsi[i] = new _BindSparseInfo(pBindInfo[i]);
         }

         Result res;
         fixed (_BindSparseInfo* ptr = _bsi)
         {
            res = _QueueBindSparse(queue, bindInfoCount, (IntPtr)ptr, fence);
         }

         //cleanup
         for(int i = 0; i < _bsi.Length; i++)
         {
            _bsi[i].destroy();
         }

         return res;
      }
      #endregion

      #region Fence commands
      //VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateFence(Device device, ref FenceCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Fence pFence);
      public static Result CreateFence(Device device, ref FenceCreateInfo pCreateInfo, out Fence pFence, AllocationCallbacks pAllocator = null)
      {
         return _CreateFence(device, ref pCreateInfo, pAllocator, out pFence);
      }

      //void vkDestroyFence(VkDevice device, VkFence fence, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyFence(Device device, Fence fence, AllocationCallbacks pAllocator = null);


      //VkResult vkResetFences(VkDevice device, uint32_t fenceCount, VkFence* pFences);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _ResetFences(Device device, UInt32 fenceCount, IntPtr pFences);
      public unsafe static Result ResetFences(Device device, UInt32 fenceCount, Fence[] pFences)
      {
         fixed (Fence* ptr = pFences)
         {
            return _ResetFences(device, fenceCount, (IntPtr)ptr);
         }
      }

      //VkResult vkGetFenceStatus(VkDevice device, VkFence fence);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetFenceStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetFenceStatus(Device device, Fence fence);


      //VkResult vkWaitForFences(VkDevice device, uint32_t fenceCount, VkFence* pFences, VkBool32 waitAll, uint64_t timeout);
      [DllImport(VulkanLibrary, EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _WaitForFences(Device device, UInt32 fenceCount, IntPtr pFences, Bool32 waitAll, UInt64 timeout);
      public unsafe static Result WaitForFences(Device device, UInt32 fenceCount, Fence[] pFences, Bool32 waitAll, UInt64 timeout)
      {
         fixed (Fence* ptr = pFences)
         {
            return _WaitForFences(device, fenceCount, (IntPtr)ptr, waitAll, timeout);
         }
      }
      #endregion

      #region Queue semaphore commands
      //VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateSemaphore(Device device, ref SemaphoreCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Semaphore pSemaphore);
      public static Result CreateSemaphore(Device device, ref SemaphoreCreateInfo pCreateInfo, out Semaphore pSemaphore, AllocationCallbacks pAllocator = null)
      {
         return _CreateSemaphore(device, ref pCreateInfo, pAllocator, out pSemaphore);
      }

      //void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks pAllocator = null);

      #endregion

      #region Event commands
      //VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateEvent(Device device, ref EventCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Event pEvent);
      public static Result CreateEvent(Device device, ref EventCreateInfo pCreateInfo, out Event pEvent, AllocationCallbacks pAllocator = null)
      {
         return _CreateEvent(device, ref pCreateInfo, pAllocator, out pEvent);
      }

      //void vkDestroyEvent(VkDevice device, VkEvent event, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyEvent(Device device, Event _event, AllocationCallbacks pAllocator);


      //VkResult vkGetEventStatus(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetEventStatus", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetEventStatus(Device device, Event _event);


      //VkResult vkSetEvent(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result SetEvent(Device device, Event _event);


      //VkResult vkResetEvent(VkDevice device, VkEvent event);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetEvent(Device device, Event _event);

      #endregion

      #region Query commands
      //VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateQueryPool(Device device, ref QueryPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out QueryPool pQueryPool);
      public static Result CreateQueryPool(Device device, ref QueryPoolCreateInfo pCreateInfo, out QueryPool pQueryPool, AllocationCallbacks pAllocator = null)
      {
         return _CreateQueryPool(device, ref pCreateInfo, pAllocator, out pQueryPool);
      }

      //void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyQueryPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks pAllocator = null);


      //VkResult vkGetQueryPoolResults(VkDevice device, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount, size_t dataSize, void* pData, VkDeviceSize stride, VkQueryResultFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetQueryPoolResults", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UInt32 dataSize, IntPtr pData, DeviceSize stride, QueryResultFlags flags);

      #endregion

      #region Buffer commands
      //VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateBuffer(Device device, ref BufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Buffer pBuffer);
      public static Result CreateBuffer(Device device, ref BufferCreateInfo pCreateInfo, out Buffer pBuffer, AllocationCallbacks pAllocator = null)
      {
         return _CreateBuffer(device, ref pCreateInfo, pAllocator, out pBuffer);
      }

      //void vkDestroyBuffer(VkDevice device, VkBuffer buffer, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks pAllocator = null);

      #endregion

      #region Buffer view commands
      //VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateBufferView(Device device, ref BufferViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out BufferView pView);
      public static Result CreateBufferView(Device device, ref BufferViewCreateInfo pCreateInfo, out BufferView pView, AllocationCallbacks pAllocator = null)
      {
         return _CreateBufferView(device, ref pCreateInfo, pAllocator, out pView);
      }

      //void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyBufferView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks pAllocator = null);

      #endregion

      #region Image commands
      //VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateImage(Device device, ref ImageCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Image pImage);
      public static Result CreateImage(Device device, ref ImageCreateInfo pCreateInfo, out Image pImage, AllocationCallbacks pAllocator = null)
      {
         return _CreateImage(device, ref pCreateInfo, pAllocator, out pImage);
      }

      //void vkDestroyImage(VkDevice device, VkImage image, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyImage(Device device, Image image, AllocationCallbacks pAllocator = null);


      //void vkGetImageSubresourceLayout(VkDevice device, VkImage image, VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageSubresourceLayout(Device device, Image image, ref ImageSubresource pSubresource, ref SubresourceLayout pLayout);

      #endregion

      #region Image view commands
      //VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateImageView(Device device, ref ImageViewCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out ImageView pView);
      public static Result CreateImageView(Device device, ref ImageViewCreateInfo pCreateInfo, out ImageView pView, AllocationCallbacks pAllocator = null)
      {
         return _CreateImageView(device, ref pCreateInfo, pAllocator, out pView);
      }

      //void vkDestroyImageView(VkDevice device, VkImageView imageView, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyImageView", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks pAllocator = null);

      #endregion

      #region Shader commands
      //VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateShaderModule(Device device, ref _ShaderModuleCreateInfo info, AllocationCallbacks pAllocator, out ShaderModule pShaderModule);
      public static Result CreateShaderModule(Device device, ref ShaderModuleCreateInfo pCreateInfo, out ShaderModule pShaderModule, AllocationCallbacks pAllocator = null)
      {
         //partially create the struct
         _ShaderModuleCreateInfo info = new _ShaderModuleCreateInfo(pCreateInfo);
         Result res = _CreateShaderModule(device, ref info, pAllocator, out pShaderModule);
         info.destroy();
         return res;
      }

      //void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks pAllocator = null);
      
      #endregion

      #region Pipeline Cache commands
      //VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreatePipelineCache(Device device, ref PipelineCacheCreateInfo pCreateInfo, AllocationCallbacks pAllocator, ref PipelineCache pPipelineCache);


      //void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineCache", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks pAllocator = null);


      //VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, size_t* pDataSize, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPipelineCacheData", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPipelineCacheData(Device device, PipelineCache pipelineCache, ref UInt32 pDataSize, IntPtr pData);


      //VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint32_t srcCacheCount, VkPipelineCache* pSrcCaches);
      [DllImport(VulkanLibrary, EntryPoint = "vkMergePipelineCaches", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, IntPtr pSrcCaches);
      public unsafe static Result MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache[] pSrcCaches)
      {
         fixed (PipelineCache* ptr = pSrcCaches)
         {
            return _MergePipelineCaches(device, dstCache, srcCacheCount, (IntPtr)ptr);
         }
      }
      #endregion

      #region Pipeline commands
      //VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, IntPtr pCreateInfos, AllocationCallbacks pAllocator, IntPtr pPipelines);
      public unsafe static Result CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo[] pCreateInfos, Pipeline[] pPipelines, AllocationCallbacks pAllocator = null)
      {
         _GraphicsPipelineCreateInfo[] infos = new _GraphicsPipelineCreateInfo[pCreateInfos.Length];
         for(int i = 0; i< createInfoCount; i++)
         {
            infos[i] = new _GraphicsPipelineCreateInfo(pCreateInfos[i]);
         }

         Result res;
         fixed (_GraphicsPipelineCreateInfo* p1 = infos)
         {
            fixed (Pipeline* p2 = pPipelines)
            {
               res = _CreateGraphicsPipelines(device, pipelineCache, createInfoCount, (IntPtr)p1, pAllocator, (IntPtr)p2);
            }
         }

         for(int i = 0; i < createInfoCount; i++)
         {
            infos[i].destroy();
         }

         return res;
      }

      //VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateComputePipelines", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, IntPtr pCreateInfos, AllocationCallbacks pAllocator, IntPtr pPipelines);
      public unsafe static Result CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo[] pCreateInfos, Pipeline[] pPipelines, AllocationCallbacks pAllocator = null)
      {
         _ComputePipelineCreateInfo[] infos = new _ComputePipelineCreateInfo[pCreateInfos.Length];
         for(int i = 0; i < createInfoCount; i++)
         {
            infos[i] = new _ComputePipelineCreateInfo(pCreateInfos[i]);
         }

         Result res;
         fixed (_ComputePipelineCreateInfo* p1 = infos)
         {
            fixed (Pipeline* p2 = pPipelines)
            {
               res = _CreateComputePipelines(device, pipelineCache, createInfoCount, (IntPtr)p1, pAllocator, (IntPtr)p2);
            }
         }

         for(int i = 0; i < createInfoCount; i++)
         {
            infos[i].destroy();
         }

         return res;
      }

      //void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks pAllocator = null);

      #endregion

      #region Pipeline layout commands
      //VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreatePipelineLayout(Device device, ref _PipelineLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out PipelineLayout pPipelineLayout);
      public static Result CreatePipelineLayout(Device device, ref PipelineLayoutCreateInfo pCreateInfo, out PipelineLayout pPipelineLayout, AllocationCallbacks pAllocator = null)
      {
         _PipelineLayoutCreateInfo info = new _PipelineLayoutCreateInfo(pCreateInfo);

         Result res = _CreatePipelineLayout(device, ref info, pAllocator, out pPipelineLayout);

         info.destroy();

         return res;
      }


      //void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks pAllocator = null);

      #endregion

      #region Sampler commands
      //VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSampler(Device device, ref SamplerCreateInfo pCreateInfo, AllocationCallbacks pAllocator, ref Sampler pSampler);


      //void vkDestroySampler(VkDevice device, VkSampler sampler, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySampler", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySampler(Device device, Sampler sampler, AllocationCallbacks pAllocator = null);

      #endregion

      #region Descriptor set commands
      //VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDescriptorSetLayout(Device device, ref DescriptorSetLayoutCreateInfo pCreateInfo, AllocationCallbacks pAllocator, ref DescriptorSetLayout pSetLayout);


      //void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks pAllocator = null);


      //VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateDescriptorPool(Device device, ref DescriptorPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out DescriptorPool pDescriptorPool);
      public static Result CreateDescriptorPool(Device device, ref DescriptorPoolCreateInfo pCreateInfo, out DescriptorPool pDescriptorPool, AllocationCallbacks pAllocator = null)
      {
         return _CreateDescriptorPool(device, ref pCreateInfo, pAllocator, out pDescriptorPool);
      }

      //void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks pAllocator);


      //VkResult vkResetDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkDescriptorPoolResetFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetDescriptorPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags);


      //VkResult vkAllocateDescriptorSets(VkDevice device, VkDescriptorSetAllocateInfo* pAllocateInfo, VkDescriptorSet* pDescriptorSets);
      [DllImport(VulkanLibrary, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _AllocateDescriptorSets(Device device, ref DescriptorSetAllocateInfo pAllocateInfo, IntPtr pDescriptorSets);
      public unsafe static Result AllocateDescriptorSets(Device device, ref DescriptorSetAllocateInfo pAllocateInfo, DescriptorSet[] pDescriptorSets)
      {
         fixed (DescriptorSet* ptr = pDescriptorSets)
         {
            return _AllocateDescriptorSets(device, ref pAllocateInfo, (IntPtr)ptr);
         }
      }

      //VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint32_t descriptorSetCount, VkDescriptorSet* pDescriptorSets);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, IntPtr pDescriptorSets);
      public unsafe static Result FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet[] pDescriptorSets)
      {
         fixed (DescriptorSet* ptr = pDescriptorSets)
         {
            return _FreeDescriptorSets(device, descriptorPool, descriptorSetCount, (IntPtr)ptr);
         }
      }

      //void vkUpdateDescriptorSets(VkDevice device, uint32_t descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint32_t descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies);
      [DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, ref WriteDescriptorSet pDescriptorWrites, UInt32 descriptorCopyCount, IntPtr pDescriptorCopies);
      public unsafe static void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, ref WriteDescriptorSet pDescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet[] pDescriptorCopies)
      {
         fixed (CopyDescriptorSet* ptr = pDescriptorCopies)
         {
            _UpdateDescriptorSets(device, descriptorWriteCount, ref pDescriptorWrites, descriptorCopyCount, (IntPtr)ptr);
         }
      }
      #endregion

      #region Pass commands
      //VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateFramebuffer(Device device, ref FramebufferCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out Framebuffer pFramebuffer);
      public static Result CreateFramebuffer(Device device, ref FramebufferCreateInfo pCreateInfo, out Framebuffer pFramebuffer, AllocationCallbacks pAllocator = null)
      {
         return _CreateFramebuffer(device, ref pCreateInfo, pAllocator, out pFramebuffer);
      }

      //void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyFramebuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks pAllocator = null);


      //VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateRenderPass(Device device, ref _RenderPassCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out RenderPass pRenderPass);
      public static Result CreateRenderPass(Device device, ref RenderPassCreateInfo pCreateInfo, out RenderPass pRenderPass, AllocationCallbacks pAllocator = null)
      {
         Result res;
         _RenderPassCreateInfo info = new _RenderPassCreateInfo(pCreateInfo);
         res = _CreateRenderPass(device, ref info, pAllocator, out pRenderPass);
         info.destroy();

         return res;
      }

      //void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks pAllocator = null);


      //void vkGetRenderAreaGranularity(VkDevice device, VkRenderPass renderPass, VkExtent2D* pGranularity);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetRenderAreaGranularity(Device device, RenderPass renderPass, ref Extent2D pGranularity);

      #endregion

      #region Command pool commands
      //VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateCommandPool(Device device, ref CommandPoolCreateInfo pCreateInfo, AllocationCallbacks pAllocator, out CommandPool pCommandPool);
      public static Result CreateCommandPool(Device device, ref CommandPoolCreateInfo pCreateInfo, out CommandPool pCommandPool, AllocationCallbacks pAllocator = null)
      {
         return _CreateCommandPool(device, ref pCreateInfo, pAllocator, out pCommandPool);
      }

      //void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks pAllocator = null);


      //VkResult vkResetCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolResetFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkResetCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags);

      #endregion

      #region Command buffer commands
      //VkResult vkAllocateCommandBuffers(VkDevice device, VkCommandBufferAllocateInfo* pAllocateInfo, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _AllocateCommandBuffers(Device device, ref CommandBufferAllocateInfo pAllocateInfo, IntPtr pCommandBuffers);
      public unsafe static Result AllocateCommandBuffers(Device device, ref CommandBufferAllocateInfo pAllocateInfo, CommandBuffer[] pCommandBuffers)
      {
         fixed (CommandBuffer* ptr = pCommandBuffers)
         {
            return _AllocateCommandBuffers(device, ref pAllocateInfo, (IntPtr)ptr);
         }
      }

      //void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, IntPtr pCommandBuffers);
      public unsafe static void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer[] pCommandBuffers)
      {
         fixed (CommandBuffer* ptr = pCommandBuffers)
         {
            _FreeCommandBuffers(device, commandPool, commandBufferCount, (IntPtr)ptr);
         }
      }

      //VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferBeginInfo* pBeginInfo);
      [DllImport(VulkanLibrary, EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _BeginCommandBuffer(CommandBuffer commandBuffer, ref _CommandBufferBeginInfo pBeginInfo);
      public static Result BeginCommandBuffer(CommandBuffer commandBuffer, ref CommandBufferBeginInfo pBeginInfo)
      {
         Result res;
         _CommandBufferBeginInfo info = new _CommandBufferBeginInfo(pBeginInfo);
         res = _BeginCommandBuffer(commandBuffer, ref info);
         info.destroy();

         return res;
      }


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
      public static extern void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, ref Viewport pViewports);


      //void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint32_t firstScissor, uint32_t scissorCount, VkRect2D* pScissors);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, ref Rect2D pScissors);


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
      public static extern void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, ref DescriptorSet pDescriptorSets, UInt32 dynamicOffsetCount, ref UInt32 pDynamicOffsets);


      //void vkCmdBindIndexBuffer(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkIndexType indexType);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType);


      //void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint32_t firstBinding, uint32_t bindingCount, VkBuffer* pBuffers, VkDeviceSize* pOffsets);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, IntPtr pBuffers, ref DeviceSize pOffsets);
      public unsafe static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer[] pBuffers, ref DeviceSize pOffsets)
      {
         fixed (Buffer* ptr = pBuffers)
         {
            _CmdBindVertexBuffers(commandBuffer, firstBinding, bindingCount, (IntPtr)ptr, ref pOffsets);
         }
      }

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
      static extern void _CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, IntPtr pRegions);
      public unsafe static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy[] pRegions)
      {
         fixed (BufferCopy* ptr = pRegions)
         {
            _CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regionCount, (IntPtr)ptr);
         }
      }

      //void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, IntPtr pRegions);
      public unsafe static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy[] pRegions)
      {
         fixed (ImageCopy* ptr = pRegions)
         {
            _CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, (IntPtr)ptr);
         }
      }

      //void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageBlit* pRegions, VkFilter filter);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBlitImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, IntPtr pRegions, Filter filter);
      public unsafe static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit[] pRegions, Filter filter)
      {
         fixed (ImageBlit* ptr = pRegions)
         {
            _CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, (IntPtr)ptr, filter);
         }
      }

      //void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkBufferImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, IntPtr pRegions);
      public unsafe static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy[] pRegions)
      {
         fixed (BufferImageCopy* ptr = pRegions)
         {
            _CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, (IntPtr)ptr);
         }
      }

      //void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint32_t regionCount, VkBufferImageCopy* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, IntPtr pRegions);
      public unsafe static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy[] pRegions)
      {
         fixed (BufferImageCopy* ptr = pRegions)
         {
            _CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, (IntPtr)ptr);
         }
      }

      //void vkCmdUpdateBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize dataSize, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, IntPtr pData);


      //void vkCmdFillBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize size, uint32_t data);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdFillBuffer", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);


      //void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint32_t rangeCount, VkImageSubresourceRange* pRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearColorImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearColorValue pColor, UInt32 rangeCount, IntPtr pRanges);
      public unsafe static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearColorValue pColor, UInt32 rangeCount, ImageSubresourceRange[] pRanges)
      {
         fixed (ImageSubresourceRange* ptr = pRanges)
         {
            _CmdClearColorImage(commandBuffer, image, imageLayout, ref pColor, rangeCount, (IntPtr)ptr);
         }
      }

      //void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint32_t rangeCount, VkImageSubresourceRange* pRanges);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearDepthStencilValue pDepthStencil, UInt32 rangeCount, IntPtr pRanges);
      public unsafe static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ref ClearDepthStencilValue pDepthStencil, UInt32 rangeCount, ImageSubresourceRange[] pRanges)
      {
         fixed (ImageSubresourceRange* ptr = pRanges)
         {
            _CmdClearDepthStencilImage(commandBuffer, image, imageLayout, ref pDepthStencil, rangeCount, (IntPtr)ptr);
         }
      }

      //void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint32_t attachmentCount, VkClearAttachment* pAttachments, uint32_t rectCount, VkClearRect* pRects);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdClearAttachments", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ref ClearAttachment pAttachments, UInt32 rectCount, IntPtr pRects);
      public unsafe static void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ref ClearAttachment pAttachments, UInt32 rectCount, ClearRect[] pRects)
      {
         fixed (ClearRect* ptr = pRects)
         {
            _CmdClearAttachments(commandBuffer, attachmentCount, ref pAttachments, rectCount, (IntPtr)ptr);
         }
      }

      //void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageResolve* pRegions);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdResolveImage", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, IntPtr pRegions);
      public unsafe static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve[] pRegions)
      {
         fixed (ImageResolve* ptr = pRegions)
         {
            _CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, (IntPtr)ptr);
         }
      }

      //void vkCmdSetEvent(VkCommandBuffer commandBuffer, VkEvent event, VkPipelineStageFlags stageMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdSetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdSetEvent(CommandBuffer commandBuffer, Event _event, PipelineStageFlags stageMask);


      //void vkCmdResetEvent(VkCommandBuffer commandBuffer, VkEvent event, VkPipelineStageFlags stageMask);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdResetEvent", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdResetEvent(CommandBuffer commandBuffer, Event _event, PipelineStageFlags stageMask);


      //void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint32_t eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdWaitEvents", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, IntPtr pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, IntPtr pMemoryBarriers, UInt32 bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, IntPtr pImageMemoryBarriers);
      public unsafe static void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event[] pEvents, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier[] pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier[] pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier[] pImageMemoryBarriers)
      {
         fixed (Event* p1 = pEvents)
         {
            fixed (MemoryBarrier* p2 = pMemoryBarriers)
            {
               fixed (BufferMemoryBarrier* p3 = pBufferMemoryBarriers)
               {
                  fixed (ImageMemoryBarrier* p4 = pImageMemoryBarriers)
                  {
                     _CmdWaitEvents(commandBuffer, eventCount, (IntPtr)p1, srcStageMask, dstStageMask, memoryBarrierCount, (IntPtr)p2, bufferMemoryBarrierCount, (IntPtr)p3, imageMemoryBarrierCount, (IntPtr)p4);
                  }
               }
            }
         }
      }

      //void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, IntPtr pMemoryBarriers, UInt32 bufferMemoryBarrierCount, IntPtr pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, IntPtr pImageMemoryBarriers);
      public unsafe static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier[] pMemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier[] pBufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier[] pImageMemoryBarriers)
      {
         fixed (MemoryBarrier* p1 = pMemoryBarriers)
         {
            fixed (BufferMemoryBarrier* p2 = pBufferMemoryBarriers)
            {
               fixed (ImageMemoryBarrier* p3 = pImageMemoryBarriers)
               {
                  _CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, (IntPtr)p1, bufferMemoryBarrierCount, (IntPtr)p2, imageMemoryBarrierCount, (IntPtr)p3);
               }
            }
         }
      }

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
      public static extern void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr pValues);


      //void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdBeginRenderPass(CommandBuffer commandBuffer, ref RenderPassBeginInfo pRenderPassBegin, SubpassContents contents);


      //void vkCmdNextSubpass(VkCommandBuffer commandBuffer, VkSubpassContents contents);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdNextSubpass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents);


      //void vkCmdEndRenderPass(VkCommandBuffer commandBuffer);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void CmdEndRenderPass(CommandBuffer commandBuffer);


      //void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);
      [DllImport(VulkanLibrary, EntryPoint = "vkCmdExecuteCommands", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern void _CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, IntPtr pCommandBuffers);
      public unsafe static void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer[] pCommandBuffers)
      {
         fixed (CommandBuffer* ptr = pCommandBuffers)
         {
            _CmdExecuteCommands(commandBuffer, commandBufferCount, (IntPtr)ptr);
         }
      }
      #endregion

      #region Device Initialization
      //VkResult vkEnumerateInstanceVersion(uint32_t* pApiVersion);
      [DllImport(VulkanLibrary, EntryPoint = "vkEnumerateInstanceVersion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result EnumerateInstanceVersion(ref UInt32 pApiVersion);

      #endregion

      #region Promoted from VK_KHR_bind_memory2
      //VkResult vkBindBufferMemory2(VkDevice device, uint32_t bindInfoCount, VkBindBufferMemoryInfo* pBindInfos);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindBufferMemory2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindBufferMemory2(Device device, UInt32 bindInfoCount, ref BindBufferMemoryInfo pBindInfos);


      //VkResult vkBindImageMemory2(VkDevice device, uint32_t bindInfoCount, VkBindImageMemoryInfo* pBindInfos);
      [DllImport(VulkanLibrary, EntryPoint = "vkBindImageMemory2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result BindImageMemory2(Device device, UInt32 bindInfoCount, ref BindImageMemoryInfo pBindInfos);

      #endregion

      #region Promoted from VK_KHR_device_group
      //void vkGetDeviceGroupPeerMemoryFeatures(VkDevice device, uint32_t heapIndex, uint32_t localDeviceIndex, uint32_t remoteDeviceIndex, VkPeerMemoryFeatureFlags* pPeerMemoryFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceGroupPeerMemoryFeatures", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceGroupPeerMemoryFeatures(Device device, UInt32 heapIndex, UInt32 localDeviceIndex, UInt32 remoteDeviceIndex, ref PeerMemoryFeatureFlags pPeerMemoryFeatures);


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
      public static extern Result EnumeratePhysicalDeviceGroups(Instance instance, ref UInt32 pPhysicalDeviceGroupCount, ref PhysicalDeviceGroupProperties pPhysicalDeviceGroupProperties);

      #endregion

      #region Promoted from VK_KHR_get_memory_requirements2
      //void vkGetImageMemoryRequirements2(VkDevice device, VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageMemoryRequirements2(Device device, ref ImageMemoryRequirementsInfo2 pInfo, ref MemoryRequirements2 pMemoryRequirements);


      //void vkGetBufferMemoryRequirements2(VkDevice device, VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetBufferMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetBufferMemoryRequirements2(Device device, ref BufferMemoryRequirementsInfo2 pInfo, ref MemoryRequirements2 pMemoryRequirements);


      //void vkGetImageSparseMemoryRequirements2(VkDevice device, VkImageSparseMemoryRequirementsInfo2* pInfo, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetImageSparseMemoryRequirements2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetImageSparseMemoryRequirements2(Device device, ref ImageSparseMemoryRequirementsInfo2 pInfo, ref UInt32 pSparseMemoryRequirementCount, ref SparseImageMemoryRequirements2 pSparseMemoryRequirements);

      #endregion

      #region Promoted from VK_KHR_get_physical_device_properties2
      //void vkGetPhysicalDeviceFeatures2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFeatures2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFeatures2(PhysicalDevice physicalDevice, ref PhysicalDeviceFeatures2 pFeatures);


      //void vkGetPhysicalDeviceProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties2* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceProperties2 pProperties);


      //void vkGetPhysicalDeviceFormatProperties2(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceFormatProperties2(PhysicalDevice physicalDevice, Format format, ref FormatProperties2 pFormatProperties);


      //VkResult vkGetPhysicalDeviceImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetPhysicalDeviceImageFormatProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceImageFormatInfo2 pImageFormatInfo, ref ImageFormatProperties2 pImageFormatProperties);


      //void vkGetPhysicalDeviceQueueFamilyProperties2(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceQueueFamilyProperties2(PhysicalDevice physicalDevice, ref UInt32 pQueueFamilyPropertyCount, ref QueueFamilyProperties2 pQueueFamilyProperties);


      //void vkGetPhysicalDeviceMemoryProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceMemoryProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceMemoryProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceMemoryProperties2 pMemoryProperties);


      //void vkGetPhysicalDeviceSparseImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, uint32_t* pPropertyCount, VkSparseImageFormatProperties2* pProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceSparseImageFormatProperties2(PhysicalDevice physicalDevice, ref PhysicalDeviceSparseImageFormatInfo2 pFormatInfo, ref UInt32 pPropertyCount, ref SparseImageFormatProperties2 pProperties);

      #endregion

      #region Promoted from VK_KHR_maintenance1
      //void vkTrimCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolTrimFlags flags);
      [DllImport(VulkanLibrary, EntryPoint = "vkTrimCommandPool", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void TrimCommandPool(Device device, CommandPool commandPool, CommandPoolTrimFlags flags);

      #endregion

      #region Originally based on VK_KHR_protected_memory (extension 146), which was never published; thus the mystifying large value= numbers below. These are not aliased since they weren't actually promoted from an extension.
      //void vkGetDeviceQueue2(VkDevice device, VkDeviceQueueInfo2* pQueueInfo, VkQueue* pQueue);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDeviceQueue2", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDeviceQueue2(Device device, ref DeviceQueueInfo2 pQueueInfo, ref Queue pQueue);

      #endregion

      #region Promoted from VK_KHR_sampler_ycbcr_conversion
      //VkResult vkCreateSamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversionCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversion* pYcbcrConversion);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateSamplerYcbcrConversion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateSamplerYcbcrConversion(Device device, ref SamplerYcbcrConversionCreateInfo pCreateInfo, AllocationCallbacks pAllocator, ref SamplerYcbcrConversion pYcbcrConversion);


      //void vkDestroySamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversion ycbcrConversion, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroySamplerYcbcrConversion", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroySamplerYcbcrConversion(Device device, SamplerYcbcrConversion ycbcrConversion, AllocationCallbacks pAllocator);

      #endregion

      #region Promoted from VK_KHR_descriptor_update_template
      //VkResult vkCreateDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplate* pDescriptorUpdateTemplate);
      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDescriptorUpdateTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result CreateDescriptorUpdateTemplate(Device device, ref DescriptorUpdateTemplateCreateInfo pCreateInfo, AllocationCallbacks pAllocator, ref DescriptorUpdateTemplate pDescriptorUpdateTemplate);


      //void vkDestroyDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplate descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator);
      [DllImport(VulkanLibrary, EntryPoint = "vkDestroyDescriptorUpdateTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void DestroyDescriptorUpdateTemplate(Device device, DescriptorUpdateTemplate descriptorUpdateTemplate, AllocationCallbacks pAllocator);


      //void vkUpdateDescriptorSetWithTemplate(VkDevice device, VkDescriptorSet descriptorSet, VkDescriptorUpdateTemplate descriptorUpdateTemplate, void* pData);
      [DllImport(VulkanLibrary, EntryPoint = "vkUpdateDescriptorSetWithTemplate", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void UpdateDescriptorSetWithTemplate(Device device, DescriptorSet descriptorSet, DescriptorUpdateTemplate descriptorUpdateTemplate, IntPtr pData);

      #endregion

      #region Promoted from VK_KHR_external_memory_capabilities
      //void vkGetPhysicalDeviceExternalBufferProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalBufferProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalBufferProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalBufferInfo pExternalBufferInfo, ref ExternalBufferProperties pExternalBufferProperties);

      #endregion

      #region Promoted from VK_KHR_external_fence_capabilities
      //void vkGetPhysicalDeviceExternalFenceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalFenceProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalFenceProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalFenceInfo pExternalFenceInfo, ref ExternalFenceProperties pExternalFenceProperties);

      #endregion

      #region Promoted from VK_KHR_external_semaphore_capabilities
      //void vkGetPhysicalDeviceExternalSemaphoreProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceExternalSemaphoreProperties", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetPhysicalDeviceExternalSemaphoreProperties(PhysicalDevice physicalDevice, ref PhysicalDeviceExternalSemaphoreInfo pExternalSemaphoreInfo, ref ExternalSemaphoreProperties pExternalSemaphoreProperties);

      #endregion

      #region Promoted from VK_KHR_maintenance3
      //void vkGetDescriptorSetLayoutSupport(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);
      [DllImport(VulkanLibrary, EntryPoint = "vkGetDescriptorSetLayoutSupport", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern void GetDescriptorSetLayoutSupport(Device device, ref DescriptorSetLayoutCreateInfo pCreateInfo, ref DescriptorSetLayoutSupport pSupport);

      #endregion
   }
}
