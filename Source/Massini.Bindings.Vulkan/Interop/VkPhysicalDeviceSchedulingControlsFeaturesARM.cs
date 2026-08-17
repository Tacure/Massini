namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSchedulingControlsFeaturesARM
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint schedulingControls;
    }
}
