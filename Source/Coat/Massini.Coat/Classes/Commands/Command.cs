using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal abstract class Command
    {
        public abstract void Reset();

        public abstract VirtualCommandKind CommandKind { get; }
    }
}
