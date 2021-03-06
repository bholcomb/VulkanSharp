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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum StreamDescriptorSurfaceCreateFlagsGGP : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct StreamDescriptorSurfaceCreateInfoGGP 
      {
         public StructureType type;          
         public IntPtr next;          
         public StreamDescriptorSurfaceCreateFlagsGGP flags;          
         public IntPtr/*GgpStreamDescriptor*/ streamDescriptor;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateStreamDescriptorSurfaceGGP(VkInstance instance, VkStreamDescriptorSurfaceCreateInfoGGP* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateStreamDescriptorSurfaceGGPDelegate(Instance instance, ref StreamDescriptorSurfaceCreateInfoGGP pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateStreamDescriptorSurfaceGGPDelegate CreateStreamDescriptorSurfaceGGP;
      #endregion

      #region interop
      public static class GGP_stream_descriptor_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateStreamDescriptorSurfaceGGP = ExternalFunction.getInstanceFunction<VK.CreateStreamDescriptorSurfaceGGPDelegate>(instance, "vkCreateStreamDescriptorSurfaceGGP");
         }
      }
      #endregion
   }
}
