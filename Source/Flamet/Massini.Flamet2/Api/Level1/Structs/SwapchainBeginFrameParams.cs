
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct SwapchainBeginFrameParams
    {
        public required ILane1 p_presentLane;
        public required (ICommandList1 CmdList, ulong SignalValue)[] p_waitCommandLists;
    }   
}