namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceInheritedViewportScissorFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint inheritedViewportScissor2D;
    }
}
