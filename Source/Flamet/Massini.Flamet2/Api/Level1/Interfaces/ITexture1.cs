
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ITexture1 : IDisposable
    {
        public TextureInfo GetInfo();

        public ILane1 GetLane();
        
        public void SetLabel(string i_label);

        public ITextureView1 CreateTextureView(in TextureViewCreateParams i_createParams);
    }   
}