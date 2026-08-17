namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePresentWaitFeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentWait;
    }
}
