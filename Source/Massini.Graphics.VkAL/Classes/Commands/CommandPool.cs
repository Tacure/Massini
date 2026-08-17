using Massini.Graphics.VkAL.Classes.Commands;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CommandPool
    {
        public T Borrow<T>()
            where T : Command, new()
        {
            Type type = typeof(T);
            if (!m_pools.TryGetValue(type, out IntCommandPool? pool))
            {
                pool = new IntCommandPool<T>();
                m_pools[type] = pool;
            }
            return ((IntCommandPool<T>)pool).Borrow();
        }

        public void Return(Command i_command) 
        {
            Type type = i_command.GetType();
            if (m_pools.TryGetValue(type, out IntCommandPool? pool))
            {
                pool.Return(i_command);
            }
        }

        private abstract class IntCommandPool
        {
            public abstract void Return(Command i_command);
        }

        private sealed class IntCommandPool<T> : IntCommandPool
            where T : Command, new()
        {
            public T Borrow() 
            {
                return m_pool.Count > 0 ? m_pool.Pop() : new T();
            }

            public override void Return(Command i_command) 
            {
                i_command.Reset();
                m_pool.Push((T)i_command);
            }

            private readonly Stack<T> m_pool = [];
        }

        private readonly Dictionary<Type, IntCommandPool> m_pools = [];
    }
}
