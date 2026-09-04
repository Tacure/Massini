

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
        public static HeapAlloc Zero => new HeapAlloc(null, MemorySize.Zero, Rid.Zero);
        
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
        public void* RawPtr()
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

        /// <inheritdoc />
        public void Dispose()
        {
            HeapAllocator.Free(this);
        }
        
        internal HeapAlloc(void* i_ptr_alloc, MemorySize i_size, Rid i_id)
        {
            m_ptr_alloc = i_ptr_alloc;
            m_size = i_size;
            m_id = i_id;
        }
        
        private readonly void* m_ptr_alloc;
        private readonly MemorySize m_size;
        private readonly Rid m_id;
    }   
}