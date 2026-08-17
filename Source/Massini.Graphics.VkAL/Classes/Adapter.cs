
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using System.Runtime.InteropServices;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class Adapter
    {
        public Instance Instance => m_instance;

        /// <summary>
        /// Get adapter info.
        /// </summary>
        /// <returns></returns>
        public AdapterInfo GetInfo()
        {
            VkPhysicalDeviceProperties2 properties2 = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2,  
                pNext = null,
                properties = new(),
            };
            Vk.vkGetPhysicalDeviceProperties2(VkPhysicalDevicePtr, &properties2);

            // Get features.

            VkPhysicalDeviceVulkan14Features vulkan14Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_FEATURES,  
                pNext = null,
            };

            VkPhysicalDeviceVulkan13Features vulkan13Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_3_FEATURES,  
                pNext = &vulkan14Features,
            };

            VkPhysicalDeviceVulkan12Features vulkan12Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES,  
                pNext = &vulkan13Features,
            };

            VkPhysicalDeviceVulkan11Features vulkan11Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES,  
                pNext = &vulkan12Features,
            };

            VkPhysicalDeviceFeatures2 features2 = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2,
                pNext = &vulkan11Features,
                features = new(),  
            };

            Vk.vkGetPhysicalDeviceFeatures2(VkPhysicalDevicePtr, &features2);

            // Get extensions.
            uint propertyCount = 0;
            Vk.vkEnumerateDeviceExtensionProperties(VkPhysicalDevicePtr, null, &propertyCount, null);
            VkExtensionProperties[] extensionProperties = new VkExtensionProperties[propertyCount];
            fixed (VkExtensionProperties* extensionPropertiesPtr = extensionProperties) 
            {
                Vk.vkEnumerateDeviceExtensionProperties(VkPhysicalDevicePtr, null, &propertyCount, extensionPropertiesPtr);
            }

            string[] extensions = new string[propertyCount];
            uint[] extensionVersions = new uint[propertyCount];
            for (int i = 0; i < propertyCount; i++) 
            {
                // Get extension name.
                sbyte[] extensionName = new sbyte[256];
                for (int j = 0; j < 256; j++) 
                {
                    extensionName[j] = extensionProperties[i].extensionName[j];
                }

                string extension = string.Empty;
                fixed (sbyte* extensionNamePtr = extensionName) 
                {
                    extension = Marshal.PtrToStringUTF8((nint)extensionNamePtr) ?? string.Empty;
                }
                extensions[i] = extension;

                // Get extension version.
                extensionVersions[i] = extensionProperties[i].specVersion;
            }

            // Get device name.
            sbyte[] deviceName = new sbyte[256];
            for (int i = 0; i < 256; i++) 
            {
                deviceName[i] = properties2.properties.deviceName[i];
            }

            string name = string.Empty;
            fixed (sbyte* deviceNamePtr = deviceName) 
            {
                name = Marshal.PtrToStringUTF8((nint)deviceNamePtr) ?? string.Empty;
            }

            // Get device type.
            AdapterType type = AdapterType.Other;
            switch (properties2.properties.deviceType)
            {
                case VkPhysicalDeviceType.VK_PHYSICAL_DEVICE_TYPE_OTHER:
                    type = AdapterType.Other;
                    break;
                case VkPhysicalDeviceType.VK_PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU:
                    type = AdapterType.Integrated;
                    break;
                case VkPhysicalDeviceType.VK_PHYSICAL_DEVICE_TYPE_DISCRETE_GPU:
                    type = AdapterType.Discrete;
                    break;
                case VkPhysicalDeviceType.VK_PHYSICAL_DEVICE_TYPE_VIRTUAL_GPU:
                    type = AdapterType.Virtual;
                    break;
                case VkPhysicalDeviceType.VK_PHYSICAL_DEVICE_TYPE_CPU:
                    type = AdapterType.CPU;
                    break;
                default:
                    type = AdapterType.Other;
                    break;
            }

            // Check the feature level.
            FeatureLevel level = FeatureLevel.None;
            
            // Level 1 requires at least Vulkan 1.4.
            bool level1Supported = properties2.properties.apiVersion >= Vk.ApiVersion0140;
            level1Supported = level1Supported && extensions.Contains(Vk.VK_EXT_SHADER_OBJECT);
            level1Supported = level1Supported && extensions.Contains(Vk.VK_KHR_MAINTENANCE_6);

            // Core 1.0
            level1Supported = level1Supported && features2.features.shaderInt64 == 1;
            // Core 1.1
            level1Supported = level1Supported && vulkan11Features.shaderDrawParameters == 1;
            // Core 1.2
            level1Supported = level1Supported && vulkan12Features.timelineSemaphore == 1;
            level1Supported = level1Supported && vulkan12Features.bufferDeviceAddress == 1;
            // Core 1.3
            level1Supported = level1Supported && vulkan13Features.dynamicRendering == 1;
            level1Supported = level1Supported && vulkan13Features.synchronization2 == 1;
            // Core 1.4
            level1Supported = level1Supported && vulkan14Features.pushDescriptor == 1;

            if (level1Supported) 
            {
                level = FeatureLevel.Level1;
            }
            
            return new() 
            {
                p_name = name,
                p_apiVersion = properties2.properties.apiVersion,
                p_driverVersion = properties2.properties.driverVersion,
                p_deviceID = properties2.properties.deviceID,
                p_vendorID = properties2.properties.vendorID,
                p_type = type,
                p_features = new() 
                {
                    p_depthClamp = features2.features.depthClamp is 1,
                    p_fillModeNonSolid = features2.features.fillModeNonSolid is 1,
                    p_wideLines = features2.features.wideLines is 1,
                    p_fragmentStoresAndAtomics = features2.features.fragmentStoresAndAtomics is 1,
                    p_samplerAnisotropy = features2.features.samplerAnisotropy is 1,
                    p_swapchain = extensions.Contains(Vk.VK_KHR_SWAPCHAIN),
                },
                p_featureLevel = level,
            };
        }

        public Device CreateDevice(in DeviceCreateParams i_createParams)
        {
            return new Device(this, i_createParams);
        }

        internal VkPhysicalDevice_T* VkPhysicalDevicePtr => m_ptr_physicalDevice;

        internal static Adapter Create(Instance i_instance, VkPhysicalDevice_T* i_ptr_physicalDevice)
        {
            return new Adapter(i_instance, i_ptr_physicalDevice);
        }

        private readonly Instance m_instance;
        private readonly VkPhysicalDevice_T* m_ptr_physicalDevice;

        private Adapter(Instance i_instance, VkPhysicalDevice_T* i_ptr_physicalDevice)
        {
            m_instance = i_instance;
            m_ptr_physicalDevice = i_ptr_physicalDevice;
        }
    }
}
