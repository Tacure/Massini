namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSubpassResolvePerformanceQueryEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint optimal;
    }
}
