namespace Massini.Core.Collections
{
    public class ObjectPool<T>(Func<T> i_factory)
        where T : class, IResettable
    {
        public T Borrow()
        {
            if (m_pool.Count > 0)
            {
                T obj = m_pool.Dequeue();
                m_set.Remove(obj);
                return obj;
            }
            return m_factory();
        }

        public bool Return(T i_object)
        {
            if (!m_set.Add(i_object))
            {
                return false;
            }

            i_object.TryReset();
            m_pool.Enqueue(i_object);
            return true;
        }

        private readonly Func<T> m_factory = i_factory;
        private readonly Queue<T> m_pool = [];
        private readonly HashSet<T> m_set = [];
    }
}
