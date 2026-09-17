using System.Runtime.CompilerServices;

namespace Massini.Bindings.Vulkan
{
    public partial struct VkTransformMatrixKHR
    {
        [NativeTypeName("float[3][4]")]
        public _matrix_e__FixedBuffer matrix;

        [InlineArray(3 * 4)]
        public partial struct _matrix_e__FixedBuffer
        {
            public float e0_0;
        }
    }
}
