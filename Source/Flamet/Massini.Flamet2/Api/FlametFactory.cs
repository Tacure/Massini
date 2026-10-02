using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using Massini.Flamet2.Impl.Classes;

namespace Massini.Flamet2.Api
{
    public static class FlametFactory
    {
        public static IDevice1 Initialize(in DeviceCreateParams i_createParams, IAdapterSelector i_selector)
        {
            return new Device(i_createParams, i_selector);
        }
    }   
}