using System.Collections;

namespace Massini.Collections
{
    /// <summary>
    /// Represents a 2D row-major flat array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlatArray2D<T> : IEnumerable<T>
    {
        public FlatArray2D(int i_width, int i_height)
        {
            m_array = new T[i_width * i_height];
            m_size = (i_width, i_height);
        }

        public FlatArray2D(int i_width, int i_height, T[] i_array) 
        {
            if (i_array.Length != i_width * i_height)
            {
                throw new ArgumentException("Array size must be width * height.");
            }

            m_array = i_array;
        }

        /// <summary>
        /// Iterate directly through the internal array.
        /// </summary>
        public ref T this[Index i_idx]
        {
            get
            {
                int idx = i_idx.GetOffset(m_array.Length);
                return ref m_array[idx];
            }
        }

        /// <summary>
        /// Get or set the value at the specified position.
        /// </summary>
        public ref T this[Index i_x, Index i_y]
        {
            get
            {
                int x = i_x.GetOffset(m_size.Width);
                int y = i_y.GetOffset(m_size.Height);
                return ref m_array[GetIndex(x, y)];
            }
        }

        /// <summary>
        /// The size of the array.
        /// </summary>
        public (int Width, int Height) Size => m_size;

        /// <summary>
        /// The number of elements in the array.
        /// </summary>
        public int Count => m_array.Length;

        public ref T GetRefAt(int i_x, int i_y)
        {
            return ref m_array[GetIndex(i_x, i_y)];
        }

        public ref T GetPinnableReference()
        {
            return ref m_array[0];
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
        private readonly (int Width, int Height) m_size;

        private int GetIndex(int i_x, int i_y)
        {
            return i_x + i_y * m_size.Width;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
