using Massini.Coat.Classes;
using Massini.Coat.Sugar.Structs;

namespace Massini.Coat.Sugar.Classes
{
    public unsafe class VertexBuffer<T> : TypedBuffer<T>
        where T : unmanaged
    {
        public VertexBuffer(Device i_device, in TypedBufferCreateParams i_createParams) : base(i_device, i_createParams, Enums.BufferType.Vertex)
        {
        }
    }
}
