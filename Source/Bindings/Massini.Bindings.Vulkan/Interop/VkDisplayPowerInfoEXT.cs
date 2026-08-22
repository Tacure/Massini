namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDisplayPowerInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkDisplayPowerStateEXT powerState;
    }
}
