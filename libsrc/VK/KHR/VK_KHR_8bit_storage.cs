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
         public StructureType type;          
         public IntPtr next;          
         public Bool32 storageBuffer8BitAccess;  //8-bit integer variables supported in StorageBuffer 
         public Bool32 uniformAndStorageBuffer8BitAccess;  //8-bit integer variables supported in StorageBuffer and Uniform 
         public Bool32 storagePushConstant8;  //8-bit integer variables supported in PushConstant 
      };
      
      
      #endregion

      //no functions
   }
}
