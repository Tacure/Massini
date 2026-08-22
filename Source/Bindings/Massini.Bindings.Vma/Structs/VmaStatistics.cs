
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vma.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VmaStatistics
    {
        /** \brief Number of `VkDeviceMemory` objects - Vulkan memory blocks allocated.
        */
        public uint p_blockCount;
        /** \brief Number of #VmaAllocation objects allocated.

        Dedicated allocations have their own blocks, so each one adds 1 to `allocationCount` as well as `blockCount`.
        */
        public uint p_allocationCount;
        /** \brief Number of bytes allocated in `VkDeviceMemory` blocks.

        \note To avoid confusion, please be aware that what Vulkan calls an "allocation" - a whole `VkDeviceMemory` object
        (e.g. as in `VkPhysicalDeviceLimits::maxMemoryAllocationCount`) is called a "block" in VMA, while VMA calls
        "allocation" a #VmaAllocation object that represents a memory region sub-allocated from such block, usually for a single buffer or image.
        */
        public ulong p_blockBytes;
        /** \brief Total number of bytes occupied by all #VmaAllocation objects.

        Always less or equal than `blockBytes`.
        Difference `(blockBytes - allocationBytes)` is the amount of memory allocated from Vulkan
        but unused by any #VmaAllocation.
        */
        public ulong p_allocationBytes;
    }
}
