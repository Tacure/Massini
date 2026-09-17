namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceCapabilitiesPresentBarrierNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentBarrierSupported;
    }
}
