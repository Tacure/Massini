using System;
using System.Runtime.InteropServices;

namespace Massini.Bindings.Vulkan
{
    public static unsafe partial class Vk
    {
        [NativeTypeName("#define VULKAN_H_ 1")]
        public const int VULKAN_H_ = 1;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateInstance([NativeTypeName("const VkInstanceCreateInfo *")] VkInstanceCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkInstance *")] VkInstance_T** pInstance);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyInstance([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumeratePhysicalDevices([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("uint32_t *")] uint* pPhysicalDeviceCount, [NativeTypeName("VkPhysicalDevice *")] VkPhysicalDevice_T** pPhysicalDevices);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFeatures([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceFeatures* pFeatures);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFormatProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceImageFormatProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, [NativeTypeName("VkImageUsageFlags")] uint usage, [NativeTypeName("VkImageCreateFlags")] uint flags, VkImageFormatProperties* pImageFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceQueueFamilyProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceMemoryProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("PFN_vkVoidFunction")]
        public static extern delegate* unmanaged[Stdcall]<void> vkGetInstanceProcAddr([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const char *")] sbyte* pName);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("PFN_vkVoidFunction")]
        public static extern delegate* unmanaged[Stdcall]<void> vkGetDeviceProcAddr([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const char *")] sbyte* pName);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDevice([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkDeviceCreateInfo *")] VkDeviceCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDevice *")] VkDevice_T** pDevice);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDevice([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumerateInstanceExtensionProperties([NativeTypeName("const char *")] sbyte* pLayerName, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkExtensionProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumerateDeviceExtensionProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const char *")] sbyte* pLayerName, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkExtensionProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumerateInstanceLayerProperties([NativeTypeName("uint32_t *")] uint* pPropertyCount, VkLayerProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumerateDeviceLayerProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkLayerProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceQueue([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint queueFamilyIndex, [NativeTypeName("uint32_t")] uint queueIndex, [NativeTypeName("VkQueue *")] VkQueue_T** pQueue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueSubmit([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t")] uint submitCount, [NativeTypeName("const VkSubmitInfo *")] VkSubmitInfo* pSubmits, [NativeTypeName("VkFence")] VkFence_T* fence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueWaitIdle([NativeTypeName("VkQueue")] VkQueue_T* queue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkDeviceWaitIdle([NativeTypeName("VkDevice")] VkDevice_T* device);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAllocateMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryAllocateInfo *")] VkMemoryAllocateInfo* pAllocateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDeviceMemory *")] VkDeviceMemory_T** pMemory);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkFreeMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkMapMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkDeviceSize")] ulong size, [NativeTypeName("VkMemoryMapFlags")] uint flags, void** ppData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUnmapMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkFlushMappedMemoryRanges([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint memoryRangeCount, [NativeTypeName("const VkMappedMemoryRange *")] VkMappedMemoryRange* pMemoryRanges);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkInvalidateMappedMemoryRanges([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint memoryRangeCount, [NativeTypeName("const VkMappedMemoryRange *")] VkMappedMemoryRange* pMemoryRanges);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceMemoryCommitment([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("VkDeviceSize *")] ulong* pCommittedMemoryInBytes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindBufferMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("VkDeviceSize")] ulong memoryOffset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindImageMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("VkDeviceSize")] ulong memoryOffset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetBufferMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, VkMemoryRequirements* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, VkMemoryRequirements* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSparseMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("uint32_t *")] uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceSparseImageFormatProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlagBits samples, [NativeTypeName("VkImageUsageFlags")] uint usage, VkImageTiling tiling, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkSparseImageFormatProperties* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueBindSparse([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindSparseInfo *")] VkBindSparseInfo* pBindInfo, [NativeTypeName("VkFence")] VkFence_T* fence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateFence([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkFenceCreateInfo *")] VkFenceCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkFence *")] VkFence_T** pFence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyFence([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkFence")] VkFence_T* fence, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkResetFences([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint fenceCount, [NativeTypeName("const VkFence *")] VkFence_T** pFences);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetFenceStatus([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkFence")] VkFence_T* fence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWaitForFences([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint fenceCount, [NativeTypeName("const VkFence *")] VkFence_T** pFences, [NativeTypeName("VkBool32")] uint waitAll, [NativeTypeName("uint64_t")] ulong timeout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSemaphore([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreCreateInfo *")] VkSemaphoreCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSemaphore *")] VkSemaphore_T** pSemaphore);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySemaphore([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSemaphore")] VkSemaphore_T* semaphore, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateEvent([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkEventCreateInfo *")] VkEventCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkEvent *")] VkEvent_T** pEvent);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyEvent([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetEventStatus([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkEvent")] VkEvent_T* @event);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetEvent([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkEvent")] VkEvent_T* @event);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkResetEvent([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkEvent")] VkEvent_T* @event);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateQueryPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkQueryPoolCreateInfo *")] VkQueryPoolCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkQueryPool *")] VkQueryPool_T** pQueryPool);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyQueryPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetQueryPoolResults([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount, [NativeTypeName("size_t")] nuint dataSize, void* pData, [NativeTypeName("VkDeviceSize")] ulong stride, [NativeTypeName("VkQueryResultFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateBuffer([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferCreateInfo *")] VkBufferCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkBuffer *")] VkBuffer_T** pBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyBuffer([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateBufferView([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferViewCreateInfo *")] VkBufferViewCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkBufferView *")] VkBufferView_T** pView);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyBufferView([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkBufferView")] VkBufferView_T* bufferView, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateImage([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageCreateInfo *")] VkImageCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkImage *")] VkImage_T** pImage);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyImage([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSubresourceLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("const VkImageSubresource *")] VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateImageView([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageViewCreateInfo *")] VkImageViewCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkImageView *")] VkImageView_T** pView);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyImageView([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImageView")] VkImageView_T* imageView, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateShaderModule([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkShaderModuleCreateInfo *")] VkShaderModuleCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkShaderModule *")] VkShaderModule_T** pShaderModule);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyShaderModule([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkShaderModule")] VkShaderModule_T* shaderModule, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreatePipelineCache([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineCacheCreateInfo *")] VkPipelineCacheCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipelineCache *")] VkPipelineCache_T** pPipelineCache);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPipelineCache([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineCacheData([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("size_t *")] nuint* pDataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkMergePipelineCaches([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* dstCache, [NativeTypeName("uint32_t")] uint srcCacheCount, [NativeTypeName("const VkPipelineCache *")] VkPipelineCache_T** pSrcCaches);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateGraphicsPipelines([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("uint32_t")] uint createInfoCount, [NativeTypeName("const VkGraphicsPipelineCreateInfo *")] VkGraphicsPipelineCreateInfo* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipeline *")] VkPipeline_T** pPipelines);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateComputePipelines([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("uint32_t")] uint createInfoCount, [NativeTypeName("const VkComputePipelineCreateInfo *")] VkComputePipelineCreateInfo* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipeline *")] VkPipeline_T** pPipelines);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPipeline([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreatePipelineLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineLayoutCreateInfo *")] VkPipelineLayoutCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipelineLayout *")] VkPipelineLayout_T** pPipelineLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPipelineLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* pipelineLayout, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSampler([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSamplerCreateInfo *")] VkSamplerCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSampler *")] VkSampler_T** pSampler);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySampler([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSampler")] VkSampler_T* sampler, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDescriptorSetLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorSetLayoutCreateInfo *")] VkDescriptorSetLayoutCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDescriptorSetLayout *")] VkDescriptorSetLayout_T** pSetLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDescriptorSetLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSetLayout")] VkDescriptorSetLayout_T* descriptorSetLayout, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDescriptorPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorPoolCreateInfo *")] VkDescriptorPoolCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDescriptorPool *")] VkDescriptorPool_T** pDescriptorPool);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDescriptorPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorPool")] VkDescriptorPool_T* descriptorPool, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkResetDescriptorPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorPool")] VkDescriptorPool_T* descriptorPool, [NativeTypeName("VkDescriptorPoolResetFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAllocateDescriptorSets([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorSetAllocateInfo *")] VkDescriptorSetAllocateInfo* pAllocateInfo, [NativeTypeName("VkDescriptorSet *")] VkDescriptorSet_T** pDescriptorSets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkFreeDescriptorSets([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorPool")] VkDescriptorPool_T* descriptorPool, [NativeTypeName("uint32_t")] uint descriptorSetCount, [NativeTypeName("const VkDescriptorSet *")] VkDescriptorSet_T** pDescriptorSets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUpdateDescriptorSets([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint descriptorWriteCount, [NativeTypeName("const VkWriteDescriptorSet *")] VkWriteDescriptorSet* pDescriptorWrites, [NativeTypeName("uint32_t")] uint descriptorCopyCount, [NativeTypeName("const VkCopyDescriptorSet *")] VkCopyDescriptorSet* pDescriptorCopies);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateFramebuffer([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkFramebufferCreateInfo *")] VkFramebufferCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkFramebuffer *")] VkFramebuffer_T** pFramebuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyFramebuffer([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkFramebuffer")] VkFramebuffer_T* framebuffer, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateRenderPass([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderPassCreateInfo *")] VkRenderPassCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkRenderPass *")] VkRenderPass_T** pRenderPass);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyRenderPass([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkRenderPass")] VkRenderPass_T* renderPass, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetRenderAreaGranularity([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkRenderPass")] VkRenderPass_T* renderPass, VkExtent2D* pGranularity);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateCommandPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCommandPoolCreateInfo *")] VkCommandPoolCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkCommandPool *")] VkCommandPool_T** pCommandPool);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyCommandPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCommandPool")] VkCommandPool_T* commandPool, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkResetCommandPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCommandPool")] VkCommandPool_T* commandPool, [NativeTypeName("VkCommandPoolResetFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAllocateCommandBuffers([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCommandBufferAllocateInfo *")] VkCommandBufferAllocateInfo* pAllocateInfo, [NativeTypeName("VkCommandBuffer *")] VkCommandBuffer_T** pCommandBuffers);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkFreeCommandBuffers([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCommandPool")] VkCommandPool_T* commandPool, [NativeTypeName("uint32_t")] uint commandBufferCount, [NativeTypeName("const VkCommandBuffer *")] VkCommandBuffer_T** pCommandBuffers);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBeginCommandBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCommandBufferBeginInfo *")] VkCommandBufferBeginInfo* pBeginInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEndCommandBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkResetCommandBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkCommandBufferResetFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindPipeline([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewport([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstViewport, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkViewport *")] VkViewport* pViewports);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetScissor([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstScissor, [NativeTypeName("uint32_t")] uint scissorCount, [NativeTypeName("const VkRect2D *")] VkRect2D* pScissors);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineWidth([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, float lineWidth);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBias([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetBlendConstants([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const float[4]")] float* blendConstants);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBounds([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, float minDepthBounds, float maxDepthBounds);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilCompareMask([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkStencilFaceFlags")] uint faceMask, [NativeTypeName("uint32_t")] uint compareMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilWriteMask([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkStencilFaceFlags")] uint faceMask, [NativeTypeName("uint32_t")] uint writeMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilReference([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkStencilFaceFlags")] uint faceMask, [NativeTypeName("uint32_t")] uint reference);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorSets([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint firstSet, [NativeTypeName("uint32_t")] uint descriptorSetCount, [NativeTypeName("const VkDescriptorSet *")] VkDescriptorSet_T** pDescriptorSets, [NativeTypeName("uint32_t")] uint dynamicOffsetCount, [NativeTypeName("const uint32_t *")] uint* pDynamicOffsets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindIndexBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, VkIndexType indexType);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindVertexBuffers([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstBinding, [NativeTypeName("uint32_t")] uint bindingCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pOffsets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDraw([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint vertexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstVertex, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndexed([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint indexCount, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstIndex, [NativeTypeName("int32_t")] int vertexOffset, [NativeTypeName("uint32_t")] uint firstInstance);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndirect([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndexedIndirect([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDispatch([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint groupCountX, [NativeTypeName("uint32_t")] uint groupCountY, [NativeTypeName("uint32_t")] uint groupCountZ);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDispatchIndirect([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* srcBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkBufferCopy *")] VkBufferCopy* pRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* srcImage, VkImageLayout srcImageLayout, [NativeTypeName("VkImage")] VkImage_T* dstImage, VkImageLayout dstImageLayout, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkImageCopy *")] VkImageCopy* pRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBlitImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* srcImage, VkImageLayout srcImageLayout, [NativeTypeName("VkImage")] VkImage_T* dstImage, VkImageLayout dstImageLayout, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkImageBlit *")] VkImageBlit* pRegions, VkFilter filter);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBufferToImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* srcBuffer, [NativeTypeName("VkImage")] VkImage_T* dstImage, VkImageLayout dstImageLayout, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkBufferImageCopy *")] VkBufferImageCopy* pRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImageToBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* srcImage, VkImageLayout srcImageLayout, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkBufferImageCopy *")] VkBufferImageCopy* pRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdUpdateBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("VkDeviceSize")] ulong dstOffset, [NativeTypeName("VkDeviceSize")] ulong dataSize, [NativeTypeName("const void *")] void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdFillBuffer([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("VkDeviceSize")] ulong dstOffset, [NativeTypeName("VkDeviceSize")] ulong size, [NativeTypeName("uint32_t")] uint data);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdClearColorImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* image, VkImageLayout imageLayout, [NativeTypeName("const VkClearColorValue *")] VkClearColorValue* pColor, [NativeTypeName("uint32_t")] uint rangeCount, [NativeTypeName("const VkImageSubresourceRange *")] VkImageSubresourceRange* pRanges);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdClearDepthStencilImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* image, VkImageLayout imageLayout, [NativeTypeName("const VkClearDepthStencilValue *")] VkClearDepthStencilValue* pDepthStencil, [NativeTypeName("uint32_t")] uint rangeCount, [NativeTypeName("const VkImageSubresourceRange *")] VkImageSubresourceRange* pRanges);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdClearAttachments([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkClearAttachment *")] VkClearAttachment* pAttachments, [NativeTypeName("uint32_t")] uint rectCount, [NativeTypeName("const VkClearRect *")] VkClearRect* pRects);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResolveImage([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImage")] VkImage_T* srcImage, VkImageLayout srcImageLayout, [NativeTypeName("VkImage")] VkImage_T* dstImage, VkImageLayout dstImageLayout, [NativeTypeName("uint32_t")] uint regionCount, [NativeTypeName("const VkImageResolve *")] VkImageResolve* pRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetEvent([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("VkPipelineStageFlags")] uint stageMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResetEvent([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("VkPipelineStageFlags")] uint stageMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWaitEvents([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint eventCount, [NativeTypeName("const VkEvent *")] VkEvent_T** pEvents, [NativeTypeName("VkPipelineStageFlags")] uint srcStageMask, [NativeTypeName("VkPipelineStageFlags")] uint dstStageMask, [NativeTypeName("uint32_t")] uint memoryBarrierCount, [NativeTypeName("const VkMemoryBarrier *")] VkMemoryBarrier* pMemoryBarriers, [NativeTypeName("uint32_t")] uint bufferMemoryBarrierCount, [NativeTypeName("const VkBufferMemoryBarrier *")] VkBufferMemoryBarrier* pBufferMemoryBarriers, [NativeTypeName("uint32_t")] uint imageMemoryBarrierCount, [NativeTypeName("const VkImageMemoryBarrier *")] VkImageMemoryBarrier* pImageMemoryBarriers);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPipelineBarrier([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkPipelineStageFlags")] uint srcStageMask, [NativeTypeName("VkPipelineStageFlags")] uint dstStageMask, [NativeTypeName("VkDependencyFlags")] uint dependencyFlags, [NativeTypeName("uint32_t")] uint memoryBarrierCount, [NativeTypeName("const VkMemoryBarrier *")] VkMemoryBarrier* pMemoryBarriers, [NativeTypeName("uint32_t")] uint bufferMemoryBarrierCount, [NativeTypeName("const VkBufferMemoryBarrier *")] VkBufferMemoryBarrier* pBufferMemoryBarriers, [NativeTypeName("uint32_t")] uint imageMemoryBarrierCount, [NativeTypeName("const VkImageMemoryBarrier *")] VkImageMemoryBarrier* pImageMemoryBarriers);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginQuery([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query, [NativeTypeName("VkQueryControlFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndQuery([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResetQueryPool([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteTimestamp([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineStageFlagBits pipelineStage, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyQueryPoolResults([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("VkDeviceSize")] ulong dstOffset, [NativeTypeName("VkDeviceSize")] ulong stride, [NativeTypeName("VkQueryResultFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushConstants([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("VkShaderStageFlags")] uint stageFlags, [NativeTypeName("uint32_t")] uint offset, [NativeTypeName("uint32_t")] uint size, [NativeTypeName("const void *")] void* pValues);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginRenderPass([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderPassBeginInfo *")] VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdNextSubpass([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkSubpassContents contents);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRenderPass([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdExecuteCommands([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint commandBufferCount, [NativeTypeName("const VkCommandBuffer *")] VkCommandBuffer_T** pCommandBuffers);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumerateInstanceVersion([NativeTypeName("uint32_t *")] uint* pApiVersion);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindBufferMemory2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindBufferMemoryInfo *")] VkBindBufferMemoryInfo* pBindInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindImageMemory2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindImageMemoryInfo *")] VkBindImageMemoryInfo* pBindInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceGroupPeerMemoryFeatures([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint heapIndex, [NativeTypeName("uint32_t")] uint localDeviceIndex, [NativeTypeName("uint32_t")] uint remoteDeviceIndex, [NativeTypeName("VkPeerMemoryFeatureFlags *")] uint* pPeerMemoryFeatures);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDeviceMask([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint deviceMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDispatchBase([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint baseGroupX, [NativeTypeName("uint32_t")] uint baseGroupY, [NativeTypeName("uint32_t")] uint baseGroupZ, [NativeTypeName("uint32_t")] uint groupCountX, [NativeTypeName("uint32_t")] uint groupCountY, [NativeTypeName("uint32_t")] uint groupCountZ);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumeratePhysicalDeviceGroups([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("uint32_t *")] uint* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageMemoryRequirements2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageMemoryRequirementsInfo2 *")] VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetBufferMemoryRequirements2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferMemoryRequirementsInfo2 *")] VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSparseMemoryRequirements2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageSparseMemoryRequirementsInfo2 *")] VkImageSparseMemoryRequirementsInfo2* pInfo, [NativeTypeName("uint32_t *")] uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFeatures2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceProperties2* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFormatProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceImageFormatProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceImageFormatInfo2 *")] VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceQueueFamilyProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceMemoryProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceSparseImageFormatProperties2([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceSparseImageFormatInfo2 *")] VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkSparseImageFormatProperties2* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkTrimCommandPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCommandPool")] VkCommandPool_T* commandPool, [NativeTypeName("VkCommandPoolTrimFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceQueue2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceQueueInfo2 *")] VkDeviceQueueInfo2* pQueueInfo, [NativeTypeName("VkQueue *")] VkQueue_T** pQueue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSamplerYcbcrConversion([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSamplerYcbcrConversionCreateInfo *")] VkSamplerYcbcrConversionCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSamplerYcbcrConversion *")] VkSamplerYcbcrConversion_T** pYcbcrConversion);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySamplerYcbcrConversion([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSamplerYcbcrConversion")] VkSamplerYcbcrConversion_T* ycbcrConversion, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDescriptorUpdateTemplate([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorUpdateTemplateCreateInfo *")] VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDescriptorUpdateTemplate *")] VkDescriptorUpdateTemplate_T** pDescriptorUpdateTemplate);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDescriptorUpdateTemplate([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUpdateDescriptorSetWithTemplate([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSet")] VkDescriptorSet_T* descriptorSet, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("const void *")] void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalBufferProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalBufferInfo *")] VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalFenceProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalFenceInfo *")] VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalSemaphoreProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalSemaphoreInfo *")] VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetLayoutSupport([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorSetLayoutCreateInfo *")] VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndirectCount([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndexedIndirectCount([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateRenderPass2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderPassCreateInfo2 *")] VkRenderPassCreateInfo2* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkRenderPass *")] VkRenderPass_T** pRenderPass);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginRenderPass2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderPassBeginInfo *")] VkRenderPassBeginInfo* pRenderPassBegin, [NativeTypeName("const VkSubpassBeginInfo *")] VkSubpassBeginInfo* pSubpassBeginInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdNextSubpass2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSubpassBeginInfo *")] VkSubpassBeginInfo* pSubpassBeginInfo, [NativeTypeName("const VkSubpassEndInfo *")] VkSubpassEndInfo* pSubpassEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRenderPass2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSubpassEndInfo *")] VkSubpassEndInfo* pSubpassEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkResetQueryPool([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSemaphoreCounterValue([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSemaphore")] VkSemaphore_T* semaphore, [NativeTypeName("uint64_t *")] ulong* pValue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWaitSemaphores([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreWaitInfo *")] VkSemaphoreWaitInfo* pWaitInfo, [NativeTypeName("uint64_t")] ulong timeout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSignalSemaphore([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreSignalInfo *")] VkSemaphoreSignalInfo* pSignalInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceAddress")]
        public static extern ulong vkGetBufferDeviceAddress([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferDeviceAddressInfo *")] VkBufferDeviceAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong vkGetBufferOpaqueCaptureAddress([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferDeviceAddressInfo *")] VkBufferDeviceAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong vkGetDeviceMemoryOpaqueCaptureAddress([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceMemoryOpaqueCaptureAddressInfo *")] VkDeviceMemoryOpaqueCaptureAddressInfo* pInfo);

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_NONE = 0UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TOP_OF_PIPE_BIT = 0x00000001UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT = 0x00000002UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT = 0x00000004UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT = 0x00000008UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TESSELLATION_CONTROL_SHADER_BIT = 0x00000010UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TESSELLATION_EVALUATION_SHADER_BIT = 0x00000020UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT = 0x00000040UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT = 0x00000080UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_EARLY_FRAGMENT_TESTS_BIT = 0x00000100UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_LATE_FRAGMENT_TESTS_BIT = 0x00000200UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT = 0x00000400UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT = 0x00000800UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_TRANSFER_BIT = 0x00001000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TRANSFER_BIT = 0x00001000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT = 0x00002000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_HOST_BIT = 0x00004000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT = 0x00008000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT = 0x00010000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COPY_BIT = 0x100000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_RESOLVE_BIT = 0x200000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_BLIT_BIT = 0x400000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_CLEAR_BIT = 0x800000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT = 0x1000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT = 0x2000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT = 0x4000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VIDEO_DECODE_BIT_KHR = 0x04000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VIDEO_ENCODE_BIT_KHR = 0x08000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_NONE_KHR = 0UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TOP_OF_PIPE_BIT_KHR = 0x00000001UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT_KHR = 0x00000002UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT_KHR = 0x00000004UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT_KHR = 0x00000008UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TESSELLATION_CONTROL_SHADER_BIT_KHR = 0x00000010UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TESSELLATION_EVALUATION_SHADER_BIT_KHR = 0x00000020UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT_KHR = 0x00000040UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT_KHR = 0x00000080UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_EARLY_FRAGMENT_TESTS_BIT_KHR = 0x00000100UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_LATE_FRAGMENT_TESTS_BIT_KHR = 0x00000200UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT_KHR = 0x00000400UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT_KHR = 0x00000800UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_TRANSFER_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TRANSFER_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT_KHR = 0x00002000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_HOST_BIT_KHR = 0x00004000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT_KHR = 0x00008000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT_KHR = 0x00010000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COPY_BIT_KHR = 0x100000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_RESOLVE_BIT_KHR = 0x200000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_BLIT_BIT_KHR = 0x400000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_CLEAR_BIT_KHR = 0x800000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT_KHR = 0x1000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT_KHR = 0x2000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT_KHR = 0x4000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TRANSFORM_FEEDBACK_BIT_EXT = 0x01000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00040000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_NV = 0x00020000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_EXT = 0x00020000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00400000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_SHADING_RATE_IMAGE_BIT_NV = 0x00400000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_KHR = 0x02000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_KHR = 0x00200000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_NV = 0x00200000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_NV = 0x02000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_DENSITY_PROCESS_BIT_EXT = 0x00800000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TASK_SHADER_BIT_NV = 0x00080000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_NV = 0x00100000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_TASK_SHADER_BIT_EXT = 0x00080000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_EXT = 0x00100000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_SUBPASS_SHADER_BIT_HUAWEI = 0x8000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_SUBPASS_SHADING_BIT_HUAWEI = 0x8000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_INVOCATION_MASK_BIT_HUAWEI = 0x10000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_COPY_BIT_KHR = 0x10000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_MICROMAP_BUILD_BIT_EXT = 0x40000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_CLUSTER_CULLING_SHADER_BIT_HUAWEI = 0x20000000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_OPTICAL_FLOW_BIT_NV = 0x20000000UL;

        [NativeTypeName("const VkPipelineStageFlagBits2")]
        public const ulong VK_PIPELINE_STAGE_2_CONVERT_COOPERATIVE_VECTOR_MATRIX_BIT_NV = 0x100000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_NONE = 0UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT = 0x00000001UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INDEX_READ_BIT = 0x00000002UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT = 0x00000004UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_UNIFORM_READ_BIT = 0x00000008UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT = 0x00000010UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_READ_BIT = 0x00000020UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_WRITE_BIT = 0x00000040UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT = 0x00000080UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT = 0x00000100UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT = 0x00000200UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = 0x00000400UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFER_READ_BIT = 0x00000800UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFER_WRITE_BIT = 0x00001000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_HOST_READ_BIT = 0x00002000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_HOST_WRITE_BIT = 0x00004000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MEMORY_READ_BIT = 0x00008000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MEMORY_WRITE_BIT = 0x00010000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_SAMPLED_READ_BIT = 0x100000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_STORAGE_READ_BIT = 0x200000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT = 0x400000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VIDEO_DECODE_READ_BIT_KHR = 0x800000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VIDEO_DECODE_WRITE_BIT_KHR = 0x1000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VIDEO_ENCODE_READ_BIT_KHR = 0x2000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VIDEO_ENCODE_WRITE_BIT_KHR = 0x4000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_TILE_ATTACHMENT_READ_BIT_QCOM = 0x8000000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_TILE_ATTACHMENT_WRITE_BIT_QCOM = 0x10000000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_NONE_KHR = 0UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT_KHR = 0x00000001UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INDEX_READ_BIT_KHR = 0x00000002UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT_KHR = 0x00000004UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_UNIFORM_READ_BIT_KHR = 0x00000008UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT_KHR = 0x00000010UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_READ_BIT_KHR = 0x00000020UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_WRITE_BIT_KHR = 0x00000040UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT_KHR = 0x00000080UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT_KHR = 0x00000100UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT_KHR = 0x00000200UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT_KHR = 0x00000400UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFER_READ_BIT_KHR = 0x00000800UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFER_WRITE_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_HOST_READ_BIT_KHR = 0x00002000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_HOST_WRITE_BIT_KHR = 0x00004000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MEMORY_READ_BIT_KHR = 0x00008000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MEMORY_WRITE_BIT_KHR = 0x00010000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_SAMPLED_READ_BIT_KHR = 0x100000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_STORAGE_READ_BIT_KHR = 0x200000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT_KHR = 0x400000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFORM_FEEDBACK_WRITE_BIT_EXT = 0x02000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFORM_FEEDBACK_COUNTER_READ_BIT_EXT = 0x04000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_TRANSFORM_FEEDBACK_COUNTER_WRITE_BIT_EXT = 0x08000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_CONDITIONAL_RENDERING_READ_BIT_EXT = 0x00100000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_NV = 0x00020000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_NV = 0x00040000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_EXT = 0x00020000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_EXT = 0x00040000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_FRAGMENT_SHADING_RATE_ATTACHMENT_READ_BIT_KHR = 0x00800000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADING_RATE_IMAGE_READ_BIT_NV = 0x00800000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_KHR = 0x00200000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_KHR = 0x00400000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_NV = 0x00200000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_NV = 0x00400000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_FRAGMENT_DENSITY_MAP_READ_BIT_EXT = 0x01000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_NONCOHERENT_BIT_EXT = 0x00080000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_DESCRIPTOR_BUFFER_READ_BIT_EXT = 0x20000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_INVOCATION_MASK_READ_BIT_HUAWEI = 0x8000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_SHADER_BINDING_TABLE_READ_BIT_KHR = 0x10000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MICROMAP_READ_BIT_EXT = 0x100000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_MICROMAP_WRITE_BIT_EXT = 0x200000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_OPTICAL_FLOW_READ_BIT_NV = 0x40000000000UL;

        [NativeTypeName("const VkAccessFlagBits2")]
        public const ulong VK_ACCESS_2_OPTICAL_FLOW_WRITE_BIT_NV = 0x80000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT = 0x00000001UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT = 0x00000002UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT = 0x00000004UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_UNIFORM_TEXEL_BUFFER_BIT = 0x00000008UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_BIT = 0x00000010UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_ATOMIC_BIT = 0x00000020UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT = 0x00000040UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT = 0x00000080UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT = 0x00000100UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000200UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BLIT_SRC_BIT = 0x00000400UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BLIT_DST_BIT = 0x00000800UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT = 0x00001000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_TRANSFER_SRC_BIT = 0x00004000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_TRANSFER_DST_BIT = 0x00008000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT = 0x00010000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT = 0x00020000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT = 0x00040000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT = 0x00080000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT = 0x00100000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT = 0x00200000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_DISJOINT_BIT = 0x00400000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT = 0x00800000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT = 0x80000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT = 0x100000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT = 0x200000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT = 0x00002000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_HOST_IMAGE_TRANSFER_BIT = 0x400000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_DECODE_OUTPUT_BIT_KHR = 0x02000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_DECODE_DPB_BIT_KHR = 0x04000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_VERTEX_BUFFER_BIT_KHR = 0x20000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x01000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x40000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_HOST_IMAGE_TRANSFER_BIT_EXT = 0x400000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_INPUT_BIT_KHR = 0x08000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_DPB_BIT_KHR = 0x10000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT_KHR = 0x00000001UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT_KHR = 0x00000002UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT_KHR = 0x00000004UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_UNIFORM_TEXEL_BUFFER_BIT_KHR = 0x00000008UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_BIT_KHR = 0x00000010UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_ATOMIC_BIT_KHR = 0x00000020UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT_KHR = 0x00000040UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT_KHR = 0x00000080UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT_KHR = 0x00000100UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT_KHR = 0x00000200UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BLIT_SRC_BIT_KHR = 0x00000400UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BLIT_DST_BIT_KHR = 0x00000800UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_TRANSFER_SRC_BIT_KHR = 0x00004000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_TRANSFER_DST_BIT_KHR = 0x00008000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT_KHR = 0x00020000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT_KHR = 0x00040000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT_KHR = 0x00080000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT_KHR = 0x00100000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT_KHR = 0x00200000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_DISJOINT_BIT_KHR = 0x00400000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT_KHR = 0x00800000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT_KHR = 0x80000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT_KHR = 0x100000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT_KHR = 0x200000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT_KHR = 0x00010000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT_EXT = 0x00002000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_RADIUS_BUFFER_BIT_NV = 0x8000000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_LINEAR_COLOR_ATTACHMENT_BIT_NV = 0x4000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_WEIGHT_IMAGE_BIT_QCOM = 0x400000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_WEIGHT_SAMPLED_IMAGE_BIT_QCOM = 0x800000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BLOCK_MATCHING_BIT_QCOM = 0x1000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_BOX_FILTER_SAMPLED_BIT_QCOM = 0x2000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_IMAGE_BIT_NV = 0x10000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_VECTOR_BIT_NV = 0x20000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_COST_BIT_NV = 0x40000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x2000000000000UL;

        [NativeTypeName("const VkFormatFeatureFlagBits2")]
        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x4000000000000UL;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceToolProperties([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pToolCount, VkPhysicalDeviceToolProperties* pToolProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreatePrivateDataSlot([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPrivateDataSlotCreateInfo *")] VkPrivateDataSlotCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPrivateDataSlot *")] VkPrivateDataSlot_T** pPrivateDataSlot);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPrivateDataSlot([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetPrivateData([NativeTypeName("VkDevice")] VkDevice_T* device, VkObjectType objectType, [NativeTypeName("uint64_t")] ulong objectHandle, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("uint64_t")] ulong data);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPrivateData([NativeTypeName("VkDevice")] VkDevice_T* device, VkObjectType objectType, [NativeTypeName("uint64_t")] ulong objectHandle, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("uint64_t *")] ulong* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetEvent2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResetEvent2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("VkPipelineStageFlags2")] ulong stageMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWaitEvents2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint eventCount, [NativeTypeName("const VkEvent *")] VkEvent_T** pEvents, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPipelineBarrier2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteTimestamp2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkPipelineStageFlags2")] ulong stage, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueSubmit2([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t")] uint submitCount, [NativeTypeName("const VkSubmitInfo2 *")] VkSubmitInfo2* pSubmits, [NativeTypeName("VkFence")] VkFence_T* fence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBuffer2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyBufferInfo2 *")] VkCopyBufferInfo2* pCopyBufferInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImage2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyImageInfo2 *")] VkCopyImageInfo2* pCopyImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBufferToImage2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyBufferToImageInfo2 *")] VkCopyBufferToImageInfo2* pCopyBufferToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImageToBuffer2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyImageToBufferInfo2 *")] VkCopyImageToBufferInfo2* pCopyImageToBufferInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBlitImage2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBlitImageInfo2 *")] VkBlitImageInfo2* pBlitImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResolveImage2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkResolveImageInfo2 *")] VkResolveImageInfo2* pResolveImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginRendering([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingInfo *")] VkRenderingInfo* pRenderingInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRendering([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCullMode([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkCullModeFlags")] uint cullMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetFrontFace([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkFrontFace frontFace);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPrimitiveTopology([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPrimitiveTopology primitiveTopology);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportWithCount([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkViewport *")] VkViewport* pViewports);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetScissorWithCount([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint scissorCount, [NativeTypeName("const VkRect2D *")] VkRect2D* pScissors);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindVertexBuffers2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstBinding, [NativeTypeName("uint32_t")] uint bindingCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pOffsets, [NativeTypeName("const VkDeviceSize *")] ulong* pSizes, [NativeTypeName("const VkDeviceSize *")] ulong* pStrides);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthTestEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthWriteEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthWriteEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthCompareOp([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkCompareOp depthCompareOp);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBoundsTestEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthBoundsTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilTestEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint stencilTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilOp([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkStencilFaceFlags")] uint faceMask, VkStencilOp failOp, VkStencilOp passOp, VkStencilOp depthFailOp, VkCompareOp compareOp);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRasterizerDiscardEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint rasterizerDiscardEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBiasEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthBiasEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPrimitiveRestartEnable([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint primitiveRestartEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceBufferMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceBufferMemoryRequirements *")] VkDeviceBufferMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageMemoryRequirements *")] VkDeviceImageMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageSparseMemoryRequirements([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageMemoryRequirements *")] VkDeviceImageMemoryRequirements* pInfo, [NativeTypeName("uint32_t *")] uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT = 0x00000001UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT = 0x00000002UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DERIVATIVE_BIT = 0x00000004UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT = 0x00000008UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT = 0x00000010UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT = 0x00000100UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT = 0x00000200UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT = 0x08000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT = 0x40000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_EXECUTION_GRAPH_BIT_AMDX = 0x100000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_BUILT_IN_PRIMITIVES_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_ALLOW_SPHERES_AND_LINEAR_SWEPT_SPHERES_BIT_NV = 0x200000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_ENABLE_LEGACY_DITHERING_BIT_EXT = 0x400000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT_KHR = 0x00000001UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT_KHR = 0x00000002UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DERIVATIVE_BIT_KHR = 0x00000004UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT_KHR = 0x00000008UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT_KHR = 0x00000010UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DEFER_COMPILE_BIT_NV = 0x00000020UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_STATISTICS_BIT_KHR = 0x00000040UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_INTERNAL_REPRESENTATIONS_BIT_KHR = 0x00000080UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT_KHR = 0x00000100UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT_KHR = 0x00000200UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_LINK_TIME_OPTIMIZATION_BIT_EXT = 0x00000400UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RETAIN_LINK_TIME_OPTIMIZATION_INFO_BIT_EXT = 0x00800000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_LIBRARY_BIT_KHR = 0x00000800UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_TRIANGLES_BIT_KHR = 0x00001000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_AABBS_BIT_KHR = 0x00002000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NULL_ANY_HIT_SHADERS_BIT_KHR = 0x00004000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NULL_CLOSEST_HIT_SHADERS_BIT_KHR = 0x00008000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NULL_MISS_SHADERS_BIT_KHR = 0x00010000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NULL_INTERSECTION_SHADERS_BIT_KHR = 0x00020000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_SHADER_GROUP_HANDLE_CAPTURE_REPLAY_BIT_KHR = 0x00080000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_NV = 0x00040000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_ALLOW_MOTION_BIT_NV = 0x00100000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00200000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = 0x00400000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_OPACITY_MICROMAP_BIT_EXT = 0x01000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_COLOR_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x02000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DEPTH_STENCIL_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x04000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT_EXT = 0x08000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT_EXT = 0x40000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_DISPLACEMENT_MICROMAP_BIT_NV = 0x10000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DESCRIPTOR_BUFFER_BIT_EXT = 0x20000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_DISALLOW_OPACITY_MICROMAP_BIT_ARM = 0x2000000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_DATA_BIT_KHR = 0x80000000UL;

        [NativeTypeName("const VkPipelineCreateFlagBits2")]
        public const ulong VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_EXT = 0x4000000000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFER_SRC_BIT = 0x00000001UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFER_DST_BIT = 0x00000002UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_UNIFORM_TEXEL_BUFFER_BIT = 0x00000004UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_STORAGE_TEXEL_BUFFER_BIT = 0x00000008UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT = 0x00000010UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT = 0x00000020UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT = 0x00000040UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT = 0x00000080UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT = 0x00000100UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT = 0x00020000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_EXECUTION_GRAPH_SCRATCH_BIT_AMDX = 0x02000000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFER_SRC_BIT_KHR = 0x00000001UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFER_DST_BIT_KHR = 0x00000002UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_UNIFORM_TEXEL_BUFFER_BIT_KHR = 0x00000004UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_STORAGE_TEXEL_BUFFER_BIT_KHR = 0x00000008UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT_KHR = 0x00000010UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT_KHR = 0x00000020UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT_KHR = 0x00000040UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT_KHR = 0x00000080UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT_KHR = 0x00000100UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00000200UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_SHADER_BINDING_TABLE_BIT_KHR = 0x00000400UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_RAY_TRACING_BIT_NV = 0x00000400UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFORM_FEEDBACK_BUFFER_BIT_EXT = 0x00000800UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TRANSFORM_FEEDBACK_COUNTER_BUFFER_BIT_EXT = 0x00001000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VIDEO_DECODE_SRC_BIT_KHR = 0x00002000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VIDEO_DECODE_DST_BIT_KHR = 0x00004000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VIDEO_ENCODE_DST_BIT_KHR = 0x00008000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_VIDEO_ENCODE_SRC_BIT_KHR = 0x00010000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT_KHR = 0x00020000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_BUILD_INPUT_READ_ONLY_BIT_KHR = 0x00080000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_STORAGE_BIT_KHR = 0x00100000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_SAMPLER_DESCRIPTOR_BUFFER_BIT_EXT = 0x00200000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_RESOURCE_DESCRIPTOR_BUFFER_BIT_EXT = 0x00400000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_PUSH_DESCRIPTORS_DESCRIPTOR_BUFFER_BIT_EXT = 0x04000000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_MICROMAP_BUILD_INPUT_READ_ONLY_BIT_EXT = 0x00800000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_MICROMAP_STORAGE_BIT_EXT = 0x01000000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_TILE_MEMORY_QCOM = 0x08000000UL;

        [NativeTypeName("const VkBufferUsageFlagBits2")]
        public const ulong VK_BUFFER_USAGE_2_PREPROCESS_BUFFER_BIT_EXT = 0x80000000UL;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineStipple([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint lineStippleFactor, [NativeTypeName("uint16_t")] ushort lineStipplePattern);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkMapMemory2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryMapInfo *")] VkMemoryMapInfo* pMemoryMapInfo, void** ppData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkUnmapMemory2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryUnmapInfo *")] VkMemoryUnmapInfo* pMemoryUnmapInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindIndexBuffer2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkDeviceSize")] ulong size, VkIndexType indexType);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetRenderingAreaGranularity([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderingAreaInfo *")] VkRenderingAreaInfo* pRenderingAreaInfo, VkExtent2D* pGranularity);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageSubresourceLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageSubresourceInfo *")] VkDeviceImageSubresourceInfo* pInfo, VkSubresourceLayout2* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSubresourceLayout2([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("const VkImageSubresource2 *")] VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSet([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint set, [NativeTypeName("uint32_t")] uint descriptorWriteCount, [NativeTypeName("const VkWriteDescriptorSet *")] VkWriteDescriptorSet* pDescriptorWrites);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSetWithTemplate([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint set, [NativeTypeName("const void *")] void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRenderingAttachmentLocations([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingAttachmentLocationInfo *")] VkRenderingAttachmentLocationInfo* pLocationInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRenderingInputAttachmentIndices([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingInputAttachmentIndexInfo *")] VkRenderingInputAttachmentIndexInfo* pInputAttachmentIndexInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorSets2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBindDescriptorSetsInfo *")] VkBindDescriptorSetsInfo* pBindDescriptorSetsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushConstants2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushConstantsInfo *")] VkPushConstantsInfo* pPushConstantsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSet2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushDescriptorSetInfo *")] VkPushDescriptorSetInfo* pPushDescriptorSetInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSetWithTemplate2([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushDescriptorSetWithTemplateInfo *")] VkPushDescriptorSetWithTemplateInfo* pPushDescriptorSetWithTemplateInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMemoryToImage([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyMemoryToImageInfo *")] VkCopyMemoryToImageInfo* pCopyMemoryToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyImageToMemory([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyImageToMemoryInfo *")] VkCopyImageToMemoryInfo* pCopyImageToMemoryInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyImageToImage([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyImageToImageInfo *")] VkCopyImageToImageInfo* pCopyImageToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkTransitionImageLayout([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint transitionCount, [NativeTypeName("const VkHostImageLayoutTransitionInfo *")] VkHostImageLayoutTransitionInfo* pTransitions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySurfaceKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceSupportKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t")] uint queueFamilyIndex, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("VkBool32 *")] uint* pSupported);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, VkSurfaceCapabilitiesKHR* pSurfaceCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceFormatsKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("uint32_t *")] uint* pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfacePresentModesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("uint32_t *")] uint* pPresentModeCount, VkPresentModeKHR* pPresentModes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSwapchainKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSwapchainCreateInfoKHR *")] VkSwapchainCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSwapchainKHR *")] VkSwapchainKHR_T** pSwapchain);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySwapchainKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSwapchainImagesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("uint32_t *")] uint* pSwapchainImageCount, [NativeTypeName("VkImage *")] VkImage_T** pSwapchainImages);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireNextImageKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("uint64_t")] ulong timeout, [NativeTypeName("VkSemaphore")] VkSemaphore_T* semaphore, [NativeTypeName("VkFence")] VkFence_T* fence, [NativeTypeName("uint32_t *")] uint* pImageIndex);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueuePresentKHR([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("const VkPresentInfoKHR *")] VkPresentInfoKHR* pPresentInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeviceGroupPresentCapabilitiesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, VkDeviceGroupPresentCapabilitiesKHR* pDeviceGroupPresentCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeviceGroupSurfacePresentModesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("VkDeviceGroupPresentModeFlagsKHR *")] uint* pModes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDevicePresentRectanglesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, [NativeTypeName("uint32_t *")] uint* pRectCount, VkRect2D* pRects);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireNextImage2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAcquireNextImageInfoKHR *")] VkAcquireNextImageInfoKHR* pAcquireInfo, [NativeTypeName("uint32_t *")] uint* pImageIndex);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceDisplayPropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayPropertiesKHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDisplayPlaneSupportedDisplaysKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t")] uint planeIndex, [NativeTypeName("uint32_t *")] uint* pDisplayCount, [NativeTypeName("VkDisplayKHR *")] VkDisplayKHR_T** pDisplays);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDisplayModePropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayModePropertiesKHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDisplayModeKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display, [NativeTypeName("const VkDisplayModeCreateInfoKHR *")] VkDisplayModeCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDisplayModeKHR *")] VkDisplayModeKHR_T** pMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDisplayPlaneCapabilitiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayModeKHR")] VkDisplayModeKHR_T* mode, [NativeTypeName("uint32_t")] uint planeIndex, VkDisplayPlaneCapabilitiesKHR* pCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDisplayPlaneSurfaceKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkDisplaySurfaceCreateInfoKHR *")] VkDisplaySurfaceCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** pSurface);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSharedSwapchainsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint swapchainCount, [NativeTypeName("const VkSwapchainCreateInfoKHR *")] VkSwapchainCreateInfoKHR* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSwapchainKHR *")] VkSwapchainKHR_T** pSwapchains);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceVideoCapabilitiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkVideoProfileInfoKHR *")] VkVideoProfileInfoKHR* pVideoProfile, VkVideoCapabilitiesKHR* pCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceVideoFormatPropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceVideoFormatInfoKHR *")] VkPhysicalDeviceVideoFormatInfoKHR* pVideoFormatInfo, [NativeTypeName("uint32_t *")] uint* pVideoFormatPropertyCount, VkVideoFormatPropertiesKHR* pVideoFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateVideoSessionKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkVideoSessionCreateInfoKHR *")] VkVideoSessionCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkVideoSessionKHR *")] VkVideoSessionKHR_T** pVideoSession);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyVideoSessionKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkVideoSessionKHR")] VkVideoSessionKHR_T* videoSession, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetVideoSessionMemoryRequirementsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkVideoSessionKHR")] VkVideoSessionKHR_T* videoSession, [NativeTypeName("uint32_t *")] uint* pMemoryRequirementsCount, VkVideoSessionMemoryRequirementsKHR* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindVideoSessionMemoryKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkVideoSessionKHR")] VkVideoSessionKHR_T* videoSession, [NativeTypeName("uint32_t")] uint bindSessionMemoryInfoCount, [NativeTypeName("const VkBindVideoSessionMemoryInfoKHR *")] VkBindVideoSessionMemoryInfoKHR* pBindSessionMemoryInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateVideoSessionParametersKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkVideoSessionParametersCreateInfoKHR *")] VkVideoSessionParametersCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkVideoSessionParametersKHR *")] VkVideoSessionParametersKHR_T** pVideoSessionParameters);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkUpdateVideoSessionParametersKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkVideoSessionParametersKHR")] VkVideoSessionParametersKHR_T* videoSessionParameters, [NativeTypeName("const VkVideoSessionParametersUpdateInfoKHR *")] VkVideoSessionParametersUpdateInfoKHR* pUpdateInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyVideoSessionParametersKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkVideoSessionParametersKHR")] VkVideoSessionParametersKHR_T* videoSessionParameters, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginVideoCodingKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkVideoBeginCodingInfoKHR *")] VkVideoBeginCodingInfoKHR* pBeginInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndVideoCodingKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkVideoEndCodingInfoKHR *")] VkVideoEndCodingInfoKHR* pEndCodingInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdControlVideoCodingKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkVideoCodingControlInfoKHR *")] VkVideoCodingControlInfoKHR* pCodingControlInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDecodeVideoKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkVideoDecodeInfoKHR *")] VkVideoDecodeInfoKHR* pDecodeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginRenderingKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingInfo *")] VkRenderingInfo* pRenderingInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRenderingKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFeatures2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceProperties2* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceFormatProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceImageFormatProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceImageFormatInfo2 *")] VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceQueueFamilyProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceMemoryProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceSparseImageFormatProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceSparseImageFormatInfo2 *")] VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkSparseImageFormatProperties2* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceGroupPeerMemoryFeaturesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint heapIndex, [NativeTypeName("uint32_t")] uint localDeviceIndex, [NativeTypeName("uint32_t")] uint remoteDeviceIndex, [NativeTypeName("VkPeerMemoryFeatureFlags *")] uint* pPeerMemoryFeatures);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDeviceMaskKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint deviceMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDispatchBaseKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint baseGroupX, [NativeTypeName("uint32_t")] uint baseGroupY, [NativeTypeName("uint32_t")] uint baseGroupZ, [NativeTypeName("uint32_t")] uint groupCountX, [NativeTypeName("uint32_t")] uint groupCountY, [NativeTypeName("uint32_t")] uint groupCountZ);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkTrimCommandPoolKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCommandPool")] VkCommandPool_T* commandPool, [NativeTypeName("VkCommandPoolTrimFlags")] uint flags);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumeratePhysicalDeviceGroupsKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("uint32_t *")] uint* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalBufferPropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalBufferInfo *")] VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryFdKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryGetFdInfoKHR *")] VkMemoryGetFdInfoKHR* pGetFdInfo, int* pFd);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryFdPropertiesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, VkExternalMemoryHandleTypeFlagBits handleType, int fd, VkMemoryFdPropertiesKHR* pMemoryFdProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalSemaphoreInfo *")] VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkImportSemaphoreFdKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImportSemaphoreFdInfoKHR *")] VkImportSemaphoreFdInfoKHR* pImportSemaphoreFdInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSemaphoreFdKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreGetFdInfoKHR *")] VkSemaphoreGetFdInfoKHR* pGetFdInfo, int* pFd);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSetKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint set, [NativeTypeName("uint32_t")] uint descriptorWriteCount, [NativeTypeName("const VkWriteDescriptorSet *")] VkWriteDescriptorSet* pDescriptorWrites);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSetWithTemplateKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint set, [NativeTypeName("const void *")] void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDescriptorUpdateTemplateKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorUpdateTemplateCreateInfo *")] VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDescriptorUpdateTemplate *")] VkDescriptorUpdateTemplate_T** pDescriptorUpdateTemplate);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDescriptorUpdateTemplateKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUpdateDescriptorSetWithTemplateKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSet")] VkDescriptorSet_T* descriptorSet, [NativeTypeName("VkDescriptorUpdateTemplate")] VkDescriptorUpdateTemplate_T* descriptorUpdateTemplate, [NativeTypeName("const void *")] void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateRenderPass2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderPassCreateInfo2 *")] VkRenderPassCreateInfo2* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkRenderPass *")] VkRenderPass_T** pRenderPass);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginRenderPass2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderPassBeginInfo *")] VkRenderPassBeginInfo* pRenderPassBegin, [NativeTypeName("const VkSubpassBeginInfo *")] VkSubpassBeginInfo* pSubpassBeginInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdNextSubpass2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSubpassBeginInfo *")] VkSubpassBeginInfo* pSubpassBeginInfo, [NativeTypeName("const VkSubpassEndInfo *")] VkSubpassEndInfo* pSubpassEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRenderPass2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSubpassEndInfo *")] VkSubpassEndInfo* pSubpassEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSwapchainStatusKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceExternalFencePropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceExternalFenceInfo *")] VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkImportFenceFdKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImportFenceFdInfoKHR *")] VkImportFenceFdInfoKHR* pImportFenceFdInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetFenceFdKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkFenceGetFdInfoKHR *")] VkFenceGetFdInfoKHR* pGetFdInfo, int* pFd);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t")] uint queueFamilyIndex, [NativeTypeName("uint32_t *")] uint* pCounterCount, VkPerformanceCounterKHR* pCounters, VkPerformanceCounterDescriptionKHR* pCounterDescriptions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkQueryPoolPerformanceCreateInfoKHR *")] VkQueryPoolPerformanceCreateInfoKHR* pPerformanceQueryCreateInfo, [NativeTypeName("uint32_t *")] uint* pNumPasses);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireProfilingLockKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAcquireProfilingLockInfoKHR *")] VkAcquireProfilingLockInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkReleaseProfilingLockKHR([NativeTypeName("VkDevice")] VkDevice_T* device);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceSurfaceInfo2KHR *")] VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceFormats2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceSurfaceInfo2KHR *")] VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, [NativeTypeName("uint32_t *")] uint* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceDisplayProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayProperties2KHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceDisplayPlaneProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayPlaneProperties2KHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDisplayModeProperties2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkDisplayModeProperties2KHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDisplayPlaneCapabilities2KHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkDisplayPlaneInfo2KHR *")] VkDisplayPlaneInfo2KHR* pDisplayPlaneInfo, VkDisplayPlaneCapabilities2KHR* pCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageMemoryRequirements2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageMemoryRequirementsInfo2 *")] VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetBufferMemoryRequirements2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferMemoryRequirementsInfo2 *")] VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSparseMemoryRequirements2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageSparseMemoryRequirementsInfo2 *")] VkImageSparseMemoryRequirementsInfo2* pInfo, [NativeTypeName("uint32_t *")] uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateSamplerYcbcrConversionKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSamplerYcbcrConversionCreateInfo *")] VkSamplerYcbcrConversionCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSamplerYcbcrConversion *")] VkSamplerYcbcrConversion_T** pYcbcrConversion);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroySamplerYcbcrConversionKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSamplerYcbcrConversion")] VkSamplerYcbcrConversion_T* ycbcrConversion, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindBufferMemory2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindBufferMemoryInfo *")] VkBindBufferMemoryInfo* pBindInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindImageMemory2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindImageMemoryInfo *")] VkBindImageMemoryInfo* pBindInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetLayoutSupportKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorSetLayoutCreateInfo *")] VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndirectCountKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndexedIndirectCountKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSemaphoreCounterValueKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSemaphore")] VkSemaphore_T* semaphore, [NativeTypeName("uint64_t *")] ulong* pValue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWaitSemaphoresKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreWaitInfo *")] VkSemaphoreWaitInfo* pWaitInfo, [NativeTypeName("uint64_t")] ulong timeout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSignalSemaphoreKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreSignalInfo *")] VkSemaphoreSignalInfo* pSignalInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceFragmentShadingRatesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pFragmentShadingRateCount, VkPhysicalDeviceFragmentShadingRateKHR* pFragmentShadingRates);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetFragmentShadingRateKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkExtent2D *")] VkExtent2D* pFragmentSize, [NativeTypeName("const VkFragmentShadingRateCombinerOpKHR[2]")] VkFragmentShadingRateCombinerOpKHR* combinerOps);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRenderingAttachmentLocationsKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingAttachmentLocationInfo *")] VkRenderingAttachmentLocationInfo* pLocationInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRenderingInputAttachmentIndicesKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingInputAttachmentIndexInfo *")] VkRenderingInputAttachmentIndexInfo* pInputAttachmentIndexInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWaitForPresentKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("uint64_t")] ulong presentId, [NativeTypeName("uint64_t")] ulong timeout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceAddress")]
        public static extern ulong vkGetBufferDeviceAddressKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferDeviceAddressInfo *")] VkBufferDeviceAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong vkGetBufferOpaqueCaptureAddressKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferDeviceAddressInfo *")] VkBufferDeviceAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong vkGetDeviceMemoryOpaqueCaptureAddressKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceMemoryOpaqueCaptureAddressInfo *")] VkDeviceMemoryOpaqueCaptureAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDeferredOperationKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDeferredOperationKHR *")] VkDeferredOperationKHR_T** pDeferredOperation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDeferredOperationKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* operation, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint vkGetDeferredOperationMaxConcurrencyKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* operation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeferredOperationResultKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* operation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkDeferredOperationJoinKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* operation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineExecutablePropertiesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineInfoKHR *")] VkPipelineInfoKHR* pPipelineInfo, [NativeTypeName("uint32_t *")] uint* pExecutableCount, VkPipelineExecutablePropertiesKHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineExecutableStatisticsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineExecutableInfoKHR *")] VkPipelineExecutableInfoKHR* pExecutableInfo, [NativeTypeName("uint32_t *")] uint* pStatisticCount, VkPipelineExecutableStatisticKHR* pStatistics);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineExecutableInternalRepresentationsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineExecutableInfoKHR *")] VkPipelineExecutableInfoKHR* pExecutableInfo, [NativeTypeName("uint32_t *")] uint* pInternalRepresentationCount, VkPipelineExecutableInternalRepresentationKHR* pInternalRepresentations);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkMapMemory2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryMapInfo *")] VkMemoryMapInfo* pMemoryMapInfo, void** ppData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkUnmapMemory2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryUnmapInfo *")] VkMemoryUnmapInfo* pMemoryUnmapInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceVideoEncodeQualityLevelPropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR *")] VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR* pQualityLevelInfo, VkVideoEncodeQualityLevelPropertiesKHR* pQualityLevelProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetEncodedVideoSessionParametersKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkVideoEncodeSessionParametersGetInfoKHR *")] VkVideoEncodeSessionParametersGetInfoKHR* pVideoSessionParametersInfo, VkVideoEncodeSessionParametersFeedbackInfoKHR* pFeedbackInfo, [NativeTypeName("size_t *")] nuint* pDataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEncodeVideoKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkVideoEncodeInfoKHR *")] VkVideoEncodeInfoKHR* pEncodeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetEvent2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResetEvent2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkEvent")] VkEvent_T* @event, [NativeTypeName("VkPipelineStageFlags2")] ulong stageMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWaitEvents2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint eventCount, [NativeTypeName("const VkEvent *")] VkEvent_T** pEvents, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPipelineBarrier2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDependencyInfo *")] VkDependencyInfo* pDependencyInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteTimestamp2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkPipelineStageFlags2")] ulong stage, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueSubmit2KHR([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t")] uint submitCount, [NativeTypeName("const VkSubmitInfo2 *")] VkSubmitInfo2* pSubmits, [NativeTypeName("VkFence")] VkFence_T* fence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBuffer2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyBufferInfo2 *")] VkCopyBufferInfo2* pCopyBufferInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImage2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyImageInfo2 *")] VkCopyImageInfo2* pCopyImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyBufferToImage2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyBufferToImageInfo2 *")] VkCopyBufferToImageInfo2* pCopyBufferToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyImageToBuffer2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyImageToBufferInfo2 *")] VkCopyImageToBufferInfo2* pCopyImageToBufferInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBlitImage2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBlitImageInfo2 *")] VkBlitImageInfo2* pBlitImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdResolveImage2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkResolveImageInfo2 *")] VkResolveImageInfo2* pResolveImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdTraceRaysIndirect2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDeviceAddress")] ulong indirectDeviceAddress);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceBufferMemoryRequirementsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceBufferMemoryRequirements *")] VkDeviceBufferMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageMemoryRequirementsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageMemoryRequirements *")] VkDeviceImageMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageSparseMemoryRequirementsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageMemoryRequirements *")] VkDeviceImageMemoryRequirements* pInfo, [NativeTypeName("uint32_t *")] uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindIndexBuffer2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkDeviceSize")] ulong size, VkIndexType indexType);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetRenderingAreaGranularityKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderingAreaInfo *")] VkRenderingAreaInfo* pRenderingAreaInfo, VkExtent2D* pGranularity);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceImageSubresourceLayoutKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceImageSubresourceInfo *")] VkDeviceImageSubresourceInfo* pInfo, VkSubresourceLayout2* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSubresourceLayout2KHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("const VkImageSubresource2 *")] VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreatePipelineBinariesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineBinaryCreateInfoKHR *")] VkPipelineBinaryCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, VkPipelineBinaryHandlesInfoKHR* pBinaries);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPipelineBinaryKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineBinaryKHR")] VkPipelineBinaryKHR_T* pipelineBinary, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineKeyKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineCreateInfoKHR *")] VkPipelineCreateInfoKHR* pPipelineCreateInfo, VkPipelineBinaryKeyKHR* pPipelineKey);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelineBinaryDataKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineBinaryDataInfoKHR *")] VkPipelineBinaryDataInfoKHR* pInfo, VkPipelineBinaryKeyKHR* pPipelineBinaryKey, [NativeTypeName("size_t *")] nuint* pPipelineBinaryDataSize, void* pPipelineBinaryData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkReleaseCapturedPipelineDataKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkReleaseCapturedPipelineDataInfoKHR *")] VkReleaseCapturedPipelineDataInfoKHR* pInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkCooperativeMatrixPropertiesKHR* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineStippleKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint lineStippleFactor, [NativeTypeName("uint16_t")] ushort lineStipplePattern);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pTimeDomainCount, VkTimeDomainKHR* pTimeDomains);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetCalibratedTimestampsKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint timestampCount, [NativeTypeName("const VkCalibratedTimestampInfoKHR *")] VkCalibratedTimestampInfoKHR* pTimestampInfos, [NativeTypeName("uint64_t *")] ulong* pTimestamps, [NativeTypeName("uint64_t *")] ulong* pMaxDeviation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorSets2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBindDescriptorSetsInfo *")] VkBindDescriptorSetsInfo* pBindDescriptorSetsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushConstants2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushConstantsInfo *")] VkPushConstantsInfo* pPushConstantsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSet2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushDescriptorSetInfo *")] VkPushDescriptorSetInfo* pPushDescriptorSetInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPushDescriptorSetWithTemplate2KHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPushDescriptorSetWithTemplateInfo *")] VkPushDescriptorSetWithTemplateInfo* pPushDescriptorSetWithTemplateInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDescriptorBufferOffsets2EXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSetDescriptorBufferOffsetsInfoEXT *")] VkSetDescriptorBufferOffsetsInfoEXT* pSetDescriptorBufferOffsetsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorBufferEmbeddedSamplers2EXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBindDescriptorBufferEmbeddedSamplersInfoEXT *")] VkBindDescriptorBufferEmbeddedSamplersInfoEXT* pBindDescriptorBufferEmbeddedSamplersInfo);

        [NativeTypeName("const VkAccessFlagBits3KHR")]
        public const ulong VK_ACCESS_3_NONE_KHR = 0UL;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDebugReportCallbackEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkDebugReportCallbackCreateInfoEXT *")] VkDebugReportCallbackCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDebugReportCallbackEXT *")] VkDebugReportCallbackEXT_T** pCallback);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDebugReportCallbackEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("VkDebugReportCallbackEXT")] VkDebugReportCallbackEXT_T* callback, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDebugReportMessageEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("VkDebugReportFlagsEXT")] uint flags, VkDebugReportObjectTypeEXT objectType, [NativeTypeName("uint64_t")] ulong @object, [NativeTypeName("size_t")] nuint location, [NativeTypeName("int32_t")] int messageCode, [NativeTypeName("const char *")] sbyte* pLayerPrefix, [NativeTypeName("const char *")] sbyte* pMessage);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkDebugMarkerSetObjectTagEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDebugMarkerObjectTagInfoEXT *")] VkDebugMarkerObjectTagInfoEXT* pTagInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkDebugMarkerSetObjectNameEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDebugMarkerObjectNameInfoEXT *")] VkDebugMarkerObjectNameInfoEXT* pNameInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDebugMarkerBeginEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDebugMarkerMarkerInfoEXT *")] VkDebugMarkerMarkerInfoEXT* pMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDebugMarkerEndEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDebugMarkerInsertEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDebugMarkerMarkerInfoEXT *")] VkDebugMarkerMarkerInfoEXT* pMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindTransformFeedbackBuffersEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstBinding, [NativeTypeName("uint32_t")] uint bindingCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pOffsets, [NativeTypeName("const VkDeviceSize *")] ulong* pSizes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginTransformFeedbackEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstCounterBuffer, [NativeTypeName("uint32_t")] uint counterBufferCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pCounterBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pCounterBufferOffsets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndTransformFeedbackEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstCounterBuffer, [NativeTypeName("uint32_t")] uint counterBufferCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pCounterBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pCounterBufferOffsets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginQueryIndexedEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query, [NativeTypeName("VkQueryControlFlags")] uint flags, [NativeTypeName("uint32_t")] uint index);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndQueryIndexedEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint query, [NativeTypeName("uint32_t")] uint index);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndirectByteCountEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstInstance, [NativeTypeName("VkBuffer")] VkBuffer_T* counterBuffer, [NativeTypeName("VkDeviceSize")] ulong counterBufferOffset, [NativeTypeName("uint32_t")] uint counterOffset, [NativeTypeName("uint32_t")] uint vertexStride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateCuModuleNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCuModuleCreateInfoNVX *")] VkCuModuleCreateInfoNVX* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkCuModuleNVX *")] VkCuModuleNVX_T** pModule);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateCuFunctionNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCuFunctionCreateInfoNVX *")] VkCuFunctionCreateInfoNVX* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkCuFunctionNVX *")] VkCuFunctionNVX_T** pFunction);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyCuModuleNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCuModuleNVX")] VkCuModuleNVX_T* module, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyCuFunctionNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCuFunctionNVX")] VkCuFunctionNVX_T* function, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCuLaunchKernelNVX([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCuLaunchInfoNVX *")] VkCuLaunchInfoNVX* pLaunchInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint vkGetImageViewHandleNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageViewHandleInfoNVX *")] VkImageViewHandleInfoNVX* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong vkGetImageViewHandle64NVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageViewHandleInfoNVX *")] VkImageViewHandleInfoNVX* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetImageViewAddressNVX([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImageView")] VkImageView_T* imageView, VkImageViewAddressPropertiesNVX* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndirectCountAMD([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawIndexedIndirectCountAMD([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetShaderInfoAMD([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, VkShaderStageFlagBits shaderStage, VkShaderInfoTypeAMD infoType, [NativeTypeName("size_t *")] nuint* pInfoSize, void* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, [NativeTypeName("VkImageUsageFlags")] uint usage, [NativeTypeName("VkImageCreateFlags")] uint flags, [NativeTypeName("VkExternalMemoryHandleTypeFlagsNV")] uint externalHandleType, VkExternalImageFormatPropertiesNV* pExternalImageFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginConditionalRenderingEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkConditionalRenderingBeginInfoEXT *")] VkConditionalRenderingBeginInfoEXT* pConditionalRenderingBegin);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndConditionalRenderingEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportWScalingNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstViewport, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkViewportWScalingNV *")] VkViewportWScalingNV* pViewportWScalings);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkReleaseDisplayEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkSurfaceKHR")] VkSurfaceKHR_T* surface, VkSurfaceCapabilities2EXT* pSurfaceCapabilities);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkDisplayPowerControlEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display, [NativeTypeName("const VkDisplayPowerInfoEXT *")] VkDisplayPowerInfoEXT* pDisplayPowerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkRegisterDeviceEventEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDeviceEventInfoEXT *")] VkDeviceEventInfoEXT* pDeviceEventInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkFence *")] VkFence_T** pFence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkRegisterDisplayEventEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display, [NativeTypeName("const VkDisplayEventInfoEXT *")] VkDisplayEventInfoEXT* pDisplayEventInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkFence *")] VkFence_T** pFence);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSwapchainCounterEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, VkSurfaceCounterFlagBitsEXT counter, [NativeTypeName("uint64_t *")] ulong* pCounterValue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetRefreshCycleDurationGOOGLE([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, VkRefreshCycleDurationGOOGLE* pDisplayTimingProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPastPresentationTimingGOOGLE([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("uint32_t *")] uint* pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDiscardRectangleEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstDiscardRectangle, [NativeTypeName("uint32_t")] uint discardRectangleCount, [NativeTypeName("const VkRect2D *")] VkRect2D* pDiscardRectangles);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDiscardRectangleEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint discardRectangleEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDiscardRectangleModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkDiscardRectangleModeEXT discardRectangleMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkSetHdrMetadataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint swapchainCount, [NativeTypeName("const VkSwapchainKHR *")] VkSwapchainKHR_T** pSwapchains, [NativeTypeName("const VkHdrMetadataEXT *")] VkHdrMetadataEXT* pMetadata);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetDebugUtilsObjectNameEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDebugUtilsObjectNameInfoEXT *")] VkDebugUtilsObjectNameInfoEXT* pNameInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetDebugUtilsObjectTagEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDebugUtilsObjectTagInfoEXT *")] VkDebugUtilsObjectTagInfoEXT* pTagInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkQueueBeginDebugUtilsLabelEXT([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("const VkDebugUtilsLabelEXT *")] VkDebugUtilsLabelEXT* pLabelInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkQueueEndDebugUtilsLabelEXT([NativeTypeName("VkQueue")] VkQueue_T* queue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkQueueInsertDebugUtilsLabelEXT([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("const VkDebugUtilsLabelEXT *")] VkDebugUtilsLabelEXT* pLabelInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginDebugUtilsLabelEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDebugUtilsLabelEXT *")] VkDebugUtilsLabelEXT* pLabelInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndDebugUtilsLabelEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdInsertDebugUtilsLabelEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDebugUtilsLabelEXT *")] VkDebugUtilsLabelEXT* pLabelInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateDebugUtilsMessengerEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkDebugUtilsMessengerCreateInfoEXT *")] VkDebugUtilsMessengerCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkDebugUtilsMessengerEXT *")] VkDebugUtilsMessengerEXT_T** pMessenger);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyDebugUtilsMessengerEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("VkDebugUtilsMessengerEXT")] VkDebugUtilsMessengerEXT_T* messenger, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkSubmitDebugUtilsMessageEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity, [NativeTypeName("VkDebugUtilsMessageTypeFlagsEXT")] uint messageTypes, [NativeTypeName("const VkDebugUtilsMessengerCallbackDataEXT *")] VkDebugUtilsMessengerCallbackDataEXT* pCallbackData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetSampleLocationsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkSampleLocationsInfoEXT *")] VkSampleLocationsInfoEXT* pSampleLocationsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPhysicalDeviceMultisamplePropertiesEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, VkSampleCountFlagBits samples, VkMultisamplePropertiesEXT* pMultisampleProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetImageDrmFormatModifierPropertiesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, VkImageDrmFormatModifierPropertiesEXT* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateValidationCacheEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkValidationCacheCreateInfoEXT *")] VkValidationCacheCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkValidationCacheEXT *")] VkValidationCacheEXT_T** pValidationCache);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyValidationCacheEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkValidationCacheEXT")] VkValidationCacheEXT_T* validationCache, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkMergeValidationCachesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkValidationCacheEXT")] VkValidationCacheEXT_T* dstCache, [NativeTypeName("uint32_t")] uint srcCacheCount, [NativeTypeName("const VkValidationCacheEXT *")] VkValidationCacheEXT_T** pSrcCaches);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetValidationCacheDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkValidationCacheEXT")] VkValidationCacheEXT_T* validationCache, [NativeTypeName("size_t *")] nuint* pDataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindShadingRateImageNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImageView")] VkImageView_T* imageView, VkImageLayout imageLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportShadingRatePaletteNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstViewport, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkShadingRatePaletteNV *")] VkShadingRatePaletteNV* pShadingRatePalettes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoarseSampleOrderNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkCoarseSampleOrderTypeNV sampleOrderType, [NativeTypeName("uint32_t")] uint customSampleOrderCount, [NativeTypeName("const VkCoarseSampleOrderCustomNV *")] VkCoarseSampleOrderCustomNV* pCustomSampleOrders);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateAccelerationStructureNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureCreateInfoNV *")] VkAccelerationStructureCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkAccelerationStructureNV *")] VkAccelerationStructureNV_T** pAccelerationStructure);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyAccelerationStructureNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* accelerationStructure, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetAccelerationStructureMemoryRequirementsNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureMemoryRequirementsInfoNV *")] VkAccelerationStructureMemoryRequirementsInfoNV* pInfo, [NativeTypeName("VkMemoryRequirements2KHR *")] VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindAccelerationStructureMemoryNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint bindInfoCount, [NativeTypeName("const VkBindAccelerationStructureMemoryInfoNV *")] VkBindAccelerationStructureMemoryInfoNV* pBindInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildAccelerationStructureNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkAccelerationStructureInfoNV *")] VkAccelerationStructureInfoNV* pInfo, [NativeTypeName("VkBuffer")] VkBuffer_T* instanceData, [NativeTypeName("VkDeviceSize")] ulong instanceOffset, [NativeTypeName("VkBool32")] uint update, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* dst, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* src, [NativeTypeName("VkBuffer")] VkBuffer_T* scratch, [NativeTypeName("VkDeviceSize")] ulong scratchOffset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyAccelerationStructureNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* dst, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* src, VkCopyAccelerationStructureModeKHR mode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdTraceRaysNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* raygenShaderBindingTableBuffer, [NativeTypeName("VkDeviceSize")] ulong raygenShaderBindingOffset, [NativeTypeName("VkBuffer")] VkBuffer_T* missShaderBindingTableBuffer, [NativeTypeName("VkDeviceSize")] ulong missShaderBindingOffset, [NativeTypeName("VkDeviceSize")] ulong missShaderBindingStride, [NativeTypeName("VkBuffer")] VkBuffer_T* hitShaderBindingTableBuffer, [NativeTypeName("VkDeviceSize")] ulong hitShaderBindingOffset, [NativeTypeName("VkDeviceSize")] ulong hitShaderBindingStride, [NativeTypeName("VkBuffer")] VkBuffer_T* callableShaderBindingTableBuffer, [NativeTypeName("VkDeviceSize")] ulong callableShaderBindingOffset, [NativeTypeName("VkDeviceSize")] ulong callableShaderBindingStride, [NativeTypeName("uint32_t")] uint width, [NativeTypeName("uint32_t")] uint height, [NativeTypeName("uint32_t")] uint depth);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateRayTracingPipelinesNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("uint32_t")] uint createInfoCount, [NativeTypeName("const VkRayTracingPipelineCreateInfoNV *")] VkRayTracingPipelineCreateInfoNV* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipeline *")] VkPipeline_T** pPipelines);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetRayTracingShaderGroupHandlesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint firstGroup, [NativeTypeName("uint32_t")] uint groupCount, [NativeTypeName("size_t")] nuint dataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetRayTracingShaderGroupHandlesNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint firstGroup, [NativeTypeName("uint32_t")] uint groupCount, [NativeTypeName("size_t")] nuint dataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetAccelerationStructureHandleNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkAccelerationStructureNV")] VkAccelerationStructureNV_T* accelerationStructure, [NativeTypeName("size_t")] nuint dataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteAccelerationStructuresPropertiesNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint accelerationStructureCount, [NativeTypeName("const VkAccelerationStructureNV *")] VkAccelerationStructureNV_T** pAccelerationStructures, VkQueryType queryType, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCompileDeferredNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint shader);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryHostPointerPropertiesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, VkExternalMemoryHandleTypeFlagBits handleType, [NativeTypeName("const void *")] void* pHostPointer, VkMemoryHostPointerPropertiesEXT* pMemoryHostPointerProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteBufferMarkerAMD([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineStageFlagBits pipelineStage, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("VkDeviceSize")] ulong dstOffset, [NativeTypeName("uint32_t")] uint marker);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteBufferMarker2AMD([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkPipelineStageFlags2")] ulong stage, [NativeTypeName("VkBuffer")] VkBuffer_T* dstBuffer, [NativeTypeName("VkDeviceSize")] ulong dstOffset, [NativeTypeName("uint32_t")] uint marker);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pTimeDomainCount, VkTimeDomainKHR* pTimeDomains);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetCalibratedTimestampsEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint timestampCount, [NativeTypeName("const VkCalibratedTimestampInfoKHR *")] VkCalibratedTimestampInfoKHR* pTimestampInfos, [NativeTypeName("uint64_t *")] ulong* pTimestamps, [NativeTypeName("uint64_t *")] ulong* pMaxDeviation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint taskCount, [NativeTypeName("uint32_t")] uint firstTask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksIndirectNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksIndirectCountNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetExclusiveScissorEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstExclusiveScissor, [NativeTypeName("uint32_t")] uint exclusiveScissorCount, [NativeTypeName("const VkBool32 *")] uint* pExclusiveScissorEnables);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetExclusiveScissorNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstExclusiveScissor, [NativeTypeName("uint32_t")] uint exclusiveScissorCount, [NativeTypeName("const VkRect2D *")] VkRect2D* pExclusiveScissors);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCheckpointNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const void *")] void* pCheckpointMarker);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetQueueCheckpointDataNV([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t *")] uint* pCheckpointDataCount, VkCheckpointDataNV* pCheckpointData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetQueueCheckpointData2NV([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("uint32_t *")] uint* pCheckpointDataCount, VkCheckpointData2NV* pCheckpointData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkInitializePerformanceApiINTEL([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkInitializePerformanceApiInfoINTEL *")] VkInitializePerformanceApiInfoINTEL* pInitializeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUninitializePerformanceApiINTEL([NativeTypeName("VkDevice")] VkDevice_T* device);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCmdSetPerformanceMarkerINTEL([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPerformanceMarkerInfoINTEL *")] VkPerformanceMarkerInfoINTEL* pMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCmdSetPerformanceStreamMarkerINTEL([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPerformanceStreamMarkerInfoINTEL *")] VkPerformanceStreamMarkerInfoINTEL* pMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCmdSetPerformanceOverrideINTEL([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPerformanceOverrideInfoINTEL *")] VkPerformanceOverrideInfoINTEL* pOverrideInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquirePerformanceConfigurationINTEL([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPerformanceConfigurationAcquireInfoINTEL *")] VkPerformanceConfigurationAcquireInfoINTEL* pAcquireInfo, [NativeTypeName("VkPerformanceConfigurationINTEL *")] VkPerformanceConfigurationINTEL_T** pConfiguration);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkReleasePerformanceConfigurationINTEL([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPerformanceConfigurationINTEL")] VkPerformanceConfigurationINTEL_T* configuration);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkQueueSetPerformanceConfigurationINTEL([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("VkPerformanceConfigurationINTEL")] VkPerformanceConfigurationINTEL_T* configuration);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPerformanceParameterINTEL([NativeTypeName("VkDevice")] VkDevice_T* device, VkPerformanceParameterTypeINTEL parameter, VkPerformanceValueINTEL* pValue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkSetLocalDimmingAMD([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapChain, [NativeTypeName("VkBool32")] uint localDimmingEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceAddress")]
        public static extern ulong vkGetBufferDeviceAddressEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferDeviceAddressInfo *")] VkBufferDeviceAddressInfo* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceToolPropertiesEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pToolCount, VkPhysicalDeviceToolProperties* pToolProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkCooperativeMatrixPropertiesNV* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pCombinationCount, VkFramebufferMixedSamplesCombinationNV* pCombinations);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateHeadlessSurfaceEXT([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkHeadlessSurfaceCreateInfoEXT *")] VkHeadlessSurfaceCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** pSurface);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineStippleEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint lineStippleFactor, [NativeTypeName("uint16_t")] ushort lineStipplePattern);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkResetQueryPoolEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery, [NativeTypeName("uint32_t")] uint queryCount);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCullModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkCullModeFlags")] uint cullMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetFrontFaceEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkFrontFace frontFace);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPrimitiveTopologyEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPrimitiveTopology primitiveTopology);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportWithCountEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkViewport *")] VkViewport* pViewports);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetScissorWithCountEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint scissorCount, [NativeTypeName("const VkRect2D *")] VkRect2D* pScissors);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindVertexBuffers2EXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstBinding, [NativeTypeName("uint32_t")] uint bindingCount, [NativeTypeName("const VkBuffer *")] VkBuffer_T** pBuffers, [NativeTypeName("const VkDeviceSize *")] ulong* pOffsets, [NativeTypeName("const VkDeviceSize *")] ulong* pSizes, [NativeTypeName("const VkDeviceSize *")] ulong* pStrides);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthTestEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthWriteEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthWriteEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthCompareOpEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkCompareOp depthCompareOp);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBoundsTestEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthBoundsTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilTestEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint stencilTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetStencilOpEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkStencilFaceFlags")] uint faceMask, VkStencilOp failOp, VkStencilOp passOp, VkStencilOp depthFailOp, VkCompareOp compareOp);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMemoryToImageEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyMemoryToImageInfo *")] VkCopyMemoryToImageInfo* pCopyMemoryToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyImageToMemoryEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyImageToMemoryInfo *")] VkCopyImageToMemoryInfo* pCopyImageToMemoryInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyImageToImageEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCopyImageToImageInfo *")] VkCopyImageToImageInfo* pCopyImageToImageInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkTransitionImageLayoutEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint transitionCount, [NativeTypeName("const VkHostImageLayoutTransitionInfo *")] VkHostImageLayoutTransitionInfo* pTransitions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetImageSubresourceLayout2EXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkImage")] VkImage_T* image, [NativeTypeName("const VkImageSubresource2 *")] VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkReleaseSwapchainImagesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkReleaseSwapchainImagesInfoEXT *")] VkReleaseSwapchainImagesInfoEXT* pReleaseInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetGeneratedCommandsMemoryRequirementsNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkGeneratedCommandsMemoryRequirementsInfoNV *")] VkGeneratedCommandsMemoryRequirementsInfoNV* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPreprocessGeneratedCommandsNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkGeneratedCommandsInfoNV *")] VkGeneratedCommandsInfoNV* pGeneratedCommandsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdExecuteGeneratedCommandsNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint isPreprocessed, [NativeTypeName("const VkGeneratedCommandsInfoNV *")] VkGeneratedCommandsInfoNV* pGeneratedCommandsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindPipelineShaderGroupNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint groupIndex);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateIndirectCommandsLayoutNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkIndirectCommandsLayoutCreateInfoNV *")] VkIndirectCommandsLayoutCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkIndirectCommandsLayoutNV *")] VkIndirectCommandsLayoutNV_T** pIndirectCommandsLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyIndirectCommandsLayoutNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkIndirectCommandsLayoutNV")] VkIndirectCommandsLayoutNV_T* indirectCommandsLayout, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBias2EXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkDepthBiasInfoEXT *")] VkDepthBiasInfoEXT* pDepthBiasInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireDrmDisplayEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("int32_t")] int drmFd, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDrmDisplayEXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("int32_t")] int drmFd, [NativeTypeName("uint32_t")] uint connectorId, [NativeTypeName("VkDisplayKHR *")] VkDisplayKHR_T** display);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreatePrivateDataSlotEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPrivateDataSlotCreateInfo *")] VkPrivateDataSlotCreateInfo* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPrivateDataSlot *")] VkPrivateDataSlot_T** pPrivateDataSlot);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyPrivateDataSlotEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetPrivateDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, VkObjectType objectType, [NativeTypeName("uint64_t")] ulong objectHandle, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("uint64_t")] ulong data);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPrivateDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, VkObjectType objectType, [NativeTypeName("uint64_t")] ulong objectHandle, [NativeTypeName("VkPrivateDataSlot")] VkPrivateDataSlot_T* privateDataSlot, [NativeTypeName("uint64_t *")] ulong* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateCudaModuleNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCudaModuleCreateInfoNV *")] VkCudaModuleCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkCudaModuleNV *")] VkCudaModuleNV_T** pModule);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetCudaModuleCacheNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCudaModuleNV")] VkCudaModuleNV_T* module, [NativeTypeName("size_t *")] nuint* pCacheSize, void* pCacheData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateCudaFunctionNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkCudaFunctionCreateInfoNV *")] VkCudaFunctionCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkCudaFunctionNV *")] VkCudaFunctionNV_T** pFunction);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyCudaModuleNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCudaModuleNV")] VkCudaModuleNV_T* module, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyCudaFunctionNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkCudaFunctionNV")] VkCudaFunctionNV_T* function, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCudaLaunchKernelNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCudaLaunchInfoNV *")] VkCudaLaunchInfoNV* pLaunchInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDispatchTileQCOM([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBeginPerTileExecutionQCOM([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPerTileBeginInfoQCOM *")] VkPerTileBeginInfoQCOM* pPerTileBeginInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndPerTileExecutionQCOM([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkPerTileEndInfoQCOM *")] VkPerTileEndInfoQCOM* pPerTileEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetLayoutSizeEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSetLayout")] VkDescriptorSetLayout_T* layout, [NativeTypeName("VkDeviceSize *")] ulong* pLayoutSizeInBytes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetLayoutBindingOffsetEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSetLayout")] VkDescriptorSetLayout_T* layout, [NativeTypeName("uint32_t")] uint binding, [NativeTypeName("VkDeviceSize *")] ulong* pOffset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorGetInfoEXT *")] VkDescriptorGetInfoEXT* pDescriptorInfo, [NativeTypeName("size_t")] nuint dataSize, void* pDescriptor);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorBuffersEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint bufferCount, [NativeTypeName("const VkDescriptorBufferBindingInfoEXT *")] VkDescriptorBufferBindingInfoEXT* pBindingInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDescriptorBufferOffsetsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint firstSet, [NativeTypeName("uint32_t")] uint setCount, [NativeTypeName("const uint32_t *")] uint* pBufferIndices, [NativeTypeName("const VkDeviceSize *")] ulong* pOffsets);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindDescriptorBufferEmbeddedSamplersEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipelineLayout")] VkPipelineLayout_T* layout, [NativeTypeName("uint32_t")] uint set);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetBufferOpaqueCaptureDescriptorDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkBufferCaptureDescriptorDataInfoEXT *")] VkBufferCaptureDescriptorDataInfoEXT* pInfo, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetImageOpaqueCaptureDescriptorDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageCaptureDescriptorDataInfoEXT *")] VkImageCaptureDescriptorDataInfoEXT* pInfo, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetImageViewOpaqueCaptureDescriptorDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImageViewCaptureDescriptorDataInfoEXT *")] VkImageViewCaptureDescriptorDataInfoEXT* pInfo, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSamplerOpaqueCaptureDescriptorDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSamplerCaptureDescriptorDataInfoEXT *")] VkSamplerCaptureDescriptorDataInfoEXT* pInfo, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureCaptureDescriptorDataInfoEXT *")] VkAccelerationStructureCaptureDescriptorDataInfoEXT* pInfo, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetFragmentShadingRateEnumNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkFragmentShadingRateNV shadingRate, [NativeTypeName("const VkFragmentShadingRateCombinerOpKHR[2]")] VkFragmentShadingRateCombinerOpKHR* combinerOps);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeviceFaultInfoEXT([NativeTypeName("VkDevice")] VkDevice_T* device, VkDeviceFaultCountsEXT* pFaultCounts, VkDeviceFaultInfoEXT* pFaultInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetVertexInputEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint vertexBindingDescriptionCount, [NativeTypeName("const VkVertexInputBindingDescription2EXT *")] VkVertexInputBindingDescription2EXT* pVertexBindingDescriptions, [NativeTypeName("uint32_t")] uint vertexAttributeDescriptionCount, [NativeTypeName("const VkVertexInputAttributeDescription2EXT *")] VkVertexInputAttributeDescription2EXT* pVertexAttributeDescriptions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkRenderPass")] VkRenderPass_T* renderpass, VkExtent2D* pMaxWorkgroupSize);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSubpassShadingHUAWEI([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindInvocationMaskHUAWEI([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImageView")] VkImageView_T* imageView, VkImageLayout imageLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryRemoteAddressNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryGetRemoteAddressInfoNV *")] VkMemoryGetRemoteAddressInfoNV* pMemoryGetRemoteAddressInfo, [NativeTypeName("VkRemoteAddressNV *")] void** pAddress);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPipelinePropertiesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineInfoEXT *")] VkPipelineInfoKHR* pPipelineInfo, VkBaseOutStructure* pPipelineProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPatchControlPointsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint patchControlPoints);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRasterizerDiscardEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint rasterizerDiscardEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthBiasEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthBiasEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLogicOpEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkLogicOp logicOp);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPrimitiveRestartEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint primitiveRestartEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetColorWriteEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkBool32 *")] uint* pColorWriteEnables);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMultiEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("const VkMultiDrawInfoEXT *")] VkMultiDrawInfoEXT* pVertexInfo, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstInstance, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMultiIndexedEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("const VkMultiDrawIndexedInfoEXT *")] VkMultiDrawIndexedInfoEXT* pIndexInfo, [NativeTypeName("uint32_t")] uint instanceCount, [NativeTypeName("uint32_t")] uint firstInstance, [NativeTypeName("uint32_t")] uint stride, [NativeTypeName("const int32_t *")] int* pVertexOffset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateMicromapEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMicromapCreateInfoEXT *")] VkMicromapCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkMicromapEXT *")] VkMicromapEXT_T** pMicromap);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyMicromapEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkMicromapEXT")] VkMicromapEXT_T* micromap, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildMicromapsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkMicromapBuildInfoEXT *")] VkMicromapBuildInfoEXT* pInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBuildMicromapsEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkMicromapBuildInfoEXT *")] VkMicromapBuildInfoEXT* pInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMicromapEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyMicromapInfoEXT *")] VkCopyMicromapInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMicromapToMemoryEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyMicromapToMemoryInfoEXT *")] VkCopyMicromapToMemoryInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMemoryToMicromapEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyMemoryToMicromapInfoEXT *")] VkCopyMemoryToMicromapInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWriteMicromapsPropertiesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint micromapCount, [NativeTypeName("const VkMicromapEXT *")] VkMicromapEXT_T** pMicromaps, VkQueryType queryType, [NativeTypeName("size_t")] nuint dataSize, void* pData, [NativeTypeName("size_t")] nuint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMicromapEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyMicromapInfoEXT *")] VkCopyMicromapInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMicromapToMemoryEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyMicromapToMemoryInfoEXT *")] VkCopyMicromapToMemoryInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMemoryToMicromapEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyMemoryToMicromapInfoEXT *")] VkCopyMemoryToMicromapInfoEXT* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteMicromapsPropertiesEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint micromapCount, [NativeTypeName("const VkMicromapEXT *")] VkMicromapEXT_T** pMicromaps, VkQueryType queryType, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceMicromapCompatibilityEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMicromapVersionInfoEXT *")] VkMicromapVersionInfoEXT* pVersionInfo, VkAccelerationStructureCompatibilityKHR* pCompatibility);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetMicromapBuildSizesEXT([NativeTypeName("VkDevice")] VkDevice_T* device, VkAccelerationStructureBuildTypeKHR buildType, [NativeTypeName("const VkMicromapBuildInfoEXT *")] VkMicromapBuildInfoEXT* pBuildInfo, VkMicromapBuildSizesInfoEXT* pSizeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawClusterHUAWEI([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint groupCountX, [NativeTypeName("uint32_t")] uint groupCountY, [NativeTypeName("uint32_t")] uint groupCountZ);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawClusterIndirectHUAWEI([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkSetDeviceMemoryPriorityEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, float priority);

        [NativeTypeName("const VkPhysicalDeviceSchedulingControlsFlagBitsARM")]
        public const ulong VK_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_SHADER_CORE_COUNT_ARM = 0x00000001UL;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetLayoutHostMappingInfoVALVE([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkDescriptorSetBindingReferenceVALVE *")] VkDescriptorSetBindingReferenceVALVE* pBindingReference, VkDescriptorSetLayoutHostMappingInfoVALVE* pHostMapping);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDescriptorSetHostMappingVALVE([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDescriptorSet")] VkDescriptorSet_T* descriptorSet, void** ppData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMemoryIndirectNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDeviceAddress")] ulong copyBufferAddress, [NativeTypeName("uint32_t")] uint copyCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMemoryToImageIndirectNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDeviceAddress")] ulong copyBufferAddress, [NativeTypeName("uint32_t")] uint copyCount, [NativeTypeName("uint32_t")] uint stride, [NativeTypeName("VkImage")] VkImage_T* dstImage, VkImageLayout dstImageLayout, [NativeTypeName("const VkImageSubresourceLayers *")] VkImageSubresourceLayers* pImageSubresources);

        [NativeTypeName("const VkMemoryDecompressionMethodFlagBitsNV")]
        public const ulong VK_MEMORY_DECOMPRESSION_METHOD_GDEFLATE_1_0_BIT_NV = 0x00000001UL;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDecompressMemoryNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint decompressRegionCount, [NativeTypeName("const VkDecompressMemoryRegionNV *")] VkDecompressMemoryRegionNV* pDecompressMemoryRegions);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDecompressMemoryIndirectCountNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkDeviceAddress")] ulong indirectCommandsAddress, [NativeTypeName("VkDeviceAddress")] ulong indirectCommandsCountAddress, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPipelineIndirectMemoryRequirementsNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkComputePipelineCreateInfo *")] VkComputePipelineCreateInfo* pCreateInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdUpdatePipelineIndirectBufferNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPipelineBindPoint pipelineBindPoint, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceAddress")]
        public static extern ulong vkGetPipelineIndirectDeviceAddressNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPipelineIndirectDeviceAddressInfoNV *")] VkPipelineIndirectDeviceAddressInfoNV* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthClampEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthClampEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetPolygonModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkPolygonMode polygonMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRasterizationSamplesEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkSampleCountFlagBits rasterizationSamples);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetSampleMaskEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkSampleCountFlagBits samples, [NativeTypeName("const VkSampleMask *")] uint* pSampleMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetAlphaToCoverageEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint alphaToCoverageEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetAlphaToOneEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint alphaToOneEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLogicOpEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint logicOpEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetColorBlendEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstAttachment, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkBool32 *")] uint* pColorBlendEnables);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetColorBlendEquationEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstAttachment, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkColorBlendEquationEXT *")] VkColorBlendEquationEXT* pColorBlendEquations);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetColorWriteMaskEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstAttachment, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkColorComponentFlags *")] uint* pColorWriteMasks);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetTessellationDomainOriginEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkTessellationDomainOrigin domainOrigin);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRasterizationStreamEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint rasterizationStream);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetConservativeRasterizationModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkConservativeRasterizationModeEXT conservativeRasterizationMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetExtraPrimitiveOverestimationSizeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, float extraPrimitiveOverestimationSize);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthClipEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint depthClipEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetSampleLocationsEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint sampleLocationsEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetColorBlendAdvancedEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstAttachment, [NativeTypeName("uint32_t")] uint attachmentCount, [NativeTypeName("const VkColorBlendAdvancedEXT *")] VkColorBlendAdvancedEXT* pColorBlendAdvanced);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetProvokingVertexModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkProvokingVertexModeEXT provokingVertexMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineRasterizationModeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkLineRasterizationModeEXT")] VkLineRasterizationMode lineRasterizationMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetLineStippleEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint stippledLineEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthClipNegativeOneToOneEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint negativeOneToOne);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportWScalingEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint viewportWScalingEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetViewportSwizzleNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint firstViewport, [NativeTypeName("uint32_t")] uint viewportCount, [NativeTypeName("const VkViewportSwizzleNV *")] VkViewportSwizzleNV* pViewportSwizzles);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageToColorEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint coverageToColorEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageToColorLocationNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint coverageToColorLocation);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageModulationModeNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkCoverageModulationModeNV coverageModulationMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageModulationTableEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint coverageModulationTableEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageModulationTableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint coverageModulationTableCount, [NativeTypeName("const float *")] float* pCoverageModulationTable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetShadingRateImageEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint shadingRateImageEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRepresentativeFragmentTestEnableNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint representativeFragmentTestEnable);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetCoverageReductionModeNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkCoverageReductionModeNV coverageReductionMode);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetShaderModuleIdentifierEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkShaderModule")] VkShaderModule_T* shaderModule, VkShaderModuleIdentifierEXT* pIdentifier);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetShaderModuleCreateInfoIdentifierEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkShaderModuleCreateInfo *")] VkShaderModuleCreateInfo* pCreateInfo, VkShaderModuleIdentifierEXT* pIdentifier);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceOpticalFlowImageFormatsNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkOpticalFlowImageFormatInfoNV *")] VkOpticalFlowImageFormatInfoNV* pOpticalFlowImageFormatInfo, [NativeTypeName("uint32_t *")] uint* pFormatCount, VkOpticalFlowImageFormatPropertiesNV* pImageFormatProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateOpticalFlowSessionNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkOpticalFlowSessionCreateInfoNV *")] VkOpticalFlowSessionCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkOpticalFlowSessionNV *")] VkOpticalFlowSessionNV_T** pSession);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyOpticalFlowSessionNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkOpticalFlowSessionNV")] VkOpticalFlowSessionNV_T* session, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBindOpticalFlowSessionImageNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkOpticalFlowSessionNV")] VkOpticalFlowSessionNV_T* session, VkOpticalFlowSessionBindingPointNV bindingPoint, [NativeTypeName("VkImageView")] VkImageView_T* view, VkImageLayout layout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdOpticalFlowExecuteNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkOpticalFlowSessionNV")] VkOpticalFlowSessionNV_T* session, [NativeTypeName("const VkOpticalFlowExecuteInfoNV *")] VkOpticalFlowExecuteInfoNV* pExecuteInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkAntiLagUpdateAMD([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAntiLagDataAMD *")] VkAntiLagDataAMD* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateShadersEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint createInfoCount, [NativeTypeName("const VkShaderCreateInfoEXT *")] VkShaderCreateInfoEXT* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkShaderEXT *")] VkShaderEXT_T** pShaders);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyShaderEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkShaderEXT")] VkShaderEXT_T* shader, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetShaderBinaryDataEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkShaderEXT")] VkShaderEXT_T* shader, [NativeTypeName("size_t *")] nuint* pDataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindShadersEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint stageCount, [NativeTypeName("const VkShaderStageFlagBits *")] VkShaderStageFlagBits* pStages, [NativeTypeName("const VkShaderEXT *")] VkShaderEXT_T** pShaders);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetDepthClampRangeEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, VkDepthClampModeEXT depthClampMode, [NativeTypeName("const VkDepthClampRangeEXT *")] VkDepthClampRangeEXT* pDepthClampRange);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetFramebufferTilePropertiesQCOM([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkFramebuffer")] VkFramebuffer_T* framebuffer, [NativeTypeName("uint32_t *")] uint* pPropertiesCount, VkTilePropertiesQCOM* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDynamicRenderingTilePropertiesQCOM([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkRenderingInfo *")] VkRenderingInfo* pRenderingInfo, VkTilePropertiesQCOM* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCooperativeVectorPropertiesNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkCooperativeVectorPropertiesNV* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkConvertCooperativeVectorMatrixNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkConvertCooperativeVectorMatrixInfoNV *")] VkConvertCooperativeVectorMatrixInfoNV* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdConvertCooperativeVectorMatrixNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkConvertCooperativeVectorMatrixInfoNV *")] VkConvertCooperativeVectorMatrixInfoNV* pInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkSetLatencySleepModeNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("const VkLatencySleepModeInfoNV *")] VkLatencySleepModeInfoNV* pSleepModeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkLatencySleepNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("const VkLatencySleepInfoNV *")] VkLatencySleepInfoNV* pSleepInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkSetLatencyMarkerNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, [NativeTypeName("const VkSetLatencyMarkerInfoNV *")] VkSetLatencyMarkerInfoNV* pLatencyMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetLatencyTimingsNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain, VkGetLatencyMarkerInfoNV* pLatencyMarkerInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkQueueNotifyOutOfBandNV([NativeTypeName("VkQueue")] VkQueue_T* queue, [NativeTypeName("const VkOutOfBandQueueTypeInfoNV *")] VkOutOfBandQueueTypeInfoNV* pQueueTypeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetAttachmentFeedbackLoopEnableEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkImageAspectFlags")] uint aspectMask);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBindTileMemoryQCOM([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkTileMemoryBindInfoQCOM *")] VkTileMemoryBindInfoQCOM* pTileMemoryBindInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateExternalComputeQueueNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkExternalComputeQueueCreateInfoNV *")] VkExternalComputeQueueCreateInfoNV* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkExternalComputeQueueNV *")] VkExternalComputeQueueNV_T** pExternalQueue);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyExternalComputeQueueNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkExternalComputeQueueNV")] VkExternalComputeQueueNV_T* externalQueue, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetExternalComputeQueueDataNV([NativeTypeName("VkExternalComputeQueueNV")] VkExternalComputeQueueNV_T* externalQueue, VkExternalComputeQueueDataParamsNV* @params, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetClusterAccelerationStructureBuildSizesNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkClusterAccelerationStructureInputInfoNV *")] VkClusterAccelerationStructureInputInfoNV* pInfo, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildClusterAccelerationStructureIndirectNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkClusterAccelerationStructureCommandsInfoNV *")] VkClusterAccelerationStructureCommandsInfoNV* pCommandInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetPartitionedAccelerationStructuresBuildSizesNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPartitionedAccelerationStructureInstancesInputNV *")] VkPartitionedAccelerationStructureInstancesInputNV* pInfo, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildPartitionedAccelerationStructuresNV([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkBuildPartitionedAccelerationStructureInfoNV *")] VkBuildPartitionedAccelerationStructureInfoNV* pBuildInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetGeneratedCommandsMemoryRequirementsEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkGeneratedCommandsMemoryRequirementsInfoEXT *")] VkGeneratedCommandsMemoryRequirementsInfoEXT* pInfo, VkMemoryRequirements2* pMemoryRequirements);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdPreprocessGeneratedCommandsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkGeneratedCommandsInfoEXT *")] VkGeneratedCommandsInfoEXT* pGeneratedCommandsInfo, [NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* stateCommandBuffer);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdExecuteGeneratedCommandsEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBool32")] uint isPreprocessed, [NativeTypeName("const VkGeneratedCommandsInfoEXT *")] VkGeneratedCommandsInfoEXT* pGeneratedCommandsInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateIndirectCommandsLayoutEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkIndirectCommandsLayoutCreateInfoEXT *")] VkIndirectCommandsLayoutCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkIndirectCommandsLayoutEXT *")] VkIndirectCommandsLayoutEXT_T** pIndirectCommandsLayout);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyIndirectCommandsLayoutEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkIndirectCommandsLayoutEXT")] VkIndirectCommandsLayoutEXT_T* indirectCommandsLayout, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateIndirectExecutionSetEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkIndirectExecutionSetCreateInfoEXT *")] VkIndirectExecutionSetCreateInfoEXT* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkIndirectExecutionSetEXT *")] VkIndirectExecutionSetEXT_T** pIndirectExecutionSet);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyIndirectExecutionSetEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkIndirectExecutionSetEXT")] VkIndirectExecutionSetEXT_T* indirectExecutionSet, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUpdateIndirectExecutionSetPipelineEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkIndirectExecutionSetEXT")] VkIndirectExecutionSetEXT_T* indirectExecutionSet, [NativeTypeName("uint32_t")] uint executionSetWriteCount, [NativeTypeName("const VkWriteIndirectExecutionSetPipelineEXT *")] VkWriteIndirectExecutionSetPipelineEXT* pExecutionSetWrites);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkUpdateIndirectExecutionSetShaderEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkIndirectExecutionSetEXT")] VkIndirectExecutionSetEXT_T* indirectExecutionSet, [NativeTypeName("uint32_t")] uint executionSetWriteCount, [NativeTypeName("const VkWriteIndirectExecutionSetShaderEXT *")] VkWriteIndirectExecutionSetShaderEXT* pExecutionSetWrites);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixFlexibleDimensionsPropertiesNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t *")] uint* pPropertyCount, VkCooperativeMatrixFlexibleDimensionsPropertiesNV* pProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdEndRendering2EXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkRenderingEndInfoEXT *")] VkRenderingEndInfoEXT* pRenderingEndInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateAccelerationStructureKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureCreateInfoKHR *")] VkAccelerationStructureCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkAccelerationStructureKHR *")] VkAccelerationStructureKHR_T** pAccelerationStructure);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkDestroyAccelerationStructureKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkAccelerationStructureKHR")] VkAccelerationStructureKHR_T* accelerationStructure, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildAccelerationStructuresKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkAccelerationStructureBuildGeometryInfoKHR *")] VkAccelerationStructureBuildGeometryInfoKHR* pInfos, [NativeTypeName("const VkAccelerationStructureBuildRangeInfoKHR *const *")] VkAccelerationStructureBuildRangeInfoKHR** ppBuildRangeInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdBuildAccelerationStructuresIndirectKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkAccelerationStructureBuildGeometryInfoKHR *")] VkAccelerationStructureBuildGeometryInfoKHR* pInfos, [NativeTypeName("const VkDeviceAddress *")] ulong* pIndirectDeviceAddresses, [NativeTypeName("const uint32_t *")] uint* pIndirectStrides, [NativeTypeName("const uint32_t *const *")] uint** ppMaxPrimitiveCounts);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkBuildAccelerationStructuresKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("uint32_t")] uint infoCount, [NativeTypeName("const VkAccelerationStructureBuildGeometryInfoKHR *")] VkAccelerationStructureBuildGeometryInfoKHR* pInfos, [NativeTypeName("const VkAccelerationStructureBuildRangeInfoKHR *const *")] VkAccelerationStructureBuildRangeInfoKHR** ppBuildRangeInfos);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyAccelerationStructureKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyAccelerationStructureInfoKHR *")] VkCopyAccelerationStructureInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyAccelerationStructureToMemoryKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyAccelerationStructureToMemoryInfoKHR *")] VkCopyAccelerationStructureToMemoryInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCopyMemoryToAccelerationStructureKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("const VkCopyMemoryToAccelerationStructureInfoKHR *")] VkCopyMemoryToAccelerationStructureInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkWriteAccelerationStructuresPropertiesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("uint32_t")] uint accelerationStructureCount, [NativeTypeName("const VkAccelerationStructureKHR *")] VkAccelerationStructureKHR_T** pAccelerationStructures, VkQueryType queryType, [NativeTypeName("size_t")] nuint dataSize, void* pData, [NativeTypeName("size_t")] nuint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyAccelerationStructureKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyAccelerationStructureInfoKHR *")] VkCopyAccelerationStructureInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyAccelerationStructureToMemoryKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyAccelerationStructureToMemoryInfoKHR *")] VkCopyAccelerationStructureToMemoryInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdCopyMemoryToAccelerationStructureKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkCopyMemoryToAccelerationStructureInfoKHR *")] VkCopyMemoryToAccelerationStructureInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceAddress")]
        public static extern ulong vkGetAccelerationStructureDeviceAddressKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureDeviceAddressInfoKHR *")] VkAccelerationStructureDeviceAddressInfoKHR* pInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdWriteAccelerationStructuresPropertiesKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint accelerationStructureCount, [NativeTypeName("const VkAccelerationStructureKHR *")] VkAccelerationStructureKHR_T** pAccelerationStructures, VkQueryType queryType, [NativeTypeName("VkQueryPool")] VkQueryPool_T* queryPool, [NativeTypeName("uint32_t")] uint firstQuery);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetDeviceAccelerationStructureCompatibilityKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkAccelerationStructureVersionInfoKHR *")] VkAccelerationStructureVersionInfoKHR* pVersionInfo, VkAccelerationStructureCompatibilityKHR* pCompatibility);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkGetAccelerationStructureBuildSizesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, VkAccelerationStructureBuildTypeKHR buildType, [NativeTypeName("const VkAccelerationStructureBuildGeometryInfoKHR *")] VkAccelerationStructureBuildGeometryInfoKHR* pBuildInfo, [NativeTypeName("const uint32_t *")] uint* pMaxPrimitiveCounts, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdTraceRaysKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pRaygenShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pMissShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pHitShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pCallableShaderBindingTable, [NativeTypeName("uint32_t")] uint width, [NativeTypeName("uint32_t")] uint height, [NativeTypeName("uint32_t")] uint depth);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateRayTracingPipelinesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeferredOperationKHR")] VkDeferredOperationKHR_T* deferredOperation, [NativeTypeName("VkPipelineCache")] VkPipelineCache_T* pipelineCache, [NativeTypeName("uint32_t")] uint createInfoCount, [NativeTypeName("const VkRayTracingPipelineCreateInfoKHR *")] VkRayTracingPipelineCreateInfoKHR* pCreateInfos, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkPipeline *")] VkPipeline_T** pPipelines);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetRayTracingCaptureReplayShaderGroupHandlesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint firstGroup, [NativeTypeName("uint32_t")] uint groupCount, [NativeTypeName("size_t")] nuint dataSize, void* pData);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdTraceRaysIndirectKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pRaygenShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pMissShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pHitShaderBindingTable, [NativeTypeName("const VkStridedDeviceAddressRegionKHR *")] VkStridedDeviceAddressRegionKHR* pCallableShaderBindingTable, [NativeTypeName("VkDeviceAddress")] ulong indirectDeviceAddress);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkDeviceSize")]
        public static extern ulong vkGetRayTracingShaderGroupStackSizeKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkPipeline")] VkPipeline_T* pipeline, [NativeTypeName("uint32_t")] uint group, VkShaderGroupShaderKHR groupShader);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdSetRayTracingPipelineStackSizeKHR([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint pipelineStackSize);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("uint32_t")] uint groupCountX, [NativeTypeName("uint32_t")] uint groupCountY, [NativeTypeName("uint32_t")] uint groupCountZ);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksIndirectEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("uint32_t")] uint drawCount, [NativeTypeName("uint32_t")] uint stride);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern void vkCmdDrawMeshTasksIndirectCountEXT([NativeTypeName("VkCommandBuffer")] VkCommandBuffer_T* commandBuffer, [NativeTypeName("VkBuffer")] VkBuffer_T* buffer, [NativeTypeName("VkDeviceSize")] ulong offset, [NativeTypeName("VkBuffer")] VkBuffer_T* countBuffer, [NativeTypeName("VkDeviceSize")] ulong countBufferOffset, [NativeTypeName("uint32_t")] uint maxDrawCount, [NativeTypeName("uint32_t")] uint stride);

        [NativeTypeName("#define VULKAN_CORE_H_ 1")]
        public const int VULKAN_CORE_H_ = 1;

        [NativeTypeName("#define VK_VERSION_1_0 1")]
        public const int VK_VERSION_1_0 = 1;

        [NativeTypeName("#define VK_USE_64_BIT_PTR_DEFINES 1")]
        public const int VK_USE_64_BIT_PTR_DEFINES = 1;

        [NativeTypeName("#define VK_API_VERSION_1_0 VK_MAKE_API_VERSION(0, 1, 0, 0)")]
        public const uint VK_API_VERSION_1_0 = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_HEADER_VERSION 313")]
        public const int VK_HEADER_VERSION = 313;

        [NativeTypeName("#define VK_HEADER_VERSION_COMPLETE VK_MAKE_API_VERSION(0, 1, 4, VK_HEADER_VERSION)")]
        public const uint VK_HEADER_VERSION_COMPLETE = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(4)) << 12) | ((uint)(313)));

        [NativeTypeName("#define VK_ATTACHMENT_UNUSED (~0U)")]
        public const uint VK_ATTACHMENT_UNUSED = (~0U);

        [NativeTypeName("#define VK_FALSE 0U")]
        public const uint VK_FALSE = 0U;

        [NativeTypeName("#define VK_LOD_CLAMP_NONE 1000.0F")]
        public const float VK_LOD_CLAMP_NONE = 1000.0F;

        [NativeTypeName("#define VK_QUEUE_FAMILY_IGNORED (~0U)")]
        public const uint VK_QUEUE_FAMILY_IGNORED = (~0U);

        [NativeTypeName("#define VK_REMAINING_ARRAY_LAYERS (~0U)")]
        public const uint VK_REMAINING_ARRAY_LAYERS = (~0U);

        [NativeTypeName("#define VK_REMAINING_MIP_LEVELS (~0U)")]
        public const uint VK_REMAINING_MIP_LEVELS = (~0U);

        [NativeTypeName("#define VK_SUBPASS_EXTERNAL (~0U)")]
        public const uint VK_SUBPASS_EXTERNAL = (~0U);

        [NativeTypeName("#define VK_TRUE 1U")]
        public const uint VK_TRUE = 1U;

        [NativeTypeName("#define VK_WHOLE_SIZE (~0ULL)")]
        public const ulong VK_WHOLE_SIZE = (~0UL);

        [NativeTypeName("#define VK_MAX_MEMORY_TYPES 32U")]
        public const uint VK_MAX_MEMORY_TYPES = 32U;

        [NativeTypeName("#define VK_MAX_PHYSICAL_DEVICE_NAME_SIZE 256U")]
        public const uint VK_MAX_PHYSICAL_DEVICE_NAME_SIZE = 256U;

        [NativeTypeName("#define VK_UUID_SIZE 16U")]
        public const uint VK_UUID_SIZE = 16U;

        [NativeTypeName("#define VK_MAX_EXTENSION_NAME_SIZE 256U")]
        public const uint VK_MAX_EXTENSION_NAME_SIZE = 256U;

        [NativeTypeName("#define VK_MAX_DESCRIPTION_SIZE 256U")]
        public const uint VK_MAX_DESCRIPTION_SIZE = 256U;

        [NativeTypeName("#define VK_MAX_MEMORY_HEAPS 16U")]
        public const uint VK_MAX_MEMORY_HEAPS = 16U;

        [NativeTypeName("#define VK_VERSION_1_1 1")]
        public const int VK_VERSION_1_1 = 1;

        [NativeTypeName("#define VK_API_VERSION_1_1 VK_MAKE_API_VERSION(0, 1, 1, 0)")]
        public const uint VK_API_VERSION_1_1 = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(1)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_MAX_DEVICE_GROUP_SIZE 32U")]
        public const uint VK_MAX_DEVICE_GROUP_SIZE = 32U;

        [NativeTypeName("#define VK_LUID_SIZE 8U")]
        public const uint VK_LUID_SIZE = 8U;

        [NativeTypeName("#define VK_QUEUE_FAMILY_EXTERNAL (~1U)")]
        public const uint VK_QUEUE_FAMILY_EXTERNAL = (~1U);

        [NativeTypeName("#define VK_VERSION_1_2 1")]
        public const int VK_VERSION_1_2 = 1;

        [NativeTypeName("#define VK_API_VERSION_1_2 VK_MAKE_API_VERSION(0, 1, 2, 0)")]
        public const uint VK_API_VERSION_1_2 = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(2)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_MAX_DRIVER_NAME_SIZE 256U")]
        public const uint VK_MAX_DRIVER_NAME_SIZE = 256U;

        [NativeTypeName("#define VK_MAX_DRIVER_INFO_SIZE 256U")]
        public const uint VK_MAX_DRIVER_INFO_SIZE = 256U;

        [NativeTypeName("#define VK_VERSION_1_3 1")]
        public const int VK_VERSION_1_3 = 1;

        [NativeTypeName("#define VK_API_VERSION_1_3 VK_MAKE_API_VERSION(0, 1, 3, 0)")]
        public const uint VK_API_VERSION_1_3 = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(3)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_VERSION_1_4 1")]
        public const int VK_VERSION_1_4 = 1;

        [NativeTypeName("#define VK_API_VERSION_1_4 VK_MAKE_API_VERSION(0, 1, 4, 0)")]
        public const uint VK_API_VERSION_1_4 = ((((uint)(0)) << 29) | (((uint)(1)) << 22) | (((uint)(4)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_MAX_GLOBAL_PRIORITY_SIZE 16U")]
        public const uint VK_MAX_GLOBAL_PRIORITY_SIZE = 16U;

        [NativeTypeName("#define VK_KHR_surface 1")]
        public const int VK_KHR_surface = 1;

        [NativeTypeName("#define VK_KHR_SURFACE_SPEC_VERSION 25")]
        public const int VK_KHR_SURFACE_SPEC_VERSION = 25;

        [NativeTypeName("#define VK_KHR_SURFACE_EXTENSION_NAME \"VK_KHR_surface\"")]
        public static ReadOnlySpan<byte> VK_KHR_SURFACE_EXTENSION_NAME => "VK_KHR_surface"u8;

        [NativeTypeName("#define VK_KHR_swapchain 1")]
        public const int VK_KHR_swapchain = 1;

        [NativeTypeName("#define VK_KHR_SWAPCHAIN_SPEC_VERSION 70")]
        public const int VK_KHR_SWAPCHAIN_SPEC_VERSION = 70;

        [NativeTypeName("#define VK_KHR_SWAPCHAIN_EXTENSION_NAME \"VK_KHR_swapchain\"")]
        public static ReadOnlySpan<byte> VK_KHR_SWAPCHAIN_EXTENSION_NAME => "VK_KHR_swapchain"u8;

        [NativeTypeName("#define VK_KHR_display 1")]
        public const int VK_KHR_display = 1;

        [NativeTypeName("#define VK_KHR_DISPLAY_SPEC_VERSION 23")]
        public const int VK_KHR_DISPLAY_SPEC_VERSION = 23;

        [NativeTypeName("#define VK_KHR_DISPLAY_EXTENSION_NAME \"VK_KHR_display\"")]
        public static ReadOnlySpan<byte> VK_KHR_DISPLAY_EXTENSION_NAME => "VK_KHR_display"u8;

        [NativeTypeName("#define VK_KHR_display_swapchain 1")]
        public const int VK_KHR_display_swapchain = 1;

        [NativeTypeName("#define VK_KHR_DISPLAY_SWAPCHAIN_SPEC_VERSION 10")]
        public const int VK_KHR_DISPLAY_SWAPCHAIN_SPEC_VERSION = 10;

        [NativeTypeName("#define VK_KHR_DISPLAY_SWAPCHAIN_EXTENSION_NAME \"VK_KHR_display_swapchain\"")]
        public static ReadOnlySpan<byte> VK_KHR_DISPLAY_SWAPCHAIN_EXTENSION_NAME => "VK_KHR_display_swapchain"u8;

        [NativeTypeName("#define VK_KHR_sampler_mirror_clamp_to_edge 1")]
        public const int VK_KHR_sampler_mirror_clamp_to_edge = 1;

        [NativeTypeName("#define VK_KHR_SAMPLER_MIRROR_CLAMP_TO_EDGE_SPEC_VERSION 3")]
        public const int VK_KHR_SAMPLER_MIRROR_CLAMP_TO_EDGE_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_KHR_SAMPLER_MIRROR_CLAMP_TO_EDGE_EXTENSION_NAME \"VK_KHR_sampler_mirror_clamp_to_edge\"")]
        public static ReadOnlySpan<byte> VK_KHR_SAMPLER_MIRROR_CLAMP_TO_EDGE_EXTENSION_NAME => "VK_KHR_sampler_mirror_clamp_to_edge"u8;

        [NativeTypeName("#define VK_KHR_video_queue 1")]
        public const int VK_KHR_video_queue = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_QUEUE_SPEC_VERSION 8")]
        public const int VK_KHR_VIDEO_QUEUE_SPEC_VERSION = 8;

        [NativeTypeName("#define VK_KHR_VIDEO_QUEUE_EXTENSION_NAME \"VK_KHR_video_queue\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_QUEUE_EXTENSION_NAME => "VK_KHR_video_queue"u8;

        [NativeTypeName("#define VK_KHR_video_decode_queue 1")]
        public const int VK_KHR_video_decode_queue = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_QUEUE_SPEC_VERSION 8")]
        public const int VK_KHR_VIDEO_DECODE_QUEUE_SPEC_VERSION = 8;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_QUEUE_EXTENSION_NAME \"VK_KHR_video_decode_queue\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_DECODE_QUEUE_EXTENSION_NAME => "VK_KHR_video_decode_queue"u8;

        [NativeTypeName("#define VK_KHR_video_encode_h264 1")]
        public const int VK_KHR_video_encode_h264 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_H264_SPEC_VERSION 14")]
        public const int VK_KHR_VIDEO_ENCODE_H264_SPEC_VERSION = 14;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_H264_EXTENSION_NAME \"VK_KHR_video_encode_h264\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_ENCODE_H264_EXTENSION_NAME => "VK_KHR_video_encode_h264"u8;

        [NativeTypeName("#define VK_KHR_video_encode_h265 1")]
        public const int VK_KHR_video_encode_h265 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_H265_SPEC_VERSION 14")]
        public const int VK_KHR_VIDEO_ENCODE_H265_SPEC_VERSION = 14;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_H265_EXTENSION_NAME \"VK_KHR_video_encode_h265\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_ENCODE_H265_EXTENSION_NAME => "VK_KHR_video_encode_h265"u8;

        [NativeTypeName("#define VK_KHR_video_decode_h264 1")]
        public const int VK_KHR_video_decode_h264 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_H264_SPEC_VERSION 9")]
        public const int VK_KHR_VIDEO_DECODE_H264_SPEC_VERSION = 9;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_H264_EXTENSION_NAME \"VK_KHR_video_decode_h264\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_DECODE_H264_EXTENSION_NAME => "VK_KHR_video_decode_h264"u8;

        [NativeTypeName("#define VK_KHR_dynamic_rendering 1")]
        public const int VK_KHR_dynamic_rendering = 1;

        [NativeTypeName("#define VK_KHR_DYNAMIC_RENDERING_SPEC_VERSION 1")]
        public const int VK_KHR_DYNAMIC_RENDERING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DYNAMIC_RENDERING_EXTENSION_NAME \"VK_KHR_dynamic_rendering\"")]
        public static ReadOnlySpan<byte> VK_KHR_DYNAMIC_RENDERING_EXTENSION_NAME => "VK_KHR_dynamic_rendering"u8;

        [NativeTypeName("#define VK_KHR_multiview 1")]
        public const int VK_KHR_multiview = 1;

        [NativeTypeName("#define VK_KHR_MULTIVIEW_SPEC_VERSION 1")]
        public const int VK_KHR_MULTIVIEW_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MULTIVIEW_EXTENSION_NAME \"VK_KHR_multiview\"")]
        public static ReadOnlySpan<byte> VK_KHR_MULTIVIEW_EXTENSION_NAME => "VK_KHR_multiview"u8;

        [NativeTypeName("#define VK_KHR_get_physical_device_properties2 1")]
        public const int VK_KHR_get_physical_device_properties2 = 1;

        [NativeTypeName("#define VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_SPEC_VERSION 2")]
        public const int VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME \"VK_KHR_get_physical_device_properties2\"")]
        public static ReadOnlySpan<byte> VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME => "VK_KHR_get_physical_device_properties2"u8;

        [NativeTypeName("#define VK_KHR_device_group 1")]
        public const int VK_KHR_device_group = 1;

        [NativeTypeName("#define VK_KHR_DEVICE_GROUP_SPEC_VERSION 4")]
        public const int VK_KHR_DEVICE_GROUP_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_KHR_DEVICE_GROUP_EXTENSION_NAME \"VK_KHR_device_group\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEVICE_GROUP_EXTENSION_NAME => "VK_KHR_device_group"u8;

        [NativeTypeName("#define VK_KHR_shader_draw_parameters 1")]
        public const int VK_KHR_shader_draw_parameters = 1;

        [NativeTypeName("#define VK_KHR_SHADER_DRAW_PARAMETERS_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_DRAW_PARAMETERS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_DRAW_PARAMETERS_EXTENSION_NAME \"VK_KHR_shader_draw_parameters\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_DRAW_PARAMETERS_EXTENSION_NAME => "VK_KHR_shader_draw_parameters"u8;

        [NativeTypeName("#define VK_KHR_maintenance1 1")]
        public const int VK_KHR_maintenance1 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_1_SPEC_VERSION 2")]
        public const int VK_KHR_MAINTENANCE_1_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_1_EXTENSION_NAME \"VK_KHR_maintenance1\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_1_EXTENSION_NAME => "VK_KHR_maintenance1"u8;

        [NativeTypeName("#define VK_KHR_MAINTENANCE1_SPEC_VERSION VK_KHR_MAINTENANCE_1_SPEC_VERSION")]
        public const int VK_KHR_MAINTENANCE1_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_MAINTENANCE1_EXTENSION_NAME VK_KHR_MAINTENANCE_1_EXTENSION_NAME")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE1_EXTENSION_NAME => "VK_KHR_maintenance1"u8;

        [NativeTypeName("#define VK_KHR_device_group_creation 1")]
        public const int VK_KHR_device_group_creation = 1;

        [NativeTypeName("#define VK_KHR_DEVICE_GROUP_CREATION_SPEC_VERSION 1")]
        public const int VK_KHR_DEVICE_GROUP_CREATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DEVICE_GROUP_CREATION_EXTENSION_NAME \"VK_KHR_device_group_creation\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEVICE_GROUP_CREATION_EXTENSION_NAME => "VK_KHR_device_group_creation"u8;

        [NativeTypeName("#define VK_MAX_DEVICE_GROUP_SIZE_KHR VK_MAX_DEVICE_GROUP_SIZE")]
        public const uint VK_MAX_DEVICE_GROUP_SIZE_KHR = 32U;

        [NativeTypeName("#define VK_KHR_external_memory_capabilities 1")]
        public const int VK_KHR_external_memory_capabilities = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME \"VK_KHR_external_memory_capabilities\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME => "VK_KHR_external_memory_capabilities"u8;

        [NativeTypeName("#define VK_LUID_SIZE_KHR VK_LUID_SIZE")]
        public const uint VK_LUID_SIZE_KHR = 8U;

        [NativeTypeName("#define VK_KHR_external_memory 1")]
        public const int VK_KHR_external_memory = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_MEMORY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_EXTENSION_NAME \"VK_KHR_external_memory\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_MEMORY_EXTENSION_NAME => "VK_KHR_external_memory"u8;

        [NativeTypeName("#define VK_QUEUE_FAMILY_EXTERNAL_KHR VK_QUEUE_FAMILY_EXTERNAL")]
        public const uint VK_QUEUE_FAMILY_EXTERNAL_KHR = (~1U);

        [NativeTypeName("#define VK_KHR_external_memory_fd 1")]
        public const int VK_KHR_external_memory_fd = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_FD_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_MEMORY_FD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_FD_EXTENSION_NAME \"VK_KHR_external_memory_fd\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_MEMORY_FD_EXTENSION_NAME => "VK_KHR_external_memory_fd"u8;

        [NativeTypeName("#define VK_KHR_external_semaphore_capabilities 1")]
        public const int VK_KHR_external_semaphore_capabilities = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_EXTENSION_NAME \"VK_KHR_external_semaphore_capabilities\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_EXTENSION_NAME => "VK_KHR_external_semaphore_capabilities"u8;

        [NativeTypeName("#define VK_KHR_external_semaphore 1")]
        public const int VK_KHR_external_semaphore = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_SEMAPHORE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_EXTENSION_NAME \"VK_KHR_external_semaphore\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_SEMAPHORE_EXTENSION_NAME => "VK_KHR_external_semaphore"u8;

        [NativeTypeName("#define VK_KHR_external_semaphore_fd 1")]
        public const int VK_KHR_external_semaphore_fd = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_FD_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_SEMAPHORE_FD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_FD_EXTENSION_NAME \"VK_KHR_external_semaphore_fd\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_SEMAPHORE_FD_EXTENSION_NAME => "VK_KHR_external_semaphore_fd"u8;

        [NativeTypeName("#define VK_KHR_push_descriptor 1")]
        public const int VK_KHR_push_descriptor = 1;

        [NativeTypeName("#define VK_KHR_PUSH_DESCRIPTOR_SPEC_VERSION 2")]
        public const int VK_KHR_PUSH_DESCRIPTOR_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_PUSH_DESCRIPTOR_EXTENSION_NAME \"VK_KHR_push_descriptor\"")]
        public static ReadOnlySpan<byte> VK_KHR_PUSH_DESCRIPTOR_EXTENSION_NAME => "VK_KHR_push_descriptor"u8;

        [NativeTypeName("#define VK_KHR_shader_float16_int8 1")]
        public const int VK_KHR_shader_float16_int8 = 1;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT16_INT8_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_FLOAT16_INT8_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT16_INT8_EXTENSION_NAME \"VK_KHR_shader_float16_int8\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_FLOAT16_INT8_EXTENSION_NAME => "VK_KHR_shader_float16_int8"u8;

        [NativeTypeName("#define VK_KHR_16bit_storage 1")]
        public const int VK_KHR_16bit_storage = 1;

        [NativeTypeName("#define VK_KHR_16BIT_STORAGE_SPEC_VERSION 1")]
        public const int VK_KHR_16BIT_STORAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_16BIT_STORAGE_EXTENSION_NAME \"VK_KHR_16bit_storage\"")]
        public static ReadOnlySpan<byte> VK_KHR_16BIT_STORAGE_EXTENSION_NAME => "VK_KHR_16bit_storage"u8;

        [NativeTypeName("#define VK_KHR_incremental_present 1")]
        public const int VK_KHR_incremental_present = 1;

        [NativeTypeName("#define VK_KHR_INCREMENTAL_PRESENT_SPEC_VERSION 2")]
        public const int VK_KHR_INCREMENTAL_PRESENT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_INCREMENTAL_PRESENT_EXTENSION_NAME \"VK_KHR_incremental_present\"")]
        public static ReadOnlySpan<byte> VK_KHR_INCREMENTAL_PRESENT_EXTENSION_NAME => "VK_KHR_incremental_present"u8;

        [NativeTypeName("#define VK_KHR_descriptor_update_template 1")]
        public const int VK_KHR_descriptor_update_template = 1;

        [NativeTypeName("#define VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_SPEC_VERSION 1")]
        public const int VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_EXTENSION_NAME \"VK_KHR_descriptor_update_template\"")]
        public static ReadOnlySpan<byte> VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_EXTENSION_NAME => "VK_KHR_descriptor_update_template"u8;

        [NativeTypeName("#define VK_KHR_imageless_framebuffer 1")]
        public const int VK_KHR_imageless_framebuffer = 1;

        [NativeTypeName("#define VK_KHR_IMAGELESS_FRAMEBUFFER_SPEC_VERSION 1")]
        public const int VK_KHR_IMAGELESS_FRAMEBUFFER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_IMAGELESS_FRAMEBUFFER_EXTENSION_NAME \"VK_KHR_imageless_framebuffer\"")]
        public static ReadOnlySpan<byte> VK_KHR_IMAGELESS_FRAMEBUFFER_EXTENSION_NAME => "VK_KHR_imageless_framebuffer"u8;

        [NativeTypeName("#define VK_KHR_create_renderpass2 1")]
        public const int VK_KHR_create_renderpass2 = 1;

        [NativeTypeName("#define VK_KHR_CREATE_RENDERPASS_2_SPEC_VERSION 1")]
        public const int VK_KHR_CREATE_RENDERPASS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_CREATE_RENDERPASS_2_EXTENSION_NAME \"VK_KHR_create_renderpass2\"")]
        public static ReadOnlySpan<byte> VK_KHR_CREATE_RENDERPASS_2_EXTENSION_NAME => "VK_KHR_create_renderpass2"u8;

        [NativeTypeName("#define VK_KHR_shared_presentable_image 1")]
        public const int VK_KHR_shared_presentable_image = 1;

        [NativeTypeName("#define VK_KHR_SHARED_PRESENTABLE_IMAGE_SPEC_VERSION 1")]
        public const int VK_KHR_SHARED_PRESENTABLE_IMAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHARED_PRESENTABLE_IMAGE_EXTENSION_NAME \"VK_KHR_shared_presentable_image\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHARED_PRESENTABLE_IMAGE_EXTENSION_NAME => "VK_KHR_shared_presentable_image"u8;

        [NativeTypeName("#define VK_KHR_external_fence_capabilities 1")]
        public const int VK_KHR_external_fence_capabilities = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_CAPABILITIES_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_FENCE_CAPABILITIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_CAPABILITIES_EXTENSION_NAME \"VK_KHR_external_fence_capabilities\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_FENCE_CAPABILITIES_EXTENSION_NAME => "VK_KHR_external_fence_capabilities"u8;

        [NativeTypeName("#define VK_KHR_external_fence 1")]
        public const int VK_KHR_external_fence = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_FENCE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_EXTENSION_NAME \"VK_KHR_external_fence\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_FENCE_EXTENSION_NAME => "VK_KHR_external_fence"u8;

        [NativeTypeName("#define VK_KHR_external_fence_fd 1")]
        public const int VK_KHR_external_fence_fd = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_FD_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_FENCE_FD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_FD_EXTENSION_NAME \"VK_KHR_external_fence_fd\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_FENCE_FD_EXTENSION_NAME => "VK_KHR_external_fence_fd"u8;

        [NativeTypeName("#define VK_KHR_performance_query 1")]
        public const int VK_KHR_performance_query = 1;

        [NativeTypeName("#define VK_KHR_PERFORMANCE_QUERY_SPEC_VERSION 1")]
        public const int VK_KHR_PERFORMANCE_QUERY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PERFORMANCE_QUERY_EXTENSION_NAME \"VK_KHR_performance_query\"")]
        public static ReadOnlySpan<byte> VK_KHR_PERFORMANCE_QUERY_EXTENSION_NAME => "VK_KHR_performance_query"u8;

        [NativeTypeName("#define VK_KHR_maintenance2 1")]
        public const int VK_KHR_maintenance2 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_2_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_2_EXTENSION_NAME \"VK_KHR_maintenance2\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_2_EXTENSION_NAME => "VK_KHR_maintenance2"u8;

        [NativeTypeName("#define VK_KHR_MAINTENANCE2_SPEC_VERSION VK_KHR_MAINTENANCE_2_SPEC_VERSION")]
        public const int VK_KHR_MAINTENANCE2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE2_EXTENSION_NAME VK_KHR_MAINTENANCE_2_EXTENSION_NAME")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE2_EXTENSION_NAME => "VK_KHR_maintenance2"u8;

        [NativeTypeName("#define VK_KHR_get_surface_capabilities2 1")]
        public const int VK_KHR_get_surface_capabilities2 = 1;

        [NativeTypeName("#define VK_KHR_GET_SURFACE_CAPABILITIES_2_SPEC_VERSION 1")]
        public const int VK_KHR_GET_SURFACE_CAPABILITIES_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_GET_SURFACE_CAPABILITIES_2_EXTENSION_NAME \"VK_KHR_get_surface_capabilities2\"")]
        public static ReadOnlySpan<byte> VK_KHR_GET_SURFACE_CAPABILITIES_2_EXTENSION_NAME => "VK_KHR_get_surface_capabilities2"u8;

        [NativeTypeName("#define VK_KHR_variable_pointers 1")]
        public const int VK_KHR_variable_pointers = 1;

        [NativeTypeName("#define VK_KHR_VARIABLE_POINTERS_SPEC_VERSION 1")]
        public const int VK_KHR_VARIABLE_POINTERS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VARIABLE_POINTERS_EXTENSION_NAME \"VK_KHR_variable_pointers\"")]
        public static ReadOnlySpan<byte> VK_KHR_VARIABLE_POINTERS_EXTENSION_NAME => "VK_KHR_variable_pointers"u8;

        [NativeTypeName("#define VK_KHR_get_display_properties2 1")]
        public const int VK_KHR_get_display_properties2 = 1;

        [NativeTypeName("#define VK_KHR_GET_DISPLAY_PROPERTIES_2_SPEC_VERSION 1")]
        public const int VK_KHR_GET_DISPLAY_PROPERTIES_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_GET_DISPLAY_PROPERTIES_2_EXTENSION_NAME \"VK_KHR_get_display_properties2\"")]
        public static ReadOnlySpan<byte> VK_KHR_GET_DISPLAY_PROPERTIES_2_EXTENSION_NAME => "VK_KHR_get_display_properties2"u8;

        [NativeTypeName("#define VK_KHR_dedicated_allocation 1")]
        public const int VK_KHR_dedicated_allocation = 1;

        [NativeTypeName("#define VK_KHR_DEDICATED_ALLOCATION_SPEC_VERSION 3")]
        public const int VK_KHR_DEDICATED_ALLOCATION_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_KHR_DEDICATED_ALLOCATION_EXTENSION_NAME \"VK_KHR_dedicated_allocation\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEDICATED_ALLOCATION_EXTENSION_NAME => "VK_KHR_dedicated_allocation"u8;

        [NativeTypeName("#define VK_KHR_storage_buffer_storage_class 1")]
        public const int VK_KHR_storage_buffer_storage_class = 1;

        [NativeTypeName("#define VK_KHR_STORAGE_BUFFER_STORAGE_CLASS_SPEC_VERSION 1")]
        public const int VK_KHR_STORAGE_BUFFER_STORAGE_CLASS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_STORAGE_BUFFER_STORAGE_CLASS_EXTENSION_NAME \"VK_KHR_storage_buffer_storage_class\"")]
        public static ReadOnlySpan<byte> VK_KHR_STORAGE_BUFFER_STORAGE_CLASS_EXTENSION_NAME => "VK_KHR_storage_buffer_storage_class"u8;

        [NativeTypeName("#define VK_KHR_shader_bfloat16 1")]
        public const int VK_KHR_shader_bfloat16 = 1;

        [NativeTypeName("#define VK_KHR_SHADER_BFLOAT16_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_BFLOAT16_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_BFLOAT16_EXTENSION_NAME \"VK_KHR_shader_bfloat16\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_BFLOAT16_EXTENSION_NAME => "VK_KHR_shader_bfloat16"u8;

        [NativeTypeName("#define VK_KHR_relaxed_block_layout 1")]
        public const int VK_KHR_relaxed_block_layout = 1;

        [NativeTypeName("#define VK_KHR_RELAXED_BLOCK_LAYOUT_SPEC_VERSION 1")]
        public const int VK_KHR_RELAXED_BLOCK_LAYOUT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_RELAXED_BLOCK_LAYOUT_EXTENSION_NAME \"VK_KHR_relaxed_block_layout\"")]
        public static ReadOnlySpan<byte> VK_KHR_RELAXED_BLOCK_LAYOUT_EXTENSION_NAME => "VK_KHR_relaxed_block_layout"u8;

        [NativeTypeName("#define VK_KHR_get_memory_requirements2 1")]
        public const int VK_KHR_get_memory_requirements2 = 1;

        [NativeTypeName("#define VK_KHR_GET_MEMORY_REQUIREMENTS_2_SPEC_VERSION 1")]
        public const int VK_KHR_GET_MEMORY_REQUIREMENTS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_GET_MEMORY_REQUIREMENTS_2_EXTENSION_NAME \"VK_KHR_get_memory_requirements2\"")]
        public static ReadOnlySpan<byte> VK_KHR_GET_MEMORY_REQUIREMENTS_2_EXTENSION_NAME => "VK_KHR_get_memory_requirements2"u8;

        [NativeTypeName("#define VK_KHR_image_format_list 1")]
        public const int VK_KHR_image_format_list = 1;

        [NativeTypeName("#define VK_KHR_IMAGE_FORMAT_LIST_SPEC_VERSION 1")]
        public const int VK_KHR_IMAGE_FORMAT_LIST_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_IMAGE_FORMAT_LIST_EXTENSION_NAME \"VK_KHR_image_format_list\"")]
        public static ReadOnlySpan<byte> VK_KHR_IMAGE_FORMAT_LIST_EXTENSION_NAME => "VK_KHR_image_format_list"u8;

        [NativeTypeName("#define VK_KHR_sampler_ycbcr_conversion 1")]
        public const int VK_KHR_sampler_ycbcr_conversion = 1;

        [NativeTypeName("#define VK_KHR_SAMPLER_YCBCR_CONVERSION_SPEC_VERSION 14")]
        public const int VK_KHR_SAMPLER_YCBCR_CONVERSION_SPEC_VERSION = 14;

        [NativeTypeName("#define VK_KHR_SAMPLER_YCBCR_CONVERSION_EXTENSION_NAME \"VK_KHR_sampler_ycbcr_conversion\"")]
        public static ReadOnlySpan<byte> VK_KHR_SAMPLER_YCBCR_CONVERSION_EXTENSION_NAME => "VK_KHR_sampler_ycbcr_conversion"u8;

        [NativeTypeName("#define VK_KHR_bind_memory2 1")]
        public const int VK_KHR_bind_memory2 = 1;

        [NativeTypeName("#define VK_KHR_BIND_MEMORY_2_SPEC_VERSION 1")]
        public const int VK_KHR_BIND_MEMORY_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_BIND_MEMORY_2_EXTENSION_NAME \"VK_KHR_bind_memory2\"")]
        public static ReadOnlySpan<byte> VK_KHR_BIND_MEMORY_2_EXTENSION_NAME => "VK_KHR_bind_memory2"u8;

        [NativeTypeName("#define VK_KHR_maintenance3 1")]
        public const int VK_KHR_maintenance3 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_3_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_3_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_3_EXTENSION_NAME \"VK_KHR_maintenance3\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_3_EXTENSION_NAME => "VK_KHR_maintenance3"u8;

        [NativeTypeName("#define VK_KHR_MAINTENANCE3_SPEC_VERSION VK_KHR_MAINTENANCE_3_SPEC_VERSION")]
        public const int VK_KHR_MAINTENANCE3_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE3_EXTENSION_NAME VK_KHR_MAINTENANCE_3_EXTENSION_NAME")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE3_EXTENSION_NAME => "VK_KHR_maintenance3"u8;

        [NativeTypeName("#define VK_KHR_draw_indirect_count 1")]
        public const int VK_KHR_draw_indirect_count = 1;

        [NativeTypeName("#define VK_KHR_DRAW_INDIRECT_COUNT_SPEC_VERSION 1")]
        public const int VK_KHR_DRAW_INDIRECT_COUNT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DRAW_INDIRECT_COUNT_EXTENSION_NAME \"VK_KHR_draw_indirect_count\"")]
        public static ReadOnlySpan<byte> VK_KHR_DRAW_INDIRECT_COUNT_EXTENSION_NAME => "VK_KHR_draw_indirect_count"u8;

        [NativeTypeName("#define VK_KHR_shader_subgroup_extended_types 1")]
        public const int VK_KHR_shader_subgroup_extended_types = 1;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_EXTENDED_TYPES_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_SUBGROUP_EXTENDED_TYPES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_EXTENDED_TYPES_EXTENSION_NAME \"VK_KHR_shader_subgroup_extended_types\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_SUBGROUP_EXTENDED_TYPES_EXTENSION_NAME => "VK_KHR_shader_subgroup_extended_types"u8;

        [NativeTypeName("#define VK_KHR_8bit_storage 1")]
        public const int VK_KHR_8bit_storage = 1;

        [NativeTypeName("#define VK_KHR_8BIT_STORAGE_SPEC_VERSION 1")]
        public const int VK_KHR_8BIT_STORAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_8BIT_STORAGE_EXTENSION_NAME \"VK_KHR_8bit_storage\"")]
        public static ReadOnlySpan<byte> VK_KHR_8BIT_STORAGE_EXTENSION_NAME => "VK_KHR_8bit_storage"u8;

        [NativeTypeName("#define VK_KHR_shader_atomic_int64 1")]
        public const int VK_KHR_shader_atomic_int64 = 1;

        [NativeTypeName("#define VK_KHR_SHADER_ATOMIC_INT64_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_ATOMIC_INT64_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_ATOMIC_INT64_EXTENSION_NAME \"VK_KHR_shader_atomic_int64\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_ATOMIC_INT64_EXTENSION_NAME => "VK_KHR_shader_atomic_int64"u8;

        [NativeTypeName("#define VK_KHR_shader_clock 1")]
        public const int VK_KHR_shader_clock = 1;

        [NativeTypeName("#define VK_KHR_SHADER_CLOCK_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_CLOCK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_CLOCK_EXTENSION_NAME \"VK_KHR_shader_clock\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_CLOCK_EXTENSION_NAME => "VK_KHR_shader_clock"u8;

        [NativeTypeName("#define VK_KHR_video_decode_h265 1")]
        public const int VK_KHR_video_decode_h265 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_H265_SPEC_VERSION 8")]
        public const int VK_KHR_VIDEO_DECODE_H265_SPEC_VERSION = 8;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_H265_EXTENSION_NAME \"VK_KHR_video_decode_h265\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_DECODE_H265_EXTENSION_NAME => "VK_KHR_video_decode_h265"u8;

        [NativeTypeName("#define VK_KHR_global_priority 1")]
        public const int VK_KHR_global_priority = 1;

        [NativeTypeName("#define VK_KHR_GLOBAL_PRIORITY_SPEC_VERSION 1")]
        public const int VK_KHR_GLOBAL_PRIORITY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_GLOBAL_PRIORITY_EXTENSION_NAME \"VK_KHR_global_priority\"")]
        public static ReadOnlySpan<byte> VK_KHR_GLOBAL_PRIORITY_EXTENSION_NAME => "VK_KHR_global_priority"u8;

        [NativeTypeName("#define VK_MAX_GLOBAL_PRIORITY_SIZE_KHR VK_MAX_GLOBAL_PRIORITY_SIZE")]
        public const uint VK_MAX_GLOBAL_PRIORITY_SIZE_KHR = 16U;

        [NativeTypeName("#define VK_KHR_driver_properties 1")]
        public const int VK_KHR_driver_properties = 1;

        [NativeTypeName("#define VK_KHR_DRIVER_PROPERTIES_SPEC_VERSION 1")]
        public const int VK_KHR_DRIVER_PROPERTIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DRIVER_PROPERTIES_EXTENSION_NAME \"VK_KHR_driver_properties\"")]
        public static ReadOnlySpan<byte> VK_KHR_DRIVER_PROPERTIES_EXTENSION_NAME => "VK_KHR_driver_properties"u8;

        [NativeTypeName("#define VK_MAX_DRIVER_NAME_SIZE_KHR VK_MAX_DRIVER_NAME_SIZE")]
        public const uint VK_MAX_DRIVER_NAME_SIZE_KHR = 256U;

        [NativeTypeName("#define VK_MAX_DRIVER_INFO_SIZE_KHR VK_MAX_DRIVER_INFO_SIZE")]
        public const uint VK_MAX_DRIVER_INFO_SIZE_KHR = 256U;

        [NativeTypeName("#define VK_KHR_shader_float_controls 1")]
        public const int VK_KHR_shader_float_controls = 1;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT_CONTROLS_SPEC_VERSION 4")]
        public const int VK_KHR_SHADER_FLOAT_CONTROLS_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT_CONTROLS_EXTENSION_NAME \"VK_KHR_shader_float_controls\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_FLOAT_CONTROLS_EXTENSION_NAME => "VK_KHR_shader_float_controls"u8;

        [NativeTypeName("#define VK_KHR_depth_stencil_resolve 1")]
        public const int VK_KHR_depth_stencil_resolve = 1;

        [NativeTypeName("#define VK_KHR_DEPTH_STENCIL_RESOLVE_SPEC_VERSION 1")]
        public const int VK_KHR_DEPTH_STENCIL_RESOLVE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DEPTH_STENCIL_RESOLVE_EXTENSION_NAME \"VK_KHR_depth_stencil_resolve\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEPTH_STENCIL_RESOLVE_EXTENSION_NAME => "VK_KHR_depth_stencil_resolve"u8;

        [NativeTypeName("#define VK_KHR_swapchain_mutable_format 1")]
        public const int VK_KHR_swapchain_mutable_format = 1;

        [NativeTypeName("#define VK_KHR_SWAPCHAIN_MUTABLE_FORMAT_SPEC_VERSION 1")]
        public const int VK_KHR_SWAPCHAIN_MUTABLE_FORMAT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SWAPCHAIN_MUTABLE_FORMAT_EXTENSION_NAME \"VK_KHR_swapchain_mutable_format\"")]
        public static ReadOnlySpan<byte> VK_KHR_SWAPCHAIN_MUTABLE_FORMAT_EXTENSION_NAME => "VK_KHR_swapchain_mutable_format"u8;

        [NativeTypeName("#define VK_KHR_timeline_semaphore 1")]
        public const int VK_KHR_timeline_semaphore = 1;

        [NativeTypeName("#define VK_KHR_TIMELINE_SEMAPHORE_SPEC_VERSION 2")]
        public const int VK_KHR_TIMELINE_SEMAPHORE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_TIMELINE_SEMAPHORE_EXTENSION_NAME \"VK_KHR_timeline_semaphore\"")]
        public static ReadOnlySpan<byte> VK_KHR_TIMELINE_SEMAPHORE_EXTENSION_NAME => "VK_KHR_timeline_semaphore"u8;

        [NativeTypeName("#define VK_KHR_vulkan_memory_model 1")]
        public const int VK_KHR_vulkan_memory_model = 1;

        [NativeTypeName("#define VK_KHR_VULKAN_MEMORY_MODEL_SPEC_VERSION 3")]
        public const int VK_KHR_VULKAN_MEMORY_MODEL_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_KHR_VULKAN_MEMORY_MODEL_EXTENSION_NAME \"VK_KHR_vulkan_memory_model\"")]
        public static ReadOnlySpan<byte> VK_KHR_VULKAN_MEMORY_MODEL_EXTENSION_NAME => "VK_KHR_vulkan_memory_model"u8;

        [NativeTypeName("#define VK_KHR_shader_terminate_invocation 1")]
        public const int VK_KHR_shader_terminate_invocation = 1;

        [NativeTypeName("#define VK_KHR_SHADER_TERMINATE_INVOCATION_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_TERMINATE_INVOCATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_TERMINATE_INVOCATION_EXTENSION_NAME \"VK_KHR_shader_terminate_invocation\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_TERMINATE_INVOCATION_EXTENSION_NAME => "VK_KHR_shader_terminate_invocation"u8;

        [NativeTypeName("#define VK_KHR_fragment_shading_rate 1")]
        public const int VK_KHR_fragment_shading_rate = 1;

        [NativeTypeName("#define VK_KHR_FRAGMENT_SHADING_RATE_SPEC_VERSION 2")]
        public const int VK_KHR_FRAGMENT_SHADING_RATE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_FRAGMENT_SHADING_RATE_EXTENSION_NAME \"VK_KHR_fragment_shading_rate\"")]
        public static ReadOnlySpan<byte> VK_KHR_FRAGMENT_SHADING_RATE_EXTENSION_NAME => "VK_KHR_fragment_shading_rate"u8;

        [NativeTypeName("#define VK_KHR_dynamic_rendering_local_read 1")]
        public const int VK_KHR_dynamic_rendering_local_read = 1;

        [NativeTypeName("#define VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_SPEC_VERSION 1")]
        public const int VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_EXTENSION_NAME \"VK_KHR_dynamic_rendering_local_read\"")]
        public static ReadOnlySpan<byte> VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_EXTENSION_NAME => "VK_KHR_dynamic_rendering_local_read"u8;

        [NativeTypeName("#define VK_KHR_shader_quad_control 1")]
        public const int VK_KHR_shader_quad_control = 1;

        [NativeTypeName("#define VK_KHR_SHADER_QUAD_CONTROL_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_QUAD_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_QUAD_CONTROL_EXTENSION_NAME \"VK_KHR_shader_quad_control\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_QUAD_CONTROL_EXTENSION_NAME => "VK_KHR_shader_quad_control"u8;

        [NativeTypeName("#define VK_KHR_spirv_1_4 1")]
        public const int VK_KHR_spirv_1_4 = 1;

        [NativeTypeName("#define VK_KHR_SPIRV_1_4_SPEC_VERSION 1")]
        public const int VK_KHR_SPIRV_1_4_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SPIRV_1_4_EXTENSION_NAME \"VK_KHR_spirv_1_4\"")]
        public static ReadOnlySpan<byte> VK_KHR_SPIRV_1_4_EXTENSION_NAME => "VK_KHR_spirv_1_4"u8;

        [NativeTypeName("#define VK_KHR_surface_protected_capabilities 1")]
        public const int VK_KHR_surface_protected_capabilities = 1;

        [NativeTypeName("#define VK_KHR_SURFACE_PROTECTED_CAPABILITIES_SPEC_VERSION 1")]
        public const int VK_KHR_SURFACE_PROTECTED_CAPABILITIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SURFACE_PROTECTED_CAPABILITIES_EXTENSION_NAME \"VK_KHR_surface_protected_capabilities\"")]
        public static ReadOnlySpan<byte> VK_KHR_SURFACE_PROTECTED_CAPABILITIES_EXTENSION_NAME => "VK_KHR_surface_protected_capabilities"u8;

        [NativeTypeName("#define VK_KHR_separate_depth_stencil_layouts 1")]
        public const int VK_KHR_separate_depth_stencil_layouts = 1;

        [NativeTypeName("#define VK_KHR_SEPARATE_DEPTH_STENCIL_LAYOUTS_SPEC_VERSION 1")]
        public const int VK_KHR_SEPARATE_DEPTH_STENCIL_LAYOUTS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SEPARATE_DEPTH_STENCIL_LAYOUTS_EXTENSION_NAME \"VK_KHR_separate_depth_stencil_layouts\"")]
        public static ReadOnlySpan<byte> VK_KHR_SEPARATE_DEPTH_STENCIL_LAYOUTS_EXTENSION_NAME => "VK_KHR_separate_depth_stencil_layouts"u8;

        [NativeTypeName("#define VK_KHR_present_wait 1")]
        public const int VK_KHR_present_wait = 1;

        [NativeTypeName("#define VK_KHR_PRESENT_WAIT_SPEC_VERSION 1")]
        public const int VK_KHR_PRESENT_WAIT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PRESENT_WAIT_EXTENSION_NAME \"VK_KHR_present_wait\"")]
        public static ReadOnlySpan<byte> VK_KHR_PRESENT_WAIT_EXTENSION_NAME => "VK_KHR_present_wait"u8;

        [NativeTypeName("#define VK_KHR_uniform_buffer_standard_layout 1")]
        public const int VK_KHR_uniform_buffer_standard_layout = 1;

        [NativeTypeName("#define VK_KHR_UNIFORM_BUFFER_STANDARD_LAYOUT_SPEC_VERSION 1")]
        public const int VK_KHR_UNIFORM_BUFFER_STANDARD_LAYOUT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_UNIFORM_BUFFER_STANDARD_LAYOUT_EXTENSION_NAME \"VK_KHR_uniform_buffer_standard_layout\"")]
        public static ReadOnlySpan<byte> VK_KHR_UNIFORM_BUFFER_STANDARD_LAYOUT_EXTENSION_NAME => "VK_KHR_uniform_buffer_standard_layout"u8;

        [NativeTypeName("#define VK_KHR_buffer_device_address 1")]
        public const int VK_KHR_buffer_device_address = 1;

        [NativeTypeName("#define VK_KHR_BUFFER_DEVICE_ADDRESS_SPEC_VERSION 1")]
        public const int VK_KHR_BUFFER_DEVICE_ADDRESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME \"VK_KHR_buffer_device_address\"")]
        public static ReadOnlySpan<byte> VK_KHR_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME => "VK_KHR_buffer_device_address"u8;

        [NativeTypeName("#define VK_KHR_deferred_host_operations 1")]
        public const int VK_KHR_deferred_host_operations = 1;

        [NativeTypeName("#define VK_KHR_DEFERRED_HOST_OPERATIONS_SPEC_VERSION 4")]
        public const int VK_KHR_DEFERRED_HOST_OPERATIONS_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_KHR_DEFERRED_HOST_OPERATIONS_EXTENSION_NAME \"VK_KHR_deferred_host_operations\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEFERRED_HOST_OPERATIONS_EXTENSION_NAME => "VK_KHR_deferred_host_operations"u8;

        [NativeTypeName("#define VK_KHR_pipeline_executable_properties 1")]
        public const int VK_KHR_pipeline_executable_properties = 1;

        [NativeTypeName("#define VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_SPEC_VERSION 1")]
        public const int VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_EXTENSION_NAME \"VK_KHR_pipeline_executable_properties\"")]
        public static ReadOnlySpan<byte> VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_EXTENSION_NAME => "VK_KHR_pipeline_executable_properties"u8;

        [NativeTypeName("#define VK_KHR_map_memory2 1")]
        public const int VK_KHR_map_memory2 = 1;

        [NativeTypeName("#define VK_KHR_MAP_MEMORY_2_SPEC_VERSION 1")]
        public const int VK_KHR_MAP_MEMORY_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAP_MEMORY_2_EXTENSION_NAME \"VK_KHR_map_memory2\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAP_MEMORY_2_EXTENSION_NAME => "VK_KHR_map_memory2"u8;

        [NativeTypeName("#define VK_KHR_shader_integer_dot_product 1")]
        public const int VK_KHR_shader_integer_dot_product = 1;

        [NativeTypeName("#define VK_KHR_SHADER_INTEGER_DOT_PRODUCT_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_INTEGER_DOT_PRODUCT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_INTEGER_DOT_PRODUCT_EXTENSION_NAME \"VK_KHR_shader_integer_dot_product\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_INTEGER_DOT_PRODUCT_EXTENSION_NAME => "VK_KHR_shader_integer_dot_product"u8;

        [NativeTypeName("#define VK_KHR_pipeline_library 1")]
        public const int VK_KHR_pipeline_library = 1;

        [NativeTypeName("#define VK_KHR_PIPELINE_LIBRARY_SPEC_VERSION 1")]
        public const int VK_KHR_PIPELINE_LIBRARY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PIPELINE_LIBRARY_EXTENSION_NAME \"VK_KHR_pipeline_library\"")]
        public static ReadOnlySpan<byte> VK_KHR_PIPELINE_LIBRARY_EXTENSION_NAME => "VK_KHR_pipeline_library"u8;

        [NativeTypeName("#define VK_KHR_shader_non_semantic_info 1")]
        public const int VK_KHR_shader_non_semantic_info = 1;

        [NativeTypeName("#define VK_KHR_SHADER_NON_SEMANTIC_INFO_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_NON_SEMANTIC_INFO_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_NON_SEMANTIC_INFO_EXTENSION_NAME \"VK_KHR_shader_non_semantic_info\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_NON_SEMANTIC_INFO_EXTENSION_NAME => "VK_KHR_shader_non_semantic_info"u8;

        [NativeTypeName("#define VK_KHR_present_id 1")]
        public const int VK_KHR_present_id = 1;

        [NativeTypeName("#define VK_KHR_PRESENT_ID_SPEC_VERSION 1")]
        public const int VK_KHR_PRESENT_ID_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PRESENT_ID_EXTENSION_NAME \"VK_KHR_present_id\"")]
        public static ReadOnlySpan<byte> VK_KHR_PRESENT_ID_EXTENSION_NAME => "VK_KHR_present_id"u8;

        [NativeTypeName("#define VK_KHR_video_encode_queue 1")]
        public const int VK_KHR_video_encode_queue = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_QUEUE_SPEC_VERSION 12")]
        public const int VK_KHR_VIDEO_ENCODE_QUEUE_SPEC_VERSION = 12;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_QUEUE_EXTENSION_NAME \"VK_KHR_video_encode_queue\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_ENCODE_QUEUE_EXTENSION_NAME => "VK_KHR_video_encode_queue"u8;

        [NativeTypeName("#define VK_KHR_synchronization2 1")]
        public const int VK_KHR_synchronization2 = 1;

        [NativeTypeName("#define VK_KHR_SYNCHRONIZATION_2_SPEC_VERSION 1")]
        public const int VK_KHR_SYNCHRONIZATION_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SYNCHRONIZATION_2_EXTENSION_NAME \"VK_KHR_synchronization2\"")]
        public static ReadOnlySpan<byte> VK_KHR_SYNCHRONIZATION_2_EXTENSION_NAME => "VK_KHR_synchronization2"u8;

        [NativeTypeName("#define VK_KHR_fragment_shader_barycentric 1")]
        public const int VK_KHR_fragment_shader_barycentric = 1;

        [NativeTypeName("#define VK_KHR_FRAGMENT_SHADER_BARYCENTRIC_SPEC_VERSION 1")]
        public const int VK_KHR_FRAGMENT_SHADER_BARYCENTRIC_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME \"VK_KHR_fragment_shader_barycentric\"")]
        public static ReadOnlySpan<byte> VK_KHR_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME => "VK_KHR_fragment_shader_barycentric"u8;

        [NativeTypeName("#define VK_KHR_shader_subgroup_uniform_control_flow 1")]
        public const int VK_KHR_shader_subgroup_uniform_control_flow = 1;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_EXTENSION_NAME \"VK_KHR_shader_subgroup_uniform_control_flow\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_EXTENSION_NAME => "VK_KHR_shader_subgroup_uniform_control_flow"u8;

        [NativeTypeName("#define VK_KHR_zero_initialize_workgroup_memory 1")]
        public const int VK_KHR_zero_initialize_workgroup_memory = 1;

        [NativeTypeName("#define VK_KHR_ZERO_INITIALIZE_WORKGROUP_MEMORY_SPEC_VERSION 1")]
        public const int VK_KHR_ZERO_INITIALIZE_WORKGROUP_MEMORY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_ZERO_INITIALIZE_WORKGROUP_MEMORY_EXTENSION_NAME \"VK_KHR_zero_initialize_workgroup_memory\"")]
        public static ReadOnlySpan<byte> VK_KHR_ZERO_INITIALIZE_WORKGROUP_MEMORY_EXTENSION_NAME => "VK_KHR_zero_initialize_workgroup_memory"u8;

        [NativeTypeName("#define VK_KHR_workgroup_memory_explicit_layout 1")]
        public const int VK_KHR_workgroup_memory_explicit_layout = 1;

        [NativeTypeName("#define VK_KHR_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_SPEC_VERSION 1")]
        public const int VK_KHR_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_EXTENSION_NAME \"VK_KHR_workgroup_memory_explicit_layout\"")]
        public static ReadOnlySpan<byte> VK_KHR_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_EXTENSION_NAME => "VK_KHR_workgroup_memory_explicit_layout"u8;

        [NativeTypeName("#define VK_KHR_copy_commands2 1")]
        public const int VK_KHR_copy_commands2 = 1;

        [NativeTypeName("#define VK_KHR_COPY_COMMANDS_2_SPEC_VERSION 1")]
        public const int VK_KHR_COPY_COMMANDS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_COPY_COMMANDS_2_EXTENSION_NAME \"VK_KHR_copy_commands2\"")]
        public static ReadOnlySpan<byte> VK_KHR_COPY_COMMANDS_2_EXTENSION_NAME => "VK_KHR_copy_commands2"u8;

        [NativeTypeName("#define VK_KHR_format_feature_flags2 1")]
        public const int VK_KHR_format_feature_flags2 = 1;

        [NativeTypeName("#define VK_KHR_FORMAT_FEATURE_FLAGS_2_SPEC_VERSION 2")]
        public const int VK_KHR_FORMAT_FEATURE_FLAGS_2_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_FORMAT_FEATURE_FLAGS_2_EXTENSION_NAME \"VK_KHR_format_feature_flags2\"")]
        public static ReadOnlySpan<byte> VK_KHR_FORMAT_FEATURE_FLAGS_2_EXTENSION_NAME => "VK_KHR_format_feature_flags2"u8;

        [NativeTypeName("#define VK_KHR_ray_tracing_maintenance1 1")]
        public const int VK_KHR_ray_tracing_maintenance1 = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_MAINTENANCE_1_SPEC_VERSION 1")]
        public const int VK_KHR_RAY_TRACING_MAINTENANCE_1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_MAINTENANCE_1_EXTENSION_NAME \"VK_KHR_ray_tracing_maintenance1\"")]
        public static ReadOnlySpan<byte> VK_KHR_RAY_TRACING_MAINTENANCE_1_EXTENSION_NAME => "VK_KHR_ray_tracing_maintenance1"u8;

        [NativeTypeName("#define VK_KHR_portability_enumeration 1")]
        public const int VK_KHR_portability_enumeration = 1;

        [NativeTypeName("#define VK_KHR_PORTABILITY_ENUMERATION_SPEC_VERSION 1")]
        public const int VK_KHR_PORTABILITY_ENUMERATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PORTABILITY_ENUMERATION_EXTENSION_NAME \"VK_KHR_portability_enumeration\"")]
        public static ReadOnlySpan<byte> VK_KHR_PORTABILITY_ENUMERATION_EXTENSION_NAME => "VK_KHR_portability_enumeration"u8;

        [NativeTypeName("#define VK_KHR_maintenance4 1")]
        public const int VK_KHR_maintenance4 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_4_SPEC_VERSION 2")]
        public const int VK_KHR_MAINTENANCE_4_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_4_EXTENSION_NAME \"VK_KHR_maintenance4\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_4_EXTENSION_NAME => "VK_KHR_maintenance4"u8;

        [NativeTypeName("#define VK_KHR_shader_subgroup_rotate 1")]
        public const int VK_KHR_shader_subgroup_rotate = 1;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_ROTATE_SPEC_VERSION 2")]
        public const int VK_KHR_SHADER_SUBGROUP_ROTATE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_SHADER_SUBGROUP_ROTATE_EXTENSION_NAME \"VK_KHR_shader_subgroup_rotate\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_SUBGROUP_ROTATE_EXTENSION_NAME => "VK_KHR_shader_subgroup_rotate"u8;

        [NativeTypeName("#define VK_KHR_shader_maximal_reconvergence 1")]
        public const int VK_KHR_shader_maximal_reconvergence = 1;

        [NativeTypeName("#define VK_KHR_SHADER_MAXIMAL_RECONVERGENCE_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_MAXIMAL_RECONVERGENCE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_MAXIMAL_RECONVERGENCE_EXTENSION_NAME \"VK_KHR_shader_maximal_reconvergence\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_MAXIMAL_RECONVERGENCE_EXTENSION_NAME => "VK_KHR_shader_maximal_reconvergence"u8;

        [NativeTypeName("#define VK_KHR_maintenance5 1")]
        public const int VK_KHR_maintenance5 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_5_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_5_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_5_EXTENSION_NAME \"VK_KHR_maintenance5\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_5_EXTENSION_NAME => "VK_KHR_maintenance5"u8;

        [NativeTypeName("#define VK_KHR_ray_tracing_position_fetch 1")]
        public const int VK_KHR_ray_tracing_position_fetch = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_POSITION_FETCH_SPEC_VERSION 1")]
        public const int VK_KHR_RAY_TRACING_POSITION_FETCH_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_POSITION_FETCH_EXTENSION_NAME \"VK_KHR_ray_tracing_position_fetch\"")]
        public static ReadOnlySpan<byte> VK_KHR_RAY_TRACING_POSITION_FETCH_EXTENSION_NAME => "VK_KHR_ray_tracing_position_fetch"u8;

        [NativeTypeName("#define VK_KHR_pipeline_binary 1")]
        public const int VK_KHR_pipeline_binary = 1;

        [NativeTypeName("#define VK_MAX_PIPELINE_BINARY_KEY_SIZE_KHR 32U")]
        public const uint VK_MAX_PIPELINE_BINARY_KEY_SIZE_KHR = 32U;

        [NativeTypeName("#define VK_KHR_PIPELINE_BINARY_SPEC_VERSION 1")]
        public const int VK_KHR_PIPELINE_BINARY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_PIPELINE_BINARY_EXTENSION_NAME \"VK_KHR_pipeline_binary\"")]
        public static ReadOnlySpan<byte> VK_KHR_PIPELINE_BINARY_EXTENSION_NAME => "VK_KHR_pipeline_binary"u8;

        [NativeTypeName("#define VK_KHR_cooperative_matrix 1")]
        public const int VK_KHR_cooperative_matrix = 1;

        [NativeTypeName("#define VK_KHR_COOPERATIVE_MATRIX_SPEC_VERSION 2")]
        public const int VK_KHR_COOPERATIVE_MATRIX_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_COOPERATIVE_MATRIX_EXTENSION_NAME \"VK_KHR_cooperative_matrix\"")]
        public static ReadOnlySpan<byte> VK_KHR_COOPERATIVE_MATRIX_EXTENSION_NAME => "VK_KHR_cooperative_matrix"u8;

        [NativeTypeName("#define VK_KHR_compute_shader_derivatives 1")]
        public const int VK_KHR_compute_shader_derivatives = 1;

        [NativeTypeName("#define VK_KHR_COMPUTE_SHADER_DERIVATIVES_SPEC_VERSION 1")]
        public const int VK_KHR_COMPUTE_SHADER_DERIVATIVES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME \"VK_KHR_compute_shader_derivatives\"")]
        public static ReadOnlySpan<byte> VK_KHR_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME => "VK_KHR_compute_shader_derivatives"u8;

        [NativeTypeName("#define VK_KHR_video_decode_av1 1")]
        public const int VK_KHR_video_decode_av1 = 1;

        [NativeTypeName("#define VK_MAX_VIDEO_AV1_REFERENCES_PER_FRAME_KHR 7U")]
        public const uint VK_MAX_VIDEO_AV1_REFERENCES_PER_FRAME_KHR = 7U;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_AV1_SPEC_VERSION 1")]
        public const int VK_KHR_VIDEO_DECODE_AV1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_DECODE_AV1_EXTENSION_NAME \"VK_KHR_video_decode_av1\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_DECODE_AV1_EXTENSION_NAME => "VK_KHR_video_decode_av1"u8;

        [NativeTypeName("#define VK_KHR_video_encode_av1 1")]
        public const int VK_KHR_video_encode_av1 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_AV1_SPEC_VERSION 1")]
        public const int VK_KHR_VIDEO_ENCODE_AV1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_AV1_EXTENSION_NAME \"VK_KHR_video_encode_av1\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_ENCODE_AV1_EXTENSION_NAME => "VK_KHR_video_encode_av1"u8;

        [NativeTypeName("#define VK_KHR_video_maintenance1 1")]
        public const int VK_KHR_video_maintenance1 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_MAINTENANCE_1_SPEC_VERSION 1")]
        public const int VK_KHR_VIDEO_MAINTENANCE_1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_MAINTENANCE_1_EXTENSION_NAME \"VK_KHR_video_maintenance1\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_MAINTENANCE_1_EXTENSION_NAME => "VK_KHR_video_maintenance1"u8;

        [NativeTypeName("#define VK_KHR_vertex_attribute_divisor 1")]
        public const int VK_KHR_vertex_attribute_divisor = 1;

        [NativeTypeName("#define VK_KHR_VERTEX_ATTRIBUTE_DIVISOR_SPEC_VERSION 1")]
        public const int VK_KHR_VERTEX_ATTRIBUTE_DIVISOR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME \"VK_KHR_vertex_attribute_divisor\"")]
        public static ReadOnlySpan<byte> VK_KHR_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME => "VK_KHR_vertex_attribute_divisor"u8;

        [NativeTypeName("#define VK_KHR_load_store_op_none 1")]
        public const int VK_KHR_load_store_op_none = 1;

        [NativeTypeName("#define VK_KHR_LOAD_STORE_OP_NONE_SPEC_VERSION 1")]
        public const int VK_KHR_LOAD_STORE_OP_NONE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_LOAD_STORE_OP_NONE_EXTENSION_NAME \"VK_KHR_load_store_op_none\"")]
        public static ReadOnlySpan<byte> VK_KHR_LOAD_STORE_OP_NONE_EXTENSION_NAME => "VK_KHR_load_store_op_none"u8;

        [NativeTypeName("#define VK_KHR_shader_float_controls2 1")]
        public const int VK_KHR_shader_float_controls2 = 1;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT_CONTROLS_2_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_FLOAT_CONTROLS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_FLOAT_CONTROLS_2_EXTENSION_NAME \"VK_KHR_shader_float_controls2\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_FLOAT_CONTROLS_2_EXTENSION_NAME => "VK_KHR_shader_float_controls2"u8;

        [NativeTypeName("#define VK_KHR_index_type_uint8 1")]
        public const int VK_KHR_index_type_uint8 = 1;

        [NativeTypeName("#define VK_KHR_INDEX_TYPE_UINT8_SPEC_VERSION 1")]
        public const int VK_KHR_INDEX_TYPE_UINT8_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_INDEX_TYPE_UINT8_EXTENSION_NAME \"VK_KHR_index_type_uint8\"")]
        public static ReadOnlySpan<byte> VK_KHR_INDEX_TYPE_UINT8_EXTENSION_NAME => "VK_KHR_index_type_uint8"u8;

        [NativeTypeName("#define VK_KHR_line_rasterization 1")]
        public const int VK_KHR_line_rasterization = 1;

        [NativeTypeName("#define VK_KHR_LINE_RASTERIZATION_SPEC_VERSION 1")]
        public const int VK_KHR_LINE_RASTERIZATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_LINE_RASTERIZATION_EXTENSION_NAME \"VK_KHR_line_rasterization\"")]
        public static ReadOnlySpan<byte> VK_KHR_LINE_RASTERIZATION_EXTENSION_NAME => "VK_KHR_line_rasterization"u8;

        [NativeTypeName("#define VK_KHR_calibrated_timestamps 1")]
        public const int VK_KHR_calibrated_timestamps = 1;

        [NativeTypeName("#define VK_KHR_CALIBRATED_TIMESTAMPS_SPEC_VERSION 1")]
        public const int VK_KHR_CALIBRATED_TIMESTAMPS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_CALIBRATED_TIMESTAMPS_EXTENSION_NAME \"VK_KHR_calibrated_timestamps\"")]
        public static ReadOnlySpan<byte> VK_KHR_CALIBRATED_TIMESTAMPS_EXTENSION_NAME => "VK_KHR_calibrated_timestamps"u8;

        [NativeTypeName("#define VK_KHR_shader_expect_assume 1")]
        public const int VK_KHR_shader_expect_assume = 1;

        [NativeTypeName("#define VK_KHR_SHADER_EXPECT_ASSUME_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_EXPECT_ASSUME_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_EXPECT_ASSUME_EXTENSION_NAME \"VK_KHR_shader_expect_assume\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_EXPECT_ASSUME_EXTENSION_NAME => "VK_KHR_shader_expect_assume"u8;

        [NativeTypeName("#define VK_KHR_maintenance6 1")]
        public const int VK_KHR_maintenance6 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_6_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_6_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_6_EXTENSION_NAME \"VK_KHR_maintenance6\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_6_EXTENSION_NAME => "VK_KHR_maintenance6"u8;

        [NativeTypeName("#define VK_KHR_video_encode_quantization_map 1")]
        public const int VK_KHR_video_encode_quantization_map = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_QUANTIZATION_MAP_SPEC_VERSION 2")]
        public const int VK_KHR_VIDEO_ENCODE_QUANTIZATION_MAP_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_KHR_VIDEO_ENCODE_QUANTIZATION_MAP_EXTENSION_NAME \"VK_KHR_video_encode_quantization_map\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_ENCODE_QUANTIZATION_MAP_EXTENSION_NAME => "VK_KHR_video_encode_quantization_map"u8;

        [NativeTypeName("#define VK_KHR_shader_relaxed_extended_instruction 1")]
        public const int VK_KHR_shader_relaxed_extended_instruction = 1;

        [NativeTypeName("#define VK_KHR_SHADER_RELAXED_EXTENDED_INSTRUCTION_SPEC_VERSION 1")]
        public const int VK_KHR_SHADER_RELAXED_EXTENDED_INSTRUCTION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_SHADER_RELAXED_EXTENDED_INSTRUCTION_EXTENSION_NAME \"VK_KHR_shader_relaxed_extended_instruction\"")]
        public static ReadOnlySpan<byte> VK_KHR_SHADER_RELAXED_EXTENDED_INSTRUCTION_EXTENSION_NAME => "VK_KHR_shader_relaxed_extended_instruction"u8;

        [NativeTypeName("#define VK_KHR_maintenance7 1")]
        public const int VK_KHR_maintenance7 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_7_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_7_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_7_EXTENSION_NAME \"VK_KHR_maintenance7\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_7_EXTENSION_NAME => "VK_KHR_maintenance7"u8;

        [NativeTypeName("#define VK_KHR_maintenance8 1")]
        public const int VK_KHR_maintenance8 = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_8_SPEC_VERSION 1")]
        public const int VK_KHR_MAINTENANCE_8_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_MAINTENANCE_8_EXTENSION_NAME \"VK_KHR_maintenance8\"")]
        public static ReadOnlySpan<byte> VK_KHR_MAINTENANCE_8_EXTENSION_NAME => "VK_KHR_maintenance8"u8;

        [NativeTypeName("#define VK_KHR_video_maintenance2 1")]
        public const int VK_KHR_video_maintenance2 = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_MAINTENANCE_2_SPEC_VERSION 1")]
        public const int VK_KHR_VIDEO_MAINTENANCE_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_VIDEO_MAINTENANCE_2_EXTENSION_NAME \"VK_KHR_video_maintenance2\"")]
        public static ReadOnlySpan<byte> VK_KHR_VIDEO_MAINTENANCE_2_EXTENSION_NAME => "VK_KHR_video_maintenance2"u8;

        [NativeTypeName("#define VK_KHR_depth_clamp_zero_one 1")]
        public const int VK_KHR_depth_clamp_zero_one = 1;

        [NativeTypeName("#define VK_KHR_DEPTH_CLAMP_ZERO_ONE_SPEC_VERSION 1")]
        public const int VK_KHR_DEPTH_CLAMP_ZERO_ONE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME \"VK_KHR_depth_clamp_zero_one\"")]
        public static ReadOnlySpan<byte> VK_KHR_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME => "VK_KHR_depth_clamp_zero_one"u8;

        [NativeTypeName("#define VK_EXT_debug_report 1")]
        public const int VK_EXT_debug_report = 1;

        [NativeTypeName("#define VK_EXT_DEBUG_REPORT_SPEC_VERSION 10")]
        public const int VK_EXT_DEBUG_REPORT_SPEC_VERSION = 10;

        [NativeTypeName("#define VK_EXT_DEBUG_REPORT_EXTENSION_NAME \"VK_EXT_debug_report\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEBUG_REPORT_EXTENSION_NAME => "VK_EXT_debug_report"u8;

        [NativeTypeName("#define VK_NV_glsl_shader 1")]
        public const int VK_NV_glsl_shader = 1;

        [NativeTypeName("#define VK_NV_GLSL_SHADER_SPEC_VERSION 1")]
        public const int VK_NV_GLSL_SHADER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_GLSL_SHADER_EXTENSION_NAME \"VK_NV_glsl_shader\"")]
        public static ReadOnlySpan<byte> VK_NV_GLSL_SHADER_EXTENSION_NAME => "VK_NV_glsl_shader"u8;

        [NativeTypeName("#define VK_EXT_depth_range_unrestricted 1")]
        public const int VK_EXT_depth_range_unrestricted = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_RANGE_UNRESTRICTED_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_RANGE_UNRESTRICTED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_RANGE_UNRESTRICTED_EXTENSION_NAME \"VK_EXT_depth_range_unrestricted\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_RANGE_UNRESTRICTED_EXTENSION_NAME => "VK_EXT_depth_range_unrestricted"u8;

        [NativeTypeName("#define VK_IMG_filter_cubic 1")]
        public const int VK_IMG_filter_cubic = 1;

        [NativeTypeName("#define VK_IMG_FILTER_CUBIC_SPEC_VERSION 1")]
        public const int VK_IMG_FILTER_CUBIC_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_IMG_FILTER_CUBIC_EXTENSION_NAME \"VK_IMG_filter_cubic\"")]
        public static ReadOnlySpan<byte> VK_IMG_FILTER_CUBIC_EXTENSION_NAME => "VK_IMG_filter_cubic"u8;

        [NativeTypeName("#define VK_AMD_rasterization_order 1")]
        public const int VK_AMD_rasterization_order = 1;

        [NativeTypeName("#define VK_AMD_RASTERIZATION_ORDER_SPEC_VERSION 1")]
        public const int VK_AMD_RASTERIZATION_ORDER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_RASTERIZATION_ORDER_EXTENSION_NAME \"VK_AMD_rasterization_order\"")]
        public static ReadOnlySpan<byte> VK_AMD_RASTERIZATION_ORDER_EXTENSION_NAME => "VK_AMD_rasterization_order"u8;

        [NativeTypeName("#define VK_AMD_shader_trinary_minmax 1")]
        public const int VK_AMD_shader_trinary_minmax = 1;

        [NativeTypeName("#define VK_AMD_SHADER_TRINARY_MINMAX_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_TRINARY_MINMAX_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_TRINARY_MINMAX_EXTENSION_NAME \"VK_AMD_shader_trinary_minmax\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_TRINARY_MINMAX_EXTENSION_NAME => "VK_AMD_shader_trinary_minmax"u8;

        [NativeTypeName("#define VK_AMD_shader_explicit_vertex_parameter 1")]
        public const int VK_AMD_shader_explicit_vertex_parameter = 1;

        [NativeTypeName("#define VK_AMD_SHADER_EXPLICIT_VERTEX_PARAMETER_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_EXPLICIT_VERTEX_PARAMETER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_EXPLICIT_VERTEX_PARAMETER_EXTENSION_NAME \"VK_AMD_shader_explicit_vertex_parameter\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_EXPLICIT_VERTEX_PARAMETER_EXTENSION_NAME => "VK_AMD_shader_explicit_vertex_parameter"u8;

        [NativeTypeName("#define VK_EXT_debug_marker 1")]
        public const int VK_EXT_debug_marker = 1;

        [NativeTypeName("#define VK_EXT_DEBUG_MARKER_SPEC_VERSION 4")]
        public const int VK_EXT_DEBUG_MARKER_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_EXT_DEBUG_MARKER_EXTENSION_NAME \"VK_EXT_debug_marker\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEBUG_MARKER_EXTENSION_NAME => "VK_EXT_debug_marker"u8;

        [NativeTypeName("#define VK_AMD_gcn_shader 1")]
        public const int VK_AMD_gcn_shader = 1;

        [NativeTypeName("#define VK_AMD_GCN_SHADER_SPEC_VERSION 1")]
        public const int VK_AMD_GCN_SHADER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_GCN_SHADER_EXTENSION_NAME \"VK_AMD_gcn_shader\"")]
        public static ReadOnlySpan<byte> VK_AMD_GCN_SHADER_EXTENSION_NAME => "VK_AMD_gcn_shader"u8;

        [NativeTypeName("#define VK_NV_dedicated_allocation 1")]
        public const int VK_NV_dedicated_allocation = 1;

        [NativeTypeName("#define VK_NV_DEDICATED_ALLOCATION_SPEC_VERSION 1")]
        public const int VK_NV_DEDICATED_ALLOCATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_DEDICATED_ALLOCATION_EXTENSION_NAME \"VK_NV_dedicated_allocation\"")]
        public static ReadOnlySpan<byte> VK_NV_DEDICATED_ALLOCATION_EXTENSION_NAME => "VK_NV_dedicated_allocation"u8;

        [NativeTypeName("#define VK_EXT_transform_feedback 1")]
        public const int VK_EXT_transform_feedback = 1;

        [NativeTypeName("#define VK_EXT_TRANSFORM_FEEDBACK_SPEC_VERSION 1")]
        public const int VK_EXT_TRANSFORM_FEEDBACK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_TRANSFORM_FEEDBACK_EXTENSION_NAME \"VK_EXT_transform_feedback\"")]
        public static ReadOnlySpan<byte> VK_EXT_TRANSFORM_FEEDBACK_EXTENSION_NAME => "VK_EXT_transform_feedback"u8;

        [NativeTypeName("#define VK_NVX_binary_import 1")]
        public const int VK_NVX_binary_import = 1;

        [NativeTypeName("#define VK_NVX_BINARY_IMPORT_SPEC_VERSION 2")]
        public const int VK_NVX_BINARY_IMPORT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NVX_BINARY_IMPORT_EXTENSION_NAME \"VK_NVX_binary_import\"")]
        public static ReadOnlySpan<byte> VK_NVX_BINARY_IMPORT_EXTENSION_NAME => "VK_NVX_binary_import"u8;

        [NativeTypeName("#define VK_NVX_image_view_handle 1")]
        public const int VK_NVX_image_view_handle = 1;

        [NativeTypeName("#define VK_NVX_IMAGE_VIEW_HANDLE_SPEC_VERSION 3")]
        public const int VK_NVX_IMAGE_VIEW_HANDLE_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_NVX_IMAGE_VIEW_HANDLE_EXTENSION_NAME \"VK_NVX_image_view_handle\"")]
        public static ReadOnlySpan<byte> VK_NVX_IMAGE_VIEW_HANDLE_EXTENSION_NAME => "VK_NVX_image_view_handle"u8;

        [NativeTypeName("#define VK_AMD_draw_indirect_count 1")]
        public const int VK_AMD_draw_indirect_count = 1;

        [NativeTypeName("#define VK_AMD_DRAW_INDIRECT_COUNT_SPEC_VERSION 2")]
        public const int VK_AMD_DRAW_INDIRECT_COUNT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_AMD_DRAW_INDIRECT_COUNT_EXTENSION_NAME \"VK_AMD_draw_indirect_count\"")]
        public static ReadOnlySpan<byte> VK_AMD_DRAW_INDIRECT_COUNT_EXTENSION_NAME => "VK_AMD_draw_indirect_count"u8;

        [NativeTypeName("#define VK_AMD_negative_viewport_height 1")]
        public const int VK_AMD_negative_viewport_height = 1;

        [NativeTypeName("#define VK_AMD_NEGATIVE_VIEWPORT_HEIGHT_SPEC_VERSION 1")]
        public const int VK_AMD_NEGATIVE_VIEWPORT_HEIGHT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_NEGATIVE_VIEWPORT_HEIGHT_EXTENSION_NAME \"VK_AMD_negative_viewport_height\"")]
        public static ReadOnlySpan<byte> VK_AMD_NEGATIVE_VIEWPORT_HEIGHT_EXTENSION_NAME => "VK_AMD_negative_viewport_height"u8;

        [NativeTypeName("#define VK_AMD_gpu_shader_half_float 1")]
        public const int VK_AMD_gpu_shader_half_float = 1;

        [NativeTypeName("#define VK_AMD_GPU_SHADER_HALF_FLOAT_SPEC_VERSION 2")]
        public const int VK_AMD_GPU_SHADER_HALF_FLOAT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_AMD_GPU_SHADER_HALF_FLOAT_EXTENSION_NAME \"VK_AMD_gpu_shader_half_float\"")]
        public static ReadOnlySpan<byte> VK_AMD_GPU_SHADER_HALF_FLOAT_EXTENSION_NAME => "VK_AMD_gpu_shader_half_float"u8;

        [NativeTypeName("#define VK_AMD_shader_ballot 1")]
        public const int VK_AMD_shader_ballot = 1;

        [NativeTypeName("#define VK_AMD_SHADER_BALLOT_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_BALLOT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_BALLOT_EXTENSION_NAME \"VK_AMD_shader_ballot\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_BALLOT_EXTENSION_NAME => "VK_AMD_shader_ballot"u8;

        [NativeTypeName("#define VK_AMD_texture_gather_bias_lod 1")]
        public const int VK_AMD_texture_gather_bias_lod = 1;

        [NativeTypeName("#define VK_AMD_TEXTURE_GATHER_BIAS_LOD_SPEC_VERSION 1")]
        public const int VK_AMD_TEXTURE_GATHER_BIAS_LOD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_TEXTURE_GATHER_BIAS_LOD_EXTENSION_NAME \"VK_AMD_texture_gather_bias_lod\"")]
        public static ReadOnlySpan<byte> VK_AMD_TEXTURE_GATHER_BIAS_LOD_EXTENSION_NAME => "VK_AMD_texture_gather_bias_lod"u8;

        [NativeTypeName("#define VK_AMD_shader_info 1")]
        public const int VK_AMD_shader_info = 1;

        [NativeTypeName("#define VK_AMD_SHADER_INFO_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_INFO_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_INFO_EXTENSION_NAME \"VK_AMD_shader_info\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_INFO_EXTENSION_NAME => "VK_AMD_shader_info"u8;

        [NativeTypeName("#define VK_AMD_shader_image_load_store_lod 1")]
        public const int VK_AMD_shader_image_load_store_lod = 1;

        [NativeTypeName("#define VK_AMD_SHADER_IMAGE_LOAD_STORE_LOD_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_IMAGE_LOAD_STORE_LOD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_IMAGE_LOAD_STORE_LOD_EXTENSION_NAME \"VK_AMD_shader_image_load_store_lod\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_IMAGE_LOAD_STORE_LOD_EXTENSION_NAME => "VK_AMD_shader_image_load_store_lod"u8;

        [NativeTypeName("#define VK_NV_corner_sampled_image 1")]
        public const int VK_NV_corner_sampled_image = 1;

        [NativeTypeName("#define VK_NV_CORNER_SAMPLED_IMAGE_SPEC_VERSION 2")]
        public const int VK_NV_CORNER_SAMPLED_IMAGE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_CORNER_SAMPLED_IMAGE_EXTENSION_NAME \"VK_NV_corner_sampled_image\"")]
        public static ReadOnlySpan<byte> VK_NV_CORNER_SAMPLED_IMAGE_EXTENSION_NAME => "VK_NV_corner_sampled_image"u8;

        [NativeTypeName("#define VK_IMG_format_pvrtc 1")]
        public const int VK_IMG_format_pvrtc = 1;

        [NativeTypeName("#define VK_IMG_FORMAT_PVRTC_SPEC_VERSION 1")]
        public const int VK_IMG_FORMAT_PVRTC_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_IMG_FORMAT_PVRTC_EXTENSION_NAME \"VK_IMG_format_pvrtc\"")]
        public static ReadOnlySpan<byte> VK_IMG_FORMAT_PVRTC_EXTENSION_NAME => "VK_IMG_format_pvrtc"u8;

        [NativeTypeName("#define VK_NV_external_memory_capabilities 1")]
        public const int VK_NV_external_memory_capabilities = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_CAPABILITIES_SPEC_VERSION 1")]
        public const int VK_NV_EXTERNAL_MEMORY_CAPABILITIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME \"VK_NV_external_memory_capabilities\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME => "VK_NV_external_memory_capabilities"u8;

        [NativeTypeName("#define VK_NV_external_memory 1")]
        public const int VK_NV_external_memory = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_SPEC_VERSION 1")]
        public const int VK_NV_EXTERNAL_MEMORY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_EXTENSION_NAME \"VK_NV_external_memory\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTERNAL_MEMORY_EXTENSION_NAME => "VK_NV_external_memory"u8;

        [NativeTypeName("#define VK_EXT_validation_flags 1")]
        public const int VK_EXT_validation_flags = 1;

        [NativeTypeName("#define VK_EXT_VALIDATION_FLAGS_SPEC_VERSION 3")]
        public const int VK_EXT_VALIDATION_FLAGS_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_EXT_VALIDATION_FLAGS_EXTENSION_NAME \"VK_EXT_validation_flags\"")]
        public static ReadOnlySpan<byte> VK_EXT_VALIDATION_FLAGS_EXTENSION_NAME => "VK_EXT_validation_flags"u8;

        [NativeTypeName("#define VK_EXT_shader_subgroup_ballot 1")]
        public const int VK_EXT_shader_subgroup_ballot = 1;

        [NativeTypeName("#define VK_EXT_SHADER_SUBGROUP_BALLOT_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_SUBGROUP_BALLOT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_SUBGROUP_BALLOT_EXTENSION_NAME \"VK_EXT_shader_subgroup_ballot\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_SUBGROUP_BALLOT_EXTENSION_NAME => "VK_EXT_shader_subgroup_ballot"u8;

        [NativeTypeName("#define VK_EXT_shader_subgroup_vote 1")]
        public const int VK_EXT_shader_subgroup_vote = 1;

        [NativeTypeName("#define VK_EXT_SHADER_SUBGROUP_VOTE_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_SUBGROUP_VOTE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_SUBGROUP_VOTE_EXTENSION_NAME \"VK_EXT_shader_subgroup_vote\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_SUBGROUP_VOTE_EXTENSION_NAME => "VK_EXT_shader_subgroup_vote"u8;

        [NativeTypeName("#define VK_EXT_texture_compression_astc_hdr 1")]
        public const int VK_EXT_texture_compression_astc_hdr = 1;

        [NativeTypeName("#define VK_EXT_TEXTURE_COMPRESSION_ASTC_HDR_SPEC_VERSION 1")]
        public const int VK_EXT_TEXTURE_COMPRESSION_ASTC_HDR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_TEXTURE_COMPRESSION_ASTC_HDR_EXTENSION_NAME \"VK_EXT_texture_compression_astc_hdr\"")]
        public static ReadOnlySpan<byte> VK_EXT_TEXTURE_COMPRESSION_ASTC_HDR_EXTENSION_NAME => "VK_EXT_texture_compression_astc_hdr"u8;

        [NativeTypeName("#define VK_EXT_astc_decode_mode 1")]
        public const int VK_EXT_astc_decode_mode = 1;

        [NativeTypeName("#define VK_EXT_ASTC_DECODE_MODE_SPEC_VERSION 1")]
        public const int VK_EXT_ASTC_DECODE_MODE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_ASTC_DECODE_MODE_EXTENSION_NAME \"VK_EXT_astc_decode_mode\"")]
        public static ReadOnlySpan<byte> VK_EXT_ASTC_DECODE_MODE_EXTENSION_NAME => "VK_EXT_astc_decode_mode"u8;

        [NativeTypeName("#define VK_EXT_pipeline_robustness 1")]
        public const int VK_EXT_pipeline_robustness = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_ROBUSTNESS_SPEC_VERSION 1")]
        public const int VK_EXT_PIPELINE_ROBUSTNESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_ROBUSTNESS_EXTENSION_NAME \"VK_EXT_pipeline_robustness\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_ROBUSTNESS_EXTENSION_NAME => "VK_EXT_pipeline_robustness"u8;

        [NativeTypeName("#define VK_EXT_conditional_rendering 1")]
        public const int VK_EXT_conditional_rendering = 1;

        [NativeTypeName("#define VK_EXT_CONDITIONAL_RENDERING_SPEC_VERSION 2")]
        public const int VK_EXT_CONDITIONAL_RENDERING_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_CONDITIONAL_RENDERING_EXTENSION_NAME \"VK_EXT_conditional_rendering\"")]
        public static ReadOnlySpan<byte> VK_EXT_CONDITIONAL_RENDERING_EXTENSION_NAME => "VK_EXT_conditional_rendering"u8;

        [NativeTypeName("#define VK_NV_clip_space_w_scaling 1")]
        public const int VK_NV_clip_space_w_scaling = 1;

        [NativeTypeName("#define VK_NV_CLIP_SPACE_W_SCALING_SPEC_VERSION 1")]
        public const int VK_NV_CLIP_SPACE_W_SCALING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_CLIP_SPACE_W_SCALING_EXTENSION_NAME \"VK_NV_clip_space_w_scaling\"")]
        public static ReadOnlySpan<byte> VK_NV_CLIP_SPACE_W_SCALING_EXTENSION_NAME => "VK_NV_clip_space_w_scaling"u8;

        [NativeTypeName("#define VK_EXT_direct_mode_display 1")]
        public const int VK_EXT_direct_mode_display = 1;

        [NativeTypeName("#define VK_EXT_DIRECT_MODE_DISPLAY_SPEC_VERSION 1")]
        public const int VK_EXT_DIRECT_MODE_DISPLAY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DIRECT_MODE_DISPLAY_EXTENSION_NAME \"VK_EXT_direct_mode_display\"")]
        public static ReadOnlySpan<byte> VK_EXT_DIRECT_MODE_DISPLAY_EXTENSION_NAME => "VK_EXT_direct_mode_display"u8;

        [NativeTypeName("#define VK_EXT_display_surface_counter 1")]
        public const int VK_EXT_display_surface_counter = 1;

        [NativeTypeName("#define VK_EXT_DISPLAY_SURFACE_COUNTER_SPEC_VERSION 1")]
        public const int VK_EXT_DISPLAY_SURFACE_COUNTER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DISPLAY_SURFACE_COUNTER_EXTENSION_NAME \"VK_EXT_display_surface_counter\"")]
        public static ReadOnlySpan<byte> VK_EXT_DISPLAY_SURFACE_COUNTER_EXTENSION_NAME => "VK_EXT_display_surface_counter"u8;

        [NativeTypeName("#define VK_EXT_display_control 1")]
        public const int VK_EXT_display_control = 1;

        [NativeTypeName("#define VK_EXT_DISPLAY_CONTROL_SPEC_VERSION 1")]
        public const int VK_EXT_DISPLAY_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DISPLAY_CONTROL_EXTENSION_NAME \"VK_EXT_display_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_DISPLAY_CONTROL_EXTENSION_NAME => "VK_EXT_display_control"u8;

        [NativeTypeName("#define VK_GOOGLE_display_timing 1")]
        public const int VK_GOOGLE_display_timing = 1;

        [NativeTypeName("#define VK_GOOGLE_DISPLAY_TIMING_SPEC_VERSION 1")]
        public const int VK_GOOGLE_DISPLAY_TIMING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_GOOGLE_DISPLAY_TIMING_EXTENSION_NAME \"VK_GOOGLE_display_timing\"")]
        public static ReadOnlySpan<byte> VK_GOOGLE_DISPLAY_TIMING_EXTENSION_NAME => "VK_GOOGLE_display_timing"u8;

        [NativeTypeName("#define VK_NV_sample_mask_override_coverage 1")]
        public const int VK_NV_sample_mask_override_coverage = 1;

        [NativeTypeName("#define VK_NV_SAMPLE_MASK_OVERRIDE_COVERAGE_SPEC_VERSION 1")]
        public const int VK_NV_SAMPLE_MASK_OVERRIDE_COVERAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_SAMPLE_MASK_OVERRIDE_COVERAGE_EXTENSION_NAME \"VK_NV_sample_mask_override_coverage\"")]
        public static ReadOnlySpan<byte> VK_NV_SAMPLE_MASK_OVERRIDE_COVERAGE_EXTENSION_NAME => "VK_NV_sample_mask_override_coverage"u8;

        [NativeTypeName("#define VK_NV_geometry_shader_passthrough 1")]
        public const int VK_NV_geometry_shader_passthrough = 1;

        [NativeTypeName("#define VK_NV_GEOMETRY_SHADER_PASSTHROUGH_SPEC_VERSION 1")]
        public const int VK_NV_GEOMETRY_SHADER_PASSTHROUGH_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_GEOMETRY_SHADER_PASSTHROUGH_EXTENSION_NAME \"VK_NV_geometry_shader_passthrough\"")]
        public static ReadOnlySpan<byte> VK_NV_GEOMETRY_SHADER_PASSTHROUGH_EXTENSION_NAME => "VK_NV_geometry_shader_passthrough"u8;

        [NativeTypeName("#define VK_NV_viewport_array2 1")]
        public const int VK_NV_viewport_array2 = 1;

        [NativeTypeName("#define VK_NV_VIEWPORT_ARRAY_2_SPEC_VERSION 1")]
        public const int VK_NV_VIEWPORT_ARRAY_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_VIEWPORT_ARRAY_2_EXTENSION_NAME \"VK_NV_viewport_array2\"")]
        public static ReadOnlySpan<byte> VK_NV_VIEWPORT_ARRAY_2_EXTENSION_NAME => "VK_NV_viewport_array2"u8;

        [NativeTypeName("#define VK_NV_VIEWPORT_ARRAY2_SPEC_VERSION VK_NV_VIEWPORT_ARRAY_2_SPEC_VERSION")]
        public const int VK_NV_VIEWPORT_ARRAY2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_VIEWPORT_ARRAY2_EXTENSION_NAME VK_NV_VIEWPORT_ARRAY_2_EXTENSION_NAME")]
        public static ReadOnlySpan<byte> VK_NV_VIEWPORT_ARRAY2_EXTENSION_NAME => "VK_NV_viewport_array2"u8;

        [NativeTypeName("#define VK_NVX_multiview_per_view_attributes 1")]
        public const int VK_NVX_multiview_per_view_attributes = 1;

        [NativeTypeName("#define VK_NVX_MULTIVIEW_PER_VIEW_ATTRIBUTES_SPEC_VERSION 1")]
        public const int VK_NVX_MULTIVIEW_PER_VIEW_ATTRIBUTES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NVX_MULTIVIEW_PER_VIEW_ATTRIBUTES_EXTENSION_NAME \"VK_NVX_multiview_per_view_attributes\"")]
        public static ReadOnlySpan<byte> VK_NVX_MULTIVIEW_PER_VIEW_ATTRIBUTES_EXTENSION_NAME => "VK_NVX_multiview_per_view_attributes"u8;

        [NativeTypeName("#define VK_NV_viewport_swizzle 1")]
        public const int VK_NV_viewport_swizzle = 1;

        [NativeTypeName("#define VK_NV_VIEWPORT_SWIZZLE_SPEC_VERSION 1")]
        public const int VK_NV_VIEWPORT_SWIZZLE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_VIEWPORT_SWIZZLE_EXTENSION_NAME \"VK_NV_viewport_swizzle\"")]
        public static ReadOnlySpan<byte> VK_NV_VIEWPORT_SWIZZLE_EXTENSION_NAME => "VK_NV_viewport_swizzle"u8;

        [NativeTypeName("#define VK_EXT_discard_rectangles 1")]
        public const int VK_EXT_discard_rectangles = 1;

        [NativeTypeName("#define VK_EXT_DISCARD_RECTANGLES_SPEC_VERSION 2")]
        public const int VK_EXT_DISCARD_RECTANGLES_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_DISCARD_RECTANGLES_EXTENSION_NAME \"VK_EXT_discard_rectangles\"")]
        public static ReadOnlySpan<byte> VK_EXT_DISCARD_RECTANGLES_EXTENSION_NAME => "VK_EXT_discard_rectangles"u8;

        [NativeTypeName("#define VK_EXT_conservative_rasterization 1")]
        public const int VK_EXT_conservative_rasterization = 1;

        [NativeTypeName("#define VK_EXT_CONSERVATIVE_RASTERIZATION_SPEC_VERSION 1")]
        public const int VK_EXT_CONSERVATIVE_RASTERIZATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_CONSERVATIVE_RASTERIZATION_EXTENSION_NAME \"VK_EXT_conservative_rasterization\"")]
        public static ReadOnlySpan<byte> VK_EXT_CONSERVATIVE_RASTERIZATION_EXTENSION_NAME => "VK_EXT_conservative_rasterization"u8;

        [NativeTypeName("#define VK_EXT_depth_clip_enable 1")]
        public const int VK_EXT_depth_clip_enable = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLIP_ENABLE_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_CLIP_ENABLE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLIP_ENABLE_EXTENSION_NAME \"VK_EXT_depth_clip_enable\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_CLIP_ENABLE_EXTENSION_NAME => "VK_EXT_depth_clip_enable"u8;

        [NativeTypeName("#define VK_EXT_swapchain_colorspace 1")]
        public const int VK_EXT_swapchain_colorspace = 1;

        [NativeTypeName("#define VK_EXT_SWAPCHAIN_COLOR_SPACE_SPEC_VERSION 5")]
        public const int VK_EXT_SWAPCHAIN_COLOR_SPACE_SPEC_VERSION = 5;

        [NativeTypeName("#define VK_EXT_SWAPCHAIN_COLOR_SPACE_EXTENSION_NAME \"VK_EXT_swapchain_colorspace\"")]
        public static ReadOnlySpan<byte> VK_EXT_SWAPCHAIN_COLOR_SPACE_EXTENSION_NAME => "VK_EXT_swapchain_colorspace"u8;

        [NativeTypeName("#define VK_EXT_hdr_metadata 1")]
        public const int VK_EXT_hdr_metadata = 1;

        [NativeTypeName("#define VK_EXT_HDR_METADATA_SPEC_VERSION 3")]
        public const int VK_EXT_HDR_METADATA_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_EXT_HDR_METADATA_EXTENSION_NAME \"VK_EXT_hdr_metadata\"")]
        public static ReadOnlySpan<byte> VK_EXT_HDR_METADATA_EXTENSION_NAME => "VK_EXT_hdr_metadata"u8;

        [NativeTypeName("#define VK_IMG_relaxed_line_rasterization 1")]
        public const int VK_IMG_relaxed_line_rasterization = 1;

        [NativeTypeName("#define VK_IMG_RELAXED_LINE_RASTERIZATION_SPEC_VERSION 1")]
        public const int VK_IMG_RELAXED_LINE_RASTERIZATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_IMG_RELAXED_LINE_RASTERIZATION_EXTENSION_NAME \"VK_IMG_relaxed_line_rasterization\"")]
        public static ReadOnlySpan<byte> VK_IMG_RELAXED_LINE_RASTERIZATION_EXTENSION_NAME => "VK_IMG_relaxed_line_rasterization"u8;

        [NativeTypeName("#define VK_EXT_external_memory_dma_buf 1")]
        public const int VK_EXT_external_memory_dma_buf = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_DMA_BUF_SPEC_VERSION 1")]
        public const int VK_EXT_EXTERNAL_MEMORY_DMA_BUF_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_DMA_BUF_EXTENSION_NAME \"VK_EXT_external_memory_dma_buf\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTERNAL_MEMORY_DMA_BUF_EXTENSION_NAME => "VK_EXT_external_memory_dma_buf"u8;

        [NativeTypeName("#define VK_EXT_queue_family_foreign 1")]
        public const int VK_EXT_queue_family_foreign = 1;

        [NativeTypeName("#define VK_EXT_QUEUE_FAMILY_FOREIGN_SPEC_VERSION 1")]
        public const int VK_EXT_QUEUE_FAMILY_FOREIGN_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_QUEUE_FAMILY_FOREIGN_EXTENSION_NAME \"VK_EXT_queue_family_foreign\"")]
        public static ReadOnlySpan<byte> VK_EXT_QUEUE_FAMILY_FOREIGN_EXTENSION_NAME => "VK_EXT_queue_family_foreign"u8;

        [NativeTypeName("#define VK_QUEUE_FAMILY_FOREIGN_EXT (~2U)")]
        public const uint VK_QUEUE_FAMILY_FOREIGN_EXT = (~2U);

        [NativeTypeName("#define VK_EXT_debug_utils 1")]
        public const int VK_EXT_debug_utils = 1;

        [NativeTypeName("#define VK_EXT_DEBUG_UTILS_SPEC_VERSION 2")]
        public const int VK_EXT_DEBUG_UTILS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_DEBUG_UTILS_EXTENSION_NAME \"VK_EXT_debug_utils\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEBUG_UTILS_EXTENSION_NAME => "VK_EXT_debug_utils"u8;

        [NativeTypeName("#define VK_EXT_sampler_filter_minmax 1")]
        public const int VK_EXT_sampler_filter_minmax = 1;

        [NativeTypeName("#define VK_EXT_SAMPLER_FILTER_MINMAX_SPEC_VERSION 2")]
        public const int VK_EXT_SAMPLER_FILTER_MINMAX_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_SAMPLER_FILTER_MINMAX_EXTENSION_NAME \"VK_EXT_sampler_filter_minmax\"")]
        public static ReadOnlySpan<byte> VK_EXT_SAMPLER_FILTER_MINMAX_EXTENSION_NAME => "VK_EXT_sampler_filter_minmax"u8;

        [NativeTypeName("#define VK_AMD_gpu_shader_int16 1")]
        public const int VK_AMD_gpu_shader_int16 = 1;

        [NativeTypeName("#define VK_AMD_GPU_SHADER_INT16_SPEC_VERSION 2")]
        public const int VK_AMD_GPU_SHADER_INT16_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_AMD_GPU_SHADER_INT16_EXTENSION_NAME \"VK_AMD_gpu_shader_int16\"")]
        public static ReadOnlySpan<byte> VK_AMD_GPU_SHADER_INT16_EXTENSION_NAME => "VK_AMD_gpu_shader_int16"u8;

        [NativeTypeName("#define VK_AMD_mixed_attachment_samples 1")]
        public const int VK_AMD_mixed_attachment_samples = 1;

        [NativeTypeName("#define VK_AMD_MIXED_ATTACHMENT_SAMPLES_SPEC_VERSION 1")]
        public const int VK_AMD_MIXED_ATTACHMENT_SAMPLES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_MIXED_ATTACHMENT_SAMPLES_EXTENSION_NAME \"VK_AMD_mixed_attachment_samples\"")]
        public static ReadOnlySpan<byte> VK_AMD_MIXED_ATTACHMENT_SAMPLES_EXTENSION_NAME => "VK_AMD_mixed_attachment_samples"u8;

        [NativeTypeName("#define VK_AMD_shader_fragment_mask 1")]
        public const int VK_AMD_shader_fragment_mask = 1;

        [NativeTypeName("#define VK_AMD_SHADER_FRAGMENT_MASK_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_FRAGMENT_MASK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_FRAGMENT_MASK_EXTENSION_NAME \"VK_AMD_shader_fragment_mask\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_FRAGMENT_MASK_EXTENSION_NAME => "VK_AMD_shader_fragment_mask"u8;

        [NativeTypeName("#define VK_EXT_inline_uniform_block 1")]
        public const int VK_EXT_inline_uniform_block = 1;

        [NativeTypeName("#define VK_EXT_INLINE_UNIFORM_BLOCK_SPEC_VERSION 1")]
        public const int VK_EXT_INLINE_UNIFORM_BLOCK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_INLINE_UNIFORM_BLOCK_EXTENSION_NAME \"VK_EXT_inline_uniform_block\"")]
        public static ReadOnlySpan<byte> VK_EXT_INLINE_UNIFORM_BLOCK_EXTENSION_NAME => "VK_EXT_inline_uniform_block"u8;

        [NativeTypeName("#define VK_EXT_shader_stencil_export 1")]
        public const int VK_EXT_shader_stencil_export = 1;

        [NativeTypeName("#define VK_EXT_SHADER_STENCIL_EXPORT_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_STENCIL_EXPORT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_STENCIL_EXPORT_EXTENSION_NAME \"VK_EXT_shader_stencil_export\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_STENCIL_EXPORT_EXTENSION_NAME => "VK_EXT_shader_stencil_export"u8;

        [NativeTypeName("#define VK_EXT_sample_locations 1")]
        public const int VK_EXT_sample_locations = 1;

        [NativeTypeName("#define VK_EXT_SAMPLE_LOCATIONS_SPEC_VERSION 1")]
        public const int VK_EXT_SAMPLE_LOCATIONS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SAMPLE_LOCATIONS_EXTENSION_NAME \"VK_EXT_sample_locations\"")]
        public static ReadOnlySpan<byte> VK_EXT_SAMPLE_LOCATIONS_EXTENSION_NAME => "VK_EXT_sample_locations"u8;

        [NativeTypeName("#define VK_EXT_blend_operation_advanced 1")]
        public const int VK_EXT_blend_operation_advanced = 1;

        [NativeTypeName("#define VK_EXT_BLEND_OPERATION_ADVANCED_SPEC_VERSION 2")]
        public const int VK_EXT_BLEND_OPERATION_ADVANCED_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_BLEND_OPERATION_ADVANCED_EXTENSION_NAME \"VK_EXT_blend_operation_advanced\"")]
        public static ReadOnlySpan<byte> VK_EXT_BLEND_OPERATION_ADVANCED_EXTENSION_NAME => "VK_EXT_blend_operation_advanced"u8;

        [NativeTypeName("#define VK_NV_fragment_coverage_to_color 1")]
        public const int VK_NV_fragment_coverage_to_color = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_COVERAGE_TO_COLOR_SPEC_VERSION 1")]
        public const int VK_NV_FRAGMENT_COVERAGE_TO_COLOR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_COVERAGE_TO_COLOR_EXTENSION_NAME \"VK_NV_fragment_coverage_to_color\"")]
        public static ReadOnlySpan<byte> VK_NV_FRAGMENT_COVERAGE_TO_COLOR_EXTENSION_NAME => "VK_NV_fragment_coverage_to_color"u8;

        [NativeTypeName("#define VK_NV_framebuffer_mixed_samples 1")]
        public const int VK_NV_framebuffer_mixed_samples = 1;

        [NativeTypeName("#define VK_NV_FRAMEBUFFER_MIXED_SAMPLES_SPEC_VERSION 1")]
        public const int VK_NV_FRAMEBUFFER_MIXED_SAMPLES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_FRAMEBUFFER_MIXED_SAMPLES_EXTENSION_NAME \"VK_NV_framebuffer_mixed_samples\"")]
        public static ReadOnlySpan<byte> VK_NV_FRAMEBUFFER_MIXED_SAMPLES_EXTENSION_NAME => "VK_NV_framebuffer_mixed_samples"u8;

        [NativeTypeName("#define VK_NV_fill_rectangle 1")]
        public const int VK_NV_fill_rectangle = 1;

        [NativeTypeName("#define VK_NV_FILL_RECTANGLE_SPEC_VERSION 1")]
        public const int VK_NV_FILL_RECTANGLE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_FILL_RECTANGLE_EXTENSION_NAME \"VK_NV_fill_rectangle\"")]
        public static ReadOnlySpan<byte> VK_NV_FILL_RECTANGLE_EXTENSION_NAME => "VK_NV_fill_rectangle"u8;

        [NativeTypeName("#define VK_NV_shader_sm_builtins 1")]
        public const int VK_NV_shader_sm_builtins = 1;

        [NativeTypeName("#define VK_NV_SHADER_SM_BUILTINS_SPEC_VERSION 1")]
        public const int VK_NV_SHADER_SM_BUILTINS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_SHADER_SM_BUILTINS_EXTENSION_NAME \"VK_NV_shader_sm_builtins\"")]
        public static ReadOnlySpan<byte> VK_NV_SHADER_SM_BUILTINS_EXTENSION_NAME => "VK_NV_shader_sm_builtins"u8;

        [NativeTypeName("#define VK_EXT_post_depth_coverage 1")]
        public const int VK_EXT_post_depth_coverage = 1;

        [NativeTypeName("#define VK_EXT_POST_DEPTH_COVERAGE_SPEC_VERSION 1")]
        public const int VK_EXT_POST_DEPTH_COVERAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_POST_DEPTH_COVERAGE_EXTENSION_NAME \"VK_EXT_post_depth_coverage\"")]
        public static ReadOnlySpan<byte> VK_EXT_POST_DEPTH_COVERAGE_EXTENSION_NAME => "VK_EXT_post_depth_coverage"u8;

        [NativeTypeName("#define VK_EXT_image_drm_format_modifier 1")]
        public const int VK_EXT_image_drm_format_modifier = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_SPEC_VERSION 2")]
        public const int VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_EXTENSION_NAME \"VK_EXT_image_drm_format_modifier\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_EXTENSION_NAME => "VK_EXT_image_drm_format_modifier"u8;

        [NativeTypeName("#define VK_EXT_validation_cache 1")]
        public const int VK_EXT_validation_cache = 1;

        [NativeTypeName("#define VK_EXT_VALIDATION_CACHE_SPEC_VERSION 1")]
        public const int VK_EXT_VALIDATION_CACHE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_VALIDATION_CACHE_EXTENSION_NAME \"VK_EXT_validation_cache\"")]
        public static ReadOnlySpan<byte> VK_EXT_VALIDATION_CACHE_EXTENSION_NAME => "VK_EXT_validation_cache"u8;

        [NativeTypeName("#define VK_EXT_descriptor_indexing 1")]
        public const int VK_EXT_descriptor_indexing = 1;

        [NativeTypeName("#define VK_EXT_DESCRIPTOR_INDEXING_SPEC_VERSION 2")]
        public const int VK_EXT_DESCRIPTOR_INDEXING_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_DESCRIPTOR_INDEXING_EXTENSION_NAME \"VK_EXT_descriptor_indexing\"")]
        public static ReadOnlySpan<byte> VK_EXT_DESCRIPTOR_INDEXING_EXTENSION_NAME => "VK_EXT_descriptor_indexing"u8;

        [NativeTypeName("#define VK_EXT_shader_viewport_index_layer 1")]
        public const int VK_EXT_shader_viewport_index_layer = 1;

        [NativeTypeName("#define VK_EXT_SHADER_VIEWPORT_INDEX_LAYER_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_VIEWPORT_INDEX_LAYER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_VIEWPORT_INDEX_LAYER_EXTENSION_NAME \"VK_EXT_shader_viewport_index_layer\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_VIEWPORT_INDEX_LAYER_EXTENSION_NAME => "VK_EXT_shader_viewport_index_layer"u8;

        [NativeTypeName("#define VK_NV_shading_rate_image 1")]
        public const int VK_NV_shading_rate_image = 1;

        [NativeTypeName("#define VK_NV_SHADING_RATE_IMAGE_SPEC_VERSION 3")]
        public const int VK_NV_SHADING_RATE_IMAGE_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_NV_SHADING_RATE_IMAGE_EXTENSION_NAME \"VK_NV_shading_rate_image\"")]
        public static ReadOnlySpan<byte> VK_NV_SHADING_RATE_IMAGE_EXTENSION_NAME => "VK_NV_shading_rate_image"u8;

        [NativeTypeName("#define VK_NV_ray_tracing 1")]
        public const int VK_NV_ray_tracing = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_SPEC_VERSION 3")]
        public const int VK_NV_RAY_TRACING_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_NV_RAY_TRACING_EXTENSION_NAME \"VK_NV_ray_tracing\"")]
        public static ReadOnlySpan<byte> VK_NV_RAY_TRACING_EXTENSION_NAME => "VK_NV_ray_tracing"u8;

        [NativeTypeName("#define VK_SHADER_UNUSED_KHR (~0U)")]
        public const uint VK_SHADER_UNUSED_KHR = (~0U);

        [NativeTypeName("#define VK_SHADER_UNUSED_NV VK_SHADER_UNUSED_KHR")]
        public const uint VK_SHADER_UNUSED_NV = (~0U);

        [NativeTypeName("#define VK_NV_representative_fragment_test 1")]
        public const int VK_NV_representative_fragment_test = 1;

        [NativeTypeName("#define VK_NV_REPRESENTATIVE_FRAGMENT_TEST_SPEC_VERSION 2")]
        public const int VK_NV_REPRESENTATIVE_FRAGMENT_TEST_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_REPRESENTATIVE_FRAGMENT_TEST_EXTENSION_NAME \"VK_NV_representative_fragment_test\"")]
        public static ReadOnlySpan<byte> VK_NV_REPRESENTATIVE_FRAGMENT_TEST_EXTENSION_NAME => "VK_NV_representative_fragment_test"u8;

        [NativeTypeName("#define VK_EXT_filter_cubic 1")]
        public const int VK_EXT_filter_cubic = 1;

        [NativeTypeName("#define VK_EXT_FILTER_CUBIC_SPEC_VERSION 3")]
        public const int VK_EXT_FILTER_CUBIC_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_EXT_FILTER_CUBIC_EXTENSION_NAME \"VK_EXT_filter_cubic\"")]
        public static ReadOnlySpan<byte> VK_EXT_FILTER_CUBIC_EXTENSION_NAME => "VK_EXT_filter_cubic"u8;

        [NativeTypeName("#define VK_QCOM_render_pass_shader_resolve 1")]
        public const int VK_QCOM_render_pass_shader_resolve = 1;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_SHADER_RESOLVE_SPEC_VERSION 4")]
        public const int VK_QCOM_RENDER_PASS_SHADER_RESOLVE_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_SHADER_RESOLVE_EXTENSION_NAME \"VK_QCOM_render_pass_shader_resolve\"")]
        public static ReadOnlySpan<byte> VK_QCOM_RENDER_PASS_SHADER_RESOLVE_EXTENSION_NAME => "VK_QCOM_render_pass_shader_resolve"u8;

        [NativeTypeName("#define VK_EXT_global_priority 1")]
        public const int VK_EXT_global_priority = 1;

        [NativeTypeName("#define VK_EXT_GLOBAL_PRIORITY_SPEC_VERSION 2")]
        public const int VK_EXT_GLOBAL_PRIORITY_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_GLOBAL_PRIORITY_EXTENSION_NAME \"VK_EXT_global_priority\"")]
        public static ReadOnlySpan<byte> VK_EXT_GLOBAL_PRIORITY_EXTENSION_NAME => "VK_EXT_global_priority"u8;

        [NativeTypeName("#define VK_EXT_external_memory_host 1")]
        public const int VK_EXT_external_memory_host = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_HOST_SPEC_VERSION 1")]
        public const int VK_EXT_EXTERNAL_MEMORY_HOST_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_HOST_EXTENSION_NAME \"VK_EXT_external_memory_host\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTERNAL_MEMORY_HOST_EXTENSION_NAME => "VK_EXT_external_memory_host"u8;

        [NativeTypeName("#define VK_AMD_buffer_marker 1")]
        public const int VK_AMD_buffer_marker = 1;

        [NativeTypeName("#define VK_AMD_BUFFER_MARKER_SPEC_VERSION 1")]
        public const int VK_AMD_BUFFER_MARKER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_BUFFER_MARKER_EXTENSION_NAME \"VK_AMD_buffer_marker\"")]
        public static ReadOnlySpan<byte> VK_AMD_BUFFER_MARKER_EXTENSION_NAME => "VK_AMD_buffer_marker"u8;

        [NativeTypeName("#define VK_AMD_pipeline_compiler_control 1")]
        public const int VK_AMD_pipeline_compiler_control = 1;

        [NativeTypeName("#define VK_AMD_PIPELINE_COMPILER_CONTROL_SPEC_VERSION 1")]
        public const int VK_AMD_PIPELINE_COMPILER_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_PIPELINE_COMPILER_CONTROL_EXTENSION_NAME \"VK_AMD_pipeline_compiler_control\"")]
        public static ReadOnlySpan<byte> VK_AMD_PIPELINE_COMPILER_CONTROL_EXTENSION_NAME => "VK_AMD_pipeline_compiler_control"u8;

        [NativeTypeName("#define VK_EXT_calibrated_timestamps 1")]
        public const int VK_EXT_calibrated_timestamps = 1;

        [NativeTypeName("#define VK_EXT_CALIBRATED_TIMESTAMPS_SPEC_VERSION 2")]
        public const int VK_EXT_CALIBRATED_TIMESTAMPS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_CALIBRATED_TIMESTAMPS_EXTENSION_NAME \"VK_EXT_calibrated_timestamps\"")]
        public static ReadOnlySpan<byte> VK_EXT_CALIBRATED_TIMESTAMPS_EXTENSION_NAME => "VK_EXT_calibrated_timestamps"u8;

        [NativeTypeName("#define VK_AMD_shader_core_properties 1")]
        public const int VK_AMD_shader_core_properties = 1;

        [NativeTypeName("#define VK_AMD_SHADER_CORE_PROPERTIES_SPEC_VERSION 2")]
        public const int VK_AMD_SHADER_CORE_PROPERTIES_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME \"VK_AMD_shader_core_properties\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME => "VK_AMD_shader_core_properties"u8;

        [NativeTypeName("#define VK_AMD_memory_overallocation_behavior 1")]
        public const int VK_AMD_memory_overallocation_behavior = 1;

        [NativeTypeName("#define VK_AMD_MEMORY_OVERALLOCATION_BEHAVIOR_SPEC_VERSION 1")]
        public const int VK_AMD_MEMORY_OVERALLOCATION_BEHAVIOR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_MEMORY_OVERALLOCATION_BEHAVIOR_EXTENSION_NAME \"VK_AMD_memory_overallocation_behavior\"")]
        public static ReadOnlySpan<byte> VK_AMD_MEMORY_OVERALLOCATION_BEHAVIOR_EXTENSION_NAME => "VK_AMD_memory_overallocation_behavior"u8;

        [NativeTypeName("#define VK_EXT_vertex_attribute_divisor 1")]
        public const int VK_EXT_vertex_attribute_divisor = 1;

        [NativeTypeName("#define VK_EXT_VERTEX_ATTRIBUTE_DIVISOR_SPEC_VERSION 3")]
        public const int VK_EXT_VERTEX_ATTRIBUTE_DIVISOR_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_EXT_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME \"VK_EXT_vertex_attribute_divisor\"")]
        public static ReadOnlySpan<byte> VK_EXT_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME => "VK_EXT_vertex_attribute_divisor"u8;

        [NativeTypeName("#define VK_EXT_pipeline_creation_feedback 1")]
        public const int VK_EXT_pipeline_creation_feedback = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_CREATION_FEEDBACK_SPEC_VERSION 1")]
        public const int VK_EXT_PIPELINE_CREATION_FEEDBACK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_CREATION_FEEDBACK_EXTENSION_NAME \"VK_EXT_pipeline_creation_feedback\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_CREATION_FEEDBACK_EXTENSION_NAME => "VK_EXT_pipeline_creation_feedback"u8;

        [NativeTypeName("#define VK_NV_shader_subgroup_partitioned 1")]
        public const int VK_NV_shader_subgroup_partitioned = 1;

        [NativeTypeName("#define VK_NV_SHADER_SUBGROUP_PARTITIONED_SPEC_VERSION 1")]
        public const int VK_NV_SHADER_SUBGROUP_PARTITIONED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_SHADER_SUBGROUP_PARTITIONED_EXTENSION_NAME \"VK_NV_shader_subgroup_partitioned\"")]
        public static ReadOnlySpan<byte> VK_NV_SHADER_SUBGROUP_PARTITIONED_EXTENSION_NAME => "VK_NV_shader_subgroup_partitioned"u8;

        [NativeTypeName("#define VK_NV_compute_shader_derivatives 1")]
        public const int VK_NV_compute_shader_derivatives = 1;

        [NativeTypeName("#define VK_NV_COMPUTE_SHADER_DERIVATIVES_SPEC_VERSION 1")]
        public const int VK_NV_COMPUTE_SHADER_DERIVATIVES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME \"VK_NV_compute_shader_derivatives\"")]
        public static ReadOnlySpan<byte> VK_NV_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME => "VK_NV_compute_shader_derivatives"u8;

        [NativeTypeName("#define VK_NV_mesh_shader 1")]
        public const int VK_NV_mesh_shader = 1;

        [NativeTypeName("#define VK_NV_MESH_SHADER_SPEC_VERSION 1")]
        public const int VK_NV_MESH_SHADER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_MESH_SHADER_EXTENSION_NAME \"VK_NV_mesh_shader\"")]
        public static ReadOnlySpan<byte> VK_NV_MESH_SHADER_EXTENSION_NAME => "VK_NV_mesh_shader"u8;

        [NativeTypeName("#define VK_NV_fragment_shader_barycentric 1")]
        public const int VK_NV_fragment_shader_barycentric = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_SHADER_BARYCENTRIC_SPEC_VERSION 1")]
        public const int VK_NV_FRAGMENT_SHADER_BARYCENTRIC_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME \"VK_NV_fragment_shader_barycentric\"")]
        public static ReadOnlySpan<byte> VK_NV_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME => "VK_NV_fragment_shader_barycentric"u8;

        [NativeTypeName("#define VK_NV_shader_image_footprint 1")]
        public const int VK_NV_shader_image_footprint = 1;

        [NativeTypeName("#define VK_NV_SHADER_IMAGE_FOOTPRINT_SPEC_VERSION 2")]
        public const int VK_NV_SHADER_IMAGE_FOOTPRINT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_SHADER_IMAGE_FOOTPRINT_EXTENSION_NAME \"VK_NV_shader_image_footprint\"")]
        public static ReadOnlySpan<byte> VK_NV_SHADER_IMAGE_FOOTPRINT_EXTENSION_NAME => "VK_NV_shader_image_footprint"u8;

        [NativeTypeName("#define VK_NV_scissor_exclusive 1")]
        public const int VK_NV_scissor_exclusive = 1;

        [NativeTypeName("#define VK_NV_SCISSOR_EXCLUSIVE_SPEC_VERSION 2")]
        public const int VK_NV_SCISSOR_EXCLUSIVE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_SCISSOR_EXCLUSIVE_EXTENSION_NAME \"VK_NV_scissor_exclusive\"")]
        public static ReadOnlySpan<byte> VK_NV_SCISSOR_EXCLUSIVE_EXTENSION_NAME => "VK_NV_scissor_exclusive"u8;

        [NativeTypeName("#define VK_NV_device_diagnostic_checkpoints 1")]
        public const int VK_NV_device_diagnostic_checkpoints = 1;

        [NativeTypeName("#define VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_SPEC_VERSION 2")]
        public const int VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_EXTENSION_NAME \"VK_NV_device_diagnostic_checkpoints\"")]
        public static ReadOnlySpan<byte> VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_EXTENSION_NAME => "VK_NV_device_diagnostic_checkpoints"u8;

        [NativeTypeName("#define VK_INTEL_shader_integer_functions2 1")]
        public const int VK_INTEL_shader_integer_functions2 = 1;

        [NativeTypeName("#define VK_INTEL_SHADER_INTEGER_FUNCTIONS_2_SPEC_VERSION 1")]
        public const int VK_INTEL_SHADER_INTEGER_FUNCTIONS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_INTEL_SHADER_INTEGER_FUNCTIONS_2_EXTENSION_NAME \"VK_INTEL_shader_integer_functions2\"")]
        public static ReadOnlySpan<byte> VK_INTEL_SHADER_INTEGER_FUNCTIONS_2_EXTENSION_NAME => "VK_INTEL_shader_integer_functions2"u8;

        [NativeTypeName("#define VK_INTEL_performance_query 1")]
        public const int VK_INTEL_performance_query = 1;

        [NativeTypeName("#define VK_INTEL_PERFORMANCE_QUERY_SPEC_VERSION 2")]
        public const int VK_INTEL_PERFORMANCE_QUERY_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_INTEL_PERFORMANCE_QUERY_EXTENSION_NAME \"VK_INTEL_performance_query\"")]
        public static ReadOnlySpan<byte> VK_INTEL_PERFORMANCE_QUERY_EXTENSION_NAME => "VK_INTEL_performance_query"u8;

        [NativeTypeName("#define VK_EXT_pci_bus_info 1")]
        public const int VK_EXT_pci_bus_info = 1;

        [NativeTypeName("#define VK_EXT_PCI_BUS_INFO_SPEC_VERSION 2")]
        public const int VK_EXT_PCI_BUS_INFO_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_PCI_BUS_INFO_EXTENSION_NAME \"VK_EXT_pci_bus_info\"")]
        public static ReadOnlySpan<byte> VK_EXT_PCI_BUS_INFO_EXTENSION_NAME => "VK_EXT_pci_bus_info"u8;

        [NativeTypeName("#define VK_AMD_display_native_hdr 1")]
        public const int VK_AMD_display_native_hdr = 1;

        [NativeTypeName("#define VK_AMD_DISPLAY_NATIVE_HDR_SPEC_VERSION 1")]
        public const int VK_AMD_DISPLAY_NATIVE_HDR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_DISPLAY_NATIVE_HDR_EXTENSION_NAME \"VK_AMD_display_native_hdr\"")]
        public static ReadOnlySpan<byte> VK_AMD_DISPLAY_NATIVE_HDR_EXTENSION_NAME => "VK_AMD_display_native_hdr"u8;

        [NativeTypeName("#define VK_EXT_fragment_density_map 1")]
        public const int VK_EXT_fragment_density_map = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_SPEC_VERSION 2")]
        public const int VK_EXT_FRAGMENT_DENSITY_MAP_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_EXTENSION_NAME \"VK_EXT_fragment_density_map\"")]
        public static ReadOnlySpan<byte> VK_EXT_FRAGMENT_DENSITY_MAP_EXTENSION_NAME => "VK_EXT_fragment_density_map"u8;

        [NativeTypeName("#define VK_EXT_scalar_block_layout 1")]
        public const int VK_EXT_scalar_block_layout = 1;

        [NativeTypeName("#define VK_EXT_SCALAR_BLOCK_LAYOUT_SPEC_VERSION 1")]
        public const int VK_EXT_SCALAR_BLOCK_LAYOUT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SCALAR_BLOCK_LAYOUT_EXTENSION_NAME \"VK_EXT_scalar_block_layout\"")]
        public static ReadOnlySpan<byte> VK_EXT_SCALAR_BLOCK_LAYOUT_EXTENSION_NAME => "VK_EXT_scalar_block_layout"u8;

        [NativeTypeName("#define VK_GOOGLE_hlsl_functionality1 1")]
        public const int VK_GOOGLE_hlsl_functionality1 = 1;

        [NativeTypeName("#define VK_GOOGLE_HLSL_FUNCTIONALITY_1_SPEC_VERSION 1")]
        public const int VK_GOOGLE_HLSL_FUNCTIONALITY_1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_GOOGLE_HLSL_FUNCTIONALITY_1_EXTENSION_NAME \"VK_GOOGLE_hlsl_functionality1\"")]
        public static ReadOnlySpan<byte> VK_GOOGLE_HLSL_FUNCTIONALITY_1_EXTENSION_NAME => "VK_GOOGLE_hlsl_functionality1"u8;

        [NativeTypeName("#define VK_GOOGLE_HLSL_FUNCTIONALITY1_SPEC_VERSION VK_GOOGLE_HLSL_FUNCTIONALITY_1_SPEC_VERSION")]
        public const int VK_GOOGLE_HLSL_FUNCTIONALITY1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_GOOGLE_HLSL_FUNCTIONALITY1_EXTENSION_NAME VK_GOOGLE_HLSL_FUNCTIONALITY_1_EXTENSION_NAME")]
        public static ReadOnlySpan<byte> VK_GOOGLE_HLSL_FUNCTIONALITY1_EXTENSION_NAME => "VK_GOOGLE_hlsl_functionality1"u8;

        [NativeTypeName("#define VK_GOOGLE_decorate_string 1")]
        public const int VK_GOOGLE_decorate_string = 1;

        [NativeTypeName("#define VK_GOOGLE_DECORATE_STRING_SPEC_VERSION 1")]
        public const int VK_GOOGLE_DECORATE_STRING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_GOOGLE_DECORATE_STRING_EXTENSION_NAME \"VK_GOOGLE_decorate_string\"")]
        public static ReadOnlySpan<byte> VK_GOOGLE_DECORATE_STRING_EXTENSION_NAME => "VK_GOOGLE_decorate_string"u8;

        [NativeTypeName("#define VK_EXT_subgroup_size_control 1")]
        public const int VK_EXT_subgroup_size_control = 1;

        [NativeTypeName("#define VK_EXT_SUBGROUP_SIZE_CONTROL_SPEC_VERSION 2")]
        public const int VK_EXT_SUBGROUP_SIZE_CONTROL_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_SUBGROUP_SIZE_CONTROL_EXTENSION_NAME \"VK_EXT_subgroup_size_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_SUBGROUP_SIZE_CONTROL_EXTENSION_NAME => "VK_EXT_subgroup_size_control"u8;

        [NativeTypeName("#define VK_AMD_shader_core_properties2 1")]
        public const int VK_AMD_shader_core_properties2 = 1;

        [NativeTypeName("#define VK_AMD_SHADER_CORE_PROPERTIES_2_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_CORE_PROPERTIES_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_CORE_PROPERTIES_2_EXTENSION_NAME \"VK_AMD_shader_core_properties2\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_CORE_PROPERTIES_2_EXTENSION_NAME => "VK_AMD_shader_core_properties2"u8;

        [NativeTypeName("#define VK_AMD_device_coherent_memory 1")]
        public const int VK_AMD_device_coherent_memory = 1;

        [NativeTypeName("#define VK_AMD_DEVICE_COHERENT_MEMORY_SPEC_VERSION 1")]
        public const int VK_AMD_DEVICE_COHERENT_MEMORY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_DEVICE_COHERENT_MEMORY_EXTENSION_NAME \"VK_AMD_device_coherent_memory\"")]
        public static ReadOnlySpan<byte> VK_AMD_DEVICE_COHERENT_MEMORY_EXTENSION_NAME => "VK_AMD_device_coherent_memory"u8;

        [NativeTypeName("#define VK_EXT_shader_image_atomic_int64 1")]
        public const int VK_EXT_shader_image_atomic_int64 = 1;

        [NativeTypeName("#define VK_EXT_SHADER_IMAGE_ATOMIC_INT64_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_IMAGE_ATOMIC_INT64_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_IMAGE_ATOMIC_INT64_EXTENSION_NAME \"VK_EXT_shader_image_atomic_int64\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_IMAGE_ATOMIC_INT64_EXTENSION_NAME => "VK_EXT_shader_image_atomic_int64"u8;

        [NativeTypeName("#define VK_EXT_memory_budget 1")]
        public const int VK_EXT_memory_budget = 1;

        [NativeTypeName("#define VK_EXT_MEMORY_BUDGET_SPEC_VERSION 1")]
        public const int VK_EXT_MEMORY_BUDGET_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MEMORY_BUDGET_EXTENSION_NAME \"VK_EXT_memory_budget\"")]
        public static ReadOnlySpan<byte> VK_EXT_MEMORY_BUDGET_EXTENSION_NAME => "VK_EXT_memory_budget"u8;

        [NativeTypeName("#define VK_EXT_memory_priority 1")]
        public const int VK_EXT_memory_priority = 1;

        [NativeTypeName("#define VK_EXT_MEMORY_PRIORITY_SPEC_VERSION 1")]
        public const int VK_EXT_MEMORY_PRIORITY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MEMORY_PRIORITY_EXTENSION_NAME \"VK_EXT_memory_priority\"")]
        public static ReadOnlySpan<byte> VK_EXT_MEMORY_PRIORITY_EXTENSION_NAME => "VK_EXT_memory_priority"u8;

        [NativeTypeName("#define VK_NV_dedicated_allocation_image_aliasing 1")]
        public const int VK_NV_dedicated_allocation_image_aliasing = 1;

        [NativeTypeName("#define VK_NV_DEDICATED_ALLOCATION_IMAGE_ALIASING_SPEC_VERSION 1")]
        public const int VK_NV_DEDICATED_ALLOCATION_IMAGE_ALIASING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_DEDICATED_ALLOCATION_IMAGE_ALIASING_EXTENSION_NAME \"VK_NV_dedicated_allocation_image_aliasing\"")]
        public static ReadOnlySpan<byte> VK_NV_DEDICATED_ALLOCATION_IMAGE_ALIASING_EXTENSION_NAME => "VK_NV_dedicated_allocation_image_aliasing"u8;

        [NativeTypeName("#define VK_EXT_buffer_device_address 1")]
        public const int VK_EXT_buffer_device_address = 1;

        [NativeTypeName("#define VK_EXT_BUFFER_DEVICE_ADDRESS_SPEC_VERSION 2")]
        public const int VK_EXT_BUFFER_DEVICE_ADDRESS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME \"VK_EXT_buffer_device_address\"")]
        public static ReadOnlySpan<byte> VK_EXT_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME => "VK_EXT_buffer_device_address"u8;

        [NativeTypeName("#define VK_EXT_tooling_info 1")]
        public const int VK_EXT_tooling_info = 1;

        [NativeTypeName("#define VK_EXT_TOOLING_INFO_SPEC_VERSION 1")]
        public const int VK_EXT_TOOLING_INFO_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_TOOLING_INFO_EXTENSION_NAME \"VK_EXT_tooling_info\"")]
        public static ReadOnlySpan<byte> VK_EXT_TOOLING_INFO_EXTENSION_NAME => "VK_EXT_tooling_info"u8;

        [NativeTypeName("#define VK_EXT_separate_stencil_usage 1")]
        public const int VK_EXT_separate_stencil_usage = 1;

        [NativeTypeName("#define VK_EXT_SEPARATE_STENCIL_USAGE_SPEC_VERSION 1")]
        public const int VK_EXT_SEPARATE_STENCIL_USAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SEPARATE_STENCIL_USAGE_EXTENSION_NAME \"VK_EXT_separate_stencil_usage\"")]
        public static ReadOnlySpan<byte> VK_EXT_SEPARATE_STENCIL_USAGE_EXTENSION_NAME => "VK_EXT_separate_stencil_usage"u8;

        [NativeTypeName("#define VK_EXT_validation_features 1")]
        public const int VK_EXT_validation_features = 1;

        [NativeTypeName("#define VK_EXT_VALIDATION_FEATURES_SPEC_VERSION 6")]
        public const int VK_EXT_VALIDATION_FEATURES_SPEC_VERSION = 6;

        [NativeTypeName("#define VK_EXT_VALIDATION_FEATURES_EXTENSION_NAME \"VK_EXT_validation_features\"")]
        public static ReadOnlySpan<byte> VK_EXT_VALIDATION_FEATURES_EXTENSION_NAME => "VK_EXT_validation_features"u8;

        [NativeTypeName("#define VK_NV_cooperative_matrix 1")]
        public const int VK_NV_cooperative_matrix = 1;

        [NativeTypeName("#define VK_NV_COOPERATIVE_MATRIX_SPEC_VERSION 1")]
        public const int VK_NV_COOPERATIVE_MATRIX_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COOPERATIVE_MATRIX_EXTENSION_NAME \"VK_NV_cooperative_matrix\"")]
        public static ReadOnlySpan<byte> VK_NV_COOPERATIVE_MATRIX_EXTENSION_NAME => "VK_NV_cooperative_matrix"u8;

        [NativeTypeName("#define VK_NV_coverage_reduction_mode 1")]
        public const int VK_NV_coverage_reduction_mode = 1;

        [NativeTypeName("#define VK_NV_COVERAGE_REDUCTION_MODE_SPEC_VERSION 1")]
        public const int VK_NV_COVERAGE_REDUCTION_MODE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COVERAGE_REDUCTION_MODE_EXTENSION_NAME \"VK_NV_coverage_reduction_mode\"")]
        public static ReadOnlySpan<byte> VK_NV_COVERAGE_REDUCTION_MODE_EXTENSION_NAME => "VK_NV_coverage_reduction_mode"u8;

        [NativeTypeName("#define VK_EXT_fragment_shader_interlock 1")]
        public const int VK_EXT_fragment_shader_interlock = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_SHADER_INTERLOCK_SPEC_VERSION 1")]
        public const int VK_EXT_FRAGMENT_SHADER_INTERLOCK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_SHADER_INTERLOCK_EXTENSION_NAME \"VK_EXT_fragment_shader_interlock\"")]
        public static ReadOnlySpan<byte> VK_EXT_FRAGMENT_SHADER_INTERLOCK_EXTENSION_NAME => "VK_EXT_fragment_shader_interlock"u8;

        [NativeTypeName("#define VK_EXT_ycbcr_image_arrays 1")]
        public const int VK_EXT_ycbcr_image_arrays = 1;

        [NativeTypeName("#define VK_EXT_YCBCR_IMAGE_ARRAYS_SPEC_VERSION 1")]
        public const int VK_EXT_YCBCR_IMAGE_ARRAYS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_YCBCR_IMAGE_ARRAYS_EXTENSION_NAME \"VK_EXT_ycbcr_image_arrays\"")]
        public static ReadOnlySpan<byte> VK_EXT_YCBCR_IMAGE_ARRAYS_EXTENSION_NAME => "VK_EXT_ycbcr_image_arrays"u8;

        [NativeTypeName("#define VK_EXT_provoking_vertex 1")]
        public const int VK_EXT_provoking_vertex = 1;

        [NativeTypeName("#define VK_EXT_PROVOKING_VERTEX_SPEC_VERSION 1")]
        public const int VK_EXT_PROVOKING_VERTEX_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PROVOKING_VERTEX_EXTENSION_NAME \"VK_EXT_provoking_vertex\"")]
        public static ReadOnlySpan<byte> VK_EXT_PROVOKING_VERTEX_EXTENSION_NAME => "VK_EXT_provoking_vertex"u8;

        [NativeTypeName("#define VK_EXT_headless_surface 1")]
        public const int VK_EXT_headless_surface = 1;

        [NativeTypeName("#define VK_EXT_HEADLESS_SURFACE_SPEC_VERSION 1")]
        public const int VK_EXT_HEADLESS_SURFACE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_HEADLESS_SURFACE_EXTENSION_NAME \"VK_EXT_headless_surface\"")]
        public static ReadOnlySpan<byte> VK_EXT_HEADLESS_SURFACE_EXTENSION_NAME => "VK_EXT_headless_surface"u8;

        [NativeTypeName("#define VK_EXT_line_rasterization 1")]
        public const int VK_EXT_line_rasterization = 1;

        [NativeTypeName("#define VK_EXT_LINE_RASTERIZATION_SPEC_VERSION 1")]
        public const int VK_EXT_LINE_RASTERIZATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_LINE_RASTERIZATION_EXTENSION_NAME \"VK_EXT_line_rasterization\"")]
        public static ReadOnlySpan<byte> VK_EXT_LINE_RASTERIZATION_EXTENSION_NAME => "VK_EXT_line_rasterization"u8;

        [NativeTypeName("#define VK_EXT_shader_atomic_float 1")]
        public const int VK_EXT_shader_atomic_float = 1;

        [NativeTypeName("#define VK_EXT_SHADER_ATOMIC_FLOAT_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_ATOMIC_FLOAT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_ATOMIC_FLOAT_EXTENSION_NAME \"VK_EXT_shader_atomic_float\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_ATOMIC_FLOAT_EXTENSION_NAME => "VK_EXT_shader_atomic_float"u8;

        [NativeTypeName("#define VK_EXT_host_query_reset 1")]
        public const int VK_EXT_host_query_reset = 1;

        [NativeTypeName("#define VK_EXT_HOST_QUERY_RESET_SPEC_VERSION 1")]
        public const int VK_EXT_HOST_QUERY_RESET_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_HOST_QUERY_RESET_EXTENSION_NAME \"VK_EXT_host_query_reset\"")]
        public static ReadOnlySpan<byte> VK_EXT_HOST_QUERY_RESET_EXTENSION_NAME => "VK_EXT_host_query_reset"u8;

        [NativeTypeName("#define VK_EXT_index_type_uint8 1")]
        public const int VK_EXT_index_type_uint8 = 1;

        [NativeTypeName("#define VK_EXT_INDEX_TYPE_UINT8_SPEC_VERSION 1")]
        public const int VK_EXT_INDEX_TYPE_UINT8_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_INDEX_TYPE_UINT8_EXTENSION_NAME \"VK_EXT_index_type_uint8\"")]
        public static ReadOnlySpan<byte> VK_EXT_INDEX_TYPE_UINT8_EXTENSION_NAME => "VK_EXT_index_type_uint8"u8;

        [NativeTypeName("#define VK_EXT_extended_dynamic_state 1")]
        public const int VK_EXT_extended_dynamic_state = 1;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_SPEC_VERSION 1")]
        public const int VK_EXT_EXTENDED_DYNAMIC_STATE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_EXTENSION_NAME \"VK_EXT_extended_dynamic_state\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTENDED_DYNAMIC_STATE_EXTENSION_NAME => "VK_EXT_extended_dynamic_state"u8;

        [NativeTypeName("#define VK_EXT_host_image_copy 1")]
        public const int VK_EXT_host_image_copy = 1;

        [NativeTypeName("#define VK_EXT_HOST_IMAGE_COPY_SPEC_VERSION 1")]
        public const int VK_EXT_HOST_IMAGE_COPY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_HOST_IMAGE_COPY_EXTENSION_NAME \"VK_EXT_host_image_copy\"")]
        public static ReadOnlySpan<byte> VK_EXT_HOST_IMAGE_COPY_EXTENSION_NAME => "VK_EXT_host_image_copy"u8;

        [NativeTypeName("#define VK_EXT_map_memory_placed 1")]
        public const int VK_EXT_map_memory_placed = 1;

        [NativeTypeName("#define VK_EXT_MAP_MEMORY_PLACED_SPEC_VERSION 1")]
        public const int VK_EXT_MAP_MEMORY_PLACED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MAP_MEMORY_PLACED_EXTENSION_NAME \"VK_EXT_map_memory_placed\"")]
        public static ReadOnlySpan<byte> VK_EXT_MAP_MEMORY_PLACED_EXTENSION_NAME => "VK_EXT_map_memory_placed"u8;

        [NativeTypeName("#define VK_EXT_shader_atomic_float2 1")]
        public const int VK_EXT_shader_atomic_float2 = 1;

        [NativeTypeName("#define VK_EXT_SHADER_ATOMIC_FLOAT_2_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_ATOMIC_FLOAT_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_ATOMIC_FLOAT_2_EXTENSION_NAME \"VK_EXT_shader_atomic_float2\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_ATOMIC_FLOAT_2_EXTENSION_NAME => "VK_EXT_shader_atomic_float2"u8;

        [NativeTypeName("#define VK_EXT_surface_maintenance1 1")]
        public const int VK_EXT_surface_maintenance1 = 1;

        [NativeTypeName("#define VK_EXT_SURFACE_MAINTENANCE_1_SPEC_VERSION 1")]
        public const int VK_EXT_SURFACE_MAINTENANCE_1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SURFACE_MAINTENANCE_1_EXTENSION_NAME \"VK_EXT_surface_maintenance1\"")]
        public static ReadOnlySpan<byte> VK_EXT_SURFACE_MAINTENANCE_1_EXTENSION_NAME => "VK_EXT_surface_maintenance1"u8;

        [NativeTypeName("#define VK_EXT_swapchain_maintenance1 1")]
        public const int VK_EXT_swapchain_maintenance1 = 1;

        [NativeTypeName("#define VK_EXT_SWAPCHAIN_MAINTENANCE_1_SPEC_VERSION 1")]
        public const int VK_EXT_SWAPCHAIN_MAINTENANCE_1_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SWAPCHAIN_MAINTENANCE_1_EXTENSION_NAME \"VK_EXT_swapchain_maintenance1\"")]
        public static ReadOnlySpan<byte> VK_EXT_SWAPCHAIN_MAINTENANCE_1_EXTENSION_NAME => "VK_EXT_swapchain_maintenance1"u8;

        [NativeTypeName("#define VK_EXT_shader_demote_to_helper_invocation 1")]
        public const int VK_EXT_shader_demote_to_helper_invocation = 1;

        [NativeTypeName("#define VK_EXT_SHADER_DEMOTE_TO_HELPER_INVOCATION_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_DEMOTE_TO_HELPER_INVOCATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_DEMOTE_TO_HELPER_INVOCATION_EXTENSION_NAME \"VK_EXT_shader_demote_to_helper_invocation\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_DEMOTE_TO_HELPER_INVOCATION_EXTENSION_NAME => "VK_EXT_shader_demote_to_helper_invocation"u8;

        [NativeTypeName("#define VK_NV_device_generated_commands 1")]
        public const int VK_NV_device_generated_commands = 1;

        [NativeTypeName("#define VK_NV_DEVICE_GENERATED_COMMANDS_SPEC_VERSION 3")]
        public const int VK_NV_DEVICE_GENERATED_COMMANDS_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_NV_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME \"VK_NV_device_generated_commands\"")]
        public static ReadOnlySpan<byte> VK_NV_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME => "VK_NV_device_generated_commands"u8;

        [NativeTypeName("#define VK_NV_inherited_viewport_scissor 1")]
        public const int VK_NV_inherited_viewport_scissor = 1;

        [NativeTypeName("#define VK_NV_INHERITED_VIEWPORT_SCISSOR_SPEC_VERSION 1")]
        public const int VK_NV_INHERITED_VIEWPORT_SCISSOR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_INHERITED_VIEWPORT_SCISSOR_EXTENSION_NAME \"VK_NV_inherited_viewport_scissor\"")]
        public static ReadOnlySpan<byte> VK_NV_INHERITED_VIEWPORT_SCISSOR_EXTENSION_NAME => "VK_NV_inherited_viewport_scissor"u8;

        [NativeTypeName("#define VK_EXT_texel_buffer_alignment 1")]
        public const int VK_EXT_texel_buffer_alignment = 1;

        [NativeTypeName("#define VK_EXT_TEXEL_BUFFER_ALIGNMENT_SPEC_VERSION 1")]
        public const int VK_EXT_TEXEL_BUFFER_ALIGNMENT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_TEXEL_BUFFER_ALIGNMENT_EXTENSION_NAME \"VK_EXT_texel_buffer_alignment\"")]
        public static ReadOnlySpan<byte> VK_EXT_TEXEL_BUFFER_ALIGNMENT_EXTENSION_NAME => "VK_EXT_texel_buffer_alignment"u8;

        [NativeTypeName("#define VK_QCOM_render_pass_transform 1")]
        public const int VK_QCOM_render_pass_transform = 1;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_TRANSFORM_SPEC_VERSION 4")]
        public const int VK_QCOM_RENDER_PASS_TRANSFORM_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_TRANSFORM_EXTENSION_NAME \"VK_QCOM_render_pass_transform\"")]
        public static ReadOnlySpan<byte> VK_QCOM_RENDER_PASS_TRANSFORM_EXTENSION_NAME => "VK_QCOM_render_pass_transform"u8;

        [NativeTypeName("#define VK_EXT_depth_bias_control 1")]
        public const int VK_EXT_depth_bias_control = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_BIAS_CONTROL_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_BIAS_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_BIAS_CONTROL_EXTENSION_NAME \"VK_EXT_depth_bias_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_BIAS_CONTROL_EXTENSION_NAME => "VK_EXT_depth_bias_control"u8;

        [NativeTypeName("#define VK_EXT_device_memory_report 1")]
        public const int VK_EXT_device_memory_report = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_MEMORY_REPORT_SPEC_VERSION 2")]
        public const int VK_EXT_DEVICE_MEMORY_REPORT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_DEVICE_MEMORY_REPORT_EXTENSION_NAME \"VK_EXT_device_memory_report\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEVICE_MEMORY_REPORT_EXTENSION_NAME => "VK_EXT_device_memory_report"u8;

        [NativeTypeName("#define VK_EXT_acquire_drm_display 1")]
        public const int VK_EXT_acquire_drm_display = 1;

        [NativeTypeName("#define VK_EXT_ACQUIRE_DRM_DISPLAY_SPEC_VERSION 1")]
        public const int VK_EXT_ACQUIRE_DRM_DISPLAY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_ACQUIRE_DRM_DISPLAY_EXTENSION_NAME \"VK_EXT_acquire_drm_display\"")]
        public static ReadOnlySpan<byte> VK_EXT_ACQUIRE_DRM_DISPLAY_EXTENSION_NAME => "VK_EXT_acquire_drm_display"u8;

        [NativeTypeName("#define VK_EXT_robustness2 1")]
        public const int VK_EXT_robustness2 = 1;

        [NativeTypeName("#define VK_EXT_ROBUSTNESS_2_SPEC_VERSION 1")]
        public const int VK_EXT_ROBUSTNESS_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_ROBUSTNESS_2_EXTENSION_NAME \"VK_EXT_robustness2\"")]
        public static ReadOnlySpan<byte> VK_EXT_ROBUSTNESS_2_EXTENSION_NAME => "VK_EXT_robustness2"u8;

        [NativeTypeName("#define VK_EXT_custom_border_color 1")]
        public const int VK_EXT_custom_border_color = 1;

        [NativeTypeName("#define VK_EXT_CUSTOM_BORDER_COLOR_SPEC_VERSION 12")]
        public const int VK_EXT_CUSTOM_BORDER_COLOR_SPEC_VERSION = 12;

        [NativeTypeName("#define VK_EXT_CUSTOM_BORDER_COLOR_EXTENSION_NAME \"VK_EXT_custom_border_color\"")]
        public static ReadOnlySpan<byte> VK_EXT_CUSTOM_BORDER_COLOR_EXTENSION_NAME => "VK_EXT_custom_border_color"u8;

        [NativeTypeName("#define VK_GOOGLE_user_type 1")]
        public const int VK_GOOGLE_user_type = 1;

        [NativeTypeName("#define VK_GOOGLE_USER_TYPE_SPEC_VERSION 1")]
        public const int VK_GOOGLE_USER_TYPE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_GOOGLE_USER_TYPE_EXTENSION_NAME \"VK_GOOGLE_user_type\"")]
        public static ReadOnlySpan<byte> VK_GOOGLE_USER_TYPE_EXTENSION_NAME => "VK_GOOGLE_user_type"u8;

        [NativeTypeName("#define VK_NV_present_barrier 1")]
        public const int VK_NV_present_barrier = 1;

        [NativeTypeName("#define VK_NV_PRESENT_BARRIER_SPEC_VERSION 1")]
        public const int VK_NV_PRESENT_BARRIER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_PRESENT_BARRIER_EXTENSION_NAME \"VK_NV_present_barrier\"")]
        public static ReadOnlySpan<byte> VK_NV_PRESENT_BARRIER_EXTENSION_NAME => "VK_NV_present_barrier"u8;

        [NativeTypeName("#define VK_EXT_private_data 1")]
        public const int VK_EXT_private_data = 1;

        [NativeTypeName("#define VK_EXT_PRIVATE_DATA_SPEC_VERSION 1")]
        public const int VK_EXT_PRIVATE_DATA_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PRIVATE_DATA_EXTENSION_NAME \"VK_EXT_private_data\"")]
        public static ReadOnlySpan<byte> VK_EXT_PRIVATE_DATA_EXTENSION_NAME => "VK_EXT_private_data"u8;

        [NativeTypeName("#define VK_EXT_pipeline_creation_cache_control 1")]
        public const int VK_EXT_pipeline_creation_cache_control = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_CREATION_CACHE_CONTROL_SPEC_VERSION 3")]
        public const int VK_EXT_PIPELINE_CREATION_CACHE_CONTROL_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_EXT_PIPELINE_CREATION_CACHE_CONTROL_EXTENSION_NAME \"VK_EXT_pipeline_creation_cache_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_CREATION_CACHE_CONTROL_EXTENSION_NAME => "VK_EXT_pipeline_creation_cache_control"u8;

        [NativeTypeName("#define VK_NV_device_diagnostics_config 1")]
        public const int VK_NV_device_diagnostics_config = 1;

        [NativeTypeName("#define VK_NV_DEVICE_DIAGNOSTICS_CONFIG_SPEC_VERSION 2")]
        public const int VK_NV_DEVICE_DIAGNOSTICS_CONFIG_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_DEVICE_DIAGNOSTICS_CONFIG_EXTENSION_NAME \"VK_NV_device_diagnostics_config\"")]
        public static ReadOnlySpan<byte> VK_NV_DEVICE_DIAGNOSTICS_CONFIG_EXTENSION_NAME => "VK_NV_device_diagnostics_config"u8;

        [NativeTypeName("#define VK_QCOM_render_pass_store_ops 1")]
        public const int VK_QCOM_render_pass_store_ops = 1;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_STORE_OPS_SPEC_VERSION 2")]
        public const int VK_QCOM_RENDER_PASS_STORE_OPS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_QCOM_RENDER_PASS_STORE_OPS_EXTENSION_NAME \"VK_QCOM_render_pass_store_ops\"")]
        public static ReadOnlySpan<byte> VK_QCOM_RENDER_PASS_STORE_OPS_EXTENSION_NAME => "VK_QCOM_render_pass_store_ops"u8;

        [NativeTypeName("#define VK_NV_cuda_kernel_launch 1")]
        public const int VK_NV_cuda_kernel_launch = 1;

        [NativeTypeName("#define VK_NV_CUDA_KERNEL_LAUNCH_SPEC_VERSION 2")]
        public const int VK_NV_CUDA_KERNEL_LAUNCH_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_CUDA_KERNEL_LAUNCH_EXTENSION_NAME \"VK_NV_cuda_kernel_launch\"")]
        public static ReadOnlySpan<byte> VK_NV_CUDA_KERNEL_LAUNCH_EXTENSION_NAME => "VK_NV_cuda_kernel_launch"u8;

        [NativeTypeName("#define VK_QCOM_tile_shading 1")]
        public const int VK_QCOM_tile_shading = 1;

        [NativeTypeName("#define VK_QCOM_TILE_SHADING_SPEC_VERSION 1")]
        public const int VK_QCOM_TILE_SHADING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_TILE_SHADING_EXTENSION_NAME \"VK_QCOM_tile_shading\"")]
        public static ReadOnlySpan<byte> VK_QCOM_TILE_SHADING_EXTENSION_NAME => "VK_QCOM_tile_shading"u8;

        [NativeTypeName("#define VK_NV_low_latency 1")]
        public const int VK_NV_low_latency = 1;

        [NativeTypeName("#define VK_NV_LOW_LATENCY_SPEC_VERSION 1")]
        public const int VK_NV_LOW_LATENCY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_LOW_LATENCY_EXTENSION_NAME \"VK_NV_low_latency\"")]
        public static ReadOnlySpan<byte> VK_NV_LOW_LATENCY_EXTENSION_NAME => "VK_NV_low_latency"u8;

        [NativeTypeName("#define VK_EXT_descriptor_buffer 1")]
        public const int VK_EXT_descriptor_buffer = 1;

        [NativeTypeName("#define VK_EXT_DESCRIPTOR_BUFFER_SPEC_VERSION 1")]
        public const int VK_EXT_DESCRIPTOR_BUFFER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DESCRIPTOR_BUFFER_EXTENSION_NAME \"VK_EXT_descriptor_buffer\"")]
        public static ReadOnlySpan<byte> VK_EXT_DESCRIPTOR_BUFFER_EXTENSION_NAME => "VK_EXT_descriptor_buffer"u8;

        [NativeTypeName("#define VK_EXT_graphics_pipeline_library 1")]
        public const int VK_EXT_graphics_pipeline_library = 1;

        [NativeTypeName("#define VK_EXT_GRAPHICS_PIPELINE_LIBRARY_SPEC_VERSION 1")]
        public const int VK_EXT_GRAPHICS_PIPELINE_LIBRARY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_GRAPHICS_PIPELINE_LIBRARY_EXTENSION_NAME \"VK_EXT_graphics_pipeline_library\"")]
        public static ReadOnlySpan<byte> VK_EXT_GRAPHICS_PIPELINE_LIBRARY_EXTENSION_NAME => "VK_EXT_graphics_pipeline_library"u8;

        [NativeTypeName("#define VK_AMD_shader_early_and_late_fragment_tests 1")]
        public const int VK_AMD_shader_early_and_late_fragment_tests = 1;

        [NativeTypeName("#define VK_AMD_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_SPEC_VERSION 1")]
        public const int VK_AMD_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_EXTENSION_NAME \"VK_AMD_shader_early_and_late_fragment_tests\"")]
        public static ReadOnlySpan<byte> VK_AMD_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_EXTENSION_NAME => "VK_AMD_shader_early_and_late_fragment_tests"u8;

        [NativeTypeName("#define VK_NV_fragment_shading_rate_enums 1")]
        public const int VK_NV_fragment_shading_rate_enums = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_SHADING_RATE_ENUMS_SPEC_VERSION 1")]
        public const int VK_NV_FRAGMENT_SHADING_RATE_ENUMS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_FRAGMENT_SHADING_RATE_ENUMS_EXTENSION_NAME \"VK_NV_fragment_shading_rate_enums\"")]
        public static ReadOnlySpan<byte> VK_NV_FRAGMENT_SHADING_RATE_ENUMS_EXTENSION_NAME => "VK_NV_fragment_shading_rate_enums"u8;

        [NativeTypeName("#define VK_NV_ray_tracing_motion_blur 1")]
        public const int VK_NV_ray_tracing_motion_blur = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_MOTION_BLUR_SPEC_VERSION 1")]
        public const int VK_NV_RAY_TRACING_MOTION_BLUR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_MOTION_BLUR_EXTENSION_NAME \"VK_NV_ray_tracing_motion_blur\"")]
        public static ReadOnlySpan<byte> VK_NV_RAY_TRACING_MOTION_BLUR_EXTENSION_NAME => "VK_NV_ray_tracing_motion_blur"u8;

        [NativeTypeName("#define VK_EXT_ycbcr_2plane_444_formats 1")]
        public const int VK_EXT_ycbcr_2plane_444_formats = 1;

        [NativeTypeName("#define VK_EXT_YCBCR_2PLANE_444_FORMATS_SPEC_VERSION 1")]
        public const int VK_EXT_YCBCR_2PLANE_444_FORMATS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_YCBCR_2PLANE_444_FORMATS_EXTENSION_NAME \"VK_EXT_ycbcr_2plane_444_formats\"")]
        public static ReadOnlySpan<byte> VK_EXT_YCBCR_2PLANE_444_FORMATS_EXTENSION_NAME => "VK_EXT_ycbcr_2plane_444_formats"u8;

        [NativeTypeName("#define VK_EXT_fragment_density_map2 1")]
        public const int VK_EXT_fragment_density_map2 = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_2_SPEC_VERSION 1")]
        public const int VK_EXT_FRAGMENT_DENSITY_MAP_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_2_EXTENSION_NAME \"VK_EXT_fragment_density_map2\"")]
        public static ReadOnlySpan<byte> VK_EXT_FRAGMENT_DENSITY_MAP_2_EXTENSION_NAME => "VK_EXT_fragment_density_map2"u8;

        [NativeTypeName("#define VK_QCOM_rotated_copy_commands 1")]
        public const int VK_QCOM_rotated_copy_commands = 1;

        [NativeTypeName("#define VK_QCOM_ROTATED_COPY_COMMANDS_SPEC_VERSION 2")]
        public const int VK_QCOM_ROTATED_COPY_COMMANDS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_QCOM_ROTATED_COPY_COMMANDS_EXTENSION_NAME \"VK_QCOM_rotated_copy_commands\"")]
        public static ReadOnlySpan<byte> VK_QCOM_ROTATED_COPY_COMMANDS_EXTENSION_NAME => "VK_QCOM_rotated_copy_commands"u8;

        [NativeTypeName("#define VK_EXT_image_robustness 1")]
        public const int VK_EXT_image_robustness = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_ROBUSTNESS_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_ROBUSTNESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_ROBUSTNESS_EXTENSION_NAME \"VK_EXT_image_robustness\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_ROBUSTNESS_EXTENSION_NAME => "VK_EXT_image_robustness"u8;

        [NativeTypeName("#define VK_EXT_image_compression_control 1")]
        public const int VK_EXT_image_compression_control = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_COMPRESSION_CONTROL_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_COMPRESSION_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_COMPRESSION_CONTROL_EXTENSION_NAME \"VK_EXT_image_compression_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_COMPRESSION_CONTROL_EXTENSION_NAME => "VK_EXT_image_compression_control"u8;

        [NativeTypeName("#define VK_EXT_attachment_feedback_loop_layout 1")]
        public const int VK_EXT_attachment_feedback_loop_layout = 1;

        [NativeTypeName("#define VK_EXT_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_SPEC_VERSION 2")]
        public const int VK_EXT_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_EXTENSION_NAME \"VK_EXT_attachment_feedback_loop_layout\"")]
        public static ReadOnlySpan<byte> VK_EXT_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_EXTENSION_NAME => "VK_EXT_attachment_feedback_loop_layout"u8;

        [NativeTypeName("#define VK_EXT_4444_formats 1")]
        public const int VK_EXT_4444_formats = 1;

        [NativeTypeName("#define VK_EXT_4444_FORMATS_SPEC_VERSION 1")]
        public const int VK_EXT_4444_FORMATS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_4444_FORMATS_EXTENSION_NAME \"VK_EXT_4444_formats\"")]
        public static ReadOnlySpan<byte> VK_EXT_4444_FORMATS_EXTENSION_NAME => "VK_EXT_4444_formats"u8;

        [NativeTypeName("#define VK_EXT_device_fault 1")]
        public const int VK_EXT_device_fault = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_FAULT_SPEC_VERSION 2")]
        public const int VK_EXT_DEVICE_FAULT_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_DEVICE_FAULT_EXTENSION_NAME \"VK_EXT_device_fault\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEVICE_FAULT_EXTENSION_NAME => "VK_EXT_device_fault"u8;

        [NativeTypeName("#define VK_ARM_rasterization_order_attachment_access 1")]
        public const int VK_ARM_rasterization_order_attachment_access = 1;

        [NativeTypeName("#define VK_ARM_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_SPEC_VERSION 1")]
        public const int VK_ARM_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_ARM_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME \"VK_ARM_rasterization_order_attachment_access\"")]
        public static ReadOnlySpan<byte> VK_ARM_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME => "VK_ARM_rasterization_order_attachment_access"u8;

        [NativeTypeName("#define VK_EXT_rgba10x6_formats 1")]
        public const int VK_EXT_rgba10x6_formats = 1;

        [NativeTypeName("#define VK_EXT_RGBA10X6_FORMATS_SPEC_VERSION 1")]
        public const int VK_EXT_RGBA10X6_FORMATS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_RGBA10X6_FORMATS_EXTENSION_NAME \"VK_EXT_rgba10x6_formats\"")]
        public static ReadOnlySpan<byte> VK_EXT_RGBA10X6_FORMATS_EXTENSION_NAME => "VK_EXT_rgba10x6_formats"u8;

        [NativeTypeName("#define VK_VALVE_mutable_descriptor_type 1")]
        public const int VK_VALVE_mutable_descriptor_type = 1;

        [NativeTypeName("#define VK_VALVE_MUTABLE_DESCRIPTOR_TYPE_SPEC_VERSION 1")]
        public const int VK_VALVE_MUTABLE_DESCRIPTOR_TYPE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_VALVE_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME \"VK_VALVE_mutable_descriptor_type\"")]
        public static ReadOnlySpan<byte> VK_VALVE_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME => "VK_VALVE_mutable_descriptor_type"u8;

        [NativeTypeName("#define VK_EXT_vertex_input_dynamic_state 1")]
        public const int VK_EXT_vertex_input_dynamic_state = 1;

        [NativeTypeName("#define VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_SPEC_VERSION 2")]
        public const int VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_EXTENSION_NAME \"VK_EXT_vertex_input_dynamic_state\"")]
        public static ReadOnlySpan<byte> VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_EXTENSION_NAME => "VK_EXT_vertex_input_dynamic_state"u8;

        [NativeTypeName("#define VK_EXT_physical_device_drm 1")]
        public const int VK_EXT_physical_device_drm = 1;

        [NativeTypeName("#define VK_EXT_PHYSICAL_DEVICE_DRM_SPEC_VERSION 1")]
        public const int VK_EXT_PHYSICAL_DEVICE_DRM_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PHYSICAL_DEVICE_DRM_EXTENSION_NAME \"VK_EXT_physical_device_drm\"")]
        public static ReadOnlySpan<byte> VK_EXT_PHYSICAL_DEVICE_DRM_EXTENSION_NAME => "VK_EXT_physical_device_drm"u8;

        [NativeTypeName("#define VK_EXT_device_address_binding_report 1")]
        public const int VK_EXT_device_address_binding_report = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_ADDRESS_BINDING_REPORT_SPEC_VERSION 1")]
        public const int VK_EXT_DEVICE_ADDRESS_BINDING_REPORT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_ADDRESS_BINDING_REPORT_EXTENSION_NAME \"VK_EXT_device_address_binding_report\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEVICE_ADDRESS_BINDING_REPORT_EXTENSION_NAME => "VK_EXT_device_address_binding_report"u8;

        [NativeTypeName("#define VK_EXT_depth_clip_control 1")]
        public const int VK_EXT_depth_clip_control = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLIP_CONTROL_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_CLIP_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLIP_CONTROL_EXTENSION_NAME \"VK_EXT_depth_clip_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_CLIP_CONTROL_EXTENSION_NAME => "VK_EXT_depth_clip_control"u8;

        [NativeTypeName("#define VK_EXT_primitive_topology_list_restart 1")]
        public const int VK_EXT_primitive_topology_list_restart = 1;

        [NativeTypeName("#define VK_EXT_PRIMITIVE_TOPOLOGY_LIST_RESTART_SPEC_VERSION 1")]
        public const int VK_EXT_PRIMITIVE_TOPOLOGY_LIST_RESTART_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PRIMITIVE_TOPOLOGY_LIST_RESTART_EXTENSION_NAME \"VK_EXT_primitive_topology_list_restart\"")]
        public static ReadOnlySpan<byte> VK_EXT_PRIMITIVE_TOPOLOGY_LIST_RESTART_EXTENSION_NAME => "VK_EXT_primitive_topology_list_restart"u8;

        [NativeTypeName("#define VK_EXT_present_mode_fifo_latest_ready 1")]
        public const int VK_EXT_present_mode_fifo_latest_ready = 1;

        [NativeTypeName("#define VK_EXT_PRESENT_MODE_FIFO_LATEST_READY_SPEC_VERSION 1")]
        public const int VK_EXT_PRESENT_MODE_FIFO_LATEST_READY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PRESENT_MODE_FIFO_LATEST_READY_EXTENSION_NAME \"VK_EXT_present_mode_fifo_latest_ready\"")]
        public static ReadOnlySpan<byte> VK_EXT_PRESENT_MODE_FIFO_LATEST_READY_EXTENSION_NAME => "VK_EXT_present_mode_fifo_latest_ready"u8;

        [NativeTypeName("#define VK_HUAWEI_subpass_shading 1")]
        public const int VK_HUAWEI_subpass_shading = 1;

        [NativeTypeName("#define VK_HUAWEI_SUBPASS_SHADING_SPEC_VERSION 3")]
        public const int VK_HUAWEI_SUBPASS_SHADING_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_HUAWEI_SUBPASS_SHADING_EXTENSION_NAME \"VK_HUAWEI_subpass_shading\"")]
        public static ReadOnlySpan<byte> VK_HUAWEI_SUBPASS_SHADING_EXTENSION_NAME => "VK_HUAWEI_subpass_shading"u8;

        [NativeTypeName("#define VK_HUAWEI_invocation_mask 1")]
        public const int VK_HUAWEI_invocation_mask = 1;

        [NativeTypeName("#define VK_HUAWEI_INVOCATION_MASK_SPEC_VERSION 1")]
        public const int VK_HUAWEI_INVOCATION_MASK_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_HUAWEI_INVOCATION_MASK_EXTENSION_NAME \"VK_HUAWEI_invocation_mask\"")]
        public static ReadOnlySpan<byte> VK_HUAWEI_INVOCATION_MASK_EXTENSION_NAME => "VK_HUAWEI_invocation_mask"u8;

        [NativeTypeName("#define VK_NV_external_memory_rdma 1")]
        public const int VK_NV_external_memory_rdma = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_RDMA_SPEC_VERSION 1")]
        public const int VK_NV_EXTERNAL_MEMORY_RDMA_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_RDMA_EXTENSION_NAME \"VK_NV_external_memory_rdma\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTERNAL_MEMORY_RDMA_EXTENSION_NAME => "VK_NV_external_memory_rdma"u8;

        [NativeTypeName("#define VK_EXT_pipeline_properties 1")]
        public const int VK_EXT_pipeline_properties = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_PROPERTIES_SPEC_VERSION 1")]
        public const int VK_EXT_PIPELINE_PROPERTIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_PROPERTIES_EXTENSION_NAME \"VK_EXT_pipeline_properties\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_PROPERTIES_EXTENSION_NAME => "VK_EXT_pipeline_properties"u8;

        [NativeTypeName("#define VK_EXT_frame_boundary 1")]
        public const int VK_EXT_frame_boundary = 1;

        [NativeTypeName("#define VK_EXT_FRAME_BOUNDARY_SPEC_VERSION 1")]
        public const int VK_EXT_FRAME_BOUNDARY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_FRAME_BOUNDARY_EXTENSION_NAME \"VK_EXT_frame_boundary\"")]
        public static ReadOnlySpan<byte> VK_EXT_FRAME_BOUNDARY_EXTENSION_NAME => "VK_EXT_frame_boundary"u8;

        [NativeTypeName("#define VK_EXT_multisampled_render_to_single_sampled 1")]
        public const int VK_EXT_multisampled_render_to_single_sampled = 1;

        [NativeTypeName("#define VK_EXT_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_SPEC_VERSION 1")]
        public const int VK_EXT_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_EXTENSION_NAME \"VK_EXT_multisampled_render_to_single_sampled\"")]
        public static ReadOnlySpan<byte> VK_EXT_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_EXTENSION_NAME => "VK_EXT_multisampled_render_to_single_sampled"u8;

        [NativeTypeName("#define VK_EXT_extended_dynamic_state2 1")]
        public const int VK_EXT_extended_dynamic_state2 = 1;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_2_SPEC_VERSION 1")]
        public const int VK_EXT_EXTENDED_DYNAMIC_STATE_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_2_EXTENSION_NAME \"VK_EXT_extended_dynamic_state2\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTENDED_DYNAMIC_STATE_2_EXTENSION_NAME => "VK_EXT_extended_dynamic_state2"u8;

        [NativeTypeName("#define VK_EXT_color_write_enable 1")]
        public const int VK_EXT_color_write_enable = 1;

        [NativeTypeName("#define VK_EXT_COLOR_WRITE_ENABLE_SPEC_VERSION 1")]
        public const int VK_EXT_COLOR_WRITE_ENABLE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_COLOR_WRITE_ENABLE_EXTENSION_NAME \"VK_EXT_color_write_enable\"")]
        public static ReadOnlySpan<byte> VK_EXT_COLOR_WRITE_ENABLE_EXTENSION_NAME => "VK_EXT_color_write_enable"u8;

        [NativeTypeName("#define VK_EXT_primitives_generated_query 1")]
        public const int VK_EXT_primitives_generated_query = 1;

        [NativeTypeName("#define VK_EXT_PRIMITIVES_GENERATED_QUERY_SPEC_VERSION 1")]
        public const int VK_EXT_PRIMITIVES_GENERATED_QUERY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PRIMITIVES_GENERATED_QUERY_EXTENSION_NAME \"VK_EXT_primitives_generated_query\"")]
        public static ReadOnlySpan<byte> VK_EXT_PRIMITIVES_GENERATED_QUERY_EXTENSION_NAME => "VK_EXT_primitives_generated_query"u8;

        [NativeTypeName("#define VK_EXT_global_priority_query 1")]
        public const int VK_EXT_global_priority_query = 1;

        [NativeTypeName("#define VK_EXT_GLOBAL_PRIORITY_QUERY_SPEC_VERSION 1")]
        public const int VK_EXT_GLOBAL_PRIORITY_QUERY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_GLOBAL_PRIORITY_QUERY_EXTENSION_NAME \"VK_EXT_global_priority_query\"")]
        public static ReadOnlySpan<byte> VK_EXT_GLOBAL_PRIORITY_QUERY_EXTENSION_NAME => "VK_EXT_global_priority_query"u8;

        [NativeTypeName("#define VK_MAX_GLOBAL_PRIORITY_SIZE_EXT VK_MAX_GLOBAL_PRIORITY_SIZE")]
        public const uint VK_MAX_GLOBAL_PRIORITY_SIZE_EXT = 16U;

        [NativeTypeName("#define VK_EXT_image_view_min_lod 1")]
        public const int VK_EXT_image_view_min_lod = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_VIEW_MIN_LOD_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_VIEW_MIN_LOD_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_VIEW_MIN_LOD_EXTENSION_NAME \"VK_EXT_image_view_min_lod\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_VIEW_MIN_LOD_EXTENSION_NAME => "VK_EXT_image_view_min_lod"u8;

        [NativeTypeName("#define VK_EXT_multi_draw 1")]
        public const int VK_EXT_multi_draw = 1;

        [NativeTypeName("#define VK_EXT_MULTI_DRAW_SPEC_VERSION 1")]
        public const int VK_EXT_MULTI_DRAW_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MULTI_DRAW_EXTENSION_NAME \"VK_EXT_multi_draw\"")]
        public static ReadOnlySpan<byte> VK_EXT_MULTI_DRAW_EXTENSION_NAME => "VK_EXT_multi_draw"u8;

        [NativeTypeName("#define VK_EXT_image_2d_view_of_3d 1")]
        public const int VK_EXT_image_2d_view_of_3d = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_2D_VIEW_OF_3D_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_2D_VIEW_OF_3D_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_2D_VIEW_OF_3D_EXTENSION_NAME \"VK_EXT_image_2d_view_of_3d\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_2D_VIEW_OF_3D_EXTENSION_NAME => "VK_EXT_image_2d_view_of_3d"u8;

        [NativeTypeName("#define VK_EXT_shader_tile_image 1")]
        public const int VK_EXT_shader_tile_image = 1;

        [NativeTypeName("#define VK_EXT_SHADER_TILE_IMAGE_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_TILE_IMAGE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_TILE_IMAGE_EXTENSION_NAME \"VK_EXT_shader_tile_image\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_TILE_IMAGE_EXTENSION_NAME => "VK_EXT_shader_tile_image"u8;

        [NativeTypeName("#define VK_EXT_opacity_micromap 1")]
        public const int VK_EXT_opacity_micromap = 1;

        [NativeTypeName("#define VK_EXT_OPACITY_MICROMAP_SPEC_VERSION 2")]
        public const int VK_EXT_OPACITY_MICROMAP_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_OPACITY_MICROMAP_EXTENSION_NAME \"VK_EXT_opacity_micromap\"")]
        public static ReadOnlySpan<byte> VK_EXT_OPACITY_MICROMAP_EXTENSION_NAME => "VK_EXT_opacity_micromap"u8;

        [NativeTypeName("#define VK_EXT_load_store_op_none 1")]
        public const int VK_EXT_load_store_op_none = 1;

        [NativeTypeName("#define VK_EXT_LOAD_STORE_OP_NONE_SPEC_VERSION 1")]
        public const int VK_EXT_LOAD_STORE_OP_NONE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_LOAD_STORE_OP_NONE_EXTENSION_NAME \"VK_EXT_load_store_op_none\"")]
        public static ReadOnlySpan<byte> VK_EXT_LOAD_STORE_OP_NONE_EXTENSION_NAME => "VK_EXT_load_store_op_none"u8;

        [NativeTypeName("#define VK_HUAWEI_cluster_culling_shader 1")]
        public const int VK_HUAWEI_cluster_culling_shader = 1;

        [NativeTypeName("#define VK_HUAWEI_CLUSTER_CULLING_SHADER_SPEC_VERSION 3")]
        public const int VK_HUAWEI_CLUSTER_CULLING_SHADER_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_HUAWEI_CLUSTER_CULLING_SHADER_EXTENSION_NAME \"VK_HUAWEI_cluster_culling_shader\"")]
        public static ReadOnlySpan<byte> VK_HUAWEI_CLUSTER_CULLING_SHADER_EXTENSION_NAME => "VK_HUAWEI_cluster_culling_shader"u8;

        [NativeTypeName("#define VK_EXT_border_color_swizzle 1")]
        public const int VK_EXT_border_color_swizzle = 1;

        [NativeTypeName("#define VK_EXT_BORDER_COLOR_SWIZZLE_SPEC_VERSION 1")]
        public const int VK_EXT_BORDER_COLOR_SWIZZLE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_BORDER_COLOR_SWIZZLE_EXTENSION_NAME \"VK_EXT_border_color_swizzle\"")]
        public static ReadOnlySpan<byte> VK_EXT_BORDER_COLOR_SWIZZLE_EXTENSION_NAME => "VK_EXT_border_color_swizzle"u8;

        [NativeTypeName("#define VK_EXT_pageable_device_local_memory 1")]
        public const int VK_EXT_pageable_device_local_memory = 1;

        [NativeTypeName("#define VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_SPEC_VERSION 1")]
        public const int VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_EXTENSION_NAME \"VK_EXT_pageable_device_local_memory\"")]
        public static ReadOnlySpan<byte> VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_EXTENSION_NAME => "VK_EXT_pageable_device_local_memory"u8;

        [NativeTypeName("#define VK_ARM_shader_core_properties 1")]
        public const int VK_ARM_shader_core_properties = 1;

        [NativeTypeName("#define VK_ARM_SHADER_CORE_PROPERTIES_SPEC_VERSION 1")]
        public const int VK_ARM_SHADER_CORE_PROPERTIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_ARM_SHADER_CORE_PROPERTIES_EXTENSION_NAME \"VK_ARM_shader_core_properties\"")]
        public static ReadOnlySpan<byte> VK_ARM_SHADER_CORE_PROPERTIES_EXTENSION_NAME => "VK_ARM_shader_core_properties"u8;

        [NativeTypeName("#define VK_ARM_scheduling_controls 1")]
        public const int VK_ARM_scheduling_controls = 1;

        [NativeTypeName("#define VK_ARM_SCHEDULING_CONTROLS_SPEC_VERSION 1")]
        public const int VK_ARM_SCHEDULING_CONTROLS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_ARM_SCHEDULING_CONTROLS_EXTENSION_NAME \"VK_ARM_scheduling_controls\"")]
        public static ReadOnlySpan<byte> VK_ARM_SCHEDULING_CONTROLS_EXTENSION_NAME => "VK_ARM_scheduling_controls"u8;

        [NativeTypeName("#define VK_EXT_image_sliced_view_of_3d 1")]
        public const int VK_EXT_image_sliced_view_of_3d = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_SLICED_VIEW_OF_3D_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_SLICED_VIEW_OF_3D_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_SLICED_VIEW_OF_3D_EXTENSION_NAME \"VK_EXT_image_sliced_view_of_3d\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_SLICED_VIEW_OF_3D_EXTENSION_NAME => "VK_EXT_image_sliced_view_of_3d"u8;

        [NativeTypeName("#define VK_REMAINING_3D_SLICES_EXT (~0U)")]
        public const uint VK_REMAINING_3D_SLICES_EXT = (~0U);

        [NativeTypeName("#define VK_VALVE_descriptor_set_host_mapping 1")]
        public const int VK_VALVE_descriptor_set_host_mapping = 1;

        [NativeTypeName("#define VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_SPEC_VERSION 1")]
        public const int VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_EXTENSION_NAME \"VK_VALVE_descriptor_set_host_mapping\"")]
        public static ReadOnlySpan<byte> VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_EXTENSION_NAME => "VK_VALVE_descriptor_set_host_mapping"u8;

        [NativeTypeName("#define VK_EXT_depth_clamp_zero_one 1")]
        public const int VK_EXT_depth_clamp_zero_one = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLAMP_ZERO_ONE_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_CLAMP_ZERO_ONE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME \"VK_EXT_depth_clamp_zero_one\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME => "VK_EXT_depth_clamp_zero_one"u8;

        [NativeTypeName("#define VK_EXT_non_seamless_cube_map 1")]
        public const int VK_EXT_non_seamless_cube_map = 1;

        [NativeTypeName("#define VK_EXT_NON_SEAMLESS_CUBE_MAP_SPEC_VERSION 1")]
        public const int VK_EXT_NON_SEAMLESS_CUBE_MAP_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_NON_SEAMLESS_CUBE_MAP_EXTENSION_NAME \"VK_EXT_non_seamless_cube_map\"")]
        public static ReadOnlySpan<byte> VK_EXT_NON_SEAMLESS_CUBE_MAP_EXTENSION_NAME => "VK_EXT_non_seamless_cube_map"u8;

        [NativeTypeName("#define VK_ARM_render_pass_striped 1")]
        public const int VK_ARM_render_pass_striped = 1;

        [NativeTypeName("#define VK_ARM_RENDER_PASS_STRIPED_SPEC_VERSION 1")]
        public const int VK_ARM_RENDER_PASS_STRIPED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_ARM_RENDER_PASS_STRIPED_EXTENSION_NAME \"VK_ARM_render_pass_striped\"")]
        public static ReadOnlySpan<byte> VK_ARM_RENDER_PASS_STRIPED_EXTENSION_NAME => "VK_ARM_render_pass_striped"u8;

        [NativeTypeName("#define VK_QCOM_fragment_density_map_offset 1")]
        public const int VK_QCOM_fragment_density_map_offset = 1;

        [NativeTypeName("#define VK_QCOM_FRAGMENT_DENSITY_MAP_OFFSET_SPEC_VERSION 3")]
        public const int VK_QCOM_FRAGMENT_DENSITY_MAP_OFFSET_SPEC_VERSION = 3;

        [NativeTypeName("#define VK_QCOM_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME \"VK_QCOM_fragment_density_map_offset\"")]
        public static ReadOnlySpan<byte> VK_QCOM_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME => "VK_QCOM_fragment_density_map_offset"u8;

        [NativeTypeName("#define VK_NV_copy_memory_indirect 1")]
        public const int VK_NV_copy_memory_indirect = 1;

        [NativeTypeName("#define VK_NV_COPY_MEMORY_INDIRECT_SPEC_VERSION 1")]
        public const int VK_NV_COPY_MEMORY_INDIRECT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COPY_MEMORY_INDIRECT_EXTENSION_NAME \"VK_NV_copy_memory_indirect\"")]
        public static ReadOnlySpan<byte> VK_NV_COPY_MEMORY_INDIRECT_EXTENSION_NAME => "VK_NV_copy_memory_indirect"u8;

        [NativeTypeName("#define VK_NV_memory_decompression 1")]
        public const int VK_NV_memory_decompression = 1;

        [NativeTypeName("#define VK_NV_MEMORY_DECOMPRESSION_SPEC_VERSION 1")]
        public const int VK_NV_MEMORY_DECOMPRESSION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_MEMORY_DECOMPRESSION_EXTENSION_NAME \"VK_NV_memory_decompression\"")]
        public static ReadOnlySpan<byte> VK_NV_MEMORY_DECOMPRESSION_EXTENSION_NAME => "VK_NV_memory_decompression"u8;

        [NativeTypeName("#define VK_NV_device_generated_commands_compute 1")]
        public const int VK_NV_device_generated_commands_compute = 1;

        [NativeTypeName("#define VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_SPEC_VERSION 2")]
        public const int VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_EXTENSION_NAME \"VK_NV_device_generated_commands_compute\"")]
        public static ReadOnlySpan<byte> VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_EXTENSION_NAME => "VK_NV_device_generated_commands_compute"u8;

        [NativeTypeName("#define VK_NV_ray_tracing_linear_swept_spheres 1")]
        public const int VK_NV_ray_tracing_linear_swept_spheres = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_LINEAR_SWEPT_SPHERES_SPEC_VERSION 1")]
        public const int VK_NV_RAY_TRACING_LINEAR_SWEPT_SPHERES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_LINEAR_SWEPT_SPHERES_EXTENSION_NAME \"VK_NV_ray_tracing_linear_swept_spheres\"")]
        public static ReadOnlySpan<byte> VK_NV_RAY_TRACING_LINEAR_SWEPT_SPHERES_EXTENSION_NAME => "VK_NV_ray_tracing_linear_swept_spheres"u8;

        [NativeTypeName("#define VK_NV_linear_color_attachment 1")]
        public const int VK_NV_linear_color_attachment = 1;

        [NativeTypeName("#define VK_NV_LINEAR_COLOR_ATTACHMENT_SPEC_VERSION 1")]
        public const int VK_NV_LINEAR_COLOR_ATTACHMENT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_LINEAR_COLOR_ATTACHMENT_EXTENSION_NAME \"VK_NV_linear_color_attachment\"")]
        public static ReadOnlySpan<byte> VK_NV_LINEAR_COLOR_ATTACHMENT_EXTENSION_NAME => "VK_NV_linear_color_attachment"u8;

        [NativeTypeName("#define VK_GOOGLE_surfaceless_query 1")]
        public const int VK_GOOGLE_surfaceless_query = 1;

        [NativeTypeName("#define VK_GOOGLE_SURFACELESS_QUERY_SPEC_VERSION 2")]
        public const int VK_GOOGLE_SURFACELESS_QUERY_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_GOOGLE_SURFACELESS_QUERY_EXTENSION_NAME \"VK_GOOGLE_surfaceless_query\"")]
        public static ReadOnlySpan<byte> VK_GOOGLE_SURFACELESS_QUERY_EXTENSION_NAME => "VK_GOOGLE_surfaceless_query"u8;

        [NativeTypeName("#define VK_EXT_image_compression_control_swapchain 1")]
        public const int VK_EXT_image_compression_control_swapchain = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_SPEC_VERSION 1")]
        public const int VK_EXT_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_EXTENSION_NAME \"VK_EXT_image_compression_control_swapchain\"")]
        public static ReadOnlySpan<byte> VK_EXT_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_EXTENSION_NAME => "VK_EXT_image_compression_control_swapchain"u8;

        [NativeTypeName("#define VK_QCOM_image_processing 1")]
        public const int VK_QCOM_image_processing = 1;

        [NativeTypeName("#define VK_QCOM_IMAGE_PROCESSING_SPEC_VERSION 1")]
        public const int VK_QCOM_IMAGE_PROCESSING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_IMAGE_PROCESSING_EXTENSION_NAME \"VK_QCOM_image_processing\"")]
        public static ReadOnlySpan<byte> VK_QCOM_IMAGE_PROCESSING_EXTENSION_NAME => "VK_QCOM_image_processing"u8;

        [NativeTypeName("#define VK_EXT_nested_command_buffer 1")]
        public const int VK_EXT_nested_command_buffer = 1;

        [NativeTypeName("#define VK_EXT_NESTED_COMMAND_BUFFER_SPEC_VERSION 1")]
        public const int VK_EXT_NESTED_COMMAND_BUFFER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_NESTED_COMMAND_BUFFER_EXTENSION_NAME \"VK_EXT_nested_command_buffer\"")]
        public static ReadOnlySpan<byte> VK_EXT_NESTED_COMMAND_BUFFER_EXTENSION_NAME => "VK_EXT_nested_command_buffer"u8;

        [NativeTypeName("#define VK_EXT_external_memory_acquire_unmodified 1")]
        public const int VK_EXT_external_memory_acquire_unmodified = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_SPEC_VERSION 1")]
        public const int VK_EXT_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_EXTENSION_NAME \"VK_EXT_external_memory_acquire_unmodified\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_EXTENSION_NAME => "VK_EXT_external_memory_acquire_unmodified"u8;

        [NativeTypeName("#define VK_EXT_extended_dynamic_state3 1")]
        public const int VK_EXT_extended_dynamic_state3 = 1;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_3_SPEC_VERSION 2")]
        public const int VK_EXT_EXTENDED_DYNAMIC_STATE_3_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_EXTENDED_DYNAMIC_STATE_3_EXTENSION_NAME \"VK_EXT_extended_dynamic_state3\"")]
        public static ReadOnlySpan<byte> VK_EXT_EXTENDED_DYNAMIC_STATE_3_EXTENSION_NAME => "VK_EXT_extended_dynamic_state3"u8;

        [NativeTypeName("#define VK_EXT_subpass_merge_feedback 1")]
        public const int VK_EXT_subpass_merge_feedback = 1;

        [NativeTypeName("#define VK_EXT_SUBPASS_MERGE_FEEDBACK_SPEC_VERSION 2")]
        public const int VK_EXT_SUBPASS_MERGE_FEEDBACK_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_SUBPASS_MERGE_FEEDBACK_EXTENSION_NAME \"VK_EXT_subpass_merge_feedback\"")]
        public static ReadOnlySpan<byte> VK_EXT_SUBPASS_MERGE_FEEDBACK_EXTENSION_NAME => "VK_EXT_subpass_merge_feedback"u8;

        [NativeTypeName("#define VK_LUNARG_direct_driver_loading 1")]
        public const int VK_LUNARG_direct_driver_loading = 1;

        [NativeTypeName("#define VK_LUNARG_DIRECT_DRIVER_LOADING_SPEC_VERSION 1")]
        public const int VK_LUNARG_DIRECT_DRIVER_LOADING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_LUNARG_DIRECT_DRIVER_LOADING_EXTENSION_NAME \"VK_LUNARG_direct_driver_loading\"")]
        public static ReadOnlySpan<byte> VK_LUNARG_DIRECT_DRIVER_LOADING_EXTENSION_NAME => "VK_LUNARG_direct_driver_loading"u8;

        [NativeTypeName("#define VK_EXT_shader_module_identifier 1")]
        public const int VK_EXT_shader_module_identifier = 1;

        [NativeTypeName("#define VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT 32U")]
        public const uint VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT = 32U;

        [NativeTypeName("#define VK_EXT_SHADER_MODULE_IDENTIFIER_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_MODULE_IDENTIFIER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_MODULE_IDENTIFIER_EXTENSION_NAME \"VK_EXT_shader_module_identifier\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_MODULE_IDENTIFIER_EXTENSION_NAME => "VK_EXT_shader_module_identifier"u8;

        [NativeTypeName("#define VK_EXT_rasterization_order_attachment_access 1")]
        public const int VK_EXT_rasterization_order_attachment_access = 1;

        [NativeTypeName("#define VK_EXT_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_SPEC_VERSION 1")]
        public const int VK_EXT_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME \"VK_EXT_rasterization_order_attachment_access\"")]
        public static ReadOnlySpan<byte> VK_EXT_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME => "VK_EXT_rasterization_order_attachment_access"u8;

        [NativeTypeName("#define VK_NV_optical_flow 1")]
        public const int VK_NV_optical_flow = 1;

        [NativeTypeName("#define VK_NV_OPTICAL_FLOW_SPEC_VERSION 1")]
        public const int VK_NV_OPTICAL_FLOW_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_OPTICAL_FLOW_EXTENSION_NAME \"VK_NV_optical_flow\"")]
        public static ReadOnlySpan<byte> VK_NV_OPTICAL_FLOW_EXTENSION_NAME => "VK_NV_optical_flow"u8;

        [NativeTypeName("#define VK_EXT_legacy_dithering 1")]
        public const int VK_EXT_legacy_dithering = 1;

        [NativeTypeName("#define VK_EXT_LEGACY_DITHERING_SPEC_VERSION 2")]
        public const int VK_EXT_LEGACY_DITHERING_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_LEGACY_DITHERING_EXTENSION_NAME \"VK_EXT_legacy_dithering\"")]
        public static ReadOnlySpan<byte> VK_EXT_LEGACY_DITHERING_EXTENSION_NAME => "VK_EXT_legacy_dithering"u8;

        [NativeTypeName("#define VK_EXT_pipeline_protected_access 1")]
        public const int VK_EXT_pipeline_protected_access = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_PROTECTED_ACCESS_SPEC_VERSION 1")]
        public const int VK_EXT_PIPELINE_PROTECTED_ACCESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_PROTECTED_ACCESS_EXTENSION_NAME \"VK_EXT_pipeline_protected_access\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_PROTECTED_ACCESS_EXTENSION_NAME => "VK_EXT_pipeline_protected_access"u8;

        [NativeTypeName("#define VK_AMD_anti_lag 1")]
        public const int VK_AMD_anti_lag = 1;

        [NativeTypeName("#define VK_AMD_ANTI_LAG_SPEC_VERSION 1")]
        public const int VK_AMD_ANTI_LAG_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_AMD_ANTI_LAG_EXTENSION_NAME \"VK_AMD_anti_lag\"")]
        public static ReadOnlySpan<byte> VK_AMD_ANTI_LAG_EXTENSION_NAME => "VK_AMD_anti_lag"u8;

        [NativeTypeName("#define VK_EXT_shader_object 1")]
        public const int VK_EXT_shader_object = 1;

        [NativeTypeName("#define VK_EXT_SHADER_OBJECT_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_OBJECT_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_OBJECT_EXTENSION_NAME \"VK_EXT_shader_object\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_OBJECT_EXTENSION_NAME => "VK_EXT_shader_object"u8;

        [NativeTypeName("#define VK_QCOM_tile_properties 1")]
        public const int VK_QCOM_tile_properties = 1;

        [NativeTypeName("#define VK_QCOM_TILE_PROPERTIES_SPEC_VERSION 1")]
        public const int VK_QCOM_TILE_PROPERTIES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_TILE_PROPERTIES_EXTENSION_NAME \"VK_QCOM_tile_properties\"")]
        public static ReadOnlySpan<byte> VK_QCOM_TILE_PROPERTIES_EXTENSION_NAME => "VK_QCOM_tile_properties"u8;

        [NativeTypeName("#define VK_SEC_amigo_profiling 1")]
        public const int VK_SEC_amigo_profiling = 1;

        [NativeTypeName("#define VK_SEC_AMIGO_PROFILING_SPEC_VERSION 1")]
        public const int VK_SEC_AMIGO_PROFILING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_SEC_AMIGO_PROFILING_EXTENSION_NAME \"VK_SEC_amigo_profiling\"")]
        public static ReadOnlySpan<byte> VK_SEC_AMIGO_PROFILING_EXTENSION_NAME => "VK_SEC_amigo_profiling"u8;

        [NativeTypeName("#define VK_QCOM_multiview_per_view_viewports 1")]
        public const int VK_QCOM_multiview_per_view_viewports = 1;

        [NativeTypeName("#define VK_QCOM_MULTIVIEW_PER_VIEW_VIEWPORTS_SPEC_VERSION 1")]
        public const int VK_QCOM_MULTIVIEW_PER_VIEW_VIEWPORTS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_MULTIVIEW_PER_VIEW_VIEWPORTS_EXTENSION_NAME \"VK_QCOM_multiview_per_view_viewports\"")]
        public static ReadOnlySpan<byte> VK_QCOM_MULTIVIEW_PER_VIEW_VIEWPORTS_EXTENSION_NAME => "VK_QCOM_multiview_per_view_viewports"u8;

        [NativeTypeName("#define VK_NV_ray_tracing_invocation_reorder 1")]
        public const int VK_NV_ray_tracing_invocation_reorder = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_INVOCATION_REORDER_SPEC_VERSION 1")]
        public const int VK_NV_RAY_TRACING_INVOCATION_REORDER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_INVOCATION_REORDER_EXTENSION_NAME \"VK_NV_ray_tracing_invocation_reorder\"")]
        public static ReadOnlySpan<byte> VK_NV_RAY_TRACING_INVOCATION_REORDER_EXTENSION_NAME => "VK_NV_ray_tracing_invocation_reorder"u8;

        [NativeTypeName("#define VK_NV_cooperative_vector 1")]
        public const int VK_NV_cooperative_vector = 1;

        [NativeTypeName("#define VK_NV_COOPERATIVE_VECTOR_SPEC_VERSION 4")]
        public const int VK_NV_COOPERATIVE_VECTOR_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_NV_COOPERATIVE_VECTOR_EXTENSION_NAME \"VK_NV_cooperative_vector\"")]
        public static ReadOnlySpan<byte> VK_NV_COOPERATIVE_VECTOR_EXTENSION_NAME => "VK_NV_cooperative_vector"u8;

        [NativeTypeName("#define VK_NV_extended_sparse_address_space 1")]
        public const int VK_NV_extended_sparse_address_space = 1;

        [NativeTypeName("#define VK_NV_EXTENDED_SPARSE_ADDRESS_SPACE_SPEC_VERSION 1")]
        public const int VK_NV_EXTENDED_SPARSE_ADDRESS_SPACE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTENDED_SPARSE_ADDRESS_SPACE_EXTENSION_NAME \"VK_NV_extended_sparse_address_space\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTENDED_SPARSE_ADDRESS_SPACE_EXTENSION_NAME => "VK_NV_extended_sparse_address_space"u8;

        [NativeTypeName("#define VK_EXT_mutable_descriptor_type 1")]
        public const int VK_EXT_mutable_descriptor_type = 1;

        [NativeTypeName("#define VK_EXT_MUTABLE_DESCRIPTOR_TYPE_SPEC_VERSION 1")]
        public const int VK_EXT_MUTABLE_DESCRIPTOR_TYPE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME \"VK_EXT_mutable_descriptor_type\"")]
        public static ReadOnlySpan<byte> VK_EXT_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME => "VK_EXT_mutable_descriptor_type"u8;

        [NativeTypeName("#define VK_EXT_legacy_vertex_attributes 1")]
        public const int VK_EXT_legacy_vertex_attributes = 1;

        [NativeTypeName("#define VK_EXT_LEGACY_VERTEX_ATTRIBUTES_SPEC_VERSION 1")]
        public const int VK_EXT_LEGACY_VERTEX_ATTRIBUTES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_LEGACY_VERTEX_ATTRIBUTES_EXTENSION_NAME \"VK_EXT_legacy_vertex_attributes\"")]
        public static ReadOnlySpan<byte> VK_EXT_LEGACY_VERTEX_ATTRIBUTES_EXTENSION_NAME => "VK_EXT_legacy_vertex_attributes"u8;

        [NativeTypeName("#define VK_EXT_layer_settings 1")]
        public const int VK_EXT_layer_settings = 1;

        [NativeTypeName("#define VK_EXT_LAYER_SETTINGS_SPEC_VERSION 2")]
        public const int VK_EXT_LAYER_SETTINGS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_EXT_LAYER_SETTINGS_EXTENSION_NAME \"VK_EXT_layer_settings\"")]
        public static ReadOnlySpan<byte> VK_EXT_LAYER_SETTINGS_EXTENSION_NAME => "VK_EXT_layer_settings"u8;

        [NativeTypeName("#define VK_ARM_shader_core_builtins 1")]
        public const int VK_ARM_shader_core_builtins = 1;

        [NativeTypeName("#define VK_ARM_SHADER_CORE_BUILTINS_SPEC_VERSION 2")]
        public const int VK_ARM_SHADER_CORE_BUILTINS_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_ARM_SHADER_CORE_BUILTINS_EXTENSION_NAME \"VK_ARM_shader_core_builtins\"")]
        public static ReadOnlySpan<byte> VK_ARM_SHADER_CORE_BUILTINS_EXTENSION_NAME => "VK_ARM_shader_core_builtins"u8;

        [NativeTypeName("#define VK_EXT_pipeline_library_group_handles 1")]
        public const int VK_EXT_pipeline_library_group_handles = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_LIBRARY_GROUP_HANDLES_SPEC_VERSION 1")]
        public const int VK_EXT_PIPELINE_LIBRARY_GROUP_HANDLES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_PIPELINE_LIBRARY_GROUP_HANDLES_EXTENSION_NAME \"VK_EXT_pipeline_library_group_handles\"")]
        public static ReadOnlySpan<byte> VK_EXT_PIPELINE_LIBRARY_GROUP_HANDLES_EXTENSION_NAME => "VK_EXT_pipeline_library_group_handles"u8;

        [NativeTypeName("#define VK_EXT_dynamic_rendering_unused_attachments 1")]
        public const int VK_EXT_dynamic_rendering_unused_attachments = 1;

        [NativeTypeName("#define VK_EXT_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_SPEC_VERSION 1")]
        public const int VK_EXT_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_EXTENSION_NAME \"VK_EXT_dynamic_rendering_unused_attachments\"")]
        public static ReadOnlySpan<byte> VK_EXT_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_EXTENSION_NAME => "VK_EXT_dynamic_rendering_unused_attachments"u8;

        [NativeTypeName("#define VK_NV_low_latency2 1")]
        public const int VK_NV_low_latency2 = 1;

        [NativeTypeName("#define VK_NV_LOW_LATENCY_2_SPEC_VERSION 2")]
        public const int VK_NV_LOW_LATENCY_2_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_LOW_LATENCY_2_EXTENSION_NAME \"VK_NV_low_latency2\"")]
        public static ReadOnlySpan<byte> VK_NV_LOW_LATENCY_2_EXTENSION_NAME => "VK_NV_low_latency2"u8;

        [NativeTypeName("#define VK_QCOM_multiview_per_view_render_areas 1")]
        public const int VK_QCOM_multiview_per_view_render_areas = 1;

        [NativeTypeName("#define VK_QCOM_MULTIVIEW_PER_VIEW_RENDER_AREAS_SPEC_VERSION 1")]
        public const int VK_QCOM_MULTIVIEW_PER_VIEW_RENDER_AREAS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_MULTIVIEW_PER_VIEW_RENDER_AREAS_EXTENSION_NAME \"VK_QCOM_multiview_per_view_render_areas\"")]
        public static ReadOnlySpan<byte> VK_QCOM_MULTIVIEW_PER_VIEW_RENDER_AREAS_EXTENSION_NAME => "VK_QCOM_multiview_per_view_render_areas"u8;

        [NativeTypeName("#define VK_NV_per_stage_descriptor_set 1")]
        public const int VK_NV_per_stage_descriptor_set = 1;

        [NativeTypeName("#define VK_NV_PER_STAGE_DESCRIPTOR_SET_SPEC_VERSION 1")]
        public const int VK_NV_PER_STAGE_DESCRIPTOR_SET_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_PER_STAGE_DESCRIPTOR_SET_EXTENSION_NAME \"VK_NV_per_stage_descriptor_set\"")]
        public static ReadOnlySpan<byte> VK_NV_PER_STAGE_DESCRIPTOR_SET_EXTENSION_NAME => "VK_NV_per_stage_descriptor_set"u8;

        [NativeTypeName("#define VK_QCOM_image_processing2 1")]
        public const int VK_QCOM_image_processing2 = 1;

        [NativeTypeName("#define VK_QCOM_IMAGE_PROCESSING_2_SPEC_VERSION 1")]
        public const int VK_QCOM_IMAGE_PROCESSING_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_IMAGE_PROCESSING_2_EXTENSION_NAME \"VK_QCOM_image_processing2\"")]
        public static ReadOnlySpan<byte> VK_QCOM_IMAGE_PROCESSING_2_EXTENSION_NAME => "VK_QCOM_image_processing2"u8;

        [NativeTypeName("#define VK_QCOM_filter_cubic_weights 1")]
        public const int VK_QCOM_filter_cubic_weights = 1;

        [NativeTypeName("#define VK_QCOM_FILTER_CUBIC_WEIGHTS_SPEC_VERSION 1")]
        public const int VK_QCOM_FILTER_CUBIC_WEIGHTS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_FILTER_CUBIC_WEIGHTS_EXTENSION_NAME \"VK_QCOM_filter_cubic_weights\"")]
        public static ReadOnlySpan<byte> VK_QCOM_FILTER_CUBIC_WEIGHTS_EXTENSION_NAME => "VK_QCOM_filter_cubic_weights"u8;

        [NativeTypeName("#define VK_QCOM_ycbcr_degamma 1")]
        public const int VK_QCOM_ycbcr_degamma = 1;

        [NativeTypeName("#define VK_QCOM_YCBCR_DEGAMMA_SPEC_VERSION 1")]
        public const int VK_QCOM_YCBCR_DEGAMMA_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_YCBCR_DEGAMMA_EXTENSION_NAME \"VK_QCOM_ycbcr_degamma\"")]
        public static ReadOnlySpan<byte> VK_QCOM_YCBCR_DEGAMMA_EXTENSION_NAME => "VK_QCOM_ycbcr_degamma"u8;

        [NativeTypeName("#define VK_QCOM_filter_cubic_clamp 1")]
        public const int VK_QCOM_filter_cubic_clamp = 1;

        [NativeTypeName("#define VK_QCOM_FILTER_CUBIC_CLAMP_SPEC_VERSION 1")]
        public const int VK_QCOM_FILTER_CUBIC_CLAMP_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_FILTER_CUBIC_CLAMP_EXTENSION_NAME \"VK_QCOM_filter_cubic_clamp\"")]
        public static ReadOnlySpan<byte> VK_QCOM_FILTER_CUBIC_CLAMP_EXTENSION_NAME => "VK_QCOM_filter_cubic_clamp"u8;

        [NativeTypeName("#define VK_EXT_attachment_feedback_loop_dynamic_state 1")]
        public const int VK_EXT_attachment_feedback_loop_dynamic_state = 1;

        [NativeTypeName("#define VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_SPEC_VERSION 1")]
        public const int VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_EXTENSION_NAME \"VK_EXT_attachment_feedback_loop_dynamic_state\"")]
        public static ReadOnlySpan<byte> VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_EXTENSION_NAME => "VK_EXT_attachment_feedback_loop_dynamic_state"u8;

        [NativeTypeName("#define VK_MSFT_layered_driver 1")]
        public const int VK_MSFT_layered_driver = 1;

        [NativeTypeName("#define VK_MSFT_LAYERED_DRIVER_SPEC_VERSION 1")]
        public const int VK_MSFT_LAYERED_DRIVER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_MSFT_LAYERED_DRIVER_EXTENSION_NAME \"VK_MSFT_layered_driver\"")]
        public static ReadOnlySpan<byte> VK_MSFT_LAYERED_DRIVER_EXTENSION_NAME => "VK_MSFT_layered_driver"u8;

        [NativeTypeName("#define VK_NV_descriptor_pool_overallocation 1")]
        public const int VK_NV_descriptor_pool_overallocation = 1;

        [NativeTypeName("#define VK_NV_DESCRIPTOR_POOL_OVERALLOCATION_SPEC_VERSION 1")]
        public const int VK_NV_DESCRIPTOR_POOL_OVERALLOCATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_DESCRIPTOR_POOL_OVERALLOCATION_EXTENSION_NAME \"VK_NV_descriptor_pool_overallocation\"")]
        public static ReadOnlySpan<byte> VK_NV_DESCRIPTOR_POOL_OVERALLOCATION_EXTENSION_NAME => "VK_NV_descriptor_pool_overallocation"u8;

        [NativeTypeName("#define VK_QCOM_tile_memory_heap 1")]
        public const int VK_QCOM_tile_memory_heap = 1;

        [NativeTypeName("#define VK_QCOM_TILE_MEMORY_HEAP_SPEC_VERSION 1")]
        public const int VK_QCOM_TILE_MEMORY_HEAP_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_QCOM_TILE_MEMORY_HEAP_EXTENSION_NAME \"VK_QCOM_tile_memory_heap\"")]
        public static ReadOnlySpan<byte> VK_QCOM_TILE_MEMORY_HEAP_EXTENSION_NAME => "VK_QCOM_tile_memory_heap"u8;

        [NativeTypeName("#define VK_NV_display_stereo 1")]
        public const int VK_NV_display_stereo = 1;

        [NativeTypeName("#define VK_NV_DISPLAY_STEREO_SPEC_VERSION 1")]
        public const int VK_NV_DISPLAY_STEREO_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_DISPLAY_STEREO_EXTENSION_NAME \"VK_NV_display_stereo\"")]
        public static ReadOnlySpan<byte> VK_NV_DISPLAY_STEREO_EXTENSION_NAME => "VK_NV_display_stereo"u8;

        [NativeTypeName("#define VK_NV_raw_access_chains 1")]
        public const int VK_NV_raw_access_chains = 1;

        [NativeTypeName("#define VK_NV_RAW_ACCESS_CHAINS_SPEC_VERSION 1")]
        public const int VK_NV_RAW_ACCESS_CHAINS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_RAW_ACCESS_CHAINS_EXTENSION_NAME \"VK_NV_raw_access_chains\"")]
        public static ReadOnlySpan<byte> VK_NV_RAW_ACCESS_CHAINS_EXTENSION_NAME => "VK_NV_raw_access_chains"u8;

        [NativeTypeName("#define VK_NV_external_compute_queue 1")]
        public const int VK_NV_external_compute_queue = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_COMPUTE_QUEUE_SPEC_VERSION 1")]
        public const int VK_NV_EXTERNAL_COMPUTE_QUEUE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_COMPUTE_QUEUE_EXTENSION_NAME \"VK_NV_external_compute_queue\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTERNAL_COMPUTE_QUEUE_EXTENSION_NAME => "VK_NV_external_compute_queue"u8;

        [NativeTypeName("#define VK_NV_command_buffer_inheritance 1")]
        public const int VK_NV_command_buffer_inheritance = 1;

        [NativeTypeName("#define VK_NV_COMMAND_BUFFER_INHERITANCE_SPEC_VERSION 1")]
        public const int VK_NV_COMMAND_BUFFER_INHERITANCE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COMMAND_BUFFER_INHERITANCE_EXTENSION_NAME \"VK_NV_command_buffer_inheritance\"")]
        public static ReadOnlySpan<byte> VK_NV_COMMAND_BUFFER_INHERITANCE_EXTENSION_NAME => "VK_NV_command_buffer_inheritance"u8;

        [NativeTypeName("#define VK_NV_shader_atomic_float16_vector 1")]
        public const int VK_NV_shader_atomic_float16_vector = 1;

        [NativeTypeName("#define VK_NV_SHADER_ATOMIC_FLOAT16_VECTOR_SPEC_VERSION 1")]
        public const int VK_NV_SHADER_ATOMIC_FLOAT16_VECTOR_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_SHADER_ATOMIC_FLOAT16_VECTOR_EXTENSION_NAME \"VK_NV_shader_atomic_float16_vector\"")]
        public static ReadOnlySpan<byte> VK_NV_SHADER_ATOMIC_FLOAT16_VECTOR_EXTENSION_NAME => "VK_NV_shader_atomic_float16_vector"u8;

        [NativeTypeName("#define VK_EXT_shader_replicated_composites 1")]
        public const int VK_EXT_shader_replicated_composites = 1;

        [NativeTypeName("#define VK_EXT_SHADER_REPLICATED_COMPOSITES_SPEC_VERSION 1")]
        public const int VK_EXT_SHADER_REPLICATED_COMPOSITES_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_SHADER_REPLICATED_COMPOSITES_EXTENSION_NAME \"VK_EXT_shader_replicated_composites\"")]
        public static ReadOnlySpan<byte> VK_EXT_SHADER_REPLICATED_COMPOSITES_EXTENSION_NAME => "VK_EXT_shader_replicated_composites"u8;

        [NativeTypeName("#define VK_NV_ray_tracing_validation 1")]
        public const int VK_NV_ray_tracing_validation = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_VALIDATION_SPEC_VERSION 1")]
        public const int VK_NV_RAY_TRACING_VALIDATION_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_RAY_TRACING_VALIDATION_EXTENSION_NAME \"VK_NV_ray_tracing_validation\"")]
        public static ReadOnlySpan<byte> VK_NV_RAY_TRACING_VALIDATION_EXTENSION_NAME => "VK_NV_ray_tracing_validation"u8;

        [NativeTypeName("#define VK_NV_cluster_acceleration_structure 1")]
        public const int VK_NV_cluster_acceleration_structure = 1;

        [NativeTypeName("#define VK_NV_CLUSTER_ACCELERATION_STRUCTURE_SPEC_VERSION 2")]
        public const int VK_NV_CLUSTER_ACCELERATION_STRUCTURE_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_CLUSTER_ACCELERATION_STRUCTURE_EXTENSION_NAME \"VK_NV_cluster_acceleration_structure\"")]
        public static ReadOnlySpan<byte> VK_NV_CLUSTER_ACCELERATION_STRUCTURE_EXTENSION_NAME => "VK_NV_cluster_acceleration_structure"u8;

        [NativeTypeName("#define VK_NV_partitioned_acceleration_structure 1")]
        public const int VK_NV_partitioned_acceleration_structure = 1;

        [NativeTypeName("#define VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_SPEC_VERSION 1")]
        public const int VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_EXTENSION_NAME \"VK_NV_partitioned_acceleration_structure\"")]
        public static ReadOnlySpan<byte> VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_EXTENSION_NAME => "VK_NV_partitioned_acceleration_structure"u8;

        [NativeTypeName("#define VK_PARTITIONED_ACCELERATION_STRUCTURE_PARTITION_INDEX_GLOBAL_NV (~0U)")]
        public const uint VK_PARTITIONED_ACCELERATION_STRUCTURE_PARTITION_INDEX_GLOBAL_NV = (~0U);

        [NativeTypeName("#define VK_EXT_device_generated_commands 1")]
        public const int VK_EXT_device_generated_commands = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_GENERATED_COMMANDS_SPEC_VERSION 1")]
        public const int VK_EXT_DEVICE_GENERATED_COMMANDS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME \"VK_EXT_device_generated_commands\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME => "VK_EXT_device_generated_commands"u8;

        [NativeTypeName("#define VK_MESA_image_alignment_control 1")]
        public const int VK_MESA_image_alignment_control = 1;

        [NativeTypeName("#define VK_MESA_IMAGE_ALIGNMENT_CONTROL_SPEC_VERSION 1")]
        public const int VK_MESA_IMAGE_ALIGNMENT_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_MESA_IMAGE_ALIGNMENT_CONTROL_EXTENSION_NAME \"VK_MESA_image_alignment_control\"")]
        public static ReadOnlySpan<byte> VK_MESA_IMAGE_ALIGNMENT_CONTROL_EXTENSION_NAME => "VK_MESA_image_alignment_control"u8;

        [NativeTypeName("#define VK_EXT_depth_clamp_control 1")]
        public const int VK_EXT_depth_clamp_control = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLAMP_CONTROL_SPEC_VERSION 1")]
        public const int VK_EXT_DEPTH_CLAMP_CONTROL_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_DEPTH_CLAMP_CONTROL_EXTENSION_NAME \"VK_EXT_depth_clamp_control\"")]
        public static ReadOnlySpan<byte> VK_EXT_DEPTH_CLAMP_CONTROL_EXTENSION_NAME => "VK_EXT_depth_clamp_control"u8;

        [NativeTypeName("#define VK_HUAWEI_hdr_vivid 1")]
        public const int VK_HUAWEI_hdr_vivid = 1;

        [NativeTypeName("#define VK_HUAWEI_HDR_VIVID_SPEC_VERSION 1")]
        public const int VK_HUAWEI_HDR_VIVID_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_HUAWEI_HDR_VIVID_EXTENSION_NAME \"VK_HUAWEI_hdr_vivid\"")]
        public static ReadOnlySpan<byte> VK_HUAWEI_HDR_VIVID_EXTENSION_NAME => "VK_HUAWEI_hdr_vivid"u8;

        [NativeTypeName("#define VK_NV_cooperative_matrix2 1")]
        public const int VK_NV_cooperative_matrix2 = 1;

        [NativeTypeName("#define VK_NV_COOPERATIVE_MATRIX_2_SPEC_VERSION 1")]
        public const int VK_NV_COOPERATIVE_MATRIX_2_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_COOPERATIVE_MATRIX_2_EXTENSION_NAME \"VK_NV_cooperative_matrix2\"")]
        public static ReadOnlySpan<byte> VK_NV_COOPERATIVE_MATRIX_2_EXTENSION_NAME => "VK_NV_cooperative_matrix2"u8;

        [NativeTypeName("#define VK_ARM_pipeline_opacity_micromap 1")]
        public const int VK_ARM_pipeline_opacity_micromap = 1;

        [NativeTypeName("#define VK_ARM_PIPELINE_OPACITY_MICROMAP_SPEC_VERSION 1")]
        public const int VK_ARM_PIPELINE_OPACITY_MICROMAP_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_ARM_PIPELINE_OPACITY_MICROMAP_EXTENSION_NAME \"VK_ARM_pipeline_opacity_micromap\"")]
        public static ReadOnlySpan<byte> VK_ARM_PIPELINE_OPACITY_MICROMAP_EXTENSION_NAME => "VK_ARM_pipeline_opacity_micromap"u8;

        [NativeTypeName("#define VK_EXT_vertex_attribute_robustness 1")]
        public const int VK_EXT_vertex_attribute_robustness = 1;

        [NativeTypeName("#define VK_EXT_VERTEX_ATTRIBUTE_ROBUSTNESS_SPEC_VERSION 1")]
        public const int VK_EXT_VERTEX_ATTRIBUTE_ROBUSTNESS_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_VERTEX_ATTRIBUTE_ROBUSTNESS_EXTENSION_NAME \"VK_EXT_vertex_attribute_robustness\"")]
        public static ReadOnlySpan<byte> VK_EXT_VERTEX_ATTRIBUTE_ROBUSTNESS_EXTENSION_NAME => "VK_EXT_vertex_attribute_robustness"u8;

        [NativeTypeName("#define VK_NV_present_metering 1")]
        public const int VK_NV_present_metering = 1;

        [NativeTypeName("#define VK_NV_PRESENT_METERING_SPEC_VERSION 1")]
        public const int VK_NV_PRESENT_METERING_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_PRESENT_METERING_EXTENSION_NAME \"VK_NV_present_metering\"")]
        public static ReadOnlySpan<byte> VK_NV_PRESENT_METERING_EXTENSION_NAME => "VK_NV_present_metering"u8;

        [NativeTypeName("#define VK_EXT_fragment_density_map_offset 1")]
        public const int VK_EXT_fragment_density_map_offset = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_SPEC_VERSION 1")]
        public const int VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME \"VK_EXT_fragment_density_map_offset\"")]
        public static ReadOnlySpan<byte> VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME => "VK_EXT_fragment_density_map_offset"u8;

        [NativeTypeName("#define VK_KHR_acceleration_structure 1")]
        public const int VK_KHR_acceleration_structure = 1;

        [NativeTypeName("#define VK_KHR_ACCELERATION_STRUCTURE_SPEC_VERSION 13")]
        public const int VK_KHR_ACCELERATION_STRUCTURE_SPEC_VERSION = 13;

        [NativeTypeName("#define VK_KHR_ACCELERATION_STRUCTURE_EXTENSION_NAME \"VK_KHR_acceleration_structure\"")]
        public static ReadOnlySpan<byte> VK_KHR_ACCELERATION_STRUCTURE_EXTENSION_NAME => "VK_KHR_acceleration_structure"u8;

        [NativeTypeName("#define VK_KHR_ray_tracing_pipeline 1")]
        public const int VK_KHR_ray_tracing_pipeline = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_PIPELINE_SPEC_VERSION 1")]
        public const int VK_KHR_RAY_TRACING_PIPELINE_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_RAY_TRACING_PIPELINE_EXTENSION_NAME \"VK_KHR_ray_tracing_pipeline\"")]
        public static ReadOnlySpan<byte> VK_KHR_RAY_TRACING_PIPELINE_EXTENSION_NAME => "VK_KHR_ray_tracing_pipeline"u8;

        [NativeTypeName("#define VK_KHR_ray_query 1")]
        public const int VK_KHR_ray_query = 1;

        [NativeTypeName("#define VK_KHR_RAY_QUERY_SPEC_VERSION 1")]
        public const int VK_KHR_RAY_QUERY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_RAY_QUERY_EXTENSION_NAME \"VK_KHR_ray_query\"")]
        public static ReadOnlySpan<byte> VK_KHR_RAY_QUERY_EXTENSION_NAME => "VK_KHR_ray_query"u8;

        [NativeTypeName("#define VK_EXT_mesh_shader 1")]
        public const int VK_EXT_mesh_shader = 1;

        [NativeTypeName("#define VK_EXT_MESH_SHADER_SPEC_VERSION 1")]
        public const int VK_EXT_MESH_SHADER_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_EXT_MESH_SHADER_EXTENSION_NAME \"VK_EXT_mesh_shader\"")]
        public static ReadOnlySpan<byte> VK_EXT_MESH_SHADER_EXTENSION_NAME => "VK_EXT_mesh_shader"u8;

        [NativeTypeName("#define VULKAN_WIN32_H_ 1")]
        public const int VULKAN_WIN32_H_ = 1;

        [NativeTypeName("#define VK_KHR_win32_surface 1")]
        public const int VK_KHR_win32_surface = 1;

        [NativeTypeName("#define VK_KHR_WIN32_SURFACE_SPEC_VERSION 6")]
        public const int VK_KHR_WIN32_SURFACE_SPEC_VERSION = 6;

        [NativeTypeName("#define VK_KHR_WIN32_SURFACE_EXTENSION_NAME \"VK_KHR_win32_surface\"")]
        public static ReadOnlySpan<byte> VK_KHR_WIN32_SURFACE_EXTENSION_NAME => "VK_KHR_win32_surface"u8;

        [NativeTypeName("#define VK_KHR_external_memory_win32 1")]
        public const int VK_KHR_external_memory_win32 = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_WIN32_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_MEMORY_WIN32_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_MEMORY_WIN32_EXTENSION_NAME \"VK_KHR_external_memory_win32\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_MEMORY_WIN32_EXTENSION_NAME => "VK_KHR_external_memory_win32"u8;

        [NativeTypeName("#define VK_KHR_win32_keyed_mutex 1")]
        public const int VK_KHR_win32_keyed_mutex = 1;

        [NativeTypeName("#define VK_KHR_WIN32_KEYED_MUTEX_SPEC_VERSION 1")]
        public const int VK_KHR_WIN32_KEYED_MUTEX_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_WIN32_KEYED_MUTEX_EXTENSION_NAME \"VK_KHR_win32_keyed_mutex\"")]
        public static ReadOnlySpan<byte> VK_KHR_WIN32_KEYED_MUTEX_EXTENSION_NAME => "VK_KHR_win32_keyed_mutex"u8;

        [NativeTypeName("#define VK_KHR_external_semaphore_win32 1")]
        public const int VK_KHR_external_semaphore_win32 = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_WIN32_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_SEMAPHORE_WIN32_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_SEMAPHORE_WIN32_EXTENSION_NAME \"VK_KHR_external_semaphore_win32\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_SEMAPHORE_WIN32_EXTENSION_NAME => "VK_KHR_external_semaphore_win32"u8;

        [NativeTypeName("#define VK_KHR_external_fence_win32 1")]
        public const int VK_KHR_external_fence_win32 = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_WIN32_SPEC_VERSION 1")]
        public const int VK_KHR_EXTERNAL_FENCE_WIN32_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_KHR_EXTERNAL_FENCE_WIN32_EXTENSION_NAME \"VK_KHR_external_fence_win32\"")]
        public static ReadOnlySpan<byte> VK_KHR_EXTERNAL_FENCE_WIN32_EXTENSION_NAME => "VK_KHR_external_fence_win32"u8;

        [NativeTypeName("#define VK_NV_external_memory_win32 1")]
        public const int VK_NV_external_memory_win32 = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_WIN32_SPEC_VERSION 1")]
        public const int VK_NV_EXTERNAL_MEMORY_WIN32_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_EXTERNAL_MEMORY_WIN32_EXTENSION_NAME \"VK_NV_external_memory_win32\"")]
        public static ReadOnlySpan<byte> VK_NV_EXTERNAL_MEMORY_WIN32_EXTENSION_NAME => "VK_NV_external_memory_win32"u8;

        [NativeTypeName("#define VK_NV_win32_keyed_mutex 1")]
        public const int VK_NV_win32_keyed_mutex = 1;

        [NativeTypeName("#define VK_NV_WIN32_KEYED_MUTEX_SPEC_VERSION 2")]
        public const int VK_NV_WIN32_KEYED_MUTEX_SPEC_VERSION = 2;

        [NativeTypeName("#define VK_NV_WIN32_KEYED_MUTEX_EXTENSION_NAME \"VK_NV_win32_keyed_mutex\"")]
        public static ReadOnlySpan<byte> VK_NV_WIN32_KEYED_MUTEX_EXTENSION_NAME => "VK_NV_win32_keyed_mutex"u8;

        [NativeTypeName("#define VK_EXT_full_screen_exclusive 1")]
        public const int VK_EXT_full_screen_exclusive = 1;

        [NativeTypeName("#define VK_EXT_FULL_SCREEN_EXCLUSIVE_SPEC_VERSION 4")]
        public const int VK_EXT_FULL_SCREEN_EXCLUSIVE_SPEC_VERSION = 4;

        [NativeTypeName("#define VK_EXT_FULL_SCREEN_EXCLUSIVE_EXTENSION_NAME \"VK_EXT_full_screen_exclusive\"")]
        public static ReadOnlySpan<byte> VK_EXT_FULL_SCREEN_EXCLUSIVE_EXTENSION_NAME => "VK_EXT_full_screen_exclusive"u8;

        [NativeTypeName("#define VK_NV_acquire_winrt_display 1")]
        public const int VK_NV_acquire_winrt_display = 1;

        [NativeTypeName("#define VK_NV_ACQUIRE_WINRT_DISPLAY_SPEC_VERSION 1")]
        public const int VK_NV_ACQUIRE_WINRT_DISPLAY_SPEC_VERSION = 1;

        [NativeTypeName("#define VK_NV_ACQUIRE_WINRT_DISPLAY_EXTENSION_NAME \"VK_NV_acquire_winrt_display\"")]
        public static ReadOnlySpan<byte> VK_NV_ACQUIRE_WINRT_DISPLAY_EXTENSION_NAME => "VK_NV_acquire_winrt_display"u8;

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateWin32SurfaceKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkWin32SurfaceCreateInfoKHR *")] VkWin32SurfaceCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** pSurface);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateWaylandSurfaceKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkWaylandSurfaceCreateInfoKHR *")] VkWaylandSurfaceCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** pSurface);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkCreateXlibSurfaceKHR([NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("const VkXlibSurfaceCreateInfoKHR *")] VkXlibSurfaceCreateInfoKHR* pCreateInfo, [NativeTypeName("const VkAllocationCallbacks *")] VkAllocationCallbacks* pAllocator, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** pSurface);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("VkBool32")]
        public static extern uint vkGetPhysicalDeviceWin32PresentationSupportKHR([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t")] uint queueFamilyIndex);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryWin32HandleKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkMemoryGetWin32HandleInfoKHR *")] VkMemoryGetWin32HandleInfoKHR* pGetWin32HandleInfo, [NativeTypeName("HANDLE *")] void** pHandle);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryWin32HandlePropertiesKHR([NativeTypeName("VkDevice")] VkDevice_T* device, VkExternalMemoryHandleTypeFlagBits handleType, [NativeTypeName("HANDLE")] void* handle, VkMemoryWin32HandlePropertiesKHR* pMemoryWin32HandleProperties);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkImportSemaphoreWin32HandleKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImportSemaphoreWin32HandleInfoKHR *")] VkImportSemaphoreWin32HandleInfoKHR* pImportSemaphoreWin32HandleInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetSemaphoreWin32HandleKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkSemaphoreGetWin32HandleInfoKHR *")] VkSemaphoreGetWin32HandleInfoKHR* pGetWin32HandleInfo, [NativeTypeName("HANDLE *")] void** pHandle);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkImportFenceWin32HandleKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkImportFenceWin32HandleInfoKHR *")] VkImportFenceWin32HandleInfoKHR* pImportFenceWin32HandleInfo);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetFenceWin32HandleKHR([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkFenceGetWin32HandleInfoKHR *")] VkFenceGetWin32HandleInfoKHR* pGetWin32HandleInfo, [NativeTypeName("HANDLE *")] void** pHandle);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetMemoryWin32HandleNV([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkDeviceMemory")] VkDeviceMemory_T* memory, [NativeTypeName("VkExternalMemoryHandleTypeFlagsNV")] uint handleType, [NativeTypeName("HANDLE *")] void** pHandle);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetPhysicalDeviceSurfacePresentModes2EXT([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("const VkPhysicalDeviceSurfaceInfo2KHR *")] VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, [NativeTypeName("uint32_t *")] uint* pPresentModeCount, VkPresentModeKHR* pPresentModes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireFullScreenExclusiveModeEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkReleaseFullScreenExclusiveModeEXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("VkSwapchainKHR")] VkSwapchainKHR_T* swapchain);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetDeviceGroupSurfacePresentModes2EXT([NativeTypeName("VkDevice")] VkDevice_T* device, [NativeTypeName("const VkPhysicalDeviceSurfaceInfo2KHR *")] VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, [NativeTypeName("VkDeviceGroupPresentModeFlagsKHR *")] uint* pModes);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkAcquireWinrtDisplayNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("VkDisplayKHR")] VkDisplayKHR_T* display);

        [DllImport("vulkan", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        public static extern VkResult vkGetWinrtDisplayNV([NativeTypeName("VkPhysicalDevice")] VkPhysicalDevice_T* physicalDevice, [NativeTypeName("uint32_t")] uint deviceRelativeId, [NativeTypeName("VkDisplayKHR *")] VkDisplayKHR_T** pDisplay);

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_H265STD_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_H265STD_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_h265std 1")]
        public const int vulkan_video_codec_h265std = 1;

        [NativeTypeName("#define STD_VIDEO_H265_CPB_CNT_LIST_SIZE 32")]
        public const int STD_VIDEO_H265_CPB_CNT_LIST_SIZE = 32;

        [NativeTypeName("#define STD_VIDEO_H265_SUBLAYERS_LIST_SIZE 7")]
        public const int STD_VIDEO_H265_SUBLAYERS_LIST_SIZE = 7;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_4X4_NUM_LISTS 6")]
        public const int STD_VIDEO_H265_SCALING_LIST_4X4_NUM_LISTS = 6;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_4X4_NUM_ELEMENTS 16")]
        public const int STD_VIDEO_H265_SCALING_LIST_4X4_NUM_ELEMENTS = 16;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_8X8_NUM_LISTS 6")]
        public const int STD_VIDEO_H265_SCALING_LIST_8X8_NUM_LISTS = 6;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_8X8_NUM_ELEMENTS 64")]
        public const int STD_VIDEO_H265_SCALING_LIST_8X8_NUM_ELEMENTS = 64;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_16X16_NUM_LISTS 6")]
        public const int STD_VIDEO_H265_SCALING_LIST_16X16_NUM_LISTS = 6;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_16X16_NUM_ELEMENTS 64")]
        public const int STD_VIDEO_H265_SCALING_LIST_16X16_NUM_ELEMENTS = 64;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_32X32_NUM_LISTS 2")]
        public const int STD_VIDEO_H265_SCALING_LIST_32X32_NUM_LISTS = 2;

        [NativeTypeName("#define STD_VIDEO_H265_SCALING_LIST_32X32_NUM_ELEMENTS 64")]
        public const int STD_VIDEO_H265_SCALING_LIST_32X32_NUM_ELEMENTS = 64;

        [NativeTypeName("#define STD_VIDEO_H265_CHROMA_QP_OFFSET_LIST_SIZE 6")]
        public const int STD_VIDEO_H265_CHROMA_QP_OFFSET_LIST_SIZE = 6;

        [NativeTypeName("#define STD_VIDEO_H265_CHROMA_QP_OFFSET_TILE_COLS_LIST_SIZE 19")]
        public const int STD_VIDEO_H265_CHROMA_QP_OFFSET_TILE_COLS_LIST_SIZE = 19;

        [NativeTypeName("#define STD_VIDEO_H265_CHROMA_QP_OFFSET_TILE_ROWS_LIST_SIZE 21")]
        public const int STD_VIDEO_H265_CHROMA_QP_OFFSET_TILE_ROWS_LIST_SIZE = 21;

        [NativeTypeName("#define STD_VIDEO_H265_PREDICTOR_PALETTE_COMPONENTS_LIST_SIZE 3")]
        public const int STD_VIDEO_H265_PREDICTOR_PALETTE_COMPONENTS_LIST_SIZE = 3;

        [NativeTypeName("#define STD_VIDEO_H265_PREDICTOR_PALETTE_COMP_ENTRIES_LIST_SIZE 128")]
        public const int STD_VIDEO_H265_PREDICTOR_PALETTE_COMP_ENTRIES_LIST_SIZE = 128;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_NUM_LIST_REF 15")]
        public const int STD_VIDEO_H265_MAX_NUM_LIST_REF = 15;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_CHROMA_PLANES 2")]
        public const int STD_VIDEO_H265_MAX_CHROMA_PLANES = 2;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_SHORT_TERM_REF_PIC_SETS 64")]
        public const int STD_VIDEO_H265_MAX_SHORT_TERM_REF_PIC_SETS = 64;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_DPB_SIZE 16")]
        public const int STD_VIDEO_H265_MAX_DPB_SIZE = 16;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_LONG_TERM_REF_PICS_SPS 32")]
        public const int STD_VIDEO_H265_MAX_LONG_TERM_REF_PICS_SPS = 32;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_LONG_TERM_PICS 16")]
        public const int STD_VIDEO_H265_MAX_LONG_TERM_PICS = 16;

        [NativeTypeName("#define STD_VIDEO_H265_MAX_DELTA_POC 48")]
        public const int STD_VIDEO_H265_MAX_DELTA_POC = 48;

        [NativeTypeName("#define STD_VIDEO_H265_NO_REFERENCE_PICTURE 0xFF")]
        public const int STD_VIDEO_H265_NO_REFERENCE_PICTURE = 0xFF;

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_H265STD_DECODE_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_H265STD_DECODE_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_h265std_decode 1")]
        public const int vulkan_video_codec_h265std_decode = 1;

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_API_VERSION_1_0_0 VK_MAKE_VIDEO_STD_VERSION(1, 0, 0)")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_API_VERSION_1_0_0 = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_SPEC_VERSION VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_API_VERSION_1_0_0")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_SPEC_VERSION = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_EXTENSION_NAME \"VK_STD_vulkan_video_codec_h265_decode\"")]
        public static ReadOnlySpan<byte> VK_STD_VULKAN_VIDEO_CODEC_H265_DECODE_EXTENSION_NAME => "VK_STD_vulkan_video_codec_h265_decode"u8;

        [NativeTypeName("#define STD_VIDEO_DECODE_H265_REF_PIC_SET_LIST_SIZE 8")]
        public const int STD_VIDEO_DECODE_H265_REF_PIC_SET_LIST_SIZE = 8;

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_H265STD_ENCODE_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_H265STD_ENCODE_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_h265std_encode 1")]
        public const int vulkan_video_codec_h265std_encode = 1;

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_API_VERSION_1_0_0 VK_MAKE_VIDEO_STD_VERSION(1, 0, 0)")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_API_VERSION_1_0_0 = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_SPEC_VERSION VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_API_VERSION_1_0_0")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_SPEC_VERSION = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_EXTENSION_NAME \"VK_STD_vulkan_video_codec_h265_encode\"")]
        public static ReadOnlySpan<byte> VK_STD_VULKAN_VIDEO_CODEC_H265_ENCODE_EXTENSION_NAME => "VK_STD_vulkan_video_codec_h265_encode"u8;

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_H264STD_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_H264STD_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_h264std 1")]
        public const int vulkan_video_codec_h264std = 1;

        [NativeTypeName("#define STD_VIDEO_H264_CPB_CNT_LIST_SIZE 32")]
        public const int STD_VIDEO_H264_CPB_CNT_LIST_SIZE = 32;

        [NativeTypeName("#define STD_VIDEO_H264_SCALING_LIST_4X4_NUM_LISTS 6")]
        public const int STD_VIDEO_H264_SCALING_LIST_4X4_NUM_LISTS = 6;

        [NativeTypeName("#define STD_VIDEO_H264_SCALING_LIST_4X4_NUM_ELEMENTS 16")]
        public const int STD_VIDEO_H264_SCALING_LIST_4X4_NUM_ELEMENTS = 16;

        [NativeTypeName("#define STD_VIDEO_H264_SCALING_LIST_8X8_NUM_LISTS 6")]
        public const int STD_VIDEO_H264_SCALING_LIST_8X8_NUM_LISTS = 6;

        [NativeTypeName("#define STD_VIDEO_H264_SCALING_LIST_8X8_NUM_ELEMENTS 64")]
        public const int STD_VIDEO_H264_SCALING_LIST_8X8_NUM_ELEMENTS = 64;

        [NativeTypeName("#define STD_VIDEO_H264_MAX_NUM_LIST_REF 32")]
        public const int STD_VIDEO_H264_MAX_NUM_LIST_REF = 32;

        [NativeTypeName("#define STD_VIDEO_H264_MAX_CHROMA_PLANES 2")]
        public const int STD_VIDEO_H264_MAX_CHROMA_PLANES = 2;

        [NativeTypeName("#define STD_VIDEO_H264_NO_REFERENCE_PICTURE 0xFF")]
        public const int STD_VIDEO_H264_NO_REFERENCE_PICTURE = 0xFF;

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_H264STD_DECODE_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_H264STD_DECODE_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_h264std_decode 1")]
        public const int vulkan_video_codec_h264std_decode = 1;

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_API_VERSION_1_0_0 VK_MAKE_VIDEO_STD_VERSION(1, 0, 0)")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_API_VERSION_1_0_0 = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_SPEC_VERSION VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_API_VERSION_1_0_0")]
        public const uint VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_SPEC_VERSION = ((((uint)(1)) << 22) | (((uint)(0)) << 12) | ((uint)(0)));

        [NativeTypeName("#define VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_EXTENSION_NAME \"VK_STD_vulkan_video_codec_h264_decode\"")]
        public static ReadOnlySpan<byte> VK_STD_VULKAN_VIDEO_CODEC_H264_DECODE_EXTENSION_NAME => "VK_STD_vulkan_video_codec_h264_decode"u8;

        [NativeTypeName("#define STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_LIST_SIZE 2")]
        public const int STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_LIST_SIZE = 2;

        [NativeTypeName("#define VULKAN_VIDEO_CODEC_AV1STD_H_ 1")]
        public const int VULKAN_VIDEO_CODEC_AV1STD_H_ = 1;

        [NativeTypeName("#define vulkan_video_codec_av1std 1")]
        public const int vulkan_video_codec_av1std = 1;

        [NativeTypeName("#define STD_VIDEO_AV1_NUM_REF_FRAMES 8")]
        public const int STD_VIDEO_AV1_NUM_REF_FRAMES = 8;

        [NativeTypeName("#define STD_VIDEO_AV1_REFS_PER_FRAME 7")]
        public const int STD_VIDEO_AV1_REFS_PER_FRAME = 7;

        [NativeTypeName("#define STD_VIDEO_AV1_TOTAL_REFS_PER_FRAME 8")]
        public const int STD_VIDEO_AV1_TOTAL_REFS_PER_FRAME = 8;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_TILE_COLS 64")]
        public const int STD_VIDEO_AV1_MAX_TILE_COLS = 64;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_TILE_ROWS 64")]
        public const int STD_VIDEO_AV1_MAX_TILE_ROWS = 64;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_SEGMENTS 8")]
        public const int STD_VIDEO_AV1_MAX_SEGMENTS = 8;

        [NativeTypeName("#define STD_VIDEO_AV1_SEG_LVL_MAX 8")]
        public const int STD_VIDEO_AV1_SEG_LVL_MAX = 8;

        [NativeTypeName("#define STD_VIDEO_AV1_PRIMARY_REF_NONE 7")]
        public const int STD_VIDEO_AV1_PRIMARY_REF_NONE = 7;

        [NativeTypeName("#define STD_VIDEO_AV1_SELECT_INTEGER_MV 2")]
        public const int STD_VIDEO_AV1_SELECT_INTEGER_MV = 2;

        [NativeTypeName("#define STD_VIDEO_AV1_SELECT_SCREEN_CONTENT_TOOLS 2")]
        public const int STD_VIDEO_AV1_SELECT_SCREEN_CONTENT_TOOLS = 2;

        [NativeTypeName("#define STD_VIDEO_AV1_SKIP_MODE_FRAMES 2")]
        public const int STD_VIDEO_AV1_SKIP_MODE_FRAMES = 2;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_LOOP_FILTER_STRENGTHS 4")]
        public const int STD_VIDEO_AV1_MAX_LOOP_FILTER_STRENGTHS = 4;

        [NativeTypeName("#define STD_VIDEO_AV1_LOOP_FILTER_ADJUSTMENTS 2")]
        public const int STD_VIDEO_AV1_LOOP_FILTER_ADJUSTMENTS = 2;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_CDEF_FILTER_STRENGTHS 8")]
        public const int STD_VIDEO_AV1_MAX_CDEF_FILTER_STRENGTHS = 8;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_PLANES 3")]
        public const int STD_VIDEO_AV1_MAX_NUM_PLANES = 3;

        [NativeTypeName("#define STD_VIDEO_AV1_GLOBAL_MOTION_PARAMS 6")]
        public const int STD_VIDEO_AV1_GLOBAL_MOTION_PARAMS = 6;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_Y_POINTS 14")]
        public const int STD_VIDEO_AV1_MAX_NUM_Y_POINTS = 14;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_CB_POINTS 10")]
        public const int STD_VIDEO_AV1_MAX_NUM_CB_POINTS = 10;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_CR_POINTS 10")]
        public const int STD_VIDEO_AV1_MAX_NUM_CR_POINTS = 10;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_POS_LUMA 24")]
        public const int STD_VIDEO_AV1_MAX_NUM_POS_LUMA = 24;

        [NativeTypeName("#define STD_VIDEO_AV1_MAX_NUM_POS_CHROMA 25")]
        public const int STD_VIDEO_AV1_MAX_NUM_POS_CHROMA = 25;
    }
}
