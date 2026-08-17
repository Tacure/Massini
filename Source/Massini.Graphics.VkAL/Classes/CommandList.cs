
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Classes.Commands;
using Massini.Graphics.VkAL.Classes.Encoders;
using Massini.Graphics.VkAL.Classes.Internal;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Extensions;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Structs.Level1.Internal;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class CommandList : IResource, IDisposable
    {
        /// <inheritdoc/>
        public ResId Id => m_id;

        public Device Device => m_queueFamily.Device;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        public QueueFamily QueueFamily => m_queueFamily;

        public ulong SignalValue => m_cbChainingSemaphoreSignalValue;

        public CommandList(QueueFamily i_queueFamily, in CommandListCreateParams i_createParams)
        {
            QueueFamily queueFamily = (QueueFamily)i_queueFamily;
            Device device = (Device)i_queueFamily.Device;

            VkCommandBufferAllocateInfo commandBufferAllocateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO,
                pNext = null,
                commandPool = queueFamily.VkCommandPoolPtr,
                level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY,
                commandBufferCount = 1,
            };

            VkCommandBuffer_T* commandBuffer = null;
            VkResult result = Vk.vkAllocateCommandBuffers(device.VkDevicePtr, &commandBufferAllocateInfo, &commandBuffer);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to allocate command buffers.");
            }

            // Create timeline semaphore.
            VkSemaphoreTypeCreateInfo semaphoreTypeCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO,
                pNext = null,
                initialValue = 0,
                semaphoreType = VkSemaphoreType.VK_SEMAPHORE_TYPE_TIMELINE,
            };

            VkSemaphoreCreateInfo semaphoreCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO,
                pNext = &semaphoreTypeCreateInfo,
                flags = 0,
            };

            VkSemaphore_T* semaphore = null;
            Vk.vkCreateSemaphore(device.VkDevicePtr, &semaphoreCreateInfo, null, &semaphore);

            VkUtils.SetObjectLabel(i_queueFamily.Device, commandBuffer, VkObjectType.VK_OBJECT_TYPE_COMMAND_BUFFER, $"{nameof(CommandList)} - {i_createParams.p_label}");
            VkUtils.SetObjectLabel(i_queueFamily.Device, semaphore, VkObjectType.VK_OBJECT_TYPE_SEMAPHORE, $"{nameof(CommandList)} - Semaphore - {i_createParams.p_label}");

            m_id = ResId.GetNextId();
            m_label = i_createParams.p_label;
            m_queueFamily = i_queueFamily;
            m_ptr_commandBuffer = commandBuffer;
            m_ptr_cbChainingTimelineSemaphore = semaphore;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)((QueueFamily)m_queueFamily).Device;

                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vk.vkDestroySemaphore(device.VkDevicePtr, m_ptr_cbChainingTimelineSemaphore, null);
                VkCommandBuffer_T* commandBuffer = m_ptr_commandBuffer;
                Vk.vkFreeCommandBuffers(device.VkDevicePtr, m_queueFamily.VkCommandPoolPtr, 1, &commandBuffer);
            }
        }

        public void WaitIdle()
        {
            VkSemaphore_T* semaphore = m_ptr_cbChainingTimelineSemaphore;
            ulong value = m_cbChainingSemaphoreSignalValue;
            VkSemaphoreWaitInfo semaphoreWaitInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO,
                pNext = null,
                flags = 0,
                pSemaphores = &semaphore,
                pValues = &value,
                semaphoreCount = 1,
            };

            Device device = m_queueFamily.Device;
        
            //device.Funcs.PfnVkWaitSemaphoresKhr(device.VkDevicePtr, &semaphoreWaitInfo, UInt64.MaxValue);
            Vk.vkWaitSemaphores(device.VkDevicePtr, &semaphoreWaitInfo, UInt64.MaxValue);
        }

        /// <summary>
        /// Opens the command list for recording. All previously recorded commands are discarded.
        /// </summary>
        /// <param name="i_beginParams"></param>
        public MainEncoder Open(in CommandListBeginParams i_beginParams)
        {
            m_isFlushed = false;

            if (m_mainEncoder != null)
            {
                m_encoderPool.Return(m_mainEncoder);
            }
            m_mainEncoder = m_encoderPool.Borrow<MainEncoder>();

            m_mainEncoder.SetOwner(this);

            return m_mainEncoder;
        }

        /// <summary>
        /// Writes all recorded commands to the command buffer.
        /// </summary>
        public void Flush()
        {
            m_isFlushed = true;
            Record();
        }

        public void Submit(in CommandListSubmitParams i_submitParams)
        {
            if (m_isFlushed == false)
            {
                Flush();
            }

            Queue queue = i_submitParams.p_queue;

            // Setup wait semaphores.

            uint waitCommandBufferCount = (uint)i_submitParams.p_waitCommandLists.Length;

            CommandListSemaphoreSubmitParams vkCommandBufferSubmitParams = default;
            uint waitBinarySemaphoreCount = 0;
            uint signalBinarySemaphoreCount = 0;
            if (i_submitParams.TryGetNext(out vkCommandBufferSubmitParams))
            {
                waitBinarySemaphoreCount = (uint)vkCommandBufferSubmitParams.p_waitBinarySemaphores.Length;
                signalBinarySemaphoreCount = (uint)vkCommandBufferSubmitParams.p_signalBinarySemaphores.Length;
            }

            Span<nuint> waitSemaphores = stackalloc nuint[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            Span<VkPipelineStageFlagBits> waitStages = stackalloc VkPipelineStageFlagBits[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            Span<ulong> waitValues = stackalloc ulong[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            for (int i = 0; i < waitBinarySemaphoreCount; i++)
            {
                waitStages[i] = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_ALL_COMMANDS_BIT;
                waitValues[i] = 0;
                waitSemaphores[i] = (nuint)vkCommandBufferSubmitParams.p_waitBinarySemaphores[i];
            }
            for (int i = (int)waitBinarySemaphoreCount; i < waitBinarySemaphoreCount + waitCommandBufferCount; i++)
            {
                CommandList commandBuffer = (CommandList)i_submitParams.p_waitCommandLists[i - (int)waitBinarySemaphoreCount];
                waitStages[i] = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_ALL_COMMANDS_BIT;
                waitValues[i] = commandBuffer.m_cbChainingSemaphoreSignalValue;
                waitSemaphores[i] = (nuint)commandBuffer.m_ptr_cbChainingTimelineSemaphore;
            }

            // Get execution completed wait value.
            Device device = m_queueFamily.Device;

            ulong signalValue = default;
            Vk.vkGetSemaphoreCounterValue(device.VkDevicePtr, m_ptr_cbChainingTimelineSemaphore, &signalValue);

            signalValue += 1;
            m_cbChainingSemaphoreSignalValue = signalValue;

            // Setup signal semaphores.

            // Add one for execution completed semaphore.
            Span<nuint> signalSemaphores = stackalloc nuint[(int)signalBinarySemaphoreCount + 1];
            Span<ulong> signalValues = stackalloc ulong[(int)signalBinarySemaphoreCount + 1];
            for (int i = 0; i < signalBinarySemaphoreCount; i++)
            {
                signalValues[i] = 0;
                signalSemaphores[i] = (nuint)vkCommandBufferSubmitParams.p_signalBinarySemaphores[i];
            }
            signalSemaphores[^1] = (nuint)m_ptr_cbChainingTimelineSemaphore;
            signalValues[^1] = m_cbChainingSemaphoreSignalValue;

            fixed (nuint* waitSemaphoresPtr = waitSemaphores, signalSemaphoresPtr = signalSemaphores)
            {
                fixed (VkPipelineStageFlagBits* waitStagesPtr = waitStages)
                {
                    fixed (ulong* waitValuesPtr = waitValues, signalValuesPtr = signalValues)
                    {
                        VkCommandBuffer_T* commandBufferPtr = m_ptr_commandBuffer;

                        VkTimelineSemaphoreSubmitInfo timelineSemaphoreSubmitInfo = new()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO,
                            pNext = null,
                            waitSemaphoreValueCount = (uint)waitValues.Length,
                            pWaitSemaphoreValues = waitValuesPtr,
                            signalSemaphoreValueCount = (uint)signalValues.Length,
                            pSignalSemaphoreValues = signalValuesPtr,
                        };

                        VkSubmitInfo submitInfo = new()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO,
                            pNext = &timelineSemaphoreSubmitInfo,
                            waitSemaphoreCount = (uint)waitSemaphores.Length,
                            pWaitSemaphores = (VkSemaphore_T**)waitSemaphoresPtr,
                            pWaitDstStageMask = (uint*)waitStagesPtr,
                            commandBufferCount = 1,
                            pCommandBuffers = &commandBufferPtr,
                            signalSemaphoreCount = (uint)signalSemaphores.Length,
                            pSignalSemaphores = (VkSemaphore_T**)signalSemaphoresPtr,
                        };

                        Vk.vkQueueSubmit(queue.VkQueuePtr, 1, &submitInfo, null);
                    }
                }
            }
        }
    }

    public unsafe partial class CommandList 
    {
        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly QueueFamily m_queueFamily;
        private readonly VkCommandBuffer_T* m_ptr_commandBuffer;
        private readonly VkSemaphore_T* m_ptr_cbChainingTimelineSemaphore;
        private ulong m_cbChainingSemaphoreSignalValue = 0;
        private bool m_isFlushed = false;
        private readonly EncoderPool m_encoderPool = new();
        private MainEncoder? m_mainEncoder = null;
        private ShaderLink? m_boundShaderLink = null;

        private void CmdImageBarrier(Texture i_texture, VkImageLayout i_newLayout, VkAccessFlagBits i_dstAccessMask, VkPipelineStageFlagBits i_dstStageMask, Span<ulong> i_layerMasks)
        {
            Texture texture = i_texture;

            if (i_layerMasks.Length != texture.ArrayLayersCount)
            {
                throw new ArgumentException("i_layerMasks.Length should be equal to texture.ArrayLayers.");
            }

            VkImageMemoryBarrier2[] barriers = new VkImageMemoryBarrier2[texture.ArrayLayersCount * texture.MipLevelCount];
            uint usedBarriers = 0; // Keeps track of how many barriers are actually used.
            for (int layerIdx = 0; layerIdx < texture.ArrayLayersCount; layerIdx++)
            {
                // Filter layer if no mip levels need to be transitioned.
                ulong mask = i_layerMasks[layerIdx];
                if (mask == 0) continue;

                for (int mipIdx = 0; mipIdx < texture.MipLevelCount; mipIdx++)
                {
                    // Check bit mask if bit equals 1 (ONE).
                    if ((mask & (1UL << mipIdx)) == 0UL) continue;

                    ref TextureBarrierState.TextureSubresourceBarrierState subresourceState = ref texture.LayerBarriers.GetState((uint)layerIdx, (uint)mipIdx);

                    if (subresourceState.p_layout == i_newLayout && 
                        subresourceState.p_accessMask == i_dstAccessMask &&
                        subresourceState.p_stageMask == i_dstStageMask) continue;
                    
                    barriers[usedBarriers] = new()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2,
                        srcStageMask = (ulong)subresourceState.p_stageMask,
                        dstStageMask = (ulong)i_dstStageMask,
                        srcAccessMask = (ulong)subresourceState.p_accessMask,
                        dstAccessMask = (ulong)i_dstAccessMask,
                        oldLayout = subresourceState.p_layout,
                        newLayout = i_newLayout,
                        srcQueueFamilyIndex = Vk.VK_QUEUE_FAMILY_IGNORED,
                        dstQueueFamilyIndex = Vk.VK_QUEUE_FAMILY_IGNORED,
                        image = texture.VkImagePtr,
                        subresourceRange = new()
                        {
                            aspectMask = (uint)VkUtils.GuessVkImageAspectMask(texture.VkFormat),
                            baseArrayLayer = (uint)layerIdx,
                            levelCount = 1,
                            baseMipLevel = (uint)mipIdx,
                            layerCount = 1,
                        },
                    };

                    subresourceState.p_layout = i_newLayout;
                    subresourceState.p_accessMask = i_dstAccessMask;
                    subresourceState.p_stageMask = i_dstStageMask;

                    usedBarriers++;
                }
            }

            if (usedBarriers == 0) return;

            fixed (VkImageMemoryBarrier2* barriersPtr = barriers)
            {
                VkDependencyInfo dependencyInfo = new()
                {
                    pNext = null,
                    sType = VkStructureType.VK_STRUCTURE_TYPE_DEPENDENCY_INFO,
                    bufferMemoryBarrierCount = 0,
                    pBufferMemoryBarriers = null,
                    imageMemoryBarrierCount = usedBarriers,
                    pImageMemoryBarriers = barriersPtr,
                    memoryBarrierCount = 0,
                    pMemoryBarriers = null,  
                };

                Vk.vkCmdPipelineBarrier2(m_ptr_commandBuffer, &dependencyInfo);
            }
        }

        private void CmdBufferBarrier(Buffer i_buffer, VkAccessFlagBits i_dstAccessMask, VkPipelineStageFlagBits i_dstStageMask)
        {
            Buffer buffer = (Buffer)i_buffer;

            if (buffer.VkAccessMask == i_dstAccessMask && buffer.VkStageMask == i_dstStageMask) return;

            VkBufferMemoryBarrier bufferMemoryBarrier = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER,
                pNext = null,
                srcAccessMask = (uint)buffer.VkAccessMask,
                dstAccessMask = (uint)i_dstAccessMask,
                srcQueueFamilyIndex = Vk.VK_QUEUE_FAMILY_IGNORED,
                dstQueueFamilyIndex = Vk.VK_QUEUE_FAMILY_IGNORED,
                buffer = buffer.VkBufferPtr,
                offset = 0,
                size = i_buffer.Size,
            };

            Vk.vkCmdPipelineBarrier(
                m_ptr_commandBuffer,
                (uint)buffer.VkStageMask,
                (uint)i_dstStageMask,
                0,
                0, null,
                1, &bufferMemoryBarrier,
                0, null);

            buffer.VkStageMask = i_dstStageMask;
            buffer.VkAccessMask = i_dstAccessMask;
        }

        private void Record()
        {
            MainEncoder mainEncoder = m_mainEncoder!;

            // Remove bound shader link.
            m_boundShaderLink = null;

            // Lock pool.
            lock (m_queueFamily.PoolLock)
            {
                // Reset command buffer before recording.
                Vk.vkResetCommandBuffer(m_ptr_commandBuffer, (uint)VkCommandBufferResetFlagBits.VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT);

                VkCommandBufferBeginInfo beginInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO,
                    flags = 0,
                    pNext = null,
                    pInheritanceInfo = null,
                };
                Vk.vkBeginCommandBuffer(m_ptr_commandBuffer, &beginInfo);

                // Record commands.
                foreach (Command command in mainEncoder.Commands)
                {
                    switch (command.CommandKind)
                    {
                        case VirtualCommandKind.CmdRenderPass:
                            HandleCmdRenderPass((CmdRenderPass)command);
                            break;
                        case VirtualCommandKind.CmdComputePass:
                            HandleCmdComputePass((CmdComputePass)command);
                            break;
                        case VirtualCommandKind.CmdCopyBufferToTexture:
                            HandleCmdCopyBufferToTexture((CmdCopyBufferToTexture)command);
                            break;
                        case VirtualCommandKind.CmdCopyBufferToBuffer:
                            HandleCmdCopyBufferToBuffer((CmdCopyBufferToBuffer)command);
                            break;
                        case VirtualCommandKind.CmdCopyTextureToBuffer:
                            HandleCmdCopyTextureToBuffer((CmdCopyTextureToBuffer)command);
                            break;
                        case VirtualCommandKind.CmdCopyTextureToTexture:
                            HandleCmdCopyTextureToTexture((CmdCopyTextureToTexture)command);
                            break;
                        case VirtualCommandKind.CmdBlitTexture:
                            HandleCmdBlitTexture((CmdBlitTexture)command);
                            break;
                        default: throw new Exception($"Unsupported command type: {command.CommandKind}");
                    }
                }

                // Close command buffer.
                Vk.vkEndCommandBuffer(m_ptr_commandBuffer);
            }
        }

        private void HandleCmdRenderPass(CmdRenderPass i_cmdRenderPass)
        {
            ref RenderPassBeginParams renderPassBeginParams = ref i_cmdRenderPass.p_beginParams;

            VkRenderingAttachmentInfo[] colorAttachments = new VkRenderingAttachmentInfo[renderPassBeginParams.p_colorAttachments.Length];

            uint width = 0;
            uint height = 0;

            for (int i = 0; i < renderPassBeginParams.p_colorAttachments.Length; i++)
            {
                ref RenderPassColorAttachment renderPassColorAttachment = ref renderPassBeginParams.p_colorAttachments[i];

                VkClearColorValue clearColorValue = new();
                clearColorValue.float32[0] = renderPassColorAttachment.p_clearColor.p_r;
                clearColorValue.float32[1] = renderPassColorAttachment.p_clearColor.p_g;
                clearColorValue.float32[2] = renderPassColorAttachment.p_clearColor.p_b;
                clearColorValue.float32[3] = renderPassColorAttachment.p_clearColor.p_a;

                TextureView textureView = (TextureView)renderPassColorAttachment.p_textureView;

                ulong[] masks = new ulong[textureView.Texture.ArrayLayersCount];
                for (int j = 0; j < textureView.Texture.ArrayLayersCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    textureView.Texture,
                    VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                    VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                    masks);

                width = textureView.Texture.Width;
                height = textureView.Texture.Height;

                VkRenderingAttachmentInfo colorAttachment = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                    loadOp = VkUtils.LoadOpToVkAttachmentLoadOp(renderPassColorAttachment.p_loadOp),
                    storeOp = VkUtils.StoreOpToVkAttachmentStoreOp(renderPassColorAttachment.p_storeOp),
                    clearValue = new()
                    {
                        color = clearColorValue,
                    },
                };

                colorAttachments[i] = colorAttachment;
            }

            bool hasDepthStencilAttachment = renderPassBeginParams.p_depthStencilAttachment.HasValue;
            VkRenderingAttachmentInfo depthAttachment = default;
            if (renderPassBeginParams.p_depthStencilAttachment.HasValue)
            {
                RenderPassDepthStencilAttachment renderPassDepthStencilAttachment = renderPassBeginParams.p_depthStencilAttachment.Value;

                TextureView textureView = (TextureView)renderPassDepthStencilAttachment.p_textureView;

                depthAttachment = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                    loadOp = VkUtils.LoadOpToVkAttachmentLoadOp(renderPassDepthStencilAttachment.p_depthLoadOp),
                    storeOp = VkUtils.StoreOpToVkAttachmentStoreOp(renderPassDepthStencilAttachment.p_depthStoreOp),
                    clearValue = new()
                    {
                        depthStencil = new()
                        {
                            depth = 1.0f,
                            stencil = 0,
                        },
                    },
                };

                ulong[] masks = new ulong[textureView.Texture.ArrayLayersCount];
                for (int j = 0; j < textureView.Texture.ArrayLayersCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    textureView.Texture,
                    VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                    VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT,
                    masks);
            }

            VkRenderingAttachmentInfo stencilAttachment = default;
            if (renderPassBeginParams.p_depthStencilAttachment.HasValue)
            {
                RenderPassDepthStencilAttachment renderPassDepthStencilAttachment = renderPassBeginParams.p_depthStencilAttachment.Value;

                TextureView textureView = (TextureView)renderPassDepthStencilAttachment.p_textureView;

                stencilAttachment = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                    loadOp = VkUtils.LoadOpToVkAttachmentLoadOp(renderPassDepthStencilAttachment.p_stencilLoadOp),
                    storeOp = VkUtils.StoreOpToVkAttachmentStoreOp(renderPassDepthStencilAttachment.p_stencilStoreOp),
                    clearValue = new()
                    {
                        depthStencil = new()
                        {
                            depth = 1.0f,
                            stencil = 0,
                        },
                    },
                };
            }

            // Index buffer barriers.
            foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindIndexBuffer>())
            {
                CmdBufferBarrier(
                    cmd.p_buffer!,
                    VkAccessFlagBits.VK_ACCESS_INDEX_READ_BIT,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_VERTEX_INPUT_BIT);
            }

            // Vertex buffer barriers.
            foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindVertexBuffer>())
            {
                CmdBufferBarrier(
                    cmd.p_buffer!,
                    VkAccessFlagBits.VK_ACCESS_VERTEX_ATTRIBUTE_READ_BIT,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_VERTEX_INPUT_BIT);
            }

            // Bindings barriers.
            foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindSets>())
            {
                HandleSetBarriers(cmd.p_pipelineSets);
            }

            // Push bindings barriers.
            foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdPushSet>()) 
            {
                HandlePushSetBarriers(cmd.p_bindingDescription);
            }

            fixed (VkRenderingAttachmentInfo* colorAttachmentsPtr = colorAttachments)
            {
                VkRenderingInfo renderingInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_INFO,
                    renderArea = new()
                    {
                        offset = new() { x = 0, y = 0 },
                        extent = new() { width = width, height = height },
                    },
                    layerCount = 1,
                    colorAttachmentCount = (uint)colorAttachments.Length,
                    pColorAttachments = colorAttachmentsPtr,
                    pDepthAttachment = hasDepthStencilAttachment ? &depthAttachment : null,
                    pStencilAttachment = hasDepthStencilAttachment ? &stencilAttachment : null,
                };

                Vk.vkCmdBeginRendering(m_ptr_commandBuffer, &renderingInfo);
            }

            // Record render pass commands.
            foreach (Command command in i_cmdRenderPass.p_encoder!.Commands)
            {
                switch (command.CommandKind)
                {
                    case VirtualCommandKind.CmdSetScissorRect:
                        HandleCmdSetScissorRect((CmdSetScissorRect)command);
                        break;
                    case VirtualCommandKind.CmdSetViewport:
                        HandleCmdSetViewport((CmdSetViewport)command);
                        break;
                    case VirtualCommandKind.CmdBindSets:
                        HandleCmdBindSets((CmdBindSets)command, false);
                        break;
                    case VirtualCommandKind.CmdPushSet:
                        HandleCmdPushSet((CmdPushSet)command, false);
                        break;
                    case VirtualCommandKind.CmdPushConstant:
                        HandleCmdPushConstant((CmdPushConstant)command);
                        break;
                    case VirtualCommandKind.CmdBindIndexBuffer:
                        HandleCmdBindIndexBuffer((CmdBindIndexBuffer)command);
                        break;
                    case VirtualCommandKind.CmdBindVertexBuffer:
                        HandleCmdBindVertexBuffer((CmdBindVertexBuffer)command);
                        break;
                    case VirtualCommandKind.CmdDraw:
                        HandleCmdDraw((CmdDraw)command);
                        break;
                    case VirtualCommandKind.CmdDrawIndexed:
                        HandleCmdDrawIndexed((CmdDrawIndexed)command);
                        break;
                    case VirtualCommandKind.CmdBindShaderLink:
                        HandleCmdBindShaderLink((CmdBindShaderLink)command);
                        break;
                    case VirtualCommandKind.CmdSetCullMode:
                        HandleCmdSetCullMode((CmdSetCullMode)command);
                        break;
                    case VirtualCommandKind.CmdSetRasterizerDiscardEnable:
                        HandleCmdSetRasterizerDiscardEnable((CmdSetRasterizerDiscardEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetDepthTestEnable:
                        HandleCmdSetDepthTestEnable((CmdSetDepthTestEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetStencilTestEnable:
                        HandleCmdSetStencilTestEnable((CmdSetStencilTestEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetDepthBiasEnable:
                        HandleCmdSetDepthBiasEnable((CmdSetDepthBiasEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetPolygonMode:
                        HandleCmdSetPolygonMode((CmdSetPolygonMode)command);
                        break;
                    case VirtualCommandKind.CmdSetRasterizationSamples:
                        HandleCmdSetRasterizationSamples((CmdSetRasterizationSamples)command);
                        break;
                    case VirtualCommandKind.CmdSetSampleMask:
                        HandleCmdSetSampleMask((CmdSetSampleMask)command);
                        break;
                    case VirtualCommandKind.CmdSetFrontFace:
                        HandleCmdSetFrontFace((CmdSetFrontFace)command);
                        break;
                    case VirtualCommandKind.CmdSetPrimitiveTopology:
                        HandleCmdSetPrimitiveTopology((CmdSetPrimitiveTopology)command);
                        break;
                    case VirtualCommandKind.CmdSetPrimitiveRestartEnable:
                        HandleCmdSetPrimitiveRestartEnable((CmdSetPrimitiveRestartEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetDepthClampEnable:
                        HandleCmdSetDepthClampEnable((CmdSetDepthClampEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetAlphaToCoverageEnable:
                        HandleCmdSetAlphaToCoverageEnable((CmdSetAlphaToCoverageEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetColorBlendEnable:
                        HandleCmdSetColorBlendEnable((CmdSetColorBlendEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetColorWriteMask:
                        HandleCmdSetColorWriteMask((CmdSetColorWriteMask)command);
                        break;
                    case VirtualCommandKind.CmdSetVertexInput:
                        HandleCmdSetVertexInput((CmdSetVertexInput)command);
                        break;
                    case VirtualCommandKind.CmdSetColorBlendEquation:
                        HandleCmdSetColorBlendEquation((CmdSetColorBlendEquation)command);
                        break;
                    case VirtualCommandKind.CmdSetDepthCompareOp:
                        HandleCmdSetDepthCompareOp((CmdSetDepthCompareOp)command);
                        break;
                    case VirtualCommandKind.CmdSetDepthWriteEnable:
                        HandleCmdSetDepthWriteEnable((CmdSetDepthWriteEnable)command);
                        break;
                    case VirtualCommandKind.CmdSetLineWidth:
                        HandleCmdSetLineWidth((CmdSetLineWidth)command);
                        break;
                    default: throw new Exception($"Unsupported command type: {command.CommandKind}");
                }
            }

            // End render pass.
            Vk.vkCmdEndRendering(m_ptr_commandBuffer);

            // Transition color attachments to present.
            for (int i = 0; i < i_cmdRenderPass.p_beginParams.p_colorAttachments.Length; i++)
            {
                TextureView textureView = i_cmdRenderPass.p_beginParams.p_colorAttachments[i].p_textureView;

                ulong[] masks = new ulong[textureView.Texture.ArrayLayersCount];
                for (int j = 0; j < textureView.Texture.ArrayLayersCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    textureView.Texture,
                    VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR,
                    VkAccessFlagBits.VK_ACCESS_NONE,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT,
                    masks);
            }
        }

        private void HandleCmdComputePass(CmdComputePass i_cmdComputePass)
        {
            // Bindings barriers.
            foreach (var cmd in i_cmdComputePass.p_encoder!.Commands.OfType<CmdBindSets>())
            {
                HandleSetBarriers(cmd.p_pipelineSets);
            }

            // Push bindings barriers.
            foreach (var cmd in i_cmdComputePass.p_encoder!.Commands.OfType<CmdPushSet>())
            {
                HandlePushSetBarriers(cmd.p_bindingDescription);
            }

            // Record compute pass commands.
            foreach (Command command in i_cmdComputePass.p_encoder!.Commands)
            {
                switch (command.CommandKind)
                {
                    case VirtualCommandKind.CmdBindShaderLink:
                        HandleCmdBindShaderLink((CmdBindShaderLink)command);
                        break;
                    case VirtualCommandKind.CmdBindSets:
                        HandleCmdBindSets((CmdBindSets)command, true);
                        break;
                    case VirtualCommandKind.CmdPushSet:
                        HandleCmdPushSet((CmdPushSet)command, true);
                        break;
                    case VirtualCommandKind.CmdPushConstant:
                        HandleCmdPushConstant((CmdPushConstant)command);
                        break;
                    case VirtualCommandKind.CmdDispatch:
                        HandleCmdDispatch((CmdDispatch)command);
                        break;
                    default: throw new Exception($"Unsupported command type: {command.CommandKind}");
                }
            }
        }

        private void HandleCmdCopyBufferToTexture(CmdCopyBufferToTexture i_cmdCopyBufferToTexture)
        {
            Buffer srcBuffer = i_cmdCopyBufferToTexture.p_srcBuffer!;
            Texture dstTexture = i_cmdCopyBufferToTexture.p_dstTexture!;

            CmdBufferBarrier(
                srcBuffer,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_READ_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT);

            ulong[] dstMasks = new ulong[dstTexture.ArrayLayersCount];
            VkUtils.FillTextureBarrierMipmapsBitmaskToAll(dstMasks);

            CmdImageBarrier(
                dstTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_WRITE_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                dstMasks);

            Span<VkBufferImageCopy> vkBufferImageCopies = stackalloc VkBufferImageCopy[i_cmdCopyBufferToTexture.p_regions.Length];
            for (int i = 0; i < i_cmdCopyBufferToTexture.p_regions.Length; i++)
            {
                vkBufferImageCopies[i] = new()
                {
                    bufferOffset = i_cmdCopyBufferToTexture.p_regions[i].p_bufferOffset,
                    imageExtent = new()
                    {
                        width = i_cmdCopyBufferToTexture.p_regions[i].p_textureExtent.Width,
                        height = i_cmdCopyBufferToTexture.p_regions[i].p_textureExtent.Height,
                        depth = i_cmdCopyBufferToTexture.p_regions[i].p_textureExtent.Depth,
                    },
                    bufferImageHeight = i_cmdCopyBufferToTexture.p_regions[i].p_bufferTextureHeightInTexels,
                    bufferRowLength = i_cmdCopyBufferToTexture.p_regions[i].p_bufferRowLengthInTexels,
                    imageOffset = new()
                    {
                        x = i_cmdCopyBufferToTexture.p_regions[i].p_textureOffset.p_x,
                        y = i_cmdCopyBufferToTexture.p_regions[i].p_textureOffset.p_y,
                        z = i_cmdCopyBufferToTexture.p_regions[i].p_textureOffset.p_z,
                    },
                    imageSubresource = new()
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdCopyBufferToTexture.p_regions[i].p_textureSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdCopyBufferToTexture.p_regions[i].p_textureSubresource.p_baseArrayLayer,
                        layerCount = i_cmdCopyBufferToTexture.p_regions[i].p_textureSubresource.p_layerCount,
                        mipLevel = i_cmdCopyBufferToTexture.p_regions[i].p_textureSubresource.p_mipLevel,
                    },
                };
            }

            fixed (VkBufferImageCopy* vkBufferImageCopiesPtr = vkBufferImageCopies)
            {
                Vk.vkCmdCopyBufferToImage(
                    m_ptr_commandBuffer, 
                    srcBuffer.VkBufferPtr, 
                    dstTexture.VkImagePtr, 
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 
                    (uint)vkBufferImageCopies.Length, 
                    vkBufferImageCopiesPtr);
            }
        }

        private void HandleCmdCopyTextureToTexture(CmdCopyTextureToTexture i_cmdCopyTextureToTexture)
        {
            Texture srcTexture = i_cmdCopyTextureToTexture.p_srcTexture!;
            Texture dstTexture = i_cmdCopyTextureToTexture.p_dstTexture!;

            ulong[] srcMasks = new ulong[srcTexture.ArrayLayersCount];
            ulong[] dstMasks = new ulong[dstTexture.ArrayLayersCount];

            Span<VkImageCopy> vkImageCopies = stackalloc VkImageCopy[i_cmdCopyTextureToTexture.p_regions.Length];
            for (int i = 0; i < i_cmdCopyTextureToTexture.p_regions.Length; i++)
            {
                ref TextureCopy region = ref i_cmdCopyTextureToTexture.p_regions[i];
                VkUtils.FillTextureBarrierMipmapsBitmask(in region.p_srcSubresource, srcMasks);
                VkUtils.FillTextureBarrierMipmapsBitmask(in region.p_dstSubresource, dstMasks);

                vkImageCopies[i] = new()
                {
                    extent = new()
                    {
                        width = i_cmdCopyTextureToTexture.p_regions[i].p_extent.Width,
                        height = i_cmdCopyTextureToTexture.p_regions[i].p_extent.Height,
                        depth = i_cmdCopyTextureToTexture.p_regions[i].p_extent.Depth,
                    },
                    srcOffset = new()
                    {
                        x = i_cmdCopyTextureToTexture.p_regions[i].p_srcOffset.p_x,
                        y = i_cmdCopyTextureToTexture.p_regions[i].p_srcOffset.p_y,
                        z = i_cmdCopyTextureToTexture.p_regions[i].p_srcOffset.p_z,
                    },
                    dstOffset = new()
                    {
                        x = i_cmdCopyTextureToTexture.p_regions[i].p_dstOffset.p_x,
                        y = i_cmdCopyTextureToTexture.p_regions[i].p_dstOffset.p_y,
                        z = i_cmdCopyTextureToTexture.p_regions[i].p_dstOffset.p_z,
                    },
                    srcSubresource = new()
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdCopyTextureToTexture.p_regions[i].p_srcSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdCopyTextureToTexture.p_regions[i].p_srcSubresource.p_baseArrayLayer,
                        layerCount = i_cmdCopyTextureToTexture.p_regions[i].p_srcSubresource.p_layerCount,
                        mipLevel = i_cmdCopyTextureToTexture.p_regions[i].p_srcSubresource.p_mipLevel,
                    },
                    dstSubresource = new()
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdCopyTextureToTexture.p_regions[i].p_dstSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdCopyTextureToTexture.p_regions[i].p_dstSubresource.p_baseArrayLayer,
                        layerCount = i_cmdCopyTextureToTexture.p_regions[i].p_dstSubresource.p_layerCount,
                        mipLevel = i_cmdCopyTextureToTexture.p_regions[i].p_dstSubresource.p_mipLevel,
                    },
                };
            }

            CmdImageBarrier(
                srcTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_READ_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                srcMasks);

            CmdImageBarrier(
                dstTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_WRITE_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                dstMasks);

            fixed (VkImageCopy* vkImageCopiesPtr = vkImageCopies)
            {
                Vk.vkCmdCopyImage(
                    m_ptr_commandBuffer, 
                    srcTexture.VkImagePtr, 
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, 
                    dstTexture.VkImagePtr, 
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 
                    (uint)vkImageCopies.Length, 
                    vkImageCopiesPtr);
            }
        }

        private void HandleCmdCopyTextureToBuffer(CmdCopyTextureToBuffer i_cmdCopyTextureToBuffer)
        {
            Texture srcTexture = i_cmdCopyTextureToBuffer.p_srcTexture!;
            Buffer dstBuffer = i_cmdCopyTextureToBuffer.p_dstBuffer!;

            ulong[] srcMasks = new ulong[srcTexture.ArrayLayersCount];
            VkUtils.FillTextureBarrierMipmapsBitmaskToAll(srcMasks);

            CmdImageBarrier(
                srcTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_READ_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                srcMasks);

            CmdBufferBarrier(
                dstBuffer,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_WRITE_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT);

            Span<VkBufferImageCopy> vkBufferImageCopies = stackalloc VkBufferImageCopy[i_cmdCopyTextureToBuffer.p_regions.Length];
            for (int i = 0; i < i_cmdCopyTextureToBuffer.p_regions.Length; i++)
            {
                vkBufferImageCopies[i] = new()
                {
                    bufferOffset = i_cmdCopyTextureToBuffer.p_regions[i].p_bufferOffset,
                    imageExtent = new()
                    {
                        width = i_cmdCopyTextureToBuffer.p_regions[i].p_textureExtent.Width,
                        height = i_cmdCopyTextureToBuffer.p_regions[i].p_textureExtent.Height,
                        depth = i_cmdCopyTextureToBuffer.p_regions[i].p_textureExtent.Depth,
                    },
                    bufferImageHeight = i_cmdCopyTextureToBuffer.p_regions[i].p_bufferTextureHeightInTexels,
                    bufferRowLength = i_cmdCopyTextureToBuffer.p_regions[i].p_bufferRowLengthInTexels,
                    imageOffset = new()
                    {
                        x = i_cmdCopyTextureToBuffer.p_regions[i].p_textureOffset.p_x,
                        y = i_cmdCopyTextureToBuffer.p_regions[i].p_textureOffset.p_y,
                        z = i_cmdCopyTextureToBuffer.p_regions[i].p_textureOffset.p_z,
                    },
                    imageSubresource = new()
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdCopyTextureToBuffer.p_regions[i].p_textureSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdCopyTextureToBuffer.p_regions[i].p_textureSubresource.p_baseArrayLayer,
                        layerCount = i_cmdCopyTextureToBuffer.p_regions[i].p_textureSubresource.p_layerCount,
                        mipLevel = i_cmdCopyTextureToBuffer.p_regions[i].p_textureSubresource.p_mipLevel,
                    },
                };
            }

            fixed (VkBufferImageCopy* vkBufferImageCopiesPtr = vkBufferImageCopies)
            {
                Vk.vkCmdCopyImageToBuffer(
                    m_ptr_commandBuffer, 
                    srcTexture.VkImagePtr, 
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, 
                    dstBuffer.VkBufferPtr, 
                    (uint)vkBufferImageCopies.Length, 
                    vkBufferImageCopiesPtr);
            }
        }

        private void HandleCmdCopyBufferToBuffer(CmdCopyBufferToBuffer i_cmdCopyBufferToBuffer)
        {
            Buffer srcBuffer = i_cmdCopyBufferToBuffer.p_srcBuffer!;
            Buffer dstBuffer = i_cmdCopyBufferToBuffer.p_dstBuffer!;

            CmdBufferBarrier(
                srcBuffer,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_READ_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT);

            CmdBufferBarrier(
                dstBuffer,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_WRITE_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT);

            Span<VkBufferCopy> vkBufferCopies = stackalloc VkBufferCopy[i_cmdCopyBufferToBuffer.p_bufferCopies.Length];
            for (int i = 0; i < i_cmdCopyBufferToBuffer.p_bufferCopies.Length; i++)
            {
                vkBufferCopies[i] = new()
                {
                    size = i_cmdCopyBufferToBuffer.p_bufferCopies[i].p_size,
                    dstOffset = i_cmdCopyBufferToBuffer.p_bufferCopies[i].p_dstOffset,
                    srcOffset = i_cmdCopyBufferToBuffer.p_bufferCopies[i].p_srcOffset,
                };
            }

            fixed (VkBufferCopy* vkBufferCopiesPtr = vkBufferCopies)
            {
                Vk.vkCmdCopyBuffer(m_ptr_commandBuffer, srcBuffer.VkBufferPtr, dstBuffer.VkBufferPtr, (uint)vkBufferCopies.Length, vkBufferCopiesPtr);
            }
        }

        private void HandleCmdBlitTexture(CmdBlitTexture i_cmdBlitTexture)
        {
            Texture srcTexture = i_cmdBlitTexture.p_srcTexture!;
            Texture dstTexture = i_cmdBlitTexture.p_dstTexture!;

            ulong[] srcMasks = new ulong[srcTexture.ArrayLayersCount];
            ulong[] dstMasks = new ulong[dstTexture.ArrayLayersCount];

            VkImageBlit[] vkRegions = new VkImageBlit[i_cmdBlitTexture.p_regions.Length];
            for (int i = 0; i < i_cmdBlitTexture.p_regions.Length; i++) 
            {
                ref TextureBlit region = ref i_cmdBlitTexture.p_regions[i];
                VkUtils.FillTextureBarrierMipmapsBitmask(in region.p_srcSubresource, srcMasks);
                VkUtils.FillTextureBarrierMipmapsBitmask(in region.p_dstSubresource, dstMasks);

                vkRegions[i] = new()
                {
                    srcSubresource = new()
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdBlitTexture.p_regions[i].p_srcSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdBlitTexture.p_regions[i].p_srcSubresource.p_baseArrayLayer,
                        layerCount = i_cmdBlitTexture.p_regions[i].p_srcSubresource.p_layerCount,
                        mipLevel = i_cmdBlitTexture.p_regions[i].p_srcSubresource.p_mipLevel,
                    },
                    dstSubresource = new() 
                    {
                        aspectMask = (uint)VkUtils.TextureAspectFlagsToVkImageAspectFlagBits(i_cmdBlitTexture.p_regions[i].p_dstSubresource.p_aspectMask),
                        baseArrayLayer = i_cmdBlitTexture.p_regions[i].p_dstSubresource.p_baseArrayLayer,
                        layerCount = i_cmdBlitTexture.p_regions[i].p_dstSubresource.p_layerCount,
                        mipLevel = i_cmdBlitTexture.p_regions[i].p_dstSubresource.p_mipLevel,
                    },
                };

                vkRegions[i].srcOffsets[0] = new()
                {
                    x = i_cmdBlitTexture.p_regions[i].p_srcOffsetA.p_x,
                    y = i_cmdBlitTexture.p_regions[i].p_srcOffsetA.p_y,
                    z = i_cmdBlitTexture.p_regions[i].p_srcOffsetA.p_z,
                };

                vkRegions[i].srcOffsets[1] = new()
                {
                    x = i_cmdBlitTexture.p_regions[i].p_srcOffsetB.p_x,
                    y = i_cmdBlitTexture.p_regions[i].p_srcOffsetB.p_y,
                    z = i_cmdBlitTexture.p_regions[i].p_srcOffsetB.p_z,
                };

                vkRegions[i].dstOffsets[0] = new()
                {
                    x = i_cmdBlitTexture.p_regions[i].p_dstOffsetA.p_x,
                    y = i_cmdBlitTexture.p_regions[i].p_dstOffsetA.p_y,
                    z = i_cmdBlitTexture.p_regions[i].p_dstOffsetA.p_z,
                };

                vkRegions[i].dstOffsets[1] = new()
                {
                    x = i_cmdBlitTexture.p_regions[i].p_dstOffsetB.p_x,
                    y = i_cmdBlitTexture.p_regions[i].p_dstOffsetB.p_y,
                    z = i_cmdBlitTexture.p_regions[i].p_dstOffsetB.p_z,
                };
            }

            CmdImageBarrier(
                srcTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_READ_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                srcMasks);

            CmdImageBarrier(
                dstTexture,
                VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                VkAccessFlagBits.VK_ACCESS_TRANSFER_WRITE_BIT,
                VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TRANSFER_BIT,
                dstMasks);

            fixed (VkImageBlit* vkRegionsPtr = vkRegions)
            {
                Vk.vkCmdBlitImage(
                    m_ptr_commandBuffer,
                    srcTexture.VkImagePtr,
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                    dstTexture.VkImagePtr,
                    VkImageLayout.VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                    (uint)i_cmdBlitTexture.p_regions.Length,
                    vkRegionsPtr,
                    VkUtils.FilterModeToVkFilter(i_cmdBlitTexture.p_filterMode));
            }
        }

        private void HandleCmdSetScissorRect(CmdSetScissorRect i_cmdSetScissorRect)
        {
            VkRect2D scissor = new()
            {
                offset = new() { x = (int)i_cmdSetScissorRect.p_x, y = (int)i_cmdSetScissorRect.p_y },
                extent = new() { width = i_cmdSetScissorRect.p_width, height = i_cmdSetScissorRect.p_height },
            };
            
            //QueueFamily.Device.Funcs.PfnVkCmdSetScissorWithCountExt(m_ptr_commandBuffer, 1, &scissor);
            Vk.vkCmdSetScissorWithCount(m_ptr_commandBuffer, 1, &scissor);
        }

        private void HandleCmdSetViewport(CmdSetViewport i_cmdSetViewport)
        {
            VkViewport viewport = new()
            {
                x = i_cmdSetViewport.p_x,
                y = i_cmdSetViewport.p_y + i_cmdSetViewport.p_height,
                width = i_cmdSetViewport.p_width,
                height = -i_cmdSetViewport.p_height,
                minDepth = i_cmdSetViewport.p_minDepth,
                maxDepth = i_cmdSetViewport.p_maxDepth,
            };
            //QueueFamily.Device.Funcs.PfnVkCmdSetViewportWithCountExt(m_ptr_commandBuffer, 1, &viewport);
            Vk.vkCmdSetViewportWithCount(m_ptr_commandBuffer, 1, &viewport);
        }

        private void HandleCmdDrawIndexed(CmdDrawIndexed i_cmdDrawIndexed)
        {
            Vk.vkCmdDrawIndexed(
                m_ptr_commandBuffer,
                i_cmdDrawIndexed.p_indexCount,
                i_cmdDrawIndexed.p_instanceCount,
                i_cmdDrawIndexed.p_firstIndex,
                i_cmdDrawIndexed.p_vertexOffset,
                i_cmdDrawIndexed.p_firstInstance);
        }

        private void HandleCmdDraw(CmdDraw i_cmdDr)
        {
            Vk.vkCmdDraw(
                m_ptr_commandBuffer,
                i_cmdDr.p_vertexCount,
                i_cmdDr.p_instanceCount,
                i_cmdDr.p_firstVertex,
                i_cmdDr.p_firstInstance);
        }

        private void HandleCmdBindVertexBuffer(CmdBindVertexBuffer i_cmdBindVertexBuffer)
        {
            Buffer buffer = (Buffer)i_cmdBindVertexBuffer.p_buffer!;
            VkBuffer_T* bufferPtr = buffer.VkBufferPtr;
            ulong offset = i_cmdBindVertexBuffer.p_offset;
            ulong size = i_cmdBindVertexBuffer.p_size;

            Vk.vkCmdBindVertexBuffers2(
                m_ptr_commandBuffer, 
                i_cmdBindVertexBuffer.p_firstBinding, 
                1, 
                &bufferPtr, 
                &offset, 
                &size, 
                null);
        }

        private void HandleCmdBindIndexBuffer(CmdBindIndexBuffer i_cmdBindIndexBuffer)
        {
            Buffer buffer = (Buffer)i_cmdBindIndexBuffer.p_buffer!;

            Vk.vkCmdBindIndexBuffer(
                m_ptr_commandBuffer,
                buffer.VkBufferPtr,
                i_cmdBindIndexBuffer.p_offset,
                VkUtils.IndexFormatToVkIndexType(i_cmdBindIndexBuffer.p_indexFormat));
        }

        private void HandleCmdBindSets(CmdBindSets i_cmdBindSets, bool i_isComputePass)
        {
            VkPipelineLayout_T* pipelineLayoutPtr = null;
            if (m_boundShaderLink != null)
            {
                pipelineLayoutPtr = m_boundShaderLink.Layout.VkPipelineLayoutPtr;
            }
            else
            {
                throw new Exception("A ShaderLink is not bound.");
            }

            nuint* setPtrs = stackalloc nuint[i_cmdBindSets.p_pipelineSets.Length];
            for (int i = 0; i < i_cmdBindSets.p_pipelineSets.Length; i++)
            {
                setPtrs[i] = (nuint)i_cmdBindSets.p_pipelineSets[i].VkDescriptorSetPtr;
            }

            VkPipelineBindPoint pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;
            if (i_isComputePass)
            {
                pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_COMPUTE;
            }

            Vk.vkCmdBindDescriptorSets(
                m_ptr_commandBuffer,
                pipelineBindPoint,
                pipelineLayoutPtr,
                i_cmdBindSets.p_firstSet,
                (uint)i_cmdBindSets.p_pipelineSets.Length,
                (VkDescriptorSet_T**)setPtrs,
                0,
                null
            );
        }

        private void HandleCmdPushSet(CmdPushSet i_cmdPushPipelineSet, bool i_isComputePass)
        {
            VkPipelineBindPoint pipelineBindPoint = 
                i_isComputePass ? VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_COMPUTE : VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;

            List<uint> bindingNumberListBuffers = [];
            List<uint> bindingNumberListImages = [];
            List<VkDescriptorType> vkDescriptorTypesListBuffers = [];
            List<VkDescriptorType> vkDescriptorTypesListImages = [];
            List<VkDescriptorBufferInfo> vkDescriptorBufferInfoList = [];
            List<VkDescriptorImageInfo> vkDescriptorImageInfoList = [];

            for (int i = 0; i < i_cmdPushPipelineSet.p_bindingDescription.Length; i++)
            {
                ref SetEntryBinding binding = ref i_cmdPushPipelineSet.p_bindingDescription[i];

                if (binding.p_bufferBinding.HasValue)
                {
                    BufferBindingDescription bufferBinding = binding.p_bufferBinding.Value;
                    Buffer buffer = bufferBinding.p_buffer!;

                    VkDescriptorBufferInfo bufferInfo = new()
                    {
                        buffer = buffer.VkBufferPtr,
                        offset = bufferBinding.p_offset,
                        range = bufferBinding.p_range,
                    };

                    vkDescriptorBufferInfoList.Add(bufferInfo);
                    bindingNumberListBuffers.Add(binding.p_binding);
                    vkDescriptorTypesListBuffers.Add(VkUtils.EntryTypeToVkDescriptorType(binding.p_type));
                }
                else if (binding.p_textureBinding.HasValue)
                {
                    TextureBindingDescription textureBinding = binding.p_textureBinding.Value;
                    TextureView? textureView = textureBinding.p_textureView;
                    Sampler? sampler = textureBinding.p_sampler;

                    VkDescriptorImageInfo imageInfo = new()
                    {
                        imageView = textureView != null ? textureView.VkImageViewPtr : null,
                        sampler = sampler != null ? sampler.VkSamplerPtr : null,
                        imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                    };

                    vkDescriptorImageInfoList.Add(imageInfo);
                    bindingNumberListImages.Add(binding.p_binding);
                    vkDescriptorTypesListImages.Add(VkUtils.EntryTypeToVkDescriptorType(binding.p_type));
                }
            }

            VkDescriptorBufferInfo[] vkDescriptorBufferInfoArray = [.. vkDescriptorBufferInfoList];
            VkDescriptorImageInfo[] vkDescriptorImageInfoArray = [.. vkDescriptorImageInfoList];

            fixed (VkDescriptorBufferInfo* bufferInfoPtr = vkDescriptorBufferInfoArray)
            fixed (VkDescriptorImageInfo* imageInfoPtr = vkDescriptorImageInfoArray)
            {
                VkWriteDescriptorSet[] vkWriteDescriptorSetsArray =
                    new VkWriteDescriptorSet[vkDescriptorBufferInfoArray.Length + vkDescriptorImageInfoArray.Length];

                for (int i = 0; i < vkDescriptorBufferInfoArray.Length; i++)
                {
                    VkWriteDescriptorSet vkWriteDescriptorSet = new()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET,
                        pNext = null,
                        dstSet = null, // This field is ignored.
                        dstBinding = bindingNumberListBuffers[i],
                        dstArrayElement = 0,
                        descriptorCount = 1,
                        descriptorType = vkDescriptorTypesListBuffers[i],
                        pBufferInfo = &bufferInfoPtr[i],
                        pImageInfo = null,
                        pTexelBufferView = null,
                    };

                    vkWriteDescriptorSetsArray[i] = vkWriteDescriptorSet;
                }

                for (int i = 0; i < vkDescriptorImageInfoArray.Length; i++)
                {
                    VkWriteDescriptorSet vkWriteDescriptorSet = new()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET,
                        pNext = null,
                        dstSet = null, // This field is ignored.
                        dstBinding = bindingNumberListImages[i],
                        dstArrayElement = 0,
                        descriptorCount = 1,
                        descriptorType = vkDescriptorTypesListImages[i],
                        pBufferInfo = null,
                        pImageInfo = &imageInfoPtr[i],
                        pTexelBufferView = null,
                    };

                    vkWriteDescriptorSetsArray[i + vkDescriptorBufferInfoArray.Length] = vkWriteDescriptorSet;
                }

                fixed (VkWriteDescriptorSet* vkWriteDescriptorSetPtr = vkWriteDescriptorSetsArray)
                {
                    VkPipelineLayout_T* pipelineLayoutPtr = null;
                    if (m_boundShaderLink != null)
                    {
                        pipelineLayoutPtr = m_boundShaderLink.Layout.VkPipelineLayoutPtr;
                    }
                    else
                    {
                        throw new Exception("A ShaderLink is not bound.");
                    }

                    Vk.vkCmdPushDescriptorSet(
                        m_ptr_commandBuffer,
                        pipelineBindPoint,
                        pipelineLayoutPtr,
                        i_cmdPushPipelineSet.p_set,
                        (uint)i_cmdPushPipelineSet.p_bindingDescription.Length,
                        vkWriteDescriptorSetPtr
                    );
                }
            }
        }
        
        private void HandleCmdPushConstant(CmdPushConstant i_cmdPushConstant)
        {
            VkPipelineLayout_T* pipelineLayoutPtr = null;
            if (m_boundShaderLink != null)
            {
                pipelineLayoutPtr = m_boundShaderLink.Layout.VkPipelineLayoutPtr;
            }
            else
            {
                throw new Exception("A ShaderLink is not bound.");
            }

            fixed (byte* ptr = i_cmdPushConstant.p_data)
            {
                Vk.vkCmdPushConstants(
                    m_ptr_commandBuffer,
                    pipelineLayoutPtr,
                    (uint)VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(i_cmdPushConstant.p_stageFlags),
                    0,
                    (uint)i_cmdPushConstant.p_data.Length,
                    ptr);
            }
        }

        private void HandleCmdDispatch(CmdDispatch i_cmdDispatch)
        {
            Vk.vkCmdDispatch(
                m_ptr_commandBuffer,
                i_cmdDispatch.p_numGroupsX,
                i_cmdDispatch.p_numGroupsY,
                i_cmdDispatch.p_numGroupsZ);
        }

        private void HandleSetBarriers(Set[] i_sets)
        {
            foreach (var pipelineSet in i_sets)
            {
                ref SetDeclaration setDeclaration =
                    ref pipelineSet.Layout.SetDeclarations[pipelineSet.SetLayoutIdx];

                for (int i = 0; i < setDeclaration.p_entries.Length; i++)
                {
                    ref SetEntryDeclaration entryDeclaration = ref setDeclaration.p_entries[i];
                    ref SetEntryBinding bindingDescription = ref pipelineSet.BindingDescriptions[i];

                    switch (entryDeclaration.p_type)
                    {
                        case EntryType.UniformBuffer:
                            Buffer uniform = bindingDescription.p_bufferBinding!.Value.p_buffer!;
                            CmdBufferBarrier(
                                uniform,
                                VkUtils.EntryModeToVkAccessFlagBits(entryDeclaration.p_mode),
                                VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(entryDeclaration.p_stages));
                            break;
                        case EntryType.StorageBuffer:
                            Buffer storage = bindingDescription.p_bufferBinding!.Value.p_buffer!;
                            CmdBufferBarrier(
                                storage,
                                VkUtils.EntryModeToVkAccessFlagBits(entryDeclaration.p_mode),
                                VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(entryDeclaration.p_stages));
                            break;
                        case EntryType.Texture:
                            TextureView textureView = bindingDescription.p_textureBinding!.Value.p_textureView!;

                            ulong[] masks = new ulong[textureView.Texture.ArrayLayersCount];
                            VkUtils.FillTextureBarrierMipmapsBitmaskToAll(masks);

                            CmdImageBarrier(
                                textureView.Texture,
                                VkImageLayout.VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                                VkUtils.EntryModeToVkAccessFlagBits(entryDeclaration.p_mode),
                                VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(entryDeclaration.p_stages),
                                masks);
                            break;
                        case EntryType.Sampler:
                            // Do nothing.
                            break;
                        default: throw new Exception($"Unsupported entry type: {entryDeclaration.p_type}");
                    }
                }
            }
        }

        private void HandlePushSetBarriers(SetEntryBinding[] i_bindingDescription)
        {
            for (int i = 0; i < i_bindingDescription.Length; i++) 
            {
                if (!i_bindingDescription[i].TryGetNext(out PushBindingUsageInfo usageInfo))
                {
                    throw new Exception("Push pipeline set binding usage info not found.");
                }

                switch (i_bindingDescription[i].p_type)
                {
                    case EntryType.UniformBuffer:
                        Buffer uniform = (Buffer)i_bindingDescription[i].p_bufferBinding!.Value.p_buffer!;
                        CmdBufferBarrier(
                            uniform,
                            VkUtils.EntryModeToVkAccessFlagBits(usageInfo.p_mode),
                            VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(usageInfo.p_stages));
                        break;
                    case EntryType.StorageBuffer:
                        Buffer storage = (Buffer)i_bindingDescription[i].p_bufferBinding!.Value.p_buffer!;
                        CmdBufferBarrier(
                            storage,
                            VkUtils.EntryModeToVkAccessFlagBits(usageInfo.p_mode),
                            VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(usageInfo.p_stages));
                        break;
                    case EntryType.Texture:
                        TextureView textureView = (TextureView)i_bindingDescription[i].p_textureBinding!.Value.p_textureView!;

                        ulong[] masks = new ulong[textureView.Texture.ArrayLayersCount];
                        VkUtils.FillTextureBarrierMipmapsBitmaskToAll(masks);

                        CmdImageBarrier(
                            textureView.Texture,
                            VkImageLayout.VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                            VkUtils.EntryModeToVkAccessFlagBits(usageInfo.p_mode),
                            VkUtils.ShaderStageFlagsToVkPipelineStageFlagBits(usageInfo.p_stages),
                            masks);
                        break;
                    case EntryType.Sampler:
                        // Do nothing.
                        break;
                    default: throw new Exception($"Unsupported entry type: {i_bindingDescription[i].p_type}");
                }
            }
        }
    
        private void HandleCmdBindShaderLink(CmdBindShaderLink i_cmdBindShaderLink)
        {
            // Unbind previous shader link.
            if (m_boundShaderLink != null && m_boundShaderLink != i_cmdBindShaderLink.p_shaderLink)
            {
                VkShaderStageFlagBits[] vkUnbindStages = new VkShaderStageFlagBits[m_boundShaderLink.Stages.Length];
                for (int i = 0; i < m_boundShaderLink.Stages.Length; i++)
                {
                    vkUnbindStages[i] = VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(m_boundShaderLink.Stages[i]);
                }

                fixed (VkShaderStageFlagBits* vkUnbindStagesPtr = vkUnbindStages)
                {
                    m_queueFamily.Device.Funcs.PfnVkCmdBindShadersExt(m_ptr_commandBuffer, (uint)vkUnbindStages.Length, vkUnbindStagesPtr, null);
                }
            }

            // Bind new shader link if different.

            if (m_boundShaderLink != i_cmdBindShaderLink.p_shaderLink)
            {
                ShaderLink shaderLink = i_cmdBindShaderLink.p_shaderLink!;
                ShaderStageFlags[] stages = shaderLink.Stages;
                VkShaderEXT_T*[] shaderPtrs = shaderLink.VkShadersPtrs;
                
                // Convert stages to VkShaderStageFlagBits.
                VkShaderStageFlagBits[] vkStages = new VkShaderStageFlagBits[stages.Length];
                for (int i = 0; i < stages.Length; i++)
                {
                    vkStages[i] = VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(stages[i]);
                }

                fixed (VkShaderStageFlagBits* vkStagesPtr = vkStages)
                fixed (VkShaderEXT_T** shaderPtrsPtr = shaderPtrs)
                {
                    m_queueFamily.Device.Funcs.PfnVkCmdBindShadersExt(m_ptr_commandBuffer, (uint)vkStages.Length, vkStagesPtr, shaderPtrsPtr);
                }

                m_boundShaderLink = shaderLink;
            }
        }

        private void HandleCmdSetCullMode(CmdSetCullMode i_cmdSetCullMode)
        {
            Vk.vkCmdSetCullMode(m_ptr_commandBuffer, (uint)VkUtils.CullModeFlagsToVkCullModeFlagBits(i_cmdSetCullMode.p_cullMode));
        }

        private void HandleCmdSetRasterizerDiscardEnable(CmdSetRasterizerDiscardEnable i_cmdSetRasterizerDiscardEnable)
        {
            Vk.vkCmdSetRasterizerDiscardEnable(m_ptr_commandBuffer, i_cmdSetRasterizerDiscardEnable.p_rasterizerDiscardEnable ? 1U : 0U);
        }
        
        private void HandleCmdSetDepthTestEnable(CmdSetDepthTestEnable i_cmdSetDepthTestEnable)
        {
            Vk.vkCmdSetDepthTestEnable(m_ptr_commandBuffer, i_cmdSetDepthTestEnable.p_depthTestEnable ? 1U : 0U);
        }

        private void HandleCmdSetStencilTestEnable(CmdSetStencilTestEnable i_cmdSetStencilTestEnable)
        {
            Vk.vkCmdSetStencilTestEnable(m_ptr_commandBuffer, i_cmdSetStencilTestEnable.p_stencilTestEnable ? 1U : 0U);
        }

        private void HandleCmdSetDepthBiasEnable(CmdSetDepthBiasEnable i_cmdSetDepthBiasEnable)
        {
            Vk.vkCmdSetDepthBiasEnable(m_ptr_commandBuffer, i_cmdSetDepthBiasEnable.p_depthBiasEnable ? 1U : 0U);
        }

        private void HandleCmdSetPolygonMode(CmdSetPolygonMode i_cmdSetPolygonMode)
        {
            m_queueFamily.Device.Funcs.PfnVkCmdSetPolygonModeExt(m_ptr_commandBuffer, VkUtils.PolygonModeToVkPolygonMode(i_cmdSetPolygonMode.p_polygonMode));
        }

        private void HandleCmdSetRasterizationSamples(CmdSetRasterizationSamples i_cmdSetRasterizationSamples)
        {
            m_queueFamily.Device.Funcs.PfnVkCmdSetRasterizationSamplesExt(m_ptr_commandBuffer, VkUtils.SampleCountToVkSampleCountFlagBits(i_cmdSetRasterizationSamples.p_rasterizationSamples));
        }

        private void HandleCmdSetSampleMask(CmdSetSampleMask i_cmdSetSampleMask)
        {
            fixed (uint* maskPtr = i_cmdSetSampleMask.p_mask)
            m_queueFamily.Device.Funcs.PfnVkCmdSetSampleMaskExt(
                m_ptr_commandBuffer, 
                VkUtils.SampleCountToVkSampleCountFlagBits(i_cmdSetSampleMask.p_samples),
                maskPtr);
        }

        private void HandleCmdSetFrontFace(CmdSetFrontFace i_cmdSetFrontFace)
        {
            Vk.vkCmdSetFrontFace(m_ptr_commandBuffer, VkUtils.FrontFaceToVkFrontFace(i_cmdSetFrontFace.p_frontFace));
        }

        private void HandleCmdSetPrimitiveTopology(CmdSetPrimitiveTopology i_cmdSetPrimitiveTopology)
        {
            Vk.vkCmdSetPrimitiveTopology(m_ptr_commandBuffer, VkUtils.PrimitiveTopologyToVkPrimitiveTopology(i_cmdSetPrimitiveTopology.p_primitiveTopology));
        }

        private void HandleCmdSetPrimitiveRestartEnable(CmdSetPrimitiveRestartEnable i_cmdSetPrimitiveRestartEnable)
        {
            Vk.vkCmdSetPrimitiveRestartEnable(m_ptr_commandBuffer, i_cmdSetPrimitiveRestartEnable.p_primitiveRestartEnable ? 1U : 0U);
        }

        private void HandleCmdSetDepthClampEnable(CmdSetDepthClampEnable i_cmdSetDepthClampEnable)
        {
            m_queueFamily.Device.Funcs.PfnVkCmdSetDepthClampEnableExt(m_ptr_commandBuffer, i_cmdSetDepthClampEnable.p_depthClampEnable ? 1U : 0U);
        }

        private void HandleCmdSetAlphaToCoverageEnable(CmdSetAlphaToCoverageEnable i_cmdSetAlphaToCoverageEnable)
        {
            m_queueFamily.Device.Funcs.PfnVkCmdSetAlphaToCoverageEnableExt(m_ptr_commandBuffer, i_cmdSetAlphaToCoverageEnable.p_alphaToCoverageEnable ? 1U : 0U);
        }

        private void HandleCmdSetColorBlendEnable(CmdSetColorBlendEnable i_cmdSetColorBlendEnable)
        {
            Span<uint> enabled = stackalloc uint[i_cmdSetColorBlendEnable.p_colorBlendEnable!.Length];
            for (int i = 0; i < i_cmdSetColorBlendEnable.p_colorBlendEnable.Length; i++)
            {
                enabled[i] = i_cmdSetColorBlendEnable.p_colorBlendEnable[i] ? 1U : 0U;
            }

            fixed (uint* enabledPtr = enabled)
            {            
                m_queueFamily.Device.Funcs.PfnVkCmdSetColorBlendEnableExt(
                    m_ptr_commandBuffer, 
                    i_cmdSetColorBlendEnable.p_firstAttachment,
                    (uint)enabled.Length,
                    enabledPtr);
            }
        }

        private void HandleCmdSetColorWriteMask(CmdSetColorWriteMask i_cmdSetColorWriteMask)
        {
            Span<uint> colorWriteMasks = stackalloc uint[i_cmdSetColorWriteMask.p_colorWriteMasks!.Length];
            for (int i = 0; i < i_cmdSetColorWriteMask.p_colorWriteMasks.Length; i++)
            {
                colorWriteMasks[i] = (uint)VkUtils.ColorComponentFlagsToVkColorComponentFlagBits(i_cmdSetColorWriteMask.p_colorWriteMasks[i]);
            }

            fixed (uint* colorWriteMasksPtr = colorWriteMasks)
            {            
                m_queueFamily.Device.Funcs.PfnVkCmdSetColorWriteMaskExt(
                    m_ptr_commandBuffer, 
                    i_cmdSetColorWriteMask.p_firstAttachment,
                    (uint)colorWriteMasks.Length,
                    colorWriteMasksPtr);
            }
        }

        private void HandleCmdSetVertexInput(CmdSetVertexInput i_cmdSetVertexInput)
        {
            VkVertexInputBindingDescription2EXT[] vertexInputBindingDescriptionArray = [];
            VkVertexInputAttributeDescription2EXT[] vertexInputAttributeDescriptionArray = [];

            vertexInputBindingDescriptionArray = new VkVertexInputBindingDescription2EXT[i_cmdSetVertexInput.p_vertexAttributesLayouts!.Length];

            int vertexAttributeLength = 0;
            for (int i = 0; i < i_cmdSetVertexInput.p_vertexAttributesLayouts.Length; i++)
            {
                vertexAttributeLength += i_cmdSetVertexInput.p_vertexAttributesLayouts[i].p_attributes.Length;
            }
            vertexInputAttributeDescriptionArray = new VkVertexInputAttributeDescription2EXT[vertexAttributeLength];

            int attributeIndex = 0;
            for (int i = 0; i < i_cmdSetVertexInput.p_vertexAttributesLayouts.Length; i++)
            {
                var layout = i_cmdSetVertexInput.p_vertexAttributesLayouts[i];

                vertexInputBindingDescriptionArray[i] = new VkVertexInputBindingDescription2EXT
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_VERTEX_INPUT_BINDING_DESCRIPTION_2_EXT,
                    pNext = null,
                    binding = layout.p_binding,
                    stride = layout.p_stride,
                    inputRate = VkUtils.VertexStepModeToVkVertexInputRate(layout.p_stepMode),
                    divisor = 1, // TODO: Expose this parameter.
                };

                for (int j = 0; j < layout.p_attributes.Length; j++)
                {
                    var attribute = layout.p_attributes[j];
                    vertexInputAttributeDescriptionArray[attributeIndex++] = new VkVertexInputAttributeDescription2EXT
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_VERTEX_INPUT_ATTRIBUTE_DESCRIPTION_2_EXT,
                        pNext = null,
                        location = attribute.p_location,
                        binding = layout.p_binding,
                        format = VkUtils.VertexFormatToVkFormat(attribute.p_format),
                        offset = (uint)attribute.p_attributeOffset,
                    };
                }
            }

            fixed (VkVertexInputBindingDescription2EXT* vertexInputBindingDescriptionArrayPtr = vertexInputBindingDescriptionArray)
            fixed (VkVertexInputAttributeDescription2EXT* vertexInputAttributeDescriptionArrayPtr = vertexInputAttributeDescriptionArray)
            {
                m_queueFamily.Device.Funcs.PfnVkCmdSetVertexInputExt(
                    m_ptr_commandBuffer, 
                    (uint)vertexInputBindingDescriptionArray.Length,
                    vertexInputBindingDescriptionArrayPtr,
                    (uint)vertexInputAttributeDescriptionArray.Length,
                    vertexInputAttributeDescriptionArrayPtr);
            }
        }

        private void HandleCmdSetColorBlendEquation(CmdSetColorBlendEquation i_cmdSetColorBlendEquation)
        {
            VkColorBlendEquationEXT[] blendEquations = new VkColorBlendEquationEXT[i_cmdSetColorBlendEquation.p_blendEquations!.Length];
            for (int i = 0; i < i_cmdSetColorBlendEquation.p_blendEquations.Length; i++)
            {
                blendEquations[i].alphaBlendOp = VkUtils.BlendOpToVkBlendOp(i_cmdSetColorBlendEquation.p_blendEquations[i].p_alphaBlendOp);
                blendEquations[i].colorBlendOp = VkUtils.BlendOpToVkBlendOp(i_cmdSetColorBlendEquation.p_blendEquations[i].p_colorBlendOp);
                blendEquations[i].dstAlphaBlendFactor = VkUtils.BlendFactorToVkBlendFactor(i_cmdSetColorBlendEquation.p_blendEquations[i].p_dstAlphaBlendFactor);
                blendEquations[i].dstColorBlendFactor = VkUtils.BlendFactorToVkBlendFactor(i_cmdSetColorBlendEquation.p_blendEquations[i].p_dstColorBlendFactor);
                blendEquations[i].srcAlphaBlendFactor = VkUtils.BlendFactorToVkBlendFactor(i_cmdSetColorBlendEquation.p_blendEquations[i].p_srcAlphaBlendFactor);
                blendEquations[i].srcColorBlendFactor = VkUtils.BlendFactorToVkBlendFactor(i_cmdSetColorBlendEquation.p_blendEquations[i].p_srcColorBlendFactor);
            }

            fixed (VkColorBlendEquationEXT* blendEquationsPtr = blendEquations)
            {
                m_queueFamily.Device.Funcs.PfnVkCmdSetColorBlendEquationExt(
                    m_ptr_commandBuffer,
                    (uint)i_cmdSetColorBlendEquation.p_firstAttachment,
                    (uint)i_cmdSetColorBlendEquation.p_blendEquations!.Length,
                    blendEquationsPtr);
            }
        }

        private void HandleCmdSetDepthCompareOp(CmdSetDepthCompareOp i_cmdSetDepthCompareOp)
        {
            Vk.vkCmdSetDepthCompareOp(m_ptr_commandBuffer, VkUtils.CompareOperationToVkCompareOp(i_cmdSetDepthCompareOp.p_depthCompareOp));
        }

        private void HandleCmdSetDepthWriteEnable(CmdSetDepthWriteEnable i_cmdSetDepthWriteEnable)
        {
            Vk.vkCmdSetDepthWriteEnable(m_ptr_commandBuffer, i_cmdSetDepthWriteEnable.p_depthWriteEnable ? 1U : 0U);
        }

        private void HandleCmdSetLineWidth(CmdSetLineWidth i_cmdSetLineWidth)
        {
            Vk.vkCmdSetLineWidth(m_ptr_commandBuffer, i_cmdSetLineWidth.p_lineWidth);
        }
    }
}
