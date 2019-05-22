using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_acquire_xlib_display = "VK_EXT_acquire_xlib_display";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkAcquireXlibDisplayEXT(VkPhysicalDevice  physicalDevice, Display *  dpy, VkDisplayKHR  display);
      //VkResult vkGetRandROutputDisplayEXT(VkPhysicalDevice  physicalDevice, Display *  dpy, RROutput  rrOutput, VkDisplayKHR *  pDisplay);
      
      //delegate definitions
      public delegate Result AcquireXlibDisplayEXTDelegate(PhysicalDevice physicalDevice, IntPtr dpy, DisplayKHR displays);
      public delegate Result GetRandROutputDisplayEXTDelegate(PhysicalDevice physicalDevice, IntPtr dpy, IntPtr rrOutput, ref DisplayKHR pDisplays);
      
      //delegate instances
      public static AcquireXlibDisplayEXTDelegate AcquireXlibDisplayEXT;
      public static GetRandROutputDisplayEXTDelegate GetRandROutputDisplayEXT;
      #endregion

      #region interop
      public static class VK_EXT_acquire_xlib_display
      {
         public static void init(VK.Instance instance)
         {
            VK.AcquireXlibDisplayEXT = ExternalFunction.getInstanceFunction<VK.AcquireXlibDisplayEXTDelegate>(instance, "vkAcquireXlibDisplayEXT");
            VK.GetRandROutputDisplayEXT = ExternalFunction.getInstanceFunction<VK.GetRandROutputDisplayEXTDelegate>(instance, "vkGetRandROutputDisplayEXT");
         }
      }
      #endregion
   }
}
