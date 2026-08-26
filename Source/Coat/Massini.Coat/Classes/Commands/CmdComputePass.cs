using Massini.Coat.Classes.Encoders;
using Massini.Coat.Enums.Internal;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Classes.Commands
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
