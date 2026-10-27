
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Kernel : IKernel1
    {
        public Kernel(Device i_device, in GraphicsKernelCreateParams i_createParams)
        {
            m_ptr_pipeline = CreateGraphicsPipeline(i_device, in i_createParams);

            m_kernelInfo = new KernelInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
                Layout = i_createParams.p_layout,
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_kernelInfo.Device;
                
                m_isDisposed = true;
                Vk.vkDestroyPipeline(device.VkDevicePtr, m_ptr_pipeline, null);
            }
        }

        public KernelInfo GetInfo()
        {
            return m_kernelInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_kernelInfo.Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_pipeline, VkObjectType.VK_OBJECT_TYPE_PIPELINE, i_label);  
        }

        private bool m_isDisposed = false;
        private readonly VkPipeline_T* m_ptr_pipeline;
        private readonly KernelInfo m_kernelInfo;
        
        private static VkPipeline_T* CreateGraphicsPipeline(Device i_device, in GraphicsKernelCreateParams i_createParams)
        {
            Layout layout = (Layout)i_createParams.p_layout;
            
            VkGraphicsPipelineCreateInfo pipelineCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
                pNext = null,
                flags = 0,
                layout = layout.VkPipelineLayoutPtr,
            };
            
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
                topology = IntSharedCvs.PrimitiveTopologyToVkPrimitiveTopology(i_createParams.p_topology),
            };
            pipelineCreateInfo.pInputAssemblyState = &inputAssemblyStateCreateInfo;
            
            #endregion
            
            #region Rendering state

            HeapAlloc<VkFormat> colorFormats = HeapAllocator.Alloc<VkFormat>(i_createParams.p_colorAttachmentFormats.Length);
            for (int i = 0; i < i_createParams.p_colorAttachmentFormats.Length; i++)
            {
                *colorFormats.RawPtrAt(i) = IntSharedCvs.TextureFormatToVkFormat(i_createParams.p_colorAttachmentFormats[i]);
            }
            
            VkFormat depthStencilFormat = IntSharedCvs.TextureFormatToVkFormat(i_createParams.p_depthStencilAttachmentFormat);
            
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