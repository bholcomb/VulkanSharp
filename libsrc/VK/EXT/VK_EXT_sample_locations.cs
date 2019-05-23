using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_EXT_sample_locations = "VK_EXT_sample_locations";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SampleLocationEXT 
      {
         public float x;          
         public float y;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SampleLocationsInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SampleCountFlags sampleLocationsPerPixel;          
         public Extent2D sampleLocationGridSize;          
         public UInt32 sampleLocationsCount;          
         public SampleLocationEXT* pSampleLocations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AttachmentSampleLocationsEXT 
      {
         public UInt32 attachmentIndex;          
         public SampleLocationsInfoEXT sampleLocationsInfo;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassSampleLocationsEXT 
      {
         public UInt32 subpassIndex;          
         public SampleLocationsInfoEXT sampleLocationsInfo;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassSampleLocationsBeginInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public UInt32 attachmentInitialSampleLocationsCount;          
         public AttachmentSampleLocationsEXT* pAttachmentInitialSampleLocations;          
         public UInt32 postSubpassSampleLocationsCount;          
         public SubpassSampleLocationsEXT* pPostSubpassSampleLocations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PipelineSampleLocationsStateCreateInfoEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Bool32 sampleLocationsEnable;          
         public SampleLocationsInfoEXT sampleLocationsInfo;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct PhysicalDeviceSampleLocationsPropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public SampleCountFlags sampleLocationSampleCounts;          
         public Extent2D maxSampleLocationGridSize;          
         public fixed float sampleLocationCoordinateRange[2];          
         public UInt32 sampleLocationSubPixelBits;          
         public Bool32 variableSampleLocations;          
      };
      
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct MultisamplePropertiesEXT 
      {
         public StructureType sType;          
         public IntPtr pNext;          
         public Extent2D maxSampleLocationGridSize;          
      };
      
      
      #endregion

      #region functions
      //external functions we need to get from the device
      //void vkCmdSetSampleLocationsEXT(VkCommandBuffer commandBuffer, VkSampleLocationsInfoEXT* pSampleLocationsInfo);
      //void vkGetPhysicalDeviceMultisamplePropertiesEXT(VkPhysicalDevice physicalDevice, VkSampleCountFlags samples, VkMultisamplePropertiesEXT* pMultisampleProperties);
      
      //delegate definitions
      public delegate void CmdSetSampleLocationsEXTDelegate(CommandBuffer commandBuffer, ref SampleLocationsInfoEXT pSampleLocationsInfo);
      public delegate void GetPhysicalDeviceMultisamplePropertiesEXTDelegate(PhysicalDevice physicalDevice, SampleCountFlags samples, ref MultisamplePropertiesEXT pMultisampleProperties);
      
      //delegate instances
      public static CmdSetSampleLocationsEXTDelegate CmdSetSampleLocationsEXT;
      public static GetPhysicalDeviceMultisamplePropertiesEXTDelegate GetPhysicalDeviceMultisamplePropertiesEXT;
      #endregion

      #region interop
      public static class VK_EXT_sample_locations
      {
         public static void init(VK.Device device)
         {
            VK.CmdSetSampleLocationsEXT = ExternalFunction.getDeviceFunction<VK.CmdSetSampleLocationsEXTDelegate>(device, "vkCmdSetSampleLocationsEXT");
            VK.GetPhysicalDeviceMultisamplePropertiesEXT = ExternalFunction.getDeviceFunction<VK.GetPhysicalDeviceMultisamplePropertiesEXTDelegate>(device, "vkGetPhysicalDeviceMultisamplePropertiesEXT");
         }
      }
      #endregion
   }
}
