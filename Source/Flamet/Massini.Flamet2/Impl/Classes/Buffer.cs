
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Buffer : IBuffer1
    {
        public Buffer(Lane i_lane, in BufferCreateParams i_createParams)
        {
            Device device = (Device)i_lane.GetInfo().Device;

            uint familyIndex = i_lane.FamilyIndex;
            VkBuffer_T* buffer = null;
            VmaAllocation* allocation = null;
            VmaAllocationInfo allocationInfo = new();
            VkBufferCreateInfo bufferCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
                pNext = null,
                flags = 0,
                sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                queueFamilyIndexCount = ONE,
                pQueueFamilyIndices = &familyIndex,
                size = i_createParams.p_size.ToBytes(),
                usage = (uint)IntSharedCvs.BufferUsageFlagsToVkBufferUsageFlagBits(i_createParams.p_usage) |
                        IntSharedCvs.BufferTypeToVkBufferUsageFlags(i_createParams.p_type),
            };
            VmaAllocationCreateInfo allocationCreateInfo = new()
            {
                p_usage = i_createParams.p_usage.HasFlag(BufferUsageFlags.HostVisible) ?
                    VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO_PREFER_HOST : VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO_PREFER_DEVICE,
                p_requiredFlags = i_createParams.p_usage.HasFlag(BufferUsageFlags.HostVisible) ?
                    VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT | VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_HOST_COHERENT_BIT :
                    VkMemoryPropertyFlagBits.VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT,
            };

            // TODO: Check if VMA is thread safe, if not, create a wrapper class with locks.
            VkResult result = Vma.vmaCreateBuffer(device.VmaAllocatorPtr, &bufferCreateInfo, &allocationCreateInfo, &buffer, &allocation, &allocationInfo);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create buffer");
            }
            
            m_bufferInfo = new BufferInfo()
            {
                Id = Rid.NewId(),
                BufferType = i_createParams.p_type,
                Size = i_createParams.p_size,
            };
            m_lane = i_lane;
            m_ptr_buffer = buffer;
            m_ptr_allocation = allocation;
            m_bufferBarrierState = new BufferBarrierState();
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_lane.GetInfo().Device;
                
                m_isDisposed = true;
                // TODO: Check if VMA is thread safe, if not, create a wrapper class with locks.
                Vma.vmaDestroyBuffer(device.VmaAllocatorPtr, m_ptr_buffer, m_ptr_allocation);
            }
        }

        public BufferInfo GetInfo()
        {
            return m_bufferInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_lane.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_buffer, VkObjectType.VK_OBJECT_TYPE_BUFFER, i_label);        
        }
        
        public ulong GetDeviceAddress()
        {
            Device device = (Device)m_lane.GetInfo().Device;
            
            VkBufferDeviceAddressInfo bufferAddressInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO,
                pNext = null,  
                buffer = m_ptr_buffer,
            };

            return Vk.vkGetBufferDeviceAddress(device.VkDevicePtr, &bufferAddressInfo);
        }

        public void WriteBytes(ReadOnlySpan<byte> i_data, MemorySize i_bufferOffset = default)
        {
            Device device = (Device)m_lane.GetInfo().Device;
            
            nuint offset = i_bufferOffset.ToBytes();
            nuint size = m_bufferInfo.Size.ToBytes();
            
            if ((ulong)i_data.Length + offset > size)
            {
                throw new Exception("Cannot write more data than buffer size.");
            }

            void* dstMemoryPtr = null;
            VkResult result = Vma.vmaMapMemory(device.VmaAllocatorPtr, m_ptr_allocation, &dstMemoryPtr);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to map buffer memory.");
            }

            fixed (byte* srcDataPtr = i_data) 
            {
                System.Buffer.MemoryCopy(srcDataPtr, (void*)((nuint)dstMemoryPtr + offset), (long)(size - offset), i_data.Length);
                Vma.vmaUnmapMemory(device.VmaAllocatorPtr, m_ptr_allocation);
                Vma.vmaFlushAllocation(device.VmaAllocatorPtr, m_ptr_allocation, i_bufferOffset.ToBytes(), (ulong)i_data.Length);
            }
        }

        public void ReadBytes(Span<byte> i_data, MemorySize i_bufferOffset = default)
        {
            Device device = (Device)m_lane.GetInfo().Device;
            
            nuint offset = i_bufferOffset.ToBytes();
            nuint size = m_bufferInfo.Size.ToBytes();
            
            if ((ulong)i_data.Length + offset > size)
            {
                throw new Exception("Cannot read more data than buffer size.");
            }

            void* srcMemoryPtr = null;
            VkResult result = Vma.vmaMapMemory(device.VmaAllocatorPtr, m_ptr_allocation, &srcMemoryPtr);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to map buffer memory.");
            }

            fixed (byte* dstDataPtr = i_data)
            {
                System.Buffer.MemoryCopy((void*)((nuint)srcMemoryPtr + offset), dstDataPtr, i_data.Length, i_data.Length);
                Vma.vmaUnmapMemory(device.VmaAllocatorPtr, m_ptr_allocation);
            }
        }

        internal VkBuffer_T* VkBufferPtr => m_ptr_buffer;
        
        private bool m_isDisposed = false;
        private readonly BufferInfo m_bufferInfo;
        private readonly Lane m_lane;
        private readonly VkBuffer_T* m_ptr_buffer;
        private readonly VmaAllocation* m_ptr_allocation;
        private BufferBarrierState m_bufferBarrierState;
    }   
}