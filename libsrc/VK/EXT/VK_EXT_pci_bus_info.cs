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
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PhysicalDevicePCIBusInfoPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 pciDomain;          
         public UInt32 pciBus;          
         public UInt32 pciDevice;          
         public UInt32 pciFunction;          
      };
      
      
      #endregion

      //no functions
   }
}
