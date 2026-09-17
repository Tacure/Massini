namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceCapabilitiesPresentId2KHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentId2Supported;
    }
}
