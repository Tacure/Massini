using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vma.Handles;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Massini.Bindings.Vulkan;

namespace Massini.Bindings.Vma
{
    public static partial class Vma
    {
        private const string VMA_LIBRARY = "vma";
    }

    public static partial class Vma 
    {
        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeCreateAllocator")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaCreateAllocator(VmaAllocatorCreateInfo* i_ptr_createInfo, VmaAllocator** o_ptr_allocator);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeDestroyAllocator")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaDestroyAllocator(VmaAllocator* i_ptr_allocator);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeGetPoolStatistics")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaGetPoolStatistics(VmaAllocator* i_ptr_allocator, VmaPool* i_ptr_pool, VmaStatistics* o_ptr_stats);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeGetAllocationInfo")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaGetAllocationInfo(VmaAllocator i_ptr_allocator, VmaAllocation* i_ptr_allocation, VmaAllocationInfo* o_ptr_allocationInfo);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeInvalidateAllocation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaInvalidateAllocation(VmaAllocator* i_ptr_allocator, VmaAllocation* i_ptr_allocation, ulong i_sizeOffset, ulong i_sizeLength);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeFlushAllocation")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaFlushAllocation(VmaAllocator* i_ptr_allocator, VmaAllocation* i_ptr_allocation, ulong i_sizeOffset, ulong i_sizeLength);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeCreateBuffer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaCreateBuffer(VmaAllocator* i_ptr_allocator, VkBufferCreateInfo* i_ptr_bufferCreateInfo, VmaAllocationCreateInfo* i_ptr_allocationCreateInfo, VkBuffer_T** o_ptr_buffer, VmaAllocation** o_ptr_allocation, VmaAllocationInfo* i_ptr_allocationInfo);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeDestroyBuffer")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaDestroyBuffer(VmaAllocator* i_ptr_allocator, VkBuffer_T* i_ptr_buffer, VmaAllocation* i_ptr_allocation);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeCreateImage")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaCreateImage(VmaAllocator* i_ptr_allocator, VkImageCreateInfo* i_ptr_imageCreateInfo, VmaAllocationCreateInfo* i_ptr_allocationCreateInfo, VkImage_T** o_ptr_image, VmaAllocation** o_ptr_allocation, VmaAllocationInfo* i_ptr_allocationInfo);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeDestroyImage")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaDestroyImage(VmaAllocator* i_ptr_allocator, VkImage_T* i_ptr_image, VmaAllocation* i_allocation);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeMapMemory")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial VkResult vmaMapMemory(VmaAllocator* i_ptr_allocator, VmaAllocation* i_ptr_allocation, void** i_ptr_data);

        [LibraryImport(VMA_LIBRARY, EntryPoint = "vmaeUnmapMemory")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static unsafe partial void vmaUnmapMemory(VmaAllocator* i_ptr_allocator, VmaAllocation* i_ptr_allocation);
    }
}
