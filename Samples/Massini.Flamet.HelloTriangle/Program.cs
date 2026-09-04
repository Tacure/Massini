using System.Runtime.InteropServices;
using Massini.Flamet.Classes;
using Massini.Flamet.Classes.Encoders;
using Massini.Flamet.Enums;
using Massini.Flamet.Structs;
using Massini.Flamet.Structs.Level1;
using Massini.Flamet.Structs.Level1.Commands;
using Massini.Flamet.Sugar.Classes;
using Massini.Flamet.Sugar.Extensions;
using Massini.Flamet.Sugar.Structs;
using Massini.Core.Interop.Linux;
using Massini.Core.Math;
using Massini.Core.Math.Primitives;
using Buffer = Massini.Flamet.Classes.Buffer;

namespace Massini.Flamet.HelloTriangle
{
    internal static class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct Vertex
        {
            public Vec4<float> p_position;
            public Vec3<float> p_color;
        }
        
        private static Instance? m_instance = null;
        private static Device? m_device = null;
        private static Queue? m_queue = null;
        private static Surface? m_surface = null;
        private static Swapchain? m_swapchain = null;
        private static Layout? m_layout = null;
        private static ShaderLink? m_shaderLink = null;
        private static VertexBuffer<Vertex>? m_vertexBuffer = null;
        private static IndexBuffer<uint>? m_indexBuffer = null;
        
        private static Vec2<uint> m_viewport = new(800, 600);
        
        private static unsafe void Main()
        {
            SDL3.SDL.Init(SDL3.SDL.InitFlags.Events | SDL3.SDL.InitFlags.Video);
            nint window = SDL3.SDL.CreateWindow("Test", (int)m_viewport.Width, (int)m_viewport.Height, SDL3.SDL.WindowFlags.Resizable);

            m_instance = new Instance(new InstanceCreateParams()
            {
                p_next = null,
                p_label = "",
                p_features = new InstanceFeatures()
                {
                    p_debugUtils = true,
                    p_surface = true,
                },
            });

            m_instance.OnLog += (level, message) => Console.WriteLine($"{level}: {message}");

            var adapters = m_instance.GetAdapters(default);
            Adapter adapter = adapters[0];

            m_device = adapter.CreateDevice(new DeviceCreateParams()
            {
                p_next = null,
                p_featureLevel = Massini.Flamet.Enums.FeatureLevel.Level1,
                p_features = new AdapterFeatures()
                {
                    p_depthClamp = true,
                    p_fillModeNonSolid = true,
                    p_fragmentStoresAndAtomics = true,
                    p_samplerAnisotropy = true,
                    p_swapchain = true,
                    p_wideLines = true,
                },
            });

            m_queue = m_device.QueueFamilies[0].Queues[0];

            uint windowProps = SDL3.SDL.GetWindowProperties(window);
            XDisplay* displayPtr = (XDisplay*)SDL3.SDL.GetPointerProperty(windowProps, SDL3.SDL.Props.WindowX11DisplayPointer, 0);
            nint windowNumber = (nint)SDL3.SDL.GetNumberProperty(windowProps, SDL3.SDL.Props.WindowX11WindowNumber, 0L);

            m_surface = m_instance.CreateSurface(new SurfaceCreateParams
            {
                p_next = new SurfaceXlibCreateParams()
                {
                    p_next = null,
                    p_ptr_display = displayPtr,
                    p_window = windowNumber,
                },
                p_label = "Surface",
            });

            m_swapchain = m_device.CreateSwapchain(new SwapchainCreateParams
            {
                p_next = null,
                p_label = "Swapchain",
                p_size = new Vec2<uint>(800, 600),
                p_surface = m_surface,
                p_presentMode = Massini.Flamet.Enums.PresentModeFlags.Fifo,
                p_colorFormat = Massini.Flamet.Enums.TextureFormat.BGRA8UnormSrgb,
                p_colorSpace = Massini.Flamet.Enums.ColorSpace.SrgbNonLinear,
                p_compositeAlphaMode = Massini.Flamet.Enums.CompositeAlphaModeFlags.Opaque,
                p_enableDepthBuffer = false,
                p_depthFormat = Massini.Flamet.Enums.TextureFormat.None,
                p_maxFramesInFlight = 3,
            });

            m_layout = m_device.CreateLayout(new LayoutCreateParams
            {
                p_next = null,
                p_label = "Layout",
                p_pushConstant = null,
                p_sets = [],
            });
            
            byte[] vertexShader = File.ReadAllBytes("./hello_triangle.vert.spv");
            byte[] fragmentShader = File.ReadAllBytes("./hello_triangle.frag.spv");
            
            m_shaderLink = m_device.CreateShaderLink(new ShaderLinkCreateParams()
            {
                p_next = null,
                p_label = "ShaderLink",
                p_layout = m_layout,
                p_stages = 
                [
                    new ShaderLinkStage()
                    {
                        p_next = null,
                        p_stage = ShaderStageFlags.Vertex,
                        p_entryPoint = "main",
                        p_code = vertexShader,
                    },
                    new ShaderLinkStage()
                    {
                        p_next = null,
                        p_stage = ShaderStageFlags.Fragment,
                        p_entryPoint = "main",
                        p_code = fragmentShader,
                    },
                ],
            });

            m_vertexBuffer = m_device.CreateVertexBuffer<Vertex>(new TypedBufferCreateParams()
            {
                p_next = null,
                p_label = "Vertex Buffer",
                p_count = 3,
                p_usage = BufferUsageFlags.HostVisible | BufferUsageFlags.TransferDst,
            });

            m_vertexBuffer.WriteElements([
                new Vertex {
                    p_position = new Vec4<float>(0.0f, -0.5f, 0.0f, 1.0f),
                    p_color    = new Vec3<float>(1.0f, 0.0f, 0.0f)
                },
                new Vertex {
                    p_position = new Vec4<float>(0.5f, 0.5f, 0.0f, 1.0f),
                    p_color    = new Vec3<float>(0.0f, 1.0f, 0.0f)
                },
                new Vertex {
                    p_position = new Vec4<float>(-0.5f, 0.5f, 0.0f, 1.0f),
                    p_color    = new Vec3<float>(0.0f, 0.0f, 1.0f)
                }
            ]);

            m_indexBuffer = m_device.CreateIndexBuffer<uint>(new TypedBufferCreateParams()
            {
                p_next = null,
                p_label = "Index Buffer",
                p_count = 3,
                p_usage = BufferUsageFlags.HostVisible | BufferUsageFlags.TransferDst,
            });

            m_indexBuffer.WriteElements([0, 1, 2]);
            
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
                        m_device.WaitIdle();
                        m_swapchain?.Dispose();
                        
                        // Get new window size.
                        if (!SDL3.SDL.GetWindowSize(window, out var width, out var height))
                        {
                            throw new Exception("Failed to get window size.");
                        }
                        
                        // Make sure the viewport size is at least 1.
                        width = Math<int>.Max(width, 1);
                        height = Math<int>.Max(height, 1);
                        
                        m_viewport = new Vec2<uint>((uint)width, (uint)height);

                        m_swapchain = m_device.CreateSwapchain(new SwapchainCreateParams
                        {
                            p_next = null,
                            p_label = "Swapchain",
                            p_size = new Vec2<uint>((uint)width,  (uint)height),
                            p_surface = m_surface,
                            p_presentMode = Massini.Flamet.Enums.PresentModeFlags.Fifo,
                            p_colorFormat = Massini.Flamet.Enums.TextureFormat.BGRA8UnormSrgb,
                            p_colorSpace = Massini.Flamet.Enums.ColorSpace.SrgbNonLinear,
                            p_compositeAlphaMode = Massini.Flamet.Enums.CompositeAlphaModeFlags.Opaque,
                            p_enableDepthBuffer = false,
                            p_depthFormat = Massini.Flamet.Enums.TextureFormat.None,
                            p_maxFramesInFlight = 3,
                        });
                    }
                }

                double currentTime = SDL3.SDL.GetTicks() / 1000.0;

                Update(TimeSpan.FromSeconds(currentTime - lastTime));

                lastTime = currentTime;
            }

            m_device.WaitIdle();
            
            m_indexBuffer?.Dispose();
            m_vertexBuffer?.Dispose();

            m_shaderLink?.Dispose();
            m_layout?.Dispose();
            
            m_swapchain.Dispose();
            m_surface.Dispose();
            m_device.Dispose();
            m_instance.Dispose();

            SDL3.SDL.DestroyWindow(window);
            SDL3.SDL.Quit();
        }

        private static void Update(TimeSpan i_deltaTime)
        {
            m_swapchain!.BeginFrame(new SwapchainBeginFrameParams
            {
                p_next = null,
                p_presentQueue = m_queue!,
                p_waitCommandLists = [],
            }, out var cmdList, out var colorView, out var depthStencilView);

            MainEncoder mainEncoder = cmdList.Open(default);

            RenderPassEncoder renderPassEncoder = mainEncoder.CmdRenderPass(new RenderPassBeginParams
            {
                p_next = null,
                p_colorAttachments =
                [
                    new RenderPassColorAttachment
                    {
                        p_next = null,
                        p_clearColor = new Vec4<float>(0, 0, 0, 1),
                        p_depthSlice = 0,
                        p_loadOp = Massini.Flamet.Enums.LoadOp.Clear,
                        p_storeOp = Massini.Flamet.Enums.StoreOp.Store,
                        p_textureView = colorView,
                    },
                ],
                p_depthStencilAttachment = null,
            });
            
            renderPassEncoder.CmdBindShaderLink(m_shaderLink!);
            renderPassEncoder.CmdSetVertexInput(
            [
                new VertexAttributesLayout()
                {
                    p_binding = 0,
                    p_stepMode = VertexStepMode.Vertex,
                    p_stride  = (uint)m_vertexBuffer!.ElementSize,
                    p_attributes = 
                    [
                        new VertexAttribute()
                        {
                            p_location = 0,
                            p_attributeOffset = 0,
                            p_format = VertexFormat.Float32x4,
                        },
                        new VertexAttribute()
                        {
                            p_location = 1,
                            p_attributeOffset = 16,
                            p_format = VertexFormat.Float32x3,
                        },
                    ],
                },
            ]);
            
            SetDefaultShaderLinkParams(renderPassEncoder, m_viewport);
            
            renderPassEncoder.CmdBindIndexBuffer(m_indexBuffer!, IndexFormat.Uint32, 0, 3);
            renderPassEncoder.CmdBindVertexBuffer(m_vertexBuffer!, 0, 0, m_vertexBuffer!.Size);
            renderPassEncoder.CmdDrawIndexed(3, 1, 0, 0, 0);
            
            m_swapchain!.EndFrame();
        }

        static void SetDefaultShaderLinkParams(RenderPassEncoder i_encoder, Vec2<uint> i_viewport)
        {
            i_encoder.CmdSetCullMode(CullMode.Back);
            i_encoder.CmdSetDepthBiasEnable(false);
            i_encoder.CmdSetDepthClampEnable(false);
            i_encoder.CmdSetPolygonMode(PolygonMode.Fill);
            i_encoder.CmdSetStencilTestEnable(false);
            i_encoder.CmdSetColorBlendEnable(0, [true]);
            i_encoder.CmdSetFrontFace(FrontFace.CounterClockwise);
            i_encoder.CmdSetPrimitiveRestartEnable(false);
            i_encoder.CmdSetPrimitiveTopology(PrimitiveTopology.TriangleList);
            i_encoder.CmdSetDepthTestEnable(false);
            i_encoder.CmdSetColorWriteMask(0, [ColorComponentFlags.All]);
            i_encoder.CmdSetLineWidth(1.0f);
            i_encoder.CmdSetRasterizerDiscardEnable(false);
            i_encoder.CmdSetDepthCompareOp(CompareOp.LessOrEqual);
            i_encoder.CmdSetSampleMask(0, [0xFFFFFFFF]);
            i_encoder.CmdSetRasterizationSamples(SampleCount.SampleCount1);
            i_encoder.CmdSetAlphaToCoverageEnable(false);
            i_encoder.CmdSetColorBlendEquation(new SetColorBlendEquationCmdParams()
            {
                p_next = null,
                p_firstAttachment = 0,
                p_blendEquations = 
                [
                    new BlendState()
                    {
                        p_alphaBlendOp = BlendOp.Add,
                        p_colorBlendOp = BlendOp.Add,
                        p_colorWriteMask = ColorComponentFlags.All,
                        p_dstAlphaBlendFactor = BlendFactor.Zero,
                        p_dstColorBlendFactor = BlendFactor.Zero,
                        p_srcAlphaBlendFactor = BlendFactor.One,
                        p_srcColorBlendFactor = BlendFactor.One,
                    }
                ],
            });
            i_encoder.CmdSetScissorRect(0, 0, i_viewport.Width, i_viewport.Height);
            i_encoder.CmdSetViewport(0, 0, i_viewport.Width, i_viewport.Height, 0.0f, 1.0f);
        }
    }
}
