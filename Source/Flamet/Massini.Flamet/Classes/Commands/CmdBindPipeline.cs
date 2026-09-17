
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal class CmdBindPipeline : Command
    {
        public Pipeline? p_pipeline;
        
        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBindPipeline;
        
        public override void Reset()
        {
            p_pipeline = null;
        }
    }   
}