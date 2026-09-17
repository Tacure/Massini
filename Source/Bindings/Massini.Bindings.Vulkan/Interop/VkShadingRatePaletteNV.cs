namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkShadingRatePaletteNV
    {
        [NativeTypeName("uint32_t")]
        public uint shadingRatePaletteEntryCount;

        [NativeTypeName("const VkShadingRatePaletteEntryNV *")]
        public VkShadingRatePaletteEntryNV* pShadingRatePaletteEntries;
    }
}
