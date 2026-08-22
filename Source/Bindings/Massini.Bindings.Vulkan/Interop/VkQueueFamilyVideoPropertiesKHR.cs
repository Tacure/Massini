namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkQueueFamilyVideoPropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkVideoCodecOperationFlagsKHR")]
        public uint videoCodecOperations;
    }
}
