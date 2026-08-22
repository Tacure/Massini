
namespace Massini.Entities.Extensions
{
    public static class EntityExtensions
    {
        extension(Entity i_entity)
        {
            public bool Has<T>()
            {
                return i_entity.in_table?.Components.Contains(typeof(T)) ?? false;
            }

            public ref T? Get<T>()
            {
                if (i_entity.in_table == null)
                {
                    throw new InvalidOperationException($"Entity doesn't have a component of type {typeof(T).Name}.");
                }

                return ref i_entity.in_table.Get<T>(i_entity);
            }

            public void Add<T>(in T i_component)
            {
                if (i_entity.in_table == null)
                {
                    throw new InvalidOperationException("Entity isn't valid.");
                }

                // Create mask.
                Bitfield128 mask = i_entity.in_table.TypesMask;
                mask = mask.Combine(i_entity.in_table.Storage.GetTypeMask(typeof(T)));

                // Get table.
                Table table = i_entity.in_table.Storage.GetTable(mask);

                // Move entity.
                i_entity.in_table.Move(i_entity, table);

                // Set component.
                table.Get<T>(i_entity) = i_component;
            }

            public void Remove<T>()
            {
                if (i_entity.in_table == null)
                {
                    throw new InvalidOperationException($"Entity doesn't have a component of type {typeof(T).Name}.");
                }

                // Create mask.
                Bitfield128 mask = i_entity.in_table.TypesMask;
                mask = mask.Remove(i_entity.in_table.Storage.GetTypeMask(typeof(T)));

                // Get table.
                Table table = i_entity.in_table.Storage.GetTable(mask);

                // Move entity.
                i_entity.in_table.Move(i_entity, table);
            }
        }
    }
}
