namespace Massini.Bindings.Vulkan
{
    public partial struct VkRectLayerKHR
    {
        public VkOffset2D offset;

        public VkExtent2D extent;

        [NativeTypeName("uint32_t")]
        public uint layer;
    }
}
