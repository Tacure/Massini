namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSwapchainPresentScalingCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkPresentScalingFlagsEXT")]
        public uint scalingBehavior;

        [NativeTypeName("VkPresentGravityFlagsEXT")]
        public uint presentGravityX;

        [NativeTypeName("VkPresentGravityFlagsEXT")]
        public uint presentGravityY;
    }
}
