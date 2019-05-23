
function trim(s)
   s = s:gsub("^%s*(.-)%s*$", "%1")
   s = s:gsub("[\r\n]", "")
   return s
end

function dump(o, nb)
  if nb == nil then
    nb = 1
  end
   if type(o) == 'table' then
      local s = ''
      for i = 1, nb + 1, 1 do
        s = s .. "    "
      end
      s = '{\n'
      for k,v in pairs(o) do
         if type(k) ~= 'number' then k = '"'..k..'"' end
          for i = 1, nb, 1 do
            s = s .. "    "
          end
         s = s .. '['..k..'] = ' .. dump(v, nb + 1) .. ',\n'
      end
      for i = 1, nb, 1 do
        s = s .. "    "
      end
      return s .. '}'
   else
      return tostring(o)
   end
end

function sanitizeEnumName(name, filter)
   local n = string.gsub(name, "VK_", "")
   
   --remove any extension tags from enum
   for i,t in pairs(tags) do
      local tagLength = t:len()
      local loc = string.find(n, t, -tagLength)
      if(loc ~= nil and loc ~= 1) then
         --n = string.sub(n, 1, loc-2)
      end
   end
   
   --remove any extensions from the filter name
   for i,t in pairs(tags) do
      local tagLength = t:len()
      local loc = string.find(filter, t, -tagLength)
      if(loc ~= nil and loc ~= 1) then
         filter = string.sub(filter, 1, loc-1)
      end
   end
      
   n = string.lower(n)
   n = string.gsub(n, "^%l", string.upper)
   n = string.gsub(n, "(_)(.)", function(a,b) return string.upper(b) end )
   
   local i,j = string.find(n, filter)
   --print(n, filter, i, j)
   if(j ~= nil) then
      n = string.sub(n, j+1, -1)
   end
   
   local firstChar = string.sub(n, 1, 1)
   if(string.find(firstChar, "%d") ~= nil) then
      n = "_"..n
   end
   
   return n
end

function sanitizeArrayLength(name)
   local n = string.gsub(name, "^VK_", "(int)VK.")
   return n
end

function sanitizeFunctionName(name)
   local n = string.gsub(name, "^vk", "") --remove beginning vk
   
   n = string.gsub(n, "^%l", string.lower)
   
   return n
end

function sanitizeTypeName(name)
   local n = string.gsub(name, "^Vk", "") --remove beginning vk   
   
   return n
end

function sanitizeType(name, isPointer, isDoublePointer)
   local n = trim(name)
   if isPointer == true then
      n =  n.."*" 
  end
  
  if(isDoublePointer == true) then
     return "IntPtr"
  end

   
   n = string.gsub(n, "^Vk", "") --remove beginning vk   
   n = string.gsub(n, "^PFN_vk", "") --remove beginning function pointer prefix
   n = string.gsub(n, "const ", "")
   n = string.gsub(n, "struct ", "")
   n = string.gsub(n, "void%*", "IntPtr")
   n = string.gsub(n, "uint32_t", "UInt32")   
   n = string.gsub(n, "int32_t", "Int32")
   n = string.gsub(n, "uint64_t", "UInt64")
   n = string.gsub(n, "int64_t", "Int64")
   n = string.gsub(n, "uint8_t", "byte")
   n = string.gsub(n, "int8_t", "sbyte")
   n = string.gsub(n, "size_t", "UInt32")
   n = string.gsub(n, "char%*", "string")
   
   
   
   return trim(n)

end