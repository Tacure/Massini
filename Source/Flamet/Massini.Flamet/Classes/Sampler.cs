
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet.Structs;
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes
{
    /// <summary>
    /// Sampler.
    /// </summary>
    public unsafe class Sampler : IResource, IDisposable
    {
        public const float DISABLE_LOD_MAX_CLAMP = 1000.0f;

        /// <inheritdoc/>
        public Rid Id => m_id;

        /// <inheritdoc/>
        public Device Device => m_device;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        /// <summary>
        /// Creates a sampler.
        /// </summary>
        public Sampler(Device i_device, in SamplerCreateParams i_createParams)
        {
            Device device = (Device)i_device;

            VkSamplerCreateInfo vkSamplerCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO,
                pNext = null,
                flags = 0,
                addressModeU = IntSharedCvs.SamplerAdressModeToVkSamplerAdressMode(i_createParams.p_addressModeU),
                addressModeV = IntSharedCvs.SamplerAdressModeToVkSamplerAdressMode(i_createParams.p_addressModeV),
                addressModeW = IntSharedCvs.SamplerAdressModeToVkSamplerAdressMode(i_createParams.p_addressModeW),
                compareOp = IntSharedCvs.CompareOperationToVkCompareOp(i_createParams.p_compareOperation),
                magFilter = IntSharedCvs.FilterModeToVkFilter(i_createParams.p_magFilter),
                minFilter = IntSharedCvs.FilterModeToVkFilter(i_createParams.p_minFilter),
                maxLod = i_createParams.p_lodMaxClamp,
                minLod = i_createParams.p_lodMinClamp,
                maxAnisotropy = i_createParams.p_maxAnisotropy,
                anisotropyEnable = i_createParams.p_enableAnisotropy ? 1U : 0U,
                mipmapMode = IntSharedCvs.FilterModeToVkSamplerMipmapMode(i_createParams.p_mipmapFilter),
                borderColor = VkBorderColor.VK_BORDER_COLOR_FLOAT_TRANSPARENT_BLACK,
                compareEnable = i_createParams.p_compareOperation != CompareOp.Never ? 1U : 0U,
                mipLodBias = i_createParams.p_mipLodBias,
                unnormalizedCoordinates = i_createParams.p_enableUnnormalizedCoordinates ? 1U : 0U
            };

            VkSampler_T* sampler = null;
            VkResult result = Vk.vkCreateSampler(device.VkDevicePtr, &vkSamplerCreateInfo, null, &sampler);

            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create sampler.");
            }

            IntSharedFuncs.SetObjectLabel(i_device, sampler, VkObjectType.VK_OBJECT_TYPE_SAMPLER, $"Sampler - {i_createParams.p_label}");

            m_id = Rid.NewId();
            m_label = i_createParams.p_label;
            m_device = device;
            m_ptr_sampler = sampler;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vk.vkDestroySampler(m_device.VkDevicePtr, m_ptr_sampler, null);
            }
        }

        internal VkSampler_T* VkSamplerPtr => m_ptr_sampler;

        private bool m_isDisposed = false;
        private Rid m_id;
        private readonly string m_label;
        private readonly Device m_device;
        private readonly VkSampler_T* m_ptr_sampler;
    }
}
