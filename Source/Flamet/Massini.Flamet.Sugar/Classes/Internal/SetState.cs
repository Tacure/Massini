using Massini.Flamet.Structs;
using Massini.Core;
using Massini.Flamet.Classes;

namespace Massini.Flamet.Sugar.Classes.Internal
{
    internal class SetState
    {
        public Set? Set { get; set; }
        public Dictionary<Rid, CommandList> TakenCommandLists { get; set; } = [];
        public Dictionary<Rid, ulong> TakenTimestamps { get; set; } = [];
        public int DestructionDelay { get; set; } = 0;
    }
}