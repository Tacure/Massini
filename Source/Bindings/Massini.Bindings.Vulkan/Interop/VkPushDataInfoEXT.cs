namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPushDataInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint offset;

        public VkHostAddressRangeConstEXT data;
    }
}
