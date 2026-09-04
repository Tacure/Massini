
using Massini.Core.Interop;
using Massini.Core.Interop.Windows;

namespace Massini.Bindings.Vulkan
{
    public partial class Vk
    {
        // Validation layers.
        public const string VK_LAYER_KHRONOS_VALIDATION = "VK_LAYER_KHRONOS_validation";
        public const string VK_LAYER_LUNARG_MONITOR = "VK_LAYER_LUNARG_monitor";
        public const string VK_LAYER_LUNARG_CRASH_DIAGNOSTIC = "VK_LAYER_LUNARG_crash_diagnostic";
        public const string VK_LAYER_LUNARG_SCREENSHOT = "VK_LAYER_LUNARG_screenshot";
        public const string VK_LAYER_LUNARG_GFXRECONSTRUCT = "VK_LAYER_LUNARG_gfxreconstruct";
        public const string VK_LAYER_LUNARG_API_DUMP = "VK_LAYER_LUNARG_api_dump";
        public const string VK_LAYER_KHRONOS_SYNCHRONIZATION_2 = "VK_LAYER_KHRONOS_synchronization2";
        public const string VK_LAYER_KHRONOS_SHADER_OBJECT = "VK_LAYER_KHRONOS_shader_object";
        public const string VK_LAYER_KHRONOS_PROFILES = "VK_LAYER_KHRONOS_profiles";

        // Instance extensions.
        public const string VK_KHR_SURFACE = "VK_KHR_surface";
        public const string VK_KHR_WIN32_SURFACE = "VK_KHR_win32_surface";
        public const string VK_KHR_XLIB_SURFACE = "VK_KHR_xlib_surface";
        public const string VK_KHR_XCB_SURFACE = "VK_KHR_xcb_surface";
        public const string VK_KHR_WAYLAND_SURFACE = "VK_KHR_wayland_surface";
        public const string VK_MVK_MACOS_SURFACE = "VK_MVK_macos_surface";
        public const string VK_EXT_DEBUG_UTILS = "VK_EXT_debug_utils";

        // Device extensions.
        public const string VK_KHR_DYNAMIC_RENDERING = "VK_KHR_dynamic_rendering";
        public const string VK_KHR_PUSH_DESCRIPTOR = "VK_KHR_push_descriptor";
        public const string VK_KHR_SWAPCHAIN = "VK_KHR_swapchain";
        public const string VK_KHR_DEPTH_STENCIL_RESOLVE = "VK_KHR_depth_stencil_resolve";
        public const string VK_KHR_CREATE_RENDERPASS2 = "VK_KHR_create_renderpass2";
        public const string VK_EXT_EXTENDED_DYNAMIC_STATE = "VK_EXT_extended_dynamic_state";
        public const string VK_EXT_EXTENDED_DYNAMIC_STATE_2 = "VK_EXT_extended_dynamic_state2";
        public const string VK_EXT_EXTENDED_DYNAMIC_STATE_3 = "VK_EXT_extended_dynamic_state3";
        public const string VK_EXT_VERTEX_INPUT_DYNAMIC_STATE = "VK_EXT_vertex_input_dynamic_state";
        public const string VK_KHR_TIMELINE_SEMAPHORE = "VK_KHR_timeline_semaphore";
        public const string VK_EXT_DESCRIPTOR_INDEXING = "VK_EXT_descriptor_indexing";
        public const string VK_KHR_SHADER_DRAW_PARAMETERS = "VK_KHR_shader_draw_parameters";
        public const string VK_EXT_SHADER_OBJECT = "VK_EXT_shader_object";
        public const string VK_EXT_DESCRIPTOR_BUFFER = "VK_EXT_descriptor_buffer";
        public const string VK_KHR_BUFFER_DEVICE_ADDRESS = "VK_KHR_buffer_device_address";
        public const string VK_KHR_SYNCHRONIZATION_2 = "VK_KHR_synchronization2";
        public const string VK_KHR_MAINTENANCE_6 = "VK_KHR_maintenance6";
        public const string VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2 = "VK_KHR_get_physical_device_properties2";

        // 
        //public const uint VK_QUEUE_FAMILY_IGNORED = ~0U;

        public static uint ApiVersion0100 => MakeAPIVersion(0, 1, 0, 0);
        public static uint ApiVersion0110 => MakeAPIVersion(0, 1, 1, 0);
        public static uint ApiVersion0120 => MakeAPIVersion(0, 1, 2, 0);
        public static uint ApiVersion0130 => MakeAPIVersion(0, 1, 3, 0);
        public static uint ApiVersion0140 => MakeAPIVersion(0, 1, 4, 0);

        public static uint MakeAPIVersion(int i_variant, int i_major, int i_minor, int i_patch)
        {
            return (uint)((i_variant << 29) | (i_major << 22) | (i_minor << 12) | (i_patch));
        }
    }
}
