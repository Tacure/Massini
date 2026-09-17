namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkTensorCaptureDescriptorDataInfoARM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkTensorARM")]
        public VkTensorARM_T* tensor;
    }
}
