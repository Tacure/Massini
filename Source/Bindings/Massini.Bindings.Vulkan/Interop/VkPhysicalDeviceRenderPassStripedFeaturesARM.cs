namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRenderPassStripedFeaturesARM
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint renderPassStriped;
    }
}
