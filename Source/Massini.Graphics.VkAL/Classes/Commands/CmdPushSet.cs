
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal class CmdPushSet : Command
    {
        internal uint p_set = 0;
        internal SetEntryBinding[] p_bindingDescription = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdPushSet;

        public override void Reset()
        {
            p_set = 0;
            p_bindingDescription = [];
        }
    }
}
