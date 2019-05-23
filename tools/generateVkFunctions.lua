dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")

func = [[
{{local csparams = ""
  local cparams = ""
  for k,v in pairs(f.params) do
    if(v.pointer == true) then
      cparams = cparams..v.type.."* "..v.name
      csparams = csparams.."ref "..sanitizeType(v.type).." "..sanitizeTypeName(v.name)
    else
      cparams = cparams..v.type.." "..v.name
      csparams = csparams..sanitizeType(v.type).." "..sanitizeTypeName(v.name)
    end
    
    if(k < #f.params) then 
      cparams = cparams..", " 
      csparams = csparams..", "
    end 
  end}}
      //{{= f.returnType}} {{= f.name}}({{= cparams}});
      [DllImport(VulkanLibrary, EntryPoint = "{{= f.name}}", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern {{= sanitizeType(f.returnType)}} {{= sanitizeFunctionName(f.name)}}({{= csparams}});
]]

file=[[
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class VK
   {
      {{local currentGroup = ""
        local newGroup = false
        for k,v in pairs(api.commands) do
          local c = commands[v]}}
      {{if (currentGroup ~= "" and currentGroup ~= c.group) then}}
      #endregion
      {{end}}

      {{if currentGroup ~= c.group then 
         currentGroup = c.group}}
      #region {{= currentGroup}}
      {{end}}
{{= liluat.render(templates.func, {f=c, sanitizeType = sanitizeType, sanitizeTypeName = sanitizeTypeName, sanitizeFunctionName = sanitizeFunctionName}) }}
      {{if(k == #api.commands) then }}
      #endregion
      {{end}}
      {{end}}
   }
}
]]

templates = {}
templates.func = liluat.compile(func)
templates.file = liluat.compile(file)

function generateCommands()
   local ret = templates.file
   
   local values = {
         types = types,
         api = api,
         templates = templates,
         commands = commands,
         liluat = liluat,
         sanitizeFunctionName = sanitizeFunctionName,
         sanitizeType = sanitizeType,
         sanitizeTypeName = sanitizeTypeName,
         print = print
   }
   
   local ret = liluat.render(templates.file, values)
   
   print("Writing file: functions.cs")
   local file = io.open("functions.cs", "w")
   file:write(ret)
   file:close()
end

generateCommands()