
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public interface ISetAllocator1 : IDisposable
    {
        public SetAllocatorInfo GetInfo();

        public ISet1 CreateSet(in SetCreateParams i_createParams);
    }   
}