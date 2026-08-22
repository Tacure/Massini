using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Structs.Level1.Internal;
using Massini.Core.Math;
using System.Collections;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class Swapchain : IResource, IDisposable
    {
        public ResId Id => m_id;

        public bool IsDisposed => m_isDisposed;

        public Device Device => m_device;

        public Swapchain(Device i_device, in SwapchainCreateParams i_createParams)
        {
            Device device = (Device)i_device;
            Surface surface = i_createParams.p_surface;

            VkSwapchainKHR_T* swapchain = CreateSwapchain(
                device,
                surface,
                i_createParams.p_presentMode,
                i_createParams.p_colorFormat,
                i_createParams.p_colorSpace,
                i_createParams.p_compositeAlphaMode,
                i_createParams.p_maxFramesInFlight,
                i_createParams.p_size.Width,
                i_createParams.p_size.Height,
                out uint maxFramesInFlight);

            if (swapchain == null)
            {
                throw new Exception("Failed to create swapchain.");
            }

            GetColorDepthTexturesAndViews(
                device,
                swapchain,
                i_createParams.p_colorFormat,
                i_createParams.p_enableDepthBuffer,
                maxFramesInFlight,
                i_createParams.p_size.Width,
                i_createParams.p_size.Height,
                out var colorTextures,
                out var colorTextureViews,
                out var depthTextures,
                out var depthTextureViews);

            CreateRenderSurfaceSynchronizationPrimitives(
                device,
                maxFramesInFlight,
                out var imageAvailableSemaphores,
                out var renderFinishedSemaphores);

            m_label = i_createParams.p_label;
            m_id = ResId.GetNextId();
            m_device = i_device;
            m_surface = surface;
            m_ptr_swapchain = swapchain;
            m_maxFramesInFlight = maxFramesInFlight;
            m_enableDepthBuffer = i_createParams.p_enableDepthBuffer;
            m_frameColorTextures = colorTextures;
            m_frameColorTextureViews = colorTextureViews;
            m_depthTextures = depthTextures;
            m_depthTextureViews = depthTextureViews;
            m_imageAvailableSemaphores = imageAvailableSemaphores;
            m_renderFinishedSemaphores = renderFinishedSemaphores;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                foreach (CommandList commandBuffer in m_commandLists)
                {
                    commandBuffer.Dispose();
                }
                DestroyRenderSurfaceSynchronizationPrimitives();
                DestroyRenderSurfaceSwapchain();
            }
        }

        public void BeginFrame(in SwapchainBeginFrameParams i_beginFrameParams, out CommandList o_commandList, out TextureView o_colorView, out TextureView? o_depthStencilView)
        {
            m_frameIndex++;
            if (m_frameIndex >= m_maxFramesInFlight)
            {
                m_frameIndex = 0;
            }

            m_waitCommandBuffers = i_beginFrameParams.p_waitCommandLists;

            Queue queue = i_beginFrameParams.p_presentQueue;
            if (m_currentPresentQueue == null || m_currentPresentQueue != queue)
            {
                if (m_currentPresentQueue != null)
                {
                    Vk.vkQueueWaitIdle(m_currentPresentQueue.VkQueuePtr);
                }

                foreach (var commandBuffer in m_commandLists)
                {
                    commandBuffer.Dispose();
                }
                m_commandLists.Clear();

                m_currentPresentQueue = queue;
                for (int i = 0; i < m_maxFramesInFlight; i++)
                {
                    CommandListCreateParams commandListCreateParams = new()
                    {
                        p_next = null,
                        p_label = "Swapchain",
                    };

                    var commandList = m_currentPresentQueue!.QueueFamily.CreateCommandList(in commandListCreateParams);
                    m_commandLists.Add(commandList);
                }
            }

            // Acquire the synchronization primitives.
            VkSemaphore_T* imageAvailableSemaphore = m_imageAvailableSemaphores[m_frameIndex];

            m_commandLists[m_frameIndex].WaitIdle();//

            // Acquire next image.
            uint imageIndex = 0;
            Vk.vkAcquireNextImageKHR(
                ((Device)m_device).VkDevicePtr,
                m_ptr_swapchain,
                ulong.MaxValue,
                imageAvailableSemaphore,
                null,
                &imageIndex);
            m_imageIndex = imageIndex;

            // Return frame resources.
            o_commandList = m_commandLists[m_frameIndex];
            o_colorView = m_frameColorTextureViews[(int)m_imageIndex];
            o_depthStencilView = null;
            if (m_enableDepthBuffer)
            {
                o_depthStencilView = m_depthTextureViews[(int)m_imageIndex];
            }
        }

        public void EndFrame()
        {
            VkSemaphore_T* imageAvailableSemaphore = m_imageAvailableSemaphores[m_frameIndex];
            VkSemaphore_T* renderFinishedSemaphore = m_renderFinishedSemaphores[m_frameIndex];
            CommandList commandList = m_commandLists[m_frameIndex];

            // Submit queue with image-available semaphore.
            CommandListSemaphoreSubmitParams vkCommandBufferSubmitParams = new()
            {
                p_next = null,
                p_waitBinarySemaphores = [imageAvailableSemaphore],
                p_signalBinarySemaphores = [renderFinishedSemaphore],
            };

            CommandListSubmitParams commandBufferSubmitParams = new()
            {
                p_next = vkCommandBufferSubmitParams,
                p_queue = m_currentPresentQueue!,
                p_waitCommandLists = m_waitCommandBuffers,
            };

            m_commandLists[m_frameIndex].Submit(in commandBufferSubmitParams);//

            // Present queue with render-finished semaphore
            uint imageIndex = m_imageIndex;
            VkSwapchainKHR_T* swapchainPtr = m_ptr_swapchain;
            VkPresentInfoKHR presentInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR,
                waitSemaphoreCount = 1,
                pWaitSemaphores = &renderFinishedSemaphore,
                swapchainCount = 1,
                pSwapchains = &swapchainPtr,
                pImageIndices = &imageIndex,
            };
            Vk.vkQueuePresentKHR(((Queue)m_currentPresentQueue!).VkQueuePtr, &presentInfo);
        }
    }

    public unsafe partial class Swapchain 
    {
        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Device m_device;
        private readonly Surface m_surface;
        private readonly VkSwapchainKHR_T* m_ptr_swapchain = null;
        private readonly List<Texture> m_frameColorTextures = [];
        private readonly List<TextureView> m_frameColorTextureViews = [];
        private readonly VkSemaphore_T*[] m_imageAvailableSemaphores = [];
        private readonly VkSemaphore_T*[] m_renderFinishedSemaphores = [];
        private readonly bool m_enableDepthBuffer = false;
        private readonly List<Texture> m_depthTextures = [];
        private readonly List<TextureView> m_depthTextureViews = [];
        private readonly uint m_maxFramesInFlight = 0;
        private int m_frameIndex = -1;
        private uint m_imageIndex = 0;
        private readonly List<CommandList> m_commandLists = [];
        private Queue? m_currentPresentQueue = null;

        private CommandList[] m_waitCommandBuffers = [];

        private static VkSwapchainKHR_T* CreateSwapchain(
            Device i_device,
            Surface i_surface,
            PresentModeFlags i_presentMode,
            TextureFormat i_colorFormat,
            ColorSpace i_colorSpace,
            CompositeAlphaModeFlags i_compositeAlphaMode,
            uint i_maxFramesInFlight,
            uint i_width,
            uint i_height,
            out uint o_maxFramesInFlight)
        {
            Adapter adapter = i_device.Adapter;

            uint presentModeCount = 0;
            Vk.vkGetPhysicalDeviceSurfacePresentModesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &presentModeCount, null);
            VkPresentModeKHR[] presentModes = new VkPresentModeKHR[presentModeCount];
            fixed (VkPresentModeKHR* presentModesPtr = presentModes)
            {
                Vk.vkGetPhysicalDeviceSurfacePresentModesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &presentModeCount, presentModesPtr);
            }

            VkPresentModeKHR selectedPresentMode = VkUtils.PresentModeFlagsToVkPresentModeKhr(i_presentMode);
            if (!presentModes.Contains(selectedPresentMode))
            {
                selectedPresentMode = VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR;
            }

            VkFormat selectedFormat = VkUtils.TextureFormatToVkFormat(i_colorFormat);
            VkColorSpaceKHR selectedColorSpace = VkUtils.ColorSpaceToVkColorSpaceKhr(i_colorSpace);

            VkSurfaceCapabilitiesKHR surfaceCapabilitiesKhr = new();
            Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &surfaceCapabilitiesKhr);

            o_maxFramesInFlight = Math<uint>.Min(i_maxFramesInFlight, surfaceCapabilitiesKhr.maxImageCount);
            o_maxFramesInFlight = Math<uint>.Max(o_maxFramesInFlight, surfaceCapabilitiesKhr.minImageCount);

            uint queueFamilyIndex = 0;
            VkSwapchainCreateInfoKHR swapchainCreateInfoKhr = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR,
                pNext = null,
                surface = i_surface.VkSurfacePtr,
                minImageCount = o_maxFramesInFlight,
                imageFormat = selectedFormat,
                imageColorSpace = selectedColorSpace,
                imageExtent = new VkExtent2D { width = i_width, height = i_height },
                preTransform = VkSurfaceTransformFlagBitsKHR.VK_SURFACE_TRANSFORM_IDENTITY_BIT_KHR,
                compositeAlpha = VkUtils.CompositeAlphaModeFlagsToVkCompositeAlphaFlagBitsKhr(i_compositeAlphaMode),
                presentMode = selectedPresentMode,
                imageUsage = (uint)VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT,
                imageArrayLayers = 1,
                imageSharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                queueFamilyIndexCount = 1,
                pQueueFamilyIndices = &queueFamilyIndex,
                clipped = 1,
                oldSwapchain = null,
            };

            VkSwapchainKHR_T* swapchain = null;
            VkResult result = Vk.vkCreateSwapchainKHR(((Device)i_device).VkDevicePtr, &swapchainCreateInfoKhr, null, &swapchain);
            if (result != VkResult.VK_SUCCESS)
            {
                return null;
            }

            return swapchain;
        }

        private static void GetColorDepthTexturesAndViews(
            Device i_device,
            VkSwapchainKHR_T* i_ptr_swapchain,
            TextureFormat i_colorFormat,
            bool i_enableDepth,
            uint i_maxFramesInFlight,
            uint i_width,
            uint i_height,
            out List<Texture> o_colorTextures,
            out List<TextureView> o_colorTextureViews,
            out List<Texture> o_depthTextures,
            out List<TextureView> o_depthTextureViews)
        {
            VkImage_T*[] swapchainImages = new VkImage_T*[i_maxFramesInFlight];
            fixed (VkImage_T** swapchainImagesPtr = swapchainImages)
            {
                uint frameCount = i_maxFramesInFlight;
                Vk.vkGetSwapchainImagesKHR(((Device)i_device).VkDevicePtr, i_ptr_swapchain, &frameCount, swapchainImagesPtr);
            }

            o_colorTextures = [];
            o_colorTextureViews = [];
            o_depthTextures = [];
            o_depthTextureViews = [];

            for (int i = 0; i < swapchainImages.Length; i++)
            {
                Texture colorTexture = Texture.CreateWrapper(
                    i_device!,
                    swapchainImages[i],
                    new VkExtent3D()
                    {
                        width = i_width,
                        height = i_height,
                        depth = 1,
                    },
                    VkUtils.TextureFormatToVkFormat(i_colorFormat),
                    VkImageType.VK_IMAGE_TYPE_2D,
                    1,
                    VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT);

                o_colorTextures.Add(colorTexture);

                TextureViewCreateParams colorTextureViewCreateParams = new()
                {
                    p_next = null,
                    p_label = "Color Texture View",
                    p_aspect = TextureAspectFlags.Color,
                    p_baseMipLevel = 0,
                    p_format = i_colorFormat,
                    p_mipLevelCount = 1,
                    p_sampleCount = SampleCount.SampleCount1,
                    p_type = TextureViewType.View2D,
                    p_usage = TextureUsageFlags.ColorAttachment,
                    p_baseArrayLayer = 0,
                    p_layerCount = 1,
                };

                TextureView colorTextureView = colorTexture.CreateView(in colorTextureViewCreateParams);

                o_colorTextureViews.Add(colorTextureView!);
            }

            // Create depth images.
            if (i_enableDepth)
            {
                TextureCreateParams depthTextureCreateParams = new()
                {
                    p_next = null,
                    p_label = "Depth Buffer",
                    p_format = TextureFormat.Depth32FloatStencil8,
                    p_sampleCount = SampleCount.SampleCount1,
                    p_mipLevelCount = 1,
                    p_size = new()
                    {
                        Width = i_width,
                        Height = i_height,
                        Depth = 1,
                    },
                    p_type = TextureType.Texture2D,
                    p_usage = TextureUsageFlags.DepthStencilAttachment | TextureUsageFlags.Sampled,
                    p_arrayLayers = 1,
                };

                TextureViewCreateParams depthTextureViewCreateParams = new()
                {
                    p_next = null,
                    p_label = "Depth Buffer View",
                    p_format = TextureFormat.Depth32FloatStencil8,
                    p_sampleCount = SampleCount.SampleCount1,
                    p_mipLevelCount = 1,
                    p_aspect = TextureAspectFlags.Depth | TextureAspectFlags.Stencil,
                    p_baseMipLevel = 0,
                    p_type = TextureViewType.View2D,
                    p_usage = TextureUsageFlags.DepthStencilAttachment | TextureUsageFlags.Sampled,
                    p_baseArrayLayer = 0,
                    p_layerCount = 1,
                };

                for (int i = 0; i < i_maxFramesInFlight; i++)
                {
                    Texture depthTexture = i_device.CreateTexture(in depthTextureCreateParams);

                    o_depthTextures.Add(depthTexture);

                    TextureView depthTextureView = depthTexture.CreateView(in depthTextureViewCreateParams);

                    o_depthTextureViews.Add(depthTextureView);
                }
            }
        }

        private static void CreateRenderSurfaceSynchronizationPrimitives(
            Device i_device,
            uint i_maxFramesInFlight,
            out VkSemaphore_T*[] o_imageAvailableSemaphores,
            out VkSemaphore_T*[] o_renderFinishedSemaphores)
        {
            o_imageAvailableSemaphores = new VkSemaphore_T*[i_maxFramesInFlight];
            o_renderFinishedSemaphores = new VkSemaphore_T*[i_maxFramesInFlight];

            VkSemaphoreCreateInfo semaphoreCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO,
                pNext = null,
                flags = 0,
            };

            for (int i = 0; i < i_maxFramesInFlight; i++)
            {
                VkSemaphore_T* imageAvailableSemaphore = null;
                Vk.vkCreateSemaphore(i_device.VkDevicePtr, &semaphoreCreateInfo, null, &imageAvailableSemaphore);
                o_imageAvailableSemaphores[i] = imageAvailableSemaphore;

                VkSemaphore_T* imageRenderedSemaphore = null;
                Vk.vkCreateSemaphore(i_device.VkDevicePtr, &semaphoreCreateInfo, null, &imageRenderedSemaphore);
                o_renderFinishedSemaphores[i] = imageRenderedSemaphore;
            }
        }

        private void DestroyRenderSurfaceSwapchain()
        {
            foreach (var depthTextureView in m_depthTextureViews)
            {
                depthTextureView.Dispose();
            }
            m_depthTextureViews.Clear();
            foreach (var depthTexture in m_depthTextures)
            {
                depthTexture.Dispose();
            }
            m_depthTextures.Clear();

            for (int i = 0; i < m_frameColorTextureViews.Count; i++)
            {
                m_frameColorTextureViews[i].Dispose();
            }

            Vk.vkDestroySwapchainKHR(((Device)m_device).VkDevicePtr, m_ptr_swapchain, null);
        }

        private void DestroyRenderSurfaceSynchronizationPrimitives()
        {
            foreach (VkSemaphore_T* semaphore in m_imageAvailableSemaphores)
            {
                Vk.vkDestroySemaphore(((Device)m_device).VkDevicePtr, semaphore, null);
            }

            foreach (VkSemaphore_T* semaphore in m_renderFinishedSemaphores)
            {
                Vk.vkDestroySemaphore(((Device)m_device).VkDevicePtr, semaphore, null);
            }
        }
    }
}
