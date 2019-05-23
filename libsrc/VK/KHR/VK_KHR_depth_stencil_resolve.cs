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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum ResolveModeFlagsKHR : int
      {  
         ResolveModeSampleZeroBitKhr = 1 << 0,
         ResolveModeAverageBitKhr = 1 << 1,
         ResolveModeMinBitKhr = 1 << 2,
         ResolveModeMaxBitKhr = 1 << 3,
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassDescriptionDepthStencilResolveKHR 
      {
         public StructureType sType;
         public void pNext;
         public ResolveModeFlagsKHR depthResolveMode;
         public ResolveModeFlagsKHR stencilResolveMode;
         public AttachmentReference2KHR pDepthStencilResolveAttachment;
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDepthStencilResolvePropertiesKHR 
      {
         public StructureType sType;
         public void pNext;
         public ResolveModeFlagsKHR supportedDepthResolveModes;
         public ResolveModeFlagsKHR supportedStencilResolveModes;
         public Bool32 independentResolveNone;
         public Bool32 independentResolve;
      };
      
      #endregion

      //no functions
   }
}
