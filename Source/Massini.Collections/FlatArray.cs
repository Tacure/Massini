using System.Collections;

namespace Massini.Collections
{
    /// <summary>
    /// Represents a multi-dimensional flat array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class FlatArray<T> : IEnumerable<T>
    {
        public FlatArray()
        {
            m_array = [];
            m_size = [];
        }

        /// <summary>
        /// Creates a new multi-dimensional array of the given size on each dimension.
        /// </summary>
        /// <param name="i_size"></param>
        public FlatArray(params int[] i_size)
        {
            m_array = new T[i_size.Aggregate((a, b) => a * b)];
            m_size = i_size;
        }

        /// <summary>
        /// Creates a new multi-dimensional array of the given size on each dimension and sets the initial values.
        /// </summary>
        /// <param name="i_size">Size of each dimension.</param>
        /// <param name="i_array">An array with the initial values.</param>
        public FlatArray(int[] i_size, params T[] i_array)
        {
            m_array = i_array[0..i_size.Aggregate((a, b) => a * b)];
            m_size = i_size;
        }

        /// <summary>
        /// Creates a new multi-dimensional array of the given size on each dimension and sets the initial values.
        /// </summary>
        /// <param name="i_size">Size of each dimension.</param>
        /// <param name="i_array">An array with the initial values.</param>
        /// <param name="i_offset">Offset from the start of the array.</param>
        public FlatArray(int[] i_size, T[] i_array, int i_offset)
        {
            m_array = i_array[i_offset..i_size.Aggregate((a, b) => a * b)];
            m_size = i_size;
        }

        /// <summary>
        /// Gets or sets the value at the given index.
        /// </summary>
        /// <param name="i_idx"></param>
        /// <returns></returns>
        public ref T this[params Span<int> i_idx]
        {
            get
            {
                return ref m_array[GetIndex(i_idx)];
            }
        }

        public IReadOnlyList<int> Size => m_size;

        public ref T GetRefAt(params Span<int> i_idx)
        {
            return ref m_array[GetIndex(i_idx)];
        }

        public Span<T> AsSpan()
        {
            return m_array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < m_array.Length; i++)
            {
                yield return m_array[i];
            }
        }

        private readonly T[] m_array;
        private readonly int[] m_size;

        private int GetIndex(Span<int> i_index)
        {
            int idx = 0;
            for (int i = 0; i < i_index.Length; i++)
            {
                if (i == 0)
                {
                    idx = i_index[i];
                }
                else
                {
                    int mul = i_index[i];
                    for (int j = 0; j < i; j++)
                    {
                        mul *= m_size[j];
                    }
                    idx += mul;
                }
            }

            return idx;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
