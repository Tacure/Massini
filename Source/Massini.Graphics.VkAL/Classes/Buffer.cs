
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using static System.Net.Mime.MediaTypeNames;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class Buffer : IResource, IDisposable
    {
        /// <inheritdoc/>
        public ResId Id => m_id;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        /// <inheritdoc/>
        public Device Device => m_device;

        /// <summary>
        /// The type of the buffer.
        /// </summary>
        public BufferType Type => m_bufferType;

        /// <summary>
        /// The size of the buffer in bytes.
        /// </summary>
        public ulong Size => m_size;

        public Buffer(Device i_device, in BufferCreateParams i_createParams)
        {
            Device device = i_device;

            var queueFamilies = device.QueueFamilies;
            uint[] queueFamiliesIndices = new uint[queueFamilies.Count];
            for (int i = 0; i < queueFamiliesIndices.Length; i++)
            {
                queueFamiliesIndices[i] = queueFamilies[i].FamilyIndex;
            }

            VkBuffer_T* buffer = null;
            VmaAllocation* allocation = null;
            VmaAllocationInfo allocationInfo = new();
            fixed (uint* queueFamiliesIndicesPtr = queueFamiliesIndices)
            {
                VkBufferCreateInfo bufferCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
                    pNext = null,
                    flags = 0,
                    sharingMode = VkSharingMode.VK_SHARING_MODE_CONCURRENT,
                    queueFamilyIndexCount = (uint)queueFamiliesIndices.Length,
                    pQueueFamilyIndices = queueFamiliesIndicesPtr,
                    size = i_createParams.p_size,
                    usage = (uint)VkUtils.BufferUsageFlagsToVkBufferUsageFlagBits(i_createParams.p_usage) |
                                  VkUtils.BufferTypeToVkBufferUsageFlags(i_createParams.p_type),
                };
                VmaAllocationCreateInfo allocationCreateInfo = new()
                {
                    p_usage = i_createParams.p_usage.HasFlag(BufferUsageFlags.HostVisible) ?
                        VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO_PREFER_HOST : VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO_PREFER_DEVICE,
                    p_requiredFlags = i_createParams.p_usage.HasFlag(BufferUsageFlags.HostVisible) ?
                        VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_HOST_COHERENT_BIT :
                        VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
                };

                Vma.vmaCreateBuffer(device.VmaAllocatorPtr, &bufferCreateInfo, &allocationCreateInfo, &buffer, &allocation, &allocationInfo);
            }

            VkUtils.SetObjectLabel(i_device, buffer, VkObjectType.VK_OBJECT_TYPE_BUFFER, $"{i_createParams.p_type} - {i_createParams.p_label}");

            m_id = ResId.GetNextId();
            m_label = i_createParams.p_label;
            m_device = device;
            m_size = i_createParams.p_size;
            m_bufferType = i_createParams.p_type;
            m_ptr_buffer = buffer;
            m_ptr_allocation = allocation;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vma.vmaDestroyBuffer(m_device.VmaAllocatorPtr, m_ptr_buffer, m_ptr_allocation);
            }
        }

        public void WriteBytes(byte* i_ptr_data, uint i_size, ulong i_bufferOffset = 0) 
        {
            WriteBytes(new Span<byte>((void*)i_ptr_data, (int)i_size), i_bufferOffset);
        }

        public void WriteBytes(ReadOnlySpan<byte> i_data, ulong i_bufferOffset = 0) 
        {
            if ((ulong)i_data.Length + i_bufferOffset > m_size)
            {
                throw new Exception("Cannot write more data than buffer size.");
            }

            void* dstMemoryPtr = null;
            VkResult result = Vma.vmaMapMemory(m_device.VmaAllocatorPtr, m_ptr_allocation, &dstMemoryPtr);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to map buffer memory.");
            }

            fixed (byte* srcDataPtr = i_data) 
            {
                System.Buffer.MemoryCopy(srcDataPtr, (void*)((nuint)dstMemoryPtr + i_bufferOffset), (long)(m_size - i_bufferOffset), i_data.Length);
                Vma.vmaUnmapMemory(m_device.VmaAllocatorPtr, m_ptr_allocation);
                Vma.vmaFlushAllocation(m_device.VmaAllocatorPtr, m_ptr_allocation, i_bufferOffset, (ulong)i_data.Length);
            }
        }

        public void ReadBytes(Span<byte> i_data, ulong i_bufferOffset = 0)
        {
            if ((ulong)i_data.Length + i_bufferOffset > m_size)
            {
                throw new Exception("Cannot read more data than buffer size.");
            }

            void* srcMemoryPtr = null;
            VkResult result = Vma.vmaMapMemory(m_device.VmaAllocatorPtr, m_ptr_allocation, &srcMemoryPtr);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to map buffer memory.");
            }

            fixed (byte* dstDataPtr = i_data)
            {
                System.Buffer.MemoryCopy((void*)((nuint)srcMemoryPtr + i_bufferOffset), dstDataPtr, i_data.Length, (long)(m_size - i_bufferOffset));
                Vma.vmaUnmapMemory(m_device.VmaAllocatorPtr, m_ptr_allocation);
            }
        }

        /// <summary>
        /// Returns the buffer device address. It can be used by shaders to access the buffer data.
        /// </summary>
        /// <returns>
        /// The buffer device address or 0 (NULL).
        /// </returns>
        public ulong GetDeviceAddress()
        {
            VkBufferDeviceAddressInfo bufferAddressInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO,
                pNext = null,  
                buffer = m_ptr_buffer,
            };

            return Vk.vkGetBufferDeviceAddress(m_device.VkDevicePtr, &bufferAddressInfo);
        }
    }

    public unsafe partial class Buffer
    {
        internal VkBuffer_T* VkBufferPtr => m_ptr_buffer;

        internal VkAccessFlagBits VkAccessMask
        {
            get
            {
                return m_accessMask;
            }
            set
            {
                m_accessMask = value;
            }
        }

        internal VkPipelineStageFlagBits VkStageMask
        {
            get
            {
                return m_stageMask;
            }
            set
            {
                m_stageMask = value;
            }
        }

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Device m_device;
        private readonly ulong m_size = 0UL;
        private readonly BufferType m_bufferType;
        private readonly VkBuffer_T* m_ptr_buffer;
        private readonly VmaAllocation* m_ptr_allocation;
        private VkAccessFlagBits m_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
        private VkPipelineStageFlagBits m_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
    }
}
