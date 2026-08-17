
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdBindShaderLink : Command
    {
        public ShaderLink? p_shaderLink = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBindShaderLink;

        public override void Reset()
        {
            p_shaderLink = null;
        }
    }
}
