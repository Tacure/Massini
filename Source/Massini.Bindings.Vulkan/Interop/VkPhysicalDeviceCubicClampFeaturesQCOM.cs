namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceCubicClampFeaturesQCOM
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint cubicRangeClamp;
    }
}
