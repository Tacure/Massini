namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceAddressBindingReportFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint reportAddressBinding;
    }
}
