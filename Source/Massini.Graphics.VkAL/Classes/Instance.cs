using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Massini.Bindings.Vma.Loader;
using Massini.Bindings.Vulkan;
using Massini.Bindings.Vulkan.Loader;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs;
using Massini.Interop;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class Instance : IDisposable
    {
        public class ExtensionFunctions 
        {
            public delegate* unmanaged[Cdecl]<
                VkInstance_T*,
                VkDebugUtilsMessengerCreateInfoEXT*,
                VkAllocationCallbacks*,
                VkDebugUtilsMessengerEXT_T**,
                VkResult> PfnVkCreateDebugUtilsMessengerExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkInstance_T*,
                VkDebugUtilsMessengerEXT_T*,
                VkAllocationCallbacks*,
                void> PfnVkDestroyDebugUtilsMessengerExt
            { get; set; } = null;

            public unsafe delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkDebugUtilsObjectNameInfoEXT*,
                VkResult> PfnVkSetDebugUtilsObjectNameExt
            { get; set; } = null;
        }

        public event Action<LogLevel, string>? OnLog = null;

        public Instance(in InstanceCreateParams i_createParams)
        {
            VulkanLoader.Setup();
            VmaLoader.Setup();

            // Baseline API version 1.4.
            uint apiVersion = Vk.ApiVersion0140;

            // Instance extensions.
            List<UnsafeAlloc> extensions = [];

            // Instance extensions.
            if (i_createParams.p_features.p_surface)
            {
                extensions.Add(UnsafeString.StringToPtrUTF8(Vk.VK_KHR_SURFACE));

                // Check if platform is windows.
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    extensions.Add(UnsafeString.StringToPtrUTF8(Vk.VK_KHR_WIN32_SURFACE));
                }
                // Check if platform is linux.
                // TODO: Check if it's using X11 or Wayland.
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    extensions.Add(UnsafeString.StringToPtrUTF8(Vk.VK_KHR_XLIB_SURFACE));
                }
            }

            if (i_createParams.p_features.p_debugUtils)
            {
                extensions.Add(UnsafeString.StringToPtrUTF8(Vk.VK_EXT_DEBUG_UTILS));
            }

            // Get strings pointers.
            sbyte*[] instanceExtensions = new sbyte*[extensions.Count];
            for (int i = 0; i < extensions.Count; i++)
            {
                instanceExtensions[i] = (sbyte*)extensions[i].ToRawPtr();
            }

            // Validation layers.
            using UnsafeAlloc layerName = UnsafeString.StringToPtrUTF8(Vk.VK_LAYER_KHRONOS_VALIDATION);

            sbyte*[] layerNames = [];
            if (i_createParams.p_features.p_debugUtils)
            {
                layerNames = [(sbyte*)layerName.ToRawPtr()];
            }

            VkInstance_T* vkInstance = null;
            fixed (sbyte** instanceExtensionsPtr = instanceExtensions, layerNamesPtr = layerNames)
            {
                VkApplicationInfo applicationInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO,
                    pNext = null,
                    apiVersion = apiVersion,
                };

                VkInstanceCreateInfo vkInstanceCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO,
                    pNext = null,
                    flags = 0,
                    enabledExtensionCount = (uint)instanceExtensions.Length,
                    ppEnabledExtensionNames = instanceExtensionsPtr,
                    enabledLayerCount = (uint)layerNames.Length,
                    ppEnabledLayerNames = layerNamesPtr,
                    pApplicationInfo = &applicationInfo,
                };

                VkResult result = Vk.vkCreateInstance(&vkInstanceCreateInfo, null, &vkInstance);
                if (result != VkResult.VK_SUCCESS)
                {
                    throw new Exception("Failed to create Vulkan instance.");
                }
            }

            m_label = i_createParams.p_label;
            m_ptr_handle = ObjectHandle.Pin(this).ToRawPtr();
            m_apiVersion = apiVersion;
            m_ptr_instance = vkInstance;

            // Import functions.
            if (i_createParams.p_features.p_debugUtils) 
            {
                ExtFunctions.PfnVkCreateDebugUtilsMessengerExt = Vk.GetProcAddrCreateDebugUtilsMessengerEXT(vkInstance);
                ExtFunctions.PfnVkDestroyDebugUtilsMessengerExt = Vk.GetProcAddrDestroyDebugUtilsMessengerEXT(vkInstance);
                ExtFunctions.PfnVkSetDebugUtilsObjectNameExt = Vk.GetProcAddrSetDebugUtilsObjectNameEXT(vkInstance);
            }

            // Create debug messenger.
            if (i_createParams.p_features.p_debugUtils)
            {
                m_ptr_debugUtilsMessenger = CreateDebugMessenger(vkInstance, m_ptr_handle, ExtFunctions);
            }

            // Free strings.
            foreach (UnsafeAlloc nativeString in extensions)
            {
                nativeString.Dispose();
            }
        }

        public ExtensionFunctions ExtFunctions { get; private init; } = new();

        public VkInstance_T* VkInstancePtr => m_ptr_instance;

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                ObjectHandle.FromRawPtr(m_ptr_handle).Unpin();

                if (m_ptr_debugUtilsMessenger != null)
                {
                    DestroyDebugMessenger();
                }
                Vk.vkDestroyInstance(m_ptr_instance, null);
            }
        }

        public Surface CreateSurface(in SurfaceCreateParams i_createParams)
        {
            return Surface.Create(this, i_createParams);
        }

        public IReadOnlyList<Adapter> GetAdapters(in AdapterRequirements i_requirements)
        {
            if (m_adapters.Count == 0)
            {
                uint deviceCount = 0;
                Vk.vkEnumeratePhysicalDevices(m_ptr_instance, &deviceCount, null);
                if (deviceCount == 0)
                {
                    OnLog?.Invoke(LogLevel.Warning, "No physical devices found with Vulkan support.");
                    return [];
                }

                VkPhysicalDevice_T*[] physicalDevices = new VkPhysicalDevice_T*[deviceCount];
                fixed (VkPhysicalDevice_T** physicalDevicesPtr = physicalDevices)
                {
                    Vk.vkEnumeratePhysicalDevices(m_ptr_instance, &deviceCount, physicalDevicesPtr);
                }

                foreach (VkPhysicalDevice_T* physicalDevice in physicalDevices)
                {
                    Adapter adapter = Adapter.Create(this, physicalDevice);
                    m_adapters.Add(adapter);
                }
            }

            return m_adapters;
        }

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly void* m_ptr_handle;
        private readonly uint m_apiVersion;
        private readonly VkInstance_T* m_ptr_instance;
        private VkDebugUtilsMessengerEXT_T* m_ptr_debugUtilsMessenger;
        private readonly List<Adapter> m_adapters = [];

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static uint DebugCallback(
            VkDebugUtilsMessageSeverityFlagBitsEXT i_messageSeverity,
            uint i_messageType,
            VkDebugUtilsMessengerCallbackDataEXT* i_ptr_callbackData,
            void* i_ptr_userData)
        {
            string message = Marshal.PtrToStringUTF8((nint)i_ptr_callbackData->pMessage) ?? string.Empty;

            LogLevel severity = i_messageSeverity switch
            {
                VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT => LogLevel.Info,
                VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT => LogLevel.Info,
                VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT => LogLevel.Warning,
                VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT => LogLevel.Error,
                _ => LogLevel.Info
            };

            Instance backend = ObjectHandle.FromRawPtr(i_ptr_userData).Target<Instance>()!;
            backend.OnLog?.Invoke(severity, message);

            return 1;
        }

        private static VkDebugUtilsMessengerEXT_T* CreateDebugMessenger(VkInstance_T* i_ptr_instance, void* i_ptr_handle, ExtensionFunctions i_functions)
        {
            VkDebugUtilsMessengerCreateInfoEXT vkDebugUtilsMessengerCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT,
                pNext = null,
                messageSeverity = (uint)(VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT),
                messageType = (uint)(VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT | VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT | VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT),
                pUserData = i_ptr_handle,
                pfnUserCallback = &DebugCallback,
            };

            VkDebugUtilsMessengerEXT_T* vkDebugUtilsMessenger = null;
            i_functions.PfnVkCreateDebugUtilsMessengerExt(i_ptr_instance, &vkDebugUtilsMessengerCreateInfo, null, &vkDebugUtilsMessenger);
            return vkDebugUtilsMessenger;
        }

        private void DestroyDebugMessenger()
        {
            ExtFunctions.PfnVkDestroyDebugUtilsMessengerExt(m_ptr_instance, m_ptr_debugUtilsMessenger, null);
        }
    }
}
