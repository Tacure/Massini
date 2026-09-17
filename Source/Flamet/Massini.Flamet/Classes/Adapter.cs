
using Massini.Bindings.Vulkan;
using System.Runtime.InteropServices;
using Massini.Flamet.Enums;
using Massini.Flamet.Structs;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes
{
    /// <summary>
    /// Physical device.
    /// </summary>
    public unsafe class Adapter
    {
        /// <summary>
        /// The instance that queried this adapter.
        /// </summary>
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
            
            VkPhysicalDeviceExtendedDynamicState3FeaturesEXT extendedDynamicStateFeatures3 = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_3_FEATURES_EXT,
            };
            
            VkPhysicalDeviceExtendedDynamicState2FeaturesEXT extendedDynamicStateFeatures2 = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_2_FEATURES_EXT,  
                pNext = &extendedDynamicStateFeatures3,
            };
            
            VkPhysicalDeviceExtendedDynamicStateFeaturesEXT extendedDynamicStateFeatures = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_FEATURES_EXT,  
                pNext = &extendedDynamicStateFeatures2,
            };

            VkPhysicalDeviceVulkan14Features vulkan14Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_FEATURES,  
                pNext = &extendedDynamicStateFeatures,
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
                features = new VkPhysicalDeviceFeatures(),  
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
            
            #region Level 1
            
            // Level 1 requires at least Vulkan 1.4.
            bool level1Supported = true;
            LevelSupportCheckApiVersion(ref level1Supported, properties2.properties.apiVersion, Vk.ApiVersion0140);

            // Core 1.0
            LevelSupportCheckBool(ref level1Supported, features2.features.shaderInt64);
            LevelSupportCheckBool(ref level1Supported, features2.features.shaderFloat64);
            // Core 1.1
            LevelSupportCheckBool(ref level1Supported, vulkan11Features.shaderDrawParameters);
            // Core 1.2
            LevelSupportCheckBool(ref level1Supported, vulkan12Features.timelineSemaphore);
            LevelSupportCheckBool(ref level1Supported, vulkan12Features.bufferDeviceAddress);
            // Core 1.3
            LevelSupportCheckBool(ref level1Supported, vulkan13Features.dynamicRendering);
            LevelSupportCheckBool(ref level1Supported, vulkan13Features.synchronization2);
            // Core 1.4
            LevelSupportCheckBool(ref level1Supported, vulkan14Features.pushDescriptor);
            LevelSupportCheckBool(ref level1Supported, vulkan14Features.maintenance5);
            
            // Check extensions.
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_SHADER_OBJECT);
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_EXTENDED_DYNAMIC_STATE);
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_EXTENDED_DYNAMIC_STATE_2);
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_EXTENDED_DYNAMIC_STATE_3);
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_VERTEX_INPUT_DYNAMIC_STATE);
            LevelSupportCheckExtension(ref level1Supported, extensions, Vk.VK_EXT_DESCRIPTOR_HEAP);
            
            // Check extensions features.
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures.extendedDynamicState);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures2.extendedDynamicState2);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures2.extendedDynamicState2LogicOp);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures2.extendedDynamicState2PatchControlPoints);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3AlphaToCoverageEnable);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3ColorBlendEnable);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3ColorBlendEquation);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3ColorWriteMask);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3DepthClampEnable);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3DepthClipEnable);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3LogicOpEnable);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3RasterizationSamples);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3SampleMask);
            LevelSupportCheckBool(ref level1Supported, extendedDynamicStateFeatures3.extendedDynamicState3PolygonMode);

            if (level1Supported) 
            {
                level = FeatureLevel.Level1;
            }
            
            #endregion
            
            return new AdapterInfo
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

        /// <summary>
        /// Create a device.
        /// </summary>
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

        private static void LevelSupportCheckApiVersion(ref bool r_support, uint i_value, uint i_minVersion)
        {
            r_support = r_support && (i_value >= i_minVersion);
        }

        private static void LevelSupportCheckBool(ref bool r_support, uint i_value)
        {
            r_support = r_support && (i_value == 1);
        }

        private static void LevelSupportCheckExtension(ref bool r_support, string[] i_extensions, string i_extension)
        {
            r_support = r_support && i_extensions.Contains(i_extension);
        }
    }
}
