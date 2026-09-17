namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSwapchainCounterCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkSurfaceCounterFlagsEXT")]
        public uint surfaceCounters;
    }
}
