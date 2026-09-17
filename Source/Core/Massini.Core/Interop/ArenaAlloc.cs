
namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents an arena allocation.
    /// </summary>
    public readonly unsafe struct ArenaAlloc
    {        
        /// <summary>
        /// Represents an zero arena allocation.
        /// </summary>
        public static ArenaAlloc Zero => new ArenaAlloc(null, MemorySize.Zero);
        
        /// <summary>
        /// Size of the allocation.
        /// </summary>
        public MemorySize Size => m_size;

        /// <summary>
        /// Raw pointer to the beginning of the allocation.
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
            return new Span<byte>(m_ptr_alloc, (int)m_size.ToBytes());
        }
        
        /// <summary>
        /// Wraps the allocation in a typed allocation.
        /// </summary>
        public ArenaAlloc<T> ToTypedAlloc<T>()
            where T : unmanaged
        {
            return new ArenaAlloc<T>(this, (int)m_size.ToBytes() / sizeof(T));
        }
        
        internal ArenaAlloc(byte* i_ptr_alloc, MemorySize i_size)
        {
            m_ptr_alloc = i_ptr_alloc;
            m_size = i_size;
        }
        
        private readonly byte* m_ptr_alloc;
        private readonly MemorySize m_size;
    }

    /// <summary>
    /// Represents a typed arena allocation.
    /// </summary>
    public readonly unsafe struct ArenaAlloc<T>
        where T : unmanaged
    {
        /// <summary>
        /// Represents an zero arena allocation.
        /// </summary>
        public static ArenaAlloc<T> Zero => new ArenaAlloc<T>(ArenaAlloc.Zero, 0);
        
        /// <summary>
        /// The size of the allocation.
        /// </summary>
        public MemorySize Size => m_alloc.Size;
        
        /// <summary>
        /// The number of elements this allocation can hold.
        /// </summary>
        public int Capacity => m_capacity;
        
        /// <summary>
        /// Raw pointer to the beginning of the allocation.
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
        public ArenaAlloc ToAlloc()
        {
            return m_alloc;
        }
        
        internal ArenaAlloc(ArenaAlloc i_alloc, int i_capacity)
        {
            m_alloc = i_alloc;
            m_capacity = i_capacity;
        }
        
        private readonly ArenaAlloc m_alloc;
        private readonly int m_capacity;
    }
}