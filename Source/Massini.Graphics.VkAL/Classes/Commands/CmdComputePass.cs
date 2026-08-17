using Massini.Graphics.VkAL.Classes.Encoders;
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdComputePass : Command
    {
        public ComputePassBeginParams p_beginParams;
        public ComputePassEncoder? p_encoder;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdComputePass;

        public override void Reset()
        {
            p_beginParams = default;
            p_encoder = null;
        }
    }
}
