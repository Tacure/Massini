namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSynchronization2Features
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint synchronization2;
    }
}
