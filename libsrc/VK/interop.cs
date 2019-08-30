using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
   internal static class ExternalFunction
   {
      internal static T getInstanceFunction<T>(VK.Instance instance, string name)
      {
         IntPtr funcPtr = VK.GetInstanceProcAddr(instance, name);
         if(funcPtr == IntPtr.Zero)
         {
            throw new Exception(String.Format("Instance function {0} not found, extension may not be present", name));
         }

         return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
      }

      internal static T getDeviceFunction<T>(VK.Device device, string name)
      {
         IntPtr funcPtr = VK.GetDeviceProcAddr(device, name);
         if(funcPtr == IntPtr.Zero)
         {
            throw new Exception(String.Format("Device function {0} not found, extension may not be present", name));
         }

         return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
      }
   }


   internal static class Alloc
   {
      internal static IntPtr alloc<T>(T data)
      {
         IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data.GetType()));
         Marshal.StructureToPtr(data, ptr, false);
         return ptr;
      }

      internal unsafe static IntPtr* alloc(List<string> data)
      {
         IntPtr* ptr = (IntPtr*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * data.Count);
         for(int i = 0; i < data.Count; i++)
         {
            ptr[i] = Marshal.StringToHGlobalAnsi(data[i]);
         }
         return ptr;
      }

      internal static IntPtr alloc<T>(List<T> data) where T : struct
      {
         if(data == null)
         {
            return IntPtr.Zero;
         }

         bool isEnum = typeof(T).IsEnum;
         Type outputType = isEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

         IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(outputType) * data.Count);
         Int64 addr = ptr.ToInt64();
         for(int i = 0; i < data.Count; i++)
         {
            IntPtr anItem = new IntPtr(addr);
            if(isEnum)
            {
               int val = Convert.ToInt32(data[i]);
               Marshal.StructureToPtr(val, anItem, false);
            }
            else
            {
               Marshal.StructureToPtr(data[i], anItem, false);
            }
            addr += Marshal.SizeOf(outputType);
         }

         return ptr;
      }

      internal static IntPtr alloc<T>(T[] data) where T : struct
      {
         if(data == null)
         {
            return IntPtr.Zero;
         }

         bool isEnum = typeof(T).IsEnum;
         Type outputType = isEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

         IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(outputType) * data.Length);
         Int64 addr = ptr.ToInt64();
         for(int i = 0; i < data.Length; i++)
         {
            IntPtr anItem = new IntPtr(addr);
            if(isEnum)
            {
               int val = Convert.ToInt32(data[i]);
               Marshal.StructureToPtr(val, anItem, false);
            }
            else
            {
               Marshal.StructureToPtr(data[i], anItem, false);
            }
            addr += Marshal.SizeOf(outputType);
         }

         return ptr;
      }

      internal static void free(IntPtr data)
      {
         if(data != IntPtr.Zero)
         {
            Marshal.FreeHGlobal(data);
         }
      }

      internal unsafe static void free(IntPtr* data, int count)
      {
         for(int i = 0; i < count; i++)
         {
            Marshal.FreeHGlobal(data[i]);
         }

         Marshal.FreeHGlobal(new IntPtr(data));
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   internal unsafe struct _InstanceCreateInfo
   {
      public VK.StructureType sType;
      public IntPtr next;
      public UInt32 flags;
      public IntPtr applicationInfo;

      public UInt32 enabledLayerCount;
      public IntPtr* enabledLayerNames;

      public UInt32 enabledExtensionCount;
      public IntPtr* enabledExtensionNames;

      public _InstanceCreateInfo(VK.InstanceCreateInfo info)
      {
         sType = info.type;
         next = info.next;
         flags = info.flags;
         applicationInfo = Alloc.alloc(info.applicationInfo);
         enabledLayerCount = (UInt32)info.enabledLayerNames.Count;
         enabledExtensionCount = (UInt32)info.enabledExtensionNames.Count;

         enabledLayerNames = Alloc.alloc(info.enabledLayerNames);
         enabledExtensionNames = Alloc.alloc(info.enabledExtensionNames);
      }

      public void destroy()
      {
         Alloc.free(applicationInfo);
         Alloc.free(enabledLayerNames, (int)enabledLayerCount);
         Alloc.free(enabledExtensionNames, (int)enabledExtensionCount);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   internal unsafe struct _DeviceCreateInfo
   {
      public VK.StructureType SType;
      public IntPtr Next;
      public UInt32 Flags;

      public UInt32 QueueCreateInfoCount;
      public IntPtr* QueueCreateInfos;

      public UInt32 enabledLayerCount;
      public IntPtr* enabledLayerNames;

      public UInt32 enabledExtensionCount;
      public IntPtr* enabledExtensionNames;

      public IntPtr EnabledFeatures;

      public _DeviceCreateInfo(VK.DeviceCreateInfo info)
      {
         SType = info.type;
         Next = info.next;
         Flags = info.flags;

         QueueCreateInfoCount = (UInt32)info.queueCreateInfos.Count;
         List<_DeviceQueueCreateInfo> qArray = new List<_DeviceQueueCreateInfo>();
         for(int i = 0; i < info.queueCreateInfos.Count; i++)
         {
            qArray.Add(new _DeviceQueueCreateInfo(info.queueCreateInfos[i]));
         }

         QueueCreateInfos = (IntPtr*)Alloc.alloc(qArray);

         enabledLayerCount = (UInt32)info.enabledLayerNames.Count;
         enabledExtensionCount = (UInt32)info.enabledExtensionNames.Count;

         enabledLayerNames = Alloc.alloc(info.enabledLayerNames);
         enabledExtensionNames = Alloc.alloc(info.enabledExtensionNames);

         EnabledFeatures = Alloc.alloc(info.enabledFeatures);
      }

      public void destroy()
      {
         Alloc.free(enabledLayerNames, (int)enabledLayerCount);
         Alloc.free(enabledExtensionNames, (int)enabledExtensionCount);
         Alloc.free(new IntPtr(QueueCreateInfos)); //since this is allocated as a large blob and should be freed as one
         Alloc.free(EnabledFeatures);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   internal struct _DeviceQueueCreateInfo
   {
      public VK.StructureType SType;
      public IntPtr Next;
      public UInt32 Flags;
      public UInt32 QueueFamilyIndex;
      public UInt32 QueueCount;
      public IntPtr QueuePriorities;

      public _DeviceQueueCreateInfo(VK.DeviceQueueCreateInfo info)
      {
         SType = info.type;
         Next = info.next;
         Flags = info.flags;
         QueueFamilyIndex = info.queueFamilyIndex;
         QueueCount = info.queueCount;

         QueuePriorities = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * info.queuePriorities.Length);
         Marshal.Copy(info.queuePriorities, 0, QueuePriorities, info.queuePriorities.Length);
      }

      public void destroy()
      {
         Alloc.free(QueuePriorities);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   internal struct _BindSparseInfo
   {
      VK.StructureType sType;
      IntPtr pNext;
      UInt32 waitSemaphoreCount;
      IntPtr pWaitSemaphores;
      UInt32 bufferBindCount;
      IntPtr pBufferBinds;
      UInt32 imageOpaqueBindCount;
      IntPtr pImageOpaqueBinds;
      UInt32 imageBindCount;
      IntPtr pImageBinds;
      UInt32 signalSemaphoreCount;
      IntPtr pSignalSemaphores;

      public _BindSparseInfo(VK.BindSparseInfo info)
      {
         sType = info.type;
         pNext = info.pNext;
         waitSemaphoreCount = (UInt32)info.pWaitSemaphores.Count;
         bufferBindCount = (UInt32)info.pBufferBinds.Count;
         imageOpaqueBindCount = (UInt32)info.pImageOpaqueBinds.Count;
         imageBindCount = (UInt32)info.pImageBinds.Count;
         signalSemaphoreCount = (UInt32)info.pSignalSemaphores.Count;

         pWaitSemaphores = Alloc.alloc(info.pWaitSemaphores);
         pBufferBinds = Alloc.alloc(info.pBufferBinds);
         pImageOpaqueBinds = Alloc.alloc(info.pImageOpaqueBinds);
         pImageBinds = Alloc.alloc(info.pImageBinds);
         pSignalSemaphores = Alloc.alloc(info.pSignalSemaphores);
      }

      public void destroy()
      {
         Alloc.free(pWaitSemaphores);
         Alloc.free(pBufferBinds);
         Alloc.free(pImageOpaqueBinds);
         Alloc.free(pImageBinds);
         Alloc.free(pSignalSemaphores);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct _SparseBufferMemoryBindInfo
   {
      public VK.Buffer buffer;
      public UInt32 bindCount;
      public IntPtr binds;

      public _SparseBufferMemoryBindInfo(VK.SparseBufferMemoryBindInfo info)
      {
         buffer = info.buffer;
         bindCount = (UInt32)info.binds.Count;
         binds = Alloc.alloc(info.binds);
      }

      public void destory()
      {
         Alloc.free(binds);
      }
   };

   [StructLayout(LayoutKind.Sequential)]
   public struct _SparseImageOpaqueMemoryBindInfo
   {
      public VK.Image image;
      public UInt32 bindCount;
      public IntPtr binds;

      public _SparseImageOpaqueMemoryBindInfo(VK.SparseImageOpaqueMemoryBindInfo info)
      {
         image = info.image;
         bindCount = (UInt32)info.binds.Count;
         binds = Alloc.alloc(info.binds);
      }

      public void destory()
      {
         Alloc.free(binds);
      }
   };

   [StructLayout(LayoutKind.Sequential)]
   public struct _SparseImageMemoryBindInfo
   {
      public VK.Image image;
      public UInt32 bindCount;
      public IntPtr binds;

      public _SparseImageMemoryBindInfo(VK.SparseImageMemoryBindInfo info)
      {
         image = info.image;
         bindCount = (UInt32)info.binds.Count;
         binds = Alloc.alloc(info.binds);
      }

      public void destory()
      {
         Alloc.free(binds);
      }
   };

   [StructLayout(LayoutKind.Sequential)]
   public struct _BufferCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.BufferCreateFlags flags;  //Buffer creation flags 
      public DeviceSize size;  //Specified in bytes 
      public VK.BufferUsageFlags usage;  //Buffer usage flags 
      public VK.SharingMode sharingMode;
      public UInt32 queueFamilyIndexCount;
      public IntPtr queueFamilyIndices;

      public _BufferCreateInfo(VK.BufferCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         size = info.size;
         usage = info.usage;
         sharingMode = info.sharingMode;
         queueFamilyIndexCount = (UInt32)(info.queueFamilyIndices?.Count ?? 0);
         queueFamilyIndices = Alloc.alloc(info.queueFamilyIndices);
      }

      public void destroy()
      {
         Alloc.free(queueFamilyIndices);
      }
   };

   [StructLayout(LayoutKind.Sequential)]
   public struct _ImageCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.ImageCreateFlags flags;  //Image creation flags 
      public VK.ImageType imageType;
      public VK.Format format;
      public VK.Extent3D extent;
      public UInt32 mipLevels;
      public UInt32 arrayLayers;
      public VK.SampleCountFlags samples;
      public VK.ImageTiling tiling;
      public VK.ImageUsageFlags usage;  //Image usage flags 
      public VK.SharingMode sharingMode;  //Cross-queue-family sharing mode 
      public UInt32 queueFamilyIndexCount;  //Number of queue families to share across 
      public IntPtr queueFamilyIndices;  //Array of queue family indices to share across 
      public VK.ImageLayout initialLayout;  //Initial image layout for all subresources 

      public _ImageCreateInfo(VK.ImageCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         imageType = info.imageType;
         format = info.format;
         extent = info.extent;
         mipLevels = info.mipLevels;
         arrayLayers = info.arrayLayers;
         samples = info.samples;
         tiling = info.tiling;
         usage = info.usage;
         sharingMode = info.sharingMode;
         queueFamilyIndexCount = (UInt32)info.queueFamilyIndices.Count;
         queueFamilyIndices = Alloc.alloc(info.queueFamilyIndices);
         initialLayout = info.initialLayout;
      }

      public void destroy()
      {
         Alloc.free(queueFamilyIndices);
      }
   };

   [StructLayout(LayoutKind.Sequential)]
   internal struct _SubmitInfo
   {
      public VK.StructureType SType;
      public IntPtr Next;
      public UInt32 WaitSemaphoreCount;
      public IntPtr WaitSemaphores;
      public IntPtr WaitDstStageMask;
      public UInt32 CommandBufferCount;
      public IntPtr CommandBuffers;
      public UInt32 SignalSemaphoreCount;
      public IntPtr SignalSemaphores;

      public _SubmitInfo(VK.SubmitInfo info)
      {
         SType = info.type;
         Next = info.next;
         WaitSemaphoreCount = (UInt32)(info.waitSemaphores?.Count ?? 0);
         CommandBufferCount = (UInt32)(info.commandBuffers?.Count ?? 0);
         SignalSemaphoreCount = (UInt32)(info.signalSemaphores?.Count ?? 0);

         WaitDstStageMask = Alloc.alloc(info.waitDstStageMask);
         WaitSemaphores = Alloc.alloc(info.waitSemaphores);
         CommandBuffers = Alloc.alloc(info.commandBuffers);
         SignalSemaphores = Alloc.alloc(info.signalSemaphores);
      }

      public void destroy()
      {
         Alloc.free(WaitDstStageMask);
         Alloc.free(WaitSemaphores);
         Alloc.free(CommandBuffers);
         Alloc.free(SignalSemaphores);
      }
   }

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   internal struct _RenderPassCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.RenderPassCreateFlags flags;
      public UInt32 attachmentCount;
      public IntPtr attachments;
      public UInt32 subpassCount;
      public IntPtr subpasses;
      public UInt32 dependencyCount;
      public IntPtr dependencies;

      public _RenderPassCreateInfo(VK.RenderPassCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         attachmentCount = (UInt32)(info.attachments?.Count ?? 0);
         subpassCount = (UInt32)(info.subpasses?.Count ?? 0);
         dependencyCount = (UInt32)(info.dependencies?.Count ?? 0);

         attachments = Alloc.alloc(info.attachments);
         dependencies = Alloc.alloc(info.dependencies);

         List<_SubpassDescription> subpassArray = new List<_SubpassDescription>();
         for(int i = 0; i < info.subpasses.Count; i++)
         {
            subpassArray.Add(new _SubpassDescription(info.subpasses[i]));
         }

         subpasses = Alloc.alloc(subpassArray);

         for(int i = 0; i < subpassArray.Count; i++)
         {
            subpassArray[i].destroy();
         }
      }

      public void destroy()
      {
         Alloc.free(attachments);
         Alloc.free(subpasses);
         Alloc.free(dependencies);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   internal struct _SubpassDescription
   {
      public VK.SubpassDescriptionFlags flags;
      public VK.PipelineBindPoint pipelineBindPoint;  //Must be VK_PIPELINE_BIND_POINT_GRAPHICS for now 
      public UInt32 inputAttachmentCount;
      public IntPtr inputAttachments;
      public UInt32 colorAttachmentCount;
      public IntPtr colorAttachments;
      public IntPtr resolveAttachments;
      public IntPtr depthStencilAttachment;
      public UInt32 preserveAttachmentCount;
      public IntPtr preserveAttachments;

      public _SubpassDescription(VK.SubpassDescription info)
      {
         flags = info.flags;
         pipelineBindPoint = info.pipelineBindPoint;
         inputAttachmentCount = (UInt32)(info.inputAttachments?.Count ?? 0);
         colorAttachmentCount = (UInt32)(info.colorAttachments?.Count ?? 0);
         preserveAttachmentCount = (UInt32)(info.preserveAttachments?.Count ?? 0);

         inputAttachments = Alloc.alloc(info.inputAttachments);
         colorAttachments = Alloc.alloc(info.colorAttachments);
         resolveAttachments = Alloc.alloc(info.resolveAttachments);
         depthStencilAttachment = Alloc.alloc(info.depthStencilAttachment);
         preserveAttachments = Alloc.alloc(info.preserveAttachments);
      }

      public void destroy()
      {
         Alloc.free(inputAttachments);
         Alloc.free(colorAttachments);
         Alloc.free(resolveAttachments);
         Alloc.free(depthStencilAttachment);
         Alloc.free(preserveAttachments);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   internal struct _FramebufferCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.FramebufferCreateFlags flags;
      public VK.RenderPass renderPass;
      public UInt32 attachmentCount;
      public IntPtr attachments;
      public UInt32 width;
      public UInt32 height;
      public UInt32 layers;

      public _FramebufferCreateInfo(VK.FramebufferCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         renderPass = info.renderPass;
         attachmentCount = (UInt32)(info.attachments?.Count ?? 0);
         width = info.width;
         height = info.height;
         layers = info.layers;

         attachments = Alloc.alloc(info.attachments);
      }

      public void destroy()
      {
         Alloc.free(attachments);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   internal struct _CommandBufferBeginInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.CommandBufferUsageFlags flags;  //Command buffer usage flags 
      public IntPtr inheritanceInfo;  //Pointer to inheritance info for secondary command buffers

      public _CommandBufferBeginInfo(VK.CommandBufferBeginInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;

         inheritanceInfo = info.inheritanceInfo == null ? IntPtr.Zero : Alloc.alloc(info.inheritanceInfo);
      }

      public void destroy()
      {
         Alloc.free(inheritanceInfo);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineVertexInputStateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineVertexInputStateCreateFlags flags;
      public UInt32 vertexBindingDescriptionCount;  //number of bindings 
      public IntPtr vertexBindingDescriptions;
      public UInt32 vertexAttributeDescriptionCount;  //number of attributes 
      public IntPtr vertexAttributeDescriptions;

      public _PipelineVertexInputStateCreateInfo(VK.PipelineVertexInputStateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;

         vertexBindingDescriptionCount = (UInt32)(info.vertexBindingDescriptions?.Length ?? 0);
         vertexBindingDescriptions = info.vertexBindingDescriptions != null ? Alloc.alloc(info.vertexBindingDescriptions) : IntPtr.Zero;

         vertexAttributeDescriptionCount = (UInt32)(info.vertexAttributeDescriptions?.Length ?? 0);
         vertexAttributeDescriptions = info.vertexAttributeDescriptions != null ? Alloc.alloc(info.vertexAttributeDescriptions) : IntPtr.Zero;
      }

      public void destroy()
      {
         Alloc.free(vertexBindingDescriptions);
         Alloc.free(vertexAttributeDescriptions);
      }
   };


   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _GraphicsPipelineCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineCreateFlags flags;  //Pipeline creation flags 
      public UInt32 stageCount;
      public IntPtr pStages;  //One entry for each active shader stage 
      public IntPtr pVertexInputState;
      public IntPtr pInputAssemblyState;
      public IntPtr pTessellationState;
      public IntPtr pViewportState;
      public IntPtr pRasterizationState;
      public IntPtr pMultisampleState;
      public IntPtr pDepthStencilState;
      public IntPtr pColorBlendState;
      public IntPtr pDynamicState;
      public VK.PipelineLayout layout;  //Interface layout of the pipeline 
      public VK.RenderPass renderPass;
      public UInt32 subpass;
      public VK.Pipeline basePipelineHandle;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of 
      public Int32 basePipelineIndex;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of 

      public _GraphicsPipelineCreateInfo(VK.GraphicsPipelineCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         stageCount = (UInt32)info.stages.Count;
         List<_PipelineShaderStageCreateInfo> stages = new List<_PipelineShaderStageCreateInfo>();
         for(int i=0; i< info.stages.Count; i++)
         {
            stages.Add(new _PipelineShaderStageCreateInfo(info.stages[i]));
         }
         pStages = Alloc.alloc(stages);
         pVertexInputState = info.vertexInputState == null ? IntPtr.Zero : Alloc.alloc(new _PipelineVertexInputStateCreateInfo(info.vertexInputState));
         pInputAssemblyState = info.inputAssemblyState == null ? IntPtr.Zero : Alloc.alloc(info.inputAssemblyState);
         pTessellationState = info.tessellationState == null ? IntPtr.Zero : Alloc.alloc(info.tessellationState);
         pViewportState = info.viewportState == null ? IntPtr.Zero : Alloc.alloc(new _PipelineViewportStateCreateInfo(info.viewportState));
         pRasterizationState = info.rasterizationState == null ? IntPtr.Zero : Alloc.alloc(info.rasterizationState);
         pMultisampleState = info.multisampleState == null ? IntPtr.Zero : Alloc.alloc(new _PipelineMultisampleStateCreateInfo(info.multisampleState));
         pDepthStencilState = info.depthStencilState == null ? IntPtr.Zero : Alloc.alloc(info.depthStencilState);
         pColorBlendState = info.colorBlendState == null ? IntPtr.Zero : Alloc.alloc(new _PipelineColorBlendStateCreateInfo(info.colorBlendState));
         pDynamicState = info.dynamicState == null ? IntPtr.Zero : Alloc.alloc(new _PipelineDynamicStateCreateInfo(info.dynamicState));
         layout = info.layout;
         renderPass = info.renderPass;
         subpass = info.subpass;
         basePipelineHandle = info.basePipelineHandle;
         basePipelineIndex = info.basePipelineIndex;
      }

      public void destroy()
      {
         Alloc.free(pStages);
         Alloc.free(pVertexInputState);
         Alloc.free(pInputAssemblyState);
         Alloc.free(pTessellationState);
         Alloc.free(pViewportState);
         Alloc.free(pRasterizationState);
         Alloc.free(pMultisampleState);
         Alloc.free(pDepthStencilState);
         Alloc.free(pColorBlendState);
         Alloc.free(pDynamicState);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _ComputePipelineCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineCreateFlags flags;  //Pipeline creation flags 
      public _PipelineShaderStageCreateInfo stage;
      public VK.PipelineLayout layout;  //Interface layout of the pipeline 
      public VK.Pipeline basePipelineHandle;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of 
      public Int32 basePipelineIndex;  //If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of 

      public _ComputePipelineCreateInfo(VK.ComputePipelineCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         stage = new _PipelineShaderStageCreateInfo(info.stage);
         layout = info.layout;
         basePipelineHandle = info.basePipelineHandle;
         basePipelineIndex = info.basePipelineIndex;
      }

      public void destroy()
      {
         stage.destroy();
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineShaderStageCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineShaderStageCreateFlags flags;
      public VK.ShaderStageFlags stage;  //Shader stage 
      public VK.ShaderModule module;  //Module containing entry point
      public IntPtr name;  //Null-terminated entry point name 
      public IntPtr specializationInfo;

      public _PipelineShaderStageCreateInfo(VK.PipelineShaderStageCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         stage = info.stage;
         module = info.module;
         name = Marshal.StringToHGlobalAnsi(info.name);
         if(info.specializationInfo != null)
         {
            specializationInfo = Alloc.alloc(new _SpecializationInfo(info.specializationInfo));
         }
         else
         {
            specializationInfo = IntPtr.Zero;
         }
      }

      public void destroy()
      {
         Marshal.FreeHGlobal(name);
         Alloc.free(specializationInfo);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineViewportStateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineViewportStateCreateFlags flags;
      public UInt32 viewportCount;
      public IntPtr viewports;
      public UInt32 scissorCount;
      public IntPtr scissors;

      public _PipelineViewportStateCreateInfo(VK.PipelineViewportStateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         viewportCount = (UInt32)info.viewports.Count;
         viewports = Alloc.alloc(info.viewports);
         scissorCount = (UInt32)info.scissors.Count;
         scissors = Alloc.alloc(info.scissors);
      }
      
      public void destroy()
      {
         Alloc.free(viewports);
         Alloc.free(scissors);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineMultisampleStateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineMultisampleStateCreateFlags flags;
      public VK.SampleCountFlags rasterizationSamples;  //Number of samples used for rasterization 
      public Bool32 sampleShadingEnable;  //optional (GL45) 
      public float minSampleShading;  //optional (GL45) 
      public IntPtr sampleMask;  //Array of sampleMask words 
      public Bool32 alphaToCoverageEnable;
      public Bool32 alphaToOneEnable;

      public _PipelineMultisampleStateCreateInfo(VK.PipelineMultisampleStateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         rasterizationSamples = info.rasterizationSamples;
         sampleShadingEnable = info.sampleShadingEnable;
         minSampleShading = info.minSampleShading;
         sampleMask = Alloc.alloc(info.sampleMask);
         alphaToCoverageEnable = info.alphaToCoverageEnable;
         alphaToOneEnable = info.alphaToOneEnable;
      }

      public void destroy()
      {
         Alloc.free(sampleMask);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public unsafe struct _PipelineColorBlendStateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineColorBlendStateCreateFlags flags;
      public Bool32 logicOpEnable;
      public VK.LogicOp logicOp;
      public UInt32 attachmentCount;  //# of pAttachments
      public IntPtr pAttachments;
      public fixed float blendConstants[4];

      public _PipelineColorBlendStateCreateInfo(VK.PipelineColorBlendStateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         logicOpEnable = info.logicOpEnable;
         logicOp = info.logicOp;
         attachmentCount = (UInt32)info.attachments.Count;
         pAttachments = Alloc.alloc(info.attachments);

         for(int i = 0; i < 4; i++)
         {
            blendConstants[i] = info.blendConstants[i];
         }
      }

      public void destroy()
      {
         Alloc.free(pAttachments);
      }
   };


   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineDynamicStateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineDynamicStateCreateFlags flags;
      public UInt32 dynamicStateCount;
      public IntPtr dynamicStates;

      public _PipelineDynamicStateCreateInfo(VK.PipelineDynamicStateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         dynamicStateCount = (UInt32)info.dynamicStates.Count;
         dynamicStates = Alloc.alloc(info.dynamicStates);
      }

      public void destroy()
      {
         Alloc.free(dynamicStates);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PipelineLayoutCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.PipelineLayoutCreateFlags flags;
      public UInt32 setLayoutCount;  //Number of descriptor sets interfaced by the pipeline 
      public IntPtr setLayouts;  //Array of setCount number of descriptor set layout objects defining the layout of the 
      public UInt32 pushConstantRangeCount;  //Number of push-constant ranges used by the pipeline 
      public IntPtr pushConstantRanges;  //Array of pushConstantRangeCount number of ranges used by various shader stages

      public _PipelineLayoutCreateInfo(VK.PipelineLayoutCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         setLayoutCount = (UInt32)(info.setLayouts?.Count ?? 0);
         setLayouts = Alloc.alloc(info.setLayouts);
         pushConstantRangeCount = (UInt32)(info.pushConstantRanges?.Count ?? 0);
         pushConstantRanges = Alloc.alloc(info.pushConstantRanges);
      }

      public void destroy()
      {
         Alloc.free(setLayouts);
         Alloc.free(pushConstantRanges);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _SpecializationInfo
   {
      public UInt32 mapEntryCount;  //Number of entries in the map 
      public IntPtr pMapEntries;  //Array of map entries 
      public UInt64 dataSize;  //Size in bytes of pData 
      public IntPtr pData;  //Pointer to SpecConstant data 

      public _SpecializationInfo(VK.SpecializationInfo info)
      {
         mapEntryCount = (UInt32)info.mapEntries.Count;
         pMapEntries = Alloc.alloc(info.mapEntries);
         dataSize = info.dataSize;
         pData = info.pData;
      }

      public void destroy()
      {
         Alloc.free(pMapEntries);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DescriptorSetLayoutCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.DescriptorSetLayoutCreateFlags flags;
      public UInt32 bindingCount;  //Number of bindings in the descriptor set layout 
      public IntPtr pBindings;  //Array of descriptor set layout bindings 

      public _DescriptorSetLayoutCreateInfo(VK.DescriptorSetLayoutCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         bindingCount = (UInt32)info.bindings.Count;
         List<_DescriptorSetLayoutBinding> bindings = new List<_DescriptorSetLayoutBinding>();
         for(int i=0; i < info.bindings.Count; i++)
         {
            bindings.Add(new _DescriptorSetLayoutBinding(info.bindings[i]));
         }

         pBindings = Alloc.alloc(bindings);
      }

      public void destroy()
      {
         Alloc.free(pBindings);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DescriptorSetLayoutBinding
   {
      public UInt32 binding;  //Binding number for this entry 
      public VK.DescriptorType descriptorType;  //Type of the descriptors in this binding 
      public UInt32 descriptorCount;  //Number of descriptors in this binding 
      public VK.ShaderStageFlags stageFlags;  //Shader stages this binding is visible to 
      public IntPtr pImmutableSamplers;  //Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements) 

      public _DescriptorSetLayoutBinding(VK.DescriptorSetLayoutBinding info)
      {
         binding = info.binding;
         descriptorType = info.descriptorType;
         descriptorCount = info.descriptorCount;
         stageFlags = info.stageFlags;
         pImmutableSamplers = Alloc.alloc(info.immutableSamplers);
      }

      public void destroy()
      {
         Alloc.free(pImmutableSamplers);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DescriptorPoolCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.DescriptorPoolCreateFlags flags;
      public UInt32 maxSets;
      public UInt32 poolSizeCount;
      public IntPtr pPoolSizes;

      public _DescriptorPoolCreateInfo(VK.DescriptorPoolCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         maxSets = info.maxSets;
         poolSizeCount = (UInt32)info.poolSizes.Count;
         pPoolSizes = Alloc.alloc(info.poolSizes);
      }

      public void destroy()
      {
         Alloc.free(pPoolSizes);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DescriptorSetAllocateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.DescriptorPool descriptorPool;
      public UInt32 descriptorSetCount;
      public IntPtr pSetLayouts;

      public _DescriptorSetAllocateInfo(VK.DescriptorSetAllocateInfo info)
      {
         type = info.type;
         next = info.next;
         descriptorPool = info.descriptorPool;
         descriptorSetCount = (UInt32)info.setLayouts.Count;
         pSetLayouts = Alloc.alloc(info.setLayouts);
      }

      public void destroy()
      {
         Alloc.free(pSetLayouts);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DeviceGroupRenderPassBeginInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 deviceMask;
      public UInt32 deviceRenderAreaCount;
      public IntPtr deviceRenderAreas;

      public _DeviceGroupRenderPassBeginInfo(VK.DeviceGroupRenderPassBeginInfo info)
      {
         type = info.type;
         next = info.next;
         deviceMask = info.deviceMask;
         deviceRenderAreaCount = (UInt32)(info.deviceRenderAreas?.Count ?? 0);

         deviceRenderAreas = Alloc.alloc(info.deviceRenderAreas);
      }

      public void destroy()
      {
         Alloc.free(deviceRenderAreas);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DeviceGroupSubmitInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 waitSemaphoreCount;
      public IntPtr pWaitSemaphoreDeviceIndices;
      public UInt32 commandBufferCount;
      public IntPtr pCommandBufferDeviceMasks;
      public UInt32 signalSemaphoreCount;
      public IntPtr pSignalSemaphoreDeviceIndices;


      public _DeviceGroupSubmitInfo(VK.DeviceGroupSubmitInfo info)
      {
         type = info.type;
         next = info.next;
         waitSemaphoreCount = (UInt32)(info.waitSemaphoreDeviceIndices?.Count ?? 0);
         commandBufferCount = (UInt32)(info.commandBufferDeviceMasks?.Count ?? 0);
         signalSemaphoreCount = (UInt32)(info.signalSemaphoreDeviceIndices?.Count ?? 0);

         pWaitSemaphoreDeviceIndices = Alloc.alloc(info.waitSemaphoreDeviceIndices);
         pCommandBufferDeviceMasks = Alloc.alloc(info.commandBufferDeviceMasks);
         pSignalSemaphoreDeviceIndices = Alloc.alloc(info.signalSemaphoreDeviceIndices);
      }

      public void destroy()
      {
         Alloc.free(pWaitSemaphoreDeviceIndices);
         Alloc.free(pCommandBufferDeviceMasks);
         Alloc.free(pSignalSemaphoreDeviceIndices);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _RenderPassBeginInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.RenderPass renderPass;
      public VK.Framebuffer framebuffer;
      public VK.Rect2D renderArea;
      public UInt32 clearValueCount;
      public IntPtr pClearValues;

      public _RenderPassBeginInfo(VK.RenderPassBeginInfo info)
      {
         type = info.type;
         next = info.next;
         renderPass = info.renderPass;
         framebuffer = info.framebuffer;
         renderArea = info.renderArea;
         clearValueCount = (UInt32)(info.clearValues.Count);
         pClearValues = Alloc.alloc(info.clearValues);
      }

      public void destroy()
      {
         Alloc.free(pClearValues);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _BindBufferMemoryDeviceGroupInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 deviceIndexCount;
      public IntPtr deviceIndices;

      public _BindBufferMemoryDeviceGroupInfo(VK.BindBufferMemoryDeviceGroupInfo info)
      {
         type = info.type;
         next = info.next;
         deviceIndexCount = (UInt32)info.deviceIndices.Count;
         deviceIndices = Alloc.alloc(info.deviceIndices);
      }

      public void destroy()
      {
         Alloc.free(deviceIndices);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _BindImageMemoryDeviceGroupInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 deviceIndexCount;
      public IntPtr deviceIndices;
      public UInt32 splitInstanceBindRegionCount;
      public IntPtr splitInstanceBindRegions;

      public _BindImageMemoryDeviceGroupInfo(VK.BindImageMemoryDeviceGroupInfo info)
      {
         type = info.type;
         next = info.next;
         deviceIndexCount = (UInt32)info.deviceIndices.Count;
         deviceIndices = Alloc.alloc(info.deviceIndices);
         splitInstanceBindRegionCount = (UInt32)info.splitInstanceBindRegions.Count;
         splitInstanceBindRegions = Alloc.alloc(info.splitInstanceBindRegions);
      }

      public void destroy()
      {
         Alloc.free(deviceIndices);
         Alloc.free(splitInstanceBindRegions);
      }
   };


   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _PhysicalDeviceGroupProperties
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 physicalDeviceCount;
      public IntPtr physicalDevices;
      public Bool32 subsetAllocation;

      public _PhysicalDeviceGroupProperties(VK.PhysicalDeviceGroupProperties info)
      {
         type = info.type;
         next = info.next;
         physicalDeviceCount = (UInt32)info.physicalDevices.Count;
         physicalDevices = Alloc.alloc(info.physicalDevices);
         subsetAllocation = info.subsetAllocation;
      }

      public void destroy()
      {
         Alloc.free(physicalDevices);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DeviceGroupDeviceCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 physicalDeviceCount;
      public IntPtr physicalDevices;

      public _DeviceGroupDeviceCreateInfo(VK.DeviceGroupDeviceCreateInfo info)
      {
         type = info.type;
         next = info.next;
         physicalDeviceCount = (UInt32)info.physicalDevices.Count;
         physicalDevices = Alloc.alloc(info.physicalDevices);
      }

      public void destroy()
      {
         Alloc.free(physicalDevices);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _RenderPassInputAttachmentAspectCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 aspectReferenceCount;
      public IntPtr aspectReferences;

      public _RenderPassInputAttachmentAspectCreateInfo(VK.RenderPassInputAttachmentAspectCreateInfo info)
      {
         type = info.type;
         next = info.next;
         aspectReferenceCount = (UInt32)info.aspectReferences.Count;
         aspectReferences = Alloc.alloc(info.aspectReferences);
      }

      public void destroy()
      {
         Alloc.free(aspectReferences);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _RenderPassMultiviewCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public UInt32 subpassCount;
      public IntPtr viewMasks;
      public UInt32 dependencyCount;
      public IntPtr viewOffsets;
      public UInt32 correlationMaskCount;
      public IntPtr pCorrelationMasks;

      public _RenderPassMultiviewCreateInfo(VK.RenderPassMultiviewCreateInfo info)
      {
         type = info.type;
         next = info.next;
         subpassCount = info.subpassCount;
         viewMasks = Alloc.alloc(info.viewMasks);
         dependencyCount = info.dependencyCount;
         viewOffsets = Alloc.alloc(info.viewOffsets);
         correlationMaskCount = info.correlationMaskCount;
         pCorrelationMasks = Alloc.alloc(info.pCorrelationMasks);
      }

      public void destroy()
      {
         Alloc.free(viewMasks);
         Alloc.free(viewOffsets);
         Alloc.free(pCorrelationMasks);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _DescriptorUpdateTemplateCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.DescriptorUpdateTemplateCreateFlags flags;
      public UInt32 descriptorUpdateEntryCount;  //Number of descriptor update entries to use for the update template 
      public IntPtr descriptorUpdateEntries;  //Descriptor update entries for the template 
      public VK.DescriptorUpdateTemplateType templateType;
      public VK.DescriptorSetLayout descriptorSetLayout;
      public VK.PipelineBindPoint pipelineBindPoint;
      public VK.PipelineLayout pipelineLayout;  //If used for push descriptors, this is the only allowed layout 
      public UInt32 set;

      public _DescriptorUpdateTemplateCreateInfo(VK.DescriptorUpdateTemplateCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         descriptorUpdateEntryCount = (UInt32)info.descriptorUpdateEntries.Count;
         descriptorUpdateEntries = Alloc.alloc(info.descriptorUpdateEntries);
         templateType = info.templateType;
         descriptorSetLayout = info.descriptorSetLayout;
         pipelineBindPoint = info.pipelineBindPoint;
         pipelineLayout = info.pipelineLayout;
         set = info.set;
      }

      public void destroy()
      {
         Alloc.free(descriptorUpdateEntries);
      }
   };


   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _ShaderModuleCreateInfo
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.ShaderModuleCreateFlags flags;
      public UInt64 codeSize;
      public IntPtr code;  //Binary code of size codeSize 

      public _ShaderModuleCreateInfo(VK.ShaderModuleCreateInfo info)
      {
         type = info.type;
         next = info.next;
         flags = info.flags;
         codeSize = (UInt32)info.code.Length;
         code = Marshal.AllocHGlobal(info.code.Length);
         Marshal.Copy(info.code, 0, code, info.code.Length);
      }

      public void destroy()
      {
         Marshal.FreeHGlobal(code);
      }
   };

   [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
   public struct _WriteDescriptorSet
   {
      public VK.StructureType type;
      public IntPtr next;
      public VK.DescriptorSet dstSet;  //Destination descriptor set 
      public UInt32 dstBinding;  //Binding within the destination descriptor set to write 
      public UInt32 dstArrayElement;  //Array element within the destination binding to write 
      public UInt32 descriptorCount;  //Number of descriptors to write (determines the size of the array pointed by pDescriptors) 
      public VK.DescriptorType descriptorType;  //Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used) 
      public IntPtr pImageInfo;  //Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types. 
      public IntPtr pBufferInfo;  //Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types. 
      public IntPtr pTexelBufferView;  //Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types. 

      public _WriteDescriptorSet(VK.WriteDescriptorSet set)
      {
         type = set.type;
         next = set.next;
         dstSet = set.dstSet;
         dstBinding = set.dstBinding;
         dstArrayElement = set.dstArrayElement;
         descriptorCount = set.descriptorCount;
         descriptorType = set.descriptorType;
         pImageInfo = IntPtr.Zero;
         pBufferInfo = IntPtr.Zero;
         pTexelBufferView = IntPtr.Zero;

         switch(descriptorType)
         {
            case VK.DescriptorType.AccelerationStructureNv:
               throw new Exception("Not Supported yet");
               break;
            case VK.DescriptorType.CombinedImageSampler:
               pImageInfo = Alloc.alloc(set.imageInfo);
               break;
            case VK.DescriptorType.InlineUniformBlockExt:
               pBufferInfo = Alloc.alloc(set.bufferInfo);
               break;
            case VK.DescriptorType.InputAttachment:
               pImageInfo = Alloc.alloc(set.imageInfo);
               break;
            case VK.DescriptorType.SampledImage:
               pImageInfo = Alloc.alloc(set.imageInfo);
               break;
            case VK.DescriptorType.Sampler:
               pImageInfo = Alloc.alloc(set.imageInfo);
               break;
            case VK.DescriptorType.StorageBuffer:
               pBufferInfo = Alloc.alloc(set.bufferInfo);
               break;
            case VK.DescriptorType.StorageBufferDynamic:
               pBufferInfo = Alloc.alloc(set.bufferInfo);
               break;
            case VK.DescriptorType.StorageImage:
               pImageInfo = Alloc.alloc(set.imageInfo);
               break;
            case VK.DescriptorType.StorageTexelBuffer:
               pTexelBufferView = Alloc.alloc(set.texelBufferView);
               break;
            case VK.DescriptorType.UniformBuffer:
               pBufferInfo = Alloc.alloc(set.bufferInfo);
               break;
            case VK.DescriptorType.UniformBufferDynamic:
               pBufferInfo = Alloc.alloc(set.bufferInfo);
               break;
            case VK.DescriptorType.UniformTexelBuffer:
               pTexelBufferView = Alloc.alloc(set.texelBufferView);
               break;
         }
      }

      public void destory()
      {
         Alloc.free(pImageInfo);
         Alloc.free(pBufferInfo);
         Alloc.free(pTexelBufferView);
      }
   };

}