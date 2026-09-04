
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Flamet.Structs;
using Massini.Core.Interop;
using Massini.Flamet.Classes.Internal;
using Massini.Flamet.Enums;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes
{
    /// <summary>
    /// Logical device.
    /// </summary>
    public unsafe partial class Device : IDisposable
    {
        /// <summary>
        /// The adapter that created this device.
        /// </summary>
        public Adapter Adapter => m_adapter;

        public IReadOnlyList<QueueFamily> QueueFamilies => m_queueFamilies;

        public Device(Adapter i_adapter, in DeviceCreateParams i_createParams)
        {
            Adapter adapter = i_adapter;
            Instance instance = adapter.Instance;
            FeatureLevel level = i_createParams.p_featureLevel;

            // Feature level must be at least 1.
            if (level == FeatureLevel.None) 
            {
                throw new Exception("Feature level must be at least 1.");
            }

            // Build queue family infos.

            uint queueFamilyCount = 0;
            Vk.vkGetPhysicalDeviceQueueFamilyProperties(adapter.VkPhysicalDevicePtr, &queueFamilyCount, null);
            if (queueFamilyCount == 0)
            {
                throw new Exception("No queue families found.");
            }

            VkQueueFamilyProperties[] queueFamilyProperties = new VkQueueFamilyProperties[queueFamilyCount];
            fixed (VkQueueFamilyProperties* queueFamilyPropertiesPtr = queueFamilyProperties)
            {
                Vk.vkGetPhysicalDeviceQueueFamilyProperties(adapter.VkPhysicalDevicePtr, &queueFamilyCount, queueFamilyPropertiesPtr);
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
            if (i_createParams.p_features.p_swapchain)
            {
                extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_KHR_SWAPCHAIN));
            }

            // Level 1 extensions.

            // TODO: Update api to reflect to new level style api using features instead of some extensions.

            //extensionNamesNativeStringsList.AddRange(QuNativeString.CreateUTF8(Vk.VK_KHR_SYNCHRONIZATION_2));
            extensionNamesNativeStringsList.AddRange(HeapString.CreateUTF8(Vk.VK_EXT_SHADER_OBJECT));
            //extensionNamesNativeStringsList.AddRange(QuNativeString.CreateUTF8(Vk.VK_KHR_MAINTENANCE_6));

            VkPhysicalDeviceShaderObjectFeaturesEXT shaderObjectFeatures = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_OBJECT_FEATURES_EXT,
                pNext = null,
                shaderObject = 1,
            };

            // Device features.

            VkPhysicalDeviceVulkan14Features deviceVulkan14Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_FEATURES,
                pNext = &shaderObjectFeatures,
                pushDescriptor = 1,
            };

            VkPhysicalDeviceVulkan13Features deviceVulkan13Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_3_FEATURES,
                pNext = &deviceVulkan14Features,
                dynamicRendering = 1,
                synchronization2 = 1,
            };

            VkPhysicalDeviceVulkan12Features deviceVulkan12Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES,
                pNext = &deviceVulkan13Features,
                timelineSemaphore = 1,
                bufferDeviceAddress = 1,
            };

            VkPhysicalDeviceVulkan11Features deviceVulkan11Features = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES,
                pNext = &deviceVulkan12Features,
                shaderDrawParameters = 1,
            };

            VkPhysicalDeviceFeatures deviceFeatures = new()
            {
                fillModeNonSolid = i_createParams.p_features.p_fillModeNonSolid ? 1U : 0U,
                depthClamp = i_createParams.p_features.p_depthClamp ? 1U : 0U,
                fragmentStoresAndAtomics = i_createParams.p_features.p_fragmentStoresAndAtomics ? 1U : 0U,
                samplerAnisotropy = i_createParams.p_features.p_samplerAnisotropy ? 1U : 0U,
                wideLines = i_createParams.p_features.p_wideLines ? 1U : 0U,
                shaderInt64 = 1,
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

                    VkResult result1 = Vk.vkCreateDevice(adapter.VkPhysicalDevicePtr, &vkDeviceCreateInfo, null, &device);
                    if (result1 != VkResult.VK_SUCCESS)
                    {
                        throw new Exception("Failed to create device.");
                    }
                }
            }

            // Import extension functions.

            // Import level 1 functions.

            m_deviceFunctionTable.GetProcAddrCmdBeginRenderingKHR(device);
            m_deviceFunctionTable.GetProcAddrCmdEndRenderingKHR(device);
            m_deviceFunctionTable.GetProcAddrGetSemaphoreCounterValueKHR(device);
            m_deviceFunctionTable.GetProcAddrWaitSemaphoresKHR(device);
            m_deviceFunctionTable.GetProcAddrCmdSetScissorWithCountEXT(device);
            m_deviceFunctionTable.GetProcAddrCmdSetViewportWithCountEXT(device);
            m_deviceFunctionTable.GetProcAddrCmdBindVertexBuffers2EXT(device);
            m_deviceFunctionTable.GetProcAddrCmdPushDescriptorSetKHR(device);
            m_deviceFunctionTable.GetProcAddrCreateShadersExt(device);
            m_deviceFunctionTable.GetProcAddrDestroyShaderExt(device);
            m_deviceFunctionTable.GetProcAddrCmdBindShadersExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetPolygonModeExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetRasterizationSamplesExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetSampleMaskExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetDepthClampEnableExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetLogicOpExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetLogicOpEnableExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetVertexInputExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorBlendEnableExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorBlendEquationExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetColorWriteMaskExt(device);
            m_deviceFunctionTable.GetProcAddrCmdSetAlphaToCoverageEnableExt(device);

            // Setup queue families.
            List<QueueFamily> queueFamilies = [];
            for (int familyIndex = 0; familyIndex < queueFamilyProperties.Length; familyIndex++)
            {
                VkQueue_T*[] queues = new VkQueue_T*[queueFamilyProperties[familyIndex].queueCount];
                for (int queueIndex = 0; queueIndex < queues.Length; queueIndex++)
                {
                    VkQueue_T* queue = null;
                    Vk.vkGetDeviceQueue(device, (uint)familyIndex, (uint)queueIndex, &queue);
                    queues[queueIndex] = queue;
                }

                List<Queue> queuesList = [];
                foreach (VkQueue_T* vkQueue in queues)
                {
                    Queue queue = Queue.Create((uint)familyIndex, vkQueue);
                    queuesList.Add(queue);
                }

                QueueFamily queueFamily = QueueFamily.Create(
                    device,
                    (uint)familyIndex,
                    IntSharedCvs.VkQueueFlagBitsToQueueUsageFlags((VkQueueFlagBits)queueFamilyProperties[familyIndex].queueFlags),
                    queuesList);
                queueFamilies.Add(queueFamily);

                foreach (Queue queue in queuesList)
                {
                    queue.SetQueueFamily(queueFamily);
                }
            }

            // Create memory allocator.
            VmaAllocatorCreateInfo allocatorCreateInfo = new()
            {
                p_ptr_instance = instance.VkInstancePtr,
                p_ptr_physicalDevice = adapter.VkPhysicalDevicePtr,
                p_ptr_device = device,
            };

            VmaAllocator* allocator = null;
            VkResult result2 = Vma.vmaCreateAllocator(&allocatorCreateInfo, &allocator);
            if (result2 != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create allocator.");
            }

            // Create descriptor allocator.
            DescriptorAllocator descriptorAllocator = new(device);

            m_adapter = i_adapter;
            m_ptr_device = device;
            m_ptr_allocator = allocator;
            m_queueFamilies = queueFamilies;
            m_descriptorAllocator = descriptorAllocator;

            // Link queue families.
            foreach (QueueFamily queueFamily in queueFamilies)
            {
                queueFamily.SetDevice(this);
            }

            // Free memory.
            foreach (var extensionName in extensionNamesNativeStringsList)
            {
                extensionName.Dispose();
            }
        }

        /// <summary>
        /// Destroy the device.
        /// </summary>
        /// <remarks>
        /// The device must be idle and all its associated resources freed before it can be destroyed.
        /// </remarks>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                Vma.vmaDestroyAllocator(m_ptr_allocator);
                m_descriptorAllocator?.Dispose();
                foreach (QueueFamily queueFamily in m_queueFamilies)
                {
                    queueFamily.Dispose();
                }
                Vk.vkDestroyDevice(m_ptr_device, null);
            }
        }

        /// <summary>
        /// Wait for the device to become idle.
        /// </summary>
        public void WaitIdle() 
        {
            Vk.vkDeviceWaitIdle(m_ptr_device);
        }

        /// <summary>
        /// Creates a buffer.
        /// </summary>
        public Buffer CreateBuffer(in BufferCreateParams i_createParams)
        {
            return new Buffer(this, i_createParams);
        }

        /// <summary>
        /// Creates a texture.
        /// </summary>
        public Texture CreateTexture(in TextureCreateParams i_createParams)
        {
            return new Texture(this, i_createParams);
        }

        /// <summary>
        /// Creates a swapchain.
        /// </summary>
        public Swapchain CreateSwapchain(in SwapchainCreateParams i_createParams)
        {
            return new Swapchain(this, i_createParams);
        }

        /// <summary>
        /// Creates a sampler.
        /// </summary>
        public Sampler CreateSampler(in SamplerCreateParams i_createParams)
        {
            return new Sampler(this, i_createParams);
        }

        /// <summary>
        /// Creates a shader link.
        /// </summary>
        public ShaderLink CreateShaderLink(in ShaderLinkCreateParams i_createParams)
        {
            return new ShaderLink(this, i_createParams);
        }

        /// <summary>
        /// Creates a layout.
        /// </summary>
        public Layout CreateLayout(in LayoutCreateParams i_createParams)
        {
            return new Layout(this, i_createParams);
        }
    }

    public unsafe partial class Device 
    {
        internal DescriptorAllocator DescriptorAllocator => m_descriptorAllocator;

        internal VkDevice_T* VkDevicePtr => m_ptr_device;

        internal VmaAllocator* VmaAllocatorPtr => m_ptr_allocator;
        
        internal DeviceFunctionTable GetFunctionTable()
        {
            return m_deviceFunctionTable;
        }

        private bool m_isDisposed = false;
        private readonly Adapter m_adapter;
        private readonly VkDevice_T* m_ptr_device;
        private readonly DeviceFunctionTable m_deviceFunctionTable = new();
        private readonly VmaAllocator* m_ptr_allocator;
        private readonly List<QueueFamily> m_queueFamilies;
        private readonly DescriptorAllocator m_descriptorAllocator;
    }
}
