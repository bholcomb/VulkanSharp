using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_pci_bus_info = "VK_EXT_pci_bus_info";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevicePCIBusInfoPropertiesEXT 
      {
         public StructureType sType;
         public IntPtr pNext;
         public UInt32 pciDomain;
         public UInt32 pciBus;
         public UInt32 pciFunction;
         public UInt32 pciDevice;
      };
      
      #endregion

      #region functions
      //external functions we need to get from the device
      
      //delegate definitions
      
      //delegate instances
      #endregion

      #region interop
      #endregion
   }
}
