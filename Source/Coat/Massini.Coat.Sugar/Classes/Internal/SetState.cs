
using Massini.Coat.Classes;
using Massini.Coat.Structs;
using Massini.Core;

namespace Massini.Coat.Sugar.Classes.Internal
{
    internal class SetState
    {
        public Set? Set { get; set; }
        public Dictionary<Rid, CommandList> TakenCommandLists { get; set; } = [];
        public Dictionary<Rid, ulong> TakenTimestamps { get; set; } = [];
        public int DestructionDelay { get; set; } = 0;
    }
}