
using System.Diagnostics.CodeAnalysis;

namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents a typed memory size in bytes.
    /// </summary>
    public readonly struct MemorySize : IEquatable<MemorySize>, IComparable<MemorySize>
    {
        /// <summary>
        /// Returns a new instance of <see cref="MemorySize"/> representing zero size.
        /// </summary>
        public static MemorySize Zero => FromBytes(0);
        
        /// <summary>
        /// Returns a new instance of <see cref="MemorySize"/> representing the given number of bytes.
        /// </summary>
        public static MemorySize FromBytes(nuint i_bytes)
        {
            return new MemorySize(i_bytes);
        }

        /// <summary>
        /// Returns a new instance of <see cref="MemorySize"/> representing the given number of kilobytes.
        /// </summary>
        public static MemorySize FromKilobytes(nuint i_kilobytes)
        {
            return FromBytes(i_kilobytes * 1024);
        }

        /// <summary>
        /// Returns a new instance of <see cref="MemorySize"/> representing the given number of megabytes.
        /// </summary>
        public static MemorySize FromMegabytes(nuint i_megabytes)
        {
            return FromKilobytes(i_megabytes * 1024);
        }

        /// <summary>
        /// Returns the number of bytes represented by this instance.
        /// </summary>
        public nuint ToBytes()
        {
            return m_bytes;
        }

        /// <inheritdoc />
        public int CompareTo(MemorySize i_other)
        {
            return m_bytes.CompareTo(i_other.m_bytes);
        }
        
        /// <inheritdoc />
        public bool Equals(MemorySize i_other)
        {
            return m_bytes.Equals(i_other.m_bytes);
        }

        /// <inheritdoc />
        public override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is MemorySize other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return m_bytes.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{m_bytes} bytes";
        }

        private MemorySize(nuint i_bytes)
        {
            m_bytes = i_bytes;
        }
        
        private readonly nuint m_bytes = 0;
    }   
}