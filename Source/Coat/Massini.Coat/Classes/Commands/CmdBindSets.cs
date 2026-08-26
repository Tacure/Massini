using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdBindSets : Command
    {
        public uint p_firstSet = 0;
        public Set[] p_pipelineSets = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBindSets;

        public override void Reset()
        {
            p_firstSet = 0;
            p_pipelineSets = [];
        }
    }
}
