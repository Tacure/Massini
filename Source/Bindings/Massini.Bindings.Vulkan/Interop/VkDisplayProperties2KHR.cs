namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDisplayProperties2KHR
    {
        public VkStructureType sType;

        public void* pNext;

        public VkDisplayPropertiesKHR displayProperties;
    }
}
