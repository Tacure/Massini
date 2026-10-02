
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Sampler : ISampler1
    {
        public Sampler(Lane i_lane, in SamplerCreateParams i_createParams)
        {
            Device device = (Device)i_lane.GetInfo().Device;

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

            m_lane = i_lane;
            m_ptr_sampler = sampler;
            m_samplerInfo = new SamplerInfo()
            {
                Id = Rid.NewId(),
            };
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_lane.GetInfo().Device;
                
                m_isDisposed = true;
                Vk.vkDestroySampler(device.VkDevicePtr, m_ptr_sampler, null);
            }
        }

        public SamplerInfo GetInfo()
        {
            return m_samplerInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_lane.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_sampler, VkObjectType.VK_OBJECT_TYPE_SAMPLER, i_label);      
        }

        private bool m_isDisposed = false;
        private Lane m_lane;
        private readonly VkSampler_T* m_ptr_sampler;
        private readonly SamplerInfo m_samplerInfo;
    }   
}