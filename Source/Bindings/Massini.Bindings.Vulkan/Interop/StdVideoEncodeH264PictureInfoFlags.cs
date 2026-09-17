namespace Massini.Bindings.Vulkan
{
    public partial struct StdVideoEncodeH264PictureInfoFlags
    {
        public uint _bitfield;

        [NativeTypeName("uint32_t : 1")]
        public uint IdrPicFlag
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
        public uint is_reference
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
        public uint no_output_of_prior_pics_flag
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
        public uint long_term_reference_flag
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

        [NativeTypeName("uint32_t : 1")]
        public uint adaptive_ref_pic_marking_mode_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

        [NativeTypeName("uint32_t : 27")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x7FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
            }
        }
    }
}
