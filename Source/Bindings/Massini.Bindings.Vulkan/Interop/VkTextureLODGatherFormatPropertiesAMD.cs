namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkTextureLODGatherFormatPropertiesAMD
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint supportsTextureGatherLODBiasAMD;
    }
}
