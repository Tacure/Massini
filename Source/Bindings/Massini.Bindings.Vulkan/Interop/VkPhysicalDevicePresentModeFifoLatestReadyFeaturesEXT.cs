namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePresentModeFifoLatestReadyFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentModeFifoLatestReady;
    }
}
