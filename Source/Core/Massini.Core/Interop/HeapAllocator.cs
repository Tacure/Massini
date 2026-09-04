
using System.Collections.Concurrent;
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
            HeapAlloc alloc = new(NativeMemory.Alloc(i_size.ToBytes()), i_size, Rid.NewId());
            ActiveAllocations[alloc.Id] = alloc;
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