namespace Massini.Flamet2.Impl.Classes.Commands
{
    internal sealed class CommandPool
    {
        public T Borrow<T>()
            where T : BaseCommand, new()
        {
            lock (m_pools)
            {
                Type type = typeof(T);
                if (!m_pools.TryGetValue(type, out IntCommandPool? pool))
                {
                    pool = new IntCommandPool<T>();
                    m_pools[type] = pool;
                }

                return ((IntCommandPool<T>)pool).Borrow();
            }
        }

        public void Return(BaseCommand i_command) 
        {
            lock (m_pools)
            {
                Type type = i_command.GetType();
                if (m_pools.TryGetValue(type, out IntCommandPool? pool))
                {
                    pool.Return(i_command);
                }
            }
        }

        private abstract class IntCommandPool
        {
            public abstract void Return(BaseCommand i_command);
        }

        private sealed class IntCommandPool<T> : IntCommandPool
            where T : BaseCommand, new()
        {
            public T Borrow() 
            {
                return m_pool.Count > 0 ? m_pool.Pop() : new T();
            }

            public override void Return(BaseCommand i_command) 
            {
                i_command.Reset();
                m_pool.Push((T)i_command);
            }

            private readonly Stack<T> m_pool = [];
        }

        private readonly Dictionary<Type, IntCommandPool> m_pools = [];
    }
}
