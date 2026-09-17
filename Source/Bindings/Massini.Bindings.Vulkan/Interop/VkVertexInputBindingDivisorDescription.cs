namespace Massini.Bindings.Vulkan
{
    public partial struct VkVertexInputBindingDivisorDescription
    {
        [NativeTypeName("uint32_t")]
        public uint binding;

        [NativeTypeName("uint32_t")]
        public uint divisor;
    }
}
