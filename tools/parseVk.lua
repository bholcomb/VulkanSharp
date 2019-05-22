require ("LuaXML")

local vk = xml.load("vk.xml")

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

commands = {}
api = {}
extensions = {}
tags = {}
types = {}

function getNameTag(e)
   for k,v in pairs(e) do
      if(type(v)=="table" and v:tag() == "name") then
         return v[1]
      end
   end  
end

function getTypeTag(e)
   for k,v in pairs(e) do
      if(type(v)=="table" and v:tag() == "type") then
         local ret = v[1]
         ret = string.gsub(ret, "FlagBits", "Flags")
         return ret
      end
   end  
end

function getCommentTag(e)
   for k,v in pairs(e) do
      if(type(v)=="table" and v:tag() == "comment") then
         return v[1]
      end
   end  
end

function parseTypes()
   local t = vk:find("types")
   types.bitmasks = {}
   types.handles = {}
   types.enums = {}
   types.structs = {}
   types.unions = {}
   types.type = {}
   
   for k,v in pairs(t) do
      if(v.category == "bitmask" and v.alias == nil) then 
         local n = getNameTag(v)
         local t = getTypeTag(v)
         types.bitmasks[n] = {type = t, bits = {}}
         types.type[n] = "bitmask"
      elseif(v.category == "handle" and v.alias == nil) then
         local n = getNameTag(v)
         local t = getTypeTag(v)
         types.handles[n] = t
         types.type[n] = "handle"
      elseif(v.category == "enum" and v.alias == nil) then
         local n = v.name
         if(string.find(n, "FlagBits") == nil) then
            types.enums[n] = {values = {}}
            types.type[n] = "enum"
         end
      elseif(v.category == "funcpointer" and v.alias == nil) then
         local n = getNameTag(v)
         types.type[n] = "functionPointer"
      elseif(v.category == "union" and v.alias == nil) then
         local n = v.name
         types.type[n] = "union"
         local members = {}
         for i = 1,#v do
            local memdef = v[i]
            if(memdef:tag() == "member") then
               local member = {}
               local t = getTypeTag(memdef)
               local n = getNameTag(memdef)
               local c = getCommentTag(memdef)
               member.name = n
               member.type = t
               if(c ~= nil) then member.comment = c end
               for j = 1,#memdef do
                  if(type(memdef[j]) == "string") then 
                     local _, _, val = string.find(memdef[j], "%[(%d)%]")
                     if(val ~= nil) then
                        member.array = true
                        member.arrayLength = val
                     end
                  end
               end

               table.insert(members, member)
            end
         end
         
         types.unions[n] = members
      elseif(v.category == "struct" and v.alias == nil) then
         local n = v.name
         types.type[n] = "struct" 
         local members = {}
         for i = 1,#v do
            local memdef = v[i]
            if(memdef:tag() == "member") then
               local member = {}
               local t = getTypeTag(memdef)
               local n = getNameTag(memdef)
               local c = getCommentTag(memdef)
               member.name = n
               member.type = t
               if(c ~= nil) then member.comment = c end
               for j = 1,#memdef do
                  if(memdef[j].optional == true) then
                     member.optional = true 
                  end
                  
                  if(memdef[j] == "*") then 
                     member.pointer = true
                  elseif(memdef[j] == "const") then 
                     member.const = true
                  elseif(memdef[j] == "[") then 
                     member.array = true
                     member.arrayLength = memdef[j + 1][1]
                  elseif(type(memdef[j]) == "string") then 
                     local _, _, val = string.find(memdef[j], "%[(%d)%]")
                     if(val ~= nil) then
                        member.array = true
                        member.arrayLength = val
                     end
                  end
               end

               table.insert(members, member)
            end
         end
         
         types.structs[n] = members
      end
   end
end

function parseTags()
   local t = vk:find("tags")
   for k,v in pairs(t) do 
      if(type(v)=="table" and v:tag() == "tag") then
         table.insert(tags, v.name)
      end
   end
end

function parseCommands()
   local vkCmds = vk:find("commands")
   for k,vkCmd in ipairs(vkCmds) do
      if(vkCmd.alias == nil) then
         local cmd = {}
         cmd.params = {}
         for k,v in ipairs(vkCmd) do
            if (v:tag() == "proto") then
               cmd.name = v:find("name")[1]
               --print("name: "..cmd.name)
               cmd.returnType = v:find("type")[1]
            elseif(v:tag() == "param") then
               local param = {}
               param.type = getTypeTag(v)
               param.name = getNameTag(v)
               if(v.optional == true) then param.optional = true end
               
               for i = 1, #v do
                  local vv = v[i]
                  
                  if(vv == "*") then 
                     param.pointer = true
                  elseif(vv == "const") then 
                     param.const = true
                  elseif(vv == "**") then
                     param.doublePointer = true
                  elseif(type(vv) == "string" and string.find(vv, "* const *")) then
                     param.const = true
                     param.doublePointer = true
                  end
               end
               
               table.insert(cmd.params, param)
            end
         end
         
         commands[cmd.name] = cmd
      else
         --print("Skipping alias: "..vkCmd.name)
      end
   end
end

function parseEnums()
   for k,v in pairs(vk) do
      if(type(v) == "table" and v:tag() == "enums" and v.type == "enum") then
         local enum = {}
         local enumName = v.name
         for i = 1,#v do
            local vv = v[i]
            if(type(vv) == "table" and vv:tag() == "enum"  and vv.alias == nil) then
               local val = {}
               val.name = vv.name
               val.value = vv.value
               table.insert(enum, val)
            end
         end
         
         types.enums[enumName].values = enum
      end
   end
end

function parseBitmasks()
   for k,v in pairs(vk) do
      if(type(v) == "table" and v:tag() == "enums" and v.type == "bitmask") then
         local bm = {}
         local bmName = v.name
         for i = 1, #v do
            local vv = v[i]
            if(type(vv) == "table" and vv:tag() == "enum" and vv.alias == nil and vv.bitpos ~= nil) then
               local val = {}
               val.name = vv.name
               val.bitpos = vv.bitpos
               if(vv.comment ~= nil) then val.comment = vv.comment end
               table.insert(bm, val)
            end
         end
         
         local flagName = string.gsub(bmName, "FlagBits", "Flags")
         
         if(types.bitmasks[flagName] ~= nil) then
            types.bitmasks[flagName].bits = bm
         else
            error("Can't find "..flagName)
         end
      end
   end
end

function parseExtensions()  
   local exts = vk:find("extensions")
   for k,ext in pairs(exts) do
      if(type(ext) == "table" and ext.tag ~= nil and ext:tag() == "extension" and ext.promotedto == nil) then
         if(ext.supported == "vulkan") then
            local extension = {}
            extension.commands = {}
            extension.structs = {}
            extension.handles = {}
            extension.enums = {}
            extension.bitmasks = {}
            extension.name = ext.name
            extension.number = ext.number
            extension.type = ext.type
            extension.author = ext.author
            extension.type = ext.type
            
            for kk,vv in pairs(ext) do
               if(type(vv)== "table" and vv:tag() == "require") then
                  for i,r in pairs(vv) do
                     if(type(r)=="table" and r:tag() == "enum" and r.offset ~= nil and r.extends ~= nil and r.alias == nil) then
                        local extEnum = {}
                        extEnum.name = r.name
                        extEnum.value =  1000000000 + (ext.number * 1000) + r.offset
                        extEnum.extension = ext.name
                        table.insert(types.enums[r.extends].values, extEnum)
                     elseif(type(r) == "table" and r:tag() == "enum" and r.bitpos ~= nil) then
                        local flagName = string.gsub(r.extends, "FlagBits", "Flags")
                        local extBitmask = {}
                        extBitmask.name = r.name
                        extBitmask.bitpos = r.bitpos
                        extBitmask.extension = ext.name
                        table.insert(types.bitmasks[flagName].bits, extBitmask)
                     elseif(type(r) == "table" and r:tag() == "command") then
                        if(commands[r.name] ~= nil) then
                           commands[r.name].extension = ext.name
                           table.insert(extension.commands, r.name)
                           
                           local c = commands[r.name]
                           local rt = types.type[c.returnType] 
                        end
                     elseif(type(r) == "table" and r:tag() == "type") then
                        if(types.structs[r.name] ~=nil) then
                           types.structs[r.name].extension = ext.name
                           table.insert(extension.structs, r.name)
                        elseif(types.enums[r.name] ~= nil) then
                           types.enums[r.name].extension = ext.name
                           table.insert(extension.enums, r.name)
                        elseif(types.bitmasks[r.name] ~= nil) then
                           types.bitmasks[r.name].extension = ext.name
                           table.insert(extension.bitmasks, r.name)
                        elseif(types.handles[r.name] ~= nil) then
                           table.insert(extension.handles, r.name)
                        end
                     end
                  end
               end
            end

            --look for enums
            for k,v in pairs(types.enums) do
               if(v.extension == extension.name) then
                  table.insert(extension.enums, k)
               end
            end
            --look for bitmasks
            for k,v in pairs(types.bitmasks) do
               if(v.extension == extension.name) then
                  table.insert(extension.bitmasks, k)
               end
            end
            --look for structs
            for k,v in pairs(types.structs) do
               if(v.extension == extension.name) then
                  table.insert(extension.structs, k)
               end
            end
            
            extensions[tonumber(extension.number)] = extension
         end
      end
   end
end

function addUnique(t, val)
   for k,v in pairs(t) do
      if(v == val) then return end
   end
   
   table.insert(t, val)
end

function parseApi()
   api.commands = {}
   api.enums = {}
   api.structs = {}
   api.bitmasks = {}
   api.unions = {}
   api.funcpointers = {}
   api.handles = {}
   
   function addType(typename)
      local t = types.type[typename]
      if(t == nil) then return end
      
      if(t == "handle") then addUnique(api.handles, typename) end
      if(t == "enum") then addUnique(api.enums, typename) end
      if(t == "bitmask") then addUnique(api.bitmasks, typename) end
      if(t == "union") then addUnique(api.unions, typename) end
      if(t == "struct") then addUnique(api.structs, typename) end
      if(t == "funcpointer") then addUnique(api.funcpointers, typename) end
   end
   
   for k,v in pairs(vk) do 
      if(type(v) == "table" and v:tag() == "feature") then
         for kk,vv in pairs(v) do
            if(type(vv) == "table" and vv:tag() == "require") then
               local groupName = vv.comment
               for i, r in pairs(vv) do
                  if(type(r) == "table" and r:tag() == "command") then
                     commands[r.name].group = groupName
                     table.insert(api.commands, r.name)
                     
                     local c = commands[r.name]
                     addType(c.returnType)
                     for n,m in pairs(c.params) do
                        addType(m.type)
                     end
                  elseif(type(r) == "table" and r:tag() == "enum") then
                     if(r.extends ~= nil and r.bitpos == nil and r.alias == nil) then
                        local val = 1000000000 + (r.extnumber * 1000) + r.offset
                        table.insert(types.enums[r.extends].values, {name = r.name, value = val})
                        addType(r.extends)
                     elseif(r.extends ~= nil and r.bitpos ~= nil and r.alias == nil) then
                        local flagName = string.gsub(r.extends, "FlagBits", "Flags")
                        table.insert(types.bitmasks[flagName].bits, {name = r.name, bitpos = r.bitpos})
                        addType(r.extends)
                     end
                   elseif(type(r) == "table" and r:tag() == "type" and r.alias == nil) then
                     addType(r.name)
                     local s = types.structs[r.name]
                     if(s ~= nil) then
                        for i=1,#s do
                           addType(s[i].type)
                        end
                     end
                  end
               end
            end
         end
      end
   end
end

parseTags()
parseTypes()
parseEnums()
parseBitmasks()
parseCommands()
parseApi()
parseExtensions()

if(arg[1] == "-p") then
   print(dump(tags))
   print(dump(types))
   print(dump(commands))
   print(dump(api))
   print(dump(extensions))
end