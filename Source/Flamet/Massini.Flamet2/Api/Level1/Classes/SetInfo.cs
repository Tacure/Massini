
using Massini.Core;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class SetInfo
    {
        public Rid Id { get; internal init; }
        public ISetAllocator1 SetAllocator { get; internal init; }
        public ILayout1 Layout { get; internal init; }
    }   
}