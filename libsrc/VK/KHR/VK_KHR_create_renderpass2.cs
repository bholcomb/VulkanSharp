using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vulkan
{
   public static partial class DeviceExtensions
   {
      public const string VK_KHR_create_renderpass2 = "VK_KHR_create_renderpass2";
   };
   
   public static partial class VK
   {
      #region enums
      #endregion

      #region flags
      #endregion

      #region structs
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AttachmentDescription2KHR
      {
         public StructureType type;
         public IntPtr Next;
         public AttachmentDescriptionFlags flags;
         public Format format;
         public SampleCountFlags samples;
         public AttachmentLoadOp loadOp;
         public AttachmentStoreOp storeOp;
         public AttachmentLoadOp stencilLoadOp;
         public AttachmentStoreOp stencilStoreOp;
         public ImageLayout initialLayout;
         public ImageLayout finalLayout;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct AttachmentReference2KHR
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 attachment;
         public ImageLayout layout;
         public ImageAspectFlags aspectMask;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct SubpassDescription2KHR
      {
         public StructureType type;
         public IntPtr next;
         public SubpassDescriptionFlags flags;
         public PipelineBindPoint pipelineBindPoint;
         public UInt32 viewMask;
         public UInt32 inputAttachmentCount;
         public AttachmentReference2KHR* pInputAttachments;
         public UInt32 colorAttachmentCount;
         public AttachmentReference2KHR* pColorAttachments;
         public AttachmentReference2KHR* pResolveAttachments;
         public AttachmentReference2KHR* pDepthStencilAttachment;
         public UInt32 preserveAttachmentCount;
         public IntPtr pPreserveAttachments;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassDependency2KHR
      {
         public StructureType type;
         public IntPtr next;
         public UInt32 srcSubpass;
         public UInt32 dstSubpass;
         public PipelineStageFlags srcStageMask;
         public PipelineStageFlags dstStageMask;
         public AccessFlags srcAccessMask;
         public AccessFlags dstAccessMask;
         public DependencyFlags dependencyFlags;
         public Int32 viewOffset;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public unsafe struct RenderPassCreateInfo2KHR
      {
         public StructureType type;
         public IntPtr next;
         public RenderPassCreateFlags flags;
         public UInt32 attachmentCount;
         public AttachmentDescription2KHR* pAttachments;
         public UInt32 subpassCount;
         public SubpassDescription2KHR* pSubpasses;
         public UInt32 dependencyCount;
         public SubpassDependency2KHR* pDependencies;
         public UInt32 correlatedViewMaskCount;
         public IntPtr pCorrelatedViewMasks;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassBeginInfoKHR
      {
         public StructureType type;
         public IntPtr next;
         public SubpassContents contents;
      };

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct SubpassEndInfoKHR
      {
         public StructureType type;
         public IntPtr next;
      };
      #endregion

      #region functions
      //external functions we need to get from the device
      //VkResult vkCreateRenderPass2KHR(VkDevice  device, const VkRenderPassCreateInfo2KHR *  pCreateInfo, const VkAllocationCallbacks *  pAllocator, VkRenderPass *  pRenderPass);
      //void vkCmdBeginRenderPass2KHR(VkCommandBuffer  commandBuffer, const VkRenderPassBeginInfo *  pRenderPassBegin, const VkSubpassBeginInfoKHR *  pSubpassBeginInfo);
      //void vkCmdNextSubpass2KHR(VkCommandBuffer  commandBuffer, const VkSubpassBeginInfoKHR *  pSubpassBeginInfo, const VkSubpassEndInfoKHR *  pSubpassEndInfo);
      //void vkCmdEndRenderPass2KHR(VkCommandBuffer  commandBuffer, const VkSubpassEndInfoKHR *  pSubpassEndInfo);
      
      //delegate definitions
      public delegate Result CreateRenderPass2KHRDelegate(Device device, ref RenderPassCreateInfo2KHR pCreateInfo, AllocationCallbacks pAllocator, ref RenderPass pRenderPasss);
      public delegate void CmdBeginRenderPass2KHRDelegate(CommandBuffer commandBuffer, ref RenderPassBeginInfo pRenderPassBegin, ref SubpassBeginInfoKHR pSubpassBeginInfos);
      public delegate void CmdNextSubpass2KHRDelegate(CommandBuffer commandBuffer, ref SubpassBeginInfoKHR pSubpassBeginInfo, ref SubpassEndInfoKHR pSubpassEndInfos);
      public delegate void CmdEndRenderPass2KHRDelegate(CommandBuffer commandBuffer, ref SubpassEndInfoKHR pSubpassEndInfos);
      
      //delegate instances
      public static CreateRenderPass2KHRDelegate CreateRenderPass2KHR;
      public static CmdBeginRenderPass2KHRDelegate CmdBeginRenderPass2KHR;
      public static CmdNextSubpass2KHRDelegate CmdNextSubpass2KHR;
      public static CmdEndRenderPass2KHRDelegate CmdEndRenderPass2KHR;
      #endregion

      #region interop
      public static class KHR_create_renderpass2
      {
         public static void init(VK.Device device)
         {
            VK.CreateRenderPass2KHR = ExternalFunction.getDeviceFunction<VK.CreateRenderPass2KHRDelegate>(device, "vkCreateRenderPass2KHR");
            VK.CmdBeginRenderPass2KHR = ExternalFunction.getDeviceFunction<VK.CmdBeginRenderPass2KHRDelegate>(device, "vkCmdBeginRenderPass2KHR");
            VK.CmdNextSubpass2KHR = ExternalFunction.getDeviceFunction<VK.CmdNextSubpass2KHRDelegate>(device, "vkCmdNextSubpass2KHR");
            VK.CmdEndRenderPass2KHR = ExternalFunction.getDeviceFunction<VK.CmdEndRenderPass2KHRDelegate>(device, "vkCmdEndRenderPass2KHR");
         }
      }
      #endregion
   }
}
