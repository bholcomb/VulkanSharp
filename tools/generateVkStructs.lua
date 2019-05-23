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
      #region enums
      {{for k,sName in pairs(api.structs) do
        local s = types.structs[sName]
        local needsUnsafe = false
        for i = 1,#s do 
          if((s[i].pointer == true and (s[i].type ~= "char" and s[i].type ~= "void")) or s[i].array == true) then 
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
         {{for i=1,#s do
           if (s[i].array == true) then }}
         public fixed {{= sanitizeType(s[i].type, s[i].pointer, s[i].doublePointer)}} {{= sanitizeTypeName(s[i].name)}}[{{= sanitizeArrayLength(s[i].arrayLength)}}]; {{if s[i].comment ~= nil then}} //{{= s[i].comment}} 
         {{else}}
         
         {{end}}
         {{else}}
         public {{= sanitizeType(s[i].type, s[i].pointer, s[i].doublePointer)}} {{= sanitizeTypeName(s[i].name)}}; {{if s[i].comment ~= nil then}} //{{= s[i].comment}} 
         {{else}}
         
         {{end}}
         {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion
      
      #region unions
      {{for k,sName in pairs(api.unions) do
        local s = types.unions[sName]
        local needsUnsafe = false
        for i = 1,#s do 
          if((s[i].pointer == true and (s[i].type ~= "char" and s[i].type ~= "void")) or s[i].array == true) then 
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
         {{for i=1,#s do
           if (s[i].array == true) then }}
         public fixed {{= sanitizeType(s[i].type, s[i].pointer)}} {{= sanitizeTypeName(s[i].name)}}[{{= sanitizeArrayLength(s[i].arrayLength)}}];  {{if s[i].comment ~= nil then}} //{{= s[i].comment}}
         {{else}}
         
         {{end}}
         {{else}}
         public {{= sanitizeType(s[i].type, s[i].pointer)}} {{= sanitizeTypeName(s[i].name)}};  {{if s[i].comment ~= nil then}} //{{= s[i].comment}} 
         {{else}}
         
         {{end}}
         {{end}}
         {{end}}
      };
      
      {{end}}
      #end region
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
   
   local file = io.open("structs.cs", "w")
   file:write(ret)
   file:close()
end

generateStructs()