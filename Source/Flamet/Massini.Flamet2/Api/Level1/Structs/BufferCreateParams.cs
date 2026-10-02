
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct BufferCreateParams
    {
        public required BufferType p_type;
        public required BufferUsageFlags p_usage;
        public required MemorySize p_size;
    }   
}