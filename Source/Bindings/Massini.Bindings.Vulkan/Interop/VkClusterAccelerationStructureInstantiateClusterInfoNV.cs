namespace Massini.Bindings.Vulkan
{
    public partial struct VkClusterAccelerationStructureInstantiateClusterInfoNV
    {
        [NativeTypeName("uint32_t")]
        public uint clusterIdOffset;

        public uint _bitfield;

        [NativeTypeName("uint32_t : 24")]
        public uint geometryIndexOffset
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

        [NativeTypeName("uint32_t : 8")]
        public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        [NativeTypeName("VkDeviceAddress")]
        public ulong clusterTemplateAddress;

        public VkStridedDeviceAddressNV vertexBuffer;
    }
}
