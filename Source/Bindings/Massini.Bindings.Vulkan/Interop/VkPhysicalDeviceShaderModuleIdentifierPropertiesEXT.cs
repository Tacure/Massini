using System.Runtime.CompilerServices;

namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceShaderModuleIdentifierPropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint8_t[16]")]
        public _shaderModuleIdentifierAlgorithmUUID_e__FixedBuffer shaderModuleIdentifierAlgorithmUUID;

        [InlineArray(16)]
        public partial struct _shaderModuleIdentifierAlgorithmUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
