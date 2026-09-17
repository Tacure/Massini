namespace Massini.Bindings.Vulkan
{
    public partial struct VkDrawMeshTasksIndirectCommandEXT
    {
        [NativeTypeName("uint32_t")]
        public uint groupCountX;

        [NativeTypeName("uint32_t")]
        public uint groupCountY;

        [NativeTypeName("uint32_t")]
        public uint groupCountZ;
    }
}
