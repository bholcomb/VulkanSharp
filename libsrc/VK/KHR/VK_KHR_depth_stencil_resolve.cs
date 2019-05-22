using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_depth_stencil_resolve = "VK_KHR_depth_stencil_resolve";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      [Flags]
      public enum ResolveModeFlagsKHR : int
      {  
         SampleZeroBitKhr = 1 << 0,
         AverageBitKhr = 1 << 1,
         MinBitKhr = 1 << 2,
         MaxBitKhr = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SubpassDescriptionDepthStencilResolveKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ResolveModeFlagsKHR depthResolveMode;
         public ResolveModeFlagsKHR stencilResolveMode;
         public AttachmentReference2KHR* pDepthStencilResolveAttachment;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDepthStencilResolvePropertiesKHR 
      {
         public StructureType sType;
         public IntPtr pNext;
         public ResolveModeFlagsKHR supportedDepthResolveModes;
         public ResolveModeFlagsKHR supportedStencilResolveModes;
         public Bool32 independentResolve;
         public Bool32 independentResolveNone;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
