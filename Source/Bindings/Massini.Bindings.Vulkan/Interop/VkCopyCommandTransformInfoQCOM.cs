namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkCopyCommandTransformInfoQCOM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;
    }
}
