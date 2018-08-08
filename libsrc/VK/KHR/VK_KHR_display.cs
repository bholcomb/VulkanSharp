using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums

      #endregion

      #region flags
      [Flags]
      public enum DisplayPlaneAlphaFlagsKHR : int
      {
         Opaque = 0x1,
         Global = 0x2,
         PerPixel = 0x4,
         PerPixelPremultiplied = 0x8,
      }
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential)] public struct DisplayKHR { public UInt64 native; }
      [StructLayout(LayoutKind.Sequential)] public struct DisplayModeKHR { public UInt64 native; }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayPropertiesKHR
      {
         public DisplayKHR Display;

         IntPtr _DisplayName;
         public String DisplayName
         {
            get { return Marshal.PtrToStringAnsi(_DisplayName); }
         }
         public Extent2D PhysicalDimensions;
         public Extent2D PhysicalResolution;
         public SurfaceTransformFlagsKHR SupportedTransforms;
         public Bool32 PlaneReorderPossible;
         public Bool32 PersistentContent;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayModeParametersKHR
      {
         Extent2D visibleRegion;
         UInt32 refreshRate;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayModePropertiesKHR
      {
         public UInt64 DisplayMode;
         public DisplayModeParametersKHR Parameters;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayModeCreateInfoKHR
      {
         public StructureType SType;
         public IntPtr Next;
         public UInt32 Flags;
         public DisplayModeParametersKHR Parameters;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayPlaneCapabilitiesKHR
      {
         DisplayPlaneAlphaFlagsKHR supportedAlpha;
         Offset2D minSrcPosition;
         Offset2D maxSrcPosition;
         Extent2D minSrcExtent;
         Extent2D maxSrcExtent;
         Offset2D minDstPosition;
         Offset2D maxDstPosition;
         Extent2D minDstExtent;
         Extent2D maxDstExtent;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplayPlanePropertiesKHR
      {
         public DisplayKHR CurrentDisplay;
         public UInt32 CurrentStackIndex;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct DisplaySurfaceCreateInfoKHR
      {
         public VK.StructureType SType;
         public IntPtr Next;
         public UInt32 Flags;
         public DisplayModeKHR DisplayMode;
         public UInt32 PlaneIndex;
         public UInt32 PlaneStackIndex;
         public SurfaceTransformFlagsKHR Transform;
         public float GlobalAlpha;
         public DisplayPlaneAlphaFlagsKHR AlphaMode;
         public Extent2D ImageExtent;
      }
      #endregion

      #region functions
      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity]
      static extern Result _GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, DisplayPropertiesKHR[] pProperties)
      {
         fixed (DisplayPropertiesKHR* ptr = pProperties)
         {
            return _GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice, out pPropertyCount, (IntPtr)ptr);
         }
      }

      [DllImport(VulkanLibrary, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, out UInt32 pPropertyCount, DisplayPlanePropertiesKHR[] pProperties)
      {
         fixed (DisplayPlanePropertiesKHR* ptr = pProperties)
         {
            return _GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice, out pPropertyCount, (IntPtr)ptr);
         }
      }

      [DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, out UInt32 pDisplayCount, IntPtr pDisplays);
      public unsafe static Result GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, out UInt32 pDisplayCount, DisplayKHR[] pDisplays)
      {
         fixed (DisplayKHR* ptr = pDisplays)
         {
            return _GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex, out pDisplayCount, (IntPtr)ptr);
         }
      }

      [DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity]
      static extern Result _GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, out UInt32 pPropertyCount, IntPtr pProperties);
      public unsafe static Result GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, out UInt32 pPropertyCount, DisplayModePropertiesKHR[] pProperties)
      {
         fixed (DisplayModePropertiesKHR* ptr = pProperties)
         {
            return _GetDisplayModePropertiesKHR(physicalDevice, display, out pPropertyCount, (IntPtr)ptr);
         }
      }

      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, ref DisplayModeCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, out DisplayModeKHR pMode);
      public static Result CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, ref DisplayModeCreateInfoKHR pCreateInfo, out DisplayModeKHR pMode, AllocationCallbacks pAllocator = null)
      {
         return _CreateDisplayModeKHR(physicalDevice, display, ref pCreateInfo, pAllocator, out pMode);
      }

      [DllImport(VulkanLibrary, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern Result GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, out DisplayPlaneCapabilitiesKHR pCapabilities);

      [DllImport(VulkanLibrary, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static extern Result _CreateDisplayPlaneSurfaceKHR(Instance instance, ref DisplaySurfaceCreateInfoKHR pCreateInfo, AllocationCallbacks pAllocator, out SurfaceKHR pSurface);
      public static Result CreateDisplayPlaneSurfaceKHR(Instance instance, ref DisplaySurfaceCreateInfoKHR pCreateInfo, out SurfaceKHR pSurface, AllocationCallbacks pAllocator = null)
      {
         return _CreateDisplayPlaneSurfaceKHR(instance, ref pCreateInfo, pAllocator, out pSurface);
      }
   }
   #endregion

   #region interop


   #endregion
}
