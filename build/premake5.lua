--scan a directory for all the files
function findGlslFiles(directory)
   local i, t, popen = 0, {}, io.popen
   for filename in popen('dir "'..directory..'" /b'):lines() do
      if(filename:sub(-5)==".glsl") then
         i = i + 1
         t[i] = filename
         --print("Found: "..filename)
      end
   end

   return t
end

--call the code generator on the messages
function generateSpirV(directory)
   local files = findGlslFiles(directory)
   local basePath = directory
   for k,v in pairs(files) do
      local shaderFile = basePath..'/'..v
      local shaderType
      if(shaderFile:find("vs.glsl") ~= nil) then shaderType = "vert" end
      if(shaderFile:find("fs.glsl") ~= nil) then shaderType = "frag" end
      if(shaderFile:find("gs.glsl") ~= nil) then shaderType = "geom" end
      if(shaderFile:find("cs.glsl") ~= nil) then shaderType = "comp" end
      
      
      local cmd=_WORKING_DIR..'/../bin/glslangValidator.exe -V '..shaderFile.." -S "..shaderType.." -o " ..shaderFile..".spv"
      --print("Executing: "..cmd)
      os.execute(cmd)
   end
end

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
	
  configuration { "**.glsl" }
      buildmessage 'Compiling %{file.relpath}'
      buildcommands {'../bin/glslangValidator.exe -V {file.basename}.glsl" '}
      buildoutputs { '{file.basename}.spv' }

  configuration { "**.spv" }
      buildaction "Embed"      
      
   configuration { "**.png" }
      buildaction "Embed"
      
project "VK"
	kind "SharedLib"
	language "C#"
	location "VK"
	files{"../libsrc/VK/**.cs"}
	targetdir "../bin"
	links("System")
	namespace("Vulkan")
    clr "Unsafe"
    framework("4.7.2")

project "Test Vulkan"
   generateSpirV("../libsrc/testVK/shaders")
	language  "C#"
	kind "ConsoleApp"
	location "testVK"
	files     { "../libsrc/testVK/**.cs", "../libsrc/testVK/shaders/**.glsl", "../libsrc/testVK/shaders/**.spv"}
	vpaths { ["*"] = "../testVK" }
	targetdir "../bin"
	links     { "System", "VK", "System.Windows", "System.Windows.Forms", "System.Drawing", "System.Numerics"}
	namespace("VulkanTest")
    framework("4.7.2")

   