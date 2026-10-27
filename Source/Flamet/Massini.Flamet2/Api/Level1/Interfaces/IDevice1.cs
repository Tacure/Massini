
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface IDevice1 : IDisposable
    {
        public IReadOnlyList<ILane1> GetLanes();

        public ISetAllocator1 CreateSetAllocator(in SetAllocatorCreateParams i_createParams);
        
        public IBuffer1 CreateBuffer(in BufferCreateParams i_createParams);

        public ITexture1 CreateTexture(in TextureCreateParams i_createParams);

        public ISampler1 CreateSampler(in SamplerCreateParams i_createParams);

        public ILayout1 CreateLayout(in LayoutCreateParams i_createParams);

        public IKernel1 CreateGraphicsKernel(in GraphicsKernelCreateParams i_createParams);
        
        public ISurface1 CreateSurface(in SurfaceCreateParams i_createParams);

        public ISwapchain1 CreateSwapchain(in SwapchainCreateParams i_createParams);
    }   
}