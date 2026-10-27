
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct SurfaceCreateParams : INext
    {
        public required INext? p_next;
        
        public readonly INext? Next => p_next;
    }   
}