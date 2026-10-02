
namespace Massini.Core.Functional
{
    [System.Runtime.CompilerServices.Union]
    public readonly struct Result<TValue, TError> : System.Runtime.CompilerServices.IUnion
        where TValue: notnull
        where TError: notnull
    {
        public Result(TValue value)
        {
            m_value = value;
            m_which = 1;
        }

        public Result(TError value)
        {
            m_error = value;
            m_which = 2;
        }

        public static Result<TValue, TError> ok(TValue i_value)
        {
            return new Result<TValue, TError>(i_value);
        }
        
        public static Result<TValue, TError> error(TError i_error)
        {
            return new Result<TValue, TError>(i_error);
        }

        public object? Value => m_which switch
        {
            1 => m_value,
            2 => m_error,
            _ => throw new Exception($"Which is zero!")
        };

        public bool HasValue => m_which != 0;

        public bool TryGetValue(out TValue o_value)
        {
            ThrowIfZero();
            o_value = m_value;
            return m_which == 1;
        }

        public bool TryGetValue(out TError o_error)
        {
            ThrowIfZero();
            o_error = m_error;
            return m_which == 2;
        }
        
        private readonly TValue m_value;
        private readonly TError m_error;
        private readonly byte m_which; // 0 = exception, 1 = value, 2 = error

        private void ThrowIfZero()
        {
            if (m_which != 0) return;
            throw new Exception($"Which is zero!");
        }
    }
}