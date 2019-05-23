dofile("parseVk.lua")
dofile("vkUtil.lua")

local liluat = require("liluat")
cfunc = [[
{{local params = ""
  for k,v in pairs(f.params) do
    if(v.pointer == true) then
      params = params..v.type.."* "..v.name
    else
      params = params..v.type.." "..v.name
    end
   if(k < #f.params) then params = params..", " end 
  end}}
//{{= f.returnType}} {{= f.name}}({{= params}});]]

delegate = [[
{{local params = ""
  for k,v in pairs(f.params) do
    if(v.pointer == true) then 
      params = params.."ref "..sanitizeType(v.type).." "..sanitizeTypeName(v.name)
    else
      params = params..sanitizeType(v.type).." "..sanitizeTypeName(v.name)
    end
    if(k < #f.params) then params = params..", " end 
   end}}
public delegate {{= sanitizeType(f.returnType)}} {{= sanitizeFunctionName(f.name)}}Delegate({{= params}});]]

file = [[
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   {{if (ext.type == "instance") then}}
   public static partial class InstanceExtensions
   {
      public const string {{= ext.name}} = "{{= ext.name}}";
   };
   {{elseif (ext.type == "device") then}}
   public static partial class DeviceExtensions
   {
      public const string {{= ext.name}} = "{{= ext.name}}";
   };
   {{end}}
   
   public static partial class VK
   {
      {{if (#ext.handles > 0) then}}
      #region handles
      {{for k,v in pairs(ext.handles) do}}
      [StructLayout(LayoutKind.Sequential)] public struct {{= sanitizeTypeName(v)}} { public UInt64 native; }
      {{end}}
      #endregion 
      {{else}}
      //no handles
      {{end}}
      

      {{if(#ext.enums > 0) then }}
      #region enums
       {{for k,enumName in pairs(ext.enums) do
         local e = types.enums[enumName]
         enumName = string.gsub(enumName, "Vk", "") }}
      public enum {{= enumName}} : int
      {  
         {{for kk,vv in pairs(e.values) do 
            if(type(kk)=="number") then }}
         {{= sanitizeEnumName(vv.name, enumName)}} = {{= vv.value}},
            {{end}}
         {{end}}
      };
      
       {{end}}
      #endregion
      {{else}}
      //no enums
      {{end}}

      {{if (#ext.bitmasks > 0) then }}       
      #region flags
      {{for k,bitmaskName in pairs(ext.bitmasks) do 
         local bitmask = types.bitmasks[bitmaskName]
         bitmaskName = string.gsub(bitmaskName, "Vk", "") }}
      [Flags]
      public enum {{= bitmaskName}} : int
      {  
         {{for kk,vv in pairs(bitmask.bits) do 
            if(type(kk)=="number") then }}
         {{= sanitizeEnumName(vv.name, bitmaskName)}} = 1 << {{= vv.bitpos}},
            {{end}}
         {{end}}
      };
      
      {{end}}
      #endregion
      {{else}}
      //no bitfields
      {{end}}

      {{if (#ext.structs > 0 or #ext.unions > 0) then }}
      #region structs
      {{for k,v in pairs(ext.structs) do
        local struct = types.structs[v] }}
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct {{= sanitizeTypeName(v)}} 
      {
         {{for kk,vv in pairs(struct) do }}
         public {{= sanitizeType(vv.type) }} {{= sanitizeTypeName(vv.name)}};
         {{end }}
      };
      
      {{end}}
      {{for k,v in pairs(ext.unions) do
        local struct = types.unions[v]}}
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct {{= sanitizeTypeName(v)}} 
      {
         {{for kk,vv in pairs(struct) do }}
         public {{= sanitizeType(vv.type) }} {{= sanitizeTypeName(vv.name)}};
         {{end }}
      };
      
      {{end}}
      #endregion
      {{else}}
      //no structs
      {{end}}

      {{if (#ext.commands > 0) then}}
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
      {{if ext.type == "instance" then}}
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
      #endregion
      {{else}}
      //no functions
      {{end}}
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
         types = types,
         templates = templates,
         commands = commands,
         liluat = liluat,
         sanitizeEnumName = sanitizeEnumName,
         sanitizeFunctionName = sanitizeFunctionName,
         sanitizeType = sanitizeType,
         sanitizeTypeName = sanitizeTypeName,
         print = print
      }
      
      local ret = liluat.render(templates.file, values)
      
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