namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoEncodeH264SessionParametersFeedbackInfoKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint hasStdSPSOverrides;

        [NativeTypeName("VkBool32")]
        public uint hasStdPPSOverrides;
    }
}
