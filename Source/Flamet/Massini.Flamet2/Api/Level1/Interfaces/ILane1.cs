
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ILane1 : IDisposable
    {
        public LaneInfo GetInfo();

        /// <summary>
        /// Wait for the lane to become idle.
        /// </summary>
        public void WaitIdle();
        
        public ICommandList1 CreateCommandList();
    }   
}