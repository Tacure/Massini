
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ILane1 : IDisposable
    {
        public LaneInfo GetInfo();

        public ITexture1 CreateTexture(in TextureCreateParams i_createParams);

        public IBuffer1 CreateBuffer(in BufferCreateParams i_createParams);
        
        public ISampler1 CreateSampler(in SamplerCreateParams i_createParams);
        
        public ILayout1 CreateLayout(in LayoutCreateParams i_createParams);
        
        public IKernel1 CreateGraphicsKernel(in GraphicsKernelCreateParams i_createParams);
    }   
}