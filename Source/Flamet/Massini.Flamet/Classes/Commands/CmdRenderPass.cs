using Massini.Flamet.Classes.Encoders;
using Massini.Flamet.Enums.Internal;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdRenderPass : Command
    {
        public RenderPassBeginParams p_beginParams;
        public RenderPassEncoder? p_encoder;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdRenderPass;

        public override void Reset()
        {
            p_beginParams = default;
            p_encoder = null;
        }
    }
}
