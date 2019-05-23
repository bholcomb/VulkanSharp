dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")

file=[[
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Vulkan
{
   public static partial class VK
   {
      #region handles
      {{for k,v in pairs(api.handles) do
         local h = types.handles[v]
         if(h.type == "VK_DEFINE_HANDLE") then }}
      [StructLayout(LayoutKind.Sequential)] public struct {{= sanitizeTypeName(v)}} { public IntPtr native; }
         {{else}}
      [StructLayout(LayoutKind.Sequential)] public struct {{= sanitizeTypeName(v)}} { public UInt64 native; }
         {{end}}
      {{end}}
      #endregion 
   }
}
]]

templates = {}
templates.file = liluat.compile(file)

function generateVkHandles()
   local ret = templates.file
   
   local values = {
         types = types,
         api = api,
         sanitizeType = sanitizeType,
         sanitizeTypeName = sanitizeTypeName,
         print = print
   }
   
   local ret = liluat.render(templates.file, values)
   
   print("Writing file: handles.cs")
   local file = io.open("handles.cs", "w")
   file:write(ret)
   file:close()
end

generateVkHandles()