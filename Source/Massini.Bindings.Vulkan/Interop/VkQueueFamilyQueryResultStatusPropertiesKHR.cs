namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkQueueFamilyQueryResultStatusPropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint queryResultStatusSupport;
    }
}
