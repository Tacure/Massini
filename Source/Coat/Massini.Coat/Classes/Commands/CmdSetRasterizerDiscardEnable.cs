using System;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
