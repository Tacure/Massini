using Massini.Bindings.Vulkan;
using Massini.Core.Interop;

namespace Massini.Flamet.Classes.Internal
{
    internal sealed unsafe class InstanceFunctionTable
    {
        public delegate* unmanaged[Cdecl]<
            VkInstance_T*,
            VkDebugUtilsMessengerCreateInfoEXT*,
            VkAllocationCallbacks*,
            VkDebugUtilsMessengerEXT_T**,
            VkResult> PfnVkCreateDebugUtilsMessengerExt { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkInstance_T*,
            VkDebugUtilsMessengerEXT_T*,
            VkAllocationCallbacks*,
            void> PfnVkDestroyDebugUtilsMessengerExt { get; set; } = null;

        public unsafe delegate* unmanaged[Cdecl]<
            VkDevice_T*,
            VkDebugUtilsObjectNameInfoEXT*,
            VkResult> PfnVkSetDebugUtilsObjectNameExt { get; set; } = null;
        
        public void GetProcAddrCreateDebugUtilsMessengerEXT(VkInstance_T* i_ptr_instance)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCreateDebugUtilsMessengerEXT");
            PfnVkCreateDebugUtilsMessengerExt = (delegate* unmanaged[Cdecl]<
                VkInstance_T*,
                VkDebugUtilsMessengerCreateInfoEXT*,
                VkAllocationCallbacks*,
                VkDebugUtilsMessengerEXT_T**,
                VkResult>)Vk.vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrDestroyDebugUtilsMessengerEXT(VkInstance_T* i_ptr_instance)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkDestroyDebugUtilsMessengerEXT");
            PfnVkDestroyDebugUtilsMessengerExt = (delegate* unmanaged[Cdecl]<
                VkInstance_T*,
                VkDebugUtilsMessengerEXT_T*,
                VkAllocationCallbacks*,
                void>)Vk.vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrSetDebugUtilsObjectNameEXT(VkInstance_T* i_ptr_instance)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkSetDebugUtilsObjectNameEXT");
            PfnVkSetDebugUtilsObjectNameExt = (delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkDebugUtilsObjectNameInfoEXT*,
                VkResult>)Vk.vkGetInstanceProcAddr(i_ptr_instance, (sbyte*)ptr.RawPtr());
        }
    }
}