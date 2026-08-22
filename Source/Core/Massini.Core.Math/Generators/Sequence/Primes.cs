
using System.Collections;
using System.Numerics;
using Massini.Math.Generators.Sequence;

namespace Massini.Math.Generators.Sequence
{
    public readonly struct Primes<T>(T i_start, T i_end) : ISequenceGenerator<T>
        where T : unmanaged, INumber<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            if (m_start < T.Zero || m_end < T.Zero)
            {
                throw new ArgumentException("i_start and i_end must be >= 0");
            }

            T current = m_start < T.CreateChecked(2) ? T.CreateChecked(2) : m_start;

            while (current < m_end)
            {
                if (Math<T>.IsPrime(current))
                {
                    yield return current;
                }
                current++;
            }
        }

        private readonly T m_start = i_start;
        private readonly T m_end = i_end;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
