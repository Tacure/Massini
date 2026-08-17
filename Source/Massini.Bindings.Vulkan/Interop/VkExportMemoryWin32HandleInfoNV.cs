namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkExportMemoryWin32HandleInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("const SECURITY_ATTRIBUTES *")]
        public _SECURITY_ATTRIBUTES* pAttributes;

        [NativeTypeName("DWORD")]
        public uint dwAccess;
    }
}
