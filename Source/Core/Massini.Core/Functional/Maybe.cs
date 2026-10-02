using System.Runtime.CompilerServices;

namespace Massini.Core.Functional
{
    [Union]
    public readonly struct Maybe<TSome> : IUnion
        where TSome : notnull
    {
        /// <summary>
        /// Use Some/None static methods.
        /// </summary>
        public Maybe(TSome i_some)
        {
            m_some = i_some;
            m_isSome = 1;
        }

        /// <summary>
        /// Use Some/None static methods.
        /// </summary>
        public Maybe(None i_none)
        {
            m_none = i_none;
            m_isSome = 0;
        }

        public static Maybe<TSome> Some(TSome i_some)
        {
            return new Maybe<TSome>(i_some);
        }

        public static Maybe<TSome> None()
        {
            return new Maybe<TSome>(Functional.None.none());
        }

        /// <summary>
        /// Union interface, don't use directly.
        /// </summary>
        public object? Value => m_isSome switch
        {
            0 => m_none,
            1 => m_some,
            _ => null
        };

        public bool IsSome => m_isSome == 1;

        public bool IsNone => m_isSome == 0;

        /// <summary>
        /// Use only if you are sure it's Some.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Tried to get Some when Maybe is None.</exception>
        public TSome GetSome()
        {
            return IsSome ? m_some : throw new Exception("Can't get Some if Maybe is None.");
        }

        /// <summary>
        /// Union interface, don't use directly. Always returns true.
        /// </summary>
        public bool HasValue => true; // All maybes are always None or Some.
                                      // All maybes are None when initialized with default.

        public bool TryGetValue(out TSome o_some)
        {
            o_some = m_some;
            return m_isSome == 1;
        }

        public bool TryGetValue(out None o_none)
        {
            o_none = m_none;
            return m_isSome == 0;
        }
        
        private readonly TSome m_some;
        private readonly None m_none;
        private readonly byte m_isSome; // 0 = none, 1 = value
    }   
}