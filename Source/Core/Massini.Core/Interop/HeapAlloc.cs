

namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents a heap allocation.
    /// </summary>
    public readonly unsafe struct HeapAlloc : IDisposable
    {
        /// <summary>
        /// Represents an zero heap allocation.
        /// </summary>
        public static HeapAlloc Zero => new HeapAlloc(null, MemorySize.Zero, false, Rid.Zero);
        
        /// <summary>
        /// The size of the allocation.
        /// </summary>
        public MemorySize Size => m_size;
        
        /// <summary>
        /// The id of the allocation.
        /// </summary>
        public Rid Id => m_id;

        /// <summary>
        /// Returns true if the allocation is valid.
        /// </summary>
        public bool IsValid()
        {
            return HeapAllocator.IsValid(this);
        }
        
        /// <summary>
        /// Returns the raw pointer to the allocated memory.
        /// </summary>
        public byte* RawPtr()
        {
            return m_ptr_alloc;
        }

        /// <summary>
        /// Returns a span to the allocated memory.
        /// </summary>
        public Span<byte> ToSpan()
        {
            return new Span<byte>((byte*)m_ptr_alloc, (int)m_size.ToBytes());
        }

        /// <summary>
        /// Wraps the allocation in a typed allocation.
        /// </summary>
        public HeapAlloc<T> ToTypedAlloc<T>()
            where T : unmanaged
        {
            return new HeapAlloc<T>(this, (int)m_size.ToBytes() / sizeof(T));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            HeapAllocator.Free(this);
        }
        
        internal HeapAlloc(byte* i_ptr_alloc, MemorySize i_size, bool i_aligned, Rid i_id)
        {
            m_ptr_alloc = i_ptr_alloc;
            m_size = i_size;
            m_aligned = i_aligned;
            m_id = i_id;
        }
        
        private readonly byte* m_ptr_alloc;
        private readonly MemorySize m_size;
        private readonly bool m_aligned;
        private readonly Rid m_id;
    }

    /// <summary>
    /// Represents a typed heap allocation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly unsafe struct HeapAlloc<T> : IDisposable
        where T : unmanaged
    {
        /// <summary>
        /// Represents an zero heap allocation.
        /// </summary>
        public static HeapAlloc<T> Zero => new HeapAlloc<T>(HeapAlloc.Zero, 0);
        
        /// <summary>
        /// The size of the allocation.
        /// </summary>
        public MemorySize Size => m_alloc.Size;
        
        /// <summary>
        /// The number of elements this allocation can hold.
        /// </summary>
        public int Capacity => m_capacity;
        
        /// <summary>
        /// The id of the allocation.
        /// </summary>
        public Rid Id => m_alloc.Id;

        /// <summary>
        /// Returns true if the allocation is valid.
        /// </summary>
        public bool IsValid()
        {
            return HeapAllocator.IsValid(m_alloc);
        }
        
        /// <summary>
        /// Returns the raw pointer to the allocated memory.
        /// </summary>
        public T* RawPtr()
        {
            return (T*)m_alloc.RawPtr();
        }

        /// <summary>
        /// Returns the raw pointer to the element at the specified index.
        /// </summary>
        public T* RawPtrAt(int i_idx)
        {
            return RawPtr() + i_idx;
        }
        
        /// <summary>
        /// Returns a span to the allocated memory.
        /// </summary>
        public Span<T> ToSpan()
        {
            return new Span<T>((T*)m_alloc.RawPtr(), m_capacity);
        }

        /// <summary>
        /// Returns the wrapped allocation.
        /// </summary>
        public HeapAlloc ToAlloc()
        {
            return m_alloc;
        }

        /// <summary>
        /// Fills the allocation with the specified value.
        /// </summary>
        public void Fill(in T i_value)
        {
            ToSpan().Fill(i_value);
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            HeapAllocator.Free(this);
        }

        internal HeapAlloc(HeapAlloc i_alloc, int i_capacity)
        {
            m_alloc = i_alloc;
            m_capacity = i_capacity;
        }
        
        private readonly HeapAlloc m_alloc;
        private readonly int m_capacity;
    }
}