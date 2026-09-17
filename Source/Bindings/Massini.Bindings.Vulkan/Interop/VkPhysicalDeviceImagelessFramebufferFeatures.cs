namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceImagelessFramebufferFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint imagelessFramebuffer;
    }
}
