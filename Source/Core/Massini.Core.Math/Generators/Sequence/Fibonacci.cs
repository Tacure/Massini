using System.Collections;
using System.Numerics;
using Massini.Core.Math.Generators.Sequence;

namespace Massini.Core.Math.Generators.Sequence
{
    public readonly struct Fibonacci<T>(T i_start, T i_end, bool i_includeStart = true, bool i_includeEnd = false) : ISequenceGenerator<T>
        where T : unmanaged, INumber<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            if (m_start < T.Zero || m_end < T.Zero)
            {
                throw new ArgumentException("i_start and i_end must be >= 0");
            }

            T last = T.One;
            T current = T.Zero;

            while (current < m_end || (current == m_end && m_includeEnd))
            {
                if (current > m_start || (current == m_start && m_includeStart))
                {
                    yield return current;
                }

                T temp = last;
                last = current;
                current += temp;
            }
        }

        private readonly T m_start = i_start;
        private readonly T m_end = i_end;
        private readonly bool m_includeStart = i_includeStart;
        private readonly bool m_includeEnd = i_includeEnd;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
