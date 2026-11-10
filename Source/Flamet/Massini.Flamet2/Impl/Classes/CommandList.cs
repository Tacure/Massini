
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Collections;
using Massini.Core.Math;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Extensions;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using Massini.Flamet2.Impl.Classes.Commands;
using Massini.Flamet2.Impl.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class CommandList : ICommandList1
    {
        public CommandList(Lane i_lane)
        {
            Device device = (Device)i_lane.GetInfo().Device;
            
            VkCommandBufferAllocateInfo commandBufferAllocateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO,
                pNext = null,
                commandPool = i_lane.VkCommandPoolPtr,
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

            m_ptr_commandBuffer = commandBuffer;
            m_ptr_cbChainingTimelineSemaphore = semaphore;
            m_lane = i_lane;
            
            m_commandListInfo = new CommandListInfo()
            {
                Id = Rid.NewId(),
                Lane = i_lane,
            };
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_commandListInfo.Lane.GetInfo().Device;
                Lane lane = (Lane)m_commandListInfo.Lane;
                
                m_isDisposed = true;
                Vk.vkDestroySemaphore(device.VkDevicePtr, m_ptr_cbChainingTimelineSemaphore, null);
                VkCommandBuffer_T* commandBuffer = m_ptr_commandBuffer;
                Vk.vkFreeCommandBuffers(device.VkDevicePtr, lane.VkCommandPoolPtr, 1, &commandBuffer);
            }
        }

        public CommandListInfo GetInfo()
        {
            return m_commandListInfo;
        }

        // TODO: Think if this command is truly necessary
        // TODO: or if it's better to manage this automatically like we did in the last version.
        public ulong GetSignalValue()
        {
            return m_cbChainingSemaphoreSignalValue;
        }

        public void WaitIdle(TimeSpan i_timeout)
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

            Device device = (Device)m_commandListInfo.Lane.GetInfo().Device;

            double fTimeout = Math<double>.Clamp(i_timeout.TotalNanoseconds, 0.0, double.MaxValue);
            ulong timeout = (ulong)fTimeout;
            Vk.vkWaitSemaphores(device.VkDevicePtr, &semaphoreWaitInfo, timeout);
        }

        public void Open()
        {
            if (m_state is State.Open)
            {
                throw new InvalidOperationException("Command list is already open.");
            }
            
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
            
            // Set state.
            m_state = State.Open;
        }
        
        public void Close()
        {
            if (m_state is State.Close or State.Empty)
            {
                throw new InvalidOperationException("Command list is already closed or was never opened.");
            }
            
            // Record commands.
            RecordCommands();
            
            // Close command buffer.
            Vk.vkEndCommandBuffer(m_ptr_commandBuffer);
            
            // Return old commands to pool.
            foreach (var command in m_commands)
            {
                m_lane.GetCommandPool().Return(command);
            }
            m_commands.Clear();
            
            // Set state.
            m_state = State.Close;
        }

        public void Submit(in CommandListSubmitParams i_submitParams)
        {
            if (m_state is not State.Close)
            {
                throw new InvalidOperationException("Command list was not closed.");
            }
            
            Lane lane = (Lane)i_submitParams.p_lane;
            Device device = (Device)lane.GetInfo().Device;

            // Setup wait semaphores.

            uint waitCommandBufferCount = (uint)i_submitParams.p_waitCommandLists.Length;

            CommandListSemaphoreSubmitParams cmdListSemaphoreSubmitParams = default;
            uint waitBinarySemaphoreCount = 0;
            uint signalBinarySemaphoreCount = 0;
            if (i_submitParams.TryGetNext(out cmdListSemaphoreSubmitParams))
            {
                waitBinarySemaphoreCount = (uint)cmdListSemaphoreSubmitParams.p_waitBinarySemaphores.Length;
                signalBinarySemaphoreCount = (uint)cmdListSemaphoreSubmitParams.p_signalBinarySemaphores.Length;
            }

            Span<nuint> waitSemaphores = stackalloc nuint[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            Span<VkPipelineStageFlagBits> waitStages = stackalloc VkPipelineStageFlagBits[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            Span<ulong> waitValues = stackalloc ulong[(int)waitBinarySemaphoreCount + (int)waitCommandBufferCount];
            for (int i = 0; i < waitBinarySemaphoreCount; i++)
            {
                waitStages[i] = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_ALL_COMMANDS_BIT;
                waitValues[i] = 0;
                waitSemaphores[i] = (nuint)cmdListSemaphoreSubmitParams.p_waitBinarySemaphores[i];
            }
            for (int i = (int)waitBinarySemaphoreCount; i < waitBinarySemaphoreCount + waitCommandBufferCount; i++)
            {
                (ICommandList1 commandList, ulong cmdSignalValue) = i_submitParams.p_waitCommandLists[i - (int)waitBinarySemaphoreCount];
                waitStages[i] = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_ALL_COMMANDS_BIT;
                waitValues[i] = cmdSignalValue;
                waitSemaphores[i] = (nuint)((CommandList)commandList).m_ptr_cbChainingTimelineSemaphore;
            }

            // Get execution completed wait value.

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
                signalSemaphores[i] = (nuint)cmdListSemaphoreSubmitParams.p_signalBinarySemaphores[i];
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

                        Vk.vkQueueSubmit(lane.GetNextVkQueuePtr(), 1, &submitInfo, null);
                    }
                }
            }
        }

        public void CmdBeginRenderPass(in RenderPassBeginParams i_beginParams)
        {
            int beginIndex = m_commands.Count;
            
            CommandPool cmdPool = m_lane.GetCommandPool();
            CmdBeginRenderPass cmd = cmdPool.Borrow<CmdBeginRenderPass>();
            m_commands.Add(cmd);
            
            cmd.BeginParams = i_beginParams;

            m_activeRenderPass = cmd;
            m_activeRenderPassIndex = beginIndex;
        }

        public void CmdEndRenderPass()
        {
            int endIndex = m_commands.Count;
            
            CommandPool cmdPool = m_lane.GetCommandPool();
            CmdEndRenderPass cmd = cmdPool.Borrow<CmdEndRenderPass>();
            m_commands.Add(cmd);
            
            cmd.BeginIndex = m_activeRenderPassIndex;
            
            m_activeRenderPass!.EndIndex = endIndex;
            m_activeRenderPass = null;
            m_activeRenderPassIndex = -1;
        }

        private enum State
        {
            Empty,
            Open,
            Close,
        }
        
        private bool m_isDisposed = false;
        private readonly CommandListInfo m_commandListInfo;
        private readonly Lane m_lane; // We store the lane separately for fast access.
        private readonly VkCommandBuffer_T* m_ptr_commandBuffer;
        private readonly VkSemaphore_T* m_ptr_cbChainingTimelineSemaphore;
        private ulong m_cbChainingSemaphoreSignalValue = 0;
        
        #region Recording state.
        
        private State m_state = State.Empty;
        private readonly DynamicArray<BaseCommand> m_commands = [];
        private CmdBeginRenderPass? m_activeRenderPass = null;
        private int m_activeRenderPassIndex = -1;
        
        #endregion

        #region Barrier methods.
        
        private void CmdImageBarrier(Texture i_texture, VkImageLayout i_newLayout, VkAccessFlagBits i_dstAccessMask, VkPipelineStageFlagBits i_dstStageMask, ReadOnlySpan<ulong> i_layerMasks)
        {
            Texture texture = i_texture;
            uint arrayLayerCount = texture.GetInfo().ArrayLayerCount;
            uint mipCount = texture.GetInfo().MipCount;
            TextureBarrierState textureBarrierState = texture.GetTextureBarrierState();
            VkFormat format = IntSharedCvs.TextureFormatToVkFormat(texture.GetInfo().Format);
            
            if (i_layerMasks.Length != arrayLayerCount)
            {
                throw new ArgumentException("i_layerMasks.Length should be equal to texture.ArrayLayers.");
            }

            VkImageMemoryBarrier2[] barriers = new VkImageMemoryBarrier2[arrayLayerCount * mipCount];
            uint usedBarriers = 0; // Keeps track of how many barriers are actually used.
            for (int layerIdx = 0; layerIdx < arrayLayerCount; layerIdx++)
            {
                // Filter layer if no mip levels need to be transitioned.
                ulong mask = i_layerMasks[layerIdx];
                if (mask == 0) continue;

                for (int mipIdx = 0; mipIdx < mipCount; mipIdx++)
                {
                    // Check bit mask if bit equals 1 (ONE).
                    if ((mask & (1UL << mipIdx)) == 0UL) continue;

                    ref TextureBarrierState.TextureSubresourceBarrierState subresourceState = ref textureBarrierState.GetState((uint)layerIdx, (uint)mipIdx);

                    if (subresourceState.p_layout == i_newLayout && 
                        subresourceState.p_accessMask == i_dstAccessMask &&
                        subresourceState.p_stageMask == i_dstStageMask &&
                        subresourceState.p_queueFamilyIndex == m_lane.FamilyIndex) continue;
                    
                    uint srcQueueFamilyIdx = subresourceState.p_queueFamilyIndex;
                    uint dstQueueFamilyIdx = m_lane.FamilyIndex;
                    
                    barriers[usedBarriers] = new VkImageMemoryBarrier2()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2,
                        srcStageMask = (ulong)subresourceState.p_stageMask,
                        dstStageMask = (ulong)i_dstStageMask,
                        srcAccessMask = (ulong)subresourceState.p_accessMask,
                        dstAccessMask = (ulong)i_dstAccessMask,
                        oldLayout = subresourceState.p_layout,
                        newLayout = i_newLayout,
                        srcQueueFamilyIndex = srcQueueFamilyIdx,
                        dstQueueFamilyIndex = dstQueueFamilyIdx,
                        image = texture.VkImagePtr,
                        subresourceRange = new VkImageSubresourceRange
                        {
                            aspectMask = (uint)IntSharedCvs.GuessVkImageAspectMask(format),
                            baseArrayLayer = (uint)layerIdx,
                            levelCount = 1,
                            baseMipLevel = (uint)mipIdx,
                            layerCount = 1,
                        },
                    };

                    subresourceState.p_layout = i_newLayout;
                    subresourceState.p_accessMask = i_dstAccessMask;
                    subresourceState.p_stageMask = i_dstStageMask;
                    subresourceState.p_queueFamilyIndex = dstQueueFamilyIdx;

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
            BufferBarrierState bufferBarrierState = buffer.GetBufferBarrierState();

            if (bufferBarrierState.VkAccessMask == i_dstAccessMask && 
                bufferBarrierState.VkStageMask == i_dstStageMask &&
                bufferBarrierState.QueueFamilyIndex == m_lane.FamilyIndex) return;

            uint srcQueueFamilyIdx = Vk.VK_QUEUE_FAMILY_IGNORED;
            uint dstQueueFamilyIdx = Vk.VK_QUEUE_FAMILY_IGNORED;
            if (bufferBarrierState.QueueFamilyIndex != m_lane.FamilyIndex)
            {
                srcQueueFamilyIdx = bufferBarrierState.QueueFamilyIndex;
                dstQueueFamilyIdx = m_lane.FamilyIndex;
            }
            
            VkBufferMemoryBarrier bufferMemoryBarrier = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER,
                pNext = null,
                srcAccessMask = (uint)bufferBarrierState.VkAccessMask,
                dstAccessMask = (uint)i_dstAccessMask,
                srcQueueFamilyIndex = srcQueueFamilyIdx,
                dstQueueFamilyIndex = dstQueueFamilyIdx,
                buffer = buffer.VkBufferPtr,
                offset = ZERO,
                size = i_buffer.GetInfo().Size.ToBytes(),
            };

            Vk.vkCmdPipelineBarrier(
                m_ptr_commandBuffer,
                (uint)bufferBarrierState.VkStageMask,
                (uint)i_dstStageMask,
                ZERO,
                ZERO, null,
                ONE, &bufferMemoryBarrier,
                ZERO, null);

            bufferBarrierState.VkStageMask = i_dstStageMask;
            bufferBarrierState.VkAccessMask = i_dstAccessMask;
        }
        
        #endregion

        #region Command recording.

        private void RecordCommands()
        {
            for (int idx = 0; idx < m_commands.Count; idx++)
            {
                switch (m_commands[idx])
                {
                    case CmdBeginRenderPass cmd:
                        idx = HandleRenderPass(cmd);
                        break;
                }
            }
        }

        private int HandleRenderPass(CmdBeginRenderPass i_cmd)
        {
            RenderPassBeginParams renderPassBeginParams = i_cmd.BeginParams;
            CmdEndRenderPass cmdEndRenderPass = (CmdEndRenderPass)m_commands[i_cmd.EndIndex];
            VkRenderingAttachmentInfo[] colorAttachments = new VkRenderingAttachmentInfo[renderPassBeginParams.p_colorAttachments.Length];
            ReadOnlySpan<BaseCommand> renderPassCommands = m_commands.AsSpan().Slice(cmdEndRenderPass.BeginIndex, i_cmd.EndIndex);
            
            uint width = 0;
            uint height = 0;

            for (int i = 0; i < renderPassBeginParams.p_colorAttachments.Length; i++)
            {
                ref RenderPassColorAttachment renderPassColorAttachment = ref renderPassBeginParams.p_colorAttachments[i];

                Texture texture = (Texture)renderPassColorAttachment.p_textureView.GetInfo().Texture;
                uint arrayLayerCount = texture.GetInfo().ArrayLayerCount;
                Vec3<uint> extent = texture.GetInfo().Extent;
                width = extent.Width;
                height = extent.Height;
                
                VkClearColorValue clearColorValue = new();
                clearColorValue.float32[0] = renderPassColorAttachment.p_clearColor.p_x;
                clearColorValue.float32[1] = renderPassColorAttachment.p_clearColor.p_y;
                clearColorValue.float32[2] = renderPassColorAttachment.p_clearColor.p_z;
                clearColorValue.float32[3] = renderPassColorAttachment.p_clearColor.p_w;

                TextureView textureView = (TextureView)renderPassColorAttachment.p_textureView;

                ulong[] masks = new ulong[arrayLayerCount];
                for (int j = 0; j < arrayLayerCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    texture,
                    VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                    VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                    masks);

                VkRenderingAttachmentInfo colorAttachment = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                    loadOp = IntSharedCvs.LoadOpToVkAttachmentLoadOp(renderPassColorAttachment.p_loadOp),
                    storeOp = IntSharedCvs.StoreOpToVkAttachmentStoreOp(renderPassColorAttachment.p_storeOp),
                    clearValue = new VkClearValue()
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
                Texture texture = (Texture)textureView.GetInfo().Texture;
                uint arrayLayerCount = texture.GetInfo().ArrayLayerCount;
                Vec3<uint> extent = texture.GetInfo().Extent;

                depthAttachment = new VkRenderingAttachmentInfo()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                    loadOp = IntSharedCvs.LoadOpToVkAttachmentLoadOp(renderPassDepthStencilAttachment.p_depthLoadOp),
                    storeOp = IntSharedCvs.StoreOpToVkAttachmentStoreOp(renderPassDepthStencilAttachment.p_depthStoreOp),
                    clearValue = new VkClearValue()
                    {
                        depthStencil = new VkClearDepthStencilValue()
                        {
                            depth = 1.0f,
                            stencil = 0,
                        },
                    },
                };

                ulong[] masks = new ulong[arrayLayerCount];
                for (int j = 0; j < arrayLayerCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    texture,
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

                stencilAttachment = new VkRenderingAttachmentInfo
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO,
                    imageView = textureView.VkImageViewPtr,
                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL,
                    loadOp = IntSharedCvs.LoadOpToVkAttachmentLoadOp(renderPassDepthStencilAttachment.p_stencilLoadOp),
                    storeOp = IntSharedCvs.StoreOpToVkAttachmentStoreOp(renderPassDepthStencilAttachment.p_stencilStoreOp),
                    clearValue = new VkClearValue
                    {
                        depthStencil = new VkClearDepthStencilValue
                        {
                            depth = 1.0f,
                            stencil = 0,
                        },
                    },
                };
            }

            // Index buffer barriers.
            //foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindIndexBuffer>())
            //{
            //    CmdBufferBarrier(
            //        cmd.p_buffer!,
            //        VkAccessFlagBits.VK_ACCESS_INDEX_READ_BIT,
            //        VkPipelineStageFlagBits.VK_PIPELINE_STAGE_VERTEX_INPUT_BIT);
            //}

            // Vertex buffer barriers.
            //foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindVertexBuffer>())
            //{
            //    CmdBufferBarrier(
            //        cmd.p_buffer!,
            //        VkAccessFlagBits.VK_ACCESS_VERTEX_ATTRIBUTE_READ_BIT,
            //        VkPipelineStageFlagBits.VK_PIPELINE_STAGE_VERTEX_INPUT_BIT);
            //}

            // Bindings barriers.
            //foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdBindSets>())
            //{
            //    HandleSetBarriers(cmd.p_pipelineSets);
            //}

            // Push bindings barriers.
            //foreach (var cmd in i_cmdRenderPass.p_encoder!.Commands.OfType<CmdPushSet>()) 
            //{
            //    HandlePushSetBarriers(cmd.p_bindingDescription);
            //}

            fixed (VkRenderingAttachmentInfo* colorAttachmentsPtr = colorAttachments)
            {
                VkRenderingInfo renderingInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_RENDERING_INFO,
                    renderArea = new VkRect2D()
                    {
                        offset = new VkOffset2D() { x = 0, y = 0 },
                        extent = new VkExtent2D() { width = width, height = height },
                    },
                    layerCount = 1,
                    colorAttachmentCount = (uint)colorAttachments.Length,
                    pColorAttachments = colorAttachmentsPtr,
                    pDepthAttachment = hasDepthStencilAttachment ? &depthAttachment : null,
                    pStencilAttachment = hasDepthStencilAttachment ? &stencilAttachment : null,
                };

                Vk.vkCmdBeginRendering(m_ptr_commandBuffer, &renderingInfo);
            }

            // TODO: Record render pass commands.
            for (int i = 0; i < renderPassCommands.Length; i++)
            {
                
            }

            // End render pass.
            Vk.vkCmdEndRendering(m_ptr_commandBuffer);

            // Transition color attachments to present.
            for (int i = 0; i < renderPassBeginParams.p_colorAttachments.Length; i++)
            {
                TextureView textureView = (TextureView)renderPassBeginParams.p_colorAttachments[i].p_textureView;
                Texture texture = (Texture)textureView.GetInfo().Texture;
                uint arrayLayerCount = texture.GetInfo().ArrayLayerCount;

                ulong[] masks = new ulong[arrayLayerCount];
                for (int j = 0; j < arrayLayerCount; j++)
                {
                    // All mips.
                    masks[j] = ulong.MaxValue;
                }

                CmdImageBarrier(
                    texture,
                    VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR,
                    VkAccessFlagBits.VK_ACCESS_NONE,
                    VkPipelineStageFlagBits.VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT,
                    masks);
            }
            
            return i_cmd.EndIndex + 1;
        }

        #endregion
    }
}