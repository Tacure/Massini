
using Massini.Flamet2.Api.Level1.Classes;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface IKernel1 : IDisposable
    {
        public KernelInfo GetInfo();

        public void SetLabel(string i_label);
    }   
}