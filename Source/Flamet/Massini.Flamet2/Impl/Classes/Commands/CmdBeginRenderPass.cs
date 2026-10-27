
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes.Commands
{
    internal sealed class CmdBeginRenderPass : BaseCommand
    {
        public int EndIndex { get; set; } = 0;
        public RenderPassBeginParams BeginParams { get; set; } = default;

        public override void Reset()
        {
            EndIndex = 0;
            BeginParams = default;
        }
    }   
}