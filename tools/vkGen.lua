dofile("xmlParser.lua")

function dump(o, nb)
  if nb == nil then
    nb = 0
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

local tree=XmlParser:ParseXmlFile("vk.xml")
tags = {}

function sanitizeName(name)
   local n = string.gsub(name, "VK_STRUCTURE_TYPE_", "")
      
   n = string.lower(n)
   
   for i,t in pairs(tags) do
      local tagLength = t:len()
      local loc = string.find(n, string.lower(t), -tagLength)
      if(loc ~= nil and loc ~= 1) then
         n = string.sub(n, 1, loc-1)..t
      end
   end
   
   n = string.gsub(n, "^%l", string.upper)
   n = string.gsub(n, "(_)(.)", function(a,b) return string.upper(b) end )
   
   return n
end


--find valid tags
for i,node in pairs(tree.ChildNodes) do
   if(node.Name == "tags") then
      for i,tag in pairs(node.ChildNodes) do
         table.insert(tags, tag.Attributes.name)
      end
   end
end

function findEnumExtensions(t, enumType)
   for i,node in pairs(t.ChildNodes) do
      if(node.Name == "extensions") then
         for i,ext in pairs(node.ChildNodes) do
            if(ext.Name == "extension" and ext.Attributes.supported ~= "disabled") then
               --if(ext.Attributes.name == "VK_KHR_swapchain") then print(dump(ext)) end
               
               print("//"..ext.Attributes.name)
               local num = ext.Attributes.number - 1
               local name = ext.Attributes.name
               local baseVal = 1000000000 + (num * 1000)
               
               for i,req in pairs(ext.ChildNodes) do            
                  for i, field in pairs(req.ChildNodes) do
                     if(field.Name == "enum" and field.Attributes.extends == enumType and field.Attributes.offset ~= nil) then
                        local offset = tonumber(field.Attributes.offset)
                        local name = sanitizeName(field.Attributes.name)
                        print(name.."="..string.format("%d", baseVal+offset)..",")
                     end
                  end
               end
            end
         end
      end
   end
end

--findEnumExtensions(tree, "VkResult")
--findEnumExtensions(tree, "VkStructureType")
--findEnumExtensions(tree, "VkFormat")
--findEnumExtensions(tree, "VkImageLayout")
--findEnumExtensions(tree, "VkObjectType")
--findEnumExtensions(tree, "VkBlendOp")
findEnumExtensions(tree, "VkDynamicState")
