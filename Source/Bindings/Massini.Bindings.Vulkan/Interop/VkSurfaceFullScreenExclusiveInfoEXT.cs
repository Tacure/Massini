namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceFullScreenExclusiveInfoEXT
    {
        public VkStructureType sType;

        public void* pNext;

        public VkFullScreenExclusiveEXT fullScreenExclusive;
    }
}
