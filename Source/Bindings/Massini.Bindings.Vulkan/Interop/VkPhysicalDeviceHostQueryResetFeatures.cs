namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceHostQueryResetFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint hostQueryReset;
    }
}
