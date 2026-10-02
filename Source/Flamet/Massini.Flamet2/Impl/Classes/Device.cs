using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using Massini.Flamet2.Impl.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Device : IDevice1
    {
        public Device(in DeviceCreateParams i_createParams, IAdapterSelector i_selector)
        {
            // Create instance.
            m_instance = new Instance(new InstanceCreateParams()
            {
                p_label = "Flamet Instance",
                p_features = new InstanceFeatures()
                {
                    p_debugUtils = i_createParams.p_enableDebugMode,
                    p_surface = i_createParams.p_enableSwapchain,
                },
            });

            m_instance.OnLog += i_createParams.p_logCallback;
            
            // Select an adapter.
            if (i_selector.Select(m_instance.GetAdapters()) is not Adapter adapter)
            {
                m_instance.Dispose();
                throw new Exception("Adapter not selected.");
            }
            m_adapter = adapter;
            
            // Feature level must be at least 1.
            if (m_adapter.GetInfo().FeatureLevel == FeatureLevel.None) 
            {
                throw new Exception("Feature level must be at least 1.");
            }
            
            // Build queue family infos.

            uint queueFamilyCount = 0;
            Vk.vkGetPhysicalDeviceQueueFamilyProperties(m_adapter.VkPhysicalDevicePtr, &queueFamilyCount, null);
            if (queueFamilyCount == 0)
            {
                throw new Exception("No queue families found.");
            }

            VkQueueFamilyProperties[] queueFamilyProperties = new VkQueueFamilyProperties[queueFamilyCount];
            fixed (VkQueueFamilyProperties* queueFamilyPropertiesPtr = queueFamilyProperties)
            {
                Vk.vkGetPhysicalDeviceQueueFamilyProperties(m_adapter.VkPhysicalDevicePtr, &queueFamilyCount, queueFamilyPropertiesPtr);
            }

            VkDeviceQueueCreateInfo[] vkDeviceQueueCreateInfos = new VkDeviceQueueCreateInfo[queueFamilyProperties.Length];

            // Get total queue count.
            int totalQueueCount = 0;
            for (int i = 0; i < queueFamilyProperties.Length; i++)
            {
                totalQueueCount += (int)queueFamilyProperties[i].queueCount;
            }

            // Set queue priorities.
            float* queuePriorityPtr = stackalloc float[totalQueueCount];
            for (int i = 0; i < totalQueueCount; i++)
            {
                queuePriorityPtr[i] = 1.0f;
            }

            int offset = 0;
            for (int i = 0; i < queueFamilyProperties.Length; i++)
            {
                VkDeviceQueueCreateInfo vkDeviceQueueCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
                    queueFamilyIndex = (uint)i,
                    queueCount = queueFamilyProperties[i].queueCount,
                    pQueuePriorities = queuePriorityPtr + offset,
                };
                vkDeviceQueueCreateInfos[i] = vkDeviceQueueCreateInfo;

                offset += (int)queueFamilyProperties[i].queueCount;
            }

            // Prepare extensions list.

            List<HeapString> extensionNamesNativeStringsList = [];

            // Optional extensions.
            if (i_createParams.p_enableSwapchain)
            {
                extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_KHR_SWAPCHAIN));
            }

            // Level 1 extensions.

            // TODO: Update api to reflect to new level style api using features instead of some extensions.

            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_SHADER_OBJECT));
            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_EXTENDED_DYNAMIC_STATE));
            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_EXTENDED_DYNAMIC_STATE_2));
            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_EXTENDED_DYNAMIC_STATE_3));
            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_VERTEX_INPUT_DYNAMIC_STATE));

            VkPhysicalDeviceVertexInputDynamicStateFeaturesEXT deviceVertexInputDynamicStateFeatures = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_INPUT_DYNAMIC_STATE_FEATURES_EXT,
                pNext = null,
                vertexInputDynamicState = Vk.VK_TRUE,
            };
            
            VkPhysicalDeviceExtendedDynamicStateFeaturesEXT deviceExtendedDynamicStateFeatures = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_FEATURES_EXT,
                pNext = &deviceVertexInputDynamicStateFeatures,
                extendedDynamicState = Vk.VK_TRUE,
            };

            VkPhysicalDeviceExtendedDynamicState2FeaturesEXT deviceExtendedDynamicState2Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_2_FEATURES_EXT,
                pNext = &deviceExtendedDynamicStateFeatures,
                extendedDynamicState2 = Vk.VK_TRUE,
                extendedDynamicState2LogicOp = Vk.VK_TRUE,
                extendedDynamicState2PatchControlPoints = Vk.VK_TRUE,
            };

            VkPhysicalDeviceExtendedDynamicState3FeaturesEXT deviceExtendedDynamicState3Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_3_FEATURES_EXT,
                pNext = &deviceExtendedDynamicState2Features,
                extendedDynamicState3AlphaToCoverageEnable = Vk.VK_TRUE,
                extendedDynamicState3ColorBlendEnable = Vk.VK_TRUE,
                extendedDynamicState3ColorBlendEquation = Vk.VK_TRUE,
                extendedDynamicState3ColorWriteMask = Vk.VK_TRUE,
                extendedDynamicState3DepthClampEnable = Vk.VK_TRUE,
                extendedDynamicState3DepthClipEnable = Vk.VK_TRUE,
                extendedDynamicState3LogicOpEnable = Vk.VK_TRUE,
                extendedDynamicState3RasterizationSamples = Vk.VK_TRUE,
                extendedDynamicState3SampleMask = Vk.VK_TRUE,
                extendedDynamicState3PolygonMode = Vk.VK_TRUE,
            };
            
            VkPhysicalDeviceShaderObjectFeaturesEXT shaderObjectFeatures = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_OBJECT_FEATURES_EXT,
                pNext = &deviceExtendedDynamicState3Features,
                shaderObject = Vk.VK_TRUE,
            };

            // Device features.

            VkPhysicalDeviceVulkan14Features deviceVulkan14Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_FEATURES,
                pNext = &shaderObjectFeatures,
                pushDescriptor = Vk.VK_TRUE,
                maintenance5 = Vk.VK_TRUE,
            };

            VkPhysicalDeviceVulkan13Features deviceVulkan13Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_3_FEATURES,
                pNext = &deviceVulkan14Features,
                dynamicRendering = Vk.VK_TRUE,
                synchronization2 = Vk.VK_TRUE,
            };

            VkPhysicalDeviceVulkan12Features deviceVulkan12Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES,
                pNext = &deviceVulkan13Features,
                timelineSemaphore = Vk.VK_TRUE,
                bufferDeviceAddress = Vk.VK_TRUE,
            };

            VkPhysicalDeviceVulkan11Features deviceVulkan11Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES,
                pNext = &deviceVulkan12Features,
                shaderDrawParameters = Vk.VK_TRUE,
            };

            AdapterInfo adapterInfo = m_adapter.GetInfo();
            
            VkPhysicalDeviceFeatures deviceFeatures = new()
            {
                fillModeNonSolid = adapterInfo.Features.FillModeNonSolid ? Vk.VK_TRUE : Vk.VK_FALSE,
                depthClamp = adapterInfo.Features.DepthClamp ? Vk.VK_TRUE : Vk.VK_FALSE,
                fragmentStoresAndAtomics = adapterInfo.Features.FragmentStoresAndAtomics ? Vk.VK_TRUE : Vk.VK_FALSE,
                samplerAnisotropy = adapterInfo.Features.SamplerAnisotropy ? Vk.VK_TRUE : Vk.VK_FALSE,
                wideLines = adapterInfo.Features.WideLines ? Vk.VK_TRUE : Vk.VK_FALSE,
                shaderInt64 = Vk.VK_TRUE,
                shaderFloat64 = Vk.VK_TRUE,
            };

            VkPhysicalDeviceFeatures2 deviceFeatures2 = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2,
                pNext = &deviceVulkan11Features,
                features = deviceFeatures,
            };

            // Create device.

            VkDevice_T* device = null;
            fixed (VkDeviceQueueCreateInfo* vkDeviceQueueCreateInfosPtr = vkDeviceQueueCreateInfos)
            {
                sbyte*[] extensionNames = new sbyte*[extensionNamesNativeStringsList.Count];
                for (int i = 0; i < extensionNamesNativeStringsList.Count; i++)
                {
                    extensionNames[i] = (sbyte*)extensionNamesNativeStringsList[i].RawPtr();
                }

                fixed (sbyte** extensionNamesPtr = extensionNames)
                {
                    VkDeviceCreateInfo vkDeviceCreateInfo = new()
                    {
                        sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO,
                        pNext = &deviceFeatures2,//&deviceDynamicRenderingFeatures,
                        queueCreateInfoCount = (uint)vkDeviceQueueCreateInfos.Length,
                        pQueueCreateInfos = vkDeviceQueueCreateInfosPtr,
                        enabledExtensionCount = (uint)extensionNames.Length,
                        ppEnabledExtensionNames = (sbyte**)extensionNamesPtr,
                        pEnabledFeatures = null,//&deviceFeatures,
                    };

                    VkResult result1 = Vk.vkCreateDevice(m_adapter.VkPhysicalDevicePtr, &vkDeviceCreateInfo, null, &device);
                    if (result1 != VkResult.VK_SUCCESS)
                    {
                        throw new Exception("Failed to create device.");
                    }

                    m_ptr_device = device;
                }
            }

            // Import extension functions.
            m_deviceFunctionTable = new DeviceFunctionTable();  

            // Import level 1 functions.

            m_deviceFunctionTable.GetProcAddrCmdBeginRenderingKHR(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdEndRenderingKHR(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrGetSemaphoreCounterValueKHR(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrWaitSemaphoresKHR(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetScissorWithCountEXT(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetViewportWithCountEXT(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdBindVertexBuffers2EXT(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdPushDescriptorSetKHR(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCreateShadersExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrDestroyShaderExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdBindShadersExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetPolygonModeExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetRasterizationSamplesExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetSampleMaskExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetDepthClampEnableExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetLogicOpExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetLogicOpEnableExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetVertexInputExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorBlendEnableExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorBlendEquationExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorWriteMaskExt(m_ptr_device);
            m_deviceFunctionTable.GetProcAddrCmdSetAlphaToCoverageEnableExt(m_ptr_device);

            // Setup lanes.
            m_lanes = [];
            for (int familyIndex = 0; familyIndex < queueFamilyProperties.Length; familyIndex++)
            {
                VkQueue_T*[] queues = new VkQueue_T*[queueFamilyProperties[familyIndex].queueCount];
                for (int queueIndex = 0; queueIndex < queues.Length; queueIndex++)
                {
                    VkQueue_T* queue = null;
                    Vk.vkGetDeviceQueue(m_ptr_device, (uint)familyIndex, (uint)queueIndex, &queue);
                    queues[queueIndex] = queue;
                }
                
                m_lanes.Add(new Lane(this, IntSharedCvs.VkQueueFlagBitsToLaneUsageFlags((VkQueueFlagBits)queueFamilyProperties[familyIndex].queueFlags), (uint)familyIndex, queues));
            }

            // Create memory allocator.
            VmaAllocatorCreateInfo allocatorCreateInfo = new()
            {
                p_ptr_instance = m_instance.VkInstancePtr,
                p_ptr_physicalDevice = m_adapter.VkPhysicalDevicePtr,
                p_ptr_device = m_ptr_device,
                p_flags = VmaAllocatorCreateFlagBits.VMA_ALLOCATOR_CREATE_BUFFER_DEVICE_ADDRESS_BIT,
            };

            VmaAllocator* allocator = null;
            VkResult result2 = Vma.vmaCreateAllocator(&allocatorCreateInfo, &allocator);
            if (result2 != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create allocator.");
            }
            m_ptr_vmaAllocator = allocator;

            // Free memory.
            foreach (var extensionName in extensionNamesNativeStringsList)
            {
                extensionName.Dispose();
            }
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;

                Vma.vmaDestroyAllocator(m_ptr_vmaAllocator);
                foreach (Lane lane in m_lanes)
                {
                    lane.Dispose();
                }
                Vk.vkDestroyDevice(m_ptr_device, null);
                m_instance.Dispose();
            }
        }

        public IReadOnlyList<ILane1> GetLanes()
        {
            return m_lanes;
        }

        internal Instance Instance => m_instance;
        
        internal VkDevice_T* VkDevicePtr => m_ptr_device;

        internal VmaAllocator* VmaAllocatorPtr => m_ptr_vmaAllocator;
        
        private bool m_isDisposed = false;
        private readonly Instance m_instance;
        private readonly Adapter m_adapter;
        private readonly List<Lane> m_lanes;
        private readonly VkDevice_T* m_ptr_device;
        private readonly VmaAllocator* m_ptr_vmaAllocator;
        private readonly DeviceFunctionTable m_deviceFunctionTable;
    }   
}