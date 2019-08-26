using System;
using System.Runtime.InteropServices;
using System.Security;

namespace TestMarshall
{
   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct Foo
   {
      public UInt32 a;
      public UInt32 b;
      public UInt32 c;
   };


   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct Test
   {
      public UInt32 fCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeParamIndex = 0)]
      public float[] floats;
      public UInt32 fooCount;
      [MarshalAs(UnmanagedType.ByValArray, SizeParamIndex = 2)]
      public Foo[] foos;
   };

   static class TestFoo
   {
      [DllImport("TestmarshallC.dll", EntryPoint = "callFoo", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      static unsafe extern int callFoo(ref Test t);


      static void Main(string[] args)
      {
         Test t;
         t.fCount = 3;
         t.floats = new float[3];
         t.floats[0] = 42.0f;
         t.floats[1] = 42.1f;
         t.floats[2] = 42.2f;

         t.fooCount = 3;
         t.foos = new Foo[3];
         t.foos[0].a = 1;
         t.foos[0].b = 2;
         t.foos[0].c = 3;
         t.foos[1].a = 1;
         t.foos[1].b = 2;
         t.foos[1].c = 3;
         t.foos[2].a = 1;
         t.foos[2].b = 2;
         t.foos[2].c = 3;


         TestFoo.callFoo(ref t);
      }
   }
}