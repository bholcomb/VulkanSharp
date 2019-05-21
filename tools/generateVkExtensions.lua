dofile("parseVk.lua")
dofile("vkUtil.lua")

templates = {
   file=[[
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums
ENUMS
      #endregion

      #region flags
BITFLAGS
      #endregion

      #region structs
STRUCTS
      #endregion

      #region functions
FUNCTIONS
      #endregion

      #region interop

      #endregion
   }
}

]],
   
   enum = [[
   public enum ENUM_NAME : int
   {  
VALS
   };

]],
   enumVal = "      ENUM = VALUE, \n",
   
   bitmask = [[
   [Flags]
   public enum BITMASK_NAME: int
   {
VALS
   };

]],
   bitmaskVal = "      BITMASK = VALUE, \n",
   
   
      command = [[
      //C_RETURN_TYPE C_FUNC_NAME(C_PARAMS);
      [DllImport(VulkanLibrary, EntryPoint = "C_FUNC_NAME", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern RETURN_TYPE FUNC_NAME(PARAMS);

]],
   
   param = "PARAM_TYPE PARAM_NAME",
   
   struct = [[
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct NAME 
      {
ATTRIBUTES         
      };

]],

   attr = "         public TYPE NAME;\n"
}

function directoryExists(path)
   local ok, err, code = os.rename(path, path)
   if not ok then
      if code == 13 then
         -- Permission denied, but it exists
         return true
      end
   end
   
   return false
end

function genEnums(ret, ext)
   local allEnums = ""
   for k,enumName in pairs(ext.enums) do 
      local e = enums[enumName]
      local anEnum = templates.enum
      enumName = string.gsub(enumName, "Vk", "") --remove leading Vk from all names
      anEnum = string.gsub(anEnum, "ENUM_NAME", enumName)
      local allVals = ""
      for kk,vv in pairs(e) do
         if(type(kk) == "number") then
            local valueStr = templates.enumVal
            valueStr = string.gsub(valueStr, "ENUM", sanitizeEnumName(vv.name, enumName))
            valueStr = string.gsub(valueStr, "VALUE", vv.value)
            
            allVals = allVals .. valueStr
         end
      end
      anEnum = string.gsub(anEnum, "VALS", allVals)
      
      allEnums = allEnums..anEnum
   end
   
   ret = string.gsub(ret, "ENUMS", allEnums)
   
   return ret
end

function genBitfields(ret, ext)
   local allBitmasks = ""
   for k,bitName in pairs(ext.bitmasks) do 
      local b = bitmasks[bitName]
      local aBitmask = templates.bitmask
      bitName = string.gsub(bitName, "Vk", "") --remove leading Vk from all names
      aBitmask = string.gsub(aBitmask, "BITMASK_NAME", bitName)
      local allVals = ""
      for kk,vv in pairs(b) do
         if(type(kk) == "number") then 
            local valueStr = templates.bitmaskVal
            local fs, fe = string.find(bitName, "Flag")
            local filterName = string.sub(bitName, 1, fs-1)
            valueStr = string.gsub(valueStr, "BITMASK", sanitizeEnumName(vv.name, filterName))
            valueStr = string.gsub(valueStr, "VALUE", ("1 << "..vv.bitpos))
            
            allVals = allVals .. valueStr
         end
      end
      aBitmask = string.gsub(aBitmask, "VALS", allVals)
      
      allBitmasks = allBitmasks..aBitmask
   end
   
   ret = string.gsub(ret, "BITFLAGS", allBitmasks)--build up enums
   
   return ret
end

function genStructs(ret, ext)
   local allStructs = ""  
   
   for k,structName in pairs(ext.structs) do 
      local s = structs[structName]
      local struct = templates.struct
      struct = string.gsub(struct, "NAME", sanitizeTypeName(s.name))
      
      local fields = ""
      for kk,vv in pairs(s.fields) do
         if(vv.name ~= nil) then
            field = templates.attr
            field = string.gsub(field, "TYPE", sanitizeType(vv.type))
            field = string.gsub(field, "NAME", sanitizeTypeName(vv.name))
            fields = fields..field
         end
      end
      struct = string.gsub(struct, "ATTRIBUTES", fields)
      
      allStructs = allStructs .. struct
   end
  
   
   ret = string.gsub(ret, "STRUCTS", allStructs)
   
   return ret
end

function genFuncs(ret, ext)
   local allFuncs = ""  
   
   for k,cmdName in pairs(ext.commands) do  
      local f = commands[cmdName]
      local cmd = templates.command
      cmd = string.gsub(cmd, "C_RETURN_TYPE", f.returnType)
      cmd = string.gsub(cmd, "C_FUNC_NAME", f.name)
      local cparams = ""
      for kk,vv in pairs(f.params) do
         local p = templates.param
         p = string.gsub(p, "PARAM_TYPE", vv.type)
         p = string.gsub(p, "PARAM_NAME", vv.name)
         
         if(kk < #f.params) then
            p = p..", "
         end
         
         cparams = cparams..p
      end      
      
      cmd = string.gsub(cmd, "C_PARAMS", cparams)
      
      
      
      cmd = string.gsub(cmd, "FUNC_NAME", sanitizeFunctionName(f.name))
      cmd = string.gsub(cmd, "RETURN_TYPE", sanitizeTypeName(f.returnType))
      local params = ""
      for kk,vv in pairs(f.params) do
         local p = templates.param
         p = string.gsub(p, "PARAM_TYPE", sanitizeType(vv.type))
         p = string.gsub(p, "PARAM_NAME", sanitizeTypeName(vv.name))
         
         if(kk < #f.params) then
            p = p..", "
         end
         
         params = params..p
      end      
      
      cmd = string.gsub(cmd, "PARAMS", params)
      
      allFuncs = allFuncs .. cmd
   end
   
   ret = string.gsub(ret, "FUNCTIONS", allFuncs) 
   
   return ret
end

function generateExtensions()
   for k,v in pairs(extensions) do
      local ret = templates.file
      
      ret = genEnums(ret, v)
      ret = genBitfields(ret, v)
      ret = genStructs(ret, v)
      ret = genFuncs(ret, v)
      
      if(v.author == nil) then v.author = "KHR" end
     
      if(directoryExists(v.author) == false) then
         os.execute("mkdir "..v.author)
      end
      local filename = v.author.."/"..v.name..".cs"
      print("Writing file: ".. filename)
      local file = io.open(filename, "w")
      file:write(ret)
      file:close()
   end
end

generateExtensions()