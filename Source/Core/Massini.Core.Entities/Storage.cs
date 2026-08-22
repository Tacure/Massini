
namespace Massini.Entities
{
    public partial class Storage
    {
        public const int MAX_COMPONENTS = 128;

        public Storage()
        {
            // Create default table.
            m_tables[Bitfield128.Zero] = new Table(this, [], Bitfield128.Zero);
        }

        private readonly Dictionary<Bitfield128, Table> m_tables = [];
        private readonly Dictionary<Type, Bitfield128> m_typesMasks = [];
        private int m_nextBit = 0;
    }

    // Low level API.
    public partial class Storage
    {
        public IEnumerable<Table> GetTables()
        {
            return m_tables.Values;
        }

        public IEnumerable<Entity> GetEntities()
        {
            foreach (Table table in m_tables.Values)
            {
                Memory<Entity> entities = table.GetEntitiesAsMemory();
                for (int i = 0; i < entities.Length; i++)
                {
                    yield return entities.Span[i];
                }
            }
        }

        public Query BeginQuery()
        {
            return new(this, GetTables(), Bitfield128.Zero, Bitfield128.Zero);
        }

        public Table GetTable()
        {
            return m_tables[Bitfield128.Zero];
        }

        public Table GetTable(Bitfield128 i_typesMask)
        {
            // Try to find an existing table.
            if (m_tables.TryGetValue(i_typesMask, out Table? table))
            {
                return table;
            }

            // Create a new table.
            Table newTable = new(this, [], i_typesMask);
            m_tables[i_typesMask] = newTable;
            return newTable;
        }

        public Table GetTable(HashSet<Type> i_types)
        {
            // Create table mask.
            Bitfield128 mask = Bitfield128.Zero;
            foreach (Type type in i_types)
            {
                mask = mask.Combine(GetTypeMask(type));
            }

            return GetTable(mask);
        }

        public Table GetTable<T1>()
        {
            // Create table mask.
            Bitfield128 mask = Bitfield128.Zero;
            mask = mask.Combine(GetTypeMask(typeof(T1)));

            // Try to find an existing table.
            if (m_tables.TryGetValue(mask, out Table? table))
            {
                return table;
            }

            // Create a new table.
            Table newTable = new(this, [typeof(T1)], mask);
            m_tables[mask] = newTable;
            return newTable;
        }

        public Table GetTable<T1, T2>()
        {
            // Create table mask.
            Bitfield128 mask = Bitfield128.Zero;
            mask = mask.Combine(GetTypeMask(typeof(T1)));
            mask = mask.Combine(GetTypeMask(typeof(T2)));

            // Try to find an existing table.
            if (m_tables.TryGetValue(mask, out Table? table))
            {
                return table;
            }

            // Create a new table.
            Table newTable = new(this, [typeof(T1), typeof(T2)], mask);
            m_tables[mask] = newTable;
            return newTable;
        }

        public Table GetTable<T1, T2, T3>()
        {
            // Create table mask.
            Bitfield128 mask = Bitfield128.Zero;
            mask = mask.Combine(GetTypeMask(typeof(T1)));
            mask = mask.Combine(GetTypeMask(typeof(T2)));
            mask = mask.Combine(GetTypeMask(typeof(T3)));

            // Try to find an existing table.
            if (m_tables.TryGetValue(mask, out Table? table))
            {
                return table;
            }

            // Create a new table.
            Table newTable = new(this, [typeof(T1), typeof(T2), typeof(T3)], mask);
            m_tables[mask] = newTable;
            return newTable;
        }

        public Bitfield128 GetTypeMask(Type i_type)
        {
            if (m_typesMasks.TryGetValue(i_type, out Bitfield128 mask))
            {
                return mask;
            }

            mask = Bitfield128.Zero;
            mask[m_nextBit] = true;
            m_typesMasks[i_type] = mask;
            m_nextBit++;
            return mask;
        }
    }
}
