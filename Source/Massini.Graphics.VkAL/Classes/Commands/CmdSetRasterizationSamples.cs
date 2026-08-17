
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
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
