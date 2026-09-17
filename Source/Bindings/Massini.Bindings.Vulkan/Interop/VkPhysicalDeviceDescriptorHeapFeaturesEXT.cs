namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceDescriptorHeapFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint descriptorHeap;

        [NativeTypeName("VkBool32")]
        public uint descriptorHeapCaptureReplay;
    }
}
