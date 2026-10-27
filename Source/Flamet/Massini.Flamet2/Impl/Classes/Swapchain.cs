
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Math;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using Massini.Flamet2.Impl.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Swapchain : ISwapchain1
    {
        public Swapchain(Device i_device, in SwapchainCreateParams i_createParams)
        {
            Surface surface = (Surface)i_createParams.p_surface;
            
            VkSwapchainKHR_T* swapchain = CreateSwapchain(
                i_device,
                surface,
                i_createParams.p_presentMode,
                i_createParams.p_colorFormat,
                i_createParams.p_colorSpace,
                i_createParams.p_compositeAlphaMode,
                i_createParams.p_frameCount,
                i_createParams.p_size.Width,
                i_createParams.p_size.Height,
                out uint clampedFrameCount);

            if (swapchain == null)
            {
                throw new Exception("Failed to create swapchain.");
            }

            GetColorDepthTexturesAndViews(
                i_device,
                swapchain,
                i_createParams.p_colorFormat,
                clampedFrameCount,
                i_createParams.p_size.Width,
                i_createParams.p_size.Height,
                out var colorTextures,
                out var colorTextureViews);

            CreateRenderSurfaceSynchronizationPrimitives(
                i_device,
                clampedFrameCount,
                out var imageAvailableSemaphores,
                out var renderFinishedSemaphores);

            m_ptr_swapchain = swapchain;
            m_frameColorTextures = colorTextures;
            m_frameColorTextureViews = colorTextureViews;
            m_imageAvailableSemaphores = imageAvailableSemaphores;
            m_renderFinishedSemaphores = renderFinishedSemaphores;

            m_swapchainInfo = new SwapchainInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
                Surface = i_createParams.p_surface,
                Extent = i_createParams.p_size,
                FrameCount = clampedFrameCount,
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)GetInfo().Device;
                
                m_isDisposed = true;
                foreach (CommandList commandBuffer in m_commandLists)
                {
                    commandBuffer.Dispose();
                }
                DestroyRenderSurfaceSynchronizationPrimitives();
                DestroyRenderSurfaceSwapchain();
            }
        }

        public SwapchainInfo GetInfo()
        {
            return m_swapchainInfo;
        }
        
        public void BeginFrame(
            in SwapchainBeginFrameParams i_beginFrameParams, 
            out ICommandList1 o_commandList, 
            out ITextureView1 o_colorView)
        {
            Device device = (Device)GetInfo().Device;
            
            m_frameIndex++;
            if (m_frameIndex >= GetInfo().FrameCount)
            {
                m_frameIndex = 0;
            }

            m_waitCommandLists = i_beginFrameParams.p_waitCommandLists;

            Lane lane = (Lane)i_beginFrameParams.p_presentLane;
            if (m_currentPresentLane == null || m_currentPresentLane != lane)
            {
                m_currentPresentLane?.WaitIdle();

                foreach (var commandBuffer in m_commandLists)
                {
                    commandBuffer.Dispose();
                }
                m_commandLists.Clear();

                m_currentPresentLane = lane;
                for (int i = 0; i < GetInfo().FrameCount; i++)
                {
                    var commandList = m_currentPresentLane.CreateCommandList();
                    m_commandLists.Add(commandList);
                }
            }

            // Acquire the synchronization primitives.
            VkSemaphore_T* imageAvailableSemaphore = m_imageAvailableSemaphores[m_frameIndex];

            m_commandLists[m_frameIndex].WaitIdle(TimeSpan.MaxValue);//

            // Acquire next image.
            uint imageIndex = 0;
            Vk.vkAcquireNextImageKHR(
                (device).VkDevicePtr,
                m_ptr_swapchain,
                ulong.MaxValue,
                imageAvailableSemaphore,
                null,
                &imageIndex);
            m_imageIndex = imageIndex;

            // Return frame resources.
            o_commandList = m_commandLists[m_frameIndex];
            o_colorView = m_frameColorTextureViews[(int)m_imageIndex];
        }

        public void EndFrame()
        {
            VkSemaphore_T* imageAvailableSemaphore = m_imageAvailableSemaphores[m_frameIndex];
            VkSemaphore_T* renderFinishedSemaphore = m_renderFinishedSemaphores[m_frameIndex];

            // Submit queue with image-available semaphore.
            CommandListSemaphoreSubmitParams semaphoreSubmitParams = new()
            {
                p_next = null,
                p_waitBinarySemaphores = [imageAvailableSemaphore],
                p_signalBinarySemaphores = [renderFinishedSemaphore],
            };

            CommandListSubmitParams submitParams = new()
            {
                p_next = semaphoreSubmitParams,
                p_lane = m_currentPresentLane!,
                p_waitCommandLists = m_waitCommandLists,
            };

            m_commandLists[m_frameIndex].Submit(in submitParams);//

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
            Vk.vkQueuePresentKHR(m_currentPresentLane!.GetNextVkQueuePtr(), &presentInfo);
        }

        private bool m_isDisposed = false;
        private readonly SwapchainInfo m_swapchainInfo;
        private readonly VkSwapchainKHR_T* m_ptr_swapchain;
        private readonly List<Texture> m_frameColorTextures = [];
        private readonly List<TextureView> m_frameColorTextureViews = [];
        private readonly VkSemaphore_T*[] m_imageAvailableSemaphores = [];
        private readonly VkSemaphore_T*[] m_renderFinishedSemaphores = [];
        private readonly bool m_enableDepthBuffer = false;
        private readonly List<Texture> m_depthTextures = [];
        private readonly List<TextureView> m_depthTextureViews = [];
        private int m_frameIndex = -1;
        private uint m_imageIndex = 0;
        private readonly List<ICommandList1> m_commandLists = [];
        private Lane? m_currentPresentLane = null;
        private (ICommandList1 CmdList, ulong SignalValue)[] m_waitCommandLists = [];
        
        private static VkSwapchainKHR_T* CreateSwapchain(
            Device i_device,
            Surface i_surface,
            PresentMode i_presentMode,
            TextureFormat i_colorFormat,
            ColorSpace i_colorSpace,
            CompositeAlphaModeFlags i_compositeAlphaMode,
            uint i_maxFramesInFlight,
            uint i_width,
            uint i_height,
            out uint o_clampedFrameCount)
        {
            Adapter adapter = i_device.Adapter;

            uint presentModeCount = 0;
            Vk.vkGetPhysicalDeviceSurfacePresentModesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &presentModeCount, null);
            VkPresentModeKHR[] presentModes = new VkPresentModeKHR[presentModeCount];
            fixed (VkPresentModeKHR* presentModesPtr = presentModes)
            {
                Vk.vkGetPhysicalDeviceSurfacePresentModesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &presentModeCount, presentModesPtr);
            }

            VkPresentModeKHR selectedPresentMode = IntSharedCvs.PresentModeToVkPresentModeKhr(i_presentMode);
            if (!presentModes.Contains(selectedPresentMode))
            {
                selectedPresentMode = VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR;
            }

            VkFormat selectedFormat = IntSharedCvs.TextureFormatToVkFormat(i_colorFormat);
            VkColorSpaceKHR selectedColorSpace = IntSharedCvs.ColorSpaceToVkColorSpaceKhr(i_colorSpace);

            VkSurfaceCapabilitiesKHR surfaceCapabilitiesKhr = new();
            Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(adapter.VkPhysicalDevicePtr, i_surface.VkSurfacePtr, &surfaceCapabilitiesKhr);

            o_clampedFrameCount = Math<uint>.Min(i_maxFramesInFlight, surfaceCapabilitiesKhr.maxImageCount);
            o_clampedFrameCount = Math<uint>.Max(o_clampedFrameCount, surfaceCapabilitiesKhr.minImageCount);

            // TODO: Change queue mode to concurrent.
            
            uint queueFamilyIndex = 0;
            VkSwapchainCreateInfoKHR swapchainCreateInfoKhr = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR,
                pNext = null,
                surface = i_surface.VkSurfacePtr,
                minImageCount = o_clampedFrameCount,
                imageFormat = selectedFormat,
                imageColorSpace = selectedColorSpace,
                imageExtent = new VkExtent2D { width = i_width, height = i_height },
                preTransform = VkSurfaceTransformFlagBitsKHR.VK_SURFACE_TRANSFORM_IDENTITY_BIT_KHR,
                compositeAlpha = IntSharedCvs.CompositeAlphaModeFlagsToVkCompositeAlphaFlagBitsKhr(i_compositeAlphaMode),
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
            uint i_frameCount,
            uint i_width,
            uint i_height,
            out List<Texture> o_colorTextures,
            out List<TextureView> o_colorTextureViews)
        {
            VkImage_T*[] swapchainImages = new VkImage_T*[i_frameCount];
            fixed (VkImage_T** swapchainImagesPtr = swapchainImages)
            {
                uint frameCount = i_frameCount;
                Vk.vkGetSwapchainImagesKHR(((Device)i_device).VkDevicePtr, i_ptr_swapchain, &frameCount, swapchainImagesPtr);
            }

            o_colorTextures = [];
            o_colorTextureViews = [];

            for (int i = 0; i < swapchainImages.Length; i++)
            {
                Texture colorTexture = Texture.CreateWrapper(
                    i_device!,
                    swapchainImages[i],
                    new VkExtent3D()
                    {
                        width = i_width,
                        height = i_height,
                        depth = ONE,
                    },
                    IntSharedCvs.TextureFormatToVkFormat(i_colorFormat),
                    VkImageType.VK_IMAGE_TYPE_2D,
                    uint.MaxValue,
                    ONE,
                    VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                    true);

                o_colorTextures.Add(colorTexture);

                TextureViewCreateParams colorTextureViewCreateParams = new()
                {
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

                TextureView colorTextureView = (TextureView)colorTexture.CreateTextureView(in colorTextureViewCreateParams);

                o_colorTextureViews.Add(colorTextureView!);
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
            Device device = (Device)GetInfo().Device;
            
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

            Vk.vkDestroySwapchainKHR(device.VkDevicePtr, m_ptr_swapchain, null);
        }

        private void DestroyRenderSurfaceSynchronizationPrimitives()
        {
            Device device = (Device)GetInfo().Device;
            
            foreach (VkSemaphore_T* semaphore in m_imageAvailableSemaphores)
            {
                Vk.vkDestroySemaphore(device.VkDevicePtr, semaphore, null);
            }

            foreach (VkSemaphore_T* semaphore in m_renderFinishedSemaphores)
            {
                Vk.vkDestroySemaphore(device.VkDevicePtr, semaphore, null);
            }
        }
    }   
}