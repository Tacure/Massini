
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct CommandListSubmitParams : INext
    {
        public required INext? p_next;
        /// <summary>
        /// Lane that will execute this command buffer.
        /// </summary>
        public required ILane1 p_lane;
        /// <summary>
        /// Command lists that will be waited (in the GPU) before executing this command list.
        /// </summary>
        public required (ICommandList1 CmdList, ulong SignalValue)[] p_waitCommandLists;

        public readonly INext? Next => p_next;
    }
}