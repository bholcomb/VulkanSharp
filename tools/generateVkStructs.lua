dofile("parseVk.lua")
dofile("vkUtil.lua")

templates = {
   file=[[
using System;
USING

namespace Vulkan
{
   public static partical class VK
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


function generateStructs()
   local ret = templates.file
   
   local allStructs = ""  
   
   for k,v in pairs(api.structs) do      
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

generateStructs()