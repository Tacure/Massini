namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDeviceQueueGlobalPriorityCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkQueueGlobalPriority globalPriority;
    }
}
