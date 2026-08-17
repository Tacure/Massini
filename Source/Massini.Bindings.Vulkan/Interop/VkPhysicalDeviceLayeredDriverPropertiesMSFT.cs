namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceLayeredDriverPropertiesMSFT
    {
        public VkStructureType sType;

        public void* pNext;

        public VkLayeredDriverUnderlyingApiMSFT underlyingAPI;
    }
}
