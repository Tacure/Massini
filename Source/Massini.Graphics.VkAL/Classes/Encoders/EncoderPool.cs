using System.Collections.Concurrent;

namespace Massini.Graphics.VkAL.Classes.Encoders
{
    internal sealed class EncoderPool
    {
        public T Borrow<T>()
            where T : CommandEncoder, new()
        {
            IntEncoderPool pool = m_pools.GetOrAdd(typeof(T), _ => { return new IntEncoderPool<T>(); });
            return ((IntEncoderPool<T>)pool).Borrow();
        }

        public void Return(CommandEncoder i_encoder) 
        {
            m_pools[i_encoder.GetType()].Return(i_encoder);
        }

        private abstract class IntEncoderPool 
        {
            public abstract void Return(CommandEncoder i_encoder);
        }

        private sealed class IntEncoderPool<T> : IntEncoderPool
            where T : CommandEncoder, new()
        {
            public T Borrow() 
            {
                lock (m_pool)
                {
                    if (m_pool.Count == 0) 
                    {
                        return new T();
                    }

                    return m_pool.Pop();
                }
            }

            public override void Return(CommandEncoder i_encoder) 
            {
                lock (m_pool)
                {
                    i_encoder.Reset();
                    m_pool.Push((T)i_encoder);
                }
            }

            private readonly Stack<T> m_pool = [];
        }

        private readonly ConcurrentDictionary<Type, IntEncoderPool> m_pools = [];
    }
}
