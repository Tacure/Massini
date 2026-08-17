

using System.Diagnostics.CodeAnalysis;

namespace Massini.Entities
{
    public struct Bitfield128 : IEquatable<Bitfield128>
    {
        public Bitfield128(ulong i_bitsHigher, ulong i_bitsLower)
        {
            m_bitsHigher = i_bitsHigher;
            m_bitsLower = i_bitsLower;
        }

        public bool this[int i_index]
        {
            readonly get
            {
                // Validar rango opcionalmente (0 a 127)
                if ((uint)i_index >= 128) throw new ArgumentOutOfRangeException(nameof(i_index));

                if (i_index < 64)
                {
                    return (m_bitsLower & (1UL << i_index)) != 0;
                }
                else
                {
                    return (m_bitsHigher & (1UL << (i_index - 64))) != 0;
                }
            }
            set
            {
                if ((uint)i_index >= 128) throw new ArgumentOutOfRangeException(nameof(i_index));

                if (i_index < 64)
                {
                    if (value) m_bitsLower |= 1UL << i_index;
                    else       m_bitsLower &= ~(1UL << i_index);
                }
                else
                {
                    int shift = i_index - 64;
                    if (value) m_bitsHigher |= 1UL << shift;
                    else       m_bitsHigher &= ~(1UL << shift);
                }
            }
        }

        public static Bitfield128 Zero => new(0, 0);

        public readonly Bitfield128 Combine(Bitfield128 i_other)
        {
            return new(m_bitsHigher | i_other.m_bitsHigher, m_bitsLower | i_other.m_bitsLower);
        }

        public readonly Bitfield128 Remove(Bitfield128 i_other)
        {
            return new(m_bitsHigher & ~i_other.m_bitsHigher, m_bitsLower & ~i_other.m_bitsLower);
        }

        public readonly bool SubsetOf(Bitfield128 i_other)
        {
            return (m_bitsHigher & i_other.m_bitsHigher) == m_bitsHigher && (m_bitsLower & i_other.m_bitsLower) == m_bitsLower;
        }

        public readonly bool Overlap(Bitfield128 i_other)
        {
            return (m_bitsHigher & i_other.m_bitsHigher) != 0 || (m_bitsLower & i_other.m_bitsLower) != 0;
        }

        public readonly bool Equals(Bitfield128 i_other)
        {
            return m_bitsHigher == i_other.m_bitsHigher && m_bitsLower == i_other.m_bitsLower;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            return i_obj is Bitfield128 other && Equals(other);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(m_bitsHigher, m_bitsLower);
        }

        public override readonly string ToString()
        {
            return $"{m_bitsHigher} {m_bitsLower}";
        }

        private ulong m_bitsHigher;
        private ulong m_bitsLower;
    }
}