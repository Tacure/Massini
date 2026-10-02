
using Massini.Flamet2.Api.Level1.Classes;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ISampler1 : IDisposable
    {
        public SamplerInfo GetInfo();

        public void SetLabel(string i_label);
    }   
}