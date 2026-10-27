
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ICommandList1 : IDisposable
    {
        public CommandListInfo GetInfo();

        public ulong GetSignalValue();

        public void WaitIdle(TimeSpan i_timeout);

        public void Open();

        public void Close();

        public void Submit(in CommandListSubmitParams i_submitParams);

        public void CmdBeginRenderPass(in RenderPassBeginParams i_beginParams);
        
        public void CmdEndRenderPass();
    }   
}