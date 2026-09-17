namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMultisamplePropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        public VkExtent2D maxSampleLocationGridSize;
    }
}
