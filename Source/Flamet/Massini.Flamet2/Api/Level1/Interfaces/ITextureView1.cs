
using Massini.Flamet2.Api.Level1.Classes;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ITextureView1 : IDisposable
    {
        public TextureViewInfo GetInfo();

        public void SetLabel(string i_label);
    }   
}