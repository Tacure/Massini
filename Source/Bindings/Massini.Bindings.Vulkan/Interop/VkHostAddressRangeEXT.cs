namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkHostAddressRangeEXT
    {
        public void* address;

        [NativeTypeName("size_t")]
        public nuint size;
    }
}
