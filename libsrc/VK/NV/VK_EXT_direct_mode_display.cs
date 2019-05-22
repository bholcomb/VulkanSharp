using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_EXT_direct_mode_display = "VK_EXT_direct_mode_display";
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
      //VkResult vkReleaseDisplayEXT(VkPhysicalDevice  physicalDevice, VkDisplayKHR  display);
      
      //delegate definitions
      public delegate Result ReleaseDisplayEXTDelegate(PhysicalDevice physicalDevice, DisplayKHR displays);
      
      //delegate instances
      public static ReleaseDisplayEXTDelegate ReleaseDisplayEXT;
      #endregion

      #region interop
      public static class EXT_direct_mode_display
      {
         public static void init(VK.Instance instance)
         {
            VK.ReleaseDisplayEXT = ExternalFunction.getInstanceFunction<VK.ReleaseDisplayEXTDelegate>(instance, "vkReleaseDisplayEXT");
         }
      }
      #endregion
   }
}
