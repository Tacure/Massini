
using Massini.Bindings.Vulkan;
using Massini.Collections;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Interop;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe class ShaderLink : IResource, IDisposable
    {
        /// <inheritdoc/>
        public ResId Id => m_id;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        /// <summary>
        /// The device this shader link belongs to.
        /// </summary>
        public Device Device => m_device;

        /// <summary>
        /// The shader link label.
        /// </summary>
        public string Label => m_label;

        /// <summary>
        /// The shader link layout.
        /// </summary>
        public Layout Layout => m_layout;

        /// <summary>
        /// Creates a shader link.
        /// </summary>
        public ShaderLink(Device i_device, in ShaderLinkCreateParams i_createParams)
        {
            // Early validation.
            bool hasCompute = i_createParams.p_stages.Any(s => s.p_stage == ShaderStageFlags.Compute);
            bool hasGraphics = i_createParams.p_stages.Any(s => s.p_stage != ShaderStageFlags.Compute);

            if (hasCompute && hasGraphics)
            {
                throw new Exception("Compute shader cannot be combined with graphics stages.");
            }

            // Create and link shader objects.

            // Prepare shaders data.
            List<UnsafeAlloc> entryPoints = [];
            sbyte*[] entryPointNames = new sbyte*[i_createParams.p_stages.Length];
            ShaderStageFlags[] shadersNextStage = new ShaderStageFlags[i_createParams.p_stages.Length];
            m_shaderStages = new ShaderStageFlags[i_createParams.p_stages.Length];
            DynamicArray<byte> spirvCode = [];
            for (uint i = 0; i < i_createParams.p_stages.Length; i++)
            {
                ref ShaderLinkStage stage = ref i_createParams.p_stages[i];

                // Copy code.
                for (int j = 0; j < stage.p_code.Length; j++)
                {
                    spirvCode.Add(stage.p_code[j]);
                }

                // Convert entry point to native string.
                UnsafeAlloc nativeEntryPoint = UnsafeString.StringToPtrUTF8(stage.p_entryPoint);
                entryPoints.Add(nativeEntryPoint);
                entryPointNames[i] = (sbyte*)nativeEntryPoint.ToRawPtr();

                // Determine next stage.
                if (i < i_createParams.p_stages.Length - 1)
                {
                    // TODO: Implement a robust way to determine next stage.
                    shadersNextStage[i] = i_createParams.p_stages[i + 1].p_stage;

                    if (!VkUtils.IsValidTransition(stage.p_stage, shadersNextStage[i]))
                    {
                        throw new Exception($"Invalid shader stage transition: {stage.p_stage} -> {shadersNextStage[i]}");
                    }
                }
                else
                {
                    shadersNextStage[i] = ShaderStageFlags.None;

                    if (!VkUtils.IsValidTransition(stage.p_stage, shadersNextStage[i]))
                    {
                        throw new Exception("Invalid final shader stage.");
                    }
                }

                // Store current stage.
                m_shaderStages[i] = stage.p_stage;
            }

            fixed (byte* codePtr = spirvCode.AsSpan())
            {
                fixed (VkDescriptorSetLayout_T** descriptorSetLayoutsPtr = i_createParams.p_layout.SetLayoutsPtrs)
                {
                    VkPushConstantRange pushConstantRange = i_createParams.p_layout.PushConstantRange ?? default;

                    // Fill shader create infos.
                    int codeOffset = 0;
                    VkShaderCreateInfoEXT[] shaderCreateInfos = new VkShaderCreateInfoEXT[i_createParams.p_stages.Length];

                    for (int i = 0; i < i_createParams.p_stages.Length; i++)
                    {
                        ref ShaderLinkStage stage = ref i_createParams.p_stages[i];
                        ShaderStageFlags nextStage = shadersNextStage[i];
                        sbyte* entryPoint = entryPointNames[i];

                        VkShaderCreateInfoEXT shaderCreateInfo = new()
                        {
                            sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_CREATE_INFO_EXT,
                            pNext = null,
                            flags = (uint)VkShaderCreateFlagBitsEXT.VK_SHADER_CREATE_LINK_STAGE_BIT_EXT,
                            codeSize = (nuint)stage.p_code.Length,
                            pCode = codePtr + codeOffset,
                            stage = VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(stage.p_stage),
                            nextStage = (uint)VkUtils.ShaderStageFlagsToVkShaderStageFlagBits(nextStage),
                            codeType = VkShaderCodeTypeEXT.VK_SHADER_CODE_TYPE_SPIRV_EXT,
                            pName = entryPoint,
                            pSpecializationInfo = null, // TODO: Check if this parameter is useful.
                            pPushConstantRanges = i_createParams.p_layout.PushConstantRange.HasValue ? &pushConstantRange : null,
                            pushConstantRangeCount = i_createParams.p_layout.PushConstantRange.HasValue ? 1U : 0U,
                            pSetLayouts = descriptorSetLayoutsPtr,
                            setLayoutCount = (uint)i_createParams.p_layout.SetLayoutsPtrs.Length,
                        };
                        shaderCreateInfos[i] = shaderCreateInfo;

                        codeOffset += stage.p_code.Length;
                    }

                    // Create shader objects.
                    VkShaderEXT_T*[] shaders = new VkShaderEXT_T*[i_createParams.p_stages.Length];
                    fixed (VkShaderCreateInfoEXT* shaderCreateInfosPtr = shaderCreateInfos)
                    {
                        fixed (VkShaderEXT_T** shadersPtr = shaders)
                        {
                            i_device.Funcs.PfnVkCreateShadersExt(i_device.VkDevicePtr, (uint)i_createParams.p_stages.Length, shaderCreateInfosPtr, null, shadersPtr);
                        }
                    }

                    // Set debug names.
                    for (int i = 0; i < i_createParams.p_stages.Length; i++)
                    {
                        VkShaderEXT_T* shader = shaders[i];
                        VkUtils.SetObjectLabel(i_device, shader, VkObjectType.VK_OBJECT_TYPE_SHADER_EXT, $"{nameof(ShaderLink)} - {i_createParams.p_label} - {i_createParams.p_stages[i].p_stage}");
                    }

                    m_label = i_createParams.p_label;

                    // Store data.
                    m_id = ResId.GetNextId();
                    m_device = i_device;
                    m_layout = i_createParams.p_layout;
                    m_shadersPtrs = shaders;
                }
            }

            // Free unmanaged memory.
            foreach (var entryPoint in entryPoints)
            {
                entryPoint.Dispose();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);

                for (int i = 0; i < m_shadersPtrs.Length; i++)
                {
                    m_device.Funcs.PfnVkDestroyShaderExt(m_device.VkDevicePtr, m_shadersPtrs[i], null);
                }

                m_layout.Dispose();
            }
        }

        internal VkShaderEXT_T*[] VkShadersPtrs => m_shadersPtrs;

        internal ShaderStageFlags[] Stages => m_shaderStages;

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Device m_device;
        private readonly Layout m_layout;
        private readonly VkShaderEXT_T*[] m_shadersPtrs;
        private readonly ShaderStageFlags[] m_shaderStages;
    }
}