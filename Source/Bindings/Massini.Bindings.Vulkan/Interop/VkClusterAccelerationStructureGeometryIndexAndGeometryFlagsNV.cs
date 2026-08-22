namespace Massini.Bindings.Vulkan
{
    public partial struct VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV
    {
        public uint _bitfield;

        [NativeTypeName("uint32_t : 24")]
        public uint geometryIndex
        {
            readonly get
            {
                return _bitfield & 0xFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

        [NativeTypeName("uint32_t : 5")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1Fu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1Fu << 24)) | ((value & 0x1Fu) << 24);
            }
        }

        [NativeTypeName("uint32_t : 3")]
        public uint geometryFlags
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x7u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7u << 29)) | ((value & 0x7u) << 29);
            }
        }
    }
}
