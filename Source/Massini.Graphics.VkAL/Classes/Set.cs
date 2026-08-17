
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Classes.Internal;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class Set : IResource, IDisposable
    {
        public bool IsDisposed => m_isDisposed;

        public ResId Id => m_id;

        public Device Device => m_layout.Device;

        public Layout Layout => m_layout;


        public Set(Layout i_layout, in SetCreateParams i_createParams)
        {
            DescriptorAllocator allocator = i_layout.Device.DescriptorAllocator;
            VkDescriptorSetLayout_T* setLayoutPtr = i_layout.SetLayoutsPtrs[i_createParams.p_setLayoutIdx];

            VkDescriptorSet_T* descriptorSetPtr = null;
            if (!allocator.AllocateSet(i_layout.SetDeclarations[i_createParams.p_setLayoutIdx], setLayoutPtr, out descriptorSetPtr))
            {
                throw new Exception("Failed to create descriptor set.");
            }

            List<uint> bindingNumberListBuffers = [];
            List<uint> bindingNumberListImages = [];
            List<VkDescriptorType> vkDescriptorTypesListBuffers = [];
            List<VkDescriptorType> vkDescriptorTypesListImages = [];
            List<VkDescriptorBufferInfo> vkDescriptorBufferInfoList = [];
            List<VkDescriptorImageInfo> vkDescriptorImageInfoList = [];

            for (int i = 0; i < i_createParams.p_bindings.Length; i++)
            {
                ref SetEntryBinding binding = ref i_createParams.p_bindings[i];

                if (binding.p_bufferBinding.HasValue)
                {
                    BufferBindingDescription bufferBinding = binding.p_bufferBinding.Value;
                    Buffer? buffer = bufferBinding.p_buffer;

                    VkDescriptorBufferInfo bufferInfo = new()
                    {
                        buffer = buffer != null ? buffer.VkBufferPtr : null,
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
                    Vk.vkUpdateDescriptorSets(i_layout.Device.VkDevicePtr, (uint)vkWriteDescriptorSetsArray.Length, vkWriteDescriptorSetPtr, 0, null);
                }
            }

            VkUtils.SetObjectLabel(i_layout.Device, descriptorSetPtr, VkObjectType.VK_OBJECT_TYPE_DESCRIPTOR_SET, i_createParams.p_label);

            m_id = ResId.GetNextId();
            m_label = i_createParams.p_label;
            m_layout = i_layout;
            m_ptr_set = descriptorSetPtr;
            m_bindingDescriptions = i_createParams.p_bindings;
            m_setLayoutIdx = i_createParams.p_setLayoutIdx;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                m_layout.Device.DescriptorAllocator.FreeSet(m_ptr_set);
            }
        }

        internal VkDescriptorSet_T* VkDescriptorSetPtr => m_ptr_set;

        internal SetEntryBinding[] BindingDescriptions => m_bindingDescriptions;

        internal uint SetLayoutIdx => m_setLayoutIdx;

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Layout m_layout;
        private readonly VkDescriptorSet_T* m_ptr_set;
        private readonly SetEntryBinding[] m_bindingDescriptions;
        private readonly uint m_setLayoutIdx;
    }
}
