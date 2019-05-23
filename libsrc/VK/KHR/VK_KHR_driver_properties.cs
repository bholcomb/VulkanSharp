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
      public struct PhysicalDeviceDriverPropertiesKHR 
      {
         public StructureType sType;
         public void pNext;
         public DriverIdKHR driverID;
         public char driverName;
         public char driverInfo;
         public ConformanceVersionKHR conformanceVersion;
      };
      
      #endregion

      //no functions
   }
}
