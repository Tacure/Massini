using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal abstract class Command
    {
        public abstract void Reset();

        public abstract VirtualCommandKind CommandKind { get; }
    }
}
