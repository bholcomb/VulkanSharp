using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_metal_surface = "VK_EXT_metal_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MetalSurfaceCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
         public IntPtr pLayer;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateMetalSurfaceEXT(VkInstance  instance, const VkMetalSurfaceCreateInfoEXT *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateMetalSurfaceEXTDelegate(Instance instance, ref MetalSurfaceCreateInfoEXT pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateMetalSurfaceEXTDelegate CreateMetalSurfaceEXT;
      #endregion

      #region interop
      public static class EXT_metal_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateMetalSurfaceEXT = ExternalFunction.getInstanceFunction<VK.CreateMetalSurfaceEXTDelegate>(instance, "vkCreateMetalSurfaceEXT");
         }
      }
      #endregion
   }
}
