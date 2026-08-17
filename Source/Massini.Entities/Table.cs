
using Massini.Collections;

namespace Massini.Entities
{
    public sealed class Table
    {
        public Bitfield128 TypesMask => m_typesMask;
        public Storage Storage => m_storage;
        public HashSet<Type> Components => m_components;
        public IReadOnlyList<Entity> Entities => m_entities;

        public Entity Create()
        {
            Entity entity = m_entityPool.Borrow();
            entity.in_row = m_rowCount++;
            entity.in_table = this;
            m_entities.Add(entity);

            // Create row.
            foreach (var column in m_columns.Values) 
            {
                column.AddDefault();
            }

            return entity;
        }

        public void Destroy(Entity i_entity)
        {
            int freeRow = i_entity.in_row;

            // Remove row and compact columns.
            foreach (var column in m_columns.Values) 
            {
                column.RemoveAndCompact(freeRow);
            }

            // Move last entity to removed entity.
            int last = m_entities.Count - 1;
            if (freeRow != last)
            {
                Entity lastEnt = m_entities[last];
                lastEnt.in_row = freeRow;
                m_entities[freeRow] = lastEnt;
            }
            m_entities.RemoveAt(last);

            m_entityPool.Return(i_entity);
            m_rowCount--;
        }

        public void Move(Entity i_entity, Table i_dstTable)
        {
            int srcRow = i_entity.in_row;

            // Copy components to dst.
            foreach (Column dstCol in i_dstTable.m_columns.Values) 
            {
                if (m_columns.TryGetValue(dstCol.Type, out Column? srcCol)) 
                {
                    srcCol.Copy(srcRow, dstCol);
                }
                else 
                {
                    dstCol.AddDefault();
                }
            }

            // Add entity to destination table.
            i_dstTable.m_entities.Add(i_entity);
            int newRow = i_dstTable.m_rowCount++;
            i_entity.in_row = newRow;
            i_entity.in_table = i_dstTable;

            // Remove from source table.
            int last = --m_rowCount;

            // Remove components and compact columns.
            foreach (var col in m_columns.Values)
            {
                col.RemoveAndCompact(srcRow);
            }
            
            // Compact entity list
            if (srcRow != last)
            {
                Entity lastEnt = m_entities[last];
                lastEnt.in_row = srcRow;
                m_entities[srcRow] = lastEnt;
            }

            m_entities.RemoveAt(last);
        }

        /// <summary>
        /// Get a reference to an entity component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i_entity"></param>
        /// <returns></returns>
        public ref T? Get<T>(Entity i_entity) 
        {
            return ref ((Column<T>)m_columns[typeof(T)]).Get(i_entity.in_row);
        }

        internal Table(Storage i_table, HashSet<Type> i_types, Bitfield128 i_typesMask) 
        {
            m_storage = i_table;
            m_components = i_types;
            m_typesMask = i_typesMask;

            // Create columns.
            foreach (Type type in i_types) 
            {
                m_columns.Add(type, (Column)Activator.CreateInstance(typeof(Column<>).MakeGenericType(type))!);
            }
        }

        internal Span<Entity> GetEntitiesAsSpan()
        {
            return m_entities.AsSpan();
        }

        internal Span<T?> GetColumnAsSpan<T>() 
        {
            return ((Column<T>)m_columns[typeof(T)]).AsSpan();
        }

        internal Memory<Entity> GetEntitiesAsMemory()
        {
            return m_entities.AsMemory();
        }

        internal Memory<T?> GetColumnAsMemory<T>()
        {
            return ((Column<T>)m_columns[typeof(T)]).AsMemory();
        }

        private readonly Storage m_storage;
        private readonly ObjectPool<Entity> m_entityPool = new(() => new Entity());
        private readonly DynamicArray<Entity> m_entities = [];
        private readonly HashSet<Type> m_components = [];
        private readonly Bitfield128 m_typesMask = new();
        private readonly Dictionary<Type, Column> m_columns = [];
        private int m_rowCount = 0;
    }
}
