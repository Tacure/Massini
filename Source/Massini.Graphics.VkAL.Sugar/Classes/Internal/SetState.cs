
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Structs;

namespace Massini.Graphics.VkAL.Sugar.Classes.Internal
{
    internal class SetState
    {
        public Set? Set { get; set; }
        public Dictionary<ResId, CommandList> TakenCommandLists { get; set; } = [];
        public Dictionary<ResId, ulong> TakenTimestamps { get; set; } = [];
        public int DestructionDelay { get; set; } = 0;
    }
}