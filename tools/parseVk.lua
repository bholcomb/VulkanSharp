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
enums = {}
bitmasks = {}
structs = {}
api = {}
extensions = {}
tags = {}

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
               param.type = ""
               for kk,vv in pairs(v) do
                  if(kk == 0) then
                  
                  elseif(type(kk) == "string") then 
                     param[kk] = vv
                  elseif(type(vv) == "table" and vv:tag() == "name") then 
                     param.name = vv[1] 
                  elseif(type(vv) == "table" and vv:tag() == "type") then
                     param.type = param.type .. vv[1].. " "
                  else
                     param.type = param.type .. vv.. " "
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
         for kk,vv in pairs(v) do
            if(type(vv) == "table" and vv:tag() == "enum"  and vv.alias == nil) then
               local val = {}
               val.name = vv.name
               val.value = vv.value
               table.insert(enum, val)
            end
         end
         
         enums[enumName] = enum
      end
   end
end

function parseBitmasks()
   for k,v in pairs(vk) do
      if(type(v) == "table" and v:tag() == "enums" and v.type == "bitmask") then
         local bm = {}
         local bmName = v.name
         for kk,vv in pairs(v) do
            if(type(vv) == "table" and vv:tag() == "enum" and vv.alias == nil and vv.bitpos ~= nil) then
               local val = {}
               val.name = vv.name
               val.bitpos = vv.bitpos
               table.insert(bm, val)
            end
         end
         
         bitmasks[bmName] = bm
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
                        table.insert(enums[r.extends], extEnum)
                     elseif(type(r) == "table" and r:tag() == "enum" and r.bitpos ~= nil) then
                        --print(r.extends)
                        local extBitmask = {}
                        extBitmask.name = r.name
                        extBitmask.bitpos = r.bitpos
                        extBitmask.extension = ext.name
                        table.insert(bitmasks[r.extends], extBitmask)
                     elseif(type(r) == "table" and r:tag() == "command") then
                        if(commands[r.name] ~= nil) then
                           commands[r.name].extension = ext.name
                           table.insert(extension.commands, r.name)  
                        end
                     elseif(type(r) == "table" and r:tag() == "type") then
                        if(structs[r.name] ~=nil) then
                           structs[r.name].extension = ext.name
                           table.insert(extension.structs, r.name)
                        elseif(enums[r.name] ~= nil) then
                           enums[r.name].extension = ext.name
                           table.insert(extension.enums, r.name)
                        elseif(bitmasks[r.name] ~= nil) then
                           bitmasks[r.name].extension = ext.name
                           table.insert(extension.bitmasks, r.name)
                        end
                     end
                  end
               end
            end
            
            extensions[extension.number] = extension
         end
      end
   end
end

function parseStructs()
   local function needsMarshaller(field)
      return false
   end
   
   local types = vk:find("types");
   for k,v in pairs(types)  do
      if(type(v) == "table" and v:tag() == "type" and v.category == "struct" and v.alias == nil) then
         local struct = {}
         struct.fields = {}
         struct.name = v.name
         struct.returnedOnly = v.returnedOnly or false
         for kk,member in pairs(v) do
            if(type(member) == "table" and member:tag()=="member") then
               local field = {}
               field.type = ""
               
               for kk,vv in pairs(member) do
                  if(kk == 0) then
                     --noop
                  elseif(type(kk) == "string") then 
                     field[kk] = vv
                  elseif(type(vv) == "table" and vv:tag() == "name") then 
                     field.name = vv[1] 
                  elseif(type(vv) == "table" and vv:tag() == "type") then
                     field.type = field.type .. vv[1].. " "
                  elseif(type(vv) == "table" and vv:tag() == "enum") then
                     field.type = field.type..vv[1]
                  elseif(type(vv) == "table" and vv:tag() == "comment") then
                     --noop
                  else
                     field.type = field.type .. vv.. " "
                  end
               end
               
               if(needsMarshaller(field) == true) then
                  struct.needsMarshaller = true
               end
               
               table.insert(struct.fields, field)
            end
         end
         
         structs[struct.name] = struct
      end
   end
end

function parseApi()
   api.commands = {}
   api.enums = {}
   api.structs = {}
   api.bitmasks = {}
   for k,v in pairs(vk) do 
      if(type(v) == "table" and v:tag() == "feature") then
         for kk,vv in pairs(v) do
            if(type(vv) == "table" and vv:tag() == "require") then
               local groupName = vv.comment
               for i, r in pairs(vv) do
                  if(type(r) == "table" and r:tag() == "command") then
                     commands[r.name].group = groupName
                     table.insert(api.commands, commands[r.name])
                  elseif(type(r) == "table" and r:tag() == "enum") then
                     if(r.extends ~= nil and r.bitpos == nil and r.alias == nil) then
                        table.insert(api.enums, enums[r.name])
                     elseif(r.extends ~= nil and r.bitpos ~= nil and r.alias == nil) then
                        table.insert(api.bitmasks, bitmasks[r.name])
                     end
                   elseif(type(r) == "table" and r:tag() == "type" and r.alias == nil) then
                     table.insert(api.structs, structs[r.name])
                  end
               end
            end
         end
      end
   end
end

parseTags()
parseCommands()
parseEnums()
parseBitmasks()
parseStructs()
parseExtensions()
parseApi()

if(arg[1] == "-p") then
   print(dump(tags))
   print(dump(commands))
   print(dump(enums))
   print(dump(bitmasks))
   print(dump(structs))
   print(dump(api))
   print(dump(extensions))
end