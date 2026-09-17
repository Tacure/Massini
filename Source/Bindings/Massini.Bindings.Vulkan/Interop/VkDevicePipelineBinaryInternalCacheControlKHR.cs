namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDevicePipelineBinaryInternalCacheControlKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint disableInternalCache;
    }
}
