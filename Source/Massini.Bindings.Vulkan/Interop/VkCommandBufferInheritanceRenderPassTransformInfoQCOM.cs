namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkCommandBufferInheritanceRenderPassTransformInfoQCOM
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;

        public VkRect2D renderArea;
    }
}
