namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAllocationCallbacks
    {
        public void* pUserData;

        [NativeTypeName("PFN_vkAllocationFunction")]
        public delegate* unmanaged[Cdecl]<void*, nuint, nuint, VkSystemAllocationScope, void*> pfnAllocation;

        [NativeTypeName("PFN_vkReallocationFunction")]
        public delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, VkSystemAllocationScope, void*> pfnReallocation;

        [NativeTypeName("PFN_vkFreeFunction")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> pfnFree;

        [NativeTypeName("PFN_vkInternalAllocationNotification")]
        public delegate* unmanaged[Cdecl]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalAllocation;

        [NativeTypeName("PFN_vkInternalFreeNotification")]
        public delegate* unmanaged[Cdecl]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalFree;
    }
}
