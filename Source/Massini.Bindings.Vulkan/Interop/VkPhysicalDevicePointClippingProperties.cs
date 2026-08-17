namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePointClippingProperties
    {
        public VkStructureType sType;

        public void* pNext;

        public VkPointClippingBehavior pointClippingBehavior;
    }
}
