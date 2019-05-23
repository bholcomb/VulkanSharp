using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_validation_cache = "VK_EXT_validation_cache";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct ValidationCacheEXT { public UInt64 native; }
      #endregion 
      

      #region enums
      public enum ValidationCacheHeaderVersionEXT : int
      {  
         OneExt = 1,
      };
      
      #endregion

       
      #region flags
      [Flags]
      public enum ValidationCacheCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ValidationCacheCreateInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public ValidationCacheCreateFlagsEXT flags;
         public UInt32 initialDataSize;
         public void pInitialData;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ShaderModuleValidationCacheCreateInfoEXT 
      {
         public StructureType sType;
         public void pNext;
         public ValidationCacheEXT validationCache;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateValidationCacheEXT(VkDevice device, VkValidationCacheCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkValidationCacheEXT* pValidationCache);
      //void vkDestroyValidationCacheEXT(VkDevice device, VkValidationCacheEXT validationCache, VkAllocationCallbacks* pAllocator);
      //VkResult vkMergeValidationCachesEXT(VkDevice device, VkValidationCacheEXT dstCache, uint32_t srcCacheCount, VkValidationCacheEXT* pSrcCaches);
      //VkResult vkGetValidationCacheDataEXT(VkDevice device, VkValidationCacheEXT validationCache, size_t* pDataSize, void* pData);
      
      //delegate definitions
      public delegate Result CreateValidationCacheEXTDelegate(Device device, ref ValidationCacheCreateInfoEXT pCreateInfo, ref AllocationCallbacks pAllocator, ref ValidationCacheEXT pValidationCache);
      public delegate void DestroyValidationCacheEXTDelegate(Device device, ValidationCacheEXT validationCache, ref AllocationCallbacks pAllocator);
      public delegate Result MergeValidationCachesEXTDelegate(Device device, ValidationCacheEXT dstCache, UInt32 srcCacheCount, ref ValidationCacheEXT pSrcCaches);
      public delegate Result GetValidationCacheDataEXTDelegate(Device device, ValidationCacheEXT validationCache, ref UInt32 pDataSize, ref void pData);
      
      //delegate instances
      public static CreateValidationCacheEXTDelegate CreateValidationCacheEXT;
      public static DestroyValidationCacheEXTDelegate DestroyValidationCacheEXT;
      public static MergeValidationCachesEXTDelegate MergeValidationCachesEXT;
      public static GetValidationCacheDataEXTDelegate GetValidationCacheDataEXT;
      #endregion

      #region interop
      public static class VK_EXT_validation_cache
      {
         public static void init(VK.Device device)
         {
            VK.CreateValidationCacheEXT = ExternalFunction.getDeviceFunction<VK.CreateValidationCacheEXTDelegate>(device, "vkCreateValidationCacheEXT");
            VK.DestroyValidationCacheEXT = ExternalFunction.getDeviceFunction<VK.DestroyValidationCacheEXTDelegate>(device, "vkDestroyValidationCacheEXT");
            VK.MergeValidationCachesEXT = ExternalFunction.getDeviceFunction<VK.MergeValidationCachesEXTDelegate>(device, "vkMergeValidationCachesEXT");
            VK.GetValidationCacheDataEXT = ExternalFunction.getDeviceFunction<VK.GetValidationCacheDataEXTDelegate>(device, "vkGetValidationCacheDataEXT");
         }
      }
      #endregion
   }
}
