using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_win32_keyed_mutex = "VK_KHR_win32_keyed_mutex";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct Win32KeyedMutexAcquireReleaseInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public UInt32 acquireCount;          
         public DeviceMemory* pAcquireSyncs;          
         public UInt64* pAcquireKeys;          
         public UInt32* pAcquireTimeouts;          
         public UInt32 releaseCount;          
         public DeviceMemory* pReleaseSyncs;          
         public UInt64* pReleaseKeys;          
      };
      
      
      #endregion

      //no functions
   }
}
