using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal abstract class Command
    {
        public abstract void Reset();

        public abstract VirtualCommandKind CommandKind { get; }
    }
}
