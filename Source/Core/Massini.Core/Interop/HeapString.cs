
using System.Text;

namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents a string allocated on the heap.
    /// </summary>
    public readonly unsafe struct HeapString : IDisposable
    {
        /// <summary>
        /// Creates a new UTF8 encoded string.
        /// </summary>
        public static HeapString CreateUTF8(string i_string)
        {
            // Get the required buffer size.
            int byteCount = Encoding.UTF8.GetByteCount(i_string);

            // Add 1 for the null terminator '\0'
            nuint totalSize = (nuint)byteCount + 1;

            // Create buffer.
            HeapAlloc bufferAlloc = HeapAllocator.Alloc(MemorySize.FromBytes(totalSize));
            byte* buffer = (byte*)bufferAlloc.RawPtr();
            Span<byte> destination = new(buffer, byteCount);

            // Encode the string.
            Encoding.UTF8.GetBytes(i_string, destination);

            // Add the null terminator.
            buffer[byteCount] = 0;

            return new HeapString(bufferAlloc, Encoding.UTF8);
        }
        
        /// <summary>
        /// Returns a pointer to the underlying heap memory.
        /// </summary>
        public void* RawPtr() => m_alloc.RawPtr();

        /// <inheritdoc />
        public override string ToString()
        {
            return m_encoding.GetString((byte*)m_alloc.RawPtr(), (int)m_alloc.Size.ToBytes());
        }

        /// <inheritdoc />
        public void Dispose()
        {
            m_alloc.Dispose();
        }

        private HeapString(HeapAlloc i_alloc, Encoding i_encoding)
        {
            m_alloc = i_alloc;
            m_encoding = i_encoding;
        }
        
        private readonly HeapAlloc m_alloc;
        private readonly Encoding m_encoding;
    }
}