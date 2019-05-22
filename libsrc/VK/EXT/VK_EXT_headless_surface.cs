using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_headless_surface = "VK_EXT_headless_surface";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct HeadlessSurfaceCreateInfoEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 flags;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateHeadlessSurfaceEXT(VkInstance  instance, const VkHeadlessSurfaceCreateInfoEXT *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkSurfaceKHR *  pSurface);
      
      //delegate definitions
      public delegate Result CreateHeadlessSurfaceEXTDelegate(Instance instance, ref HeadlessSurfaceCreateInfoEXT pCreateInfo, AllocationCallbacks pAllocator, ref SurfaceKHR pSurfaces);
      
      //delegate instances
      public static CreateHeadlessSurfaceEXTDelegate CreateHeadlessSurfaceEXT;
      #endregion

      #region interop
      public static class EXT_headless_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateHeadlessSurfaceEXT = ExternalFunction.getInstanceFunction<VK.CreateHeadlessSurfaceEXTDelegate>(instance, "vkCreateHeadlessSurfaceEXT");
         }
      }
      #endregion
   }
}
