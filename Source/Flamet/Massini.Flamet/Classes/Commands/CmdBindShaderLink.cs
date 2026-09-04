using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
