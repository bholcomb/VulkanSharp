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
COMMANDS
   }
}
]],
   
   commandGroup = [[
      #region CMD_GROUP

COMMANDS

      #endregion
]],
   
   command = [[
      //C_RETURN_TYPE C_FUNC_NAME(C_PARAMS);
      [DllImport(VulkanLibrary, EntryPoint = "C_FUNC_NAME", CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
      public static extern RETURN_TYPE FUNC_NAME(PARAMS);

]],
   
   param = "PARAM_TYPE PARAM_NAME"
   
}


function generateCommands()
   local ret = templates.file
   
   --build up enums
   local allCmds = ""
   
   local currentGroup = ""
   local groupCmds = ""
   
   for k,v in pairs(api.commands) do      
      if( k == 1 ) then
         currentGroup = v.group
      end
      
      if(currentGroup ~= v.group) then --end of a group
         cmdGroup = templates.commandGroup         
         cmdGroup = string.gsub(cmdGroup, "CMD_GROUP", currentGroup)
         cmdGroup = string.gsub(cmdGroup, "COMMANDS", groupCmds)         
         
         allCmds = allCmds .. cmdGroup
         
         groupCmds = ""
         currentGroup = v.group
      end
      
      local cmd = templates.command
      cmd = string.gsub(cmd, "C_RETURN_TYPE", v.returnType)
      cmd = string.gsub(cmd, "C_FUNC_NAME", v.name)
      local cparams = ""
      for kk,vv in pairs(v.params) do
         local p = templates.param
         p = string.gsub(p, "PARAM_TYPE", vv.type)
         p = string.gsub(p, "PARAM_NAME", vv.name)
         
         if(kk < #v.params) then
            p = p..", "
         end
         
         cparams = cparams..p
      end      
      
      cmd = string.gsub(cmd, "C_PARAMS", cparams)
      
      
      
      cmd = string.gsub(cmd, "FUNC_NAME", sanitizeFunctionName(v.name))
      cmd = string.gsub(cmd, "RETURN_TYPE", sanitizeTypeName(v.returnType))
      local params = ""
      for kk,vv in pairs(v.params) do
         local p = templates.param
         p = string.gsub(p, "PARAM_TYPE", sanitizeType(vv.type))
         p = string.gsub(p, "PARAM_NAME", sanitizeTypeName(vv.name))
         
         if(kk < #v.params) then
            p = p..", "
         end
         
         params = params..p
      end      
      
      cmd = string.gsub(cmd, "PARAMS", params)
      
      groupCmds = groupCmds .. cmd
   end
   
   allCmds = allCmds .. groupCmds
   
   ret = string.gsub(ret, "COMMANDS", allCmds)   
   
   local file = io.open("functions.cs", "w")
   file:write(ret)
   file:close()
end

generateCommands()