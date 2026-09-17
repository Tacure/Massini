namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineTessellationDomainOriginStateCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkTessellationDomainOrigin domainOrigin;
    }
}
