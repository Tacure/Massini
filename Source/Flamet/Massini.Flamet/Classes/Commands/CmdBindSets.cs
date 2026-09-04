using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
