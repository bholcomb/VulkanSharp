dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")

file=[[
using System;

namespace Vulkan
{
   public static partial class VK
   {
      #region enums
      {{for k,enumName in pairs(api.enums) do
         local e = types.enums[enumName]
         local lastExtension = "Core"
         enumName = string.gsub(enumName, "Vk", "") --remove leading Vk from all names
      }}    
      public enum {{= enumName}}: int
      {  
         {{for kk,vv in pairs(e.values) do
            if(lastExtension ~= (vv.extension or "Core")) then
               lastExtension = (vv.extension or "Core")}}
          //{{= vv.extension}}
            {{end}}
         {{= sanitizeEnumName(vv.name, enumName)}} = {{= vv.value}},
         {{end}}
      };
      {{end}}
      #endregion
      
      #region bitmasks
      {{for k,name in pairs(api.bitmasks) do 
         local b = types.bitmasks[name]
         local lastExtension = "Core"
         name = string.gsub(name, "Vk", "") --remove leading Vk from all name
      }}
      [Flags]
      public enum {{= name}} : int
      {  
         {{for kk,vv in pairs(b.bits) do
             if(lastExtension ~= (vv.extension or "Core")) then
                lastExtension = (vv.extension or "Core")}}
          //{{= vv.extension}}
               {{end}}
          {{= sanitizeEnumName(vv.name, name)}} =  1 << {{= vv.bitpos}},
          {{end}}
      };
      
      {{end}}
      #endregion
   }
}
]]

templates = {}
templates.file = liluat.compile(file)

function generateEnums()   
   local values = {
      api = api, 
      types = types, 
      sanitizeEnumName = sanitizeEnumName,
   }

   local ret = liluat.render(templates.file, values)
   
   local file = io.open("enums.cs", "w")
   file:write(ret)
   file:close()
end


generateEnums()
