function sanitizeEnumName(name, filter)
   local n = string.gsub(name, "VK_", "")
   
   --remove any extension tags from enum
   for i,t in pairs(tags) do
      local tagLength = t:len()
      local loc = string.find(n, t, -tagLength)
      if(loc ~= nil and loc ~= 1) then
         n = string.sub(n, 1, loc-2)
         
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

function sanitizeFunctionName(name)
   local n = string.gsub(name, "vk", "") --remove beginning vk
   
   n = string.gsub(n, "^%l", string.lower)
   
   return n
end

function sanitizeTypeName(name)
   local n = string.gsub(name, "Vk", "") --remove beginning vk   
   
   return n
end

function sanitizeType(name)
   local n = string.gsub(name, "Vk", "") --remove beginning vk   
   n = string.gsub(n, "const ", "")
   n = string.gsub(n, "void %*", "IntPtr")
   n = string.gsub(n, "uint32_t", "UInt32")
   n = string.gsub(n, "int32_t", "Int32")
      
   return n

end