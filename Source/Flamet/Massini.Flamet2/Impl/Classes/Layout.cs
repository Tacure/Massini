
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Layout : ILayout1
    {
        public Layout(Lane i_lane, in LayoutCreateParams i_createParams)
        {
            Device device = (Device)i_lane.GetInfo().Device;
            
            // Create descriptor set layouts.
            SetDeclaration[] setDeclarations = i_createParams.p_sets;
            VkDescriptorSetLayout_T*[] setLayouts = new VkDescriptorSetLayout_T*[setDeclarations.Length];
            for (int i = 0; i < setDeclarations.Length; i++)
            {
                ref SetDeclaration setDeclaration = ref setDeclarations[i];
                VkDescriptorSetLayout_T* descriptorSetLayout = CreateSetLayout(device, in setDeclaration);
                setLayouts[i] = descriptorSetLayout;
            }

            // Create layout.
            VkPipelineLayout_T* pipelineLayout = CreateLayout(device, setLayouts, i_createParams.p_pushConstant, out m_pushConstantRange);

            m_lane = i_lane;
            m_setLayoutsPtrs = setLayouts;
            m_ptr_pipelineLayout = pipelineLayout;
            m_setDeclarations = setDeclarations;
            m_layoutInfo = new LayoutInfo()
            {
                Id = Rid.NewId(),
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_lane.GetInfo().Device;
                
                m_isDisposed = true;
                for (int i = 0; i < m_setLayoutsPtrs.Length; i++)
                {
                    Vk.vkDestroyDescriptorSetLayout(device.VkDevicePtr, m_setLayoutsPtrs[i], null);
                }
                Vk.vkDestroyPipelineLayout(device.VkDevicePtr, m_ptr_pipelineLayout, null);
            }
        }

        public LayoutInfo GetInfo()
        {
            return m_layoutInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_lane.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_pipelineLayout, VkObjectType.VK_OBJECT_TYPE_PIPELINE_LAYOUT, i_label);  
        }

        private bool m_isDisposed = false;
        private readonly Lane m_lane;
        private readonly VkDescriptorSetLayout_T*[] m_setLayoutsPtrs;
        private readonly VkPipelineLayout_T* m_ptr_pipelineLayout;
        private readonly VkPushConstantRange? m_pushConstantRange;
        private readonly SetDeclaration[] m_setDeclarations;
        private readonly LayoutInfo m_layoutInfo;
        
        private static VkDescriptorSetLayout_T* CreateSetLayout(Device i_device, in SetDeclaration i_setDeclaration)
        {
            VkDescriptorSetLayoutBinding[] bindings = new VkDescriptorSetLayoutBinding[i_setDeclaration.p_entries.Length];
            for (int entryIdx = 0; entryIdx < i_setDeclaration.p_entries.Length; entryIdx++)
            {
                VkDescriptorSetLayoutBinding descriptorSetLayoutBinding = new()
                {
                    binding = i_setDeclaration.p_entries[entryIdx].p_binding,
                    descriptorType = IntSharedCvs.EntryTypeToVkDescriptorType(i_setDeclaration.p_entries[entryIdx].p_type),
                    stageFlags = (uint)IntSharedCvs.ShaderStageFlagsToVkShaderStageFlagBits(i_setDeclaration.p_entries[entryIdx].p_stages),
                    descriptorCount = i_setDeclaration.p_entries[entryIdx].p_count,
                    pImmutableSamplers = null,
                };
                bindings[entryIdx] = descriptorSetLayoutBinding;
            }

            fixed (VkDescriptorSetLayoutBinding* bindingsPtr = bindings)
            {
                VkDescriptorSetLayoutCreateInfo descriptorSetLayoutCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO,
                    pNext = null,
                    flags = (uint)(i_setDeclaration.p_pushSet ? VkDescriptorSetLayoutCreateFlagBits.VK_DESCRIPTOR_SET_LAYOUT_CREATE_PUSH_DESCRIPTOR_BIT : 0),
                    bindingCount = (uint)bindings.Length,
                    pBindings = bindingsPtr,
                };

                VkDescriptorSetLayout_T* descriptorSetLayout;
                Vk.vkCreateDescriptorSetLayout(((Device)i_device).VkDevicePtr, &descriptorSetLayoutCreateInfo, null, &descriptorSetLayout);

                return descriptorSetLayout;
            }
        }

        private static VkPipelineLayout_T* CreateLayout(Device i_device, VkDescriptorSetLayout_T*[] i_setLayouts, PushConstantDescription? i_pushConstant, out VkPushConstantRange? o_pushConstantRange)
        {
            o_pushConstantRange = null;

            VkPushConstantRange pushConstantRange = new();
            if (i_pushConstant.HasValue) 
            {
                pushConstantRange.stageFlags = (uint)IntSharedCvs.ShaderStageFlagsToVkShaderStageFlagBits(i_pushConstant.Value.p_stage);
                pushConstantRange.offset = 0;
                pushConstantRange.size = i_pushConstant.Value.p_size;

                o_pushConstantRange = pushConstantRange;
            }

            VkPipelineLayout_T* pipelineLayout;
            fixed (VkDescriptorSetLayout_T** descriptorSetLayoutsPtr = i_setLayouts)
            {
                VkPipelineLayoutCreateInfo pipelineLayoutCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO,
                    pNext = null,
                    flags = 0,
                    setLayoutCount = (uint)i_setLayouts.Length,
                    pSetLayouts = descriptorSetLayoutsPtr,
                    pushConstantRangeCount = i_pushConstant.HasValue ? 1U : 0U,
                    pPushConstantRanges = i_pushConstant.HasValue ? &pushConstantRange : null,
                };

                Vk.vkCreatePipelineLayout(((Device)i_device).VkDevicePtr, &pipelineLayoutCreateInfo, null, &pipelineLayout);
            }

            return pipelineLayout;
        }
    }   
}