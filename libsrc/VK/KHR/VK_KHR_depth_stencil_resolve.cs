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
      public unsafe struct SubpassDescriptionDepthStencilResolveKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ResolveModeFlagsKHR depthResolveMode;  //depth resolve mode 
         public ResolveModeFlagsKHR stencilResolveMode;  //stencil resolve mode 
         public AttachmentReference2KHR* pDepthStencilResolveAttachment;  //depth/stencil resolve attachment 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDeviceDepthStencilResolvePropertiesKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public ResolveModeFlagsKHR supportedDepthResolveModes;  //supported depth resolve modes 
         public ResolveModeFlagsKHR supportedStencilResolveModes;  //supported stencil resolve modes 
         public Bool32 independentResolveNone;  //depth and stencil resolve modes can be set independently if one of them is none 
         public Bool32 independentResolve;  //depth and stencil resolve modes can be set independently 
      };
      
      
      #endregion

      //no functions
   }
}
