
namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface IDevice1 : IDisposable
    {
        public IReadOnlyList<ILane1> GetLanes();
    }   
}