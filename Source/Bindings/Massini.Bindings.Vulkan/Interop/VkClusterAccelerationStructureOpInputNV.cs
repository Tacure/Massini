using System.Runtime.InteropServices;

namespace Massini.Bindings.Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkClusterAccelerationStructureOpInputNV
    {
        [FieldOffset(0)]
        public VkClusterAccelerationStructureClustersBottomLevelInputNV* pClustersBottomLevel;

        [FieldOffset(0)]
        public VkClusterAccelerationStructureTriangleClusterInputNV* pTriangleClusters;

        [FieldOffset(0)]
        public VkClusterAccelerationStructureMoveObjectsInputNV* pMoveObjects;
    }
}
