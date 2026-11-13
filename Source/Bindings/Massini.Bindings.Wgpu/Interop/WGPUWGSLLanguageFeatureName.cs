namespace Massini.Bindings.Wgpu
{
    public enum WGPUWGSLLanguageFeatureName
    {
        WGPUWGSLLanguageFeatureName_ReadonlyAndReadwriteStorageTextures = 0x00000001,
        WGPUWGSLLanguageFeatureName_Packed4x8IntegerDotProduct = 0x00000002,
        WGPUWGSLLanguageFeatureName_UnrestrictedPointerParameters = 0x00000003,
        WGPUWGSLLanguageFeatureName_PointerCompositeAccess = 0x00000004,
        WGPUWGSLLanguageFeatureName_UniformBufferStandardLayout = 0x00000005,
        WGPUWGSLLanguageFeatureName_SubgroupId = 0x00000006,
        WGPUWGSLLanguageFeatureName_TextureAndSamplerLet = 0x00000007,
        WGPUWGSLLanguageFeatureName_SubgroupUniformity = 0x00000008,
        WGPUWGSLLanguageFeatureName_TextureFormatsTier1 = 0x00000009,
        WGPUWGSLLanguageFeatureName_LinearIndexing = 0x0000000A,
        WGPUWGSLLanguageFeatureName_Force32 = 0x7FFFFFFF,
    }
}
