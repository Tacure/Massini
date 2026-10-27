
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Set : ISet1
    {
        public Set(SetAllocator i_setAllocator, in SetCreateParams i_createParams)
        {
            SetAllocator allocator = (SetAllocator)i_createParams.p_setAllocator;
            Layout layout = (Layout)i_createParams.p_layout;
            Device device = (Device)layout.GetInfo().Device;
            VkDescriptorSetLayout_T* setLayoutPtr = layout.SetLayoutsPtrs[i_createParams.p_setLayoutIdx];

            // Create descriptor set.
            VkDescriptorSet_T* descriptorSetPtr = null;
            if (!allocator.AllocateSet(layout.SetDeclarations[i_createParams.p_setLayoutIdx], setLayoutPtr, out descriptorSetPtr))
            {
                throw new Exception("Failed to create descriptor set.");
            }
            m_descriptorSetPtr = descriptorSetPtr;

            m_setInfo = new SetInfo()
            {
                Id = Rid.NewId(),
                Layout = layout,
                SetAllocator = allocator,
            };
            
            // Write descriptor set.
            List<uint> bindingNumberListBuffers = [];
            List<uint> bindingNumberListImages = [];
            List<VkDescriptorType> vkDescriptorTypesListBuffers = [];
            List<VkDescriptorType> vkDescriptorTypesListImages = [];
            List<VkDescriptorBufferInfo> vkDescriptorBufferInfoList = [];
            List<VkDescriptorImageInfo> vkDescriptorImageInfoList = [];

            for (int i = 0; i < i_createParams.p_bindings.Length; i++)
            {
                ref SetEntryBinding binding = ref i_createParams.p_bindings[i];

                switch (binding.p_bindingDescription)
                {
                    case BufferBindingDescription bufferBindingDescription:
                        Buffer buffer = (Buffer)bufferBindingDescription.p_buffer;
                        VkDescriptorBufferInfo bufferInfo = new()
                        {
                            buffer = buffer.VkBufferPtr,
                            offset = bufferBindingDescription.p_offset,
                            range = bufferBindingDescription.p_range,
                        };
                        vkDescriptorBufferInfoList.Add(bufferInfo);
                        bindingNumberListBuffers.Add(binding.p_binding);
                        vkDescriptorTypesListBuffers.Add(IntSharedCvs.BufferTypeToVkDescriptorType(buffer.GetInfo().BufferType));
                        break;
                    case TextureBindingDescription textureBindingDescription:
                        switch (textureBindingDescription.p_binding)
                        {
                            case ITextureView1 textureView1:
                                TextureView textureView = (TextureView)textureView1;
                                VkDescriptorImageInfo imageInfo = new()
                                {
                                    imageView = textureView.VkImageViewPtr,
                                    sampler = null,
                                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                                };

                                vkDescriptorImageInfoList.Add(imageInfo);
                                bindingNumberListImages.Add(binding.p_binding);
                                vkDescriptorTypesListImages.Add(VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE);
                                break;
                            case ISampler1 sampler1:
                                Sampler sampler = (Sampler)sampler1;
                                VkDescriptorImageInfo samplerInfo = new()
                                {
                                    imageView = null,
                                    sampler = sampler.VkSamplerPtr,
                                    imageLayout = VkImageLayout.VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                                };

                                vkDescriptorImageInfoList.Add(samplerInfo);
                                bindingNumberListImages.Add(binding.p_binding);
                                vkDescriptorTypesListImages.Add(VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLER);
                                break;
                        }
                        break;
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
                        dstSet = descriptorSetPtr,
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
                        dstSet = descriptorSetPtr,
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
                    // TODO: Verify this method is thread-safe.
                    Vk.vkUpdateDescriptorSets(device.VkDevicePtr, (uint)vkWriteDescriptorSetsArray.Length, vkWriteDescriptorSetPtr, 0, null);
                }
            }
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
            }
        }

        public SetInfo GetInfo()
        {
            return m_setInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_setInfo.SetAllocator.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_descriptorSetPtr, VkObjectType.VK_OBJECT_TYPE_DESCRIPTOR_SET, i_label);      
        }

        private bool m_isDisposed = false;
        private readonly SetInfo m_setInfo;
        private readonly VkDescriptorSet_T* m_descriptorSetPtr;
    }
}