
using System.Diagnostics.CodeAnalysis;

namespace Massini.Core
{
    /// <summary>
    /// Runtime unique id.
    /// </summary>
    public readonly struct Rid(ulong i_id) : IEquatable<Rid>
    {
        /// <summary>
        /// Returns true if the ids are equal.
        /// </summary>
        public static bool operator ==(Rid i_left, Rid i_right)
        {
            return i_left.Equals(i_right);
        }

        /// <summary>
        /// Returns true if the ids are not equal.
        /// </summary>
        public static bool operator !=(Rid i_left, Rid i_right)
        {
            return i_left.Equals(i_right);
        }

        /// <summary>
        /// Represents an invalid id.
        /// </summary>
        public static Rid Zero => new(0);

        /// <summary>
        /// Creates a new thread-safe unique id.
        /// </summary>
        public static Rid NewId()
        {
            return new Rid(Interlocked.Increment(ref m_nextId));
        }

        /// <summary>
        /// Returns true if the id is valid (not zero).
        /// </summary>
        public readonly bool IsValid => m_id != 0;


        /// <inheritdoc />
        public readonly bool Equals(Rid i_other)
        {
            return m_id == i_other.m_id;
        }

        /// <inheritdoc />
        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is Rid other && Equals(other);
        }

        /// <inheritdoc />
        public readonly override int GetHashCode()
        {
            return m_id.GetHashCode();
        }

        private static ulong m_nextId = 1;

        private readonly ulong m_id = i_id;
    }
}
