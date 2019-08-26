#include <iostream>

struct __declspec (dllexport) Foo
{
   int c;
   int a;
   int b;
};

struct __declspec (dllexport) Test
{
   int fcount;
   float* floatArray;
   int fooCount;
   Foo* fooArray;
};

using namespace std;

extern "C"
{
   int __declspec (dllexport) callFoo(Test* t)
   {
      cout << "fcount: " << t->fcount << endl;
      for (int i = 0; i < t->fcount; i++)
      {
         cout << "\t" << t->floatArray[i] << endl;
      }

      cout << "fooCount" << t->fooCount << endl;
      for (int i = 0; i < t->fooCount; i++)
      {
         cout << "\t" << t->fooArray[i].a << ", " << t->fooArray[i].b << ", " << t->fooArray[i].c << endl;
      }

      return 0;
   }
}