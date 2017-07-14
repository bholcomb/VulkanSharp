solution "Vulkan"
   location("../")
   configurations { "Debug", "Release" }
   platforms{"x32", "x64"}
   startproject "VK"
      
  configuration { "Debug" }
    defines { "DEBUG", "TRACE"}
    symbols "On"
    optimize "Off"
 
  configuration { "Release" }
    optimize "Speed"
	
      
project "VK"
	kind "SharedLib"
	language "C#"
	location "VK"
	files{"../libsrc/VK/**.cs"}
	targetdir "../bin"
	links("System")
	namespace("VK")
   clr "Unsafe"
   
project "Test Vulkan"
	language  "C#"
	kind      "ConsoleApp"
	location "testVK"
	files     { "../libsrc/testVK/**.cs" }
	vpaths { ["*"] = "../testVK" }
	targetdir "../bin"
	links     { "System", "VK"}
	namespace("luaVK")