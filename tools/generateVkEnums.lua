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
      #region enums
ENUMS
      #endregion
      
      #region bitmasks
BITMASKS
      #endregion
   }
}
   ]],
   enum = [[
   public enum ENUM_NAME : int
   {  
VALS
   };

]],
   enumVal = "      ENUM = VALUE, \n",
   
   bitmask = [[
   [Flags]
   public enum BITMASK_NAME: int
   {
VALS
   };

]],
   bitmaskVal = "      BITMASK = VALUE, \n",
}

function generateEnums()
   local ret = templates.file
   
   --build up enums
   local allEnums = ""
   for k,v in pairs(enums) do 
      if(v.extension == nil) then
         local anEnum = templates.enum
         k = string.gsub(k, "Vk", "") --remove leading Vk from all names
         anEnum = string.gsub(anEnum, "ENUM_NAME", k)
         local allVals = ""
         local lastExtension = "Core"
         for kk,vv in pairs(v) do
            local valueStr = templates.enumVal
            valueStr = string.gsub(valueStr, "ENUM", sanitizeEnumName(vv.name, k))
            valueStr = string.gsub(valueStr, "VALUE", vv.value)
            
            if(lastExtension ~= (vv.extension or "Core")) then
               lastExtension = (vv.extension or "Core")
               allVals = allVals.."      //"..vv.extension.."\n"
            end
            
            allVals = allVals .. valueStr
         end
         anEnum = string.gsub(anEnum, "VALS", allVals)
         
         allEnums = allEnums..anEnum
      end
   end
   
   ret = string.gsub(ret, "ENUMS", allEnums)
   
   --build up bitmasks
   local allBitmasks = ""
   for k,v in pairs(bitmasks) do 
      if(v.extension == nil) then
         local aBitmask = templates.bitmask
         k = string.gsub(k, "Vk", "") --remove leading Vk from all names
         aBitmask = string.gsub(aBitmask, "BITMASK_NAME", k)
         local allVals = ""
         local lastExtension = "Core"
         for kk,vv in pairs(v) do
            local valueStr = templates.bitmaskVal
            local fs, fe = string.find(k, "Flag")
            local filterName = string.sub(k, 1, fs-1)
            --print(vv.name, filterName)
            valueStr = string.gsub(valueStr, "BITMASK", sanitizeEnumName(vv.name, filterName))
            valueStr = string.gsub(valueStr, "VALUE", ("1 << "..vv.bitpos))
            
            if(lastExtension ~= (vv.extension or "Core")) then
               lastExtension = (vv.extension or "Core")
               allVals = allVals.."      //"..vv.extension.."\n"
            end
            
            allVals = allVals .. valueStr
         end
         aBitmask = string.gsub(aBitmask, "VALS", allVals)
         
         allBitmasks = allBitmasks..aBitmask
      end
   end
   
   ret = string.gsub(ret, "BITMASKS", allBitmasks)--build up enums
   
   local file = io.open("enums.cs", "w")
   file:write(ret)
   file:close()
end


generateEnums()


