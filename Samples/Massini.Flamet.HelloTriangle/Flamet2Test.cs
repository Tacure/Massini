
using Massini.Core.Interop.Linux;
using Massini.Core.Math;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

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

            m_setAllocator = m_device.CreateSetAllocator(new SetAllocatorCreateParams()
            {
                p_blockSize = 256U,
            });
            
            uint windowProps = SDL3.SDL.GetWindowProperties(i_window);
            XDisplay* displayPtr = (XDisplay*)SDL3.SDL.GetPointerProperty(windowProps, SDL3.SDL.Props.WindowX11DisplayPointer, 0);
            nint windowNumber = (nint)SDL3.SDL.GetNumberProperty(windowProps, SDL3.SDL.Props.WindowX11WindowNumber, 0L);

            m_surface = m_device.CreateSurface(new SurfaceCreateParams()
            {
                p_next = new SurfaceXlibCreateParams()
                {
                    p_next = null,
                    p_ptr_display = displayPtr,
                    p_window = windowNumber,
                },
            });

            m_swapchain = m_device.CreateSwapchain(new SwapchainCreateParams()
            {
                p_next = null,
                p_colorFormat = TextureFormat.BGRA8UnormSrgb,
                p_colorSpace = ColorSpace.SrgbNonLinear,
                p_compositeAlphaMode = CompositeAlphaModeFlags.Opaque,
                p_frameCount = 3,
                p_size = new Vec2<uint>(800, 600),
                p_surface = m_surface,
                p_presentMode = PresentMode.Fifo,
            });
        }
        
        private static void Update(TimeSpan i_deltaTime)
        {
            m_swapchain!.BeginFrame(new SwapchainBeginFrameParams()
            {
                p_presentLane = m_lane!,
                p_waitCommandLists = [],
            }, out ICommandList1 commandList, out ITextureView1 colorView);
            
            commandList.Open();
            
            commandList.CmdBeginRenderPass(new RenderPassBeginParams()
            {
                p_colorAttachments = 
                [
                    new RenderPassColorAttachment()
                    {
                        p_clearColor = new Vec4<float>(0.0f, 0.0f, 0.0f, 1.0f),
                        p_depthSlice = 0,
                        p_loadOp = LoadOp.Clear,
                        p_storeOp = StoreOp.Store,
                        p_textureView = colorView,
                    }
                ],
                p_depthStencilAttachment = null,
            });
            
            commandList.CmdEndRenderPass();
            
            commandList.Close();
            
            m_swapchain.EndFrame();
        }   

        private static void Quit()
        {
            m_swapchain?.Dispose();
            m_surface?.Dispose();
            m_setAllocator?.Dispose();
            m_device?.Dispose();
        }
        
        private static Vec2<uint> m_viewport = new(800, 600);

        private static IDevice1? m_device;
        private static ILane1? m_lane;
        private static ISurface1? m_surface;
        private static ISwapchain1? m_swapchain;
        private static ISetAllocator1? m_setAllocator;
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