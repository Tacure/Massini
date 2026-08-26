
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
