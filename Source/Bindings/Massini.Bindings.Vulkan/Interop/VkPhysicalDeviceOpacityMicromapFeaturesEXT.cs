namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceOpacityMicromapFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint micromap;

        [NativeTypeName("VkBool32")]
        public uint micromapCaptureReplay;

        [NativeTypeName("VkBool32")]
        public uint micromapHostCommands;
    }
}
