namespace Massini.Bindings.Vulkan
{
    public partial struct VkAccelerationStructureInstanceKHR
    {
        public VkTransformMatrixKHR transform;

        public uint _bitfield1;

        [NativeTypeName("uint32_t : 24")]
        public uint instanceCustomIndex
        {
            readonly get
            {
                return _bitfield1 & 0xFFFFFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

        [NativeTypeName("uint32_t : 8")]
        public uint mask
        {
            readonly get
            {
                return (_bitfield1 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        public uint _bitfield2;

        [NativeTypeName("uint32_t : 24")]
        public uint instanceShaderBindingTableRecordOffset
        {
            readonly get
            {
                return _bitfield2 & 0xFFFFFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

        [NativeTypeName("VkGeometryInstanceFlagsKHR : 8")]
        public uint flags
        {
            readonly get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        [NativeTypeName("uint64_t")]
        public ulong accelerationStructureReference;
    }
}
