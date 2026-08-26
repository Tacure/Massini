
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
