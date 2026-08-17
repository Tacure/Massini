using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Massini.Bindings.Vma.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VmaVulkanFunctions
    {
        /// Required when using VMA_DYNAMIC_VULKAN_FUNCTIONS.
        public void* p_ptr_vkGetInstanceProcAddr;
        /// Required when using VMA_DYNAMIC_VULKAN_FUNCTIONS.
        public void* p_ptr_vkGetDeviceProcAddr;
        public void* p_ptr_vkGetPhysicalDeviceProperties;
        public void* p_ptr_vkGetPhysicalDeviceMemoryProperties;
        public void* p_ptr_vkAllocateMemory;
        public void* p_ptr_vkFreeMemory;
        public void* p_ptr_vkMapMemory;
        public void* p_ptr_vkUnmapMemory;
        public void* p_ptr_vkFlushMappedMemoryRanges;
        public void* p_ptr_vkInvalidateMappedMemoryRanges;
        public void* p_ptr_vkBindBufferMemory;
        public void* p_ptr_vkBindImageMemory;
        public void* p_ptr_vkGetBufferMemoryRequirements;
        public void* p_ptr_vkGetImageMemoryRequirements;
        public void* p_ptr_vkCreateBuffer;
        public void* p_ptr_vkDestroyBuffer;
        public void* p_ptr_vkCreateImage;
        public void* p_ptr_vkDestroyImage;
        public void* p_ptr_vkCmdCopyBuffer;
        /// Fetch "vkGetBufferMemoryRequirements2" on Vulkan >= 1.1, fetch "vkGetBufferMemoryRequirements2KHR" when using VK_KHR_dedicated_allocation extension.
        public void* p_ptr_vkGetBufferMemoryRequirements2KHR;
        /// Fetch "vkGetImageMemoryRequirements2" on Vulkan >= 1.1, fetch "vkGetImageMemoryRequirements2KHR" when using VK_KHR_dedicated_allocation extension.
        public void* p_ptr_vkGetImageMemoryRequirements2KHR;
        /// Fetch "vkBindBufferMemory2" on Vulkan >= 1.1, fetch "vkBindBufferMemory2KHR" when using VK_KHR_bind_memory2 extension.
        public void* p_ptr_vkBindBufferMemory2KHR;
        /// Fetch "vkBindImageMemory2" on Vulkan >= 1.1, fetch "vkBindImageMemory2KHR" when using VK_KHR_bind_memory2 extension.
        public void* p_ptr_vkBindImageMemory2KHR;
        /// Fetch from "vkGetPhysicalDeviceMemoryProperties2" on Vulkan >= 1.1, but you can also fetch it from "vkGetPhysicalDeviceMemoryProperties2KHR" if you enabled extension VK_KHR_get_physical_device_properties2.
        public void* p_ptr_vkGetPhysicalDeviceMemoryProperties2KHR;
        /// Fetch from "vkGetDeviceBufferMemoryRequirements" on Vulkan >= 1.3, but you can also fetch it from "vkGetDeviceBufferMemoryRequirementsKHR" if you enabled extension VK_KHR_maintenance4.
        public void* p_ptr_vkGetDeviceBufferMemoryRequirements;
        /// Fetch from "vkGetDeviceImageMemoryRequirements" on Vulkan >= 1.3, but you can also fetch it from "vkGetDeviceImageMemoryRequirementsKHR" if you enabled extension VK_KHR_maintenance4.
        public void* p_ptr_vkGetDeviceImageMemoryRequirements;
        public void* p_ptr_vkGetMemoryWin32HandleKHR;
    }
}
