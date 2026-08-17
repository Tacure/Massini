#pragma once

// Definición de exportación para Windows/MSVC vs Resto
#if defined(_WIN32)
    #define EXPORT_API __declspec(dllexport)
#else
    #define EXPORT_API __attribute__((visibility("default")))
#endif

#include <vulkan/vulkan.h>
#include "vma/vk_mem_alloc.h"

#ifdef __cplusplus
extern "C" {
#endif

EXPORT_API VkResult vmaeCreateAllocator(VmaAllocatorCreateInfo* i_ptr_createInfo, VmaAllocator* o_ptr_allocator);

EXPORT_API void vmaeDestroyAllocator(VmaAllocator i_ptr_allocator);

EXPORT_API VkResult vmaeCreateBuffer(VmaAllocator i_ptr_allocator, VkBufferCreateInfo* i_ptr_bufferCreateInfo, VmaAllocationCreateInfo* i_ptr_allocationCreateInfo, VkBuffer* o_ptr_buffer, VmaAllocation* o_ptr_allocation, VmaAllocationInfo* o_ptr_allocationInfo);

EXPORT_API void vmaeDestroyBuffer(VmaAllocator i_ptr_allocator, VkBuffer i_ptr_buffer, VmaAllocation i_ptr_allocation);

EXPORT_API VkResult vmaeCreateImage(VmaAllocator i_ptr_allocator, VkImageCreateInfo* i_ptr_imageCreateInfo, VmaAllocationCreateInfo* i_ptr_allocationCreateInfo, VkImage* o_ptr_image, VmaAllocation* o_ptr_allocation, VmaAllocationInfo* o_ptr_allocationInfo);

EXPORT_API void vmaeDestroyImage(VmaAllocator i_ptr_allocator, VkImage i_ptr_image, VmaAllocation i_ptr_allocation);

EXPORT_API VkResult vmaeMapMemory(VmaAllocator i_ptr_allocator, VmaAllocation i_ptr_allocation, void** i_ptr_data);

EXPORT_API void vmaeUnmapMemory(VmaAllocator i_ptr_allocator, VmaAllocation i_ptr_allocation);

EXPORT_API VkResult vmaeInvalidateAllocation(VmaAllocator i_ptr_allocator, VmaAllocation i_ptr_allocation, VkDeviceSize i_offset, VkDeviceSize i_size);

EXPORT_API VkResult vmaeFlushAllocation(VmaAllocator i_ptr_allocator, VmaAllocation i_ptr_allocation, VkDeviceSize i_offset, VkDeviceSize i_size);

#ifdef __cplusplus
}
#endif