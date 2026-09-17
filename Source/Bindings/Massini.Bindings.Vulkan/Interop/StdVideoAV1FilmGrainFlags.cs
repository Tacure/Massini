namespace Massini.Bindings.Vulkan
{
    public partial struct StdVideoAV1FilmGrainFlags
    {
        public uint _bitfield;

        [NativeTypeName("uint32_t : 1")]
        public uint chroma_scaling_from_luma
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

        [NativeTypeName("uint32_t : 1")]
        public uint overlap_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

        [NativeTypeName("uint32_t : 1")]
        public uint clip_to_restricted_range
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

        [NativeTypeName("uint32_t : 1")]
        public uint update_grain
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

        [NativeTypeName("uint32_t : 28")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFFu << 4)) | ((value & 0xFFFFFFFu) << 4);
            }
        }
    }
}
