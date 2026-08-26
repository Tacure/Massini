
using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1.Commands
{
    public unsafe struct PushContantCmdParams : INext
    {
        public INext? p_next;
        public ShaderStageFlags p_stageFlags;
        public void* p_data;
        /// <summary>
        /// Size of the data in bytes.
        /// </summary>
        public uint p_size;

        public readonly INext? Next => p_next;
    }
}
