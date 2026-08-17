using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vulkan;
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vma.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VmaAllocatorCreateInfo
    {
        /// Flags for created allocator. Use #VmaAllocatorCreateFlagBits enum.
        public VmaAllocatorCreateFlagBits p_flags;
        /// Vulkan physical device.
        /** It must be valid throughout whole lifetime of created allocator. */
        public VkPhysicalDevice_T* p_ptr_physicalDevice;
        /// Vulkan device.
        /** It must be valid throughout whole lifetime of created allocator. */
        public VkDevice_T* p_ptr_device;
        /// Preferred size of a single `VkDeviceMemory` block to be allocated from large heaps > 1 GiB. Optional.
        /** Set to 0 to use default, which is currently 256 MiB. */
        public ulong p_preferredLargeHeapBlockSize;
        /// Custom CPU memory allocation callbacks. Optional.
        /** Optional, can be null. When specified, will also be used for all CPU-side memory allocations. */
        public VkAllocationCallbacks* p_ptr_allocationCallbacks;
        /// Informative callbacks for `vkAllocateMemory`, `vkFreeMemory`. Optional.
        /** Optional, can be null. */
        public VmaDeviceMemoryCallbacks* p_ptr_deviceMemoryCallbacks;
        /** \brief Either null or a pointer to an array of limits on maximum number of bytes that can be allocated out of particular Vulkan memory heap.

        If not NULL, it must be a pointer to an array of
        `VkPhysicalDeviceMemoryProperties::memoryHeapCount` elements, defining limit on
        maximum number of bytes that can be allocated out of particular Vulkan memory
        heap.

        Any of the elements may be equal to `VK_WHOLE_SIZE`, which means no limit on that
        heap. This is also the default in case of `pHeapSizeLimit` = NULL.

        If there is a limit defined for a heap:

        - If user tries to allocate more memory from that heap using this allocator,
          the allocation fails with `VK_ERROR_OUT_OF_DEVICE_MEMORY`.
        - If the limit is smaller than heap size reported in `VkMemoryHeap::size`, the
          value of this limit will be reported instead when using vmaGetMemoryProperties().

        Warning! Using this feature may not be equivalent to installing a GPU with
        smaller amount of memory, because graphics driver doesn't necessary fail new
        allocations with `VK_ERROR_OUT_OF_DEVICE_MEMORY` result when memory capacity is
        exceeded. It may return success and just silently migrate some device memory
        blocks to system RAM. This driver behavior can also be controlled using
        VK_AMD_memory_overallocation_behavior extension.
        */
        public ulong* p_ptr_heapSizeLimit;

        /** \brief Pointers to Vulkan functions. Can be null.

        For details see [Pointers to Vulkan functions](@ref config_Vulkan_functions).
        */
        public VmaVulkanFunctions* p_ptr_vulkanFunctions;
        /** \brief Handle to Vulkan instance object.

        Starting from version 3.0.0 this member is no longer optional, it must be set!
        */
        public VkInstance_T* p_ptr_instance;
        /** \brief Optional. Vulkan version that the application uses.

        It must be a value in the format as created by macro `VK_MAKE_VERSION` or a constant like: `VK_API_VERSION_1_1`, `VK_API_VERSION_1_0`.
        The patch version number specified is ignored. Only the major and minor versions are considered.
        Only versions 1.0...1.4 are supported by the current implementation.
        Leaving it initialized to zero is equivalent to `VK_API_VERSION_1_0`.
        It must match the Vulkan version used by the application and supported on the selected physical device,
        so it must be no higher than `VkApplicationInfo::apiVersion` passed to `vkCreateInstance`
        and no higher than `VkPhysicalDeviceProperties::apiVersion` found on the physical device used.
        */
        public uint p_vulkanApiVersion;
        /** \brief Either null or a pointer to an array of external memory handle types for each Vulkan memory type.

        If not NULL, it must be a pointer to an array of `VkPhysicalDeviceMemoryProperties::memoryTypeCount`
        elements, defining external memory handle types of particular Vulkan memory type,
        to be passed using `VkExportMemoryAllocateInfoKHR`.

        Any of the elements may be equal to 0, which means not to use `VkExportMemoryAllocateInfoKHR` on this memory type.
        This is also the default in case of `pTypeExternalMemoryHandleTypes` = NULL.
        */
        public VkExternalMemoryHandleTypeFlagBits* p_ptr_typeExternalMemoryHandleTypes;
    }
}
