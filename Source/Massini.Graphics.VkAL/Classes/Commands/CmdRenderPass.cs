using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Classes.Encoders;

namespace Massini.Graphics.VkAL.Classes.Commands
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
