namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkRenderPassTransformBeginInfoQCOM
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;
    }
}
