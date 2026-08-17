
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL
{
    internal static class VkUtils
    {
        public unsafe static void SetObjectLabel(Device i_device, void* i_ptr_object, VkObjectType i_objectType, string i_label)
        {
            var setDebugNameFunc = i_device.Adapter.Instance.ExtFunctions.PfnVkSetDebugUtilsObjectNameExt;
            if (setDebugNameFunc != null)
            {
                Span<sbyte> name = stackalloc sbyte[i_label.Length + 1];
                for (int i = 0; i < i_label.Length; i++)
                {
                    name[i] = (sbyte)i_label[i];
                }
                name[i_label.Length] = 0;

                fixed (sbyte* namePtr = name)
                {
                    VkDebugUtilsObjectNameInfoEXT objectNameInfo = new()
                    {
                        pNext = null,
                        sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_NAME_INFO_EXT,
                        pObjectName = namePtr,
                        objectHandle = (ulong)i_ptr_object,
                        objectType = i_objectType,
                    };

                    VkResult res = setDebugNameFunc(i_device.VkDevicePtr, &objectNameInfo);
                }
            }
        }

        public static bool IsValidTransition(ShaderStageFlags i_current, ShaderStageFlags i_next)
        {
            return i_current switch
            {
                ShaderStageFlags.Vertex =>
                    i_next == ShaderStageFlags.Fragment ||
                    i_next == ShaderStageFlags.Geometry ||
                    i_next == ShaderStageFlags.TessControl,

                ShaderStageFlags.Geometry =>
                    i_next == ShaderStageFlags.Fragment,

                ShaderStageFlags.TessControl =>
                    i_next == ShaderStageFlags.TessEvaluation,

                ShaderStageFlags.TessEvaluation =>
                    i_next == ShaderStageFlags.Geometry ||
                    i_next == ShaderStageFlags.Fragment,

                ShaderStageFlags.Fragment =>
                    i_next == ShaderStageFlags.None,

                ShaderStageFlags.Compute =>
                    i_next == ShaderStageFlags.None,

                _ => false
            };
        }

        public static void FillTextureBarrierMipmapsBitmask(in TextureSubresourceLayers i_region, ulong[] i_masks)
        {
            for (int j = (int)i_region.p_baseArrayLayer;
                j < i_region.p_layerCount + (int)i_region.p_baseArrayLayer;
                j++)
            {
                // Set bitmask bit to ONE for the mip.
                i_masks[j] |= 1UL << (int)i_region.p_mipLevel;
            }
        }

        public static void FillTextureBarrierMipmapsBitmaskToAll(ulong[] i_masks)
        {
            for (int j = 0; j < i_masks.Length; j++)
            {
                // Enable all mips.
                i_masks[j] = ulong.MaxValue;
            }
        }

        public static QueueUsageFlags VkQueueFlagBitsToQueueUsageFlags(VkQueueFlagBits i_queueFlags)
        {
            QueueUsageFlags unoQueueUsageFlags = 0;
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT))
            {
                unoQueueUsageFlags |= QueueUsageFlags.Graphics;
            }
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_COMPUTE_BIT))
            {
                unoQueueUsageFlags |= QueueUsageFlags.Compute;
            }
            if (i_queueFlags.HasFlag(VkQueueFlagBits.VK_QUEUE_TRANSFER_BIT))
            {
                unoQueueUsageFlags |= QueueUsageFlags.Transfer;
            }
            return unoQueueUsageFlags;
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

        public static VkImageAspectFlagBits GuessVkImageAspectMask(VkFormat i_format)
        {
            return i_format switch
            {
                VkFormat.VK_FORMAT_D32_SFLOAT_S8_UINT => VkImageAspectFlagBits.VK_IMAGE_ASPECT_DEPTH_BIT | VkImageAspectFlagBits.VK_IMAGE_ASPECT_STENCIL_BIT,
                _ => VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT,
            };
        }

        public static VkPresentModeKHR PresentModeFlagsToVkPresentModeKhr(PresentModeFlags i_presentMode)
        {
            return i_presentMode switch
            {
                PresentModeFlags.Fifo => VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR,
                PresentModeFlags.FifoRelaxed => VkPresentModeKHR.VK_PRESENT_MODE_FIFO_RELAXED_KHR,
                PresentModeFlags.Mailbox => VkPresentModeKHR.VK_PRESENT_MODE_MAILBOX_KHR,
                PresentModeFlags.Immediate => VkPresentModeKHR.VK_PRESENT_MODE_IMMEDIATE_KHR,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkColorSpaceKHR ColorSpaceToVkColorSpaceKhr(ColorSpace i_colorSpace)
        {
            return i_colorSpace switch
            {
                ColorSpace.SrgbNonLinear => VkColorSpaceKHR.VK_COLORSPACE_SRGB_NONLINEAR_KHR,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkCompositeAlphaFlagBitsKHR CompositeAlphaModeFlagsToVkCompositeAlphaFlagBitsKhr(CompositeAlphaModeFlags i_compositeAlphaMode)
        {
            VkCompositeAlphaFlagBitsKHR compositeAlphaFlagBitsKhr = 0;
            if (i_compositeAlphaMode.HasFlag(CompositeAlphaModeFlags.Opaque))
            {
                compositeAlphaFlagBitsKhr |= VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR;
            }
            if (i_compositeAlphaMode.HasFlag(CompositeAlphaModeFlags.Premultiplied))
            {
                compositeAlphaFlagBitsKhr |= VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR;
            }
            if (i_compositeAlphaMode.HasFlag(CompositeAlphaModeFlags.Unpremultiplied))
            {
                compositeAlphaFlagBitsKhr |= VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR;
            }
            if (i_compositeAlphaMode.HasFlag(CompositeAlphaModeFlags.Inherit))
            {
                compositeAlphaFlagBitsKhr |= VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_INHERIT_BIT_KHR;
            }
            return compositeAlphaFlagBitsKhr;
        }

        public static VkAttachmentLoadOp LoadOpToVkAttachmentLoadOp(LoadOp i_loadOp)
        {
            return i_loadOp switch
            {
                LoadOp.Load => VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_LOAD,
                LoadOp.Clear => VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkAttachmentStoreOp StoreOpToVkAttachmentStoreOp(StoreOp i_storeOp)
        {
            return i_storeOp switch
            {
                StoreOp.Store => VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE,
                StoreOp.Discard => VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE,
                _ => throw new NotImplementedException(),
            };
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

        public static VkIndexType IndexFormatToVkIndexType(IndexFormat i_indexFormat)
        {
            return i_indexFormat switch
            {
                IndexFormat.Uint16 => VkIndexType.VK_INDEX_TYPE_UINT16,
                IndexFormat.Uint32 => VkIndexType.VK_INDEX_TYPE_UINT32,
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

        public static VkVertexInputRate VertexStepModeToVkVertexInputRate(VertexStepMode i_stepMode)
        {
            return i_stepMode switch
            {
                VertexStepMode.Vertex => VkVertexInputRate.VK_VERTEX_INPUT_RATE_VERTEX,
                VertexStepMode.Instance => VkVertexInputRate.VK_VERTEX_INPUT_RATE_INSTANCE,
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

        public static VkFormat VertexFormatToVkFormat(VertexFormat i_format)
        {
            return i_format switch
            {
                VertexFormat.Float32x2 => VkFormat.VK_FORMAT_R32G32_SFLOAT,
                VertexFormat.Float32x3 => VkFormat.VK_FORMAT_R32G32B32_SFLOAT,
                VertexFormat.Float32x4 => VkFormat.VK_FORMAT_R32G32B32A32_SFLOAT,
                VertexFormat.Uint8x4 => VkFormat.VK_FORMAT_R8G8B8A8_UINT,
                VertexFormat.Unorm8x4 => VkFormat.VK_FORMAT_R8G8B8A8_UNORM,
                VertexFormat.Uint32 => VkFormat.VK_FORMAT_R32_UINT,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkPrimitiveTopology PrimitiveTopologyToVkPrimitiveTopology(PrimitiveTopology i_topology)
        {
            return i_topology switch
            {
                PrimitiveTopology.TriangleList => VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST,
                PrimitiveTopology.TriangleStrip => VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP,
                PrimitiveTopology.LineList => VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_LINE_LIST,
                PrimitiveTopology.LineStrip => VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_LINE_STRIP,
                PrimitiveTopology.PointList => VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_POINT_LIST,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkPolygonMode PolygonModeToVkPolygonMode(PolygonMode i_polygonMode)
        {
            return i_polygonMode switch
            {
                PolygonMode.Fill => VkPolygonMode.VK_POLYGON_MODE_FILL,
                PolygonMode.Line => VkPolygonMode.VK_POLYGON_MODE_LINE,
                PolygonMode.Point => VkPolygonMode.VK_POLYGON_MODE_POINT,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkFrontFace FrontFaceToVkFrontFace(FrontFace i_frontFace)
        {
            return i_frontFace switch
            {
                FrontFace.CounterClockwise => VkFrontFace.VK_FRONT_FACE_COUNTER_CLOCKWISE,
                FrontFace.Clockwise => VkFrontFace.VK_FRONT_FACE_CLOCKWISE,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkCullModeFlagBits CullModeFlagsToVkCullModeFlagBits(CullMode i_cullMode)
        {
            return i_cullMode switch
            {
                CullMode.None => VkCullModeFlagBits.VK_CULL_MODE_NONE,
                CullMode.Front => VkCullModeFlagBits.VK_CULL_MODE_FRONT_BIT,
                CullMode.Back => VkCullModeFlagBits.VK_CULL_MODE_BACK_BIT,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkStencilOp StencilOperationStateToVkStencilOp(StencilOp i_stencilOp)
        {
            return i_stencilOp switch
            {
                StencilOp.Keep => VkStencilOp.VK_STENCIL_OP_KEEP,
                StencilOp.Zero => VkStencilOp.VK_STENCIL_OP_ZERO,
                StencilOp.Replace => VkStencilOp.VK_STENCIL_OP_REPLACE,
                StencilOp.IncrementAndClamp => VkStencilOp.VK_STENCIL_OP_INCREMENT_AND_CLAMP,
                StencilOp.DecrementAndClamp => VkStencilOp.VK_STENCIL_OP_DECREMENT_AND_CLAMP,
                StencilOp.Invert => VkStencilOp.VK_STENCIL_OP_INVERT,
                StencilOp.IncrementAndWrap => VkStencilOp.VK_STENCIL_OP_INCREMENT_AND_WRAP,
                StencilOp.DecrementAndWrap => VkStencilOp.VK_STENCIL_OP_DECREMENT_AND_WRAP,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkBlendOp BlendOpToVkBlendOp(BlendOp i_blendOp)
        {
            return i_blendOp switch
            {
                BlendOp.Add => VkBlendOp.VK_BLEND_OP_ADD,
                BlendOp.Subtract => VkBlendOp.VK_BLEND_OP_SUBTRACT,
                BlendOp.ReverseSubtract => VkBlendOp.VK_BLEND_OP_REVERSE_SUBTRACT,
                BlendOp.Min => VkBlendOp.VK_BLEND_OP_MIN,
                BlendOp.Max => VkBlendOp.VK_BLEND_OP_MAX,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkBlendFactor BlendFactorToVkBlendFactor(BlendFactor i_blendFactor)
        {
            return i_blendFactor switch
            {
                BlendFactor.Zero => VkBlendFactor.VK_BLEND_FACTOR_ZERO,
                BlendFactor.One => VkBlendFactor.VK_BLEND_FACTOR_ONE,
                BlendFactor.SrcColor => VkBlendFactor.VK_BLEND_FACTOR_SRC_COLOR,
                BlendFactor.OneMinusSrcColor => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_SRC_COLOR,
                BlendFactor.DstColor => VkBlendFactor.VK_BLEND_FACTOR_DST_COLOR,
                BlendFactor.OneMinusDstColor => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_DST_COLOR,
                BlendFactor.SrcAlpha => VkBlendFactor.VK_BLEND_FACTOR_SRC_ALPHA,
                BlendFactor.OneMinusSrcAlpha => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA,
                BlendFactor.DstAlpha => VkBlendFactor.VK_BLEND_FACTOR_DST_ALPHA,
                BlendFactor.OneMinusDstAlpha => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_DST_ALPHA,
                BlendFactor.ConstantColor => VkBlendFactor.VK_BLEND_FACTOR_CONSTANT_COLOR,
                BlendFactor.OneMinusConstantColor => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_COLOR,
                BlendFactor.ConstantAlpha => VkBlendFactor.VK_BLEND_FACTOR_CONSTANT_ALPHA,
                BlendFactor.OneMinusConstantAlpha => VkBlendFactor.VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA,
                BlendFactor.SrcAlphaSaturate => VkBlendFactor.VK_BLEND_FACTOR_SRC_ALPHA_SATURATE,
                _ => throw new NotImplementedException(),
            };
        }

        public static VkColorComponentFlagBits ColorComponentFlagsToVkColorComponentFlagBits(ColorComponentFlags i_colorComponentFlags)
        {
            VkColorComponentFlagBits result = 0;
            if (i_colorComponentFlags.HasFlag(ColorComponentFlags.R))
            {
                result |= VkColorComponentFlagBits.VK_COLOR_COMPONENT_R_BIT;
            }
            if (i_colorComponentFlags.HasFlag(ColorComponentFlags.G))
            {
                result |= VkColorComponentFlagBits.VK_COLOR_COMPONENT_G_BIT;
            }
            if (i_colorComponentFlags.HasFlag(ColorComponentFlags.B))
            {
                result |= VkColorComponentFlagBits.VK_COLOR_COMPONENT_B_BIT;
            }
            if (i_colorComponentFlags.HasFlag(ColorComponentFlags.A))
            {
                result |= VkColorComponentFlagBits.VK_COLOR_COMPONENT_A_BIT;
            }
            return result;
        }

        public static VkAccessFlagBits EntryModeToVkAccessFlagBits(EntryMode i_mode)
        {
            VkAccessFlagBits result = 0;
            if (i_mode.HasFlag(EntryMode.Read))
            {
                result |= VkAccessFlagBits.VK_ACCESS_SHADER_READ_BIT;
            }
            if (i_mode.HasFlag(EntryMode.Write))
            {
                result |= VkAccessFlagBits.VK_ACCESS_SHADER_WRITE_BIT;
            }
            return result;
        }

        public static VkPipelineStageFlagBits ShaderStageFlagsToVkPipelineStageFlagBits(ShaderStageFlags i_stages)
        {
            VkPipelineStageFlagBits result = 0;
            if (i_stages.HasFlag(ShaderStageFlags.Vertex))
            {
                result |= VkPipelineStageFlagBits.VK_PIPELINE_STAGE_VERTEX_SHADER_BIT;
            }
            if (i_stages.HasFlag(ShaderStageFlags.Fragment))
            {
                result |= VkPipelineStageFlagBits.VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT;
            }
            if (i_stages.HasFlag(ShaderStageFlags.Compute))
            {
                result |= VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT;
            }
            return result;
        }
    }
}
