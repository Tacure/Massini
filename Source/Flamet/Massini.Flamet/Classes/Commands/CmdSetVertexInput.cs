using System;
using Massini.Flamet.Enums.Internal;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes.Commands
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
