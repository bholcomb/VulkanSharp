using System;
using System.Runtime.InteropServices;
using System.Security;

namespace TestMarshall
{
   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _ShaderModuleCreateInfo
   {
      public int type;
      public IntPtr next;
      public int flags;
      public UInt64 codeSize;
      public IntPtr code;  //Binary code of size codeSize 

      public _ShaderModuleCreateInfo(int size)
      {
         byte[] bytes = new byte[size];
         for(int i=0; i< size; i++)
         {
            bytes[i] = (byte)i;
         }

         type = 1;
         next = IntPtr.Zero;
         flags = 2;
         codeSize = 10;
         code = Marshal.AllocHGlobal(size);
         Marshal.Copy(bytes, 0, code, size);
      }

      public void destroy()
      {
         Marshal.FreeHGlobal(code);
      }
   };

   static class TestFoo
   {
      [DllImport("TestmarshallC.dll", EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static unsafe extern int vkCreateShaderModule(int device, ref _ShaderModuleCreateInfo pCreateInfo, IntPtr pAllocator, ref int pShaderModule);


      static void Main(string[] args)
      {
         int ret = 0;
         _ShaderModuleCreateInfo info = new _ShaderModuleCreateInfo(16);

         TestFoo.vkCreateShaderModule(1, ref info, IntPtr.Zero, ref ret );
      }
   }
}