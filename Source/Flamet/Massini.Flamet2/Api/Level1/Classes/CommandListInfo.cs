
using Massini.Core;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class CommandListInfo
    {
        public Rid Id { get; internal init; }
        public ILane1 Lane { get; internal init; }
    }   
}