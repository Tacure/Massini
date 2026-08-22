namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoDecodeH265CapabilitiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        public StdVideoH265LevelIdc maxLevelIdc;
    }
}
