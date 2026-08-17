
using Massini.Bindings.Vulkan;
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vma.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VmaAllocationInfo
    {
        /** \brief Memory type index that this allocation was allocated from.

        It never changes.
        */
        public uint p_memoryType;
        /** \brief Handle to Vulkan memory object.

        Same memory object can be shared by multiple allocations.

        It can change after the allocation is moved during \ref defragmentation.
        */
        public VkDeviceMemory_T* p_deviceMemory;
        /** \brief Offset in `VkDeviceMemory` object to the beginning of this allocation, in bytes. `(deviceMemory, offset)` pair is unique to this allocation.

        You usually don't need to use this offset. If you create a buffer or an image together with the allocation using e.g. function
        vmaCreateBuffer(), vmaCreateImage(), functions that operate on these resources refer to the beginning of the buffer or image,
        not entire device memory block. Functions like vmaMapMemory(), vmaBindBufferMemory() also refer to the beginning of the allocation
        and apply this offset automatically.

        It can change after the allocation is moved during \ref defragmentation.
        */
        public ulong p_offset;
        /** \brief Size of this allocation, in bytes.

        It never changes.

        \note Allocation size returned in this variable may be greater than the size
        requested for the resource e.g. as `VkBufferCreateInfo::size`. Whole size of the
        allocation is accessible for operations on memory e.g. using a pointer after
        mapping with vmaMapMemory(), but operations on the resource e.g. using
        `vkCmdCopyBuffer` must be limited to the size of the resource.
        */
        public ulong p_size;
        /** \brief Pointer to the beginning of this allocation as mapped data.

        If the allocation hasn't been mapped using vmaMapMemory() and hasn't been
        created with #VMA_ALLOCATION_CREATE_MAPPED_BIT flag, this value is null.

        It can change after call to vmaMapMemory(), vmaUnmapMemory().
        It can also change after the allocation is moved during \ref defragmentation.
        */
        public void* p_ptr_mappedData;
        /** \brief Custom general-purpose pointer that was passed as VmaAllocationCreateInfo::pUserData or set using vmaSetAllocationUserData().

        It can change after call to vmaSetAllocationUserData() for this allocation.
        */
        public void* p_ptr_userData;
        /** \brief Custom allocation name that was set with vmaSetAllocationName().

        It can change after call to vmaSetAllocationName() for this allocation.

        Another way to set custom name is to pass it in VmaAllocationCreateInfo::pUserData with
        additional flag #VMA_ALLOCATION_CREATE_USER_DATA_COPY_STRING_BIT set [DEPRECATED].
        */
        public char* p_ptr_name;
    }
}
