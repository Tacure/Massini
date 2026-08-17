
using System.Runtime.InteropServices;

namespace Massini.Interop
{
    public unsafe readonly struct ObjectHandle
    {
        public static ObjectHandle Pin(object i_object)
        {
            return new ObjectHandle((void*)GCHandle.Alloc(i_object, GCHandleType.Normal).AddrOfPinnedObject());
        }

        public static ObjectHandle FromRawPtr(void* i_ptr)
        {
            return new ObjectHandle(i_ptr);
        }

        public void Unpin()
        {
            GCHandle.FromIntPtr((nint)m_ptr).Free();
        }

        public void* ToRawPtr()
        {
            return m_ptr;
        }

        public T? Target<T>()
            where T : class
        {
            return (T?)GCHandle.FromIntPtr((nint)m_ptr).Target;
        }

        private readonly void* m_ptr;

        private ObjectHandle(void* i_ptr)
        {
            m_ptr = i_ptr;
        }
    }
}
