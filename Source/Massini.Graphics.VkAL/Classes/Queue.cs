
using Massini.Bindings.Vulkan;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class Queue
    {
        public QueueFamily QueueFamily => m_queueFamily!;

        public void WaitIdle()
        {
            Vk.vkQueueWaitIdle(m_ptr_queue);
        }
    }

    public unsafe partial class Queue 
    {
        internal VkQueue_T* VkQueuePtr => m_ptr_queue;

        internal static Queue Create(uint i_queueFamilyIndex, VkQueue_T* i_ptr_queue)
        {
            return new Queue(i_ptr_queue);
        }

        /// <summary>
        /// Only for internal use of the <see cref="QueueFamily"/>.
        /// </summary>
        /// <param name="i_queueFamily"></param>
        internal void SetQueueFamily(QueueFamily i_queueFamily)
        {
            m_queueFamily = i_queueFamily;
        }

        private readonly VkQueue_T* m_ptr_queue;
        private QueueFamily? m_queueFamily = null;

        private Queue(VkQueue_T* i_ptr_queue)
        {
            m_ptr_queue = i_ptr_queue;
        }
    }
}
