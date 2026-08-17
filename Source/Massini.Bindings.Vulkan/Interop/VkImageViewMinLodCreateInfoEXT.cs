namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageViewMinLodCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public float minLod;
    }
}
