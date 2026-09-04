using Massini.Flamet.Classes;
using Massini.Flamet.Sugar.Structs;

namespace Massini.Flamet.Sugar.Classes
{
    public unsafe class IndexBuffer<T> : TypedBuffer<T>
        where T : unmanaged
    {
        public IndexBuffer(Device i_device, in TypedBufferCreateParams i_createParams) : base(i_device, i_createParams, Enums.BufferType.Index)
        {
        }
    }
}
