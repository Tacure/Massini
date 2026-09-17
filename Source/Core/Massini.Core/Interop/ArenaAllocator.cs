
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Massini.Core.Interop
{
    /// <summary>
    /// Arena allocator.
    /// </summary>
    public sealed unsafe class ArenaAllocator : IDisposable
    {
        /// <summary>
        /// Creates a new arena allocator.
        /// </summary>
        public ArenaAllocator(MemorySize i_size)
        {
            m_alloc = HeapAllocator.Alloc(i_size);
        }
        
        /// <summary>
        /// Total capacity of the arena.
        /// </summary>
        public MemorySize Capacity => m_alloc.Size;
        
        /// <summary>
        /// Used memory in the arena.
        /// </summary>
        public MemorySize Used => MemorySize.FromBytes(m_offset);

        /// <inheritdoc />
        public void Dispose()
        {
            HeapAllocator.Free(m_alloc);
        }

        /// <summary>
        /// Allocates a new chunk of memory.
        /// </summary>
        public ArenaAlloc Alloc(MemorySize i_size, MemorySize i_alignment)
        {
            nuint alignment = i_alignment.ToBytes();
            nuint size = i_size.ToBytes();
            
            // Checks if the aligment is a power of two.
            if (alignment == 0 || (alignment & (alignment - 1)) != 0)
            {
                throw new ArgumentException("Alignment must be a power of two.", nameof(i_alignment));
            }

            nuint address = (nuint)m_alloc.RawPtr() + m_offset;

            nuint alignedAddress =
                (address + alignment - 1) & ~(alignment - 1);

            // Convert the alignedAddress to a relative offset and sum the size of the allocation.

            nuint newOffset =
                (alignedAddress - (nuint)m_alloc.RawPtr()) + size;

            if (newOffset > m_alloc.Size.ToBytes())
            {
                throw new OutOfMemoryException();
            }

            ArenaAlloc alloc = new(
                (byte*)alignedAddress,
                i_size);

            m_offset = newOffset;

            return alloc;
        }

        /// <summary>
        /// Allocates a new chunk of memory.
        /// </summary>
        public ArenaAlloc<T> Alloc<T>(int i_capacity, MemorySize i_alignment)
            where T : unmanaged
        {
            return new ArenaAlloc<T>(
                Alloc(MemorySize.FromBytes((nuint)(sizeof(T) * i_capacity)), i_alignment), i_capacity);
        }
        
        /// <summary>
        /// Allocates heap memory and initializes it with the given span.
        /// </summary>
        public ArenaAlloc<T> Alloc<T>(ReadOnlySpan<T> i_span, MemorySize i_alignment)
            where T : unmanaged
        {
            ArenaAlloc<T> alloc = Alloc<T>(i_span.Length, i_alignment);

            fixed (T* srcPtr = i_span)
            {
                Unsafe.CopyBlock(alloc.RawPtr(), srcPtr, (uint)alloc.Size.ToBytes());
            }
            
            return alloc;
        }

        private readonly HeapAlloc m_alloc;
        private nuint m_offset = 0;
    }   
}