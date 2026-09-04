using Massini.Flamet.Classes.Encoders;
using Massini.Flamet.Enums.Internal;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes.Commands
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
