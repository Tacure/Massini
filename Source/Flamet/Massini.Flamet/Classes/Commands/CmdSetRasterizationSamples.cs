using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetRasterizationSamples : Command
    {
        public SampleCount p_rasterizationSamples = SampleCount.SampleCount1;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetRasterizationSamples;

        public override void Reset()
        {
            p_rasterizationSamples = SampleCount.SampleCount1;
        }
    }
}
