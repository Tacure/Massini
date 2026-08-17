using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Sugar.Structs;
using System.Runtime.InteropServices;
using Buffer = Massini.Graphics.VkAL.Classes.Buffer;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public unsafe abstract class TypedBuffer<T> : Buffer
        where T : unmanaged
    {
        /// <summary>
        /// The size of a single element.
        /// </summary>
        public ulong ElementSize { get; private init; }

        /// <summary>
        /// The number of elements in the buffer.
        /// </summary>
        public ulong Count { get; private init; }

        public TypedBuffer(Device i_device, in TypedBufferCreateParams i_createParams, BufferType i_type) : base(i_device, new()
        {
            p_next = i_createParams.p_next,
            p_label = i_createParams.p_label,
            p_size = (ulong)sizeof(T) * i_createParams.p_count,
            p_type = i_type,
            p_usage = i_createParams.p_usage,
        })
        {
            ElementSize = (ulong)sizeof(T);
            Count = i_createParams.p_count;
        }

        public void WriteElements(ReadOnlySpan<T> i_data, ulong i_arrayOffset = 0)
        {
            fixed (T* ptr_data = i_data)
            {
                WriteBytes(MemoryMarshal.AsBytes(i_data), (ulong)sizeof(T) * i_arrayOffset);
            }
        }

        public void ReadElements(Span<T> i_data, ulong i_arrayOffset = 0)
        {
            fixed (T* ptr_data = i_data)
            {
                ReadBytes(MemoryMarshal.AsBytes(i_data), (ulong)sizeof(T) * i_arrayOffset);
            }
        }
    }
}
