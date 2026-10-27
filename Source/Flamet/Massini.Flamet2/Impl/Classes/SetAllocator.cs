
using System.Diagnostics.CodeAnalysis;
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class SetAllocator : ISetAllocator1
    {
        public SetAllocator(Device i_device, in SetAllocatorCreateParams i_createParams)
        {
            m_setAllocatorInfo = new SetAllocatorInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
                BlockSize = i_createParams.p_blockSize,
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_setAllocatorInfo.Device;
                
                m_isDisposed = true;
                foreach (List<DescriptorPoolBlock> pool in m_poolBlocks.Values)
                {
                    foreach (var block in pool)
                    {
                        Vk.vkDestroyDescriptorPool(device.VkDevicePtr, block.p_ptr_pool, null);
                    }
                }
                m_poolBlocks.Clear();
                m_descriptorToPool.Clear();
            }
        }

        public SetAllocatorInfo GetInfo()
        {
            return m_setAllocatorInfo;
        }

        public ISet1 CreateSet(in SetCreateParams i_createParams)
        {
            return new Set(this, in i_createParams);
        }
        
        internal bool AllocateSet(SetDeclaration i_declaration, VkDescriptorSetLayout_T* i_ptr_layout, out VkDescriptorSet_T* o_ptr_set)
        {
            o_ptr_set = null;

            // Build fingerprint.

            uint sampledImageCount = 0;
            uint samplerCount = 0;
            uint storageCount = 0;
            uint uniformCount = 0;

            for (int i = 0; i < i_declaration.p_entries.Length; i++)
            {
                ref SetEntryDeclaration entryDeclaration = ref i_declaration.p_entries[i];

                switch (entryDeclaration.p_type)
                {
                    case EntryType.UniformBuffer:
                        uniformCount += entryDeclaration.p_count;
                        break;
                    case EntryType.StorageBuffer:
                        storageCount += entryDeclaration.p_count;
                        break;
                    case EntryType.Texture:
                        sampledImageCount += entryDeclaration.p_count;
                        break;
                    case EntryType.Sampler:
                        samplerCount += entryDeclaration.p_count;
                        break;
                }
            }

            DescriptorAllocatorPoolFingerprint fingerprint = new()
            {
                p_samplerCount = samplerCount,
                p_sampledImageCount = sampledImageCount,
                p_uniformCount = uniformCount,
                p_storageCount = storageCount,
            };

            if (!m_poolBlocks.TryGetValue(fingerprint, out List<DescriptorPoolBlock>? poolBlocks))
            {
                poolBlocks = [];
                m_poolBlocks[fingerprint] = poolBlocks;
            }

            for (int i = 0; i < poolBlocks.Count; i++)
            {
                var poolBlock = poolBlocks[i];
                if (poolBlock.p_setsAllocated < poolBlock.p_setsCapacity)
                {
                    if (TryAllocateSet(poolBlock, i_ptr_layout, out o_ptr_set))
                        return true;
                }
            }

            // Create a new pool if there is no space.
            if (CreateNewBlock(fingerprint, poolBlocks) != true)
                return false;

            var newBlock = poolBlocks[^1];
            if (!TryAllocateSet(newBlock, i_ptr_layout, out o_ptr_set))
                return false;

            return true;
        }

        internal bool FreeSet(VkDescriptorSet_T* i_ptr_set)
        {
            Device device = (Device)m_setAllocatorInfo.Device;
            
            if (!m_descriptorToPool.TryGetValue((nuint)i_ptr_set, out DescriptorPoolBlock? poolBlock))
                return false;

            VkResult result = Vk.vkFreeDescriptorSets(device.VkDevicePtr, poolBlock.p_ptr_pool, 1, &i_ptr_set);
            if (result != VkResult.VK_SUCCESS)
                return false;

            poolBlock.p_setsAllocated--;
            if (poolBlock.p_setsAllocated == 0)
            {
                Vk.vkResetDescriptorPool(device.VkDevicePtr, poolBlock.p_ptr_pool, 0);
            }

            m_descriptorToPool.Remove((nuint)i_ptr_set);
            return true;
        }

        private struct DescriptorAllocatorPoolFingerprint : IEquatable<DescriptorAllocatorPoolFingerprint>
        {
            public required uint p_samplerCount;
            public required uint p_sampledImageCount;
            public required uint p_uniformCount;
            public required uint p_storageCount;

            public readonly bool Equals(DescriptorAllocatorPoolFingerprint i_other)
            {
                return
                    p_samplerCount == i_other.p_samplerCount &&
                    p_sampledImageCount == i_other.p_sampledImageCount &&
                    p_uniformCount == i_other.p_uniformCount &&
                    p_storageCount == i_other.p_storageCount;
            }

            public readonly override int GetHashCode()
            {
                return HashCode.Combine(p_samplerCount, p_sampledImageCount, p_uniformCount, p_storageCount);
            }

            public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
            {
                return i_obj is DescriptorAllocatorPoolFingerprint fingerprint && Equals(fingerprint);
            }
        }
        
        private class DescriptorPoolBlock
        {
            public required VkDescriptorPool_T* p_ptr_pool;
            public required uint p_setsAllocated;
            public required uint p_setsCapacity;
        }

        private bool m_isDisposed = false;
        private readonly SetAllocatorInfo m_setAllocatorInfo;
        private readonly Dictionary<DescriptorAllocatorPoolFingerprint, List<DescriptorPoolBlock>> m_poolBlocks = [];
        private readonly Dictionary<nuint, DescriptorPoolBlock> m_descriptorToPool = [];
        
        private bool TryAllocateSet(DescriptorPoolBlock i_block, VkDescriptorSetLayout_T* i_ptr_layout, out VkDescriptorSet_T* o_ptr_set)
        {
            Device device = (Device)m_setAllocatorInfo.Device;
            
            o_ptr_set = null;

            VkDescriptorSetLayout_T** setLayoutsPtr = stackalloc VkDescriptorSetLayout_T*[1];
            setLayoutsPtr[0] = i_ptr_layout;

            VkDescriptorSetAllocateInfo allocInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO,
                pNext = null,
                descriptorPool = i_block.p_ptr_pool,
                descriptorSetCount = 1,
                pSetLayouts = setLayoutsPtr,
            };

            VkDescriptorSet_T* descriptorSet = null;
            VkResult result = Vk.vkAllocateDescriptorSets(device.VkDevicePtr, &allocInfo, &descriptorSet);
            if (result != VkResult.VK_SUCCESS)
                return false;

            i_block.p_setsAllocated++;
            m_descriptorToPool[(nuint)descriptorSet] = i_block;
            o_ptr_set = descriptorSet;
            return true;
        }

        private bool CreateNewBlock(DescriptorAllocatorPoolFingerprint i_fingerPrint, List<DescriptorPoolBlock> i_poolBlocks)
        {
            Device device = (Device)m_setAllocatorInfo.Device;
            
            uint blockSize = m_setAllocatorInfo.BlockSize;
            
            List<VkDescriptorPoolSize> poolSizes = [];

            if (i_fingerPrint.p_uniformCount > 0)
            {
                poolSizes.Add(new VkDescriptorPoolSize
                {
                    type = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER,
                    descriptorCount = blockSize * i_fingerPrint.p_uniformCount,
                });
            }
            if (i_fingerPrint.p_storageCount > 0)
            {
                poolSizes.Add(new VkDescriptorPoolSize
                {
                    type = VkDescriptorType.VK_DESCRIPTOR_TYPE_STORAGE_BUFFER,
                    descriptorCount = blockSize * i_fingerPrint.p_storageCount,
                });
            }
            if (i_fingerPrint.p_samplerCount > 0)
            {
                poolSizes.Add(new VkDescriptorPoolSize
                {
                    type = VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLER,
                    descriptorCount = blockSize * i_fingerPrint.p_samplerCount,
                });
            }
            if (i_fingerPrint.p_sampledImageCount > 0)
            {
                poolSizes.Add(new VkDescriptorPoolSize
                {
                    type = VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE,
                    descriptorCount = blockSize * i_fingerPrint.p_sampledImageCount,
                });
            }

            fixed (VkDescriptorPoolSize* poolSizesPtr = poolSizes.ToArray())
            {
                VkDescriptorPoolCreateInfo vkDescriptorPoolCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO,
                    pNext = null,
                    flags = (uint)(VkDescriptorPoolCreateFlagBits.VK_DESCRIPTOR_POOL_CREATE_FREE_DESCRIPTOR_SET_BIT |
                                   VkDescriptorPoolCreateFlagBits.VK_DESCRIPTOR_POOL_CREATE_UPDATE_AFTER_BIND_BIT),
                    poolSizeCount = (uint)poolSizes.Count,
                    pPoolSizes = poolSizesPtr,
                    maxSets = blockSize,
                };

                VkDescriptorPool_T* descriptorPool = null;
                VkResult result = Vk.vkCreateDescriptorPool(device.VkDevicePtr, &vkDescriptorPoolCreateInfo, null, &descriptorPool);
                if (result != VkResult.VK_SUCCESS)
                {
                    return false;
                }

                i_poolBlocks.Add(new DescriptorPoolBlock()
                {
                    p_ptr_pool = descriptorPool,
                    p_setsAllocated = 0,
                    p_setsCapacity = blockSize,
                });
            }

            return true;
        }
    }   
}