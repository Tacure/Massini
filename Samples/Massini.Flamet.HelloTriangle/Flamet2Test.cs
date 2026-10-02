
using Massini.Core.Functional;
using Massini.Core.Interop;
using Massini.Core.Math;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;
using static Massini.Core.Functional.None;

namespace Massini.Flamet.HelloTriangle
{
    public static unsafe class Flamet2Test
    {
        public static void Run()
        {   
            SDL3.SDL.Init(SDL3.SDL.InitFlags.Events | SDL3.SDL.InitFlags.Video);
            nint window = SDL3.SDL.CreateWindow("Test", (int)m_viewport.Width, (int)m_viewport.Height, SDL3.SDL.WindowFlags.Resizable);

            Initialize(window);
            
            bool quit = false;
            double lastTime = 0.0;
            while (!quit)
            {
                while (SDL3.SDL.PollEvent(out var @event))
                {
                    if (@event.Type == (uint)SDL3.SDL.EventType.WindowCloseRequested)
                    {
                        quit = true;
                    }
                    else if (@event.Type == (uint)SDL3.SDL.EventType.WindowPixelSizeChanged)
                    {
                        // Get new window size.
                        if (!SDL3.SDL.GetWindowSize(window, out var width, out var height))
                        {
                            throw new Exception("Failed to get window size.");
                        }
                        
                        // Make sure the viewport size is at least 1.
                        width = Math<int>.Max(width, 1);
                        height = Math<int>.Max(height, 1);
                    }
                }

                double currentTime = SDL3.SDL.GetTicks() / 1000.0;

                Update(TimeSpan.FromSeconds(currentTime - lastTime));

                lastTime = currentTime;
            }

            Quit();
            
            SDL3.SDL.DestroyWindow(window);
            SDL3.SDL.Quit();
        }

        private static void Initialize(nint i_window)
        {
            m_device = FlametFactory.Initialize(new DeviceCreateParams()
            {
                p_enableDebugMode = true,
                p_enableSwapchain = true,
                p_logCallback = (level, message) => Console.WriteLine($"{level}: {message}"),
            }, new AdapterSelector());

            m_lane = m_device.GetLanes().First(lane =>
            {
                LaneInfo info = lane.GetInfo();
                return info.Usage.HasFlag(LaneUsageFlags.Graphics) &&
                       info.Usage.HasFlag(LaneUsageFlags.Compute) &&
                       info.Usage.HasFlag(LaneUsageFlags.Transfer);
            });

            ITexture1 texture = m_lane.CreateTexture(new TextureCreateParams
            {
                p_format = TextureFormat.BGRA8UnormSrgb,
                p_arrayLayers = 1,
                p_mipLevelCount = 1,
                p_size = new Vec3<uint>(256U, 256U, 1U),
                p_type = TextureType.Texture2D,
                p_usage = TextureUsageFlags.Sampled | TextureUsageFlags.TransferDst,
                p_sampleCount = SampleCount.SampleCount1,
            });
            texture.SetLabel("Texture");

            ITextureView1 textureView = texture.CreateTextureView(new TextureViewCreateParams()
            {
                p_type = TextureViewType.View2D,
                p_aspect = TextureAspectFlags.Color,
                p_baseArrayLayer = 0,
                p_format = TextureFormat.BGRA8UnormSrgb,
                p_baseMipLevel = 0,
                p_layerCount = 1,
                p_mipLevelCount = 1,
                p_usage = TextureUsageFlags.Sampled,
                p_sampleCount = SampleCount.SampleCount1,
            });
            textureView.SetLabel("View");
            
            textureView.Dispose();
            texture.Dispose();

            IBuffer1 buffer = m_lane.CreateBuffer(new BufferCreateParams()
            {
                p_size = MemorySize.FromBytes(32),
                p_type = BufferType.Storage,
                p_usage = BufferUsageFlags.HostVisible | BufferUsageFlags.DeviceAddress,
            });
            buffer.SetLabel("Buffer");
            
            buffer.Dispose();

            ISampler1 sampler = m_lane.CreateSampler(new SamplerCreateParams()
            {
                p_addressModeU = SamplerAdressMode.Repeat,
                p_addressModeV = SamplerAdressMode.Repeat,
                p_addressModeW = SamplerAdressMode.Repeat,
                p_minFilter = FilterMode.Linear,
                p_magFilter = FilterMode.Linear,
                p_mipmapFilter = FilterMode.Linear,
                p_compareOperation = CompareOp.Never,
                p_enableAnisotropy = true,
                p_enableUnnormalizedCoordinates = false,
                p_lodMinClamp = 0.0f,
                p_lodMaxClamp = 1.0f,
                p_maxAnisotropy = 1,
                p_mipLodBias = 0.0f,
            });
            sampler.SetLabel("Sampler");
            
            sampler.Dispose();

            ILayout1 layout = m_lane.CreateLayout(new LayoutCreateParams()
            {
                p_sets = [],
                p_pushConstant = null,
            });
            layout.SetLabel("Layout");
            
            layout.Dispose();
        }
        
        private static void Update(TimeSpan i_deltaTime)
        {
            
        }

        private static void Quit()
        {
            m_device?.Dispose();
        }
        
        private static Vec2<uint> m_viewport = new(800, 600);

        private static IDevice1? m_device;
        private static ILane1? m_lane;
    }   
    
    file class AdapterSelector : IAdapterSelector
    {
        public IAdapter1? Select(IReadOnlyList<IAdapter1> i_adapters)
        {
            for (int i = 0; i < i_adapters.Count; i++)
            {
                AdapterInfo info = i_adapters[i].GetInfo();
                if (info.AdapterType == AdapterType.Discrete &&
                    info.FeatureLevel.HasFlag(FeatureLevel.Level1))
                {
                    Console.WriteLine($"Selected Adapter {info.Name} of type {info.AdapterType} with feature level {info.FeatureLevel}");
                    
                    return i_adapters[i];
                }
            }

            return null;
        }
    }
}