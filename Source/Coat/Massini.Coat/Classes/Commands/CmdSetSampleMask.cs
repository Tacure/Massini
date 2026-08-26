
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetSampleMask : Command
    {
        public SampleCount p_samples = SampleCount.SampleCount1;
        public uint[]? p_mask = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetSampleMask;

        public override void Reset()
        {
            p_samples = SampleCount.SampleCount1;
            p_mask = null;
        }
    }
}
