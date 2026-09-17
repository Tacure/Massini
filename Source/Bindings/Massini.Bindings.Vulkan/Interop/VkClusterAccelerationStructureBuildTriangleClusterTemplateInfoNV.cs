namespace Massini.Bindings.Vulkan
{
    public partial struct VkClusterAccelerationStructureBuildTriangleClusterTemplateInfoNV
    {
        [NativeTypeName("uint32_t")]
        public uint clusterID;

        [NativeTypeName("VkClusterAccelerationStructureClusterFlagsNV")]
        public uint clusterFlags;

        public uint _bitfield;

        [NativeTypeName("uint32_t : 9")]
        public uint triangleCount
        {
            readonly get
            {
                return _bitfield & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1FFu) | (value & 0x1FFu);
            }
        }

        [NativeTypeName("uint32_t : 9")]
        public uint vertexCount
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFu << 9)) | ((value & 0x1FFu) << 9);
            }
        }

        [NativeTypeName("uint32_t : 6")]
        public uint positionTruncateBitCount
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x3Fu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3Fu << 18)) | ((value & 0x3Fu) << 18);
            }
        }

        [NativeTypeName("uint32_t : 4")]
        public uint indexType
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 24)) | ((value & 0xFu) << 24);
            }
        }

        [NativeTypeName("uint32_t : 4")]
        public uint opacityMicromapIndexType
        {
            readonly get
            {
                return (_bitfield >> 28) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 28)) | ((value & 0xFu) << 28);
            }
        }

        public VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV baseGeometryIndexAndGeometryFlags;

        [NativeTypeName("uint16_t")]
        public ushort indexBufferStride;

        [NativeTypeName("uint16_t")]
        public ushort vertexBufferStride;

        [NativeTypeName("uint16_t")]
        public ushort geometryIndexAndFlagsBufferStride;

        [NativeTypeName("uint16_t")]
        public ushort opacityMicromapIndexBufferStride;

        [NativeTypeName("VkDeviceAddress")]
        public ulong indexBuffer;

        [NativeTypeName("VkDeviceAddress")]
        public ulong vertexBuffer;

        [NativeTypeName("VkDeviceAddress")]
        public ulong geometryIndexAndFlagsBuffer;

        [NativeTypeName("VkDeviceAddress")]
        public ulong opacityMicromapArray;

        [NativeTypeName("VkDeviceAddress")]
        public ulong opacityMicromapIndexBuffer;

        [NativeTypeName("VkDeviceAddress")]
        public ulong instantiationBoundingBoxLimit;
    }
}
