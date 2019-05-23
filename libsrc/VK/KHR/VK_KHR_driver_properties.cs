using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_driver_properties = "VK_KHR_driver_properties";
   };
   
   public static partial class VK
   {
      const UInt32 MAX_DRIVER_NAME_SIZE_KHR = 256;
      const UInt32 MAX_DRIVER_INFO_SIZE_KHR = 256;

      //no handles


      #region enums
      public enum DriverIdKHR : int
      {  
         AmdProprietaryKhr = 1,
         AmdOpenSourceKhr = 2,
         MesaRadvKhr = 3,
         NvidiaProprietaryKhr = 4,
         IntelProprietaryWindowsKhr = 5,
         IntelOpenSourceMesaKhr = 6,
         ImaginationProprietaryKhr = 7,
         QualcommProprietaryKhr = 8,
         ArmProprietaryKhr = 9,
         GooglePastelKhr = 10,
         GgpProprietaryKhr = 11,
      };
      
      #endregion

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct ConformanceVersionKHR 
      {
         public byte major;          
         public byte minor;          
         public byte subminor;          
         public byte patch;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceDriverPropertiesKHR 
      {
         public StructureType type;          
         public IntPtr next;          
         public DriverIdKHR driverID;          
         public fixed char driverName[(int)VK.MAX_DRIVER_NAME_SIZE_KHR];          
         public fixed char driverInfo[(int)VK.MAX_DRIVER_INFO_SIZE_KHR];          
         public ConformanceVersionKHR conformanceVersion;          
      };
      
      
      #endregion

      //no functions
   }
}
