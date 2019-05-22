using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_debug_report = "VK_EXT_debug_report";
   };
   
   public static partial class VK
   {
      #region enums
      public enum DebugReportObjectTypeEXT : int
      {  
         UnknownExt = 0,
         InstanceExt = 1,
         PhysicalDeviceExt = 2,
         DeviceExt = 3,
         QueueExt = 4,
         SemaphoreExt = 5,
         CommandBufferExt = 6,
         FenceExt = 7,
         DeviceMemoryExt = 8,
         BufferExt = 9,
         ImageExt = 10,
         EventExt = 11,
         QueryPoolExt = 12,
         BufferViewExt = 13,
         ImageViewExt = 14,
         ShaderModuleExt = 15,
         PipelineCacheExt = 16,
         PipelineLayoutExt = 17,
         RenderPassExt = 18,
         PipelineExt = 19,
         DescriptorSetLayoutExt = 20,
         SamplerExt = 21,
         DescriptorPoolExt = 22,
         DescriptorSetExt = 23,
         FramebufferExt = 24,
         CommandPoolExt = 25,
         SurfaceKhrExt = 26,
         SwapchainKhrExt = 27,
         DebugReportCallbackExtExt = 28,
         DisplayKhrExt = 29,
         DisplayModeKhrExt = 30,
         ObjectTableNvxExt = 31,
         IndirectCommandsLayoutNvxExt = 32,
         ValidationCacheExtExt = 33,
         SamplerYcbcrConversionExt = 1000012000,
         DescriptorUpdateTemplateExt = 1000012000,
         AccelerationStructureNvExt = 1000166000,
         
      };

      #endregion

      #region flags
      public enum DebugReportFlagsEXT : UInt32
      {
         InformationBitExt = 0x00000001,
         WarningBitExt = 0x00000002,
         PerformanceWarningBitExt = 0x00000004,
         ErrorBitExt = 0x00000008,
         DebugBitExt = 0x00000010,
      };
      #endregion

      #region structs
      [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
      public delegate Bool32 DebugReportCallbackEXT(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 obj, UInt32 location, Int32 messageCode, string pLayerPrefix, string pMessage, IntPtr pUserData);


      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DebugReportCallbackCreateInfoEXT 
      {
         public StructureType type;
         public IntPtr next;
         public DebugReportFlagsEXT flags;
         public DebugReportCallbackEXT pfnCallback;
         public IntPtr pUserData;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateDebugReportCallbackEXT(VkInstance  instance, const VkDebugReportCallbackCreateInfoEXT *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkDebugReportCallbackEXT *  pCallback);
      //void vkDestroyDebugReportCallbackEXT(VkInstance  instance, VkDebugReportCallbackEXT  callback, const VkAllocationCallbacks *  pAllocator);
      //void vkDebugReportMessageEXT(VkInstance  instance, VkDebugReportFlagsEXT  flags, VkDebugReportObjectTypeEXT  objectType, uint64_t  object, size_t  location, int32_t  messageCode, const char *  pLayerPrefix, const char *  pMessage);
      
      //delegate definitions
      public delegate Result CreateDebugReportCallbackEXTDelegate(Instance instance, ref DebugReportCallbackCreateInfoEXT pCreateInfo, AllocationCallbacks pAllocator, out DebugReportCallbackEXT pCallbacks);
      public delegate void DestroyDebugReportCallbackEXTDelegate(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks pAllocators);
      public delegate void DebugReportMessageEXTDelegate(Instance instance, UInt32 flags, DebugReportObjectTypeEXT objectType, UInt64 obj, UInt32 location, Int32 messageCode, string pLayerPrefix, string pMessages);
      
      //delegate instances
      public static CreateDebugReportCallbackEXTDelegate CreateDebugReportCallbackEXT;
      public static DestroyDebugReportCallbackEXTDelegate DestroyDebugReportCallbackEXT;
      public static DebugReportMessageEXTDelegate DebugReportMessageEXT;
      #endregion

      #region interop
      public static class EXT_debug_report
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateDebugReportCallbackEXT = ExternalFunction.getInstanceFunction<VK.CreateDebugReportCallbackEXTDelegate>(instance, "vkCreateDebugReportCallbackEXT");
            VK.DestroyDebugReportCallbackEXT = ExternalFunction.getInstanceFunction<VK.DestroyDebugReportCallbackEXTDelegate>(instance, "vkDestroyDebugReportCallbackEXT");
            VK.DebugReportMessageEXT = ExternalFunction.getInstanceFunction<VK.DebugReportMessageEXTDelegate>(instance, "vkDebugReportMessageEXT");
         }
      }
      #endregion
   }
}
