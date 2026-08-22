
using Massini.Core.Collections;

namespace Massini.Core.Entities
{
    public abstract class Column
    {
        public abstract Type Type { get; }

        internal abstract void AddDefault();

        /// <summary>
        /// Remove row and compact column.
        /// </summary>
        /// <remarks>
        /// This method moves the last row to the removed row.
        /// </remarks>
        /// <param name="i_row"></param>
        internal abstract void RemoveAndCompact(int i_row);

        /// <summary>
        /// Shallow copy row to another column.
        /// </summary>
        /// <remarks>
        /// The new element is added to the end of the column.
        /// </remarks>
        /// <param name="i_row"></param>
        /// <param name="i_dstColumn"></param>
        internal abstract void Copy(int i_row, Column i_dstColumn);
    }

    public sealed class Column<T> : Column
    {
        public override Type Type => typeof(T);

        internal override void AddDefault()
        {
            m_values.Add(default);
        }

        internal void Add(T? i_value)
        {
            m_values.Add(i_value);
        }

        internal ref T? Get(int i_row)
        {
            return ref m_values.GetAt(i_row);
        }

        internal override void RemoveAndCompact(int i_row)
        {
            // If is last row, remove it.
            if (i_row == m_values.Count - 1)
            {
                m_values.RemoveAt(i_row);
                return;
            }

            // Move last row to removed row and remove last row.
            m_values[i_row] = m_values[^1];
            m_values.RemoveLast();
        }

        internal override void Copy(int i_row, Column i_dstColumn)
        {
            Column<T> dstColumn = (Column<T>)i_dstColumn;
            dstColumn.Add(Get(i_row));
        }

        internal Span<T?> AsSpan()
        {
            return m_values.AsSpan();
        }

        internal Memory<T?> AsMemory()
        {
            return m_values.AsMemory();
        }

        private readonly DynamicArray<T?> m_values = new(4);
    }
}
