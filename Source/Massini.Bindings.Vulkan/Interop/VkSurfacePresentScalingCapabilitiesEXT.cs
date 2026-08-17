namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfacePresentScalingCapabilitiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkPresentScalingFlagsEXT")]
        public uint supportedPresentScaling;

        [NativeTypeName("VkPresentGravityFlagsEXT")]
        public uint supportedPresentGravityX;

        [NativeTypeName("VkPresentGravityFlagsEXT")]
        public uint supportedPresentGravityY;

        public VkExtent2D minScaledImageExtent;

        public VkExtent2D maxScaledImageExtent;
    }
}
