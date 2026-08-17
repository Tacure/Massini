using System.Runtime.InteropServices;

namespace Massini.Bindings.Vma.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VmaDeviceMemoryCallbacks
    {
        /// <summary>
        /// Optional.
        /// </summary>
        public PfnVmaAllocateDeviceMemoryFunction p_ptr_pfnAllocate;
        /// <summary>
        /// Optional.
        /// </summary>
        public PfnVmaFreeDeviceMemoryFunction p_ptr_pfnFree;
        /// <summary>
        /// Optional user data.
        /// </summary>
        public void* p_ptr_userData;
    }
}
