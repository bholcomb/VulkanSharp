dofile("parseVk.lua")
dofile("vkUtil.lua")

templates = {
   file=[[
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Vulkan
{
   public static partial class VK
   {
STRUCTS
   }
}
]],
   
   struct = [[
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct NAME 
      {
ATTRIBUTES         
      };

]],

   attr = "         public TYPE NAME;\n"
}

local structList = {}
function addStruct(name, parent)
   local n = string.gsub(name, "const ", "")
   local n = string.gsub(n, "*", "")
   local n = string.gsub(n, "^%s*(.-)%s*$", "%1")
   
   if(n == parent) then return end --return if it's a recursive kind of structure (struct that contains a pointer to itself)

   for k,v in pairs(structList) do
       if(v == n) then return end
   end
   
   if(structs[n] ~= nil) then
      for k,v in pairs(structs[n].fields) do
         addStruct(v.type, n) --add any referenced structs
      end
      table.insert(structList, n)
   end
end

function findApiStructs()
   for k,v in pairs(api.commands) do     
      addStruct(v.returnType)
      for kk,vv in pairs(v.params) do
         addStruct(vv.type)
      end      
   end
   
   for k,v in pairs(api.structs) do
      addStruct(v.name)
   end
end

function generateStructs()
   local ret = templates.file
   
   local allStructs = ""  
   
   for k,structName in pairs(structList) do      
      local v = structs[structName]
      local struct = templates.struct
      struct = string.gsub(struct, "NAME", sanitizeTypeName(v.name))
      
      local fields = ""
      for kk,vv in pairs(v.fields) do
         field = templates.attr
         field = string.gsub(field, "TYPE", sanitizeType(vv.type))
         field = string.gsub(field, "NAME", sanitizeTypeName(vv.name))
         fields = fields..field
      end
      struct = string.gsub(struct, "ATTRIBUTES", fields)
      
      allStructs = allStructs .. struct
   end

   ret = string.gsub(ret, "STRUCTS", allStructs)   
   
   local file = io.open("structs.cs", "w")
   file:write(ret)
   file:close()
end

findApiStructs()
generateStructs()