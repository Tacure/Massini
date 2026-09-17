namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkWaylandSurfaceCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkWaylandSurfaceCreateFlagsKHR")]
        public uint flags;

        [NativeTypeName("struct wl_display *")]
        public wl_display* display;

        [NativeTypeName("struct wl_surface *")]
        public wl_surface* surface;

        public partial struct wl_display
        {
        }

        public partial struct wl_surface
        {
        }
    }
}
