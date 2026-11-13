namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUStringView
    {
        [NativeTypeName("const char *")]
        public sbyte* data;

        [NativeTypeName("size_t")]
        public nuint length;
    }
}
