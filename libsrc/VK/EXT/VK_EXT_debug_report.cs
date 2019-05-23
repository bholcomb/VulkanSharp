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
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct DebugReportCallbackEXT { public UInt64 native; }
      #endregion 
      

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
      [Flags]
      public enum DebugReportFlagsEXT : int
      {  
         DebugReportInformationBitExt = 1 << 0,
         DebugReportWarningBitExt = 1 << 1,
         DebugReportPerformanceWarningBitExt = 1 << 2,
         DebugReportErrorBitExt = 1 << 3,
         DebugReportDebugBitExt = 1 << 4,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DebugReportCallbackCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DebugReportFlagsEXT flags;  //Indicates which events call this callback 
         public DebugReportCallbackEXT pfnCallback;  //Function pointer of a callback function 
         public IntPtr pUserData;  //User data provided to callback function 
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDebugReportCallbackEXT* pCallback);
      //void vkDestroyDebugReportCallbackEXT(VkInstance instance, VkDebugReportCallbackEXT callback, VkAllocationCallbacks* pAllocator);
      //void vkDebugReportMessageEXT(VkInstance instance, VkDebugReportFlagsEXT flags, VkDebugReportObjectTypeEXT objectType, uint64_t object, size_t location, int32_t messageCode, char* pLayerPrefix, char* pMessage);
      
      //delegate definitions
      public delegate Result CreateDebugReportCallbackEXTDelegate(Instance instance, ref DebugReportCallbackCreateInfoEXT pCreateInfo, ref AllocationCallbacks pAllocator, ref DebugReportCallbackEXT pCallback);
      public delegate void DestroyDebugReportCallbackEXTDelegate(Instance instance, DebugReportCallbackEXT callback, ref AllocationCallbacks pAllocator);
      public delegate void DebugReportMessageEXTDelegate(Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 object, UInt32 location, Int32 messageCode, ref char pLayerPrefix, ref char pMessage);
      
      //delegate instances
      public static CreateDebugReportCallbackEXTDelegate CreateDebugReportCallbackEXT;
      public static DestroyDebugReportCallbackEXTDelegate DestroyDebugReportCallbackEXT;
      public static DebugReportMessageEXTDelegate DebugReportMessageEXT;
      #endregion

      #region interop
      public static class VK_EXT_debug_report
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
