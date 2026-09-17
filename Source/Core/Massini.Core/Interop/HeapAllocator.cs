
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Massini.Core.Interop
{
    /// <summary>
    /// Allocates heap memory and keeps track of unfreed allocations.
    /// </summary>
    public static unsafe class HeapAllocator
    {
        /// <summary>
        /// Allocates heap memory.
        /// </summary>
        public static HeapAlloc Alloc(MemorySize i_size)
        {
            if (i_size.Equals(MemorySize.Zero))
            {
                return HeapAlloc.Zero;
            }
            
            HeapAlloc alloc = new((byte*)NativeMemory.Alloc(i_size.ToBytes()), i_size, false, Rid.NewId());
            ActiveAllocations[alloc.Id] = alloc;
            return alloc;
        }

        /// <summary>
        /// Allocates heap memory and returns a typed allocation.
        /// </summary>
        public static HeapAlloc<T> Alloc<T>(int i_count = 1)
            where T : unmanaged
        {
            MemorySize size = MemorySize.FromBytes((nuint)(sizeof(T) * i_count));
            HeapAlloc alloc = Alloc(size);
            return new HeapAlloc<T>(alloc, i_count);
        }

        /// <summary>
        /// Allocates heap memory and initializes it with the given span.
        /// </summary>
        public static HeapAlloc<T> Alloc<T>(ReadOnlySpan<T> i_span)
            where T : unmanaged
        {
            HeapAlloc<T> alloc = Alloc<T>(i_span.Length);

            if (!alloc.IsValid())
            {
                return alloc;
            }
            
            fixed (T* srcPtr = i_span)
            {
                Unsafe.CopyBlock(alloc.RawPtr(), srcPtr, (uint)alloc.Size.ToBytes());
            }
            
            return alloc;
        }

        /// <summary>
        /// Frees a heap allocation.
        /// </summary>
        public static bool Free(HeapAlloc i_alloc)
        {
            if (!ActiveAllocations.TryRemove(i_alloc.Id, out _)) return false;
            
            NativeMemory.Free(i_alloc.RawPtr());
            return true;
        }

        /// <summary>
        /// Frees a typed heap allocation.
        /// </summary>
        public static bool Free<T>(HeapAlloc<T> i_alloc)
            where T : unmanaged
        {
            return Free(i_alloc.ToAlloc());
        }

        /// <summary>
        /// Returns true if the allocation is still valid at the time of the call.
        /// </summary>
        public static bool IsValid(HeapAlloc i_alloc)
        {
            return i_alloc.RawPtr() != null && ActiveAllocations.ContainsKey(i_alloc.Id);
        }
        
        /// <summary>
        /// Recovers a heap allocation from its id if found, otherwise returns a zeroed allocation.
        /// </summary>
        public static HeapAlloc RecoverFromId(Rid i_id)
        {
            return ActiveAllocations.TryGetValue(i_id, out var alloc) ? alloc : HeapAlloc.Zero;
        }

        private static readonly ConcurrentDictionary<Rid, HeapAlloc> ActiveAllocations = [];
    }   
}