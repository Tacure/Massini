using System.Runtime.CompilerServices;

namespace Massini.Bindings.Vulkan
{
    public partial struct VkExtensionProperties
    {
        [NativeTypeName("char[256]")]
        public _extensionName_e__FixedBuffer extensionName;

        [NativeTypeName("uint32_t")]
        public uint specVersion;

        [InlineArray(256)]
        public partial struct _extensionName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }
}
