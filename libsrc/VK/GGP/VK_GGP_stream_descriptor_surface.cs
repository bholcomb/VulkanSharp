using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_GGP_stream_descriptor_surface = "VK_GGP_stream_descriptor_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct StreamDescriptorSurfaceCreateInfoGGP 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr streamDescriptor;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateStreamDescriptorSurfaceGGP(VkInstance  instance, const VkStreamDescriptorSurfaceCreateInfoGGP *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateStreamDescriptorSurfaceGGPDelegate(Instance instance, ref StreamDescriptorSurfaceCreateInfoGGP pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateStreamDescriptorSurfaceGGPDelegate CreateStreamDescriptorSurfaceGGP;
      #endregion

      #region interop
      public static class VK_GGP_stream_descriptor_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateStreamDescriptorSurfaceGGP = ExternalFunction.getInstanceFunction<VK.CreateStreamDescriptorSurfaceGGPDelegate>(instance, "vkCreateStreamDescriptorSurfaceGGP");
         }
      }
      #endregion
   }
}
