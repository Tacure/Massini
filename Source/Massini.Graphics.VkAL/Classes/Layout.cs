
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class Layout : IResource, IDisposable
    {
        public ResId Id => m_id;

        public bool IsDisposed => m_isDisposed;

        public Device Device => m_device;

        public Layout(Device i_device, in LayoutCreateParams i_createParams)
        {
            // Create descriptor set layouts.
            SetDeclaration[] setDeclarations = i_createParams.p_sets;
            VkDescriptorSetLayout_T*[] setLayouts = new VkDescriptorSetLayout_T*[setDeclarations.Length];
            for (int i = 0; i < setDeclarations.Length; i++)
            {
                ref SetDeclaration setDeclaration = ref setDeclarations[i];
                VkDescriptorSetLayout_T* descriptorSetLayout = CreateSetLayout(i_device, in setDeclaration);
                setLayouts[i] = descriptorSetLayout;
            }

            // Create layout.
            VkPipelineLayout_T* pipelineLayout = CreateLayout(i_device, setLayouts, i_createParams.p_pushConstant, out m_pushConstantRange);

            VkUtils.SetObjectLabel(i_device, pipelineLayout, VkObjectType.VK_OBJECT_TYPE_PIPELINE_LAYOUT, $"{nameof(Layout)} - {i_createParams.p_label}");

            m_device = i_device;
            m_id = ResId.GetNextId();
            m_label = i_createParams.p_label;
            m_setLayoutsPtrs = setLayouts;
            m_ptr_pipelineLayout = pipelineLayout;
            m_setDeclarations = setDeclarations;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                for (int i = 0; i < m_setLayoutsPtrs.Length; i++)
                {
                    Vk.vkDestroyDescriptorSetLayout(m_device.VkDevicePtr, m_setLayoutsPtrs[i], null);
                }
                Vk.vkDestroyPipelineLayout(m_device.VkDevicePtr, m_ptr_pipelineLayout, null);
            }
        }

        public Set CreateSet(in SetCreateParams i_createParams)
        {
            return new Set(this, i_createParams);
        }

        internal VkPipelineLayout_T* VkPipelineLayoutPtr => m_ptr_pipelineLayout;

        internal VkDescriptorSetLayout_T*[] SetLayoutsPtrs => m_setLayoutsPtrs;

        internal VkPushConstantRange? PushConstantRange => m_pushConstantRange;

        internal SetDeclaration[] SetDeclarations => m_setDeclarations;

        private bool m_isDisposed = false;
        private readonly ResId m_id;
        private readonly string m_label;
        private readonly Device m_device;
        private readonly VkDescriptorSetLayout_T*[] m_setLayoutsPtrs;
        private readonly VkPipelineLayout_T* m_ptr_pipelineLayout;
        private readonly VkPushConstantRange? m_pushConstantRange;
        private readonly SetDeclaration[] m_setDeclarations;

        private static VkDescriptorSetLayout_T* CreateSetLayout(Device i_device, in SetDeclaration i_setDeclaration)
        {
            VkDescriptorSetLayoutBinding[] bindings = new VkDescriptorSetLayoutBinding[i_setDeclaration.p_entries.Length];
            for (int entryIdx = 0; entryIdx < i_setDeclaration.p_entries.Length; entryIdx++)
            {
                VkDescriptorSetLayoutBinding descriptorSetLayoutBinding = new()
                {
                    binding = i_setDeclaration.p_entries[entryIdx].p_binding,
                    descriptorType = VkUtils.EntryTypeToVkDescriptorType(i_setDeclaration.p_entries[entryIdx].p_type),
                    stageFlags = (uint)VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(i_setDeclaration.p_entries[entryIdx].p_stages),
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
                pushConstantRange.stageFlags = (uint)VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(i_pushConstant.Value.p_stage);
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
