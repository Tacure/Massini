using System;
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
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
