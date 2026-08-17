using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Sugar.Classes;
using Massini.Graphics.VkAL.Sugar.Structs;

namespace Massini.Graphics.VkAL.Sugar.Extensions
{
    public static class DeviceExtensions
    {
        extension(Device i_device)
        {
            public RenderTexture CreateRenderTexture(in RenderTextureCreateParams i_createParams)
            {
                return new RenderTexture(i_device, in i_createParams);
            }

            public UniformBuffer<T> CreateUniformBuffer<T>(in TypedBufferCreateParams i_createParams)
                where T : unmanaged
            {
                return new UniformBuffer<T>(i_device, in i_createParams);
            }

            public StorageBuffer<T> CreateStorageBuffer<T>(in TypedBufferCreateParams i_createParams)
                where T : unmanaged
            {
                return new StorageBuffer<T>(i_device, in i_createParams);
            }

            public VertexBuffer<T> CreateVertexBuffer<T>(in TypedBufferCreateParams i_createParams)
                where T : unmanaged
            {
                return new VertexBuffer<T>(i_device, in i_createParams);
            }

            public IndexBuffer<T> CreateIndexBuffer<T>(in TypedBufferCreateParams i_createParams)
                where T : unmanaged
            {
                return new IndexBuffer<T>(i_device, in i_createParams);
            }

            public Texture2D CreateTexture2D(in TypedTextureCreateParams i_createParams) 
            {
                return new Texture2D(i_device, in i_createParams);
            }

            public SmartShaderLink CreateSmartShaderLink(in SmartShaderLinkCreateParams i_createParams)
            {
                return new SmartShaderLink(i_device, in i_createParams);
            }
        }
    }
}
