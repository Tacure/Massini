
namespace Massini.Flamet2.Impl.Classes.Commands
{
    internal sealed class CmdEndRenderPass : BaseCommand
    {
        public int BeginIndex { get; set; } = 0;

        public override void Reset()
        {
            BeginIndex = 0;
        }
    }   
}