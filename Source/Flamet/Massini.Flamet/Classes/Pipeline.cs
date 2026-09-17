
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Interop;
using Massini.Flamet.Extensions;
using Massini.Flamet.Interfaces;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes
{
    /// <summary>
    /// Pipeline.
    /// </summary>
    public unsafe class Pipeline : IResource, IDisposable
    {
        /// <inheritdoc/>
        public Rid Id { get; private init; }
        
        /// <inheritdoc/>
        public Device Device { get; private init; }
        
        /// <inheritdoc/>
        public bool IsDisposed { get; private init; }

        /// <summary>
        /// Creates a pipeline.
        /// </summary>
        public Pipeline(Device i_device, PipelineCreateParams i_createParams)
        {
            VkPipeline_T* pipelinePtr = CreateGraphicsPipeline(i_device, i_createParams);
            
            Id = Rid.NewId();
            Device = i_device;
            IsDisposed = false;
            m_ptr_pipeline = pipelinePtr;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (m_isDisposed) return;
            
            m_isDisposed = true;
            GC.SuppressFinalize(this);
            Vk.vkDestroyPipeline(Device.VkDevicePtr, m_ptr_pipeline, null);
        }
        
        internal VkPipeline_T* VkPipelinePtr => m_ptr_pipeline;

        private bool m_isDisposed = false;
        private readonly VkPipeline_T* m_ptr_pipeline;

        private static VkPipeline_T* CreateGraphicsPipeline(Device i_device, PipelineCreateParams i_createParams)
        {
            VkGraphicsPipelineCreateInfo pipelineCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
                pNext = null,
                flags = 0,
                layout = i_createParams.p_layout.VkPipelineLayoutPtr,
            };

            if (!i_createParams.TryGetNext(out GraphicsPipelineCreateParams graphicsPipelineCreateParams))
            {
                throw new Exception("GraphicsPipelineCreateParams is null.");
            }
            
            #region Stages

            using ArenaAllocator allocator = new(MemorySize.FromMegabytes(1));
            using HeapAlloc<VkPipelineShaderStageCreateInfo> stages = HeapAllocator.Alloc<VkPipelineShaderStageCreateInfo>(i_createParams.p_stages.Length);
            FillStages(i_createParams.p_stages, stages, allocator);
            
            pipelineCreateInfo.stageCount = (uint)stages.Capacity;
            pipelineCreateInfo.pStages = stages.RawPtr();
            
            #endregion
            
            #region Dynamic state
            
            VkPipelineDynamicStateCreateInfo dynamicStateCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
                pNext = null,
                flags = 0,
            };
            pipelineCreateInfo.pDynamicState = &dynamicStateCreateInfo;
            
            using HeapAlloc<VkDynamicState> dynamicStates = HeapAllocator.Alloc<VkDynamicState>
            ([
                VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT_WITH_COUNT,
                VkDynamicState.VK_DYNAMIC_STATE_SCISSOR_WITH_COUNT,
                VkDynamicState.VK_DYNAMIC_STATE_BLEND_CONSTANTS, 
                VkDynamicState.VK_DYNAMIC_STATE_ALPHA_TO_COVERAGE_ENABLE_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_COLOR_BLEND_ENABLE_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_LOGIC_OP_ENABLE_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_LOGIC_OP_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_COLOR_BLEND_EQUATION_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_COLOR_WRITE_MASK_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_SAMPLE_MASK_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_RASTERIZATION_SAMPLES_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_RASTERIZER_DISCARD_ENABLE,
                VkDynamicState.VK_DYNAMIC_STATE_CULL_MODE,
                VkDynamicState.VK_DYNAMIC_STATE_POLYGON_MODE_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_PRIMITIVE_TOPOLOGY,
                VkDynamicState.VK_DYNAMIC_STATE_DEPTH_TEST_ENABLE,
                VkDynamicState.VK_DYNAMIC_STATE_DEPTH_BIAS_ENABLE,
                VkDynamicState.VK_DYNAMIC_STATE_DEPTH_CLAMP_ENABLE_EXT,
                VkDynamicState.VK_DYNAMIC_STATE_DEPTH_BIAS,
                VkDynamicState.VK_DYNAMIC_STATE_DEPTH_COMPARE_OP,
                VkDynamicState.VK_DYNAMIC_STATE_STENCIL_TEST_ENABLE,
                VkDynamicState.VK_DYNAMIC_STATE_LINE_WIDTH,
                VkDynamicState.VK_DYNAMIC_STATE_PRIMITIVE_RESTART_ENABLE,
                VkDynamicState.VK_DYNAMIC_STATE_FRONT_FACE,
                VkDynamicState.VK_DYNAMIC_STATE_VERTEX_INPUT_EXT,
            ]);
            dynamicStateCreateInfo.dynamicStateCount = (uint)dynamicStates.Capacity;
            dynamicStateCreateInfo.pDynamicStates = dynamicStates.RawPtr();

            #endregion
            
            #region Assembly state

            VkPipelineInputAssemblyStateCreateInfo inputAssemblyStateCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
                pNext = null,
                flags = 0,
                primitiveRestartEnable = Vk.VK_FALSE,
                topology = IntSharedCvs.PrimitiveTopologyToVkPrimitiveTopology(graphicsPipelineCreateParams.p_topology),
            };
            pipelineCreateInfo.pInputAssemblyState = &inputAssemblyStateCreateInfo;
            
            #endregion
            
            #region Rendering state

            HeapAlloc<VkFormat> colorFormats = HeapAllocator.Alloc<VkFormat>(graphicsPipelineCreateParams.p_colorAttachmentFormats.Length);
            for (int i = 0; i < graphicsPipelineCreateParams.p_colorAttachmentFormats.Length; i++)
            {
                *colorFormats.RawPtrAt(i) = IntSharedCvs.TextureFormatToVkFormat(graphicsPipelineCreateParams.p_colorAttachmentFormats[i]);
            }
            
            VkFormat depthStencilFormat = IntSharedCvs.TextureFormatToVkFormat(graphicsPipelineCreateParams.p_depthStencilAttachmentFormat);
            
            VkPipelineRenderingCreateInfo renderingCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RENDERING_CREATE_INFO,
                pNext = null,
                colorAttachmentCount = (uint)colorFormats.Capacity,
                pColorAttachmentFormats = colorFormats.RawPtr(),
                depthAttachmentFormat = depthStencilFormat,
                stencilAttachmentFormat = depthStencilFormat,
            };
            pipelineCreateInfo.pNext = &renderingCreateInfo;
            
            #endregion
            
            VkPipeline_T* pipeline = null;
            Vk.vkCreateGraphicsPipelines(i_device.VkDevicePtr, null, 1, &pipelineCreateInfo, null, &pipeline);
            
            return pipeline;
        }

        private static void FillStages(
            ShaderStage[] i_stages,
            HeapAlloc<VkPipelineShaderStageCreateInfo> i_vkStages,
            ArenaAllocator i_arena)
        {
            for (int i = 0; i < i_stages.Length; i++)
            {
                ref ShaderStage stage = ref i_stages[i];    
                VkPipelineShaderStageCreateInfo* vkStagePtr = i_vkStages.RawPtrAt(i);
                
                ArenaAlloc<VkShaderModuleCreateInfo> vkShader = i_arena.Alloc<VkShaderModuleCreateInfo>(1, MemorySize.FromBytes(8));
                ArenaString vkShaderName = ArenaString.CreateUTF8(stage.p_entryPoint, i_arena);
                ArenaAlloc<byte> codeAlloc = i_arena.Alloc(stage.p_code, MemorySize.FromBytes(1));
                
                VkShaderModuleCreateInfo* vkShaderPtr = vkShader.RawPtr();

                vkShaderPtr->sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
                vkShaderPtr->pNext = null;
                vkShaderPtr->flags = 0;
                vkShaderPtr->codeSize = (uint)codeAlloc.Size.ToBytes();
                vkShaderPtr->pCode = (uint*)codeAlloc.RawPtr();
                
                vkStagePtr->sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
                vkStagePtr->pNext = vkShaderPtr;
                vkStagePtr->flags = 0;
                vkStagePtr->module = null;
                vkStagePtr->stage = IntSharedCvs.ShaderStageFlagsToVkShaderStageFlagBits(stage.p_stage);
                vkStagePtr->pName = (sbyte*)vkShaderName.RawPtr();
                vkStagePtr->pSpecializationInfo = null;
            }
        }
    }   
}