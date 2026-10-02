
namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface IAdapterSelector
    {
        public IAdapter1? Select(IReadOnlyList<IAdapter1> i_adapters);
    }   
}