
using System.Diagnostics.CodeAnalysis;

namespace Massini
{
    /// <summary>
    /// Runtime unique id.
    /// </summary>
    public readonly struct Rid(ulong i_id) : IEquatable<Rid>
    {
        public static bool operator ==(Rid i_left, Rid i_right)
        {
            return i_left.Equals(i_right);
        }

        public static bool operator !=(Rid i_left, Rid i_right)
        {
            return i_left.Equals(i_right);
        }

        public static Rid Zero => new(0);

        public static Rid NewId()
        {
            return new Rid(Interlocked.Increment(ref m_nextId));
        }

        public readonly bool IsValid => m_id != 0;

        public readonly bool Equals(Rid i_other)
        {
            return m_id == i_other.m_id;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is Rid other && Equals(other);
        }

        public readonly override int GetHashCode()
        {
            return m_id.GetHashCode();
        }

        private readonly ulong m_id = i_id;

        private static ulong m_nextId = 1;
    }
}
