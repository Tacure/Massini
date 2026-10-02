
using Massini.Bindings.Vulkan;
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Impl
{
    internal static class IntSharedCvs
    {
        public static LaneUsageFlags VkQueueFlagBitsToLaneUsageFlags(VkQueueFlagBits i_queueFlags)
        {
            LaneUsageFlags unoQueueUsageFlags = 0;
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT))
            {
                unoQueueUsageFlags |= LaneUsageFlags.Graphics;
            }
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_COMPUTE_BIT))
            {
                unoQueueUsageFlags |= LaneUsageFlags.Compute;
            }
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_TRANSFER_BIT))
            {
                unoQueueUsageFlags |= LaneUsageFlags.Transfer;
            }
            return unoQueueUsageFlags;
        }
        
        public static VkImageType TextureTypeToVkImageType(TextureType i_type)
        {
            return i_type switch
            {
                TextureType.Texture1D => VkImageType.VK_IMAGE_TYPE_1D,
                TextureType.Texture2D => VkImageType.VK_IMAGE_TYPE_2D,
                TextureType.Texture3D => VkImageType.VK_IMAGE_TYPE_3D,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkFormat TextureFormatToVkFormat(TextureFormat i_format)
        {
            return i_format switch
            {
                TextureFormat.None => VkFormat.VK_FORMAT_UNDEFINED,
                TextureFormat.BGRA8Unorm => VkFormat.VK_FORMAT_B8G8R8A8_UNORM,
                TextureFormat.RGBA8UnormSrgb => VkFormat.VK_FORMAT_R8G8B8A8_SRGB,
                TextureFormat.RGBA16Float => VkFormat.VK_FORMAT_R16G16B16A16_SFLOAT,
                TextureFormat.RGBA8Unorm => VkFormat.VK_FORMAT_R8G8B8A8_UNORM,
                TextureFormat.RGBA32Float => VkFormat.VK_FORMAT_R32G32B32A32_SFLOAT,
                TextureFormat.Depth32FloatStencil8 => VkFormat.VK_FORMAT_D32_SFLOAT_S8_UINT,
                TextureFormat.BGRA8UnormSrgb => VkFormat.VK_FORMAT_B8G8R8A8_SRGB,
                TextureFormat.RG16Float => VkFormat.VK_FORMAT_R16G16_SFLOAT,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkSampleCountFlagBits SampleCountToVkSampleCountFlagBits(SampleCount i_sampleCount)
        {
            return i_sampleCount switch
            {
                SampleCount.SampleCount1 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
                SampleCount.SampleCount2 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_2_BIT,
                SampleCount.SampleCount4 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_4_BIT,
                SampleCount.SampleCount8 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_8_BIT,
                SampleCount.SampleCount16 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_16_BIT,
                SampleCount.SampleCount32 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_32_BIT,
                SampleCount.SampleCount64 => VkSampleCountFlagBits.VK_SAMPLE_COUNT_64_BIT,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkImageUsageFlagBits TextureUsageFlagsToVkImageUsageFlagBits(TextureUsageFlags i_usage)
        {
            VkImageUsageFlagBits imageUsageFlagBits = 0;
            if (i_usage.HasFlag(TextureUsageFlags.ColorAttachment))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT;
            }
            if (i_usage.HasFlag(TextureUsageFlags.DepthStencilAttachment))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT;
            }
            if (i_usage.HasFlag(TextureUsageFlags.TransferSrc))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_TRANSFER_SRC_BIT;
            }
            if (i_usage.HasFlag(TextureUsageFlags.TransferDst))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_TRANSFER_DST_BIT;
            }
            if (i_usage.HasFlag(TextureUsageFlags.Sampled))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_SAMPLED_BIT;
            }
            if (i_usage.HasFlag(TextureUsageFlags.Storage))
            {
                imageUsageFlagBits |= VkImageUsageFlagBits.VK_IMAGE_USAGE_STORAGE_BIT;
            }
            return imageUsageFlagBits;
        }

        public static TextureFormat VkFormatToTextureFormat(VkFormat i_format)
        {
            return i_format switch
            {
                // RGBA Formats
                VkFormat.VK_FORMAT_R8G8B8A8_UNORM => TextureFormat.RGBA8Unorm,
                VkFormat.VK_FORMAT_R8G8B8A8_SNORM => TextureFormat.RGBA8Snorm,
                VkFormat.VK_FORMAT_R8G8B8A8_SRGB => TextureFormat.RGBA8UnormSrgb,
                VkFormat.VK_FORMAT_R16G16B16A16_UNORM => TextureFormat.RGBA16Unorm,
                VkFormat.VK_FORMAT_R16G16B16A16_SNORM => TextureFormat.RGBA16Snorm,
                VkFormat.VK_FORMAT_R16G16B16A16_SFLOAT => TextureFormat.RGBA16Float,
                VkFormat.VK_FORMAT_R32G32B32A32_SFLOAT => TextureFormat.RGBA32Float,

                // BGRA Formats
                VkFormat.VK_FORMAT_B8G8R8A8_UNORM => TextureFormat.BGRA8Unorm,
                VkFormat.VK_FORMAT_B8G8R8A8_SNORM => TextureFormat.BGRA8Snorm,
                VkFormat.VK_FORMAT_B8G8R8A8_SRGB => TextureFormat.BGRA8UnormSrgb,

                // ABGR Formats
                VkFormat.VK_FORMAT_A8B8G8R8_UNORM_PACK32 => TextureFormat.ABGR8Unorm,
                VkFormat.VK_FORMAT_A8B8G8R8_SNORM_PACK32 => TextureFormat.ABGR8Snorm,
                VkFormat.VK_FORMAT_A8B8G8R8_SRGB_PACK32 => TextureFormat.ABGR8UnormSrgb,

                // Packed Formats
                VkFormat.VK_FORMAT_A2R10G10B10_UNORM_PACK32 => TextureFormat.A2RGB10Unorm,
                VkFormat.VK_FORMAT_A2B10G10R10_UNORM_PACK32 => TextureFormat.A2BGR10Unorm,
                VkFormat.VK_FORMAT_R5G6B5_UNORM_PACK16 => TextureFormat.R5G6B5Unorm,
                VkFormat.VK_FORMAT_B5G6R5_UNORM_PACK16 => TextureFormat.B5G6R5Unorm,
                VkFormat.VK_FORMAT_A1R5G5B5_UNORM_PACK16 => TextureFormat.A1RGB5Unorm,
                VkFormat.VK_FORMAT_B10G11R11_UFLOAT_PACK32 => TextureFormat.B10G11R11Ufloat,

                // Depth/Stencil Formats
                VkFormat.VK_FORMAT_D32_SFLOAT_S8_UINT => TextureFormat.Depth32FloatStencil8,

                _ => throw new NotImplementedException($"Unhandled VkFormat: {i_format}"),
            };
        }
        
        public static TextureType VkImageTypeToTextureType(VkImageType m_imageType)
        {
            return m_imageType switch
            {
                VkImageType.VK_IMAGE_TYPE_1D => TextureType.Texture1D,
                VkImageType.VK_IMAGE_TYPE_2D => TextureType.Texture2D,
                VkImageType.VK_IMAGE_TYPE_3D => TextureType.Texture3D,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkBufferUsageFlagBits BufferUsageFlagsToVkBufferUsageFlagBits(BufferUsageFlags i_usageFlags)
        {
            VkBufferUsageFlagBits result = 0;
            if (i_usageFlags.HasFlag(BufferUsageFlags.TransferSrc))
            {
                result |= VkBufferUsageFlagBits.VK_BUFFER_USAGE_TRANSFER_SRC_BIT;
            }
            if (i_usageFlags.HasFlag(BufferUsageFlags.TransferDst))
            {
                result |= VkBufferUsageFlagBits.VK_BUFFER_USAGE_TRANSFER_DST_BIT;
            }
            if (i_usageFlags.HasFlag(BufferUsageFlags.DeviceAddress))
            {
                result |= VkBufferUsageFlagBits.VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT;
            }
            return result;
        }

        public static uint BufferTypeToVkBufferUsageFlags(BufferType i_type)
        {
            return i_type switch
            {
                BufferType.Vertex => (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_VERTEX_BUFFER_BIT,
                BufferType.Index => (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_INDEX_BUFFER_BIT,
                BufferType.Uniform => (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT,
                BufferType.Storage => (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_STORAGE_BUFFER_BIT,
                BufferType.Descriptor => (uint)VkBufferUsageFlagBits.VK_BUFFER_USAGE_RESOURCE_DESCRIPTOR_BUFFER_BIT_EXT,
                _ => throw new NotImplementedException(),
            };
        }

        public static SampleCount VkSampleCountFlagBitsToSampleCount(VkSampleCountFlagBits i_sampleCount)
        {            
            return i_sampleCount switch
            {
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT => SampleCount.SampleCount1,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_2_BIT => SampleCount.SampleCount2,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_4_BIT => SampleCount.SampleCount4,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_8_BIT => SampleCount.SampleCount8,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_16_BIT => SampleCount.SampleCount16,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_32_BIT => SampleCount.SampleCount32,
                VkSampleCountFlagBits.VK_SAMPLE_COUNT_64_BIT => SampleCount.SampleCount64,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkImageViewType TextureViewTypeToVkImageViewType(TextureViewType i_type)
        {
            return i_type switch
            {
                TextureViewType.View1D => VkImageViewType.VK_IMAGE_VIEW_TYPE_1D,
                TextureViewType.View2D => VkImageViewType.VK_IMAGE_VIEW_TYPE_2D,
                TextureViewType.View3D => VkImageViewType.VK_IMAGE_VIEW_TYPE_3D,
                TextureViewType.Cube => VkImageViewType.VK_IMAGE_VIEW_TYPE_CUBE,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkImageAspectFlagBits TextureAspectFlagsToVkImageAspectFlagBits(TextureAspectFlags i_aspect)
        {
            VkImageAspectFlagBits aspectFlagBits = 0;
            if (i_aspect.HasFlag(TextureAspectFlags.Color))
            {
                aspectFlagBits |= VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT;
            }
            if (i_aspect.HasFlag(TextureAspectFlags.Depth))
            {
                aspectFlagBits |= VkImageAspectFlagBits.VK_IMAGE_ASPECT_DEPTH_BIT;
            }
            if (i_aspect.HasFlag(TextureAspectFlags.Stencil))
            {
                aspectFlagBits |= VkImageAspectFlagBits.VK_IMAGE_ASPECT_STENCIL_BIT;
            }
            return aspectFlagBits;
        }
        
        public static VkSamplerAddressMode SamplerAdressModeToVkSamplerAdressMode(SamplerAdressMode i_adressMode)
        {
            return i_adressMode switch
            {
                SamplerAdressMode.ClampToEdge => VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE,
                SamplerAdressMode.MirrorRepeat => VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT,
                SamplerAdressMode.Repeat => VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_REPEAT,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkCompareOp CompareOperationToVkCompareOp(CompareOp i_compareOperation)
        {
            return i_compareOperation switch
            {
                CompareOp.Never => VkCompareOp.VK_COMPARE_OP_NEVER,
                CompareOp.Less => VkCompareOp.VK_COMPARE_OP_LESS,
                CompareOp.Equal => VkCompareOp.VK_COMPARE_OP_EQUAL,
                CompareOp.LessOrEqual => VkCompareOp.VK_COMPARE_OP_LESS_OR_EQUAL,
                CompareOp.Greater => VkCompareOp.VK_COMPARE_OP_GREATER,
                CompareOp.NotEqual => VkCompareOp.VK_COMPARE_OP_NOT_EQUAL,
                CompareOp.GreaterOrEqual => VkCompareOp.VK_COMPARE_OP_GREATER_OR_EQUAL,
                CompareOp.Always => VkCompareOp.VK_COMPARE_OP_ALWAYS,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkFilter FilterModeToVkFilter(FilterMode i_filterMode)
        {
            return i_filterMode switch
            {
                FilterMode.Nearest => VkFilter.VK_FILTER_NEAREST,
                FilterMode.Linear => VkFilter.VK_FILTER_LINEAR,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkSamplerMipmapMode FilterModeToVkSamplerMipmapMode(FilterMode i_filterMode)
        {
            return i_filterMode switch
            {
                FilterMode.Nearest => VkSamplerMipmapMode.VK_SAMPLER_MIPMAP_MODE_NEAREST,
                FilterMode.Linear => VkSamplerMipmapMode.VK_SAMPLER_MIPMAP_MODE_LINEAR,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkDescriptorType EntryTypeToVkDescriptorType(EntryType i_type)
        {
            return i_type switch
            {
                EntryType.UniformBuffer => VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER,
                EntryType.StorageBuffer => VkDescriptorType.VK_DESCRIPTOR_TYPE_STORAGE_BUFFER,
                EntryType.Sampler => VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLER,
                EntryType.Texture => VkDescriptorType.VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE,
                _ => throw new NotImplementedException(),
            };
        }
        
        public static VkShaderStageFlagBits ShaderStageFlagsToVkShaderStageFlagBits(ShaderStageFlags i_stages)
        {
            VkShaderStageFlagBits shaderStageFlagBits = 0;
            if (i_stages.HasFlag(ShaderStageFlags.Vertex))
            {
                shaderStageFlagBits |= VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT;
            }
            if (i_stages.HasFlag(ShaderStageFlags.Fragment))
            {
                shaderStageFlagBits |= VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT;
            }
            if (i_stages.HasFlag(ShaderStageFlags.Compute))
            {
                shaderStageFlagBits |= VkShaderStageFlagBits.VK_SHADER_STAGE_COMPUTE_BIT;
            }
            return shaderStageFlagBits;
        }
    }
}
