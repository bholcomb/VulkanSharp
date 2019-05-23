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
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum MetalSurfaceCreateFlagsEXT : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct MetalSurfaceCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public MetalSurfaceCreateFlagsEXT flags;          
         public IntPtr /*CAMetalLayer* */ pLayer;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateMetalSurfaceEXT(VkInstance instance, VkMetalSurfaceCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateMetalSurfaceEXTDelegate(Instance instance, ref MetalSurfaceCreateInfoEXT pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateMetalSurfaceEXTDelegate CreateMetalSurfaceEXT;
      #endregion

      #region interop
      public static class VK_EXT_metal_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateMetalSurfaceEXT = ExternalFunction.getInstanceFunction<VK.CreateMetalSurfaceEXTDelegate>(instance, "vkCreateMetalSurfaceEXT");
         }
      }
      #endregion
   }
}
