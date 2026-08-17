
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class QueueFamily
    {
        public Device Device => m_device!;

        public uint FamilyIndex => m_familyIndex;

        public QueueUsageFlags UsageFlags => m_usageFlags;

        public IReadOnlyList<Queue> Queues => m_queues;

        /// <summary>
        /// Only for internal use of the <see cref="Massini.Graphics.VkAL.Classes.Device"/>.
        /// </summary>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vk.vkDestroyCommandPool(m_device!.VkDevicePtr, m_ptr_commandPool, null);
            }
        }

        public CommandList CreateCommandList(in CommandListCreateParams i_createParams)
        {
            return new CommandList(this, i_createParams);
        }
    }

    public unsafe partial class QueueFamily 
    {
        internal object PoolLock => m_poolLockObj;

        internal VkCommandPool_T* VkCommandPoolPtr => m_ptr_commandPool;

        internal static QueueFamily Create(VkDevice_T* i_ptr_vkDevice, uint i_familyIndex, QueueUsageFlags i_usageFlags, List<Queue> i_queues)
        {
            VkCommandPoolCreateInfo commandPoolCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO,
                pNext = null,
                flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT,
                queueFamilyIndex = i_familyIndex,
            };

            VkCommandPool_T* commandPool = null;
            Vk.vkCreateCommandPool(i_ptr_vkDevice, &commandPoolCreateInfo, null, &commandPool);

            return new QueueFamily(i_familyIndex, i_usageFlags, i_queues, commandPool);
        }

        internal void SetDevice(Device i_device)
        {
            m_device = i_device;
        }

        private bool m_isDisposed = false;
        private Device? m_device = null;
        private readonly uint m_familyIndex;
        private readonly QueueUsageFlags m_usageFlags;
        private readonly List<Queue> m_queues = [];
        private readonly VkCommandPool_T* m_ptr_commandPool;
        private readonly object m_poolLockObj = new();

        private QueueFamily(uint i_familyIndex, QueueUsageFlags i_usageFlags, List<Queue> i_queues, VkCommandPool_T* i_ptr_commandPool = null)
        {
            m_familyIndex = i_familyIndex;
            m_usageFlags = i_usageFlags;
            m_queues = i_queues;
            m_ptr_commandPool = i_ptr_commandPool;
        }
    }
}
