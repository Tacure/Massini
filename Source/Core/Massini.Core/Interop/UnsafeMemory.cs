
using System.Runtime.InteropServices;

namespace Massini.Core.Interop
{
    public unsafe static class UnsafeMemory
    {
        public static UnsafeAlloc<T> Alloc<T>(nuint i_count = 1)
            where T : unmanaged
        {
            ulong size = (ulong)sizeof(T) * i_count;
            return new((T*)NativeMemory.Alloc((nuint)size), size, ptr => NativeMemory.Free((void*)ptr));
        }

        public static UnsafeAlloc Alloc(nuint i_bytes)
        {
            return new (NativeMemory.Alloc(i_bytes), i_bytes, ptr => NativeMemory.Free((void*)ptr));
        }

        /// <summary>
        /// Should only be used when giving ownership of an allocation to native code.
        /// </summary>
        /// <param name="i_ptr">Allocation to free.</param>
        public static void FreeRogueAlloc(void* i_ptr)
        {
            NativeMemory.Free(i_ptr);
        }
    }
}
