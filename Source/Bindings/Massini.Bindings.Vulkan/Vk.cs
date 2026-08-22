
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

        public static unsafe PfnVkCreateDebugUtilsMessengerExt GetProcAddrCreateDebugUtilsMessengerEXT(VkInstance_T* i_ptr_instance)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCreateDebugUtilsMessengerEXT");
            return (PfnVkCreateDebugUtilsMessengerExt)vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkDestroyDebugUtilsMessengerExt GetProcAddrDestroyDebugUtilsMessengerEXT(VkInstance_T* i_ptr_instance)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkDestroyDebugUtilsMessengerEXT");
            return (PfnVkDestroyDebugUtilsMessengerExt)vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkSetDebugUtilsObjectNameExt GetProcAddrSetDebugUtilsObjectNameEXT(VkInstance_T* i_ptr_instance)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkSetDebugUtilsObjectNameEXT");
            return (PfnVkSetDebugUtilsObjectNameExt)vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdPushDescriptorSetKhr GetProcAddrCmdPushDescriptorSetKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdPushDescriptorSetKHR");
            return (PfnVkCmdPushDescriptorSetKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdBeginRenderingKhr GetProcAddrCmdBeginRenderingKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdBeginRenderingKHR");
            return (PfnVkCmdBeginRenderingKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdEndRenderingKhr GetProcAddrCmdEndRenderingKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdEndRenderingKHR");
            return (PfnVkCmdEndRenderingKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }


        public static unsafe PfnVkSignalSemaphoreKhr GetProcAddrSignalSemaphoreKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkSignalSemaphoreKHR");
            return (PfnVkSignalSemaphoreKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkWaitSemaphoresKhr GetProcAddrWaitSemaphoresKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkWaitSemaphoresKHR");
            return (PfnVkWaitSemaphoresKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkGetSemaphoreCounterValueKhr GetProcAddrGetSemaphoreCounterValueKHR(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkGetSemaphoreCounterValueKHR");
            return (PfnVkGetSemaphoreCounterValueKhr)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetScissorWithCountExt GetProcAddrCmdSetScissorWithCountEXT(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetScissorWithCountEXT");
            return (PfnVkCmdSetScissorWithCountExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetViewportWithCountExt GetProcAddrCmdSetViewportWithCountEXT(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetViewportWithCountEXT");
            return (PfnVkCmdSetViewportWithCountExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdBindVertexBuffers2Ext GetProcAddrCmdBindVertexBuffers2EXT(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdBindVertexBuffers2EXT");
            return (PfnVkCmdBindVertexBuffers2Ext)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCreateShadersExt GetProcAddrCreateShadersExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCreateShadersEXT");
            return (PfnVkCreateShadersExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkDestroyShaderExt GetProcAddrDestroyShaderExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkDestroyShaderEXT");
            return (PfnVkDestroyShaderExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdBindShadersExt GetProcAddrCmdBindShadersExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdBindShadersEXT");
            return (PfnVkCmdBindShadersExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetPolygonModeExt GetProcAddrCmdSetPolygonModeExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetPolygonModeEXT");
            return (PfnVkCmdSetPolygonModeExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetRasterizationSamplesExt GetProcAddrCmdSetRasterizationSamplesExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetRasterizationSamplesEXT");
            return (PfnVkCmdSetRasterizationSamplesExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetSampleMaskExt GetProcAddrCmdSetSampleMaskExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetSampleMaskEXT");
            return (PfnVkCmdSetSampleMaskExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetDepthClampEnableExt GetProcAddrCmdSetDepthClampEnableExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetDepthClampEnableEXT");
            return (PfnVkCmdSetDepthClampEnableExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetLogicOpExt GetProcAddrCmdSetLogicOpExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetLogicOpEXT");
            return (PfnVkCmdSetLogicOpExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetLogicOpEnableExt GetProcAddrCmdSetLogicOpEnableExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetLogicOpEnableEXT");
            return (PfnVkCmdSetLogicOpEnableExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetVertexInputExt GetProcAddrCmdSetVertexInputExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetVertexInputEXT");
            return (PfnVkCmdSetVertexInputExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetColorBlendEnableExt GetProcAddrCmdSetColorBlendEnableExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetColorBlendEnableEXT");
            return (PfnVkCmdSetColorBlendEnableExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetColorBlendEquationExt GetProcAddrCmdSetColorBlendEquationExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetColorBlendEquationEXT");
            return (PfnVkCmdSetColorBlendEquationExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetColorWriteMaskExt GetProcAddrCmdSetColorWriteMaskExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetColorWriteMaskEXT");
            return (PfnVkCmdSetColorWriteMaskExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }

        public static unsafe PfnVkCmdSetAlphaToCoverageEnableExt GetProcAddrCmdSetAlphaToCoverageEnableExt(VkDevice_T* i_ptr_device)
        {
            using UnsafeAlloc ptr = UnsafeString.StringToPtrUTF8("vkCmdSetAlphaToCoverageEnableEXT");
            return (PfnVkCmdSetAlphaToCoverageEnableExt)vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.ToRawPtr());
        }
    }
}
