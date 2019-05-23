using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class InstanceExtensions
   {
      public const string VK_KHR_display = "VK_KHR_display";
   };
   
   public static partial class VK
   {
      #region handles
      [StructLayout(LayoutKind.Sequential)] public struct DisplayKHR { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DisplayModeKHR { public UInt64 native; }
      #endregion 
      

      //no enums

       
      #region flags
      [Flags]
      public enum DisplayPlaneAlphaFlagsKHR : int
      {  
         DisplayPlaneAlphaOpaqueBitKhr = 1 << 0,
         DisplayPlaneAlphaGlobalBitKhr = 1 << 1,
         DisplayPlaneAlphaPerPixelBitKhr = 1 << 2,
         DisplayPlaneAlphaPerPixelPremultipliedBitKhr = 1 << 3,
      };
      
      [Flags]
      public enum DisplayModeCreateFlagsKHR : int
      {  
      };
      
      [Flags]
      public enum DisplaySurfaceCreateFlagsKHR : int
      {  
      };
      
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPropertiesKHR 
      {
         public DisplayKHR display;  //Handle of the display object 
         public string displayName;  //Name of the display 
         public Extent2D physicalDimensions;  //In millimeters? 
         public Extent2D physicalResolution;  //Max resolution for CRT? 
         public SurfaceTransformFlagsKHR supportedTransforms;  //one or more bits from VkSurfaceTransformFlagsKHR 
         public Bool32 planeReorderPossible;  //VK_TRUE if the overlay plane's z-order can be changed on this display. 
         public Bool32 persistentContent;  //VK_TRUE if this is a "smart" display that supports self-refresh/internal buffering. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayModeParametersKHR 
      {
         public Extent2D visibleRegion;  //Visible scanout region. 
         public UInt32 refreshRate;  //Number of times per second the display is updated. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayModePropertiesKHR 
      {
         public DisplayModeKHR displayMode;  //Handle of this display mode. 
         public DisplayModeParametersKHR parameters;  //The parameters this mode uses. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayModeCreateInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DisplayModeCreateFlagsKHR flags;          
         public DisplayModeParametersKHR parameters;  //The parameters this mode uses. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPlaneCapabilitiesKHR 
      {
         public DisplayPlaneAlphaFlagsKHR supportedAlpha;  //Types of alpha blending supported, if any. 
         public Offset2D minSrcPosition;  //Does the plane have any position and extent restrictions? 
         public Offset2D maxSrcPosition;          
         public Extent2D minSrcExtent;          
         public Extent2D maxSrcExtent;          
         public Offset2D minDstPosition;          
         public Offset2D maxDstPosition;          
         public Extent2D minDstExtent;          
         public Extent2D maxDstExtent;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplayPlanePropertiesKHR 
      {
         public DisplayKHR currentDisplay;  //Display the plane is currently associated with.  Will be VK_NULL_HANDLE if the plane is not in use. 
         public UInt32 currentStackIndex;  //Current z-order of the plane. 
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct DisplaySurfaceCreateInfoKHR 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public DisplaySurfaceCreateFlagsKHR flags;          
         public DisplayModeKHR displayMode;  //The mode to use when displaying this surface 
         public UInt32 planeIndex;  //The plane on which this surface appears.  Must be between 0 and the value returned by vkGetPhysicalDeviceDisplayPlanePropertiesKHR() in pPropertyCount. 
         public UInt32 planeStackIndex;  //The z-order of the plane. 
         public SurfaceTransformFlagsKHR transform;  //Transform to apply to the images as part of the scanout operation 
         public float globalAlpha;  //Global alpha value.  Must be between 0 and 1, inclusive.  Ignored if alphaMode is not VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR 
         public DisplayPlaneAlphaFlagsKHR alphaMode;  //What type of alpha blending to use.  Must be a bit from vkGetDisplayPlanePropertiesKHR::supportedAlpha. 
         public Extent2D imageExtent;  //size of the images to use with this surface 
      };
      
      #endregion

      #region functions
      //external functions we need to get from the instance
      //VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkDisplayPropertiesKHR* pProperties);
      //VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties);
      //VkResult vkGetDisplayPlaneSupportedDisplaysKHR(VkPhysicalDevice physicalDevice, uint32_t planeIndex, uint32_t* pDisplayCount, VkDisplayKHR* pDisplays);
      //VkResult vkGetDisplayModePropertiesKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, uint32_t* pPropertyCount, VkDisplayModePropertiesKHR* pProperties);
      //VkResult vkCreateDisplayModeKHR(VkPhysicalDevice physicalDevice, VkDisplayKHR display, VkDisplayModeCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDisplayModeKHR* pMode);
      //VkResult vkGetDisplayPlaneCapabilitiesKHR(VkPhysicalDevice physicalDevice, VkDisplayModeKHR mode, uint32_t planeIndex, VkDisplayPlaneCapabilitiesKHR* pCapabilities);
      //VkResult vkCreateDisplayPlaneSurfaceKHR(VkInstance instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSurfaceKHR* pSurface);
      
      //delegate definitions
      public delegate Result GetPhysicalDeviceDisplayPropertiesKHRDelegate(PhysicalDevice physicalDevice, ref UInt32 pPropertyCount, ref DisplayPropertiesKHR pProperties);
      public delegate Result GetPhysicalDeviceDisplayPlanePropertiesKHRDelegate(PhysicalDevice physicalDevice, ref UInt32 pPropertyCount, ref DisplayPlanePropertiesKHR pProperties);
      public delegate Result GetDisplayPlaneSupportedDisplaysKHRDelegate(PhysicalDevice physicalDevice, UInt32 planeIndex, ref UInt32 pDisplayCount, ref DisplayKHR pDisplays);
      public delegate Result GetDisplayModePropertiesKHRDelegate(PhysicalDevice physicalDevice, DisplayKHR display, ref UInt32 pPropertyCount, ref DisplayModePropertiesKHR pProperties);
      public delegate Result CreateDisplayModeKHRDelegate(PhysicalDevice physicalDevice, DisplayKHR display, ref DisplayModeCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref DisplayModeKHR pMode);
      public delegate Result GetDisplayPlaneCapabilitiesKHRDelegate(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, ref DisplayPlaneCapabilitiesKHR pCapabilities);
      public delegate Result CreateDisplayPlaneSurfaceKHRDelegate(Instance instance, ref DisplaySurfaceCreateInfoKHR pCreateInfo, ref AllocationCallbacks pAllocator, ref SurfaceKHR pSurface);
      
      //delegate instances
      public static GetPhysicalDeviceDisplayPropertiesKHRDelegate GetPhysicalDeviceDisplayPropertiesKHR;
      public static GetPhysicalDeviceDisplayPlanePropertiesKHRDelegate GetPhysicalDeviceDisplayPlanePropertiesKHR;
      public static GetDisplayPlaneSupportedDisplaysKHRDelegate GetDisplayPlaneSupportedDisplaysKHR;
      public static GetDisplayModePropertiesKHRDelegate GetDisplayModePropertiesKHR;
      public static CreateDisplayModeKHRDelegate CreateDisplayModeKHR;
      public static GetDisplayPlaneCapabilitiesKHRDelegate GetDisplayPlaneCapabilitiesKHR;
      public static CreateDisplayPlaneSurfaceKHRDelegate CreateDisplayPlaneSurfaceKHR;
      #endregion

      #region interop
      public static class VK_KHR_display
      {
         public static void init(VK.Instance instance)
         {
            VK.GetPhysicalDeviceDisplayPropertiesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceDisplayPropertiesKHRDelegate>(instance, "vkGetPhysicalDeviceDisplayPropertiesKHR");
            VK.GetPhysicalDeviceDisplayPlanePropertiesKHR = ExternalFunction.getInstanceFunction<VK.GetPhysicalDeviceDisplayPlanePropertiesKHRDelegate>(instance, "vkGetPhysicalDeviceDisplayPlanePropertiesKHR");
            VK.GetDisplayPlaneSupportedDisplaysKHR = ExternalFunction.getInstanceFunction<VK.GetDisplayPlaneSupportedDisplaysKHRDelegate>(instance, "vkGetDisplayPlaneSupportedDisplaysKHR");
            VK.GetDisplayModePropertiesKHR = ExternalFunction.getInstanceFunction<VK.GetDisplayModePropertiesKHRDelegate>(instance, "vkGetDisplayModePropertiesKHR");
            VK.CreateDisplayModeKHR = ExternalFunction.getInstanceFunction<VK.CreateDisplayModeKHRDelegate>(instance, "vkCreateDisplayModeKHR");
            VK.GetDisplayPlaneCapabilitiesKHR = ExternalFunction.getInstanceFunction<VK.GetDisplayPlaneCapabilitiesKHRDelegate>(instance, "vkGetDisplayPlaneCapabilitiesKHR");
            VK.CreateDisplayPlaneSurfaceKHR = ExternalFunction.getInstanceFunction<VK.CreateDisplayPlaneSurfaceKHRDelegate>(instance, "vkCreateDisplayPlaneSurfaceKHR");
         }
      }
      #endregion
   }
}
