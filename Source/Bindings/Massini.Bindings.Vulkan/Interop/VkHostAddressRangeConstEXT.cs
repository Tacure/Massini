namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkHostAddressRangeConstEXT
    {
        [NativeTypeName("const void *")]
        public void* address;

        [NativeTypeName("size_t")]
        public nuint size;
    }
}
