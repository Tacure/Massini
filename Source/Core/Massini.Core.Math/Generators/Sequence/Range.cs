
using System.Collections;
using System.Numerics;
using Massini.Core.Math.Generators.Sequence;

namespace Massini.Core.Math.Generators.Sequence
{
    public readonly struct Range<T>(T i_start, T i_end, T i_step, bool i_includeStart = true, bool i_includeEnd = false) : ISequenceGenerator<T>
        where T : unmanaged, INumber<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            // Setup.
            T step;
            T start;
            T end;

            if (m_step == T.Zero)
            {
                throw new ArgumentException("Step cannot be zero.");
            }

            step = m_step;
            if (step < T.Zero)
            {
                step = T.Abs(step);
                start = m_end;
                end = m_start;
            }
            else
            {
                start = m_start;
                end = m_end;
            }

            // Algorithm.

            T t = start;
            if (start < end)
            {
                if (!m_includeStart)
                {
                    t += step;
                }

                while (t < end)
                {
                    yield return t;
                    t += step;
                }
            }
            else if (start > end)
            {
                if (!m_includeStart)
                {
                    t -= step;
                }

                while (t > end)
                {
                    yield return t;
                    t -= step;
                }
            }

            if (m_includeEnd)
            {
                yield return end;
            }
        }

        private readonly T m_start = i_start;
        private readonly T m_end = i_end;
        private readonly T m_step = i_step;
        private readonly bool m_includeStart = i_includeStart;
        private readonly bool m_includeEnd = i_includeEnd;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
