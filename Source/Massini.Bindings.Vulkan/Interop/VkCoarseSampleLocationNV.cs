namespace Massini.Bindings.Vulkan
{
    public partial struct VkCoarseSampleLocationNV
    {
        [NativeTypeName("uint32_t")]
        public uint pixelX;

        [NativeTypeName("uint32_t")]
        public uint pixelY;

        [NativeTypeName("uint32_t")]
        public uint sample;
    }
}
