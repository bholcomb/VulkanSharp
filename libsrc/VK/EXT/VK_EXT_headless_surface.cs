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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum HeadlessSurfaceCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct HeadlessSurfaceCreateInfoEXT 
      {
         public StructureType type;          
         public IntPtr next;          
         public HeadlessSurfaceCreateFlagsEXT flags;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateHeadlessSurfaceEXT(VkInstance instance, VkHeadlessSurfaceCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateHeadlessSurfaceEXTDelegate(Instance instance, ref HeadlessSurfaceCreateInfoEXT pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateHeadlessSurfaceEXTDelegate CreateHeadlessSurfaceEXT;
      #endregion

      #region interop
      public static class VK_EXT_headless_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateHeadlessSurfaceEXT = ExternalFunction.getInstanceFunction<VK.CreateHeadlessSurfaceEXTDelegate>(instance, "vkCreateHeadlessSurfaceEXT");
         }
      }
      #endregion
   }
}
