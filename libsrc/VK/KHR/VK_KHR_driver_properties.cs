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
      const int MAX_DRIVER_NAME_SIZE_KHR = 256;
      const int MAX_DRIVER_INFO_SIZE_KHR = 256;

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

      #region flags
      #endregion

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
         public StructureType sType;
         public IntPtr pNext;
         public DriverIdKHR driverID;
         fixed byte _driverName[(int)VK.MAX_DRIVER_NAME_SIZE_KHR];
         public ConformanceVersionKHR conformanceVersion;
         fixed byte _driverInfo[(int)VK.MAX_DRIVER_INFO_SIZE_KHR];

         public string driverName
         {
            get
            {
               fixed (byte* p = _driverName)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }

         public string driverInfo
         {
            get
            {
               fixed (byte* p = _driverInfo)
               {
                  return Marshal.PtrToStringAnsi((IntPtr)p);
               }
            }
         }
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
