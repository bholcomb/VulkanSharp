using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_android_surface = "VK_KHR_android_surface";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum AndroidSurfaceCreateFlagsKHR : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct AndroidSurfaceCreateInfoKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public AndroidSurfaceCreateFlagsKHR flags;          
         public IntPtr/*ANativeWindow**/ window;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateAndroidSurfaceKHR(VkInstance instance, VkAndroidSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateAndroidSurfaceKHRDelegate(Instance instance, ref AndroidSurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateAndroidSurfaceKHRDelegate CreateAndroidSurfaceKHR;
      #endregion

      #region interop
      public static class VK_KHR_android_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateAndroidSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateAndroidSurfaceKHRDelegate>(instance, "vkCreateAndroidSurfaceKHR");
         }
      }
      #endregion
   }
}
