using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_NN_vi_surface = "VK_NN_vi_surface";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

       
      #region flags
      [Flags]
      public enum ViSurfaceCreateFlagsNN : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ViSurfaceCreateInfoNN 
      {
         public StructureType type;          
         public IntPtr next;          
         public ViSurfaceCreateFlagsNN flags;          
         public IntPtr window;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkCreateViSurfaceNN(VkInstance instance, VkViSurfaceCreateInfoNN* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result CreateViSurfaceNNDelegate(Instance instance, ref ViSurfaceCreateInfoNN pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static CreateViSurfaceNNDelegate CreateViSurfaceNN;
      #endregion

      #region interop
      public static class NN_vi_surface
      {
         public static void init(VK.Instance instance)
         {
            VK.CreateViSurfaceNN = ExternalFunction.getInstanceFunction<VK.CreateViSurfaceNNDelegate>(instance, "vkCreateViSurfaceNN");
         }
      }
      #endregion
   }
}
