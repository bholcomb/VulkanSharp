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
      {{for k,v in pairs(enums) do
         if(v.extension == nil) then
            k = string.gsub(k, "Vk", "") --remove leading Vk from all names
            local lastExtension = "Core"
      }}    
      public enum {{= k}}: int
      {  
         {{for kk,vv in pairs(v) do
            if(lastExtension ~= (vv.extension or "Core")) then
               lastExtension = (vv.extension or "Core")}}
          //{{= vv.extension}}
            {{end}}
         {{= sanitizeEnumName(vv.name, k)}} = {{= vv.value}},
         {{end}}
      };
         {{end}}
      {{end}}
      #endregion
      
      #region bitmasks
      {{for k,v in pairs(bitmasks) do 
         if(v.extension == nil) then
            k = string.gsub(k, "Vk", "") --remove leading Vk from all names
            local lastExtension = "Core"
      }}
      [Flags]
      public enum {{= k}} : int
      {  
            {{for kk,vv in pairs(v) do
               if(lastExtension ~= (vv.extension or "Core")) then
                  lastExtension = (vv.extension or "Core")}}
          //{{= vv.extension}}
               {{end}}
          {{= sanitizeEnumName(vv.name, k)}} =  1 << {{= vv.bitpos}},
            {{end}}
      };
         {{end}}
      {{end}}      
      #endregion
   }
}
]]

templates = {}
templates.file = liluat.compile(file)

function generateEnums()   
   local values = {
      enums = enums, 
      bitmasks = bitmasks, 
      sanitizeEnumName = sanitizeEnumName,
   }

   local ret = liluat.render(templates.file, values)
   
   local file = io.open("enums.cs", "w")
   file:write(ret)
   file:close()
end


generateEnums()
