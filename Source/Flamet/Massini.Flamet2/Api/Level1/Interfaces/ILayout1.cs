
using Massini.Flamet2.Api.Level1.Classes;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ILayout1 : IDisposable
    {
        public LayoutInfo GetInfo();
        
        public void SetLabel(string i_label);
    }   
}