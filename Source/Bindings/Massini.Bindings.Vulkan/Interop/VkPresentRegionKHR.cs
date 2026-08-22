namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPresentRegionKHR
    {
        [NativeTypeName("uint32_t")]
        public uint rectangleCount;

        [NativeTypeName("const VkRectLayerKHR *")]
        public VkRectLayerKHR* pRectangles;
    }
}
