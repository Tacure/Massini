namespace Massini.Bindings.Vulkan
{
    public partial struct VkDescriptorPoolSize
    {
        public VkDescriptorType type;

        [NativeTypeName("uint32_t")]
        public uint descriptorCount;
    }
}
