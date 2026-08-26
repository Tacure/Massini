using Massini.Coat.Enums.Internal;
using Massini.Coat.Structs.Level1;
using Massini.Coat.Classes.Encoders;

namespace Massini.Coat.Classes.Commands
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
