
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Sugar.Structs;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public unsafe class StorageBuffer<T> : TypedBuffer<T>
        where T : unmanaged
    {
        public StorageBuffer(Device i_device, in TypedBufferCreateParams i_createParams) : base(i_device, i_createParams, Enums.BufferType.Storage)
        {
        }
    }
}
