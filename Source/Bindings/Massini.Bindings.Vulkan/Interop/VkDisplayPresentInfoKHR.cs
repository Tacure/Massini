namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDisplayPresentInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkRect2D srcRect;

        public VkRect2D dstRect;

        [NativeTypeName("VkBool32")]
        public uint persistent;
    }
}
