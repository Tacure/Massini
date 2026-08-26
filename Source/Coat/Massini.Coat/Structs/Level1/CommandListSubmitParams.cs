
using Massini.Coat.Classes;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
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
