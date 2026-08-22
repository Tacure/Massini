namespace Massini.Bindings.Vulkan
{
    public partial struct VkVertexInputBindingDescription
    {
        [NativeTypeName("uint32_t")]
        public uint binding;

        [NativeTypeName("uint32_t")]
        public uint stride;

        public VkVertexInputRate inputRate;
    }
}
