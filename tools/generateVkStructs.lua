dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")

file=[[
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Vulkan
{
   public static partial class VK
   {
      #region structs
      {{for k,sName in pairs(api.structs) do
        local struct = types.structs[sName]
        local needsUnsafe = false
        for i = 1,#struct.members do 
          local m = struct.members[i]
          if((m.pointer == true and (m.type ~= "char" and m.type ~= "void")) or m.array == true) then 
             needsUnsafe = true
          end
        end }}
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      {{if (needsUnsafe == true ) then }}
      public unsafe struct {{= sanitizeTypeName(sName)}} 
      {{else}}
      public struct {{= sanitizeTypeName(sName)}} 
      {{end}}
      {
          {{for i=1,#struct.members do
            local m = struct.members[i]
            if (m.array == true) then }}
         public fixed {{= sanitizeType(m.type, m.pointer, m.doublePointer)}} {{= sanitizeTypeName(m.name)}}[{{= sanitizeArrayLength(m.arrayLength)}}]; {{if m.comment ~= nil then}} //{{= m.comment}} 
         {{else}}
         
         {{end}}
         {{else}}
         public {{= sanitizeType(m.type, m.pointer, m.doublePointer)}} {{= sanitizeTypeName(m.name)}}; {{if m.comment ~= nil then}} //{{= m.comment}} 
         {{else}}
         
         {{end}}
         {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion
      
      #region unions
      {{for k,sName in pairs(api.unions) do
        local struct = types.unions[sName]
        local needsUnsafe = false
        for i = 1,#struct.members do 
          local m = struct.members[i]
          if((m.pointer == true and (m.type ~= "char" and m.type ~= "void")) or m.array == true) then 
             needsUnsafe = true
          end
        end }}
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      {{if (needsUnsafe == true ) then }}
      public unsafe struct {{= sanitizeTypeName(sName)}} 
      {{else}}
      public struct {{= sanitizeTypeName(sName)}} 
      {{end}}
      {
         {{for i=1,#struct.members do
            local m = struct.members[i]
            if (m.array == true) then }}
         public fixed {{= sanitizeType(m.type, m.pointer)}} {{= sanitizeTypeName(m.name)}}[{{= sanitizeArrayLength(m.arrayLength)}}];  {{if m.comment ~= nil then}} //{{= m.comment}}
         {{else}}
         
         {{end}}
         {{else}}
         public {{= sanitizeType(m.type, m.pointer)}} {{= sanitizeTypeName(m.name)}};  {{if m.comment ~= nil then}} //{{= m.comment}} 
         {{else}}
         
         {{end}}
         {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion
   }
}
]]

templates = {}
templates.file = liluat.compile(file)

function generateStructs()
   local values = {
      api = api, 
      types = types, 
      sanitizeTypeName = sanitizeTypeName,
      sanitizeType = sanitizeType,
      sanitizeArrayLength = sanitizeArrayLength,
      print = print
   }

   local ret = liluat.render(templates.file, values)
   
   print("Writing file: structs.cs")
   local file = io.open("structs.cs", "w")
   file:write(ret)
   file:close()
end

generateStructs()