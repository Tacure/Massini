
using System.Text;

namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents a string allocated on an arena.
    /// </summary>
    public readonly unsafe struct ArenaString
    {
        /// <summary>
        /// Creates a new UTF8 encoded string.
        /// </summary>
        public static ArenaString CreateUTF8(string i_string, ArenaAllocator i_allocator)
        {
            // Get the required buffer size.
            int byteCount = Encoding.UTF8.GetByteCount(i_string);

            // Add 1 for the null terminator '\0'
            nuint totalSize = (nuint)byteCount + 1;

            // Create buffer.
            ArenaAlloc bufferAlloc = i_allocator.Alloc(MemorySize.FromBytes(totalSize), MemorySize.FromBytes(1));
            byte* buffer = (byte*)bufferAlloc.RawPtr();
            Span<byte> destination = new(buffer, byteCount);

            // Encode the string.
            Encoding.UTF8.GetBytes(i_string, destination);

            // Add the null terminator.
            buffer[byteCount] = 0;

            return new ArenaString(bufferAlloc, Encoding.UTF8);
        }
        
        /// <summary>
        /// Returns a pointer to the underlying heap memory.
        /// </summary>
        public byte* RawPtr() => m_alloc.RawPtr();

        /// <inheritdoc />
        public override string ToString()
        {
            return m_encoding.GetString((byte*)m_alloc.RawPtr(), (int)m_alloc.Size.ToBytes());
        }

        private ArenaString(ArenaAlloc i_alloc, Encoding i_encoding)
        {
            m_alloc = i_alloc;
            m_encoding = i_encoding;
        }
        
        private readonly ArenaAlloc m_alloc;
        private readonly Encoding m_encoding;
    }   
}