
namespace Massini.Core.Interop
{
    /// <summary>
    /// Represents an unmanaged memory allocation.
    /// </summary>
    /// <remarks>
    /// Memory must only be freed trough <see cref="Dispose"/> method.
    /// Allocations aren't smart pointers.
    /// Allocations should have a single owner.
    /// </remarks>
    public unsafe struct UnsafeAlloc : IDisposable
    {
        public readonly void* ToRawPtr() => m_ptr;

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                if (m_ptr != null)
                {
                    m_freeCallback((nuint)m_ptr);
                }
            }
        }

        internal UnsafeAlloc(void* i_ptr, ulong i_size, Action<nuint> i_freeCallback)
        {
            m_ptr = i_ptr;
            m_size = i_size;
            m_freeCallback = i_freeCallback;
        }

        private bool m_isDisposed = false;
        private readonly void* m_ptr = null;
        private readonly ulong m_size = 0;
        private readonly Action<nuint> m_freeCallback;
    }

    /// <summary>
    /// Represents an unmanaged typed memory allocation.
    /// </summary>
    /// <remarks>
    /// Memory must only be freed trough <see cref="Dispose"/> method.
    /// Allocations aren't smart pointers.
    /// Allocations should have a single owner.
    /// </remarks>
    /// <typeparam name="T">An unmanaged struct type.</typeparam>
    public readonly unsafe struct UnsafeAlloc<T> : IDisposable
        where T : unmanaged
    {
        public readonly T* ToRawPtr() => (T*)m_alloc.ToRawPtr();

        public readonly void Dispose()
        {
            m_alloc.Dispose();
        }

        internal UnsafeAlloc(T* i_ptr, ulong i_size, Action<nuint> i_freeCallback)
        {
            m_alloc = new UnsafeAlloc((void*)i_ptr, i_size, i_freeCallback);
        }

        private readonly UnsafeAlloc m_alloc;
    }
}
