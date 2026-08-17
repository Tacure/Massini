

using System.Diagnostics.CodeAnalysis;

namespace Massini.Graphics.VkAL.Structs
{
    /// <summary>
    /// Resource Id.
    /// </summary>
    public readonly struct ResId(ulong i_id) : IEquatable<ResId>
    {
        /// <summary>
        /// Resource Id.
        /// </summary>
        public readonly ulong Id = i_id;

        public static explicit operator ulong(ResId i_id) => i_id.Id;
        public static implicit operator ResId(ulong i_id) => new(i_id);

        public static bool operator ==(ResId i_lhs, ResId i_rhs) => i_lhs.Equals(i_rhs);
        public static bool operator !=(ResId i_lhs, ResId i_rhs) => !i_lhs.Equals(i_rhs);

        /// <inheritdoc/>
        public readonly bool Equals(ResId i_other)
        {
            return Id == i_other.Id;
        }

        /// <inheritdoc/>
        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is ResId other && Equals(other);
        }

        /// <inheritdoc/>
        public readonly override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Get next resource id.
        /// </summary>
        public static ResId GetNextId() => new(m_nextId++);

        private static ulong m_nextId = 0;
    }
}