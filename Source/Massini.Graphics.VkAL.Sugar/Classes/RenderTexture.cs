using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Sugar.Extensions;
using Massini.Graphics.VkAL.Sugar.Structs;
using System.Diagnostics.CodeAnalysis;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public class RenderTexture : IResource, IDisposable
    {
        /// <inheritdoc/>
        public ResId Id => m_id;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        /// <inheritdoc/>
        public Device Device => m_device;

        public RenderTexture(Device i_device, in RenderTextureCreateParams i_createParams) 
        {
            m_frames = i_createParams.p_frames;

            for (int i = 0; i < i_createParams.p_frames; i++)
            {
                m_colorTextures.Add([]);
                m_colorViews.Add([]);

                for (int j = 0; j < i_createParams.p_colorFormats.Length; j++)
                {
                    Texture2D texture = i_device.CreateTexture2D(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                        p_format = i_createParams.p_colorFormats[j],
                        p_mipLevelCount = 1,
                        p_sampleCount = Enums.SampleCount.SampleCount1,
                        p_size = new(i_createParams.p_size.Width, i_createParams.p_size.Height, 1),
                        p_usage = Enums.TextureUsageFlags.ColorAttachment | Enums.TextureUsageFlags.Sampled | Enums.TextureUsageFlags.TransferSrc,
                        p_arrayLayers = 1,
                    });

                    m_colorTextures[i].Add(texture);

                    TextureView2D view = texture.CreateView2D(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                        p_aspect = Enums.TextureAspectFlags.Color,
                        p_baseMipLevel = 0,
                        p_format = i_createParams.p_colorFormats[j],
                        p_mipLevelCount = 1,
                        p_sampleCount = Enums.SampleCount.SampleCount1,
                        p_usage = Enums.TextureUsageFlags.ColorAttachment | Enums.TextureUsageFlags.Sampled,
                        p_baseArrayLayer = 0,
                        p_layerCount = 1,
                    });

                    m_colorViews[i].Add(view);
                }
            }

            if (i_createParams.p_enableDepthBuffer) 
            {
                m_enableDepthBuffer = true;

                for (int i = 0; i < i_createParams.p_frames; i++) 
                {
                    Texture2D texture = i_device.CreateTexture2D(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                        p_format = i_createParams.p_depthFormat,
                        p_mipLevelCount = 1,
                        p_sampleCount = Enums.SampleCount.SampleCount1,
                        p_size = new(i_createParams.p_size.Width, i_createParams.p_size.Height, 1),
                        p_usage = Enums.TextureUsageFlags.DepthStencilAttachment | Enums.TextureUsageFlags.Sampled | Enums.TextureUsageFlags.TransferSrc,
                        p_arrayLayers = 1,
                    }); 

                    m_depthStencilTextures.Add(texture);

                    TextureView2D view = texture.CreateView2D(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                        p_aspect = Enums.TextureAspectFlags.Depth | Enums.TextureAspectFlags.Stencil,
                        p_baseMipLevel = 0,
                        p_format = i_createParams.p_depthFormat,
                        p_mipLevelCount = 1,
                        p_sampleCount = Enums.SampleCount.SampleCount1,
                        p_usage = Enums.TextureUsageFlags.DepthStencilAttachment | Enums.TextureUsageFlags.Sampled,
                    p_baseArrayLayer = 0,
                    p_layerCount = 1,
                    });

                    m_depthStencilAttachmentViews.Add(view);

                    TextureView2D depthView = texture.CreateView2D(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                        p_aspect = Enums.TextureAspectFlags.Depth,
                        p_baseMipLevel = 0,
                        p_format = i_createParams.p_depthFormat,
                        p_mipLevelCount = 1,
                        p_sampleCount = Enums.SampleCount.SampleCount1,
                        p_usage = Enums.TextureUsageFlags.Sampled,
                        p_baseArrayLayer = 0,
                        p_layerCount = 1,
                    });

                    m_depthStencilDepthViews.Add(depthView);
                }
            }

            m_id = ResId.GetNextId();
            m_device = i_device;
            m_label = i_createParams.p_label;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                foreach (var frameTextures in m_colorTextures)
                {
                    foreach (var texture in frameTextures)
                    {
                        texture.Dispose();
                    }
                }
                foreach (var frameViews in m_colorViews)
                {
                    foreach (var view in frameViews)
                    {
                        view.Dispose();
                    }
                }
                foreach (var texture in m_depthStencilTextures)
                {
                    texture.Dispose();
                }
                foreach (var view in m_depthStencilAttachmentViews)
                {
                    view.Dispose();
                }
                foreach (var view in m_depthStencilDepthViews) 
                {
                    view.Dispose();
                }
                foreach (var commandList in m_commandLists)
                {
                    commandList.Dispose();
                }
            }
        }

        public void BeginFrame(in RenderTextureBeginFrameParams i_beginFrameParams, out CommandList o_commandList, out IReadOnlyList<TextureView> o_colorViews, out TextureView? o_depthStencilView) 
        {
            if (i_beginFrameParams.p_presentQueue != m_currentPresentQueue) 
            {
                if (m_currentPresentQueue != null) 
                {
                    m_currentPresentQueue.WaitIdle();
                }

                m_currentPresentQueue = i_beginFrameParams.p_presentQueue;

                for (int i = 0; i < m_commandLists.Count; i++) 
                {
                    m_commandLists[i].Dispose();
                }
                m_commandLists.Clear();

                for (int i = 0; i < m_frames; i++)
                {
                    m_commandLists.Add(m_currentPresentQueue.QueueFamily.CreateCommandList(new()
                    {
                        p_next = null,
                        p_label = $"{nameof(RenderTexture)} - {i} - {m_label}",
                    }));
                }
            }

            m_waitCommandLists = i_beginFrameParams.p_waitCommandLists;

            m_frameIndex++;
            if (m_frameIndex >= m_frames)
            {
                m_frameIndex = 0;
            }

            m_commandLists[m_frameIndex].WaitIdle();

            o_commandList = m_commandLists[m_frameIndex];
            o_colorViews = m_colorViews[m_frameIndex];
            o_depthStencilView = m_enableDepthBuffer ? m_depthStencilAttachmentViews[m_frameIndex] : null;
        }

        public void EndFrame()
        {
            CommandListSubmitParams commandBufferSubmitParams = new()
            {
                p_next = null,
                p_queue = m_currentPresentQueue!,
                p_waitCommandLists = m_waitCommandLists,
            };

            m_commandLists[m_frameIndex].Submit(in commandBufferSubmitParams);
        }

        /// <summary>
        /// Returns a depth only view of the current frame for sampling.
        /// </summary>
        /// <param name="o_depthView"></param>
        /// <returns></returns>
        public bool TryGetDepthView([NotNullWhen(true)] out TextureView2D? o_depthView) 
        {
            o_depthView = m_enableDepthBuffer ? m_depthStencilDepthViews[m_frameIndex] : null;
            return m_enableDepthBuffer;
        }

        private bool m_isDisposed = false;
        private int m_frameIndex = -1;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Device m_device;
        private readonly uint m_frames = 0;
        private readonly bool m_enableDepthBuffer = false;
        private readonly List<List<Texture2D>> m_colorTextures = [];
        private readonly List<List<TextureView2D>> m_colorViews = [];
        private readonly List<Texture2D> m_depthStencilTextures = [];
        private readonly List<TextureView2D> m_depthStencilAttachmentViews = [];
        private readonly List<TextureView2D> m_depthStencilDepthViews = [];

        private Queue? m_currentPresentQueue = null;
        private readonly List<CommandList> m_commandLists = [];
        private CommandList[] m_waitCommandLists = [];
    }
}
