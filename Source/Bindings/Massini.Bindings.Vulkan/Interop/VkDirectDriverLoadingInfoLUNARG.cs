namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDirectDriverLoadingInfoLUNARG
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkDirectDriverLoadingFlagsLUNARG")]
        public uint flags;

        [NativeTypeName("PFN_vkGetInstanceProcAddrLUNARG")]
        public delegate* unmanaged[Cdecl]<VkInstance_T*, sbyte*, delegate* unmanaged[Cdecl]<void>> pfnGetInstanceProcAddr;
    }
}
