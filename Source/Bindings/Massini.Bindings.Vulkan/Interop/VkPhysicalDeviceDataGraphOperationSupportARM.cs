using System.Runtime.CompilerServices;

namespace Massini.Bindings.Vulkan
{
    public partial struct VkPhysicalDeviceDataGraphOperationSupportARM
    {
        public VkPhysicalDeviceDataGraphOperationTypeARM operationType;

        [NativeTypeName("char[128]")]
        public _name_e__FixedBuffer name;

        [NativeTypeName("uint32_t")]
        public uint version;

        [InlineArray(128)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
