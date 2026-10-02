using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Lane : ILane1
    {
        public Lane(Device i_device, LaneUsageFlags i_usageFlags, uint i_familyIndex, VkQueue_T*[] i_queues)
        {
            m_device = i_device;
            m_familyIndex = i_familyIndex;
            m_queues = i_queues;
            m_info = new LaneInfo()
            {
                Id = Rid.NewId(),
                Usage = i_usageFlags,
                Device = i_device,
            };
            
            VkCommandPoolCreateInfo commandPoolCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO,
                pNext = null,
                flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT,
                queueFamilyIndex = i_familyIndex,
            };

            VkCommandPool_T* commandPool = null;
            Vk.vkCreateCommandPool(i_device.VkDevicePtr, &commandPoolCreateInfo, null, &commandPool);
            m_ptr_commandPool = commandPool;
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                
                Vk.vkDestroyCommandPool(m_device.VkDevicePtr, m_ptr_commandPool, null);
            }
        }
        
        public LaneInfo GetInfo()
        {
            return m_info;
        }

        public ITexture1 CreateTexture(in TextureCreateParams i_createParams)
        {
            return new Texture(this, i_createParams);
        }

        public IBuffer1 CreateBuffer(in BufferCreateParams i_createParams)
        {
            return new Buffer(this, in i_createParams);
        }

        public ISampler1 CreateSampler(in SamplerCreateParams i_createParams)
        {
            return new Sampler(this, i_createParams);
        }

        public ILayout1 CreateLayout(in LayoutCreateParams i_createParams)
        {
            return new Layout(this, i_createParams);
        }

        public IKernel1 CreateGraphicsKernel(in GraphicsKernelCreateParams i_createParams)
        {
            return new Kernel(this, i_createParams);
        }

        internal uint FamilyIndex => m_familyIndex;

        private bool m_isDisposed = false;
        private readonly LaneInfo m_info;
        private readonly Device m_device;
        private readonly uint m_familyIndex;
        private readonly VkQueue_T*[] m_queues;
        private readonly VkCommandPool_T* m_ptr_commandPool;
    }   
}