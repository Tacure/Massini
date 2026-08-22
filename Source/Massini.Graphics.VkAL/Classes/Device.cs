
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Classes.Internal;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Core.Interop;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class Device : IDisposable
    {
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

            List<UnsafeAlloc> extensionNamesNativeStringsList = [];

            // Optional extensions.
            if (i_createParams.p_features.p_swapchain)
            {
                extensionNamesNativeStringsList.AddRange(UnsafeString.StringToPtrUTF8(Vk.VK_KHR_SWAPCHAIN));
            }

            // Level 1 extensions.

            // TODO: Update api to reflect to new level style api using features instead of some extensions.

            //extensionNamesNativeStringsList.AddRange(QuNativeString.CreateUTF8(Vk.VK_KHR_SYNCHRONIZATION_2));
            extensionNamesNativeStringsList.AddRange(UnsafeString.StringToPtrUTF8(Vk.VK_EXT_SHADER_OBJECT));
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
                    extensionNames[i] = (sbyte*)extensionNamesNativeStringsList[i].ToRawPtr();
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

            Functions functions = new();

            // Import level 1 functions.

            functions.PfnVkCmdBeginRenderingKhr = Vk.GetProcAddrCmdBeginRenderingKHR(device);
            functions.PfnVkCmdEndRenderingKhr = Vk.GetProcAddrCmdEndRenderingKHR(device);
            functions.PfnVkGetSemaphoreCounterValue = Vk.GetProcAddrGetSemaphoreCounterValueKHR(device);
            functions.PfnVkWaitSemaphoresKhr = Vk.GetProcAddrWaitSemaphoresKHR(device);
            functions.PfnVkCmdSetScissorWithCountExt = Vk.GetProcAddrCmdSetScissorWithCountEXT(device);
            functions.PfnVkCmdSetViewportWithCountExt = Vk.GetProcAddrCmdSetViewportWithCountEXT(device);
            functions.PfnVkCmdBindVertexBuffers2Ext = Vk.GetProcAddrCmdBindVertexBuffers2EXT(device);
            functions.PfnVkCmdPushDescriptorSetKhr = Vk.GetProcAddrCmdPushDescriptorSetKHR(device);
            functions.PfnVkCreateShadersExt = Vk.GetProcAddrCreateShadersExt(device);
            functions.PfnVkDestroyShaderExt = Vk.GetProcAddrDestroyShaderExt(device);
            functions.PfnVkCmdBindShadersExt = Vk.GetProcAddrCmdBindShadersExt(device);
            functions.PfnVkCmdSetPolygonModeExt = Vk.GetProcAddrCmdSetPolygonModeExt(device);
            functions.PfnVkCmdSetRasterizationSamplesExt = Vk.GetProcAddrCmdSetRasterizationSamplesExt(device);
            functions.PfnVkCmdSetSampleMaskExt = Vk.GetProcAddrCmdSetSampleMaskExt(device);
            functions.PfnVkCmdSetDepthClampEnableExt = Vk.GetProcAddrCmdSetDepthClampEnableExt(device);
            functions.PfnVkCmdSetLogicOpExt = Vk.GetProcAddrCmdSetLogicOpExt(device);
            functions.PfnVkCmdSetLogicOpEnableExt = Vk.GetProcAddrCmdSetLogicOpEnableExt(device);
            functions.PfnVkCmdSetVertexInputExt = Vk.GetProcAddrCmdSetVertexInputExt(device);
            functions.PfnVkCmdSetColorBlendEnableExt = Vk.GetProcAddrCmdSetColorBlendEnableExt(device);
            functions.PfnVkCmdSetColorBlendEquationExt = Vk.GetProcAddrCmdSetColorBlendEquationExt(device);
            functions.PfnVkCmdSetColorWriteMaskExt = Vk.GetProcAddrCmdSetColorWriteMaskExt(device);
            functions.PfnVkCmdSetAlphaToCoverageEnableExt = Vk.GetProcAddrCmdSetAlphaToCoverageEnableExt(device);

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
                    VkUtils.VkQueueFlagBitsToQueueUsageFlags((VkQueueFlagBits)queueFamilyProperties[familyIndex].queueFlags),
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
            Funcs = functions;
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

        public void WaitIdle() 
        {
            Vk.vkDeviceWaitIdle(m_ptr_device);
        }

        public Buffer CreateBuffer(in BufferCreateParams i_createParams)
        {
            return new Buffer(this, i_createParams);
        }

        public Texture CreateTexture(in TextureCreateParams i_createParams)
        {
            return new Texture(this, i_createParams);
        }

        public Swapchain CreateSwapchain(in SwapchainCreateParams i_createParams)
        {
            return new Swapchain(this, i_createParams);
        }

        public Sampler CreateSampler(in SamplerCreateParams i_createParams)
        {
            return new Sampler(this, i_createParams);
        }

        public ShaderLink CreateShaderLink(in ShaderLinkCreateParams i_createParams)
        {
            return new ShaderLink(this, i_createParams);
        }

        public Layout CreateLayout(in LayoutCreateParams i_createParams)
        {
            return new Layout(this, i_createParams);
        }
    }

    public unsafe partial class Device 
    {
        internal sealed class Functions
        {
            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkRenderingInfo*,
                void> PfnVkCmdBeginRenderingKhr
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                void> PfnVkCmdEndRenderingKhr
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkSemaphore_T*,
                ulong*,
                VkResult> PfnVkGetSemaphoreCounterValue
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkSemaphoreWaitInfo*,
                ulong,
                VkResult> PfnVkWaitSemaphoresKhr
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkRect2D*,
                void> PfnVkCmdSetScissorWithCountExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkViewport*,
                void> PfnVkCmdSetViewportWithCountExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                VkBuffer_T**,
                ulong*,
                ulong*,
                ulong*,
                void> PfnVkCmdBindVertexBuffers2Ext
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkPipelineBindPoint,
                VkPipelineLayout_T*,
                uint,
                uint,
                VkWriteDescriptorSet*,
                void> PfnVkCmdPushDescriptorSetKhr
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                uint,
                VkShaderCreateInfoEXT*,
                VkAllocationCallbacks*,
                VkShaderEXT_T**,
                VkResult> PfnVkCreateShadersExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkShaderEXT_T*,
                VkAllocationCallbacks*,
                void> PfnVkDestroyShaderExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkShaderStageFlagBits*,
                VkShaderEXT_T**,
                void> PfnVkCmdBindShadersExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkPolygonMode,
                void> PfnVkCmdSetPolygonModeExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkSampleCountFlagBits,
                void> PfnVkCmdSetRasterizationSamplesExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkSampleCountFlagBits,
                uint*,
                void> PfnVkCmdSetSampleMaskExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void> PfnVkCmdSetDepthClampEnableExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkLogicOp,
                void> PfnVkCmdSetLogicOpExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void> PfnVkCmdSetLogicOpEnableExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkVertexInputBindingDescription2EXT*,
                uint,
                VkVertexInputAttributeDescription2EXT*,
                void> PfnVkCmdSetVertexInputExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                uint*,
                void> PfnVkCmdSetColorBlendEnableExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                VkColorBlendEquationEXT*,
                void> PfnVkCmdSetColorBlendEquationExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                uint*,
                void> PfnVkCmdSetColorWriteMaskExt
            { get; set; } = null;

            public delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void> PfnVkCmdSetAlphaToCoverageEnableExt
            { get; set; } = null;
        }

        internal Functions Funcs { get; private init; } = new Functions();

        internal DescriptorAllocator DescriptorAllocator => m_descriptorAllocator;

        internal VkDevice_T* VkDevicePtr => m_ptr_device;

        internal VmaAllocator* VmaAllocatorPtr => m_ptr_allocator;

        private bool m_isDisposed = false;
        private readonly Adapter m_adapter;
        private readonly VkDevice_T* m_ptr_device = null;
        private readonly VmaAllocator* m_ptr_allocator = null;
        private readonly List<QueueFamily> m_queueFamilies = [];
        private readonly DescriptorAllocator m_descriptorAllocator;
    }
}
