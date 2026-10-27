
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ISwapchain1 : IDisposable
    {
        public SwapchainInfo GetInfo();

        public void BeginFrame(
            in SwapchainBeginFrameParams i_beginFrameParams, 
            out ICommandList1 o_commandList,
            out ITextureView1 o_colorView);

        public void EndFrame();
    }
}