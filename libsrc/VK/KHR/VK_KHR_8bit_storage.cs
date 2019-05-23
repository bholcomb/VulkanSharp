using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_8bit_storage = "VK_KHR_8bit_storage";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevice8BitStorageFeaturesKHR 
      {
         public StructureType sType;
         public void pNext;
         public Bool32 storageBuffer8BitAccess;
         public Bool32 uniformAndStorageBuffer8BitAccess;
         public Bool32 storagePushConstant8;
      };
      
      #endregion

      //no functions
   }
}
