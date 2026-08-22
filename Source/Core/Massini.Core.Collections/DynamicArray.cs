using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Massini.Core.Collections
{
    /// <summary>
    /// Represents a dynamically sized array of elements that can be accessed by index. Provides methods to add, remove,
    /// and search for elements.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the array.</typeparam>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllConstructors)]
    public class DynamicArray<T> : IList, IList<T>, IReadOnlyList<T>
    {
        public DynamicArray()
        {
        }

        public DynamicArray(int i_capacity)
        {
            m_data = new T[i_capacity];
        }

        public DynamicArray(int i_capacity, float i_resizeFactor)
        {
            if (i_resizeFactor <= 1.0f || i_resizeFactor > 2.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(i_resizeFactor));
            }

            m_data = new T[i_capacity];
            m_resizeFactor = i_resizeFactor;
        }

        /// <inheritdoc/>
        public ref T this[int i_index]
        {
            get
            {
                if (i_index < 0 || i_index >= m_count)
                {
                    throw new IndexOutOfRangeException();
                }
                return ref m_data[i_index];
            }
        }

        object? IList.this[int i_index]
        {
            get
            {
                return this[i_index];
            }
            set
            {
                if (value is T item)
                {
                    this[i_index] = item;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        T IList<T>.this[int i_index]
        {
            get
            {
                return this[i_index];
            }
            set
            {
                this[i_index] = value;
            }
        }

        T IReadOnlyList<T>.this[int i_index] => this[i_index];

        /// <inheritdoc/>
        public Type ElementsType => typeof(T);

        /// <inheritdoc/>
        public int Count => m_count;

        /// <inheritdoc/>
        public int Capacity => m_data.Length;

        /// <inheritdoc/>
        public bool IsReadOnly => m_data.IsReadOnly;

        /// <inheritdoc/>
        public bool IsFixedSize => false;

        /// <inheritdoc/>
        public bool IsSynchronized => m_data.IsSynchronized;

        /// <inheritdoc/>
        public object SyncRoot => m_data.SyncRoot;

        /// <inheritdoc/>
        public void Add(T i_item)
        {
            Resize();
            m_data[m_count++] = i_item;
        }

        /// <summary>
        /// Returns a reference to the element at the specified index.
        /// </summary>
        public ref T GetAt(int i_index)
        {
            return ref m_data[i_index];
        }

        /// <inheritdoc/>
        public int BinarySearch(T i_item)
        {
            return Array.BinarySearch(m_data, 0, m_count, i_item);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            if (m_count > 0)
            {
                Array.Clear(m_data, 0, m_count);
                m_count = 0;
            }
        }

        /// <inheritdoc/>
        public bool Contains(T i_item)
        {
            return IndexOf(i_item) >= 0;
        }

        /// <inheritdoc/>
        public void CopyTo(T[] i_array, int i_arrayIndex)
        {
            m_data.CopyTo(i_array, i_arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < m_count; i++)
            {
                yield return m_data[i];
            }
        }

        /// <inheritdoc/>
        public Span<T> AsSpan()
        {
            return new Span<T>(m_data, 0, m_count);
        }

        /// <inheritdoc/>
        public Memory<T> AsMemory()
        {
            return new Memory<T>(m_data, 0, m_count);
        }

        /// <inheritdoc/>
        public int IndexOf(T i_item)
        {
            return Array.IndexOf(m_data, i_item, 0, m_count);
        }

        /// <inheritdoc/>
        public void Insert(int i_index, T i_item)
        {
            if (i_index < 0 || i_index > m_count)
            {
                throw new ArgumentOutOfRangeException(nameof(i_index));
            }

            Resize();

            if (i_index < m_count)
            {
                Array.Copy(m_data, i_index, m_data, i_index + 1, m_count - i_index);
            }

            m_data[i_index] = i_item;
            m_count++;
        }

        /// <inheritdoc/>
        public bool Remove(T i_item)
        {
            int index = IndexOf(i_item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public void RemoveAt(int i_index)
        {
            if (i_index < 0 || i_index >= m_count)
            {
                throw new ArgumentOutOfRangeException(nameof(i_index));
            }

            m_count--;

            if (i_index < m_count)
            {
                Array.Copy(m_data, i_index + 1, m_data, i_index, m_count - i_index);
            }

            // Allow the garbage collector to collect the item if it is a class.
#pragma warning disable CS8601 // Posible asignación de referencia nula
            m_data[m_count] = default;
#pragma warning restore CS8601 // Posible asignación de referencia nula
            }

        /// <summary>
        /// Removes the last element from the list.
        /// </summary>
        public void RemoveLast()
        {
            RemoveAt(m_count - 1);
        }

        /// <inheritdoc/>
        public int Add(object? i_value)
        {
            if (i_value is T value)
            {
                Add(value);
                return m_count - 1;
            }
            return -1;
        }

        /// <inheritdoc/>
        public bool Contains(object? i_value)
        {
            if (i_value is T value)
            {
                return Contains(value);
            }
            return false;
        }

        /// <inheritdoc/>
        public int IndexOf(object? i_value)
        {
            if (i_value is T value)
            {
                return IndexOf(value);
            }
            return -1;
        }

        /// <inheritdoc/>
        public void Insert(int i_index, object? i_value)
        {
            if (i_value is T value)
            {
                Insert(i_index, value);
            }
        }

        /// <inheritdoc/>
        public void Remove(object? i_value)
        {
            if (i_value is T value)
            {
                Remove(value);
            }
        }

        /// <inheritdoc/>
        public void CopyTo(Array i_array, int i_index)
        {
            m_data.CopyTo(i_array, i_index);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{typeof(T).FullName}[{m_count}]";
        }

        private readonly float m_resizeFactor = 2.0f;
        private int m_count = 0;
        private T[] m_data = [];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Resize()
        {
            if (m_data.Length == 0)
            {
                m_data = new T[4];
                return;
            }

            if (m_count < m_data.Length)
            {
                return;
            }

            Array.Resize(ref m_data, (int)(m_data.Length * m_resizeFactor));
        }
    }
}
