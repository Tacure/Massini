
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct CommandListSubmitParams : INext
    {
        public required INext? p_next;
        /// <summary>
        /// Queue that will execute this command buffer.
        /// </summary>
        public required Queue p_queue;
        /// <summary>
        /// Command lists that will be waited (in the GPU) before executing this command list.
        /// </summary>
        public required CommandList[] p_waitCommandLists;

        public readonly INext? Next => p_next;
    }
}
