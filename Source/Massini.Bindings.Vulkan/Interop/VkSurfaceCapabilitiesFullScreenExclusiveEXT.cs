namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceCapabilitiesFullScreenExclusiveEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint fullScreenExclusiveSupported;
    }
}
