
namespace Massini.Core.Functional
{
    [System.Runtime.CompilerServices.Union]
    public readonly struct Either<T1, T2> : System.Runtime.CompilerServices.IUnion
        where T1: notnull
        where T2: notnull
    {
        public Either(T1 i_value1)
        {
            m_value1 = i_value1;
            m_which = 1;
        }

        public Either(T2 i_value2)
        {
            m_value2 = i_value2;
            m_which = 2;
        }

        public object? Value => m_which switch
        {
            1 => m_value1,
            2 => m_value2,
            _ => throw new Exception($"Which is zero!")
        };

        public bool HasValue => m_which != 0;

        public bool TryGetValue(out T1 o_value1)
        {
            ThrowIfZero();
            o_value1 = m_value1;
            return m_which == 1;
        }

        public bool TryGetValue(out T2 o_value2)
        {
            ThrowIfZero();
            o_value2 = m_value2;
            return m_which == 2;
        }
        
        private readonly T1 m_value1;
        private readonly T2 m_value2;
        private readonly byte m_which;

        private void ThrowIfZero()
        {
            if (m_which != 0) return;
            throw new Exception($"Which is zero!");
        }
    }
    
    [System.Runtime.CompilerServices.Union]
    public readonly struct Either<T1, T2, T3> : System.Runtime.CompilerServices.IUnion
        where T1: notnull
        where T2: notnull
        where T3: notnull
    {
        public Either(T1 i_value1)
        {
            m_value1 = i_value1;
            m_which = 1;
        }

        public Either(T2 i_value2)
        {
            m_value2 = i_value2;
            m_which = 2;
        }
        
        public Either(T3 i_value3)
        {
            m_value3 = i_value3;
            m_which = 3;
        }

        public object? Value => m_which switch
        {
            1 => m_value1,
            2 => m_value2,
            3 => m_value3,
            _ => throw new Exception($"Which is zero!")
        };

        public bool HasValue => m_which != 0;

        public bool TryGetValue(out T1 o_value1)
        {
            ThrowIfZero();
            o_value1 = m_value1;
            return m_which == 1;
        }

        public bool TryGetValue(out T2 o_value2)
        {
            ThrowIfZero();
            o_value2 = m_value2;
            return m_which == 2;
        }
        
        public bool TryGetValue(out T3 o_value3)
        {
            ThrowIfZero();
            o_value3 = m_value3;
            return m_which == 3;
        }
        
        private readonly T1 m_value1;
        private readonly T2 m_value2;
        private readonly T3 m_value3;
        private readonly byte m_which;

        private void ThrowIfZero()
        {
            if (m_which != 0) return;
            throw new Exception($"Which is zero!");
        }
    }
    
    [System.Runtime.CompilerServices.Union]
    public readonly struct Either<T1, T2, T3, T4> : System.Runtime.CompilerServices.IUnion
        where T1: notnull
        where T2: notnull
        where T3: notnull
        where T4: notnull
    {
        public Either(T1 i_value1)
        {
            m_value1 = i_value1;
            m_which = 1;
        }

        public Either(T2 i_value2)
        {
            m_value2 = i_value2;
            m_which = 2;
        }
        
        public Either(T3 i_value3)
        {
            m_value3 = i_value3;
            m_which = 3;
        }
        
        public Either(T4 i_value4)
        {
            m_value4 = i_value4;
            m_which = 4;
        }

        public object? Value => m_which switch
        {
            1 => m_value1,
            2 => m_value2,
            3 => m_value3,
            4 => m_value4,
            _ => throw new Exception($"Which is zero!")
        };

        public bool HasValue => m_which != 0;

        public bool TryGetValue(out T1 o_value1)
        {
            ThrowIfZero();
            o_value1 = m_value1;
            return m_which == 1;
        }

        public bool TryGetValue(out T2 o_value2)
        {
            ThrowIfZero();
            o_value2 = m_value2;
            return m_which == 2;
        }
        
        public bool TryGetValue(out T3 o_value3)
        {
            ThrowIfZero();
            o_value3 = m_value3;
            return m_which == 3;
        }
        
        public bool TryGetValue(out T4 o_value4)
        {
            ThrowIfZero();
            o_value4 = m_value4;
            return m_which == 4;
        }
        
        private readonly T1 m_value1;
        private readonly T2 m_value2;
        private readonly T3 m_value3;
        private readonly T4 m_value4;
        private readonly byte m_which;

        private void ThrowIfZero()
        {
            if (m_which != 0) return;
            throw new Exception($"Which is zero!");
        }
    }
}