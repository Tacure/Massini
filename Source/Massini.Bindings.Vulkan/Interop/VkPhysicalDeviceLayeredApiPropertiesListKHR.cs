namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceLayeredApiPropertiesListKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint layeredApiCount;

        public VkPhysicalDeviceLayeredApiPropertiesKHR* pLayeredApis;
    }
}
