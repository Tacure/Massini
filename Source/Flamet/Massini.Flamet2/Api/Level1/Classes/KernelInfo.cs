
using Massini.Core;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class KernelInfo
    {
        public Rid Id { get; internal init; }
        public IDevice1 Device { get; internal init; }
        public ILayout1 Layout { get; internal init; }
    }   
}