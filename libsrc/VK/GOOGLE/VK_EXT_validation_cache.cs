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
      [StructLayout(LayoutKind.Sequential)] public struct ValidationCacheEXT { public UInt64 native; }

      #region enums
      public enum ValidationCacheHeaderVersionEXT : int
      {  
         OneExt = 1,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ValidationCacheCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public UInt32 initialDataSize;
         public IntPtr pInitialData;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ShaderModuleValidationCacheCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ValidationCacheEXT validationCache;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateValidationCacheEXT(VkDevice  device, const VkValidationCacheCreateInfoEXT *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkValidationCacheEXT *  pValidationCache);
      //void vkDestroyValidationCacheEXT(VkDevice  device, VkValidationCacheEXT  validationCache, const VkAllocationCallbacks *  pAllocator);
      //VkResult vkMergeValidationCachesEXT(VkDevice  device, VkValidationCacheEXT  dstCache, uint32_t  srcCacheCount, const VkValidationCacheEXT *  pSrcCaches);
      //VkResult vkGetValidationCacheDataEXT(VkDevice  device, VkValidationCacheEXT  validationCache, size_t *  pDataSize, void *  pData);
      
      //delegate definitions
      public delegate Result CreateValidationCacheEXTDelegate(Device device, ref ValidationCacheCreateInfoEXT pCreateInfo, AllocationCallbacks pAllocator, ref ValidationCacheEXT pValidationCaches);
      public delegate void DestroyValidationCacheEXTDelegate(Device device, ValidationCacheEXT validationCache, AllocationCallbacks pAllocators);
      public delegate Result MergeValidationCachesEXTDelegate(Device device, ValidationCacheEXT dstCache, UInt32 srcCacheCount, ref ValidationCacheEXT pSrcCachess);
      public delegate Result GetValidationCacheDataEXTDelegate(Device device, ValidationCacheEXT validationCache, ref UInt32 pDataSize, IntPtr pDatas);
      
      //delegate instances
      public static CreateValidationCacheEXTDelegate CreateValidationCacheEXT;
      public static DestroyValidationCacheEXTDelegate DestroyValidationCacheEXT;
      public static MergeValidationCachesEXTDelegate MergeValidationCachesEXT;
      public static GetValidationCacheDataEXTDelegate GetValidationCacheDataEXT;
      #endregion

      #region interop
      public static class EXT_validation_cache
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
