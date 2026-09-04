
using Massini.Bindings.Vulkan;
using Massini.Core.Interop;

namespace Massini.Flamet.Classes.Internal
{
    internal sealed unsafe class DeviceFunctionTable
    {
        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkRenderingInfo*,
            void> PfnVkCmdBeginRenderingKhr
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            void> PfnVkCmdEndRenderingKhr
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkDevice_T*,
            VkSemaphore_T*,
            ulong*,
            VkResult> PfnVkGetSemaphoreCounterValue
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkDevice_T*,
            VkSemaphoreWaitInfo*,
            ulong,
            VkResult> PfnVkWaitSemaphoresKhr
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            VkRect2D*,
            void> PfnVkCmdSetScissorWithCountExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            VkViewport*,
            void> PfnVkCmdSetViewportWithCountExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            uint,
            VkBuffer_T**,
            ulong*,
            ulong*,
            ulong*,
            void> PfnVkCmdBindVertexBuffers2Ext
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkPipelineBindPoint,
            VkPipelineLayout_T*,
            uint,
            uint,
            VkWriteDescriptorSet*,
            void> PfnVkCmdPushDescriptorSetKhr
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkDevice_T*,
            uint,
            VkShaderCreateInfoEXT*,
            VkAllocationCallbacks*,
            VkShaderEXT_T**,
            VkResult> PfnVkCreateShadersExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkDevice_T*,
            VkShaderEXT_T*,
            VkAllocationCallbacks*,
            void> PfnVkDestroyShaderExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            VkShaderStageFlagBits*,
            VkShaderEXT_T**,
            void> PfnVkCmdBindShadersExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkPolygonMode,
            void> PfnVkCmdSetPolygonModeExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkSampleCountFlagBits,
            void> PfnVkCmdSetRasterizationSamplesExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkSampleCountFlagBits,
            uint*,
            void> PfnVkCmdSetSampleMaskExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            void> PfnVkCmdSetDepthClampEnableExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            VkLogicOp,
            void> PfnVkCmdSetLogicOpExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            void> PfnVkCmdSetLogicOpEnableExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            VkVertexInputBindingDescription2EXT*,
            uint,
            VkVertexInputAttributeDescription2EXT*,
            void> PfnVkCmdSetVertexInputExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            uint,
            uint*,
            void> PfnVkCmdSetColorBlendEnableExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            uint,
            VkColorBlendEquationEXT*,
            void> PfnVkCmdSetColorBlendEquationExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            uint,
            uint*,
            void> PfnVkCmdSetColorWriteMaskExt
        { get; set; } = null;

        public delegate* unmanaged[Cdecl]<
            VkCommandBuffer_T*,
            uint,
            void> PfnVkCmdSetAlphaToCoverageEnableExt
        { get; set; } = null;
        
        public void GetProcAddrCmdPushDescriptorSetKHR(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdPushDescriptorSetKHR");
            PfnVkCmdPushDescriptorSetKhr = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkPipelineBindPoint,
                VkPipelineLayout_T*,
                uint,
                uint,
                VkWriteDescriptorSet*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdBeginRenderingKHR(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdBeginRenderingKHR");
            PfnVkCmdBeginRenderingKhr = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkRenderingInfo*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdEndRenderingKHR(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdEndRenderingKHR");
            PfnVkCmdEndRenderingKhr = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrWaitSemaphoresKHR(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkWaitSemaphoresKHR");
            PfnVkWaitSemaphoresKhr = (delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkSemaphoreWaitInfo*,
                ulong,
                VkResult>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrGetSemaphoreCounterValueKHR(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkGetSemaphoreCounterValueKHR");
            PfnVkGetSemaphoreCounterValue = (delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkSemaphore_T*,
                ulong*,
                VkResult>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetScissorWithCountEXT(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetScissorWithCountEXT");
            PfnVkCmdSetScissorWithCountExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkRect2D*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetViewportWithCountEXT(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetViewportWithCountEXT");
            PfnVkCmdSetViewportWithCountExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkViewport*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdBindVertexBuffers2EXT(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdBindVertexBuffers2EXT");
            PfnVkCmdBindVertexBuffers2Ext = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                VkBuffer_T**,
                ulong*,
                ulong*,
                ulong*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCreateShadersExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCreateShadersEXT");
            PfnVkCreateShadersExt = (delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                uint,
                VkShaderCreateInfoEXT*,
                VkAllocationCallbacks*,
                VkShaderEXT_T**,
                VkResult>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrDestroyShaderExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkDestroyShaderEXT");
            PfnVkDestroyShaderExt = (delegate* unmanaged[Cdecl]<
                VkDevice_T*,
                VkShaderEXT_T*,
                VkAllocationCallbacks*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdBindShadersExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdBindShadersEXT");
            PfnVkCmdBindShadersExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkShaderStageFlagBits*,
                VkShaderEXT_T**,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetPolygonModeExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetPolygonModeEXT");
            PfnVkCmdSetPolygonModeExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkPolygonMode,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetRasterizationSamplesExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetRasterizationSamplesEXT");
            PfnVkCmdSetRasterizationSamplesExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkSampleCountFlagBits,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetSampleMaskExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetSampleMaskEXT");
            PfnVkCmdSetSampleMaskExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkSampleCountFlagBits,
                uint*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetDepthClampEnableExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetDepthClampEnableEXT");
            PfnVkCmdSetDepthClampEnableExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetLogicOpExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetLogicOpEXT");
            PfnVkCmdSetLogicOpExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                VkLogicOp,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetLogicOpEnableExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetLogicOpEnableEXT");
            PfnVkCmdSetLogicOpEnableExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetVertexInputExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetVertexInputEXT");
            PfnVkCmdSetVertexInputExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                VkVertexInputBindingDescription2EXT*,
                uint,
                VkVertexInputAttributeDescription2EXT*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetColorBlendEnableExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetColorBlendEnableEXT");
            PfnVkCmdSetColorBlendEnableExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                uint*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetColorBlendEquationExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetColorBlendEquationEXT");
            PfnVkCmdSetColorBlendEquationExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                VkColorBlendEquationEXT*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetColorWriteMaskExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetColorWriteMaskEXT");
            PfnVkCmdSetColorWriteMaskExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                uint,
                uint*,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }

        public void GetProcAddrCmdSetAlphaToCoverageEnableExt(VkDevice_T* i_ptr_device)
        {
            using HeapString ptr = HeapString.CreateUTF8("vkCmdSetAlphaToCoverageEnableEXT");
            PfnVkCmdSetAlphaToCoverageEnableExt = (delegate* unmanaged[Cdecl]<
                VkCommandBuffer_T*,
                uint,
                void>)Vk.vkGetDeviceProcAddr(i_ptr_device, (sbyte*)ptr.RawPtr());
        }
    }
}