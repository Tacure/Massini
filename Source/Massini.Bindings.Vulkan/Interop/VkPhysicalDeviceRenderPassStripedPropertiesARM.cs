namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRenderPassStripedPropertiesARM
    {
        public VkStructureType sType;

        public void* pNext;

        public VkExtent2D renderPassStripeGranularity;

        [NativeTypeName("uint32_t")]
        public uint maxRenderPassStripes;
    }
}
