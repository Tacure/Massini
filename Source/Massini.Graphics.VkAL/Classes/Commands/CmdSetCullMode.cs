
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetCullMode : Command
    {
        public CullMode p_cullMode;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetCullMode;

        public override void Reset()
        {
            p_cullMode = CullMode.None;
        }
    }
}