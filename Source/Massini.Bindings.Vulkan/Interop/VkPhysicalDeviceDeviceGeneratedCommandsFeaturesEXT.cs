namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint deviceGeneratedCommands;

        [NativeTypeName("VkBool32")]
        public uint dynamicGeneratedPipelineLayout;
    }
}
