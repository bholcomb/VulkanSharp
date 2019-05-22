dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")


cfunc = [[
{{local params = ""
  for k,v in pairs(f.params) do}}
{{   params = params..v.type.." "..v.name}}
{{   if(k < #f.params) then params = params..", " end 
  end}}
//{{= f.returnType}} {{= f.name}}({{= params}});]]

delegate = [[
{{local params = ""
  for k,v in pairs(f.params) do }}
{{   params = params..sanitizeType(v.type).." "..sanitizeTypeName(v.name)}}
{{   if(k < #f.params) then params = params..", " end 
   end}}
public delegate {{= sanitizeType(f.returnType)}} {{= sanitizeFunctionName(f.name)}}Delegate({{= params}}s);]]

file = [[
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   {{if ext.type == "instance" then}}
   public static partial class InstanceExtensions
   {
      public const string {{= ext.name}} = "{{= ext.name}}";
   };
   {{elseif ext.type == "device" then}}
   public static partial class DeviceExtensions
   {
      public const string {{= ext.name}} = "{{= ext.name}}";
   };
   {{end}}
   
   public static partial class VK
   {
      #region enums
      {{for k,v in pairs(ext.enums) do }}
         {{local enum = enums[v]}}
         {{local enumFilter = string.gsub(v, "Vk", "") }}
      public enum {{= enumFilter}} : int
      {  
         {{for kk,vv in pairs(enum) do 
            if(type(kk)=="number") then }}
         {{= sanitizeEnumName(vv.name, enumFilter)}} = {{= vv.value}},
            {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion

      #region flags
      {{for k,v in pairs(ext.bitmasks) do }}
      {{local bitmask = bitmasks[v]}}
      {{local bitmaskFilter = string.gsub(k, "Vk", "") }}
      [Flags]
      public enum {{= bitmaskFilter}} : int
      {  
         {{for kk,vv in pairs(bitmask) do 
            if(type(kk)=="number") then }}
         {{= sanitizeEnumName(vv.name,bitmaskFilter)}} = 1 << {{= vv.bitpos}},
            {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion

      #region structs
      {{for k,v in pairs(ext.structs) do }}
      {{local struct = structs[v]}}
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct {{= sanitizeTypeName(struct.name)}} 
      {
         {{for kk,vv in pairs(struct.fields) do }}
         public {{= sanitizeType(vv.type) }} {{= sanitizeTypeName(vv.name)}};
         {{end }}
      };
      
      {{end}}
      #endregion

      #region functions
      //external functions we need to get from the {{= ext.type}}
      {{for k,v in pairs(ext.commands) do
         local f = commands[v] }}
      {{= liluat.render(templates.cfunc, {f=f, sanitizeType = sanitizeType, sanitizeTypeName = sanitizeTypeName}) }}
      {{end}}
      
      //delegate definitions
      {{for k,v in pairs(ext.commands) do
         local f = commands[v] }}
      {{= liluat.render(templates.delegate, {f=f, sanitizeType = sanitizeType, sanitizeTypeName = sanitizeTypeName, sanitizeFunctionName = sanitizeFunctionName}) }}
      {{end}}
      
      //delegate instances
      {{for k,v in pairs(ext.commands) do
         local f = commands[v] }}
      public static {{= sanitizeFunctionName(f.name)}}Delegate {{= sanitizeFunctionName(f.name)}};
      {{end}}
      #endregion

      #region interop
      {{if(#ext.commands > 0 ) then 
         if ext.type == "instance" then}}
      public static class {{= ext.name}}
      {
         public static void init(VK.Instance instance)
         {
            {{for k,v in pairs(ext.commands) do
               local f = commands[v] }}
            VK.{{= sanitizeFunctionName(f.name)}} = ExternalFunction.getInstanceFunction<VK.{{= sanitizeFunctionName(f.name)}}Delegate>(instance, "{{= f.name}}");
            {{end}}
         }
      }
      {{elseif ext.type == "device" then}}
      public static class {{= ext.name}}
      {
         public static void init(VK.Device device)
         {
            {{for k,v in pairs(ext.commands) do
               local f = commands[v] }}
            VK.{{= sanitizeFunctionName(f.name)}} = ExternalFunction.getDeviceFunction<VK.{{= sanitizeFunctionName(f.name)}}Delegate>(device, "{{= f.name}}");
            {{end}}
         }
      }
         {{end}}
      {{end}}
      #endregion
   }
}
]]

templates = {}
templates.delegate = liluat.compile(delegate)
templates.cfunc = liluat.compile(cfunc)
templates.file = liluat.compile(file)

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

function generateExtensions()
   for k,v in pairs(extensions) do
      local values = {
         ext = v, 
         enums = enums, 
         bitmasks = bitmasks, 
         commands = commands,
         structs = structs,
         templates = templates,
         liluat = liluat,
         sanitizeEnumName = sanitizeEnumName,
         sanitizeFunctionName = sanitizeFunctionName,
         sanitizeType = sanitizeType,
         sanitizeTypeName = sanitizeTypeName,
         print = print
      }
      
      local ret = liluat.render(templates.file, values, {reference = true})
      
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