
using System.Runtime.InteropServices;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Sugar.Structs.Reflection;
using Silk.NET.SPIRV.Reflect;

namespace Massini.Graphics.VkAL.Sugar.Classes.Reflection
{
    public unsafe class ShadersReflection
    {
        public ShadersReflection(ShadersReflectionSource i_source)
        {
            ShaderReflection[] shaders = new ShaderReflection[i_source.p_code.Length];

            using Silk.NET.SPIRV.Reflect.Reflect api = Silk.NET.SPIRV.Reflect.Reflect.GetApi();

            // Reflect each shader.
            for (int i = 0; i < i_source.p_code.Length; i++)
            {
                Silk.NET.SPIRV.Reflect.ReflectShaderModule shaderModule = new();
                fixed (byte* codePtr = i_source.p_code[i])
                {
                    api.CreateShaderModule((nuint)i_source.p_code[i].Length, codePtr, &shaderModule);
                }

                // Extract basic information.
                string entryPoint = Marshal.PtrToStringUTF8((nint)shaderModule.EntryPointName) ?? string.Empty;
                ShaderStageFlags stageFlag = SpirvReflectShaderStageFlagBitsToShaderStageFlags(shaderModule.ShaderStage);

                // Extract push constants.

                PushConstantReflection? pushConstant = null;
                if (shaderModule.PushConstantBlockCount > 0)
                {
                    if (shaderModule.PushConstantBlockCount > 1)
                    {
                        throw new Exception("Only one push constant block is supported.");
                    }

                    Silk.NET.SPIRV.Reflect.BlockVariable pushConstantBlock = shaderModule.PushConstantBlocks[0];
                    pushConstant = new PushConstantReflection()
                    {
                        Name = Marshal.PtrToStringUTF8((nint)pushConstantBlock.Name) ?? string.Empty,
                        Size = (uint)pushConstantBlock.Size,
                        StageFlags = stageFlag
                    };
                }

                //shaderModule.PushConstantBlocks[0].

                // Extract sets.
                
                uint setsCount = shaderModule.DescriptorSetCount;
                Silk.NET.SPIRV.Reflect.ReflectDescriptorSet*[] setsPtrs = new Silk.NET.SPIRV.Reflect.ReflectDescriptorSet*[setsCount];
                fixed (Silk.NET.SPIRV.Reflect.ReflectDescriptorSet** setsPtr = setsPtrs)
                {
                    api.EnumerateDescriptorSets(ref shaderModule, ref setsCount, setsPtr);
                }

                SetReflection[] sets = new SetReflection[setsCount];
                for (int setIdx = 0; setIdx < setsCount; setIdx++)
                {
                    Silk.NET.SPIRV.Reflect.ReflectDescriptorSet* set = setsPtrs[setIdx];

                    // Extract set basic information.
                    uint setNumber = set->Set;

                    SetBindingReflection[] bindings = new SetBindingReflection[set->BindingCount];

                    // Extract bindings.
                    for (int bindingIdx = 0; bindingIdx < set->BindingCount; bindingIdx++)
                    {
                        Silk.NET.SPIRV.Reflect.DescriptorBinding* bindingPtr = set->Bindings[bindingIdx];
                        
                        // Extract binding basic information.
                        string bindingName = Marshal.PtrToStringUTF8((nint)bindingPtr->Name) ?? string.Empty;
                        uint binding = bindingPtr->Binding;
                        uint[] dimensions = new Span<uint>(bindingPtr->Array.Dims, (int)bindingPtr->Array.DimsCount).ToArray();
                        uint count = bindingPtr->Count;
                        bool accessed = bindingPtr->Accessed == 1U;
                        EntryType entryType = SpirvReflectDescriptorTypeToEntryType(bindingPtr->DescriptorType);

                        EntryMode entryMode = bindingPtr->ResourceType == Silk.NET.SPIRV.Reflect.ResourceType.Uav ? EntryMode.ReadWrite : EntryMode.Read;

                        var t1 = bindingPtr->ResourceType;
                        var t2 = bindingPtr->DescriptorType;

                        // Extract bindi ng resources.
                        bindings[bindingIdx] = new SetBindingReflection()
                        {
                            Name = bindingName,
                            BindingNumber = binding,
                            Dimensions = dimensions,
                            Count = count,
                            Accessed = accessed,
                            EntryType = entryType,
                            EntryMode = entryMode,
                            ShaderStage = stageFlag,
                            SetNumber = setNumber,
                        };
                    }

                    sets[setIdx] = new SetReflection()
                    {
                        SetNumber = setNumber,
                        Bindings = bindings,
                    };
                }

                api.DestroyShaderModule(&shaderModule);

                shaders[i] = new ShaderReflection()
                {
                    EntryPoint = entryPoint,
                    Stage = stageFlag,
                    Sets = [.. sets.OrderBy(x => x.SetNumber)],
                    PushConstants = pushConstant,
                };
            }

            // Generate combined sets.
            OrderedDictionary<uint, List<SetReflection>> groupedSets = [];
            foreach (ShaderReflection shader in shaders)
            {
                foreach (SetReflection set in shader.Sets)
                {
                    if (!groupedSets.ContainsKey(set.SetNumber))
                    {
                        groupedSets[set.SetNumber] = [];
                    }

                    groupedSets[set.SetNumber].Add(set);
                }
            }

            SetReflection[] combinedSets = new SetReflection[groupedSets.Count];
            int combinedSetsIdx = 0;
            foreach (List<SetReflection> setsSubgroup in groupedSets.Values)
            {
                List<SetBindingReflection> bindings = [];
                foreach (SetReflection set in setsSubgroup)
                {
                    bindings.AddRange(set.Bindings);
                }

                combinedSets[combinedSetsIdx] = new SetReflection()
                {
                    SetNumber = setsSubgroup[0].SetNumber,
                    Bindings = [.. bindings
                                .GroupBy(x => x.BindingNumber)
                                .OrderBy(x => x.Key)
                                .Select(x =>
                                {
                                    SetBindingReflection first = x.First();

                                    if (x.Any(b => b.EntryType != first.EntryType))
                                    {
                                        throw new Exception($"Binding {first.BindingNumber} has incompatible entry types.");
                                    }

                                    if (x.Any(b => b.EntryMode != first.EntryMode))
                                    {
                                        throw new Exception($"Binding {first.BindingNumber} has incompatible entry modes.");
                                    }

                                    if (x.Any(b => b.Count != first.Count))
                                    {
                                        throw new Exception($"Binding {first.BindingNumber} has incompatible counts.");
                                    }

                                    if (x.Any(b => b.Dimensions != first.Dimensions))
                                    {
                                        throw new Exception($"Binding {first.BindingNumber} has incompatible dimensions.");
                                    }

                                    return new SetBindingReflection()
                                    {
                                        BindingNumber = first.BindingNumber,
                                        Name = first.Name,
                                        Dimensions = first.Dimensions,
                                        Count = first.Count,
                                        Accessed = x.Select(x => x.Accessed).Aggregate((accessedA, accessedB) => accessedA || accessedB),
                                        EntryType = first.EntryType,
                                        EntryMode = first.EntryMode,
                                        ShaderStage = x.Select(x => x.ShaderStage).Aggregate((stageA, stageB) => stageA | stageB),  
                                        SetNumber = setsSubgroup[0].SetNumber,
                                    };
                                })],
                };

                combinedSetsIdx++;
            }

            // Generate combined push constants.
            PushConstantReflection? combinedPushConstant = null;
            foreach (ShaderReflection shader in shaders)
            {
                if (shader.PushConstants != null)
                {
                    if (combinedPushConstant == null)
                    {
                        combinedPushConstant = shader.PushConstants;
                    }
                    else if (combinedPushConstant.Size != shader.PushConstants.Size)
                    {
                        throw new Exception("Push constants are incompatible between shaders.");
                    }
                    else
                    {
                        combinedPushConstant.StageFlags |= shader.PushConstants.StageFlags;
                    }
                }
            }

            Shaders = shaders;
            Sets = [.. combinedSets.OrderBy(x => x.SetNumber)];
            PushConstants = combinedPushConstant;
        }
    
        public ShaderReflection[] Shaders { get; init; }

        public SetReflection[] Sets { get; init; }

        public PushConstantReflection? PushConstants { get; init; }

        public SetBindingReflection? GetBinding(string i_name)
        {
            foreach (var set in Sets)
            {
                var binding = set.GetBinding(i_name);
                if (binding != null) return binding;
            }
            return null;
        }

        public SetReflection? GetSet(uint i_setNumber)
        {
            return Sets.FirstOrDefault(s => s.SetNumber == i_setNumber);
        }

        private static ShaderStageFlags SpirvReflectShaderStageFlagBitsToShaderStageFlags(ShaderStageFlagBits i_stages)
        {
            ShaderStageFlags stages = ShaderStageFlags.None;
            if (i_stages.HasFlag(ShaderStageFlagBits.VertexBit))
            {
                stages |= ShaderStageFlags.Vertex;
            }
            if (i_stages.HasFlag(ShaderStageFlagBits.FragmentBit))
            {
                stages |= ShaderStageFlags.Fragment;
            }
            if (i_stages.HasFlag(ShaderStageFlagBits.ComputeBit))
            {
                stages |= ShaderStageFlags.Compute;
            }
            return stages;
        }

        private static EntryType SpirvReflectDescriptorTypeToEntryType(DescriptorType i_type)
        {
            return i_type switch
            {
                DescriptorType.Sampler => EntryType.Sampler,
                DescriptorType.CombinedImageSampler => throw new NotImplementedException(),
                DescriptorType.SampledImage => EntryType.Texture,
                DescriptorType.StorageImage => throw new NotImplementedException(),
                DescriptorType.UniformTexelBuffer => throw new NotImplementedException(),
                DescriptorType.StorageTexelBuffer => throw new NotImplementedException(),
                DescriptorType.UniformBuffer => EntryType.UniformBuffer,
                DescriptorType.StorageBuffer => EntryType.StorageBuffer,
                DescriptorType.UniformBufferDynamic => throw new NotImplementedException(),
                DescriptorType.StorageBufferDynamic => throw new NotImplementedException(),
                DescriptorType.InputAttachment => throw new NotImplementedException(),
                DescriptorType.AccelerationStructureKhr => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }
    }   
}
