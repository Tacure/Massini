
using Massini.Bindings.Vulkan;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Kernel : IKernel1
    {
        public Kernel(Lane i_lane, in GraphicsKernelCreateParams i_createParams)
        {
            
        }
        
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_lane.GetInfo().Device;
                
                m_isDisposed = true;
                Vk.vkDestroyPipeline(device.VkDevicePtr, m_ptr_pipeline, null);
            }
        }

        public KernelInfo GetInfo()
        {
            return m_kernelInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_lane.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_pipeline, VkObjectType.VK_OBJECT_TYPE_PIPELINE, i_label);  
        }

        private bool m_isDisposed = false;
        private readonly Lane m_lane;
        private readonly VkPipeline_T* m_ptr_pipeline;
        private readonly KernelInfo m_kernelInfo;
    }   
}