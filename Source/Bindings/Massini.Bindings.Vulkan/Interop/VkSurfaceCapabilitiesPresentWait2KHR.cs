namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceCapabilitiesPresentWait2KHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentWait2Supported;
    }
}
