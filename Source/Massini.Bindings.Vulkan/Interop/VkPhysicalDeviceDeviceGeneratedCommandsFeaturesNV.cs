namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint deviceGeneratedCommands;
    }
}
