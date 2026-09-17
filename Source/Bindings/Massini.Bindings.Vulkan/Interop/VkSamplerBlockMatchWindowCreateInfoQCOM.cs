namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSamplerBlockMatchWindowCreateInfoQCOM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkExtent2D windowExtent;

        public VkBlockMatchWindowCompareModeQCOM windowCompareMode;
    }
}
