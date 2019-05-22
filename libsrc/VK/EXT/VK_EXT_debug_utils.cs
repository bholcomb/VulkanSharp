using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_debug_utils = "VK_EXT_debug_utils";
   };
   
   public static partial class VK
   {
      [StructLayout(LayoutKind.Sequential)] public struct DebugUtilsMessengerEXT { public UInt64 native; }

      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DebugUtilsObjectNameInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ObjectType objectType;
         public UInt64 objectHandle;
         public string pObjectName;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DebugUtilsObjectTagInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ObjectType objectType;
         public UInt64 objectHandle;
         public UInt64 tagName;
         public UInt32 tagSize;
         public IntPtr pTag;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DebugUtilsLabelEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public string pLabelName;
         public fixed float color[4];
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct DebugUtilsMessengerCallbackDataEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public string pMessageIdName;
         public Int32 messageIdNumber;
         public string pMessage;
         public UInt32 queueLabelCount;
         public IntPtr* pQueueLabels;
         public UInt32 cmdBufLabelCount;
         public IntPtr* pCmdBufLabels;
         public UInt32 objectCount;
         public IntPtr* pObjects;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DebugUtilsMessengerCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public DebugUtilsMessageSeverityFlagsEXT messageSeverity;
         public DebugUtilsMessageTypeFlagsEXT messageType;
         public DebugUtilsMessengerCallbackEXT pfnUserCallback;
         public IntPtr pUserData;
      };

      #endregion

      #region functions
      [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
      public delegate Bool32 DebugUtilsMessengerCallbackEXT(DebugUtilsMessageSeverityFlagsEXT messageSeverity, DebugUtilsMessageTypeFlagsEXT messageTypes, ref DebugUtilsMessengerCallbackDataEXT pCallbackData, IntPtr pUserData);

      //external functions we need to get from the instance
      //VkResult vkSetDebugUtilsObjectNameEXT(VkDevice  device, const VkDebugUtilsObjectNameInfoEXT *  pNameInfo);
      //VkResult vkSetDebugUtilsObjectTagEXT(VkDevice  device, const VkDebugUtilsObjectTagInfoEXT *  pTagInfo);
      //void vkQueueBeginDebugUtilsLabelEXT(VkQueue  queue, const VkDebugUtilsLabelEXT *  pLabelInfo);
      //void vkQueueEndDebugUtilsLabelEXT(VkQueue  queue);
      //void vkQueueInsertDebugUtilsLabelEXT(VkQueue  queue, const VkDebugUtilsLabelEXT *  pLabelInfo);
      //void vkCmdBeginDebugUtilsLabelEXT(VkCommandBuffer  commandBuffer, const VkDebugUtilsLabelEXT *  pLabelInfo);
      //void vkCmdEndDebugUtilsLabelEXT(VkCommandBuffer  commandBuffer);
      //void vkCmdInsertDebugUtilsLabelEXT(VkCommandBuffer  commandBuffer, const VkDebugUtilsLabelEXT *  pLabelInfo);
      //VkResult vkCreateDebugUtilsMessengerEXT(VkInstance  instance, const VkDebugUtilsMessengerCreateInfoEXT *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkDebugUtilsMessengerEXT *  pMessenger);
      //void vkDestroyDebugUtilsMessengerEXT(VkInstance  instance, VkDebugUtilsMessengerEXT  messenger, const VkAllocationCallbacks *  pAllocator);
      //void vkSubmitDebugUtilsMessageEXT(VkInstance  instance, VkDebugUtilsMessageSeverityFlagBitsEXT  messageSeverity, VkDebugUtilsMessageTypeFlagsEXT  messageTypes, const VkDebugUtilsMessengerCallbackDataEXT *  pCallbackData);

      //delegate definitions
      public delegate Result SetDebugUtilsObjectNameEXTDelegate(Device device, ref DebugUtilsObjectNameInfoEXT pNameInfos);
      public delegate Result SetDebugUtilsObjectTagEXTDelegate(Device device, ref DebugUtilsObjectTagInfoEXT pTagInfos);
      public delegate void QueueBeginDebugUtilsLabelEXTDelegate(Queue queue, ref DebugUtilsLabelEXT pLabelInfos);
      public delegate void QueueEndDebugUtilsLabelEXTDelegate(Queue queues);
      public delegate void QueueInsertDebugUtilsLabelEXTDelegate(Queue queue, ref DebugUtilsLabelEXT pLabelInfos);
      public delegate void CmdBeginDebugUtilsLabelEXTDelegate(CommandBuffer commandBuffer, ref DebugUtilsLabelEXT pLabelInfos);
      public delegate void CmdEndDebugUtilsLabelEXTDelegate(CommandBuffer commandBuffers);
      public delegate void CmdInsertDebugUtilsLabelEXTDelegate(CommandBuffer commandBuffer, ref DebugUtilsLabelEXT pLabelInfos);
      public delegate Result CreateDebugUtilsMessengerEXTDelegate(Instance instance, ref DebugUtilsMessengerCreateInfoEXT pCreateInfo, ref AllocationCallbacks pAllocator, ref DebugUtilsMessengerEXT pMessengers);
      public delegate void DestroyDebugUtilsMessengerEXTDelegate(Instance instance, DebugUtilsMessengerEXT messenger, ref AllocationCallbacks pAllocators);
      public delegate void SubmitDebugUtilsMessageEXTDelegate(Instance instance, DebugUtilsMessageSeverityFlagsEXT messageSeverity, DebugUtilsMessageTypeFlagsEXT messageTypes, ref DebugUtilsMessengerCallbackDataEXT pCallbackDatas);
      
      //delegate instances
      public static SetDebugUtilsObjectNameEXTDelegate SetDebugUtilsObjectNameEXT;
      public static SetDebugUtilsObjectTagEXTDelegate SetDebugUtilsObjectTagEXT;
      public static QueueBeginDebugUtilsLabelEXTDelegate QueueBeginDebugUtilsLabelEXT;
      public static QueueEndDebugUtilsLabelEXTDelegate QueueEndDebugUtilsLabelEXT;
      public static QueueInsertDebugUtilsLabelEXTDelegate QueueInsertDebugUtilsLabelEXT;
      public static CmdBeginDebugUtilsLabelEXTDelegate CmdBeginDebugUtilsLabelEXT;
      public static CmdEndDebugUtilsLabelEXTDelegate CmdEndDebugUtilsLabelEXT;
      public static CmdInsertDebugUtilsLabelEXTDelegate CmdInsertDebugUtilsLabelEXT;
      public static CreateDebugUtilsMessengerEXTDelegate CreateDebugUtilsMessengerEXT;
      public static DestroyDebugUtilsMessengerEXTDelegate DestroyDebugUtilsMessengerEXT;
      public static SubmitDebugUtilsMessageEXTDelegate SubmitDebugUtilsMessageEXT;
      #endregion

      #region interop
      public static class VK_EXT_debug_utils
      {
         public static void init(VK.Instance instance)
         {
            VK.SetDebugUtilsObjectNameEXT = ExternalFunction.getInstanceFunction<VK.SetDebugUtilsObjectNameEXTDelegate>(instance, "vkSetDebugUtilsObjectNameEXT");
            VK.SetDebugUtilsObjectTagEXT = ExternalFunction.getInstanceFunction<VK.SetDebugUtilsObjectTagEXTDelegate>(instance, "vkSetDebugUtilsObjectTagEXT");
            VK.QueueBeginDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.QueueBeginDebugUtilsLabelEXTDelegate>(instance, "vkQueueBeginDebugUtilsLabelEXT");
            VK.QueueEndDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.QueueEndDebugUtilsLabelEXTDelegate>(instance, "vkQueueEndDebugUtilsLabelEXT");
            VK.QueueInsertDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.QueueInsertDebugUtilsLabelEXTDelegate>(instance, "vkQueueInsertDebugUtilsLabelEXT");
            VK.CmdBeginDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.CmdBeginDebugUtilsLabelEXTDelegate>(instance, "vkCmdBeginDebugUtilsLabelEXT");
            VK.CmdEndDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.CmdEndDebugUtilsLabelEXTDelegate>(instance, "vkCmdEndDebugUtilsLabelEXT");
            VK.CmdInsertDebugUtilsLabelEXT = ExternalFunction.getInstanceFunction<VK.CmdInsertDebugUtilsLabelEXTDelegate>(instance, "vkCmdInsertDebugUtilsLabelEXT");
            VK.CreateDebugUtilsMessengerEXT = ExternalFunction.getInstanceFunction<VK.CreateDebugUtilsMessengerEXTDelegate>(instance, "vkCreateDebugUtilsMessengerEXT");
            VK.DestroyDebugUtilsMessengerEXT = ExternalFunction.getInstanceFunction<VK.DestroyDebugUtilsMessengerEXTDelegate>(instance, "vkDestroyDebugUtilsMessengerEXT");
            VK.SubmitDebugUtilsMessageEXT = ExternalFunction.getInstanceFunction<VK.SubmitDebugUtilsMessageEXTDelegate>(instance, "vkSubmitDebugUtilsMessageEXT");
         }
      }
      #endregion
   }
}
