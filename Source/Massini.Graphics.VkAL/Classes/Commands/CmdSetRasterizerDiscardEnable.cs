using System;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
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
