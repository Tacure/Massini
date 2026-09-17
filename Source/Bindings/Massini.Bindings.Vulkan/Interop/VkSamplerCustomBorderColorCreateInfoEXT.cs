namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSamplerCustomBorderColorCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkClearColorValue customBorderColor;

        public VkFormat format;
    }
}
