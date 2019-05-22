using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_NV_cooperative_matrix = "VK_NV_cooperative_matrix";
   };
   
   public static partial class VK
   {
      #region enums
      public enum ScopeNV : int
      {  
         DeviceNv = 1,
         WorkgroupNv = 2,
         SubgroupNv = 3,
         QueueFamilyNv = 5,
         
      };
      
      public enum ComponentTypeNV : int
      {  
         Float16Nv = 0,
         Float32Nv = 1,
         Float64Nv = 2,
         Sint8Nv = 3,
         Sint16Nv = 4,
         Sint32Nv = 5,
         Sint64Nv = 6,
         Uint8Nv = 7,
         Uint16Nv = 8,
         Uint32Nv = 9,
         Uint64Nv = 10,
         
      };
      
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct CooperativeMatrixPropertiesNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 MSize;
         public UInt32 NSize;
         public UInt32 KSize;
         public ComponentTypeNV AType;
         public ComponentTypeNV BType;
         public ComponentTypeNV CType;
         public ComponentTypeNV DType;
         public ScopeNV scope;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceCooperativeMatrixFeaturesNV 
      {
         public StructureType sType;
         public IntPtr pNext;
         public Bool32 cooperativeMatrix;
         public Bool32 cooperativeMatrixRobustBufferAccess;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceCooperativeMatrixPropertiesNV 
      {
         public StructureType sType;
         public ShaderStageFlags cooperativeMatrixSupportedStages;
         public IntPtr pNext;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesNV(VkPhysicalDevice  physicalDevice, uint32_t *  pPropertyCount, VkCooperativeMatrixPropertiesNV *  pProperties);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceCooperativeMatrixPropertiesNVDelegate(PhysicalDevice physicalDevice, ref UInt32 pPropertyCount, ref CooperativeMatrixPropertiesNV pPropertiess);
      
      //delegate instances
      public static GetPhysicalDeviceCooperativeMatrixPropertiesNVDelegate GetPhysicalDeviceCooperativeMatrixPropertiesNV;
      #endregion

      #region interop
      public static class NV_cooperative_matrix
      {
         public static void init(VK.Device device)
         {
            VK.GetPhysicalDeviceCooperativeMatrixPropertiesNV = ExternalFunction.getDeviceFunction<VK.GetPhysicalDeviceCooperativeMatrixPropertiesNVDelegate>(device, "vkGetPhysicalDeviceCooperativeMatrixPropertiesNV");
         }
      }
      #endregion
   }
}
