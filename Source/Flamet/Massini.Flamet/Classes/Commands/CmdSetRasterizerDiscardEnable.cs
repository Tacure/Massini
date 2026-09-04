using System;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetRasterizerDiscardEnable : Command
    {
        public bool p_rasterizerDiscardEnable;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetRasterizerDiscardEnable;

        public override void Reset()
        {
            p_rasterizerDiscardEnable = false;
        }
    }
}
