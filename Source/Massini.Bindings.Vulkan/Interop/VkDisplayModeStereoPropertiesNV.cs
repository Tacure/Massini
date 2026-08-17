namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDisplayModeStereoPropertiesNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint hdmi3DSupported;
    }
}
