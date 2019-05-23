using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_GGP_frame_token = "VK_GGP_frame_token";
   };
   
   public static partial class VK
   {
      //no handles
      

      //no enums

      //no bitfields

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PresentFrameTokenGGP 
      {
         public StructureType type;          
         public IntPtr next;          
         public IntPtr/*GgpFrameToken*/ frameToken;          
      };
      
      
      #endregion

      //no functions
   }
}
