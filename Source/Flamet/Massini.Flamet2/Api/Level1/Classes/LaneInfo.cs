
using Massini.Core;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public class LaneInfo
    {
        public required Rid Id { get; init; }
        public required LaneUsageFlags Usage { get; init; }
        public required IDevice1 Device { get; init; }
    }   
}