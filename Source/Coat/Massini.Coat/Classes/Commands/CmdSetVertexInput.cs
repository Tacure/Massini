using System;
using Massini.Coat.Enums.Internal;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetVertexInput : Command
    {
        public VertexAttributesLayout[]? p_vertexAttributesLayouts = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetVertexInput;

        public override void Reset()
        {
            p_vertexAttributesLayouts = null;
        }
    }
}
